/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tom�s
 * Fecha: 29/02/2008
 * Hora: 9:22
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

using System;

namespace SIGUANETDesktop.DB
{
	/// <summary>
	/// Description of DBSchemaInfo.
	/// </summary>
	public struct DBSchemaInfo
	{
		public readonly dbOrigen Source;
		public readonly string Name;

		public DBSchemaInfo(dbOrigen source, string name)
		{
			this.Source = source;
			this.Name = name;
		}
	}
}
