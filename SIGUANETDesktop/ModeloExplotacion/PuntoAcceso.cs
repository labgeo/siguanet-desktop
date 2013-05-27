/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/05/2006
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.ModeloDocumento;
	
namespace SIGUANETDesktop.ModeloExplotacion
{
	/// <summary>
	/// Description of PuntoAcceso.
	/// </summary>
	public class PuntoAcceso
	{
		
		private tipoPuntoAcceso _tipo = tipoPuntoAcceso.Ninguno;
		[XmlAttribute]
		public tipoPuntoAcceso Tipo
		{
			get
			{
				return _tipo;
			}
			set
			{
				_tipo = value;
				switch (value)
				{
					case (tipoPuntoAcceso.ArbolEspacial) :
						_nombre = "Árbol de Espacios";
						_descripcion = "Vista jerarquizada de la distribución general de los espacios";
						break;
					case (tipoPuntoAcceso.ArbolUEM) :
						_nombre = "Árbol de Consulta Espacial";
						_descripcion = "Vista jerarquizada de la distribución general de los espacios en áreas de interés definidas libremente";
						break;
					case (tipoPuntoAcceso.ArbolOrganizativo) :
						_nombre = "Árbol de Organización";
						_descripcion = "Vista jerarquizada de la distribución de los espacios adscritos a cada Centro, Unidad o Departamento";
						break;
					case (tipoPuntoAcceso.ArbolActividades) :
						_nombre = "Árbol de Usos";
						_descripcion = "Vista jerarquizada de la distribución de los espacios según la actividad principal a la que se destinan";
						break;
					case (tipoPuntoAcceso.ArbolGruposActividad) :
						_nombre = "Árbol de Usos (grupos de actividad propios)";
						_descripcion = "Vista jerarquizada de la distribución de los espacios según el grupo de actividad al que pertenecen bajo el criterio propio";
						break;
					case (tipoPuntoAcceso.ArbolGruposActividadCRUE) :
						_nombre = "Árbol de Usos (grupos de actividad CRUE)";
						_descripcion = "Vista jerarquizada de la distribución de los espacios según el grupo de actividad al que pertenecen bajo el criterio de la Conferencia de Rectores de las Universidades Españolas";
						break;
					case (tipoPuntoAcceso.ArbolGruposActividadU21) :
						_nombre = "Árbol de Usos (grupos de actividad Universitas XXI)";
						_descripcion = "Vista jerarquizada de la distribución de los espacios según el grupo de actividad al que pertenecen bajo el criterio del Sistema de Información Universitas XXI";
						break;
					case (tipoPuntoAcceso.Campus) :
						_nombre = "Campus";
						_descripcion = "Punto de Acceso a SIGUANET para consultas sobre campus";
						break;
					case (tipoPuntoAcceso.Edificios) :
						_nombre = "Edificios";
						_descripcion = "Punto de Acceso a SIGUANET para consultas sobre edificios";
						break;
					case (tipoPuntoAcceso.Plantas) :
						_nombre = "Plantas";
						_descripcion = "Punto de Acceso a SIGUANET para consultas sobre plantas de edificios";
						break;						
					case (tipoPuntoAcceso.Estancias) :
						_nombre = "Estancias";
						_descripcion = "Punto de Acceso a SIGUANET para consultas sobre estancias";
						break;
					case (tipoPuntoAcceso.Departamentos) :
						_nombre = "Departamentos";
						_descripcion = "Punto de Acceso a SIGUANET para consultas sobre departamentos";
						break;						
					case (tipoPuntoAcceso.Usos) :
						_nombre = "Usos";
						_descripcion = "Punto de Acceso a SIGUANET para consultas sobre usos de los espacios";
						break;
					case (tipoPuntoAcceso.Personas) :
						_nombre = "Personas";
						_descripcion = "Punto de Acceso a SIGUANET para consultas sobre personas";
						break;						
				}
			}
		}

		private string _nombre = "Punto de Acceso";
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

		private string _descripcion = "Punto de Acceso personalizado de acceso a SIGUANET";
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
		
		private PaginaPropiedades _propiedades = new PaginaPropiedades();
		[XmlElement]
		public PaginaPropiedades Propiedades
		{
			get
			{
				return _propiedades;
			}
			set
			{
				_propiedades = value;
			}
		}
		
		public PuntoAcceso()
		{
		}		
	}
}
