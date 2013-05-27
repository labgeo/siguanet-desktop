/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 15/05/2008
 * Hora: 12:44
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.Perfiles
{
	/// <summary>
	/// Description of Profile.
	/// </summary>
	public class Profile
	{
		private ProfileType _generic = ProfileType.Publico;
		private string _custom;
		private string _sgdLocation;
		private string _sgdHttpUsr = string.Empty;
		private string _sgdHttpPwd = string.Empty;
		private bool _sgdDeserialized;
		private string _sgdDescription;
		private DateTime _sgdExpirationDate;
		
		public ProfileType Generic
		{
			get
			{
				return this._generic;
			}
		}
		
		public string Custom
		{
			get
			{
				return this._custom;
			}
		}
		
		

		public string SGDLocation
		{
			get
			{
				return this._sgdLocation;
			}
		}
		
		public string SGDHttpUsr {
			get { return _sgdHttpUsr; }
		}
		
		public string SGDHttpPwd {
			get { return _sgdHttpPwd; }
		}
		
		
		public bool SGDDeserialized
		{
			get
			{
				return this._sgdDeserialized;
			}
		}
		
		public string SGDDescription
		{
			get
			{
				return this._sgdDescription;
			}
		}
		
		public DateTime SGDExpirationDate
		{
			get
			{
				return this._sgdExpirationDate;
			}
		}
		
		public Profile(string profile)
		{
			string[] p = profile.Split('.');
			try
			{
				Root sgd = null;
				if (p[0] != null && p[0] != string.Empty)
				{
					this._generic = (ProfileType) Enum.Parse(typeof(ProfileType), p[0], true);
				}
				this._custom = (p.Length > 1) ? p[1] : string.Empty;
				this._sgdLocation = Root.GetDefaultRemoteLocation(this._generic, this._custom, Loader.Version);
				bool useCredentials = false;
				
				bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadUsingCredentials), out useCredentials);
				if (useCredentials)
				{
					this._sgdHttpUsr = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithLogin);
					this._sgdHttpPwd = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithPassword);
				}
				
				
				if (this._sgdLocation != string.Empty)
				{
					sgd = Root.GetDocumentFromURL(this._sgdLocation, this._sgdHttpUsr, this._sgdHttpPwd);
				}
				if (sgd != null)
				{
					this._sgdDeserialized = true;
					this._sgdDescription = sgd.Descripcion;
					this._sgdExpirationDate = sgd.Caducidad;
				}
				else
				{
					this._sgdDeserialized = false;
					this._sgdDescription = string.Empty;
					this._sgdExpirationDate = DateTime.MinValue;
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public override string ToString()
		{
			if (this._custom == string.Empty)
			{
				return Enum.GetName(typeof(ProfileType), this._generic).ToUpper();
			}
			else
			{
				return string.Format("{0}.{1}", Enum.GetName(typeof(ProfileType), this._generic).ToUpper(), this._custom.ToUpper());
			}
		}
	}
}
