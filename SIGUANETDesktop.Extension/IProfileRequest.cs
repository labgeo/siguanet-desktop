/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 04/03/2013
 * Hora: 14:35
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

using System;

namespace SIGUANETDesktop.Extension
{
	/// <summary>
	/// Description of IProfileRequest.
	/// </summary>
	public interface IProfileRequest
	{
		IProfileResponse GetResponse(IAuthResponse authResponse);
	}
}
