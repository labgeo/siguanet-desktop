/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tom�s
 * Fecha: 25/02/2008
 * Hora: 11:01
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
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
