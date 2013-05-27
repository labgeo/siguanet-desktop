/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 15/05/2008
 * Hora: 9:18
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Data;
using System.Collections.ObjectModel;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.Perfiles
{
	/// <summary>
	/// Description of UserProfileQuery.
	/// </summary>
	public static class UserProfileQuery
	{
		public static Collection<UserProfile> GetProfilesByUser(string name)
		{
			string sSQL = "SELECT * FROM perfiles_userprofilequery_getprofilesbyuser(:param1)";
			object[] aParams = new object[] {name};
			Collection<UserProfile> r = new Collection<UserProfile>();
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.AppendUserProfiles(ds);
			}
			else
			{
				System.Diagnostics.Debug.Print((string) ds.Tables[0].Rows[0][0]);
			}
			return r;
		}
		
		public static Collection<UserProfile> GetProfilesByDept(string name)
		{
			string sSQL = "SELECT * FROM perfiles_userprofilequery_getprofilesbydept(:param1)";
			object[] aParams = new object[] {name};
			Collection<UserProfile> r = new Collection<UserProfile>();
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.AppendUserProfiles(ds);
			}
			return r;			
		}
		
		public static Collection<UserProfile> GetPublicCustomProfiles()
		{
			Collection<UserProfile> r = new Collection<UserProfile>();
			return r;			
		}
		
		public static Collection<UserProfile> GetNonPublicCustomProfiles()
		{
			string sSQL = "SELECT * FROM perfiles_userprofilequery_getnonpubliccustomprofiles()";
			Collection<UserProfile> r = new Collection<UserProfile>();
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.AppendUserProfiles(ds);
			}
			return r;
		}
	}
}
