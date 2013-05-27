/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/03/2006
 * Time: 14:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.ModeloDocumento;

namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Clase serializable que define el conjunto de operaciones implicadas
	/// en una sesión de sincronización entre SIGUANET/PostgreSQL y ORACLE.
	/// </summary>
	public class SesionSinc : RootModule
	{
		
		private string _nombre = "Sincronización";
		[XmlAttribute]
		public string Nombre
		{
			get 
			{
				return _nombre;
			}
			set
			{
				_nombre = value;
			}
		}
		
		private string _descripcion = "Nueva Sesión de sincronización";
		[XmlAttribute]
		public string Descripcion
		{
			get
			{
				return _descripcion;
			}
			set
			{
				_descripcion = value;
			}
		}
		
		private List<Operacion> _operaciones = new List<Operacion>();
		[XmlArray]
		public List<Operacion> Operaciones
		{
			get
			{
				return _operaciones;
			}
			set
			{
				_operaciones = value;
			}
		}
		
		private string _doc = string.Empty;
		[XmlAttribute]
		public string Doc
		{
			get
			{
				return _doc;
			}
			set
			{
				_doc = value;
			}
		}
		
		public SesionSinc()
		{
			
		}
		
		public string SiguienteNombreOperacion()
		{
			int i = 0;
			int nextOc = 0;

			foreach (Operacion op in this._operaciones)
			{
				i = Convert.ToInt32(op.Nombre.Substring(2));
				if (i > nextOc) nextOc = i;
			}
			return string.Format("OP{0}", (nextOc+1).ToString("00000"));
		}		
	}
}
