/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 23/04/2008
 * Hora: 13:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;

namespace SIGUANETDesktop.Log
{
	/// <summary>
	/// Description of enums.
	/// </summary>
	public enum ExceptionCategory : long
	{
		LOADERAuthenticationFailed = -99999L,
		LOADERImpersonationFailed = -99998L,
		LOADERAuthenticationAborted = -99997L,
		LOADERServerDateParsingFailed = -99996L,
		LOADERIdentificationAborted = -99995L,
		SGDURLInvalid = 00000L,
		SGDLocalPathNotFound = 00001L,
		SGDRemotePathNotFound = 00002L,
		SGDLocalCopyFailed = 00003L,
		SGDDeserializationFailed = 00004L,
		SGDURLEmpty = 00005L,
		SGDHasExpired = 00006L,
		SRSURLInvalid = 00100L,
		SRSLocalPathNotFound = 00101L,
		SRSRemotePathNotFound = 00102L,
		SRSLocalCopyFailed = 00103L,
		SRSDeserializationFailed = 00104L,
		SRSURLEmpty = 00105L,
		DATAInvalidGeometry = 00200L
	}
}
