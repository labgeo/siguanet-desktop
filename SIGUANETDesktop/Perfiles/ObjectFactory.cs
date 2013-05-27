/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 16/05/2008
 * Hora: 9:45
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Collections.ObjectModel;
using System.Data;

namespace SIGUANETDesktop.Perfiles
{
	/// <summary>
	/// Description of ObjectFactory.
	/// </summary>
	public static class ObjectFactory
	{
		public static Collection<UserProfile> AppendUserProfiles(DataSet ds)
		{
			Collection<UserProfile> r = new Collection<UserProfile>();
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string userId = (string) dr["userid"];
					string userName = (string) dr["username"];
					string managedDeptId = string.Empty;
					if (dr["managed_deptid"].GetType() != typeof(System.DBNull))
					{
						managedDeptId = (string) dr["managed_deptid"];
					}
					string managedDeptName = string.Empty;
					if (dr["managed_deptname"].GetType() != typeof(System.DBNull))
					{
						managedDeptName = (string) dr["managed_deptname"];
					}
					string profile = string.Empty;
					if (dr["profile"].GetType() != typeof(System.DBNull))
					{
						profile = (string) dr["profile"];
					}
					UserProfile up = new UserProfile(userId, userName, managedDeptId, managedDeptName, profile);
					r.Add(up);
				}
			}
			return r;
		}
	}
}
