/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 07/04/2006
 * Time: 12:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Reflection;
using System.Resources;


namespace SIGUANETDesktop.DB
{
	/// <summary>
	/// Description of DBSettings.
	/// </summary>
	public static class DBSettings
	{

		private static string _oratns = string.Empty;
		public static string ORATNS
		{
			get
			{
				return _oratns;
			}
			set
			{
				_oratns = value;
			}
		}
		
		private static string _orausr = string.Empty;
		public static string ORAUsr
		{
			get
			{
				return _orausr;
			}
			set
			{
				_orausr = value;
			}
		}
		
		private static string _orapwd = string.Empty;
		public static string ORAPwd
		{
			get
			{
				return _orapwd;
			}
			set
			{
				_orapwd = value;
			}
		}
		
		private static int _pgsqlport = 5432;
		public static int PGSQLPort
		{
			get
			{
				return _pgsqlport;
			}
			set
			{
				_pgsqlport = value;
			}
		}

		private static string _pgsqlhost = string.Empty;
		public static string PGSQLHost
		{
			get
			{
				return _pgsqlhost;
			}
			set
			{
				_pgsqlhost = value;
			}
		}
		
		private static string _pgsqldb = "siguanet";
		public static string PGSQLDb
		{
			get
			{
				return _pgsqldb;
			}
			set
			{
				_pgsqldb = value;
			}
		}
		
		private static string _pgsqlusr = string.Empty;
		public static string PGSQLUsr
		{
			get
			{
				return _pgsqlusr;
			}
			set
			{
				_pgsqlusr = value;
			}
		}
		
		private static string _pgsqlpwd = string.Empty;
		public static string PGSQLPwd
		{
			get
			{
				return _pgsqlpwd;
			}
			set
			{
				_pgsqlpwd = value;
			}
		}
		
		private static int _pgsqlCmdTimeOut = 60;
		public static int PGSQLCmdTimeOut
		{
			get
			{
				return _pgsqlCmdTimeOut;
			}
			set
			{
				_pgsqlCmdTimeOut = value;
			}
		}		
		
		public static bool PGSQLSettingsOK
		{
			get
			{
				return _pgsqlport > 0 &&
					   _pgsqlhost.Trim() != string.Empty &&
					   _pgsqldb.Trim() != string.Empty &&
					   _pgsqlusr.Trim() != string.Empty &&
					   _pgsqlpwd.Trim() != string.Empty;
			}
		}
	}
}
