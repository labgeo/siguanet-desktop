/*
 * Created by SharpDevelop.
 * User: Jose Tom�s
 * Date: 12/07/2006
 * Time: 9:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Espacios;

namespace SIGUANETDesktop.ModeloExplotacion.Usos
{
	/// <summary>
	/// Description of GrupoCRUE.
	/// </summary>
	public class GrupoCRUE
		:GrupoActividad
	{
		public override TipoGrupo Tipo
		{
			get
			{
				return TipoGrupo.CRUE;
			}
		}
		
		public override List<ActividadSIGUA> ObtenerActividades()
		{
			List<ActividadSIGUA> r = new List<ActividadSIGUA>();
			return r;
		}
		
		public override List<Zona> ObtenerZonas()
		{
			List<Zona> r = new List<Zona>();
			return r;
		}
		
		public override List<Edificio> ObtenerEdificios()
		{
			List<Edificio> r = new List<Edificio>();
			return r;
		}
		public override List<PlantaEdificio> ObtenerPlantas()
		{
			List<PlantaEdificio> r = new List<PlantaEdificio>();
			return r;
		}
		
		public override List<Estancia> ObtenerEstancias()
		{
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public GrupoCRUE(string denominacion)
			:base(denominacion)
		{
			
		}
		
	}
}
