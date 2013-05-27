/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 31/03/2006
 * Time: 9:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SIGUANETDesktop.ModeloDocumento
{	
	public enum estadoModelo
	{
		Ninguno,
		Nuevo,
		Pendiente,
		Actualizado
	}

	public enum tipoPuntoAcceso
	{
		Ninguno,
		ArbolEspacial,
		ArbolUEM,
		ArbolOrganizativo,
		ArbolActividades,
		ArbolGruposActividad,
		ArbolGruposActividadCRUE,
		ArbolGruposActividadU21,
		Campus,
		Edificios,
		Plantas,
		Estancias,
		Departamentos,
		Usos,
		Personas
	}
	
	public enum tipoComando
	{
		Ninguno,
		Seleccion,
		Aviso,
		VerAltas,
		VerBajas,
		DarAltas,
		DarBajas,
		Modificar,
		Editar
	}
}
