/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/03/2006
 * Time: 14:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.ModeloDocumento;
namespace SIGUANETDesktop.ModeloSincronizacion
{
	/// <summary>
	/// Clase serializable que define una sentencia SQL y su posición en la secuencia
	/// de una tarea PreSincro, Sincro, PostSincro.
	/// </summary>
	public abstract class Comando
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

		private string _descripcion = "Nuevo Comando";
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
		
		private tipoComando _tipo;
		[XmlAttribute]
		public tipoComando Tipo
		{
			get
			{
				return _tipo;
			}
			set
			{
				_tipo = value;
			}
		}

		public Comando()
		{
			
		}
				
	}
}
