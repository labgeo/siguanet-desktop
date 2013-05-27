/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 23/04/2008
 * Hora: 13:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Reflection;
using System.Resources;

namespace SIGUANETDesktop.Log
{
	/// <summary>
	/// Description of SIGUANETDesktopException.
	/// </summary>
	public class SIGUANETDesktopException : Exception
	{
		private const string  EXCEPTION_STRINGS = "SIGUANETDesktop.ExceptionStrings";
		
		private ExceptionCategory _category;
		public ExceptionCategory Category
		{
			get
			{
				return this._category;
			}
		}
		
		private DateTime _timeStamp;
		public DateTime TimeStamp
		{
			get
			{
				return this._timeStamp;
			}
		}
		
		private string _sourceMethod;
		public string SourceMethod
		{
			get
			{
				return this._sourceMethod;
			}
		}
		
		private string[] _args = null;
		public override string Message
		{
			get
			{
				ResourceManager rmExceptions = new ResourceManager(EXCEPTION_STRINGS, Assembly.GetExecutingAssembly());
				string msg = rmExceptions.GetString(Enum.GetName(typeof(ExceptionCategory), this.Category));
				if (this._args != null)
				{
					msg = string.Format(msg, this._args);
				}
				return msg;
			}
		}
		
		public SIGUANETDesktopException(ExceptionCategory category, string sourceMethod, Exception innerEx, params string[] args) : base(string.Empty, innerEx)
		{
			this._category = category;
			this._timeStamp = DateTime.Now;
			this._sourceMethod = sourceMethod;
			this._args = args;
			AppLog.Instance.Log(this);
		}
	}
	
	
}
