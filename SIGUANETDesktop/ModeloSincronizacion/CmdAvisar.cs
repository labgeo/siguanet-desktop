/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 23/05/2006
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.Utilidades;

namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Description of CmdAvisar.
	/// </summary>
	public class CmdAvisar
		: CmdSeleccionar
	{
		
		private static DataSet BuildComplexData()
		{
			DataSet ds = new DataSet("ComplexData");
			DataTable dt = new DataTable("Expresiones");
			dt.Columns.Add(new DataColumn("Expresion", System.Type.GetType("System.String")));
			dt.Columns.Add(new DataColumn("Mensaje", System.Type.GetType("System.String")));
			dt.PrimaryKey = new DataColumn[1] {dt.Columns["Expresion"]};
			ds.Tables.Add(dt);
			return ds;
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
		
		private bool Eval(object val, string expresion)
		{
			bool r = false;
			int n;
			try
			{
				expresion = expresion.ToLower().Replace(" ", string.Empty);
				switch (Regex.getExpType(expresion))
				{
					case (Regex.expType.equals):
						if (int.TryParse(expresion.Substring(1), out n))
						{
							if (val.GetType() == typeof(short)) r = ((short) val == n);
							if (val.GetType() == typeof(int)) r = ((int) val == n);
							if (val.GetType() == typeof(long)) r = ((long) val == n);
							if (val.GetType() == typeof(Decimal)) r = ((Decimal) val == n);
						}
						break;
					case (Regex.expType.notequals):
						if (int.TryParse(expresion.Substring(2), out n))
						{
							if (val.GetType() == typeof(short)) r = ((short) val != n);
							if (val.GetType() == typeof(int)) r = ((int) val != n);
							if (val.GetType() == typeof(long)) r = ((long) val != n);
							if (val.GetType() == typeof(Decimal)) r = ((Decimal) val != n);
						}
						break;
					case (Regex.expType.stringequals):
							r = ((string) val == expresion.Substring(1));
						break;
					case (Regex.expType.stringnotequals):
							r = ((string) val != expresion.Substring(2));
						break;			
					case (Regex.expType.greater):
						if (int.TryParse(expresion.Substring(1), out n))
						{
							if (val.GetType() == typeof(short)) r = ((short) val > n);
							if (val.GetType() == typeof(int)) r = ((int) val > n);
							if (val.GetType() == typeof(long)) r = ((long) val > n);
							if (val.GetType() == typeof(Decimal)) r = ((Decimal) val > n);
						}
						break;
					case (Regex.expType.less):
						if (int.TryParse(expresion.Substring(1), out n))
						{
							if (val.GetType() == typeof(short)) r = ((short) val < n);
							if (val.GetType() == typeof(int)) r = ((int) val < n);
							if (val.GetType() == typeof(long)) r = ((long) val < n);
							if (val.GetType() == typeof(Decimal)) r = ((Decimal) val < n);
						}
						break;
					case (Regex.expType.greaterequals):
						if (int.TryParse(expresion.Substring(2), out n))
						{
							if (val.GetType() == typeof(short)) r = ((short) val >= n);
							if (val.GetType() == typeof(int)) r = ((int) val >= n);
							if (val.GetType() == typeof(long)) r = ((long) val >= n);
							if (val.GetType() == typeof(Decimal)) r = ((Decimal) val >= n);
						}
						break;
					case (Regex.expType.lessequals):
						if (int.TryParse(expresion.Substring(2), out n))
						{
							if (val.GetType() == typeof(short)) r = ((short) val <= n);
							if (val.GetType() == typeof(int)) r = ((int) val <= n);
							if (val.GetType() == typeof(long)) r = ((long) val <= n);
							if (val.GetType() == typeof(Decimal)) r = ((Decimal) val <= n);
						}
						break;
					case (Regex.expType.istrue):
						r = ((bool) val == true);
						break;
					case (Regex.expType.isfalse):
						r = ((bool) val == false);
						break;
					default:
						r = false;
						break;
				}
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message,
				                                     "Error al evaluar la expresión",
				                                     System.Windows.Forms.MessageBoxButtons.OK,
				                                     System.Windows.Forms.MessageBoxIcon.Error);
				r = false;
			}

			return r;
		}
		
		public override DataTable ObtenerDatos()
		{
			DataTable dt;
			object r=  DBUtils.GetScalar(this.Origen, this.SQL, null);
			if (r.GetType() != typeof(DataSet))
			{
				dt = new DataTable("Avisos");
				dt.Columns.Add("Mensaje", Type.GetType("System.String"));
				foreach (DataRow dr in _complexData.Tables["Expresiones"].Rows)
				{
					if (this.Eval(r, (string) dr["Expresion"]))
					{
					 	DataRow aviso = dt.NewRow();
		   				aviso["Mensaje"] = dr["Mensaje"];
		   				dt.Rows.Add(aviso);
					}
				}
				dt.AcceptChanges();
			}
			else
			{
				//Excepción en GerScalar
				DataSet ds = (DataSet)r;
				dt = ds.Tables[0];
			}
			return dt;
		}

		public CmdAvisar()
		{
		}
		
	}
}
