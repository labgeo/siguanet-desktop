/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 11/04/2006
 * Time: 8:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Description of CmdComparar.
	/// </summary>
	public class CmdComparar
		: Comando
	{
		
		private static DataSet BuildComplexData()
		{
			DataSet ds = new DataSet("ComplexData");
			DataTable dt = new DataTable("Joins");
			dt.Columns.Add(new DataColumn("CampoCPD", System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("CampoSIGUA", System.Type.GetType("System.String")));
			dt.PrimaryKey = new DataColumn[2] {dt.Columns["CampoCPD"], dt.Columns["CampoSIGUA"]};
			ds.Tables.Add(dt);
			return ds;
		}
		
		private TipoComprobacion _direccion = TipoComprobacion.AltasPendientesEnSIGUA;
		[XmlAttribute()]
		public TipoComprobacion Direccion
		{
			get
			{
				return _direccion;
			}
			set
			{
				_direccion = value;
			}
		}
		
		private string _tablaCPD = string.Empty;
		[XmlAttribute()]
		public string TablaCPD
		{
			get
			{
				return _tablaCPD;
			}
			set
			{
				_tablaCPD = value;
			}
		}

		private string _tablaSIGUA = string.Empty;
		[XmlAttribute()]
		public string TablaSIGUA
		{
			get
			{
				return _tablaSIGUA;
			}
			set
			{
				_tablaSIGUA = value;
			}
		}
		
		private DataSet _complexData = BuildComplexData();
		[XmlElement(Type = typeof(DataSet))]
		public DataSet ComplexData
		{
			get
			{
				return _complexData;
			}
			set
			{
				_complexData = value;
			}
		}

		public CmdComparar()
		{
			
		}
		
		private DataTable ComplexDataErrorMessages()
		{
			DataTable oTbl = new DataTable("Excepcion");
		   	oTbl.Columns.Add("Mensaje", Type.GetType("System.String"));
		   	
		   	//VALIDACIONES DE ESQUEMA EN ORACLE
		   	if (this._tablaCPD.Trim().ToUpper().StartsWith("SELECT"))
		   	{
		   		DataTable schT = DBUtils.GetSchemaFromQuery(dbOrigen.ORA, this._tablaCPD, null).Tables[0];
		   		if (schT.TableName == "Excepcion")
		   		{
			   		DataRow oRow = oTbl.NewRow();
			   		oRow["Mensaje"] = string.Format ("Error al ejecutar la consulta {0} en ORACLE: {1}", this._tablaCPD, (string)schT.Rows[0]["Mensaje"]);
			   		oTbl.Rows.Add(oRow);
		   		}
		   		else
		   		{
		   			foreach (DataRow dr in this._complexData.Tables["Joins"].Rows)
		   			{
		   				DataRow[] selected = schT.Select(string.Format("ColumnName = '{0}'", (string)dr["CampoCPD"]));
	                    if (selected.Length == 0)
	                    {
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la consulta {1} en ORACLE", (string)dr["CampoCPD"], this._tablaCPD);
					   		oTbl.Rows.Add(oRow);
	                    }
		   			}
		   		}
		   	}
		   	else
		   	{
				if (!DBUtils.IsRelation(dbOrigen.ORA, this._tablaCPD.Trim()))
				{
			   		DataRow oRow = oTbl.NewRow();
			   		oRow["Mensaje"] = string.Format ("No se encuentra la tabla {0} en ORACLE", this._tablaCPD);
			   		oTbl.Rows.Add(oRow);
				}
			   	else
			   	{
				   	foreach (DataRow dr in this._complexData.Tables["Joins"].Rows)
				   	{
				   		if (!DBUtils.IsColumn(dbOrigen.ORA, string.Format("{0}.{1}", this._tablaCPD.Trim(), (string)dr["CampoCPD"])))
				   		{
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la tabla {1} en ORACLE", (string)dr["CampoCPD"], this._tablaCPD);
					   		oTbl.Rows.Add(oRow);			   						   			
				   		}
				   	}				   	
			   	}
		   	}
		   	
		   	//VALIDACIONES DE ESQUEMA EN POSTGRESQL
		   	if (this._tablaSIGUA.Trim().ToUpper().StartsWith("SELECT"))
		   	{
		   		DataTable schT = DBUtils.GetSchemaFromQuery(dbOrigen.PGSQL, this._tablaSIGUA, null).Tables[0];
		   		if (schT.TableName == "Excepcion")
		   		{
			   		DataRow oRow = oTbl.NewRow();
			   		oRow["Mensaje"] = string.Format ("Error al ejecutar la consulta {0} en PostgreSQL: {1}", this._tablaSIGUA, (string)schT.Rows[0]["Mensaje"]);
			   		oTbl.Rows.Add(oRow);		   			
		   		}
		   		else
		   		{
		   			foreach (DataRow dr in this._complexData.Tables["Joins"].Rows)
		   			{
		   				DataRow[] selected = schT.Select(string.Format("ColumnName = '{0}'", (string)dr["CampoSIGUA"]));
	                    if (selected.Length == 0)
	                    {
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la consulta {1} en PostgreSQL", (string)dr["CampoSIGUA"], this._tablaSIGUA);
					   		oTbl.Rows.Add(oRow);	                    	
	                    }
		   			}
		   		}		   		
		   	}
		   	else
		   	{
			   	if (!DBUtils.IsRelation(dbOrigen.PGSQL, this._tablaSIGUA.Trim()))
			   	{
			   		DataRow oRow = oTbl.NewRow();
			   		oRow["Mensaje"] = string.Format ("No se encuentra la tabla {0} en PostgreSQL", this._tablaSIGUA);
			   		oTbl.Rows.Add(oRow);
			   	}
			   	else
			   	{
				   	foreach (DataRow dr in this._complexData.Tables["Joins"].Rows)
				   	{
				   		if (!DBUtils.IsColumn(dbOrigen.PGSQL, string.Format("{0}.{1}", this._tablaSIGUA.Trim(), (string)dr["CampoSIGUA"])))
				   		{
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la tabla {1} en PostgreSQL", (string)dr["CampoSIGUA"], this._tablaSIGUA);
					   		oTbl.Rows.Add(oRow);
				   		}
				   	}
			   	}  	
		   	}
		   	return oTbl;
		}
		
		public DataTable ObtenerDatos()
		{
			DataTable afectados = this.ComplexDataErrorMessages();
			if (afectados.Rows.Count == 0)
			{
				afectados = DBUtils.GetRelationDataSet(this).Tables[0];
			}
			return afectados;
		}
	}
}
