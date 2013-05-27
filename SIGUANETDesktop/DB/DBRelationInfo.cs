/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 29/02/2008
 * Hora: 9:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace SIGUANETDesktop.DB
{
	/// <summary>
	/// Description of DBRelationInfo.
	/// </summary>
	public struct DBRelationInfo
	{
		public readonly DBSchemaInfo Schema;
		public readonly string Name;
		public readonly dbRelationType Type;
		
		public DBRelationInfo(DBSchemaInfo schema, string name, dbRelationType type)
		{
			this.Schema = schema;
			this.Name = name;
			this.Type = type;
		}
	}
}
