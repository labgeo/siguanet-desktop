/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 29/04/2008
 * Hora: 15:17
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Reflection;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.Perfiles;

namespace SIGUANETDesktop
{
	/// <summary>
	/// Clase interna para la definición de reglas de deshabilitación
	/// de controles en función del perfil
	/// </summary>
	internal class GUIRule
	{
		private object _guiComponent = null;
		private ProfileType[] _disabledProfiles = null;
		private bool _override = false;
		
		public GUIRule (object guiComponent, ProfileType[] disabledProfiles)
		{
			this._guiComponent = guiComponent;
			this._disabledProfiles = disabledProfiles;
		}
		
		public GUIRule (object guiComponent, ProfileType[] disabledProfiles, BooleanExpressionDelegate overrideExpression)
		{
			this._guiComponent = guiComponent;
			this._disabledProfiles = disabledProfiles;
			this._override = overrideExpression.Invoke();
		}	
		
		public void Apply()
		{
			if (this._guiComponent != null)
			{
				foreach (ProfileType p in this._disabledProfiles)
				{
					if (Loader.Profile == p)
					{
						Type t = this._guiComponent.GetType();
						PropertyInfo pE = t.GetProperty("Enabled");
						if (pE != null)
						{
							pE.SetValue(this._guiComponent, this._override, null);
						}
						PropertyInfo pV = t.GetProperty("Visible");
						if (pV != null)
						{
							pV.SetValue(this._guiComponent, this._override, null);
						}
						break;
					}
				}
			}
		}
	}
}
