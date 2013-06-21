/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/05/2006
 * Time: 17:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.ModeloDocumento;

namespace SIGUANETDesktop.ModeloExplotacion
{
	/// <summary>
	/// Description of SesionExplotacion.
	/// </summary>
	public class QuestClient : RootModule
	{
		private string _nombre = "Datos geográficos";
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
		
		private string _descripcion = "Acceso a la base de datos PostgreSQL / PostGIS";
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
		
		private List<PuntoAcceso> _puntosAcceso = new List<PuntoAcceso>();
		[XmlArray]
		public List<PuntoAcceso> PuntosAcceso
		{
			get
			{
				return _puntosAcceso;
			}
			set
			{
				_puntosAcceso = value;
			}
		}
		
		public QuestClient()
		{
			
		}
	}
}
