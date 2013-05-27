/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 29/02/2008
 * Hora: 9:31
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace SIGUANETDesktop.DB
{
	/// <summary>
	/// Description of DBColumnInfo.
	/// </summary>
	public struct DBColumnInfo
	{
		public readonly DBRelationInfo Relation;
		public readonly string Name;
		public readonly string TypeName;
		public readonly string TypeLength;
		
		public DBColumnInfo(DBRelationInfo relation, string name, string typeName, string typeLength)
		{
			this.Relation = relation;
			this.Name = name;
			this.TypeName = typeName;
			this.TypeLength = typeLength;
		}
	}
}
