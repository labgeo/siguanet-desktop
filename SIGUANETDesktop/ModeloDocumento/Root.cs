/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/05/2006
 * Time: 17:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.Perfiles;
using SIGUANETDesktop.ModeloExplotacion;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloSincronizacion;
using SIGUANETDesktop.ModeloClienteSOAP;
using SIGUANETDesktop.ModeloClienteSQL;
using SIGUANETDesktop.ModeloAdminTools;
using SIGUANETDesktop.Preferencias;
using SIGUANETDesktop.XML;

namespace SIGUANETDesktop.ModeloDocumento
{
	/// <summary>
	/// Description of Root.
	/// </summary>
	public class Root
	{
		private const string EXT = "sgd";
		private const string BAK = "sgd.backup";
		public static readonly DateTime NO_EXPIRATION = new DateTime(9000, 1, 1);
			
		private string _formalFileName
		{
			get
			{
				string version = ((this._version == string.Empty || this._version == null) ? "none" : this._version);
				return Root.BuildFormalFileName(this._perfil, this._perfilPersonalizado, version);
			}
		}
		
		//El documento SIGUANETDesktop (SGD) por defecto
		//se ubica en el mismo directorio que el ensamblado actual y 
		//su nombre sigue el patrón "{perfil}_{version}.sgd"
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
		//su nombre sigue el patrón "{perfil}_{version}.sgd" o
		//"{perfil}[{PerfilPersonalizado}]_{version}.sgd"
		public static string GetDefaultLocation(ProfileType perfil, string perfilPersonalizado, string version)
		{
			return Path.Combine(Loader.AssemblyDir, Root.BuildFormalFileName(perfil, perfilPersonalizado, version));
		}
		
		//Método estático de conveniencia para generar la url de documento dado un perfil
		public static string GetDefaultRemoteLocation(ProfileType perfil, string perfilPersonalizado, string version)
		{
			string url = string.Empty;
			string baseUrl = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadURL);
			
			try
			{
				Uri baseUri = new Uri(baseUrl);
				Uri docUri = new Uri(baseUri, Root.BuildFormalFileName(perfil, perfilPersonalizado, Loader.Version));
				url = docUri.AbsoluteUri;
			}
			catch
			{
				//Simplemente devolvemos la cadena vacía
			}
			return url;
		}		
		
		public static string BuildFormalFileName(ProfileType perfil, string perfilPersonalizado, string version)
		{
			if (perfilPersonalizado == null || perfilPersonalizado.Trim() == string.Empty)
			{
				return string.Format("{0}_{1}.{2}", perfil, version, Root.EXT);
			}
			else
			{
				return string.Format("{0}[{1}]_{2}.{3}", perfil, perfilPersonalizado, version, Root.EXT);
			}
		}
		
		public string BuildFormalFileName()
		{
			if (_perfilPersonalizado == null || _perfilPersonalizado.Trim() == string.Empty)
			{
				return string.Format("{0}_{1}.{2}", _perfil, _version, Root.EXT);
			}
			else
			{
				return string.Format("{0}[{1}]_{2}.{3}", _perfil, _perfilPersonalizado, _version, Root.EXT);
			}
		}
		
		//Método estático de conveniencia para instanciar un objeto documento dada una url
		public static Root GetDocumentFromURL(string url, string usr, string pwd)
		{
			Root sgd = null;
			try
			{
				sgd = (Root) XMLUtils.DeserializarDocumento(url, usr, pwd, typeof(Root));
			}
			catch
			{
				//Simplemente devolvemos un documento nulo
			}
			return sgd;
		}
		
		private ProfileType _perfil = ProfileType.Anonymous;
		[XmlAttribute]
		public ProfileType Perfil
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
		
		//Cadena que especifica un perfil personalizado
		private string _perfilPersonalizado = string.Empty;
		[XmlAttribute]
		public string PerfilPersonalizado
		{
			get
			{
				return _perfilPersonalizado;
			}
			set
			{
				_perfilPersonalizado = value.Trim().ToUpper();
			}
		}
		
		private string _version = string.Format("{0}.{1}", Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(), Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString());
		[XmlAttribute]
		public string Version
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
		
		private DateTime _caducidad = Root.NO_EXPIRATION;
		[XmlAttribute]
		public DateTime Caducidad
		{
			get
			{
				return _caducidad;
			}
			set
			{
				_caducidad = value;
			}
		}
		
		[XmlIgnore]
		public bool Caducado
		{
			get
			{
				return (this._caducidad.CompareTo(Loader.SystemDate) < 0);
			}
		}
				
		private DateTime _modificado = DateTime.Now;
		[XmlAttribute]
		public DateTime Modificado
		{
			get
			{
				return _modificado;
			}
			set
			{
				_modificado = value;
			}
		}
		
		private string _url = string.Empty;
		[XmlAttribute]
		public string Url
		{
			get 
			{ 
				return _url; 
			}
			set 
			{
				_url = value; 
			}
		}
		
		private string _autor = string.Empty;
		[XmlAttribute]
		public string Autor
		{
			get 
			{
				return _autor;
			}
			set
			{
				_autor = value;
			}
		}
		
		private string _nombre = "SIGUANETDesktop";
		[XmlAttribute]
		public string Nombre
		{
			get 
			{
				return _nombre;
			}
			set
			{
				_nombre = value;
			}
		}
		
		private string _descripcion = "Nueva sesión de trabajo SIGUANETDesktop";
		[XmlAttribute]
		public string Descripcion
		{
			get
			{
				return _descripcion;
			}
			set
			{
				_descripcion = value;
			}
		}
		
		private string _doc = string.Empty;
		[XmlAttribute]
		public string Doc
		{
			get
			{
				return _doc;
			}
			set
			{
				_doc = value;
			}
		}
		
		private DbSyncClient _dbSync = new DbSyncClient();
		[XmlElement]
		public DbSyncClient DbSync
		{
			get
			{
				return _dbSync;
			}
			set
			{
				_dbSync = value;
			}
		}
		
		private QuestClient _quest = new QuestClient();
		[XmlElement]
		public QuestClient Quest
		{
			get
			{
				return _quest;
			}
			set
			{
				_quest = value;
			}
		}
		
		private SoapClient _soap = new SoapClient();
		[XmlElement]
		public SoapClient Soap
		{
			get
			{
				return _soap;
			}
			set
			{
				_soap = value;
			}
		}
		
		private SqlTerminal _sql = new SqlTerminal();
		[XmlElement]
		public SqlTerminal Sql
		{
			get
			{
				return _sql;
			}
			set
			{
				_sql = value;
			}
		}
		
		private AdminToolSet _adminTools = new AdminToolSet();
		[XmlElement]
		public AdminToolSet AdminTools
		{
			get
			{
				return _adminTools;
			}
			set
			{
				_adminTools = value;
			}
		}
		
		[XmlIgnore]
		public Collection<PropertyInfo> RootModules
		{
			get
			{
				Collection<PropertyInfo> mods = new Collection<PropertyInfo>();
				foreach (PropertyInfo p in this.GetType().GetProperties())
				{
					if (p.PropertyType.BaseType.Equals(typeof(RootModule)))
					{
						mods.Add(p);
					}
				}
				return mods;
			}
		}
		
		public Root()
		{
			
		}
		
		public void Serializar(string path)
		{
			XmlSerializer x;
			System.Xml.XmlTextWriter w;
			try
			{
				x = new XmlSerializer(this.GetType());
				//path puede ser tanto un directorio como la ruta completa de un fichero
				if (Directory.Exists(path))
				{
					path = Path.Combine(path, this._formalFileName);
				}
				this.Backup(path);
			    w = new XmlTextWriter(path, Encoding.Unicode);
	        	w.Formatting = Formatting.Indented;
	        	w.Indentation = 2;
	        	x.Serialize(w, this);
	        	w.Close();
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public string Serializar()
		{
			XmlSerializer x;
			System.Xml.XmlTextWriter w;
			try
			{
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
		}		
		
		private void Backup(string path)
		{
			if (File.Exists(path))
			{
				string pathCopiaRespaldo = string.Format("{0}.{1}", Path.GetFileNameWithoutExtension(path), Root.BAK);
				pathCopiaRespaldo = Path.Combine(Path.GetDirectoryName(path), pathCopiaRespaldo);
				File.Copy(path, pathCopiaRespaldo, true);
			}
		}
		
		public void UpdateVersion()
		{
			_version = string.Format("{0}.{1}", Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(), Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString());
		}
	}
}
