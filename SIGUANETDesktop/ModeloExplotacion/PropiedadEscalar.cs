/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 27/11/2006
 * Time: 12:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Reflection;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloExplotacion
{
	/// <summary>
	/// Description of PropiedadEscalar.
	/// </summary>
	public class PropiedadEscalar : ICloneable
	{	
		public enum TipoGrupo
		{
			General,
			Estancias,
			Personal
		}
		public enum TipoComportamiento
		{
			Deshabilitado,
			Mostrar_Escalar,
			Mostrar_Escalar_y_Datos,
			Mostrar_Escalar_Cartografia_y_Datos,
			Mostrar_Escalar_y_Cartografia
		}
		
		private string _titulo = string.Empty;
		[XmlElement]
		public string Titulo 
		{
			get 
			{
				return _titulo;			 
			}
			set
			{
				_titulo = value;
			}
		}
		
		private string _descripcion = string.Empty;
		[XmlElement]
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
		
		private string _clase = string.Empty;
		[XmlElement]
		public string Clase 
		{
			get 
			{
				return _clase;			 
			}
			set
			{
				_clase = value;
			}
		}		
		
		private string _metodoEscalar = string.Empty;
		[XmlElement]
		public string MetodoEscalar 
		{
			get 
			{
				return _metodoEscalar;			 
			}
			set
			{
				_metodoEscalar = value;
			}
		}
		
		private string _metodoDataSet = string.Empty;
		[XmlElement]
		public string MetodoDataSet
		{
			get 
			{
				return _metodoDataSet;			 
			}
			set
			{
				_metodoDataSet = value;
			}
		}
		
		private string _tituloDataSet = string.Empty;
		[XmlElement]
		public string TituloDataSet
		{
			get 
			{
				return _tituloDataSet;			 
			}
			set
			{
				_tituloDataSet = value;
			}
		}		
		
		private string _valorDefectoEscalar = string.Empty;
		[XmlElement]
		public string ValorDefectoEscalar
		{
			get
			{
				return _valorDefectoEscalar;
			}
			set
			{
				_valorDefectoEscalar = value;
			}
		}		
		
		private string _formatoEscalar = string.Empty;
		[XmlElement]
		public string FormatoEscalar
		{
			get
			{
				return _formatoEscalar;
			}
			set
			{
				_formatoEscalar = value;
			}
		}		
		
		private string _formatoCadena = string.Empty;
		[XmlElement]
		public string FormatoCadena
		{
			get
			{
				return _formatoCadena;
			}
			set
			{
				_formatoCadena = value;
			}
		}
		
		private TipoComportamiento _accion = TipoComportamiento.Mostrar_Escalar;
		[XmlAttribute]
		public TipoComportamiento Accion
		{
			get
			{
				return _accion;
			}
			set
			{
				_accion = value;
			}
		}
		
		private TipoGrupo _grupo = TipoGrupo.General;
		[XmlAttribute]
		public TipoGrupo Grupo
		{
			get
			{
				return _grupo;
			}
			set
			{
				_grupo = value;
			}
		}		
		
		public PropiedadEscalar()
		{
		}
		
		//Implementamos el método de clonación tipo ShallowCopy
		//que en nuestro caso es suficiente puesto que las propiedades
		//de la clase PropiedadEscalar son todas de tipo valor
		public object Clone()
		{
			return this.MemberwiseClone();
		}
		
	}
}
