/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/07/2006
 * Time: 9:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Utilidades;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.ModeloExplotacion.Usos;

namespace SIGUANETDesktop.ModeloExplotacion.Espacios
{
	/// <summary>
	/// Description of PlantaUEM.
	/// </summary>
	public class PlantaUEM
		:IUnidadGeoEstadistica
	{
		
		private UEM _uem = null;
		public UEM UEM
		{
			get
			{
				return _uem;
			}
			set
			{
				_uem = value;
			}
		}
		
		private EnumPlantas _planta = EnumPlantas.PB;
		public EnumPlantas Planta
		{
			get
			{
				return _planta;
			}
			set
			{
				_planta = value;
			}
		}
		
		public PlantaUEM(UEM uem, EnumPlantas planta)
		{
			_uem = uem;
			_planta = planta;
		}

		public List<PlantaEdificio> ObtenerPlantasEdificio()
		{
			return null;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, ActividadSIGUA uso)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, GrupoActividad grupo)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(ActividadSIGUA uso, DepartamentoSIGUA adscripcion)
		{
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerEstancias(GrupoActividad grupo, DepartamentoSIGUA adscripcion)
		{
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasUtiles(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}		
		
		public List<Estancia> ObtenerEstanciasDocentes(out DataSet ds)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasDocentes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}		
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}		
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, ActividadSIGUA uso)
		{
			ds = new DataSet();			
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, GrupoActividad grupo)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}		
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, ActividadSIGUA uso)
		{
			ds = new DataSet();			
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, GrupoActividad grupo)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<Estancia> ObtenerDespachosOcupados(out DataSet ds)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<Estancia> ObtenerDespachosOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerAdmonOcupados(out DataSet ds)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerAdmonOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}
		
		public List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Estancia> r = new List<Estancia>();
			return r;			
		}		
		
		public long NumEstancias()
		{
			return 0;
		}
		
		public long NumEstancias(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public long NumEstancias(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public long NumEstancias(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumEstancias(ActividadSIGUA uso, DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumEstancias(GrupoActividad grupo, DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumEstanciasUtiles()
		{
			return 0;			
		}
		
		public long NumEstanciasUtiles(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumEstanciasDocentes()
		{
			return 0;			
		}
		
		public long NumEstanciasDocentes(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumEstanciasOcupadas()
		{
			return 0;			
		}
		
		public long NumEstanciasOcupadas(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumEstanciasOcupadas(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public long NumEstanciasOcupadas(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public long NumEstanciasNoOcupadas()
		{
			return 0;			
		}
		
		public long NumEstanciasNoOcupadas(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumEstanciasNoOcupadas(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public long NumEstanciasNoOcupadas(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public long NumDespachosOcupados()
		{
			return 0;			
		}		
		
		public long NumDespachosOcupados(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}		
		
		public long NumDespachosNoOcupados()
		{
			return 0;			
		}
		
		public long NumDespachosNoOcupados(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumAdmonOcupados()
		{
			return 0;			
		}		
		
		public long NumAdmonOcupados(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}		
		
		public long NumAdmonNoOcupados()
		{
			return 0;			
		}
		
		public long NumAdmonNoOcupados(DepartamentoSIGUA adscripcion)
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
		
		public double SuperficieEstancias(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double SuperficieEstancias(ActividadSIGUA uso, DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double SuperficieEstancias(GrupoActividad grupo, DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double SuperficieEstanciasUtiles()
		{
			return 0;			
		}
		
		public double SuperficieEstanciasUtiles(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double SuperficieEstanciasDocentes()
		{
			return 0;			
		}
		
		public double SuperficieEstanciasDocentes(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double SuperficieEstanciasOcupadas()
		{
			return 0;			
		}
		
		public double SuperficieEstanciasOcupadas(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}		
		
		public double SuperficieEstanciasOcupadas(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public double SuperficieEstanciasOcupadas(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public double SuperficieEstanciasNoOcupadas()
		{
			return 0;			
		}
		
		public double SuperficieEstanciasNoOcupadas(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}		
		
		public double SuperficieEstanciasNoOcupadas(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public double SuperficieEstanciasNoOcupadas(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public double SuperficieDespachosOcupados()
		{
			return 0;
		}
		
		public double SuperficieDespachosOcupados(DepartamentoSIGUA adscripcion)
		{
			return 0;
		}		
		
		public double SuperficieDespachosNoOcupados()
		{
			return 0;
		}
		
		public double SuperficieDespachosNoOcupados(DepartamentoSIGUA adscripcion)
		{
			return 0;
		}
		
		public double SuperficieAdmonOcupados()
		{
			return 0;
		}
		
		public double SuperficieAdmonOcupados(DepartamentoSIGUA adscripcion)
		{
			return 0;
		}		
		
		public double SuperficieAdmonNoOcupados()
		{
			return 0;
		}
		
		public double SuperficieAdmonNoOcupados(DepartamentoSIGUA adscripcion)
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
		
		public DataSet EstadisticaEstancias(DepartamentoSIGUA adscripcion)
		{
			DataSet r = new DataSet();
			return r;			
		}		
		
		public DataSet EstadisticaEstancias(ActividadSIGUA uso, DepartamentoSIGUA adscripcion)
		{
			DataSet r = new DataSet();
			return r;			
		}		

		public DataSet EstadisticaEstancias(GrupoActividad grupo, DepartamentoSIGUA adscripcion)
		{
			DataSet r = new DataSet();
			return r;			
		}
		
		public List<DepartamentoSIGUA> ObtenerDepartamentosSIGUA()
		{
			List<DepartamentoSIGUA> r = new List<DepartamentoSIGUA>();
			return r;
		}
		
		public List<Persona> ObtenerPersonas()
		{
			List<Persona> r = new List<Persona>();
			return r;
		}
		
		public List<Persona> ObtenerPersonas(DepartamentoSIGUA adscripcion)
		{
			List<Persona> r = new List<Persona>();
			return r;			
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, ActividadSIGUA uso)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, GrupoActividad grupo)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}		
		
		public long NumPersonas()
		{
			return 0;			
		}
		
		public long NumPersonas(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumPersonas(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public long NumPersonas(GrupoActividad grupo)
		{
			return 0;			
		}		
		
		public double CalcularDensidad()
		{
			return 0;			
		}
		
		public double CalcularDensidad(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double CalcularDensidad(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public double CalcularDensidad(GrupoActividad grupo)
		{
			return 0;			
		}		
		
		public List<PAS> ObtenerPAS()
		{
			List<PAS> r = new List<PAS>();
			return r;
		}
		
		public List<PAS> ObtenerPAS(DepartamentoSIGUA adscripcion)
		{
			List<PAS> r = new List<PAS>();
			return r;			
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, ActividadSIGUA uso)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, GrupoActividad grupo)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public long NumPAS()
		{
			return 0;			
		}
		
		public long NumPAS(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumPAS(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public long NumPAS(GrupoActividad grupo)
		{
			return 0;			
		}		
		
		public double CalcularDensidadPAS()
		{
			return 0;			
		}
		
		public double CalcularDensidadPAS(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double CalcularDensidadPAS(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public double CalcularDensidadPAS(GrupoActividad grupo)
		{
			return 0;			
		}		
		
		public List<PDI> ObtenerPDI()
		{
			List<PDI> r = new List<PDI>();
			return r;
		}
		
		public List<PDI> ObtenerPDI(DepartamentoSIGUA adscripcion)
		{
			List<PDI> r = new List<PDI>();
			return r;			
		}
		
		public List<Ubicacion> ObtenerPDI(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, ActividadSIGUA uso)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, GrupoActividad grupo)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}		
		
		public long NumPDI()
		{
			return 0;			
		}
		
		public long NumPDI(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumPDI(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public long NumPDI(GrupoActividad grupo)
		{
			return 0;			
		}		
		
		public double CalcularDensidadPDI()
		{
			return 0;			
		}
		
		public double CalcularDensidadPDI(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double CalcularDensidadPDI(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public double CalcularDensidadPDI(GrupoActividad grupo)
		{
			return 0;			
		}		
		
		public List<Ubicacion> ObtenerUbicacionesPDICargos(out DataSet ds)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDICargos(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public long NumPDICargos()
		{
			return 0;			
		}
		
		public long NumPDICargos(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}		
		
		public List<Becario> ObtenerBecarios()
		{
			List<Becario> r = new List<Becario>();
			return r;
		}
		
		public List<Becario> ObtenerBecarios(DepartamentoSIGUA adscripcion)
		{
			List<Becario> r = new List<Becario>();
			return r;			
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, ActividadSIGUA uso)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, GrupoActividad grupo)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public long NumBecarios()
		{
			return 0;			
		}
		
		public long NumBecarios(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumBecarios(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public long NumBecarios(GrupoActividad grupo)
		{
			return 0;			
		}		
		
		public double CalcularDensidadBecarios()
		{
			return 0;			
		}
		
		public double CalcularDensidadBecarios(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double CalcularDensidadBecarios(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public double CalcularDensidadBecarios(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public List<Externo> ObtenerExternos()
		{
			List<Externo> r = new List<Externo>();
			return r;			
		}
		
		public List<Externo> ObtenerExternos(DepartamentoSIGUA adscripcion)
		{
			List<Externo> r = new List<Externo>();
			return r;			
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, ActividadSIGUA uso)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, GrupoActividad grupo)
		{
			ds = new DataSet();
			List<Ubicacion> r = new List<Ubicacion>();
			return r;
		}
		
		public long NumExternos()
		{
			return 0;			
		}
		
		public long NumExternos(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public long NumExternos(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public long NumExternos(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public double CalcularDensidadExternos()
		{
			return 0;			
		}
		
		public double CalcularDensidadExternos(DepartamentoSIGUA adscripcion)
		{
			return 0;			
		}
		
		public double CalcularDensidadExternos(ActividadSIGUA uso)
		{
			return 0;			
		}
		
		public double CalcularDensidadExternos(GrupoActividad grupo)
		{
			return 0;			
		}
		
		public DataSet EstadisticaPersonal()
		{
			DataSet r = new DataSet();
			return r;			
		}
		
		public DataSet EstadisticaPersonal(DepartamentoSIGUA adscripcion)
		{
			DataSet r = new DataSet();
			return r;			
		}		
	}
}
