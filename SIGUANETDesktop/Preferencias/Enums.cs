/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 25/02/2008
 * Hora: 13:14
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace SIGUANETDesktop.Preferencias
{
	
	//Es obligatorio inicializar todos los enumerados
	//para evitar problemas en la (de)serialización de preferencias
	//derivados de la modificación (inserción o borrado)
	//de la lista de enumerados. Una vez inicializado, 
	//no se puede reinicializar un enumerado.
	[Serializable]
	public enum PrefsGlobal : long 
	{
		AppName = 100L,
		OrgName = 101L,
		OrgAcronym = 102L,
		AuthDownloadURL = 2000L,
		AuthUseLocal = 2001L,
		AuthUseRemote = 2002L,
		AuthDownloadUsingCredentials = 2003L,
		AuthDownloadWithLogin = 2004L,
		AuthDownloadWithPassword = 2005L,
		SGDDownloadURL = 1000L,
		SGDUseLocalCopy = 1001L,
		SGDUseLocal = 1002L,
		SGDUseRemote = 1003L,
		SGDDownloadUsingCredentials = 1004L,
		SGDDownloadWithLogin = 1005L,
		SGDDownloadWithPassword = 1006L,		
		RIJHashAlgorithm = 3000L,
		RIJInitVector = 3001L,
		RIJKeySize = 3002L,
		RIJPassPhrase = 3003L,
		RIJPasswordIterations = 3004L,
		RIJSaltValue = 3005L,
		SOAPDefaultWSDLLocation = 4000L,
		SOAPDefaultWSUILocation = 4001L,
		SOAPDefaultAnonymousUsrName = 4002L,
		SOAPDefaultAnonymousUsrPassword = 4003L
	}

	//Es obligatorio inicializar todos los enumerados
	//para evitar problemas en la (de)serialización de preferencias
	//derivados de la modificación (inserción o borrado)
	//de la lista de enumerados. Una vez inicializado, 
	//no se puede reinicializar un enumerado.	
	[Serializable]
	public enum PrefsBD :long 
	{
		PGSQLTargetSchemas = 1000L,
		PGSQLDefaultTableSchemaQuery = 1001L,
		PGSQLDefaultViewSchemaQuery = 1002L,
		PGSQLDefaultColumnSchemaQuery = 1003L,
		PGSQLCustomTableSchemaQuery = 1004L,
		PGSQLCustomViewSchemaQuery = 1005L,
		PGSQLCustomColumnSchemaQuery = 1006L,		
		ORATargetSchemas = 2000L,
		ORADefaultTableSchemaQuery = 2001L,
		ORADefaultViewSchemaQuery = 2002L,
		ORADefaultColumnSchemaQuery = 2003L,
		ORACustomTableSchemaQuery = 2004L,
		ORACustomViewSchemaQuery = 2005L,
		ORACustomColumnSchemaQuery = 2006L
	}
}
