/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/04/2006
 * Time: 14:41
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
	/// Description of CmdSeleccionar.
	/// </summary>
	public class CmdSeleccionar
		: Comando
	{
		private dbOrigen _origen = dbOrigen.PGSQL;
		[XmlAttribute]
		public dbOrigen Origen
		{
			get
			{
				return _origen;
			}
			set
			{
				_origen = value;
			}
		}
		
		private string _SQL = String.Empty;
		[XmlAttribute]
		public string SQL
		{
			get
			{
				return _SQL;
			}
			set
			{
				_SQL = value;
			}
		}
		
		public virtual DataTable ObtenerDatos()
		{
			return DBUtils.GetDataSet(this._origen, this._SQL, null).Tables[0];
		}
		
		public CmdSeleccionar()
		{
			
		}
	}
}
