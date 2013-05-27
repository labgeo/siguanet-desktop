/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 01/03/2013
 * Hora: 13:24
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using SIGUANETDesktop.Extension;

namespace SIGUANETDesktop.ModeloDocumento
{
	/// <summary>
	/// Description of DefaultAuthResponse.
	/// </summary>
	public class DefaultAuthResponse : IAuthResponse
	{
		bool _isValid;
		string _loginName;
		string _status = string.Empty;
		Exception _exception;
			
		public DefaultAuthResponse(bool isValid, string status, string loginName)
		{
			_isValid = isValid;
			_loginName = loginName;
			_status = status;
		}
		
		public DefaultAuthResponse(bool isValid, string status, string loginName, Exception exception)
			: this (isValid, loginName, status)
		{
			_exception = exception;
		}
		
		public bool IsValid {
			get {
				return _isValid;
			}
		}
		
		public string Status {
			get {
				return _status;
			}
		}
		
		public Exception GetException()
		{
			return _exception;
		}
		
		public string GetUserId()
		{
			return _loginName;
		}
		
		public object[] GetData()
		{
			return null;
		}
	}
}
