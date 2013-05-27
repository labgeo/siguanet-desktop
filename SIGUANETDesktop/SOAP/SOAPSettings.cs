/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 25/03/2007
 * Time: 20:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.SOAP
{
	/// <summary>
	/// Description of SOAPSettings.
	/// </summary>
	public static class SOAPSettings
	{		
		private static string _wsdllocation = AdministradorPreferencias.Read(PrefsGlobal.SOAPDefaultWSDLLocation);
		public static string WSDLLocation
		{
			get
			{
				return _wsdllocation;
			}
			set
			{
				_wsdllocation = value;
			}
		}
		
		private static string _wsuilocation = AdministradorPreferencias.Read(PrefsGlobal.SOAPDefaultWSUILocation);
		public static string WSUILocation
		{
			get
			{
				return _wsuilocation;
			}
			set
			{
				_wsuilocation = value;
			}
		}
		
		private static string _httpusr = AdministradorPreferencias.Read(PrefsGlobal.SOAPDefaultAnonymousUsrName);
		public static string HTTPUsr
		{
			get
			{
				return _httpusr;
			}
			set
			{
				_httpusr = value;
			}
		}
		
		private static string _httppwd = AdministradorPreferencias.Read(PrefsGlobal.SOAPDefaultAnonymousUsrPassword);
		public static string HTTPPwd
		{
			get
			{
				return _httppwd;
			}
			set
			{
				_httppwd = value;
			}
		}
		
		private static bool _useAnonymousCredentials = true;
		public static bool UseAnonymousCredentials
		{
			get
			{
				return _useAnonymousCredentials;
			}
			set
			{
				_useAnonymousCredentials = value;
				if (_useAnonymousCredentials)
				{
					_httpusr = AdministradorPreferencias.Read(PrefsGlobal.SOAPDefaultAnonymousUsrName);
					_httppwd = AdministradorPreferencias.Read(PrefsGlobal.SOAPDefaultAnonymousUsrPassword);
				}
			}
		}
		
		private static bool _useDefaultAccess = true;
		public static bool UseDefaultAccess
		{
			get
			{
				return _useDefaultAccess;
			}
			set
			{
				_useDefaultAccess = value;
				if (_useDefaultAccess)
				{
					_wsdllocation = AdministradorPreferencias.Read(PrefsGlobal.SOAPDefaultWSDLLocation);
					_wsuilocation = AdministradorPreferencias.Read(PrefsGlobal.SOAPDefaultWSUILocation);
				}
			}
		}
		
		//Información de credenciales de autentificación básica para acceder
		//a los documentos de contrato (WSDL y WSUI)
		static bool _useContractCredentials = false;
		public static bool UseContractCredentials {
			get { return _useContractCredentials; }
			set { _useContractCredentials = value; }
		}
		
		static string _contractHttpUsr = string.Empty;
		public static string ContractHttpUsr {
			get { return _contractHttpUsr; }
			set { _contractHttpUsr = value; }
		}
		
		static string _contractHttpPwd = string.Empty;
		public static string ContractHttpPwd {
			get { return _contractHttpPwd; }
			set { _contractHttpPwd = value; }
		}
	}
}
