/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 24/04/2008
 * Hora: 9:20
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Collections.ObjectModel;

namespace SIGUANETDesktop.Log
{
	/// <summary>
	/// Description of AppLog.
	/// </summary>
	public sealed class AppLog
	{
		private static AppLog instance = new AppLog();
		
		public static AppLog Instance {
			get {
				return instance;
			}
		}
		
		private AppLog()
		{
		}
		
		private bool _isEmpty = true;
		
		private Collection<SIGUANETDesktopException> _exceptions = new Collection<SIGUANETDesktopException>();
		public SIGUANETDesktopException[] Exceptions
		{
			get
			{
				SIGUANETDesktopException[] clon = new SIGUANETDesktopException[this._exceptions.Count];
				
				this._exceptions.CopyTo(clon, 0);
				return clon;
			}
		}
		public ExceptionLoggedDelegate ExceptionLoggedEvent;
		public ExceptionsExistDelegate ExceptionsExistEvent;
		
		public void Log(SIGUANETDesktopException ex)
		{
			this._exceptions.Add(ex);
			//IMPORTANTE: Antes de lanzar el evento comprobamos que exista algún manejador enlazado.
			//Para ello basta con emplear if (nombreEvento != null)
			if (ExceptionLoggedEvent != null) ExceptionLoggedEvent(ex);
			if (this._isEmpty)
			{
				this._isEmpty = false;
				if (ExceptionsExistEvent != null) ExceptionsExistEvent(this._exceptions.Count);
			}
		}
	}
	public delegate void ExceptionLoggedDelegate(SIGUANETDesktopException e);
	public delegate void ExceptionsExistDelegate(int count);
}
