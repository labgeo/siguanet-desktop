/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tom�s
 * Fecha: 15/05/2008
 * Hora: 9:14
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

using System;

namespace SIGUANETDesktop.Perfiles
{
	public enum ProfileType : long
	{
		Anonymous = 1000L,
		Interno = 2000L, //Empleados
		Departamento = 3000L, //Gestores de departamento o unidad
		Administrador = 4000L, //responsables de infraestructuras, gerencia, otros cargos
		Root = 0000L //administradores del sistema
	}
}
