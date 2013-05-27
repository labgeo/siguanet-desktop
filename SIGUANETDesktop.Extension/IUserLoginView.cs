/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 27/02/2013
 * Hora: 14:31
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace SIGUANETDesktop.Extension
{
	/// <summary>
	/// Description of UserLoginView.
	/// </summary>
	public interface IUserLoginView
	{
		string Usr { get; }
		string Clave { get;	}
		bool IsAnonymous { get;	}
		string PerfilPersonalizado { get; }
		bool SRSByPass { get; }
		object[] GetAuthInfo ();
		void ShowView ();
	}
}
