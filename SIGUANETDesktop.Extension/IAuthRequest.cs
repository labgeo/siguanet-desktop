/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 28/02/2013
 * Hora: 13:41
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace SIGUANETDesktop.Extension
{
	/// <summary>
	/// Description of IAuthService.
	/// </summary>
	public interface IAuthRequest
	{
		IAuthResponse GetResponse (params object[] args);
	}
}
