/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/07/2006
 * Time: 9:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.ModeloExplotacion.Usos
{
	/// <summary>
	/// Description of GrupoActividad.
	/// </summary>
	public abstract class GrupoActividad
	{
		public abstract TipoGrupo Tipo {get;}
		
		private string _denominacion = string.Empty;
		public string Denominacion
		{
			get
			{
				return _denominacion;
			}
		}
		
		private string _denominacionAlt = string.Empty;
		public string DenominacionAlt
		{
			get
			{
				return _denominacionAlt;
			}
		}
		
		public abstract List<ActividadSIGUA> ObtenerActividades();
		public abstract List<Zona> ObtenerZonas();
		public abstract List<Edificio> ObtenerEdificios();
		public abstract List<PlantaEdificio> ObtenerPlantas();
		public abstract List<Estancia> ObtenerEstancias();
		
		public GrupoActividad(string denominacion)
		{
			_denominacion = denominacion;
			_denominacionAlt = this.ObtenerDenomAlt();
		}
		
		private string ObtenerDenomAlt()
		{
			string sSQL = "SELECT * FROM quest_grupoactividad_obtenerdenomalt(:param1)";
			object[] aParams = new object[] {this._denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(string))
			{
				return (string) r;
			}
			else
			{
				return string.Empty;
			}			
		}
	}
	
}
