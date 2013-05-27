/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 28/02/2013
 * Hora: 9:06
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Reflection;

namespace SIGUANETDesktop.Extension
{
	/// <summary>
	/// Description of AddIn.
	/// </summary>
	public class AddIn
	{
		Assembly _assembly;
		public Assembly Assembly {
			get { return _assembly; }
		}
		
		Type _type;
		public Type Type {
			get { return _type; }
		}
		
		public AddIn (Assembly assembly, Type type)
		{
			_assembly = assembly;
			_type = type;
		}
	}
}
