/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 25/02/2008
 * Hora: 13:51
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SIGUANETDesktop.Preferencias
{
	/// <summary>
	/// Description of AdministradorPreferencias.
	/// </summary>
	public static class AdministradorPreferencias
	{
		private const string PREFS_FILE = "SIGUANETDesktop.prefs";
		private const string PREFS_GLOBAL = "SIGUANETDesktop.PrefsGlobal";
		private const string PREFS_BD = "SIGUANETDesktop.PrefsBD";
		private static Preferencias _prefs = null;
		
		public static void Load()
		{
			_prefs = new Preferencias();
			//Asignamos valores por defecto (presentes en ficheros .resx), el resto a null
			//Hashtable de preferencias globales
			ResourceManager rmGlobal = new ResourceManager(PREFS_GLOBAL, Assembly.GetExecutingAssembly());
			foreach (PrefsGlobal clave in Enum.GetValues(typeof(PrefsGlobal)))
			{
				_prefs._global.Add(clave, rmGlobal.GetString(clave.ToString()));
			}
			//Hashtable de preferencias de base de datos
			ResourceManager rmBD = new ResourceManager(PREFS_BD, Assembly.GetExecutingAssembly());
			foreach (PrefsBD clave in Enum.GetValues(typeof(PrefsBD)))
			{
				_prefs._bd.Add(clave, rmBD.GetString(clave.ToString()));
			}
			//Añadir aquí código para nuevas hashtable de preferencias
			//...
			

			//En las claves con valores nulos copiamos los que ya 
			//hubieran sido asignados en el fichero de preferencias.
			//Como efecto colateral, las claves que ya no existan,
			//quedan automáticamente desechadas para la próxima serialización
			if (File.Exists(PREFS_FILE))
			{
				Preferencias oldPrefs = null;
				using (Stream s = new FileStream(PREFS_FILE, FileMode.Open))
				{
					BinaryFormatter bf = new BinaryFormatter();
					oldPrefs = (Preferencias) bf.Deserialize(s);
					s.Close();
				}
				if (oldPrefs != null)
				{
					//Hashtable de preferencias globales
					foreach (PrefsGlobal clave in Enum.GetValues(typeof(PrefsGlobal)))
					{
						if (oldPrefs._global != null)
						{
							if (oldPrefs._global.ContainsKey(clave))
							{
								if (_prefs._global[clave] == null && oldPrefs._global[clave] != null)
								{
									_prefs._global[clave] = oldPrefs._global[clave];
								}
							}
						}
					}
					//Hashtable de preferencias de base de datos
					foreach (PrefsBD clave in Enum.GetValues(typeof(PrefsBD)))
					{
						if (oldPrefs._bd != null)
						{
							if (oldPrefs._bd.ContainsKey(clave))
							{
								if (_prefs._bd[clave] == null && oldPrefs._bd[clave] != null)
								{
									_prefs._bd[clave] = oldPrefs._bd[clave];
								}
							}
						}
					}
					//Añadir aquí código para nuevas hashtable de preferencias
					//...
				}
			}
		}
			
		public static void Save()
		{
			if (_prefs != null)
			{
				try
				{
					using (Stream s = new FileStream(PREFS_FILE, FileMode.Create))
					{
						BinaryFormatter bf = new BinaryFormatter();
						bf.Serialize(s, _prefs);
						s.Close();
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
		
		public static void Update(PrefsBD preferencia, object valor)
		{
			if (_prefs == null)
			{
				throw new Exception("No se ha inicializado el administrador de preferencias");
			}
			else
			{
				_prefs._bd[preferencia] = valor;				
			}
		}
		
		public static string Read(PrefsBD preferencia)
		{
			if (_prefs == null)
			{
				throw new Exception("No se ha inicializado el administrador de preferencias");
			}
			else
			{			
				return (string) _prefs._bd[preferencia];
			}
		}
		
		public static void Update(PrefsGlobal preferencia, object valor)
		{
			if (_prefs == null)
			{
				throw new Exception("No se ha inicializado el administrador de preferencias");
			}
			else
			{
				if (preferencia == PrefsGlobal.SGDDownloadURL || preferencia == PrefsGlobal.AuthDownloadURL)
				{
					valor = (valor as string).EndsWith("/") ? valor : valor + "/";
				}
				_prefs._global[preferencia] = valor;
			}
		}
		
		public static string Read(PrefsGlobal preferencia)
		{
			if (_prefs == null)
			{
				throw new Exception("No se ha inicializado el administrador de preferencias");
			}
			else
			{			
				return (string) _prefs._global[preferencia];
			}
		}
	}
}
