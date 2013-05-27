/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 27/02/2013
 * Hora: 14:59
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Configuration;

namespace SIGUANETDesktop.Extension
{
	/// <summary>
	/// Description of ExtensionLocator.
	/// </summary>
	public class ExtensionLocator
	{
		IDictionary<string, Assembly> loadedAssemblies;
		IList<string> unavailableAssemblies;
		IDictionary<Type, AddIn> availableAddIns;
		
		public ExtensionLocator()
		{
			loadedAssemblies = new Dictionary<string, Assembly> ();
			unavailableAssemblies = new List<string> ();
			availableAddIns = new Dictionary<Type, AddIn> ();
		}
		
		public void LocateAll ()
		{
			foreach (Type extensionPoint in GetExtensionPoints ()) {
				string extensionLibPath = ConfigurationManager.AppSettings.Get (extensionPoint.Name);
				if (!string.IsNullOrEmpty (extensionLibPath)) {
					Assembly extensionLib;
					if (!unavailableAssemblies.Contains (extensionLibPath)) {
						if (!loadedAssemblies.TryGetValue (extensionLibPath, out extensionLib)) {
							try {
								extensionLib = Assembly.LoadFile (extensionLibPath);
								loadedAssemblies.Add (extensionLibPath, extensionLib);
							}
							catch {
								unavailableAssemblies.Add (extensionLibPath);
							}
						}
						if (extensionLib != null) {
							RegisterAddIn (extensionPoint, extensionLib);
						}
					}
				}
			}
		}
		
		public T GetExtension<T> ()
		{
			AddIn addIn;
			if (availableAddIns.TryGetValue (typeof(T), out addIn)) {
				return (T)addIn.Assembly.CreateInstance(addIn.Type.FullName);
			}
			else {
				return default (T);
			}
		}
		
		IList<Type> GetExtensionPoints ()
		{
			IList<Type> extensionTypes = new List<Type> ();
			Assembly a = Assembly.GetExecutingAssembly ();
			foreach (Type t in a.GetTypes ()) {
				if (t.IsInterface && t.IsPublic) {
					extensionTypes.Add (t);
				}
			}
			return extensionTypes;
		}
		
		void RegisterAddIn (Type extensionPoint, Assembly extensionLib)
		{
			Type[] types = extensionLib.GetTypes();
            foreach (Type extension in types) {
            	if (extension.GetInterface(extensionPoint.Name) != null) {
					availableAddIns.Add (extensionPoint, new AddIn (extensionLib, extension));
					break;
				}
            }
		}
	}
}
