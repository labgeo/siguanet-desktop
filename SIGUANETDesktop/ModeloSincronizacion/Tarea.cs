/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/03/2006
 * Time: 15:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic; 

namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Clase abstracta que define la lógica SQL de una tarea y su posición 
	/// en la secuencia de tareas de una operación.
	/// </summary>
	public abstract class Tarea
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
		
		private string _descripcion = "Nueva Tarea";
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
		
		private List<Comando> _comandos = new List<Comando>();
		[XmlArrayItem(Type = typeof(CmdSeleccionar)),
		 XmlArrayItem(Type = typeof(CmdAvisar)),
		 XmlArrayItem(Type = typeof(CmdComparar)),
		 XmlArrayItem(Type = typeof(CmdSincronizar)),
		 XmlArrayItem(Type = typeof(CmdEditar))]
		[XmlArray]
		public List<Comando> Comandos
		{
			get
			{
				return _comandos;
			}
			set
			{
				_comandos = value;
			}
		}		
		
		public Tarea()
		{
			
		}
		
		public string SiguienteNombreComando()
		{
			int i = 0;
			int nextOc = 0;

			foreach (Comando cmd in this._comandos)
			{
				i = Convert.ToInt32(cmd.Nombre.Substring(this._nombre.Length + 3));
				if (i > nextOc) nextOc = i;
			}
			return string.Format("{0}CMD{1}", this._nombre, (nextOc+1).ToString("00000"));
		}		

		
	}
}
