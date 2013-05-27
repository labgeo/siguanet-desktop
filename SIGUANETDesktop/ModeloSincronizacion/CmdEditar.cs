/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 11/04/2006
 * Time: 8:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Description of CmdEditar.
	/// </summary>
	public class CmdEditar
		: CmdSeleccionar
	{
		
		private DataSet _data;

		public override DataTable ObtenerDatos()
		{
			_data = DBUtils.GetDataSet(this.Origen, this.SQL, null);
			return _data.Tables[0];
		}
		
		public DataTable Actualizar()
		{
			DataTable resultado;
			if (_data == null)
			{
				_data = DBUtils.GetDataSet(this.Origen, this.SQL, null);
			}
			if (_data.Tables[0].TableName == "Excepcion")
			{
				resultado = _data.Tables[0];
			}
			else
			{
				resultado = DBUtils.UpdateDB(this.SQL, null, _data).Tables[0];
			}
			return resultado;
		}
		
		public CmdEditar()
		{
			
		}
	}
}
