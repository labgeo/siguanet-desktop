/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 04/03/2013
 * Hora: 14:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

using System;

namespace SIGUANETDesktop.Extension
{
	/// <summary>
	/// Description of IProfileResponse.
	/// </summary>
	public interface IProfileResponse
	{
		string UserId { get; }
		string Profile { get; }
		string Status { get; }
		Exception GetException ();		
	}
}
