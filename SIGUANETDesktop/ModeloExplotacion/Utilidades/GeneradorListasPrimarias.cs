/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 19/07/2006
 * Time: 8:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Collections.Generic;
using Npgsql;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Usos;

namespace SIGUANETDesktop.ModeloExplotacion.Utilidades
{
	/// <summary>
	/// Description of GeneradorListasPrimarias.
	/// </summary>
	public static class GeneradorListasPrimarias
	{
	
		public static List<Centro> ObtenerCentros()
		{
			List<Centro> r = new List<Centro>();
			return r;
		}

		public static List<Unidad> ObtenerUnidades()
		{
			List<Unidad> r = new List<Unidad>();
			return r;
		}
		
		public static List<Departamento> ObtenerDepartamentos()
		{
			List<Departamento> r = new List<Departamento>();
			return r;
		}
		
		public static List<ActividadSIGUA> ObtenerActividades()
		{
			List<ActividadSIGUA> r = new List<ActividadSIGUA>();
			return r;
		}
		
		public static List<GrupoPropio> ObtenerGruposPropios()
		{
			List<GrupoPropio> r = new List<GrupoPropio>();
			return r;
		}
		
		public static List<GrupoCRUE> ObtenerGruposCRUE()
		{
			List<GrupoCRUE> r = new List<GrupoCRUE>();
			return r;
		}
		
		public static List<GrupoUXXI> ObtenerGruposUXXI()
		{
			List<GrupoUXXI> r = new List<GrupoUXXI>();
			return r;
		}
	}
}
