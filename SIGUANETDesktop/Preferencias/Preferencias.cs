/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 25/02/2008
 * Hora: 11:01
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Collections;

namespace SIGUANETDesktop.Preferencias
{
	/// <summary>
	/// Description of Preferencias.
	/// </summary>
	[Serializable]
	public class Preferencias
	{
		internal Hashtable _global = new Hashtable();
		internal Hashtable _bd = new Hashtable();
		public Preferencias()
		{

		}
	}
}
