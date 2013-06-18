/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 15/05/2008
 * Hora: 9:14
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
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
