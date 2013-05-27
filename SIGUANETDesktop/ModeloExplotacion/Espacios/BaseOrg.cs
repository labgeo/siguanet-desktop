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
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloExplotacion.Utilidades;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.ModeloExplotacion.Usos;
using SharpMap;
using SharpMap.Geometries;


namespace SIGUANETDesktop.ModeloExplotacion.Espacios
{
	/// <summary>
	/// Description of BaseOrg.
	/// </summary>
	public class BaseOrg
		:IUnidadGeoEstadistica
	{

		public BaseOrg()
		{
			
		}
		
		public string NextCodZona()
		{
			string r = string.Empty;
			return r;
		}
		
		public List<Zona> ObtenerZonas()
		{
			List<Zona> r = new List<Zona>();
			string sSQL = "SELECT * FROM quest_baseorg_obtenerzonas()";
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string cod = (string) dr["cod_zona"];
					Zona z = new Zona(cod);
					z.Denominacion = (string) dr["txt_zona"];
					r.Add(z);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<Zona> ObtenerZonas(DepartamentoSIGUA d)
		{
			List<Zona> r = new List<Zona>();
			string sSQL = "SELECT * FROM quest_baseorg_obtenerzonas(:param1)";
			object[] aParametros = {d.Codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string cod = (string) dr["cod_zona"];
					Zona z = new Zona(cod);
					z.Denominacion = (string) dr["txt_zona"];
					r.Add(z);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<Zona> ObtenerZonas(ActividadSIGUA a)
		{
			List<Zona> r = new List<Zona>();
			string sSQL = "SELECT * FROM quest_baseorg_obtenerzonas(:param1)";
			object[] aParametros = {a.Codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string cod = (string) dr["cod_zona"];
					Zona z = new Zona(cod);
					z.Denominacion = (string) dr["txt_zona"];
					r.Add(z);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<Zona> ObtenerZonas(GrupoActividad g)
		{
			List<Zona> r = new List<Zona>();
			string sSQL = "SELECT * FROM quest_baseorg_obtenerzonas(:param1, :param2)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), g.Tipo).ToLower(), g.Denominacion};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string cod = (string) dr["cod_zona"];
					Zona z = new Zona(cod);
					z.Denominacion = (string) dr["txt_zona"];
					r.Add(z);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<PlantaBase> ObtenerPlantas()
		{
			List<PlantaBase> r = new List<PlantaBase>();
			string sSQL = "SELECT quest_baseorg_obtenerplantas() AS planta";
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string codPlanta = (string) dr["planta"];
					PlantaBase p = new PlantaBase((EnumPlantas) Enum.Parse(typeof(EnumPlantas), codPlanta, true));
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<PlantaBase> ObtenerPlantas(DepartamentoSIGUA d)
		{
			List<PlantaBase> r = new List<PlantaBase>();
			string sSQL = "SELECT quest_baseorg_obtenerplantas(:param1) AS planta";
			object[] aParametros = {d.Codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string codPlanta = (string) dr["planta"];
					PlantaBase p = new PlantaBase((EnumPlantas) Enum.Parse(typeof(EnumPlantas), codPlanta, true));
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<PlantaBase> ObtenerPlantas(ActividadSIGUA a)
		{
			List<PlantaBase> r = new List<PlantaBase>();
			string sSQL = "SELECT quest_baseorg_obtenerplantas(:param1) AS planta";
			object[] aParametros = {a.Codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string codPlanta = (string) dr["planta"];
					PlantaBase p = new PlantaBase((EnumPlantas) Enum.Parse(typeof(EnumPlantas), codPlanta, true));
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<PlantaBase> ObtenerPlantas(GrupoActividad g)
		{
			List<PlantaBase> r = new List<PlantaBase>();
			string sSQL = "SELECT * FROM quest_baseorg_obtenerplantas(:param1, :param2) AS t(planta)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), g.Tipo).ToLower(), g.Denominacion};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string codPlanta = (string) dr["planta"];
					PlantaBase p = new PlantaBase((EnumPlantas) Enum.Parse(typeof(EnumPlantas), codPlanta, true));
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<PlantaEdificio> ObtenerPlantasEdificio()
		{
			List<PlantaEdificio> r = new List<PlantaEdificio>();
			string sSQL = "SELECT * FROM quest_baseorg_obtenerplantasedificio()";
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					Zona z = new Zona((string) dr["zona"]);
					z.Denominacion = (string) dr["denominacion_zona"];
					Edificio e = new Edificio(z, (string) dr["edificio"], (int[]) dr["checklist_plantas"]);
					e.Denominacion = (string) dr["denominacion_edificio"];
					PlantaEdificio p = new PlantaEdificio(e, (EnumPlantas) System.Enum.Parse(typeof(EnumPlantas), (string) dr["planta"], true));
					p.Denominacion = (string) dr["denominacion_planta"];
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestancias(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestancias(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestancias(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
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
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasutiles(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasDocentes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasdocentes()";
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasDocentes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasdocentes(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}		
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasocupadas()";
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasocupadas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasocupadas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasocupadas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasnoocupadas()";
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasnoocupadas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasnoocupadas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerestanciasnoocupadas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerDespachosOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerdespachosocupados()";
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerDespachosOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerdespachosocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerdespachosnoocupados()";
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenerdespachosnoocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerAdmonOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obteneradmonocupados()";
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public List<Estancia> ObtenerAdmonOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obteneradmonocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obteneradmonnoocupados()";
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obteneradmonnoocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public long NumEstancias()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestancias()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstancias(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestancias(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstancias(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestancias(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstancias(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestancias(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
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
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasutiles()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasUtiles(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasutiles(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasDocentes()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasdocentes()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasDocentes(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasdocentes(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasOcupadas()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasocupadas()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasOcupadas(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasocupadas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasOcupadas(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasocupadas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasOcupadas(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasocupadas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasNoOcupadas()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasnoocupadas()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasNoOcupadas(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasnoocupadas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long NumEstanciasNoOcupadas(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasnoocupadas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumEstanciasNoOcupadas(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numestanciasnoocupadas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long NumDespachosOcupados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numdespachosocupados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumDespachosOcupados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numdespachosocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumDespachosNoOcupados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numdespachosnoocupados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumDespachosNoOcupados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numdespachosnoocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumAdmonOcupados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numadmonocupados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumAdmonOcupados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numadmonocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumAdmonNoOcupados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numadmonnoocupados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumAdmonNoOcupados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numadmonnoocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public double SuperficieEstancias()
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficie()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstancias(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficie(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstancias(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficie(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				string ex = (string)(r as DataSet).Tables[0].Rows[0][0];				
				return 0;
			}
		}
		
		public double SuperficieEstancias(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficie(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
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
			string sSQL = "SELECT * FROM quest_baseorg_superficieutil()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasUtiles(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieutil(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasDocentes()
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficiedocente()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasDocentes(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficiedocente(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public double SuperficieEstanciasOcupadas()
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieestanciasocupadas()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasOcupadas(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieestanciasocupadas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasOcupadas(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieestanciasocupadas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasOcupadas(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieestanciasocupadas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasNoOcupadas()
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieestanciasnoocupadas()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasNoOcupadas(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieestanciasnoocupadas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasNoOcupadas(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieestanciasnoocupadas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstanciasNoOcupadas(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieestanciasnoocupadas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieDespachosOcupados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficiedespachosocupados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieDespachosOcupados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficiedespachosocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieDespachosNoOcupados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficiedespachosnoocupados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieDespachosNoOcupados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficiedespachosnoocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieAdmonOcupados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieadmonocupados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieAdmonOcupados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieadmonocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public double SuperficieAdmonNoOcupados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieadmonnoocupados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieAdmonNoOcupados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_superficieadmonnoocupados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
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
			string sSQL = "SELECT * FROM quest_baseorg_obtenerdepartamentossigua()";
			List<DepartamentoSIGUA> r = new List<DepartamentoSIGUA>();
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaDepartamentosSIGUA(ds);
			}
			return r;
		}
		
		public List<ActividadSIGUA> ObtenerActividadesSIGUA()
		{
			string sSQL = "SELECT * FROM quest_baseorg_obteneractividadessigua()";
			List<ActividadSIGUA> r = new List<ActividadSIGUA>();
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaActividadesSIGUA(ds);
			}
			return r;
		}		
		
		public List<GrupoActividad> ObtenerGruposActividad(TipoGrupo t)
		{
			string sSQL = "SELECT * FROM quest_baseorg_obtenergruposactividad(:param1)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), t).ToLower()};
			List<GrupoActividad> r = new List<GrupoActividad>();
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaGruposActividad(ds, t);
			}
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
			string sSQL = "SELECT * FROM quest_baseorg_ubicaciones()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicaciones(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicaciones(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicaciones(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}		
		
		public List<Ubicacion> ObtenerUbicacionesPendientes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespendientes()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPendientes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespendientes(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public long NumPersonas()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpersonas()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPersonas(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpersonas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPersonas(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpersonas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPersonas(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpersonas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long NumPersonasNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpersonasnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPersonasNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpersonasnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long PorcentajePersonasNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajepersonasnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long PorcentajePersonasNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajepersonasnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public double CalcularDensidad()
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidad()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidad(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidad(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidad(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidad(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidad(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidad(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
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
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespas()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}		
		
		public List<Ubicacion> ObtenerUbicacionesPASPendientes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespaspendientes()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPASPendientes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespaspendientes(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public long NumPAS()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpas()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPAS(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPAS(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPAS(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long NumPASNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpasnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPASNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpasnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}	
		
		public long PorcentajePASNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajepasnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long PorcentajePASNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajepasnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadPAS()
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadpas()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadPAS(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadpas(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadPAS(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadpas(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadPAS(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadpas(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
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
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespdi()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespdi(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespdi(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespdi(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}		
		
		public List<Ubicacion> ObtenerUbicacionesPDIPendientes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespdipendientes()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDIPendientes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionespdipendientes(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public long NumPDI()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdi()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPDI(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdi(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPDI(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdi(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPDI(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdi(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPDINoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdinoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPDINoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdinoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}

		public long PorcentajePDINoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajepdinoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long PorcentajePDINoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajepdinoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadPDI()
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadpdi()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadPDI(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadpdi(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadPDI(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadpdi(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadPDI(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadpdi(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public List<Ubicacion> ObtenerUbicacionesPDICargos(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionescargos()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDICargos(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionescargos(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDICargosPendientes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionescargospendientes()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDICargosPendientes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionescargospendientes(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
				
		public long NumPDICargos()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdicargos()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPDICargos(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdicargos(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long NumPDICargosNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdicargosnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumPDICargosNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numpdicargosnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long PorcentajePDICargosNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajepdicargosnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long PorcentajePDICargosNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajepdicargosnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
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
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesbecarios()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesbecarios(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesbecarios(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesbecarios(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecariosPendientes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesbecariospendientes()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecariosPendientes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesbecariospendientes(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public long NumBecarios()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numbecarios()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumBecarios(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numbecarios(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumBecarios(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numbecarios(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumBecarios(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numbecarios(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long NumBecariosNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numbecariosnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumBecariosNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numbecariosnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long PorcentajeBecariosNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajebecariosnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long PorcentajeBecariosNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajebecariosnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadBecarios()
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadbecarios()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}		}
		
		public double CalcularDensidadBecarios(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadbecarios(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadBecarios(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadbecarios(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadBecarios(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadbecarios(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
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
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesexternos()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesexternos(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesexternos(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesexternos(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}		
		
		public List<Ubicacion> ObtenerUbicacionesExternosPendientes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesexternospendientes()";
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, null);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternosPendientes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_ubicacionesexternospendientes(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParams);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}		
		
		public long NumExternos()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numexternos()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumExternos(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numexternos(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumExternos(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numexternos(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumExternos(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numexternos(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long NumExternosNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_numexternosnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long NumExternosNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_numexternosnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}		
		
		public long PorcentajeExternosNoUbicados()
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajeexternosnoubicados()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public long PorcentajeExternosNoUbicados(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_porcentajeexternosnoubicados(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(long))
			{
				return (long) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadExternos()
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadexternos()";
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, null);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadExternos(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadexternos(:param1)";
			object[] aParams = new object[] {adscripcion.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadExternos(ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadexternos(:param1)";
			object[] aParams = new object[] {uso.Codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadExternos(GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_baseorg_densidadexternos(:param1, :param2)";
			object[] aParams = new object[] {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParams);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
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
