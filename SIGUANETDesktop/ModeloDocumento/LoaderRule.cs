/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tom�s
 * Fecha: 23/04/2008
 * Hora: 10:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

using System;

namespace SIGUANETDesktop.ModeloDocumento
{
	/// <summary>
	/// Description of LoaderRule.
	/// </summary>
	internal struct LoaderRule
	{
		public bool ForcePublic;
		public bool UseLocal;
		
		public LoaderRule(bool forcePublic, bool useLocal)
		{
			ForcePublic = forcePublic;
			UseLocal = useLocal;
		}
	}
}
