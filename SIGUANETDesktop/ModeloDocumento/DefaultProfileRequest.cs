/*
 * Creado por SharpDevelop.
 * Usuario: josetomas
 * Fecha: 04/03/2013
 * Hora: 14:58
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
	/// Description of DefaultProfileRequest.
	/// </summary>
	public class DefaultProfileRequest : IProfileRequest
	{
		public DefaultProfileRequest ()
		{
		}
		
		public IProfileResponse GetResponse(IAuthResponse authResponse)
		{
			if (authResponse == null) {
				return new DefaultProfileResponse (string.Empty, string.Empty, "MISSING_AUTHENTICATION", new ArgumentNullException ());
			}
			else if (!authResponse.IsValid) {
				return new DefaultProfileResponse (string.Empty, string.Empty, "INVALID_AUTHENTICATION", new ArgumentException ());
			}
			else if (string.IsNullOrEmpty (authResponse.GetUserId ().Trim ())) {
				return new DefaultProfileResponse (string.Empty, string.Empty, "INVALID_IDENTIFIER", new ArgumentException ());
			}
			else {
				string id = authResponse.GetUserId ();
				try {	
					return new DefaultProfileResponse (id, GetProfile (id), "OK");
				}
				catch (Exception e) {
					new SIGUANETDesktopException (ExceptionCategory.LOADERAuthenticationAborted, "DefaultProfileRequest.GetResponse", e);
					return new DefaultProfileResponse (id, string.Empty, "UNRESOLVED_PROFILE", e);
				}
			}
		}
		
		string GetProfile (string id)
		{
			string sCn = DBUtils.GetPGSQLCnString();
			string sSQL = "SELECT COALESCE(perfil, 'INTERNO') FROM personal WHERE upper(nif) = :param1;";
			using (NpgsqlConnection pgCn = new NpgsqlConnection(sCn)) {
				pgCn.Open();
				using (NpgsqlCommand pgCmd = new NpgsqlCommand(sSQL, pgCn)) {
					pgCmd.Parameters.Add(new NpgsqlParameter("param1", id));
					string r = (pgCmd.ExecuteScalar() as string).ToUpper ();
					return r;
				}
			}
		}
	}
}
