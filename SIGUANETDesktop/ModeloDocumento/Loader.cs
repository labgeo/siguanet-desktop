/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 07/04/2008
 * Hora: 13:30
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using Npgsql;
using System.Reflection;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using SIGUANETDesktop.Extension;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.Perfiles;
using SIGUANETDesktop.Preferencias;
using SIGUANETDesktop.XML;
using SIGUANETDesktop.Log;
using SIGUANETDesktop.Utilidades;

namespace SIGUANETDesktop.ModeloDocumento
{
	/// <summary>
	/// Encapsula el procedimiento de autentificación 
	/// y la lógica de carga del documento SGD
	/// en función de las preferencias del usuario
	/// </summary>
	public static class Loader
	{
		
		private const string GEEKS = "SIGUANETDesktop.Geeks";
		
		private static string _minserveDir = string.Empty;
		private static string _authDownloadDir = string.Empty;
		
		//La propiedad SystemDate se utiliza para comprobar la caducidad de
		//los documentos SGD. Por defecto asignamos la fecha del sistema del cliente,
		//pero dado que este dato no es confiable se intentará reasignar
		//con el valor de la fecha del servidor web SIGUANET en el método Loader.HTTPRequestCheck
		private static bool _hasTriedServerDate = false;
		private static DateTime _systemDate = DateTime.Now;
		public static DateTime SystemDate
		{
			get
			{
				return _systemDate;
			}
		}
		
		public static string Title
		{
			get
			{
				string s = string.Empty;
				Assembly asm = Assembly.GetExecutingAssembly();
				object[] objArray=asm.GetCustomAttributes(false) ;
				foreach (object obj in objArray)
				{
					AssemblyTitleAttribute t = obj as AssemblyTitleAttribute;
					if (t != null) 
					{
						s = t.Title;
						break;
					}
				}
				return s;
			}
		}
				
		public static string Description
		{
			get
			{
				string s = string.Empty;
				Assembly asm = Assembly.GetExecutingAssembly();
				object[] objArray=asm.GetCustomAttributes(false) ;
				foreach (object obj in objArray)
				{
					AssemblyDescriptionAttribute d = obj as AssemblyDescriptionAttribute;
					if (d != null) 
					{
						s = d.Description;
						break;
					}
				}
				return s;
			}
		}
		
		public static string Copyright
		{
			get
			{
				string s = string.Empty;
				Assembly asm = Assembly.GetExecutingAssembly();
				object[] objArray=asm.GetCustomAttributes(false) ;
				foreach (object obj in objArray)
				{
					AssemblyCopyrightAttribute c = obj as AssemblyCopyrightAttribute;
					if (c != null) 
					{
						s = c.Copyright;
						break;
					}
				}
				return s;
			}
		}
		
		public static List<Geek> Geeks
		{
			get
			{
				List<Geek> geeks = new List<Geek> ();
				ResourceManager rmGeeks = new ResourceManager(GEEKS, Assembly.GetExecutingAssembly());
				IDictionaryEnumerator eGeeks = rmGeeks.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true).GetEnumerator();
				
			    while (eGeeks.MoveNext())
			    {
			    	geeks.Add(new Geek((string) eGeeks.Value, (string) eGeeks.Key));
			    }
			    geeks.Sort();
			    return geeks;
			}
		}
		
		public static List<Dependency> Dependencies
		{
			get
			{
				List<Dependency> dependencies = new List<Dependency> ();
				foreach (AssemblyName a in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
				{
					if (!a.Name.StartsWith("System") && a.Name != "mscorlib")
					{
						dependencies.Add(new Dependency(a.Name, string.Format("{0}.{1}.{2}", a.Version.Major, a.Version.Minor, a.Version.Build)));
					}
				}
				return dependencies;
			}
		}
				
		private static string _fullVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		public static string FullVersion
		{
			get
			{
				return _fullVersion;
			}
		}
		
		private static string _version = string.Format("{0}.{1}", Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(), Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString());
		public static string Version
		{
			get
			{
				return _version;
			}
		}
		
		private static string _assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		public static string AssemblyDir
		{
			get
			{
				return _assemblyDir;
			}
		}
		
		private static ProfileType _profile = ProfileType.Publico;
		public static ProfileType Profile
		{
			get
			{
				return _profile;
			}
		}

		private static string _customProfile = string.Empty;
		public static string CustomProfile
		{
			get
			{
				return _customProfile;
			}
		}
		
		//En principio sólo un usuario con perfil Root puede suplantar otro perfil invocando al método Impersonate
		public static bool CanImpersonate
		{
			get
			{
				return (_profile == ProfileType.Root);
			}
		}
		
		//La impersonación afecta a los métodos de carga del documento SGD
		//Al inicio o tras la autentificación siempre se cumple
		//(_impersonation == _profile) == true
		//Sólo invocando al método Impersonate se puede producir la impersonación efectiva,
		//es decir
		//(_impersonation == _profile) == false
		private static ProfileType _impersonation = ProfileType.Publico;
		public static ProfileType Impersonation
		{
			get
			{
				return _impersonation;
			}
		}
		
		private static string _customImpersonation = string.Empty;
		public static string CustomImpersonation
		{
			get
			{
				return _customImpersonation;
			}
		}		
		
		public static bool IsImpersonated
		{
			get
			{
				if (_profile != _impersonation)
				{
					return true;
				}
				else
				{
					if (_customProfile != _customImpersonation)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
		}
		
		private static bool _isAuthenticated = false;
		public static bool IsAuthenticated
		{
			get
			{
				return _isAuthenticated;
			}
		}
		
		private static RemoteSettings _srs = null;
		public static RemoteSettings SRS
		{
			get
			{
				return _srs;
			}
		}
		
		private static bool _useLocal = false;
		private static bool _useRemote = true;
		private static bool _useLocalCopy = false;
		
		//=================================================================
		//Reglas de carga del documento SGD
		//if (useLocal)
		private static LoaderRule[] _localOnlySGDRules =
			new LoaderRule[]{new LoaderRule(false, true),
			                 new LoaderRule(true, true)};
		//if (useLocal && Loader._profile == Public)
		private static LoaderRule[] _localOnlyPublicSGDRules =
			new LoaderRule[]{new LoaderRule(true, true)};
		
		//if (useRemote && !uselocalCopy)
		private static LoaderRule[] _remoteOnlySGDRules =
			new LoaderRule[]{new LoaderRule(false, false),
			                 new LoaderRule(true, false)};
		
		//if (useRemote && !uselocalCopy && Loader._profile == Public)
		private static LoaderRule[] _remoteOnlyPublicSGDRules =
			new LoaderRule[]{new LoaderRule(true, false)};
		
		//if (useRemote && uselocalCopy)
		private static LoaderRule[] _remoteOrLocalSGDRules =
			new LoaderRule[]{new LoaderRule(false, false),
			                 new LoaderRule(false, true),
			                 new LoaderRule(true, false),
			                 new LoaderRule(true, true)};
		
		//if (useRemote && uselocalCopy && Loader._profile == Public)
		private static LoaderRule[] _remoteOrLocalPublicSGDRules =
			new LoaderRule[]{new LoaderRule(true, false),
			                 new LoaderRule(true, true)};
		//================================================================
		//Reglas de carga del documento SGD específicas para impersonación
		//if (useLocal)
		private static LoaderRule[] _localOnlySGDRulesImp =
			new LoaderRule[]{new LoaderRule(false, true)};
		//if (useRemote && !uselocalCopy)
		private static LoaderRule[] _remoteOnlySGDRulesImp =
			new LoaderRule[]{new LoaderRule(false, false)};
		//if (useRemote && uselocalCopy)
		private static LoaderRule[] _remoteOrLocalSGDRulesImp =
			new LoaderRule[]{new LoaderRule(false, false),
			                 new LoaderRule(false, true)};
		//==================================================================
		
		public static void Initialize (string minserveUrlBase)
		{
			if (!string.IsNullOrEmpty(minserveUrlBase.Trim())) {
				Loader._minserveDir = minserveUrlBase;
				Loader._authDownloadDir = Loader._minserveDir;
			} else {
				Loader._authDownloadDir = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadURL);
			}
		}
		
		public static void Authenticate(ExtensionLocator extlocator, bool bypassSRS, params object[] args)
		{
			if (!Loader.IsValidAuthDownloadSource (Loader._authDownloadDir))
			{
				//Si el documento SRS de perfil público en la URL base (http://urlbase/) no define una IP 
				//válida lo intentamos con una URL alternativa que por convención es http://urlbase/alt/
				if (Loader.IsValidAuthDownloadSource (Loader._authDownloadDir + "alt/"))
				{
					//Si el documento SRS de perfil público en la URL alternativa (http://urlbase/alt/)
					//define una IP válida dicha URL se convierte en la URL base
					Loader._authDownloadDir += "alt/";
				}
			}
			Loader.DoAuthenticate (extlocator, bypassSRS, args, out Loader._profile, 
			                       out Loader._customProfile, out Loader._isAuthenticated);

			if (!Loader.IsAuthenticated)
			{
				string[] strArgs = Array.ConvertAll<object, string>(args, delegate(object obj) { return obj.ToString(); });
				new SIGUANETDesktop.Log.SIGUANETDesktopException(SIGUANETDesktop.Log.ExceptionCategory.LOADERAuthenticationFailed, "Loader.DoAuthenticate", new ArgumentException(string.Format("Invalid arguments: {0}", string.Join(",", strArgs))));
			}
			else
			{
				Loader._customProfile = Loader._customProfile.Trim().ToUpper();
				//Si el usuario está autentificado, lo primero es igualar su perfil con su perfil de impersonación
				Loader._impersonation = Loader._profile;
				Loader._customImpersonation = Loader._customProfile;
			}
			//Lanzamos el evento ProfileSetEvent
			Loader.ProfileSetEvent();
		}
		
		private static void DoAuthenticate(ExtensionLocator extLocator, bool bypassSRS, object[] args, 
		                                   out ProfileType profile, out string customProfile, out bool isAuthenticated)
		{
			IAuthResponse authResponse;
			
			profile = ProfileType.Publico;
			customProfile = string.Empty;
			isAuthenticated = false;
			
			if (args != null && args.Length >= 1)
			{
				object r = null;

				//Es posible que el usuario omita la carga del documento SRS y suministre
				//los parámetros y credenciales de conexión a PostgreSQL él mismo.
				//Esto es útil para usuarios Root que no desean trabajar con los parámetros
				//y credenciales del perfil público por la razón que sea 
				//(i.e. porque se sabe con certeza que alguno de los datos en el SRS ha
				//quedado desfasado o es incorrecto) y necesitan suministrar
				//explícitamente los parámetros y credenciales de conexión a PostgreSQL en
				//el momento de la carga de la aplicación.
				//En caso contrario se intenta cargar el documento SRS para el perfil público
				//desde el servidor o, si no es posible, buscando una copia en local.
				//Es un caso especial de obtención de credenciales
				//previa a la carga del documento SGD ya que necesitamos dichas credenciales
				//para realizar la autentificación mediante un NIF			
				if (!bypassSRS) {
					Loader.DoLoadSRS(ProfileType.Publico);
				}
				
				//Autentificación de usuario
				try
				{
					authResponse = Loader.RequestAuthentication (extLocator, args);
				}
				catch
				{
					return;
				}
				
				//Recuperación del perfil del usuario previamente autentificado.
				Loader.RequestProfile (extLocator, authResponse, out r);
				
				if (r != null && r.GetType() == typeof(string))
				{
					if ((string) r != string.Empty)
					{
						//Intentamos lanzar el evento MultipleProfileEvent en caso
						//de haber recibido múltiples perfiles, como por ejemplo:
						//"DEPARTAMENTO,INTERNO.PERSONALIZADO". Esperamos 
						//el caracter ',' como separador de lista
						if ((r as string).Split(',').Length > 1)
						{
							if(Loader.MultipleProfileEvent != null)
							{
								//Lanzamos el evento MultipleProfileEvent
								Loader.MultipleProfileEvent((r as string).Split(','));
							}
							else
							{
								//No hay ningún manejador de evento de modo que no queda más remedio
								//que quedarnos con alguno de los perfiles. En este caso nos quedamos con el primero
								//descomponiéndolo en {"Perfil", "PerfilPersonalizado"}
								string[] profileInfo = (r as string).Split(',')[0].Split('.');
								//OBLIGATORIO asignar parámetro out
								profile = (ProfileType) Enum.Parse(typeof(ProfileType), profileInfo[0], true);
								if (profileInfo.GetLength(0) > 1)
								{
									//OBLIGATORIO asignar parámetro out
									customProfile = profileInfo[1];
								}
							}
						}
						else
						{
							//Descomponemos el resultado en {"Perfil", "PerfilPersonalizado"}
							string[] profileInfo = (r as string).Split('.');
							//OBLIGATORIO asignar parámetro out
							profile = (ProfileType) Enum.Parse(typeof(ProfileType), profileInfo[0], true);
							if (profileInfo.GetLength(0) > 1)
							{
								//OBLIGATORIO asignar parámetro out
								customProfile = profileInfo[1];
							}								
						}
						//OBLIGATORIO asignar parámetro out
						isAuthenticated = true;
					}
				}
			}
		}		
		
		private static IAuthResponse RequestAuthentication (ExtensionLocator extLocator, object[] args)
		{
			IAuthResponse authResponse;
			try
			{
				IAuthRequest authRequest = extLocator.GetExtension<IAuthRequest> ();
				if (authRequest == null) {
					authRequest = new DefaultAuthRequest();
				}
				authResponse = authRequest.GetResponse(args);
				if (!authResponse.IsValid) {
					throw new Exception(string.Format("La sesión de autentificación finalizó con estado {0}", authResponse.Status));
				}
				return authResponse;
			}
			catch (Exception ex)
			{
				throw new SIGUANETDesktopException(ExceptionCategory.LOADERAuthenticationAborted, "Loader.RequestAuthentication", ex);
			}			
		}
		
		private static void RequestProfile (ExtensionLocator extLocator, IAuthResponse authResponse, out object r)
		{
			r = string.Empty;
			try
			{
				IProfileRequest profileRequest = extLocator.GetExtension<IProfileRequest> ();
				if (profileRequest == null) {
					profileRequest = new DefaultProfileRequest();
				}
				IProfileResponse profileResponse = profileRequest.GetResponse(authResponse);
				r = profileResponse.Profile;
				if (profileResponse.GetException () != null) {
					throw new Exception (string.Format ("No se pudo recuperar el perfil de usuario; {0}", profileResponse.Status));
				}
			}
			catch (Exception ex)
			{
				new SIGUANETDesktopException(ExceptionCategory.LOADERAuthenticationAborted, "Loader.RequestProfile", ex);
			}			
		}
		
		private static bool IsValidAuthDownloadSource (string authDownloadDir)
		{
			bool useCredentials = false;
			string httpUsr = string.Empty;
			string httpPwd = string.Empty;
			string source = string.Empty;
			RemoteSettings srs = null;
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadUsingCredentials), out useCredentials);
			if (useCredentials)
			{
				httpUsr = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadWithLogin);
				httpPwd = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadWithPassword);
			}
			source = Loader.GetAuthDownloadSource (authDownloadDir, httpUsr, httpPwd, ProfileType.Publico);
			if (source != string.Empty)
			{
				try
				{
					//Intentamos instanciar el documento SRS desde la fuente remota
					srs = (RemoteSettings) XMLUtils.DeserializarDocumento(source, httpUsr, httpPwd, typeof(RemoteSettings));
					srs.Desencriptar();
				}
				catch (Exception e)
				{
					srs = null;
					new SIGUANETDesktopException(ExceptionCategory.SRSDeserializationFailed, "Loader.IsValidAuthDownloadSource", e, source);
				}
			}
			
			if (srs != null)
			{
				return Loader.IsListening (srs.PGSQLHost, int.Parse(srs.PGSQLPort));
			}
			return false;
		}
		
		private static string GetAuthDownloadSource (string authDownloadDir, string httpUsr, string httpPwd, ProfileType pType)
		{
			string source = string.Empty;			
			
			//La fuente es el documento SRS en la URL de enlace
			if (authDownloadDir != string.Empty)
			{
				if (Uri.IsWellFormedUriString(authDownloadDir, UriKind.Absolute))
				{
					Uri baseUri = new Uri(authDownloadDir);
					Uri srsUri = new Uri(baseUri, RemoteSettings.BuildFormalFileName(pType, Loader._version));
					if (Loader.HTTPRequestCheck(srsUri, httpUsr, httpPwd, ExceptionCategory.SRSRemotePathNotFound))
					{
						source = srsUri.AbsoluteUri;
					}
				}
				else
				{
					new SIGUANETDesktopException(ExceptionCategory.SRSURLInvalid, "Loader.GetAuthDownloadSource", new UriFormatException(), authDownloadDir);
				}
			}
			else
			{
				new SIGUANETDesktopException(ExceptionCategory.SRSURLEmpty, "Loader.GetAuthDownloadSource", new InvalidOperationException());
			}
			return source;
		}
		
		private static bool IsListening (string host, int port)
		{
			using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
				try {
        			socket.Connect(host, port);
        			return true;
				}
				catch {
					return false;
				}
			}
		}
		
		//Recibe el perfil seleccionado por el usuario de una lista de perfiles múltiples
		//y finaliza el proceso de autentificación
		public static void ResumeAuthentication(string profileData)
		{
			string[] profileInfo = profileData.Split('.');
			//Asignamos perfil
			Loader._profile = (ProfileType) Enum.Parse(typeof(ProfileType), profileInfo[0], true);
			//Lanzamos el evento ProfileSetEvent
			Loader.ProfileSetEvent();
			//Igualamos perfil con perfil de impersonación
			Loader._impersonation = Loader._profile;
			if (profileInfo.GetLength(0) > 1)
			{
				//Asignamos perfil personalizado
				Loader._customProfile = profileInfo[1].Trim().ToUpper();
				//Lanzamos el evento CustomProfileChangedEvent
				Loader.CustomProfileChangedEvent();
				//Igualamos perfil personalizado con perfil personalizado de impersonación
				Loader._customImpersonation = Loader._customProfile;
			}
		}
		
		public static void Impersonate(ProfileType profile, string customProfile)
		{
			//Sólo un usuario con privilegio de impersonación puede suplantar otro perfil
			if (Loader.CanImpersonate)
			{
				Loader._impersonation = profile;
				Loader._customImpersonation = customProfile.Trim().ToUpper();
				if (Loader.ImpersonationChangedEvent != null)
				{
					//Lanzamos el evento ImpersonationChangedEvent
					Loader.ImpersonationChangedEvent();
				}
			}
		}
		
		//Anula la impersonación
		public static void Unimpersonate()
		{
			Loader._impersonation = Loader._profile;
			Loader._customImpersonation = Loader._customProfile;
			if (Loader.ImpersonationChangedEvent != null)
			{
				//Lanzamos el evento ImpersonationChangedEvent
				Loader.ImpersonationChangedEvent();
			}
		}
		
		//Los usuarios que utilizen el acceso anónimo pueden especificar
		//un perfil personalizado. De esta forma los administradores del sistema pueden
		//preparar SGD de demo para usuarios externos que deseen
		//hacer pruebas de funcionalidad de SIGUANETDesktop temporalmente,
		//sin ser dicha funcionalidad propia del perfil Publico. 
		//A estos usuarios externos bastará con comunicarles vía e-mail
		//o por otros medios el nombre de su perfil personalizado.
		public static void SetCustomProfile(string customProfile)
		{
			Loader._customProfile = customProfile.Trim().ToUpper();
			Loader._customImpersonation = Loader._customProfile;
			if (Loader.CustomProfileChangedEvent != null)
			{
				//Lanzamos el evento CustomProfileChangedEvent
				Loader.CustomProfileChangedEvent();
			}
		}
		
		public static Root LoadSGD()
		{
			Root sgd = null;
			
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDUseLocal), out Loader._useLocal);
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDUseRemote), out Loader._useRemote);
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDUseLocalCopy), out Loader._useLocalCopy);
			
			//Puede darse este caso cuando no existe un fichero de preferencias definido,
			//por tanto forzamos la carga del documento remoto
			//para con posterioridad poder dirigir al usuario para que
			//establezca en las preferencias la URL de enlace
			if (Loader._useLocal == Loader._useRemote)
			{
				Loader._useLocal = false;
				Loader._useRemote = true;
			}
			
			if (Loader._useLocal)
			{
				sgd = (Loader._profile == ProfileType.Publico) ? Loader.LoadSGD(Loader._localOnlyPublicSGDRules) : Loader.LoadSGD(Loader._localOnlySGDRules);
			}
			if (Loader._useRemote)
			{
				if (Loader._profile == ProfileType.Publico && Loader._customProfile == string.Empty)
				{
					sgd = Loader._useLocalCopy ? Loader.LoadSGD(Loader._remoteOrLocalPublicSGDRules) : Loader.LoadSGD(Loader._remoteOnlyPublicSGDRules);
				}
				else
				{
					sgd = Loader._useLocalCopy ? Loader.LoadSGD(Loader._remoteOrLocalSGDRules) : Loader.LoadSGD(Loader._remoteOnlySGDRules);
				}
			}
			return sgd;
		}
		
		private static Root LoadSGD(LoaderRule[] rules)
		{
			Root sgd = null;
			//Si se está intentando suplantar un perfil
			//primero aplicaremos la regla de impersonación
			if (Loader.IsImpersonated)
			{
				sgd = Loader.LoadImpersonatedSGD();
			}
			if (sgd == null)
			{
				foreach (LoaderRule rule in rules)
				{
					ProfileType p = rule.ForcePublic ? ProfileType.Publico : Loader._profile;
					string custom = rule.ForcePublic ? string.Empty : Loader._customProfile;
					sgd = rule.UseLocal ? Loader.LoadLocalSGD(p, custom) : Loader.LoadRemoteSGD(p, custom);
					if (sgd != null)
					{
						break;
					}
				}
			}
			return sgd;
		}
		
		private static Root LoadImpersonatedSGD()
		{
			Root sgd = null;
			LoaderRule[] rules = null;
			string sImpersonation = Enum.GetName(typeof(ProfileType), Loader._impersonation);
			if (Loader._useLocal)
			{
				rules = Loader._localOnlySGDRulesImp;
			}
			if (Loader._useRemote)
			{
				rules = Loader._useLocalCopy ? Loader._remoteOrLocalSGDRulesImp : Loader._remoteOnlySGDRulesImp;
			}
			foreach (LoaderRule rule in rules)
			{
				ProfileType p = rule.ForcePublic ? ProfileType.Publico : Loader._impersonation;
				string custom = rule.ForcePublic ? string.Empty : Loader._customImpersonation;
				sgd = rule.UseLocal ? Loader.LoadLocalSGD(p, custom) : Loader.LoadRemoteSGD(p, custom);
				if (sgd != null)
				{
					break;
				}
			}
			if (sgd == null)
			{
				//Anulamos impersonación
				Loader.Unimpersonate();
				new SIGUANETDesktopException(ExceptionCategory.LOADERImpersonationFailed, "Loader.LoadImpersonatedSGD", new ArgumentException(string.Format("Invalid argument: {0}", sImpersonation)), sImpersonation);
			}

			return sgd;
		}
		
		private static Root LoadLocalSGD(ProfileType p, string custom)
		{
			Root sgd = null;
			string target = Root.GetDefaultLocation(p, custom, Loader._version);
			if (File.Exists(target))
			{
				try
				{
					sgd = (Root) XMLUtils.DeserializarDocumento(target, string.Empty, string.Empty, typeof(Root));
				}
				catch (Exception e)
				{
					new SIGUANETDesktopException(ExceptionCategory.SGDDeserializationFailed, "Loader.LoadLocalSGD", e, target);
					if (custom != string.Empty)
					{
						//Intentamos cargar el sgd del perfil base, sin perfil personalizado
						sgd = Loader.LoadLocalSGDBaseProfile(p);
					}
				}
			}
			else
			{
				new SIGUANETDesktopException(ExceptionCategory.SGDLocalPathNotFound, "Loader.LoadLocalSGD", new FileNotFoundException(), target);
				if (custom != string.Empty)
				{
					//Intentamos cargar el sgd del perfil base, sin perfil personalizado
					sgd = Loader.LoadLocalSGDBaseProfile(p);
				}
			}
			//CONTROL DE CADUCIDAD DEL DOCUMENTO SGD PARA USUARIOS DISTINTOS DE ROOT
			if (sgd != null)
			{
				if (Loader._profile != ProfileType.Root && sgd.Caducado && custom != string.Empty)
				{
					new SIGUANETDesktopException(ExceptionCategory.SGDHasExpired, "Loader.LoadRemoteSGD", new InvalidOperationException(string.Format("Expiration date reached: {0}", sgd.Caducidad.ToShortDateString())), target);
					//Intentamos cargar el sgd del perfil base, sin perfil personalizado
					//Los documentos asociados a los perfiles base nunca caducan
					sgd = Loader.LoadLocalSGDBaseProfile(p);
				}
			}
			return sgd;
		}
		
		private static Root LoadLocalSGDBaseProfile(ProfileType p)
		{
			//Desasignamos el perfil personalizado
			Loader._customProfile = string.Empty;
			Loader._customImpersonation = string.Empty;
			if (Loader.CustomProfileChangedEvent != null)
			{
				//Lanzamos el evento CustomProfileChangedEvent
				Loader.CustomProfileChangedEvent();
			}
			
			Root sgd = null;
			string target = Root.GetDefaultLocation(p, string.Empty, Loader._version);
			if (File.Exists(target))
			{
				try
				{
					sgd = (Root) XMLUtils.DeserializarDocumento(target, string.Empty, string.Empty, typeof(Root));
				}
				catch (Exception e)
				{
					new SIGUANETDesktopException(ExceptionCategory.SGDDeserializationFailed, "Loader.LoadLocalSGDBaseProfile", e, target);
				}
			}
			else
			{
				new SIGUANETDesktopException(ExceptionCategory.SGDLocalPathNotFound, "Loader.LoadLocalSGDBaseProfile", new FileNotFoundException(), target);
			}
			return sgd;
		}		
		
		private static Root LoadRemoteSGD(ProfileType p, string custom)
		{
			Root sgd = null;
			string target = string.Empty;
			string baseUrl = string.Empty;
			bool useCredentials = false;
			string httpUsr = string.Empty;
			string httpPwd = string.Empty;
			
			if (!string.IsNullOrEmpty(Loader._minserveDir)) {
				baseUrl = Loader._minserveDir;
			} else {
				baseUrl = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadURL);
			}
			
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadUsingCredentials), out useCredentials);
			if (useCredentials)
			{
				httpUsr = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithLogin);
				httpPwd = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithPassword);
			}
			
			if (baseUrl != string.Empty)
			{
				if (Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute))
				{
					Uri baseUri = new Uri(baseUrl);
					Uri docUri = new Uri(baseUri, Root.BuildFormalFileName(p, custom, Loader._version));
					if (Loader.HTTPRequestCheck(docUri, httpUsr, httpPwd, ExceptionCategory.SGDRemotePathNotFound))
					{
					    	target = docUri.AbsoluteUri;
					}
				}
				else
				{
					new SIGUANETDesktopException(ExceptionCategory.SGDURLInvalid, "Loader.LoadRemoteSGD", new UriFormatException(), target);
				}
			}
			else
			{
				new SIGUANETDesktopException(ExceptionCategory.SGDURLEmpty, "Loader.LoadRemoteSGD", new InvalidOperationException());
			}
			if (target != string.Empty)
			{
				try
				{
					sgd = (Root) XMLUtils.DeserializarDocumento(target, httpUsr, httpPwd, typeof(Root));
					sgd.Url = target;
					//Intentamos crear inmediatamente un documento SGD
					//en la ruta y con el nombre por defecto
					try
					{
						sgd.Serializar(sgd.DefaultLocation);
					}
					catch (Exception e)
					{
						new SIGUANETDesktopException(ExceptionCategory.SGDLocalCopyFailed, "Loader.LoadRemoteSGD", e, target, Loader._assemblyDir);
					}
				}
				catch (Exception e)
				{
					new SIGUANETDesktopException(ExceptionCategory.SGDDeserializationFailed, "Loader.LoadRemoteSGD", e, target);
					if (custom != string.Empty)
					{
						//Intentamos cargar el sgd del perfil base, sin perfil personalizado
						sgd = Loader.LoadRemoteSGDBaseProfile(p);
					}					
				}
			}
			else
			{
				if (custom != string.Empty)
				{
					//Intentamos cargar el sgd del perfil base, sin perfil personalizado
					sgd = Loader.LoadRemoteSGDBaseProfile(p);
				}
			}
			//CONTROL DE CADUCIDAD DEL DOCUMENTO SGD PARA USUARIOS DISTINTOS DE ROOT
			if (sgd != null)
			{
				if (Loader._profile != ProfileType.Root && sgd.Caducado && custom != string.Empty)
				{
					new SIGUANETDesktopException(ExceptionCategory.SGDHasExpired, "Loader.LoadRemoteSGD", new InvalidOperationException(string.Format("Expiration date reached: {0}", sgd.Caducidad.ToShortDateString())), target);
					//Intentamos cargar el sgd del perfil base, sin perfil personalizado
					//Los documentos asociados a los perfiles base nunca caducan
					sgd = Loader.LoadRemoteSGDBaseProfile(p);
				}
			}			
			return sgd;
		}
		
		private static Root LoadRemoteSGDBaseProfile(ProfileType p)
		{
			//Desasignamos el perfil personalizado
			Loader._customProfile = string.Empty;
			Loader._customImpersonation = string.Empty;
			if (Loader.CustomProfileChangedEvent != null)
			{
				//Lanzamos el evento CustomProfileChangedEvent
				Loader.CustomProfileChangedEvent();
			}
			
			Root sgd = null;
			string target = string.Empty;
			string baseUrl = string.Empty;
			bool useCredentials = false;
			string httpUsr = string.Empty;
			string httpPwd = string.Empty;
			
			if (!string.IsNullOrEmpty(Loader._minserveDir)) {
				baseUrl = Loader._minserveDir;
			} else {
				baseUrl = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadURL);
			}
			    
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadUsingCredentials), out useCredentials);
			if (useCredentials)
			{
				httpUsr = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithLogin);
				httpPwd = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithPassword);
			}
			
			if (baseUrl != string.Empty)
			{
				if (Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute))
				{
					Uri baseUri = new Uri(baseUrl);
					Uri docUri = new Uri(baseUri, Root.BuildFormalFileName(p, string.Empty, Loader._version));
					if (Loader.HTTPRequestCheck(docUri, httpUsr, httpPwd, ExceptionCategory.SGDRemotePathNotFound))
					{
					    	target = docUri.AbsoluteUri;
					}
				}
				else
				{
					new SIGUANETDesktopException(ExceptionCategory.SGDURLInvalid, "Loader.LoadRemoteSGDBaseProfile", new UriFormatException(), target);
				}
			}
			else
			{
				new SIGUANETDesktopException(ExceptionCategory.SGDURLEmpty, "Loader.LoadRemoteSGDBaseProfile", new InvalidOperationException());
			}
			if (target != string.Empty)
			{
				try
				{
					sgd = (Root) XMLUtils.DeserializarDocumento(target, httpUsr, httpPwd, typeof(Root));
					sgd.Url = target;
					//Intentamos crear inmediatamente un documento SGD
					//en la ruta y con el nombre por defecto
					try
					{
						sgd.Serializar(sgd.DefaultLocation);
					}
					catch (Exception e)
					{
						new SIGUANETDesktopException(ExceptionCategory.SGDLocalCopyFailed, "Loader.LoadRemoteSGDBaseProfile", e, target, Loader._assemblyDir);
					}
				}
				catch (Exception e)
				{
					new SIGUANETDesktopException(ExceptionCategory.SGDDeserializationFailed, "Loader.LoadRemoteSGDBaseProfile", e, target);
				}
			}
			return sgd;
		}		
		
		public static void LoadSRS()
		{
			bool useLocal = false;
			bool useRemote = false;
			
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.AuthUseLocal), out useLocal);
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.AuthUseRemote), out useRemote);
			
			//Puede darse este caso cuando no existe un fichero de preferencias definido,
			//por tanto forzamos la carga del documento remoto
			//para con posterioridad poder dirigir al usuario para que
			//establezca en las preferencias la URL de enlace
			if (useLocal == useRemote)
			{
				useLocal = false;
				useRemote = true;
			}
			//ATENCIÓN: useLocal NO SIGNIFICA obtener las credenciales de un fichero SRS local,
			//significa que es el usuario el que proporciona las credenciales por teclado.
			if (useLocal)
			{
				//DO NOTHING
			}
			if (useRemote)
			{
				//El usuario es Root SIEMPRE proporciona sus credenciales explícitamente
				if (Loader._profile == ProfileType.Root)
				{
					//DO NOTHING
				}
				else
				{
					Loader.DoLoadSRS(Loader._profile);
				}
			}
			//Lanzamos el evento ProfileSetEvent
			Loader.ProfileSetEvent();			
		}
		
		private static void DoLoadSRS(ProfileType profileType)
		{
			string source = string.Empty;
			bool useCredentials = false;
			string httpUsr = string.Empty;
			string httpPwd = string.Empty;
			
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadUsingCredentials), out useCredentials);
			if (useCredentials)
			{
				httpUsr = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadWithLogin);
				httpPwd = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadWithPassword);
			}
			
			source = Loader.GetAuthDownloadSource(Loader._authDownloadDir, httpUsr, httpPwd, profileType);
			
			//Intentamos instanciar el documento SRS desde la fuente remota
			if (source != string.Empty)
			{
				try
				{
					RemoteSettings srs = (RemoteSettings) XMLUtils.DeserializarDocumento(source, httpUsr, httpPwd, typeof(RemoteSettings));
					srs.Desencriptar();
					//intentamos crear inmediatamente un SRS
					//en la ruta y con el nombre por defecto
					try
					{
						srs.Serializar(srs.DefaultLocation, true);
					}
					catch (Exception e)
					{
						//No se pudo crear una copia en local
						new SIGUANETDesktopException(ExceptionCategory.SRSLocalCopyFailed, "Loader.DoLoadSRS", e, source, Loader._assemblyDir);
					}
					Loader._srs = srs;
					Loader._srs.ExportarAjustes();
				}
				catch (Exception e)
				{
					new SIGUANETDesktopException(ExceptionCategory.SRSDeserializationFailed, "Loader.DoLoadSRS", e, source);
					//Intentamos instanciar el documento SRS desde la fuente local
					Loader.DoLoadSRSLocalCopy(profileType);
				}
			}
			else
			{
				//Intentamos instanciar el documento SRS desde la fuente local
				Loader.DoLoadSRSLocalCopy(profileType);
			}
		}
		
		private static void DoLoadSRSLocalCopy(ProfileType profileType)
		{
			string target = RemoteSettings.GetDefaultLocation(profileType, Loader._version);
			if (File.Exists(target))
			{
				try
				{
					RemoteSettings srs = (RemoteSettings) XMLUtils.DeserializarDocumento(target, string.Empty, string.Empty, typeof(RemoteSettings));
					srs.Desencriptar();
					Loader._srs = srs;
					Loader._srs.ExportarAjustes();
				}
				catch(Exception innerE)
				{
					new SIGUANETDesktopException(ExceptionCategory.SRSDeserializationFailed, "Loader.DoLoadSRSLocalCopy", innerE, target);
					//Intentamos instanciar el documento SRS desde una copia del perfil Publico en la fuente local
					if (Loader._profile != ProfileType.Publico)
					{
						Loader.ForceLoadPublicSRSLocalCopy();
					}
				}
			}
			else
			{
				new SIGUANETDesktopException(ExceptionCategory.SRSLocalPathNotFound, "Loader.DoLoadSRSLocalCopy", new FileNotFoundException(), target);
				//Intentamos instanciar el documento SRS desde una copia del perfil Publico en la fuente local
				if (Loader._profile != ProfileType.Publico)
				{
					Loader.ForceLoadPublicSRSLocalCopy();
				}
			}
		}
		
		private static void ForceLoadPublicSRSLocalCopy()
		{
			string target = RemoteSettings.GetDefaultLocation(ProfileType.Publico, Loader._version);
			if (File.Exists(target))
			{
				try
				{
					RemoteSettings srs = (RemoteSettings) XMLUtils.DeserializarDocumento(target, string.Empty, string.Empty, typeof(RemoteSettings));
					srs.Desencriptar();
					Loader._srs = srs;
					Loader._srs.ExportarAjustes();
				}
				catch(Exception innerE)
				{
					new SIGUANETDesktopException(ExceptionCategory.SRSDeserializationFailed, "Loader.ForceLoadPublicSRSLocalCopy", innerE, target);
				}
			}
			else
			{
				new SIGUANETDesktopException(ExceptionCategory.SRSLocalPathNotFound, "Loader.ForceLoadPublicSRSLocalCopy", new FileNotFoundException(), target);
			}
		}		
		
		private static bool HTTPRequestCheck(Uri uri, string usr, string pwd, ExceptionCategory returnEC)
		{
			HttpWebRequest req = null;
			HttpWebResponse resp = null;
			try
			{
				req = (HttpWebRequest) WebRequest.Create(uri);
				if (usr != null)
				{
					if (usr.Trim() != string.Empty)
					{
						req.Credentials = new NetworkCredential(usr.Trim(), pwd);
					}
				}
				req.Timeout = 30000;
				resp = (HttpWebResponse) req.GetResponse();
				if (resp.StatusCode == HttpStatusCode.OK)
				{
					//Hacemos un único intento de reasignar la fecha del servidor a Loader.SystemDate
					//Para ello consultamos el elmento DATE de la cabecera de la respuesta
					if (!Loader._hasTriedServerDate)
					{
						string serverDate = resp.GetResponseHeader("Date");
						if (!DateTime.TryParse(serverDate, out Loader._systemDate))
						{
							Loader._systemDate = DateTime.Now;
					    	if (serverDate.Trim() == string.Empty)
					    	{
					    		new SIGUANETDesktopException(ExceptionCategory.LOADERServerDateParsingFailed, "Loader.HTTPRequestCheck", new ArgumentException(string.Format("Date string is empty")));
					    	}
					    	else
					    	{
					    		new SIGUANETDesktopException(ExceptionCategory.LOADERServerDateParsingFailed, "Loader.HTTPRequestCheck", new ArgumentException(string.Format("Invalid argument: {0}", serverDate)));
					    	}
						}
						Loader._hasTriedServerDate = true;
					}

					if (resp.ResponseUri != uri)
					{
						new SIGUANETDesktopException(returnEC, "Loader.HTTPRequestCheck", new Exception(string.Format("Server response URI was {0}", resp.ResponseUri)), uri.AbsoluteUri);
						return false;
					}
					if (resp.ContentType.Substring(0, 10) != "text/plain")
					{
						new SIGUANETDesktopException(returnEC, "Loader.HTTPRequestCheck", new Exception(string.Format("Server response Content-Type was {0}, but text/plain was expected", resp.ContentType)), uri.AbsoluteUri);
						return false;
					}
					return true;
				}
				else
				{
					new SIGUANETDesktopException(returnEC, "Loader.HTTPRequestCheck", new Exception(string.Format("Server response was {0}: {1}", Enum.GetName(typeof(HttpStatusCode), resp.StatusCode), resp.StatusDescription)), uri.AbsoluteUri);
					return false;
				}
			}
			catch (Exception e)
			{
				new SIGUANETDesktopException(returnEC, "Loader.HTTPRequestCheck", e, uri.AbsoluteUri);
				return false;
			}
			finally
			{
				if (resp != null) resp.Close();
			}
		}
		//Manejador de eventos para casos de perfil múltiple
		public static MultipleProfileDelegate MultipleProfileEvent;

		//Manejador de eventos para puntos de asignación de perfil
		public static ProfileSetDelegate ProfileSetEvent;
		
		//Manejador de eventos para cambios de impersonación
		public static ImpersonationChangedDelegate ImpersonationChangedEvent;
		
		//Manejador de eventos para cambios de perfil personalizado
		public static CustomProfileChangedDelegate CustomProfileChangedEvent;
	}
	
	public delegate void MultipleProfileDelegate(string[] profiles);
	public delegate void ProfileSetDelegate();
	public delegate void ImpersonationChangedDelegate();
	public delegate void CustomProfileChangedDelegate();
}
