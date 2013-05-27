/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 15/05/2008
 * Hora: 9:28
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Collections.ObjectModel;

namespace SIGUANETDesktop.Perfiles
{
	/// <summary>
	/// Description of UserProfile.
	/// </summary>
	public class UserProfile
	{
		private string _userId;
		
		
		
		
		public string UserId
		{
			get
			{
				return this._userId;
			}
		}
		
		private string _userName;
		public string UserName
		{
			get
			{
				return this._userName;
			}
		}
		
		private string _managedDeptId;
		public string ManagedDeptId
		{
			get
			{
				return this._managedDeptId;
			}
		}
		
		private string _managedDeptName;
		public string ManagedDeptName
		{
			get
			{
				return this._managedDeptName;
			}
		}		
		
		private Collection<Profile> _profiles = new Collection<Profile>();
		public Collection<Profile> Profiles
		{
			get
			{
				return this._profiles;
			}
		}
		
		private static Collection<Profile> _profileCache = new Collection<Profile>();
		
		public UserProfile(string userId, string userName, string managedDeptId, string managedDeptName, string profile)
		{
			this._userId = userId;
			this._userName = userName;
			this._managedDeptId = managedDeptId;
			this._managedDeptName = managedDeptName;
			//Control de múltiples perfiles
			string[] profiles = profile.Split(',');
			foreach(string p in profiles)
			{
				Profile cp = this.GetCachedProfile(p);
				if (cp != null)
				{
					this._profiles.Add(cp);
				}
				else
				{
					try
					{
						Profile np = new Profile(p);
						this._profiles.Add(np);
						UserProfile._profileCache.Add(np);
					}
					catch
					{
						//Simplemente no añadimos el perfil a la colección
					}
				}
			}
		}
		
		private Profile GetCachedProfile(string profile)
		{
			Profile cp = null;
			string[] pInfo = profile.Split('.');
			string generic = string.Empty;
			string custom = string.Empty;
			if (pInfo[0] != null && pInfo[0] != string.Empty)
			{
				generic = pInfo[0];
			}
			if (pInfo.Length > 1)
			{
				if (pInfo[1] != null && pInfo[1] != string.Empty)
				{
					custom = pInfo[1];
				}				
			}
			if (generic == string.Empty)
			{
				generic = Enum.GetName(typeof(ProfileType), ProfileType.Publico);
			}
			foreach (Profile p in UserProfile._profileCache)
			{
				try
				{
					if ((ProfileType) Enum.Parse(typeof(ProfileType), generic, true) == p.Generic && custom == p.Custom)
					{
						cp = p;
						break;
					}
				}
				catch
				{
					break;
				}
			}
			return cp;
		}
	}
}
