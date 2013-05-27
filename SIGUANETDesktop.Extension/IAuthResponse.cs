/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 01/03/2013
 * Hora: 9:06
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace SIGUANETDesktop.Extension
{
	/// <summary>
	/// Description of IAuthResponse.
	/// </summary>
	public interface IAuthResponse
	{
		bool IsValid { get; }
		string Status { get; }
		Exception GetException ();
		string GetUserId ();
		object[] GetData ();
	}
}
