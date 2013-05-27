/*
 * Created by SharpDevelop.
 * User: Jose Tom�s
 * Date: 26/05/2006
 * Time: 14:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.ModeloDocumento;

namespace SIGUANETDesktop.ModeloClienteSQL
{
	/// <summary>
	/// Description of SesionSQL.
	/// </summary>
	public class SesionSQL : RootModule
	{
		private string _nombre = "SQL";
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
		
		private string _descripcion = "Cliente SQL";
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
		
		public SesionSQL()
		{
		}
	}
}
