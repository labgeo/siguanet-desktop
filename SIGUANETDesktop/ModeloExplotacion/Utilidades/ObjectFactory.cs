/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 25/09/2006
 * Time: 9:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Data;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.ModeloExplotacion.Usos;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.Log;
using SharpMap.Geometries;

namespace SIGUANETDesktop.ModeloExplotacion.Utilidades
{
	/// <summary>
	/// Description of ObjectFactory.
	/// </summary>
	public static class ObjectFactory
	{

		public static List<Estancia> generarListaEstancias (DataSet ds)
		{
			if (ds.Tables[0].TableName == "Excepcion")
			{
				throw new ApplicationException((string) ds.Tables[0].Rows[0][0]);
			}
			else
			{
				List<Estancia> r = new List<Estancia>();
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					Estancia e = new Estancia((string) dr["codigo"]);
					try {
						e.Geometria = (MultiPolygon) SharpMap.Geometries.MultiPolygon.GeomFromText((string) dr["wkt"]);
					} catch (Exception ex) {
						new SIGUANETDesktopException (ExceptionCategory.DATAInvalidGeometry,
						                              "ObjectFactory.generarListaEstancias", ex, e.Codigo);
						continue;
					}
					
					Zona z = new Zona((string) dr["codzona"]) ;
					z.Denominacion = (string) dr["denozona"];
					Edificio ed = new Edificio(z, (string) dr["codedificio"]);
					ed.Denominacion = (string) dr["denoedificio"];
								                            
					PlantaEdificio pe = new PlantaEdificio(ed, (EnumPlantas) System.Enum.Parse(typeof(EnumPlantas), (string) dr["enumplanta"]));
					pe.Denominacion = (string) dr["denoplanta"];
					e.PlantaEdificio = pe;
					ActividadSIGUA a = new ActividadSIGUA((short) dr["actividad"]);
					a.Denominacion = (string) dr["denoActividad"];
					a.GrupoPropio = new GrupoPropio((string) dr["denogrupo"]);
					a.GrupoCRUE = new GrupoCRUE((string) dr["denocrue"]);
					a.GrupoUXXI = new GrupoUXXI((string) dr["denou21"]);
					DepartamentoSIGUA depsigua = new DepartamentoSIGUA((string) dr["coddpto"]);
					depsigua.Denominacion = (string) dr["denodpto"];
					depsigua.EsCentro = (bool) dr["es_centro"];
					depsigua.EsDepartamento = (bool) dr["es_dpto"];
					depsigua.EsUnidad = (bool) dr["es_unidad"];
					e.Actividad = a;
					e.Adscripcion = depsigua;
					if (dr["denoestancia"].GetType() == typeof(System.DBNull) )
					{
						e.Denominacion = string.Empty;					
					} else
					{
					   e.Denominacion = (string) dr["denoestancia"];
					}		
					
					r.Add(e);
				}
				return r;
			}
		}
		
		public static List<Ubicacion> generarListaUbicaciones (DataSet ds)
		{
			if (ds.Tables[0].TableName == "Excepcion")
			{
				throw new ApplicationException((string) ds.Tables[0].Rows[0][0]);
			}
			else
			{
				List<Ubicacion> r = new List<Ubicacion>();
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string apellido2 = string.Empty;
					if (!(dr["apellido2"] is System.DBNull)) apellido2 = (string) dr["apellido2"];
					Persona p = new Persona((string) dr["nif"], (string) dr["apellido1"], apellido2, (string) dr["nombre"],
					                        (bool) dr["espas"], (bool) dr["espdi"], (bool) dr["espdicargo"], (bool) dr["esbecario"], (bool) dr["esexterno"]);
					
					Estancia e = new Estancia ( (string) dr["codigo"]);
					e.Geometria = (MultiPolygon) SharpMap.Geometries.MultiPolygon.GeomFromText((string) dr["wkt"]);
					Zona z = new Zona( (string) dr["codzona"]) ;
					z.Denominacion = (string) dr["denozona"];
					Edificio ed = new Edificio(z, (string) dr["codedificio"]);
					ed.Denominacion = (string) dr["denoedificio"];
								                            
					PlantaEdificio pe = new PlantaEdificio(ed, (EnumPlantas) System.Enum.Parse(typeof(EnumPlantas), (string) dr["enumplanta"]));
					pe.Denominacion = (string) dr["denoplanta"];
					e.PlantaEdificio = pe;
					ActividadSIGUA a = new ActividadSIGUA((short) dr["actividad"]);
					a.Denominacion = (string) dr["denoActividad"];
					a.GrupoPropio = new GrupoPropio((string) dr["denogrupo"]);
					a.GrupoCRUE = new GrupoCRUE((string) dr["denocrue"]);
					a.GrupoUXXI = new GrupoUXXI((string) dr["denou21"]);
					DepartamentoSIGUA depsigua = new DepartamentoSIGUA((string) dr["coddpto"]);
					depsigua.Denominacion = (string) dr["denodpto"];
					depsigua.EsCentro = (bool) dr["es_centro"];
					depsigua.EsDepartamento = (bool) dr["es_dpto"];
					depsigua.EsUnidad = (bool) dr["es_unidad"];
					e.Actividad = a;
					e.Adscripcion = depsigua;
					if (dr["denoestancia"].GetType() == typeof(System.DBNull) )
					{
						e.Denominacion = string.Empty;					
					} else
					{
					   e.Denominacion = (string) dr["denoestancia"];
					}
					
					r.Add(new Ubicacion(p, e));
				}
				return r;
			}
		}
		
		public static List<Persona> generarListaPersonas (DataSet ds)
		{
			if (ds.Tables[0].TableName == "Excepcion")
			{
				throw new ApplicationException((string) ds.Tables[0].Rows[0][0]);
			}
			else
			{
				List<Persona> r = new List<Persona>();
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string apellido2 = string.Empty;
					if (!(dr["apellido2"] is System.DBNull)) apellido2 = (string) dr["apellido2"];
					Persona p = new Persona((string) dr["nif"], (string) dr["apellido1"], apellido2, (string) dr["nombre"],
					                        (bool) dr["espas"], (bool) dr["espdi"], (bool) dr["espdicargo"], (bool) dr["esbecario"], (bool) dr["esexterno"]);
					r.Add(p);
				}
				return r;
			}
		}
		
		public static List<DepartamentoSIGUA> generarListaDepartamentosSIGUA(DataSet ds)
		{
			if (ds.Tables[0].TableName == "Excepcion")
			{
				throw new ApplicationException((string) ds.Tables[0].Rows[0][0]);
			}
			else
			{
				List<DepartamentoSIGUA> r = new List<DepartamentoSIGUA>();
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					DepartamentoSIGUA depsigua = new DepartamentoSIGUA((string) dr["cod"]);
					depsigua.Denominacion = (string) dr["txt"];
					depsigua.EsCentro = (bool) dr["es_centro"];
					depsigua.EsDepartamento = (bool) dr["es_dpto"];
					depsigua.EsUnidad = (bool) dr["es_unidad"];
					r.Add(depsigua);
				}
				return r;
			}
		}
		
		public static List<ActividadSIGUA> generarListaActividadesSIGUA(DataSet ds)
		{
			if (ds.Tables[0].TableName == "Excepcion")
			{
				throw new ApplicationException((string) ds.Tables[0].Rows[0][0]);
			}
			else
			{
				List<ActividadSIGUA> r = new List<ActividadSIGUA>();
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					ActividadSIGUA actsigua = new ActividadSIGUA((short) dr["codactividad"]);
					actsigua.Denominacion = (string) dr["txt_actividad"];
					actsigua.GrupoPropio = new GrupoPropio((string) dr["activresum"]);
					actsigua.GrupoUXXI = new GrupoUXXI((string) dr["u21"]);
					actsigua.GrupoCRUE = new GrupoCRUE((string) dr["crue"]);
					r.Add(actsigua);
				}
				return r;
			}
		}
		
		public static List<GrupoActividad> generarListaGruposActividad(DataSet ds, TipoGrupo t)
		{
			if (ds.Tables[0].TableName == "Excepcion")
			{
				throw new ApplicationException((string) ds.Tables[0].Rows[0][0]);
			}
			else
			{
				List<GrupoActividad> r = new List<GrupoActividad>();
				GrupoActividad grupoact;
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					switch (t)
					{
					case TipoGrupo.ACTIVRESUM:
							grupoact = new GrupoPropio((string) dr[0]);
						r.Add(grupoact);
						break;
					case TipoGrupo.CRUE:
						grupoact = new GrupoCRUE((string) dr[0]);
						r.Add(grupoact);
						break;
					case TipoGrupo.U21:
						grupoact = new GrupoUXXI((string) dr[0]);
						r.Add(grupoact);
						break;
					}
				}
				return r;
			}
		}		
	}
}
