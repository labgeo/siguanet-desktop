/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tom�s
 * Fecha: 17/03/2008
 * Hora: 13:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

using System;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.ModeloDocumento;

namespace SIGUANETDesktop.ModeloAdminTools
{
	/// <summary>
	/// Description of SesionAT.
	/// </summary>
	public class SesionAT : RootModule
	{	
		private string _nombre = "Herramientas administrativas";
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
		
		private string _descripcion = "Herramientas espec�ficas para administradores de la aplicaci�n SIGUANETDesktop";
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
		
		public SesionAT()
		{
		}		
	}
}
