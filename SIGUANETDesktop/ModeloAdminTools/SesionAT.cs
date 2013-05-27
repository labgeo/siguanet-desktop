/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 17/03/2008
 * Hora: 13:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
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
		
		private string _descripcion = "Herramientas específicas para administradores de la aplicación SIGUANETDesktop";
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
