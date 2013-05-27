/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 17/03/2008
 * Hora: 10:56
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.Perfiles;
using SIGUANETDesktop.Preferencias;
using SIGUANETDesktop.Utilidades;
using SIGUANETDesktop.DB;


namespace SIGUANETDesktop.ModeloDocumento
{
	/// <summary>
	/// Description of RemoteSettings.
	/// </summary>
	public class RemoteSettings
	{
		private const string EXT = "srs";
		
		private string _formalFileName
		{
			get
			{
				string version = ((this._version == string.Empty || this._version == null) ? "none" : this._version);
				return RemoteSettings.BuildFormalFileName((ProfileType) Enum.Parse(typeof(ProfileType), this._perfil), version);
			}
		}
						
		//El documento de ajustes remotos (SRS) por defecto
		//se ubica en el mismo directorio que el ensamblado actual y 
		//su nombre sigue el patrón "{perfil}_{version}.srs"
		[XmlIgnore]
		public string DefaultLocation
		{
			get
			{
				return Path.Combine(Loader.AssemblyDir, this._formalFileName);
			}
		}		
		
		//El documento SIGUANETDesktop por defecto
		//se ubica en el mismo directorio que el ensamblado actual y 
		//su nombre sigue el patrón "{perfil}_{version}.srs"
		public static string GetDefaultLocation(ProfileType perfil, string version)
		{
			return Path.Combine(Loader.AssemblyDir, RemoteSettings.BuildFormalFileName(perfil, version));
		}
		
		//Método estático de conveniencia para generar la url de documento dado un perfil
		public static string GetDefaultRemoteLocation(ProfileType perfil, string version)
		{
			string url = string.Empty;
			string baseUrl = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadURL);
			
			try
			{
				Uri baseUri = new Uri(baseUrl);
				Uri docUri = new Uri(baseUri, RemoteSettings.BuildFormalFileName(perfil, Loader.Version));
				url = docUri.AbsoluteUri;
			}
			catch
			{
				//Simplemente devolvemos la cadena vacía
			}
			return url;
		}
		
		public static string BuildFormalFileName(ProfileType perfil, string version)
		{
			return string.Format("{0}_{1}.{2}", perfil, version, RemoteSettings.EXT);
		}
		
		public string BuildFormalFileName()
		{
			return string.Format("{0}_{1}.{2}", _perfil, _version, RemoteSettings.EXT);
		}		
		
		private static Rijndael _rij = new Rijndael();
		
		private string _version = string.Format("{0}.{1}", Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(), Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString());
		[XmlElement]
		public  string Version
		{
			get
			{
				return _version;
			}
			set
			{
				_version = value;
			}
		}
		
		private string _pgsqlhost = string.Empty;
		[XmlElement("E1")]
		public  string PGSQLHost
		{
			get
			{
				return _pgsqlhost;
			}
			set
			{
				_pgsqlhost = value;
			}
		}
		
		private string _pgsqlport = "5432";
		[XmlElement("E2")]
		public string PGSQLPort
		{
			get
			{
				return _pgsqlport;
			}
			set
			{
				_pgsqlport = value;
			}
		}
		
		private  string _pgsqldb = string.Empty;
		[XmlElement("E3")]
		public  string PGSQLDb
		{
			get
			{
				return _pgsqldb;
			}
			set
			{
				_pgsqldb = value;
			}
		}
		
		private  string _pgsqlusr = string.Empty;
		[XmlElement("E4")]
		public  string PGSQLUsr
		{
			get
			{
				return _pgsqlusr;
			}
			set
			{
				_pgsqlusr = value;
			}
		}
		
		private  string _pgsqlpwd = string.Empty;
		[XmlElement("E5")]
		public  string PGSQLPwd
		{
			get
			{
				return _pgsqlpwd;
			}
			set
			{
				_pgsqlpwd = value;
			}
		}
		
		private  string _pgsqlCmdTimeOut = "60";
		[XmlElement("E6")]
		public  string PGSQLCmdTimeOut
		{
			get
			{
				return _pgsqlCmdTimeOut;
			}
			set
			{
				_pgsqlCmdTimeOut = value;
			}
		}
		
		private  string _perfil = ProfileType.Publico.ToString();
		[XmlElement("E7")]
		public  string Perfil
		{
			get
			{
				return _perfil;
			}
			set
			{
				_perfil = value;
			}
		}
				
		public RemoteSettings()
		{
			
		}
			
		public void Serializar(string path, bool encriptar)
		{
			XmlSerializer x;
			System.Xml.XmlTextWriter w;

			try
			{
				if (Directory.Exists(path))
				{
					path = Path.Combine(path, this._formalFileName);
				}
				if (encriptar)
				{
					this.Encriptar();
				}
				x = new XmlSerializer(this.GetType());
				w = new XmlTextWriter(path, System.Text.Encoding.Unicode);
	        	w.Formatting = Formatting.Indented;
	        	w.Indentation = 2;
	        	x.Serialize(w, this);
	        	w.Close();
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (encriptar) this.Desencriptar();
			}
		}
		
		public string Serializar(bool encriptar)
		{
			XmlSerializer x;
			System.Xml.XmlTextWriter w;

			try
			{
				if (encriptar)
				{
					this.Encriptar();
				}
				x = new XmlSerializer(this.GetType());
				w = new XmlTextWriter(new MemoryStream(), Encoding.Unicode);
	        	w.Formatting = Formatting.Indented;
	        	w.Indentation = 2;
	        	x.Serialize(w, this);
	        	byte[] xmlBytes = (w.BaseStream as MemoryStream).ToArray();
	        	w.Close();
	        	return UnicodeEncoding.Unicode.GetString(xmlBytes);
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				if (encriptar) this.Desencriptar();
			}
		}		
		
		private void Encriptar()
		{
			this._pgsqlhost = _rij.Encrypt(this._pgsqlhost);
			this._pgsqlport = _rij.Encrypt(this._pgsqlport);
			this._pgsqldb = _rij.Encrypt(this._pgsqldb);
			this._pgsqlusr = _rij.Encrypt(this._pgsqlusr);
			this._pgsqlpwd = _rij.Encrypt(this._pgsqlpwd);
			this._pgsqlCmdTimeOut = _rij.Encrypt(this._pgsqlCmdTimeOut);
			this._perfil = _rij.Encrypt(this._perfil);
		}
		
		public void Desencriptar()
		{
			this._pgsqlhost = _rij.Decrypt(this._pgsqlhost);
			this._pgsqlport = _rij.Decrypt(this._pgsqlport);
			this._pgsqldb = _rij.Decrypt(this._pgsqldb);
			this._pgsqlusr = _rij.Decrypt(this._pgsqlusr);
			this._pgsqlpwd = _rij.Decrypt(this._pgsqlpwd);
			this._pgsqlCmdTimeOut = _rij.Decrypt(this._pgsqlCmdTimeOut);
			this._perfil = _rij.Decrypt(this._perfil);
		}
		
		public void ExportarAjustes()
		{
			DBSettings.PGSQLHost = this.PGSQLHost;
			DBSettings.PGSQLPort = int.Parse(this.PGSQLPort);
			DBSettings.PGSQLDb = this.PGSQLDb;
			DBSettings.PGSQLUsr = this.PGSQLUsr;
			DBSettings.PGSQLPwd = this.PGSQLPwd;
			DBSettings.PGSQLCmdTimeOut = int.Parse(Loader.SRS.PGSQLCmdTimeOut);
		}
	}
}
