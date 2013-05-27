/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 16/05/2006
 * Time: 8:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Xml.Schema;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Clase auxiliar para configuración de excepciones en comandos de alta y baja.
	/// Asociada a un interfaz gráfico permite 
	/// enlazar la propiedad Data a una DataGridView sobre el que el usuario
	/// puede marcar descartes (excepciones). Usar el método público 
	/// GuardarExcepciones para propagar los cambios al comando de sincronización
	/// subyacente. Usar el método público ObtenerAfectados para recuperar
	/// los registros que serán dados de alta o baja tomando en cuenta las excepciones.
	/// cmd : Objeto de tipo CmdSincronizacion cuyas excepciones se van actualizar.
	///  
	/// </summary>
	public class CfgExcepciones
	{
		private bool schemaValidationError = false;

		private CmdSincronizar _cmd;
		
		private bool _isValid = true;
		public bool IsValid
		{
			get
			{
				return _isValid;
			}
		}
		
		private DataTable _data;
		public DataTable Data
		{
			get
			{
				return _data;
			}
		}		
		
		public CfgExcepciones(CmdSincronizar cmd)
		{
			_cmd = cmd;
			
			//Excepciones previamente definidas
			DataTable excepciones = _cmd.ComplexData.Tables["Excepciones"].Copy();

			//Validación de errores
			_data = cmd.ComplexDataErrorMessages();
			if (_data.Rows.Count > 0)
			{
				//No se pueden recuperar los candidatos ya que el comando está mal definido
				_isValid = false;
				return;
			}
			
			//Candidatos (no coincidentes)
			_data = DBUtils.GetRelationDataSet(cmd).Tables[0].Copy();
			if (_data.TableName == "Excepcion")
			{
				//Se produjo un error a la hora de recuperar los candidatos
				_isValid = false;
			}
			else
			{
				//El método CompareSchemas actualiza el valor del
				//campo schemaValidationError mediante el evento ValidationCallBack
				if (excepciones.Columns.Count == 0)
				{
					schemaValidationError = true;
				}
				else
				{
					this.CompareSchemas(_data, excepciones);
				}
				
				//Inicializamos el valor del campo Descartar a false
				_data.Columns.Add(new DataColumn("Descartar", typeof(bool)));
				foreach (DataRow dr in _data.Rows)
				{
						dr.BeginEdit();
						dr["Descartar"] = false;
						dr.EndEdit();
				}			
				_data.AcceptChanges();
				
				//Evaluamos si schemaValidationError es false
				//para poder marcar como descartes las excepciones
				//previamente definidas. Para esto usamos el mecanismo
				//de la DataRelation. Para definir el join sólo se necesita
				//la clave primaria de la tabla de Candidatos, puesto que
				//el esquema de la tabla de Excepciones es idéntico.
				if (!schemaValidationError)
				{
					try
					{
						//Definimos la relación entre Candidatos y Excepciones
						DataSet ds = new DataSet();
						ds.Tables.Add(_data);
						ds.Tables.Add(excepciones);
						DataRelation join = null;
						List<DataColumn> parentCols = new List<DataColumn>();
						List<DataColumn> childCols = new List<DataColumn>();
						string CampoPK = string.Empty;
						foreach (DataRow joinRow in _cmd.ComplexData.Tables["Joins"].Rows)
						{
							switch(_cmd.Direccion)
							{
								case(TipoComprobacion.AltasPendientesEnSIGUA) :
									CampoPK = (string) joinRow["CampoCPD"];
									break;
								case(TipoComprobacion.BajasPendientesEnSIGUA) :
									CampoPK = (string) joinRow["CampoSIGUA"];
									break;
								case(TipoComprobacion.ModificacionesPendientesEnSIGUA) :
									CampoPK = (string) joinRow["CampoSIGUA"];
									break;								
							}
							parentCols.Add(_data.Columns[CampoPK]);
							childCols.Add(excepciones.Columns[CampoPK]);
						}
		
						join = ds.Relations.Add("Join", parentCols.ToArray(), childCols.ToArray(), false);
						foreach (DataRow parentRow in _data.Rows)
						{
							if (parentRow.GetChildRows(join).Length > 0)
				         	{
								parentRow.BeginEdit();
								parentRow["Descartar"] = true;
								parentRow.EndEdit();
				         	}					
						}
						_data.AcceptChanges();
					}
					catch(Exception e)
					{
						MessageBox.Show(e.Message, "Configurador de Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}				
					
				}
			}
		}
		
		private void CompareSchemas(DataTable masterTable, DataTable slaveTable)
		{
			XmlReaderSettings validator;
    		System.IO.MemoryStream schemaStream = new System.IO.MemoryStream();
    		System.Xml.XmlTextReader schemaReader;
    		System.IO.MemoryStream dataStream = new System.IO.MemoryStream();
    		XmlReader dataReader;
    		
    		//1) XSD (Esquema)
    		masterTable.WriteXmlSchema(schemaStream);
    		schemaStream.Position = 0;
    		schemaReader = new System.Xml.XmlTextReader(schemaStream);
    		
    		//2) XML (Datos)
    		//Provisionalmente igualamos el nombre de la slaveTable 
    		//con el de la masterTable para evitar error en la validación
    		string slaveTableName = slaveTable.TableName;
    		slaveTable.TableName = masterTable.TableName;
    		slaveTable.WriteXml(dataStream, XmlWriteMode.DiffGram);
    		dataStream.Position = 0;
    		
    		// 3) Validación (Datos vs. Esquema)
    		validator = new XmlReaderSettings();
    		//validator.ValidationFlags = XmlSchemaValidationFlags.ProcessInlineSchema;
    		validator.ValidationType = ValidationType.Schema;
    		validator.Schemas.Add(null, schemaReader);
    		validator.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
    		dataReader = XmlReader.Create(dataStream, validator);
    		while (dataReader.Read());
    		dataReader.Close();
    		schemaReader.Close();
    		dataStream.Close();
    		schemaStream.Close();
    		slaveTable.TableName = slaveTableName;
		}
		 
		private void ValidationCallBack(object sender, ValidationEventArgs e) 
		{
			if (e.Severity == XmlSeverityType.Error)
    		{
    			schemaValidationError = true;
    		}			
  		}
		
		public DataTable ObtenerAfectados()
		{
			DataTable dt = _data.Copy();
			if (_isValid)
			{
				foreach (DataRow dr in dt.Rows)
				{
					if (Convert.ToBoolean(dr["Descartar"]) == true)
					{
						dr.Delete();
					}
				}
				dt.AcceptChanges();
				dt.Columns.Remove("Descartar");
				
			}
			return dt;
		}
		public void GuardarExcepciones()
		{
			if (_isValid)
			{			
				DataTable dt = _data.Copy();
				foreach (DataRow dr in dt.Rows)
				{
					if (Convert.ToBoolean(dr["Descartar"]) == false)
					{
						dr.Delete();
					}
				}
				dt.AcceptChanges();
				dt.TableName = "Excepciones";
				dt.Columns.Remove("Descartar");
				_cmd.ComplexData.Tables.Remove("Excepciones");
				_cmd.ComplexData.Tables.Add(dt);
			}
		}
	}
}
