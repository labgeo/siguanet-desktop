/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 04/03/2013
 * Hora: 14:44
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using SIGUANETDesktop.Extension;

namespace SIGUANETDesktop.ModeloDocumento
{
	/// <summary>
	/// Description of DefaultProfileResponse.
	/// </summary>
	public class DefaultProfileResponse : IProfileResponse
	{
		string _userId;
		string _profile;
		string _status;
		Exception _exception;
		
		public string UserId {
			get {
				return _userId;
			}
		}
		
		public string Profile {
			get {
				return _profile;
			}
		}
		
		public string Status {
			get {
				return _status;
			}
		}
		
		public DefaultProfileResponse(string userId, string profile, string status)
		{
			_userId = userId;
			_profile = profile;
			_status = status;
		}
		
		public DefaultProfileResponse(string userId, string profile, string status, Exception exception)
			: this(userId, profile, status)
		{
			_exception = exception;
		}
		
		public Exception GetException()
		{
			return _exception;
		}
	}
}
