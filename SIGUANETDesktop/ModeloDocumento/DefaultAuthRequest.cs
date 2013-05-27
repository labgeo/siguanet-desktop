/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 01/03/2013
 * Hora: 13:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using SIGUANETDesktop.Extension;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.Log;
using Npgsql;

namespace SIGUANETDesktop.ModeloDocumento
{
	/// <summary>
	/// Description of DefaultAuthRequest.
	/// </summary>
	public class DefaultAuthRequest : IAuthRequest
	{
		public DefaultAuthRequest()
		{
		}
		
		public IAuthResponse GetResponse(params object[] args)
		{
			if (args == null || args.Length < 1) {
				return new DefaultAuthResponse (false, "MISSING_IDENTIFIER", string.Empty);
			}
			else {
				string id = (string) args[0];
				try {
					return new DefaultAuthResponse (IsUser (id), "OK", id);
				}
				catch (Exception e) {
					new SIGUANETDesktopException(ExceptionCategory.LOADERAuthenticationAborted, "DefaultAuthRequest.GetResponse", e);
					return new DefaultAuthResponse (false, "UNRESOLVED_IDENTIFIER", id, e);
				}
			}
		}
		
		bool IsUser (string id)
		{
			string sCn = DBUtils.GetPGSQLCnString();
			string sSQL = "SELECT ARRAY[EXISTS(SELECT 1 FROM personalpas WHERE upper(nif) = upper(:param1))," +
	       							   "EXISTS(SELECT 1 FROM personalpdi WHERE upper(nif) = upper(:param1))," +
	       							   "EXISTS(SELECT 1 FROM becarios WHERE upper(nif) = upper(:param1))];";
			using (NpgsqlConnection pgCn = new NpgsqlConnection(sCn)) {
				pgCn.Open();
				using (NpgsqlCommand pgCmd = new NpgsqlCommand(sSQL, pgCn)) {
					pgCmd.Parameters.Add(new NpgsqlParameter("param1", id));
					bool[] r = (bool[]) pgCmd.ExecuteScalar();
					return (r[0] || r[1] || r[2]);
				}
			}
		}
	}
}
