/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 11/05/2006
 * Time: 15:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Description of CmdSincronizar.
	/// </summary>
	public class CmdSincronizar
		: Comando
	{
		
		private static DataSet BuildComplexData()
		{
			DataSet ds = new DataSet("ComplexData");
			DataTable dt0 = new DataTable("Joins");
			dt0.Columns.Add(new DataColumn("CampoCPD", System.Type.GetType("System.String")));
			dt0.Columns.Add(new DataColumn("CampoSIGUA", System.Type.GetType("System.String")));
			dt0.PrimaryKey = new DataColumn[2] {dt0.Columns["CampoCPD"], dt0.Columns["CampoSIGUA"]};
			DataTable dt1 = new DataTable("Correspondencias");
			dt1.Columns.Add(new DataColumn("CampoCPD", System.Type.GetType("System.String")));
			dt1.Columns.Add(new DataColumn("CampoSIGUA", System.Type.GetType("System.String")));
			dt1.PrimaryKey = new DataColumn[2] {dt1.Columns["CampoCPD"], dt1.Columns["CampoSIGUA"]};
			DataTable dt2 = new DataTable("Defaults");
			dt2.Columns.Add(new DataColumn("CampoSIGUA", System.Type.GetType("System.String")));
			dt2.Columns.Add(new DataColumn("Valor", System.Type.GetType("System.String")));
			dt2.PrimaryKey = new DataColumn[1] {dt2.Columns["CampoSIGUA"]};
			dt2.Columns["CampoSIGUA"].AllowDBNull = false;
			DataTable dt3 = new DataTable("Excepciones");
			DataTable dt4 = new DataTable("Simulaciones");
			dt4.Columns.Add(new DataColumn("Descripcion", System.Type.GetType("System.String")));
			dt4.Columns.Add(new DataColumn("CampoAComprobar", System.Type.GetType("System.String")));
			dt4.Columns.Add(new DataColumn("TablaAjena", System.Type.GetType("System.String")));
			dt4.Columns.Add(new DataColumn("CampoAjeno", System.Type.GetType("System.String")));
			dt4.PrimaryKey = new DataColumn[3] {dt4.Columns["CampoAComprobar"], dt4.Columns["TablaAjena"], dt4.Columns["CampoAjeno"]};
			ds.Tables.Add(dt0);
			ds.Tables.Add(dt1);
			ds.Tables.Add(dt2);
			ds.Tables.Add(dt3);
			ds.Tables.Add(dt4);
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
		
		private bool _aplicarExcepciones = true;
		[XmlAttribute()]
		public bool AplicarExcepciones
		{
			get
			{
				return _aplicarExcepciones;
			}
			set
			{
				_aplicarExcepciones = value;
			}
		}
		
		private DateTime _ultimaEjecucion =  DateTime.MinValue;
		[XmlAttribute()]
		public DateTime UltimaEjecucion
		{
			get
			{
				return _ultimaEjecucion;
			}
			set
			{
				_ultimaEjecucion = value;
			}
		}
		
		public DataTable ComplexDataErrorMessages()
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
		   			foreach (DataRow dr in this._complexData.Tables["Correspondencias"].Rows)
		   			{
		   				DataRow[] selected = schT.Select(string.Format("ColumnName = '{0}'", (string)dr["CampoCPD"]));
	                    if (selected.Length == 0)
	                    {
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la consulta {1} en ORACLE", (string)dr["CampoCPD"], this._tablaCPD);
					   		oTbl.Rows.Add(oRow);	                    	
	                    }		   				
		   			}
		   			if (this._direccion == TipoComprobacion.AltasPendientesEnSIGUA)
		   			{
			   			foreach (DataRow dr in this._complexData.Tables["Simulaciones"].Rows)
			   			{
			   				DataRow[] selected = schT.Select(string.Format("ColumnName = '{0}'", (string)dr["CampoAComprobar"]));
		                    if (selected.Length == 0)
		                    {
						   		DataRow oRow = oTbl.NewRow();
						   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la consulta {1} en ORACLE", (string)dr["CampoAComprobar"], this._tablaCPD);
						   		oTbl.Rows.Add(oRow);	                    	
		                    }		   				
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
				   	foreach (DataRow dr in this._complexData.Tables["Correspondencias"].Rows)
				   	{
				   		if (!DBUtils.IsColumn(dbOrigen.ORA, string.Format("{0}.{1}", this._tablaCPD.Trim(), (string)dr["CampoCPD"])))
				   		{
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la tabla {1} en ORACLE", (string)dr["CampoCPD"], this._tablaCPD);
					   		oTbl.Rows.Add(oRow);			   						   			
				   		}
				   	}
		   			if (this._direccion == TipoComprobacion.AltasPendientesEnSIGUA)
		   			{
					   	foreach (DataRow dr in this._complexData.Tables["Simulaciones"].Rows)
					   	{
					   		if (!DBUtils.IsColumn(dbOrigen.ORA, string.Format("{0}.{1}", this._tablaCPD.Trim(), (string)dr["CampoAComprobar"])))
					   		{
						   		DataRow oRow = oTbl.NewRow();
						   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la tabla {1} en ORACLE", (string)dr["CampoAComprobar"], this._tablaCPD);
						   		oTbl.Rows.Add(oRow);			   						   			
					   		}
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
		   			foreach (DataRow dr in this._complexData.Tables["Correspondencias"].Rows)
		   			{
		   				DataRow[] selected = schT.Select(string.Format("ColumnName = '{0}'", (string)dr["CampoSIGUA"]));
	                    if (selected.Length == 0)
	                    {
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la consulta {1} en PostgreSQL", (string)dr["CampoSIGUA"], this._tablaSIGUA);
					   		oTbl.Rows.Add(oRow);	                    	
	                    }
		   			}
		   			foreach (DataRow dr in this._complexData.Tables["Defaults"].Rows)
		   			{
		   				DataRow[] selected = schT.Select(string.Format("ColumnName = '{0}'", (string)dr["CampoSIGUA"]));
	                    if (selected.Length == 0)
	                    {
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la consulta {1} en PostgreSQL", (string)dr["CampoSIGUA"], this._tablaSIGUA);
					   		oTbl.Rows.Add(oRow);	                    	
	                    }
		   			}
					if (this._direccion == TipoComprobacion.BajasPendientesEnSIGUA || this._direccion == TipoComprobacion.ModificacionesPendientesEnSIGUA)
					{
			   			foreach (DataRow dr in this._complexData.Tables["Simulaciones"].Rows)
			   			{
			   				DataRow[] selected = schT.Select(string.Format("ColumnName = '{0}'", (string)dr["CampoAComprobar"]));
		                    if (selected.Length == 0)
		                    {
						   		DataRow oRow = oTbl.NewRow();
						   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la consulta {1} en PostgreSQL", (string)dr["CampoAComprobar"], this._tablaSIGUA);
						   		oTbl.Rows.Add(oRow);	                    	
		                    }
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
				   	foreach (DataRow dr in this._complexData.Tables["Correspondencias"].Rows)
				   	{
				   		if (!DBUtils.IsColumn(dbOrigen.PGSQL, string.Format("{0}.{1}", this._tablaSIGUA.Trim(), (string)dr["CampoSIGUA"])))
				   		{
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la tabla {1} en PostgreSQL", (string)dr["CampoSIGUA"], this._tablaSIGUA);
					   		oTbl.Rows.Add(oRow);
				   		}
				   	}
				   	foreach (DataRow dr in this._complexData.Tables["Defaults"].Rows)
				   	{
				   		if (!DBUtils.IsColumn(dbOrigen.PGSQL, string.Format("{0}.{1}", this._tablaSIGUA.Trim(), (string)dr["CampoSIGUA"])))
				   		{
					   		DataRow oRow = oTbl.NewRow();
					   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la tabla {1} en PostgreSQL", (string)dr["CampoSIGUA"], this._tablaSIGUA);
					   		oTbl.Rows.Add(oRow);
				   		}
				   	}				   	
					if (this._direccion == TipoComprobacion.BajasPendientesEnSIGUA || this._direccion == TipoComprobacion.ModificacionesPendientesEnSIGUA)
					{
					   	foreach (DataRow dr in this._complexData.Tables["Simulaciones"].Rows)
					   	{
					   		if (!DBUtils.IsColumn(dbOrigen.PGSQL, string.Format("{0}.{1}", this._tablaSIGUA.Trim(), (string)dr["CampoAComprobar"])))
					   		{
						   		DataRow oRow = oTbl.NewRow();
						   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la tabla {1} en PostgreSQL", (string)dr["CampoAComprobar"], this._tablaSIGUA);
						   		oTbl.Rows.Add(oRow);
					   		}
					   	}
					}
			   	}  	
		   	}
		   	foreach (DataRow dr in this._complexData.Tables["Simulaciones"].Rows)
		   	{
		   		string foreignTable = ((string)dr["TablaAjena"]).Trim();
		   		if (!DBUtils.IsRelation(dbOrigen.PGSQL, foreignTable))
		   		{
			   		DataRow oRow = oTbl.NewRow();
			   		oRow["Mensaje"] = string.Format ("No se encuentra la tabla ajena {0} en PostgreSQL", (string)dr["TablaAjena"]);
			   		oTbl.Rows.Add(oRow);
		   		}
		   		else
		   		{
		   			if (!DBUtils.IsColumn(dbOrigen.PGSQL, string.Format("{0}.{1}", foreignTable, (string)dr["CampoAjeno"])))
			   		{
				   		DataRow oRow = oTbl.NewRow();
				   		oRow["Mensaje"] = string.Format ("No se encuentra la columna {0} de la tabla ajena {1} en PostgreSQL", (string)dr["CampoAjeno"], (string)dr["TablaAjena"]);
				   		oTbl.Rows.Add(oRow);
			   		}		   				
		   		}
		   	}
		   	return oTbl;
		}
		
		public DataTable ObtenerDatos()
		{
			DataTable afectados;
			afectados = this.ComplexDataErrorMessages();
			if (afectados.Rows.Count == 0)
			{
				if (_aplicarExcepciones)
				{
					CfgExcepciones helper = new CfgExcepciones(this);
					afectados = helper.ObtenerAfectados();
					if (helper.IsValid && _direccion == TipoComprobacion.ModificacionesPendientesEnSIGUA)
					{
						afectados.DefaultView.RowStateFilter = DataViewRowState.ModifiedCurrent;
						afectados = afectados.DefaultView.ToTable();
					}				
				}
				else
				{
					afectados = DBUtils.GetRelationDataSet(this).Tables[0];
					if (afectados.TableName != "Excepcion" && _direccion == TipoComprobacion.ModificacionesPendientesEnSIGUA)
					{
						afectados.DefaultView.RowStateFilter = DataViewRowState.ModifiedCurrent;
						afectados = afectados.DefaultView.ToTable();
					}
				}
			}
			return afectados;
		}

		public DataTable Simular()
		{
			DataTable resultado;
			DataTable afectados;
			bool abortar = false;
			
			resultado = this.ComplexDataErrorMessages();
			if (resultado.Rows.Count == 0)
			{
				if (_aplicarExcepciones)
				{
					CfgExcepciones helper = new CfgExcepciones(this);
					afectados = helper.ObtenerAfectados();
					abortar = (helper.IsValid == false);
				}
				else
				{
					afectados = DBUtils.GetRelationDataSet(this).Tables[0];
					abortar = (afectados.TableName == "Excepcion");
				}
				if (!abortar)
				{
					resultado = new DataTable();
					resultado.Columns.Add(new DataColumn("Incidencia__", System.Type.GetType("System.String")));
					foreach (DataColumn dc in afectados.Columns)
					{
						resultado.Columns.Add(dc.ColumnName, dc.DataType);
					}
					
					foreach (DataRow dr in _complexData.Tables["Simulaciones"].Rows)
					{
						string sql = string.Format("SELECT DISTINCT {0} FROM {1}", dr["CampoAjeno"], dr["TablaAjena"]);
						DataTable dtLookUp = DBUtils.GetDataSet(dbOrigen.PGSQL, sql, null).Tables[0];
						List<object[]> listUnjoined = DBUtils.GetUnjoined(afectados.Copy(), (string) dr["CampoAComprobar"], dtLookUp.Copy(), (string) dr["CampoAjeno"], _direccion);
						foreach (object[] row in listUnjoined)
						{
							int i = row.GetLength(0);
							object[] newrow = new object[i+1];
							newrow[0] = dr["Descripcion"];
							Array.ConstrainedCopy(row, 0, newrow, 1, i);
							resultado.LoadDataRow(newrow, true);
						}
					}
				}
				else
				{
					resultado = afectados;
				}
			}
			return resultado;
		}		
		
		public DataTable Sincronizar()
		{
			
			DataTable resultado;
			DataTable afectados;
			bool abortar = false;
			
			resultado = this.ComplexDataErrorMessages();
			if (resultado.Rows.Count == 0)
			{
				if (_aplicarExcepciones)
				{
					CfgExcepciones helper = new CfgExcepciones(this);
					afectados = helper.ObtenerAfectados();
					abortar = (helper.IsValid == false);
				}
				else
				{
					afectados = DBUtils.GetRelationDataSet(this).Tables[0];
					abortar = (afectados.TableName == "Excepcion");
				}
				if (!abortar)
				{
					DataSet ds = new DataSet();
					string sql = string.Empty;
					if (this._tablaSIGUA.Trim().StartsWith("SELECT", StringComparison.InvariantCultureIgnoreCase))
					{
						sql = this._tablaSIGUA.Trim();
					}
					else
					{
						sql = string.Format("SELECT * FROM {0} WHERE 0 = 1", this._tablaSIGUA);
					}
					
					switch (_direccion)
					{
						case (TipoComprobacion.AltasPendientesEnSIGUA) :
							DataTable afectadosExport = this.ExportData(afectados, 
							                                            this._tablaSIGUA, 
							                                            this._complexData.Tables["Joins"], 
							                                            this._complexData.Tables["Correspondencias"],
							                                            this._complexData.Tables["Defaults"]);
							ds.Tables.Add(afectadosExport);
							if (afectadosExport.TableName == "Excepcion")
							{
								resultado = afectadosExport;
							}
							else
							{			
								resultado = DBUtils.UpdateDB(sql, null, ds).Tables[0];
								_ultimaEjecucion = DateTime.Now;
							}
							break;
						case (TipoComprobacion.BajasPendientesEnSIGUA) :
							DataTable afectadosCopy = this.CopyData(afectados, this._tablaSIGUA);
							ds.Tables.Add(afectadosCopy);
							if (afectadosCopy.TableName == "Excepcion")
							{
								resultado = afectadosCopy;
							}
							else
							{
								//Marcar filas para borrado
								foreach (DataRow dr in afectadosCopy.Rows)
								{
									dr.Delete();
								}
								resultado = DBUtils.UpdateDB(sql, null, ds).Tables[0];
								_ultimaEjecucion = DateTime.Now;
							}
							break;
						case (TipoComprobacion.ModificacionesPendientesEnSIGUA) :
							DataTable modificadosCopy = afectados.Copy();
							modificadosCopy.TableName = "Table";
							ds.Tables.Add(modificadosCopy);
							if (modificadosCopy.TableName == "Excepcion")
							{
								resultado = modificadosCopy;
							}
							else
							{
								resultado = DBUtils.UpdateDB(sql, null, ds).Tables[0];
								_ultimaEjecucion = DateTime.Now;
							}
							break;
						default :
							DBUtils.FillExceptionDataSet(ds, "No se ejecutó ningún comando");
							resultado = ds.Tables[0];
							break;
					}
				}
				else
				{
					resultado = afectados;
				}
			}
			return resultado;
		}
		
		
		
		private DataTable ExportData(DataTable inputTable, string outputTableName, DataTable joinData, DataTable fieldMappingData, DataTable defaultsData)
		{
			string sql = string.Empty;
			if (this._tablaSIGUA.Trim().StartsWith("SELECT", StringComparison.InvariantCultureIgnoreCase))
			{
				sql = outputTableName.Trim();
			}
			else
			{
				sql = string.Format("SELECT * FROM {0} WHERE 0 = 1", outputTableName);
			}
			
			DataTable outputTable = DBUtils.GetDataSet(dbOrigen.PGSQL, sql, null).Tables[0].Copy();

			if (outputTable.TableName != "Excepcion")
			{
				//Comprobamos la compatibilidad del mapeo de campos
				List<string> uncompats = new List<string>();
				foreach (DataRow dr in joinData.Rows)
				{
					if (inputTable.Columns[Convert.ToString(dr["CampoCPD"])].DataType != outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType)
					{
						uncompats.Add(Convert.ToString(dr["CampoSIGUA"]));
					}
				}
				foreach (DataRow dr in fieldMappingData.Rows)
				{
					if (inputTable.Columns[Convert.ToString(dr["CampoCPD"])].DataType != outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType)
					{
						uncompats.Add(Convert.ToString(dr["CampoSIGUA"]));
					}
				}				

				foreach (DataRow inputRow in inputTable.Rows)
				{
					DataRow outputRow = outputTable.NewRow();
					foreach (DataRow dr in joinData.Rows)
					{
						if (!uncompats.Contains(Convert.ToString(dr["CampoSIGUA"])))
						{
							outputRow[Convert.ToString(dr["CampoSIGUA"])] = inputRow[Convert.ToString(dr["CampoCPD"])];
						}
						else
						{
							try
							{
								outputRow[Convert.ToString(dr["CampoSIGUA"])] = Convert.ChangeType(inputRow[Convert.ToString(dr["CampoCPD"])], outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType);
							}
							catch
							{
								DBUtils.FillExceptionDataSet(new DataSet(), 
								                             string.Format("No se puede convertir {0} : {1} en {2}", 
								                                           inputRow[Convert.ToString(dr["CampoCPD"])],
								                                           inputTable.Columns[Convert.ToString(dr["CampoCPD"])].DataType.Name,
								                                           outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType.Name));
							}						}						
					}
					foreach (DataRow dr in fieldMappingData.Rows)
					{
						if (!uncompats.Contains(Convert.ToString(dr["CampoSIGUA"])))
						{
							outputRow[Convert.ToString(dr["CampoSIGUA"])] = inputRow[Convert.ToString(dr["CampoCPD"])];
						}
						else
						{
							try
							{
								outputRow[Convert.ToString(dr["CampoSIGUA"])] = Convert.ChangeType(inputRow[Convert.ToString(dr["CampoCPD"])], outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType);
							}
							catch
							{
								DBUtils.FillExceptionDataSet(new DataSet(), 
								                             string.Format("No se puede convertir {0} : {1} en {2}", 
								                                           inputRow[Convert.ToString(dr["CampoCPD"])],
								                                           inputTable.Columns[Convert.ToString(dr["CampoCPD"])].DataType.Name,
								                                           outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType.Name));
							}
						}
					}
					foreach (DataRow dr in defaultsData.Rows)
					{
						string valor = Convert.ToString(dr["Valor"]);
						if (outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType == typeof(string))
						{
							outputRow[Convert.ToString(dr["CampoSIGUA"])] = valor;
						}
						if (outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType == typeof(bool))
						{
							bool b;
							bool.TryParse(valor, out b);
							outputRow[Convert.ToString(dr["CampoSIGUA"])] = b;
						}
						if (outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType == typeof(short))
						{
							short s;
							short.TryParse(valor, out s);
							outputRow[Convert.ToString(dr["CampoSIGUA"])] = s;
						}							
						if (outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType == typeof(int))
						{
							int i;
							int.TryParse(valor, out i);
							outputRow[Convert.ToString(dr["CampoSIGUA"])] = i;
						}
						if (outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType == typeof(long))
						{
							long l;
							long.TryParse(valor, out l);
							outputRow[Convert.ToString(dr["CampoSIGUA"])] = l;
						}
						if (outputTable.Columns[Convert.ToString(dr["CampoSIGUA"])].DataType == typeof(DateTime))
						{
							DateTime t;
							DateTime.TryParse(valor, out t);
							outputRow[Convert.ToString(dr["CampoSIGUA"])] = t;
						}
					}
					outputTable.Rows.Add(outputRow);
				}
				
			}
			return outputTable;
		}
		
		private DataTable CopyData(DataTable inputTable, string outputTableName)
		{
			string sql = string.Format("SELECT * FROM {0} WHERE 0 = 1", outputTableName);
			DataTable outputTable = DBUtils.GetDataSet(dbOrigen.PGSQL, sql, null).Tables[0].Copy();
			if (outputTable.TableName != "Excepcion")
			{				
				foreach (DataRow inputRow in inputTable.Rows)
				{
					DataRow outputRow = outputTable.NewRow();
					outputRow.ItemArray = inputRow.ItemArray;
					outputTable.Rows.Add(outputRow);
				}
				outputTable.AcceptChanges();
			}
			return outputTable;
		}
		
		private bool IsConvertible(object val, Type toType)
		{
			try
			{
				Convert.ChangeType(val, toType);
				return true;
			}
			catch
			{
				return false;
			}
		}
				
		public CmdSincronizar()
		{
			
		}
	}
}
