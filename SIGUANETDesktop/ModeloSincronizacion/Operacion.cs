/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/03/2006
 * Time: 14:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Clase serializable que define un conjunto lógico e indivisible de tareas de
	/// presincronización, sincronización y postsincronización.
	/// </summary>
	public class Operacion
	{
		private string _nombre;
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
		
		private string _descripcion = "Nueva Operación";
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
		
		private List<PreSincro> _precomprobaciones = new List<PreSincro>();
		[XmlArray]
		public List<PreSincro> PreComprobaciones
		{
			get
			{
				return _precomprobaciones;
			}
			set
			{
				_precomprobaciones = value;
			}
		}
		
		private List<Sincro> _acciones = new List<Sincro>();
		[XmlArray]
		public List<Sincro> Acciones
		{
			get
			{
				return _acciones;
			}
			set
			{
				_acciones = value;
			}
		}
		
		private List<PostSincro> _postcomprobaciones = new List<PostSincro>();
		[XmlArray]
		public List<PostSincro> PostComprobaciones
		{
			get
			{
				return _postcomprobaciones;
			}
			set
			{
				_postcomprobaciones = value;
			}
		}
		
		private List<Complemento> _complementos = new List<Complemento>();
		[XmlArray]
		public List<Complemento> Complementos
		{
			get
			{
				return _complementos;
			}
			set
			{
				_complementos = value;
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
		
		public Operacion()
		{
			
		}
		
		public string SiguienteNombrePreSincro()
		{
			int i = 0;
			int nextOc = 0;

			foreach (PreSincro pre in this._precomprobaciones)
			{
				i = Convert.ToInt32(pre.Nombre.Substring(this._nombre.Length + 4));
				if (i > nextOc) nextOc = i;
			}
			return string.Format("{0}PREV{1}", this._nombre, (nextOc+1).ToString("00000"));
		}
		
		public string SiguienteNombreSincro()
		{
			int i = 0;
			int nextOc = 0;

			foreach (Sincro sinc in this._acciones)
			{
				i = Convert.ToInt32(sinc.Nombre.Substring(this._nombre.Length + 4));
				if (i > nextOc) nextOc = i;
			}
			return string.Format("{0}SINC{1}", this._nombre, (nextOc+1).ToString("00000"));
		}
		
		public string SiguienteNombrePostSincro()
		{
			int i = 0;
			int nextOc = 0;

			foreach (PostSincro post in this._postcomprobaciones)
			{
				i = Convert.ToInt32(post.Nombre.Substring(this._nombre.Length + 4));
				if (i > nextOc) nextOc = i;
			}
			return string.Format("{0}POST{1}", this._nombre, (nextOc+1).ToString("00000"));
		}
		
		public string SiguienteNombreComplemento()
		{
			int i = 0;
			int nextOc = 0;

			foreach (Complemento comp in this._complementos)
			{
				i = Convert.ToInt32(comp.Nombre.Substring(this._nombre.Length + 4));
				if (i > nextOc) nextOc = i;
			}
			return string.Format("{0}COMP{1}", this._nombre, (nextOc+1).ToString("00000"));
		}		
	}
}
