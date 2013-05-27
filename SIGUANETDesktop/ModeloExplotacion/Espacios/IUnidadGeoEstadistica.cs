/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/07/2006
 * Time: 8:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.ModeloExplotacion.Usos;

namespace SIGUANETDesktop.ModeloExplotacion.Espacios
{
	/// <summary>
	/// Description of IUnidadGeoEstadistica.
	/// </summary>
	public interface IUnidadGeoEstadistica
	{
		List<Estancia> ObtenerEstancias(out DataSet ds, ActividadSIGUA uso);
		List<Estancia> ObtenerEstancias(out DataSet ds, GrupoActividad grupo);
		List<Estancia> ObtenerEstancias(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerEstancias(ActividadSIGUA uso, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerEstancias(GrupoActividad grupo, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerEstanciasUtiles(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerEstanciasDocentes(out DataSet ds);
		List<Estancia> ObtenerEstanciasDocentes(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds);
		List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, ActividadSIGUA uso);
		List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, GrupoActividad grupo);
		List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds);
		List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, ActividadSIGUA uso);
		List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, GrupoActividad grupo);
		List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds);
		List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerDespachosOcupados(out DataSet ds);
		List<Estancia> ObtenerDespachosOcupados(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds);
		List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Estancia> ObtenerAdmonOcupados(out DataSet ds);
		List<Estancia> ObtenerAdmonOcupados(out DataSet ds, DepartamentoSIGUA adscripcion);
		long NumEstancias();
		long NumEstancias(ActividadSIGUA uso);
		long NumEstancias(GrupoActividad grupo);
		long NumEstancias(DepartamentoSIGUA adscripcion);
		long NumEstancias(ActividadSIGUA uso, DepartamentoSIGUA adscripcion);
		long NumEstancias(GrupoActividad grupo, DepartamentoSIGUA adscripcion);
		long NumEstanciasUtiles();
		long NumEstanciasUtiles(DepartamentoSIGUA adscripcion);
		long NumEstanciasDocentes();
		long NumEstanciasDocentes(DepartamentoSIGUA adscripcion);
		long NumEstanciasOcupadas();
		long NumEstanciasOcupadas(DepartamentoSIGUA adscripcion);
		long NumEstanciasOcupadas(ActividadSIGUA uso);
		long NumEstanciasOcupadas(GrupoActividad grupo);
		long NumEstanciasNoOcupadas();
		long NumEstanciasNoOcupadas(DepartamentoSIGUA adscripcion);
		long NumEstanciasNoOcupadas(ActividadSIGUA uso);
		long NumEstanciasNoOcupadas(GrupoActividad grupo);
		long NumDespachosNoOcupados();
		long NumDespachosNoOcupados(DepartamentoSIGUA adscripcion);
		long NumDespachosOcupados();
		long NumDespachosOcupados(DepartamentoSIGUA adscripcion);
		long NumAdmonNoOcupados();
		long NumAdmonNoOcupados(DepartamentoSIGUA adscripcion);
		long NumAdmonOcupados();
		long NumAdmonOcupados(DepartamentoSIGUA adscripcion);
		double SuperficieEstancias();
		double SuperficieEstancias(ActividadSIGUA uso);
		double SuperficieEstancias(GrupoActividad grupo);
		double SuperficieEstancias(DepartamentoSIGUA adscripcion);
		double SuperficieEstancias(ActividadSIGUA uso, DepartamentoSIGUA adscripcion);
		double SuperficieEstancias(GrupoActividad grupo, DepartamentoSIGUA adscripcion);
		double SuperficieEstanciasUtiles();
		double SuperficieEstanciasUtiles(DepartamentoSIGUA adscripcion);
		double SuperficieEstanciasDocentes();
		double SuperficieEstanciasDocentes(DepartamentoSIGUA adscripcion);
		double SuperficieEstanciasOcupadas();
		double SuperficieEstanciasOcupadas(DepartamentoSIGUA adscripcion);
		double SuperficieEstanciasOcupadas(ActividadSIGUA uso);
		double SuperficieEstanciasOcupadas(GrupoActividad grupo);
		double SuperficieEstanciasNoOcupadas();
		double SuperficieEstanciasNoOcupadas(DepartamentoSIGUA adscripcion);
		double SuperficieEstanciasNoOcupadas(ActividadSIGUA uso);
		double SuperficieEstanciasNoOcupadas(GrupoActividad grupo);
		double SuperficieDespachosNoOcupados();
		double SuperficieDespachosNoOcupados(DepartamentoSIGUA adscripcion);
		double SuperficieDespachosOcupados();
		double SuperficieDespachosOcupados(DepartamentoSIGUA adscripcion);
		double SuperficieAdmonNoOcupados();
		double SuperficieAdmonNoOcupados(DepartamentoSIGUA adscripcion);
		double SuperficieAdmonOcupados();
		double SuperficieAdmonOcupados(DepartamentoSIGUA adscripcion);
		DataSet EstadisticaEstancias();
		DataSet EstadisticaEstancias(ActividadSIGUA uso);
		DataSet EstadisticaEstancias(GrupoActividad grupo);
		DataSet EstadisticaEstancias(DepartamentoSIGUA adscripcion);
		DataSet EstadisticaEstancias(ActividadSIGUA uso, DepartamentoSIGUA adscripcion);
		DataSet EstadisticaEstancias(GrupoActividad grupo, DepartamentoSIGUA adscripcion);
		List<DepartamentoSIGUA> ObtenerDepartamentosSIGUA();
		List<Persona> ObtenerPersonas();
		List<Persona> ObtenerPersonas(DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicaciones(out DataSet ds);
		List<Ubicacion> ObtenerUbicaciones(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicaciones(out DataSet ds, ActividadSIGUA uso);
		List<Ubicacion> ObtenerUbicaciones(out DataSet ds, GrupoActividad grupo);
		long NumPersonas();
		long NumPersonas(DepartamentoSIGUA adscripcion);
		long NumPersonas(ActividadSIGUA uso);
		long NumPersonas(GrupoActividad grupo);
		double CalcularDensidad();
		double CalcularDensidad(DepartamentoSIGUA adscripcion);
		double CalcularDensidad(ActividadSIGUA uso);
		double CalcularDensidad(GrupoActividad grupo);
		List<PAS> ObtenerPAS();
		List<PAS> ObtenerPAS(DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds);
		List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, ActividadSIGUA uso);
		List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds,  GrupoActividad grupo);
		long NumPAS();
		long NumPAS(DepartamentoSIGUA adscripcion);
		long NumPAS(ActividadSIGUA uso);
		long NumPAS(GrupoActividad grupo);
		double CalcularDensidadPAS();
		double CalcularDensidadPAS(DepartamentoSIGUA adscripcion);
		double CalcularDensidadPAS(ActividadSIGUA uso);
		double CalcularDensidadPAS(GrupoActividad grupo);
		List<PDI> ObtenerPDI();
		List<PDI> ObtenerPDI(DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds);
		List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, ActividadSIGUA uso);
		List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, GrupoActividad grupo);
		long NumPDI();
		long NumPDI(DepartamentoSIGUA adscripcion);
		long NumPDI(ActividadSIGUA uso);
		long NumPDI(GrupoActividad grupo);
		double CalcularDensidadPDI();
		double CalcularDensidadPDI(DepartamentoSIGUA adscripcion);
		double CalcularDensidadPDI(ActividadSIGUA uso);
		double CalcularDensidadPDI(GrupoActividad grupo);
		List<Ubicacion> ObtenerUbicacionesPDICargos(out DataSet ds);
		List<Ubicacion> ObtenerUbicacionesPDICargos(out DataSet ds, DepartamentoSIGUA adscripcion);
		long NumPDICargos();
		long NumPDICargos(DepartamentoSIGUA adscripcion);
		List<Becario> ObtenerBecarios();
		List<Becario> ObtenerBecarios(DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds);
		List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, ActividadSIGUA uso);
		List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, GrupoActividad grupo);
		long NumBecarios();
		long NumBecarios(DepartamentoSIGUA adscripcion);
		long NumBecarios(ActividadSIGUA uso);
		long NumBecarios(GrupoActividad grupo);
		double CalcularDensidadBecarios();
		double CalcularDensidadBecarios(DepartamentoSIGUA adscripcion);
		double CalcularDensidadBecarios(ActividadSIGUA uso);
		double CalcularDensidadBecarios(GrupoActividad grupo);
		List<Externo> ObtenerExternos();
		List<Externo> ObtenerExternos(DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds);
		List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, DepartamentoSIGUA adscripcion);
		List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, ActividadSIGUA uso);
		List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, GrupoActividad grupo);
		long NumExternos();
		long NumExternos(DepartamentoSIGUA adscripcion);
		long NumExternos(ActividadSIGUA uso);
		long NumExternos(GrupoActividad grupo);
		double CalcularDensidadExternos();
		double CalcularDensidadExternos(DepartamentoSIGUA adscripcion);
		double CalcularDensidadExternos(ActividadSIGUA uso);
		double CalcularDensidadExternos(GrupoActividad grupo);
		DataSet EstadisticaPersonal();
		DataSet EstadisticaPersonal(DepartamentoSIGUA adscripcion);
	}
}
