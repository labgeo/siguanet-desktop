/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 04/07/2006
 * Time: 12:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.ModeloExplotacion.Usos;

namespace SIGUANETDesktop.ModeloExplotacion.Organizacion
{
	/// <summary>
	/// Description of DepartamentoSIGUA.
	/// </summary>
	public class DepartamentoSIGUA
	{
		private string _codigo = string.Empty;
		public string Codigo
		{
			get
			{
				return _codigo;
			}
		}
		
		private string _denominacion = string.Empty;
		public string Denominacion
		{
			get
			{
				return _denominacion;
			}
			set 
			{
				_denominacion = value;
			}
		}
		
		private bool _esCentro = false;
		public bool EsCentro
		{
			get
			{
				return _esCentro;
			}
			set
			{
				_esCentro = value;
			}
		}
		
		private bool _esUnidad = false;
		public bool EsUnidad
		{
			get
			{
				return _esUnidad;
			}
			set
			{
				_esUnidad = value;
			}
		}
		
		private bool _esDepartamento = false;
		public bool EsDepartamento
		{
			get
			{
				return _esDepartamento;
			}
			set
			{
				_esDepartamento = value;
			}
		}
		
		public DepartamentoSIGUA(string codigo)
		{
			_codigo = codigo;
		}
		
		public List<Zona> ObtenerZonas()
		{
			List<Zona> r = new List<Zona>();
			return r;
		}
		
		public List<Edificio> ObtenerEdificios()
		{
			List<Edificio> r = new List<Edificio>();
			return r;
		}

		public List<PlantaEdificio> ObtenerPlantas()
		{
			List<PlantaEdificio> r = new List<PlantaEdificio>();
			return r;
		}
		
		public List<Estancia> ObtenerEstancias()
		{
			List<Estancia> r = new List<Estancia>();
			return r;
		}		

		public List<Estancia> ObtenerEstancias(ActividadSIGUA uso)
		{
			List<Estancia> r = new List<Estancia>();
			return r;						
		}
		
		public List<Estancia> ObtenerEstancias(GrupoActividad grupo)
		{
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerDespachosNoOcupados()
		{
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public int NumEstancias()
		{
			return 0;
		}
		
		public int NumEstancias(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public int NumEstancias(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public int NumDespachosNoOcupados()
		{
			return 0;			
		}
		
		public double SuperficieEstancias()
		{
			return 0;			
		}
		
		public double SuperficieEstancias(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public double SuperficieEstancias(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public double SuperficieDespachosNoOcupados()
		{
			return 0;
		}
		
		public DataSet EstadisticaEstancias()
		{
			DataSet r = new DataSet();
			return r;
		}
		
		public DataSet EstadisticaEstancias(ActividadSIGUA uso)
		{
			DataSet r = new DataSet();
			return r;			
		}
		
		public DataSet EstadisticaEstancias(GrupoActividad grupo)
		{
			DataSet r = new DataSet();
			return r;			
		}
		
		public List<Persona> ObtenerPersonas()
		{
			List<Persona> r = new List<Persona>();
			return r;
		}
		
		public int NumPersonas()
		{
			return 0;			
		}
		
		public double CalcularDensidad()
		{
			return 0;			
		}
		
		public List<AsignacionCargo> ObtenerAsignacionesCargo()
		{
			List<AsignacionCargo> r = new List<AsignacionCargo>();
			return r;
		}		
	}
}
