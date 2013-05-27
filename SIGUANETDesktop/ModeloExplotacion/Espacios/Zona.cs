/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/07/2006
 * Time: 9:37
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

namespace SIGUANETDesktop.ModeloExplotacion.Espacios
{
	/// <summary>
	/// Description of Zona.
	/// </summary>
	public class Zona
		:IUnidadGeoEstadistica, IDBEntity
	{

		public bool CanQuery
		{
			get
			{
				return false;
			}
		}
		
		public bool CanInsert
		{
			get
			{
				return false;
			}
		}
		
		public bool CanDelete
		{
			get
			{
				return false;
			}
		}
		
		public bool CanUpdate
		{
			get
			{
				return false;
			}
		}
		
		private bool _allowInsert = false;
		public bool AllowInsert
		{
			get
			{
				return _allowInsert;
			}
			set
			{
				_allowInsert = value;
			}
		}
		
		private bool _allowDelete = false;
		public bool AllowDelete
		{
			get
			{
				return _allowDelete;
			}
			set
			{
				_allowDelete = value;
			}
		}
		
		private bool _allowUpdate = false;
		public bool AllowUpdate
		{
			get
			{
				return _allowUpdate;
			}
			set
			{
				_allowUpdate = value;
			}
		}
		
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
		
		private long _numEdificios = 0;
		public long NumEdificios
		{
			get
			{
				return _numEdificios;
			}
		}
		
		public Zona(string codigo)
		{
			this._codigo = codigo;
			string sSQL = "SELECT count(*) FROM edificios where cod_zona = :param1";
			object[] aParam = {codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParam);
			if (r.GetType() == typeof(long))
			{
				this._numEdificios = (long) r;
			}
		}
		
		public string NextCodEdificio()
		{
			string r = string.Empty;
			return r;
		}		
		
		List<Edificio> GetListEdificios(string sql, params object[] sqlParams)
		{
			List<Edificio> r = new List<Edificio>();
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sql, sqlParams);
			if (ds.Tables[0].TableName != "Excepcion") {
				foreach(DataRow dr in ds.Tables[0].Rows) {
					string cod = (string) dr["codigo"];
					int[] checklist = (int[]) dr["checklist_plantas"];
					Edificio e = new Edificio(this, cod, checklist);
					e.Denominacion = (string) dr["denominacion_edificio"];
					r.Add(e);
				}
			} else {
				DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			}
			return r;
		}
		
		public List<Edificio> ObtenerEdificios()
		{
			string sSQL = "SELECT * FROM quest_zona_obteneredificios(:param1)";
			return GetListEdificios (sSQL, this._codigo);
		}

		public List<Edificio> ObtenerEdificios(DepartamentoSIGUA d)
		{
			string sSQL = "SELECT * FROM quest_zona_obteneredificios(:param1, :param2)";
			return GetListEdificios (sSQL, this._codigo, d.Codigo);
		}
		
		public List<Edificio> ObtenerEdificios(ActividadSIGUA a)
		{
			string sSQL = "SELECT * FROM quest_zona_obteneredificios(:param1, :param2)";
			return GetListEdificios (sSQL, this._codigo, a.Codigo);
		}
		
		public List<Edificio> ObtenerEdificios(GrupoActividad g)
		{
			string sSQL = "SELECT * FROM quest_zona_obteneredificios(:param1, :param2, :param3)";
			return GetListEdificios (sSQL, Enum.GetName(typeof(TipoGrupo), g.Tipo).ToLower(), g.Denominacion, this._codigo);
		}
		
		public List<PlantaZona> ObtenerPlantas()
		{
			List<PlantaZona> r = new List<PlantaZona>();
			string sSQL = "SELECT quest_zona_obtenerplantas(:param1) AS planta";
			object[] aParam = {this._codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParam);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string codPlanta = (string) dr["planta"];
					PlantaZona p = new PlantaZona(this, (EnumPlantas) Enum.Parse(typeof(EnumPlantas), codPlanta, true));
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;			
		}
		
		public List<PlantaZona> ObtenerPlantas(DepartamentoSIGUA d)
		{
			List<PlantaZona> r = new List<PlantaZona>();
			string sSQL = "SELECT quest_zona_obtenerplantas(:param1, :param2) AS planta";
			object[] aParam = {this._codigo, d.Codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParam);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string codPlanta = (string) dr["planta"];
					PlantaZona p = new PlantaZona(this, (EnumPlantas) Enum.Parse(typeof(EnumPlantas), codPlanta, true));
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;			
		}
		
		public List<PlantaZona> ObtenerPlantas(ActividadSIGUA a)
		{
			List<PlantaZona> r = new List<PlantaZona>();
			string sSQL = "SELECT quest_zona_obtenerplantas(:param1, :param2) AS planta";
			object[] aParam = {this._codigo, a.Codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParam);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string codPlanta = (string) dr["planta"];
					PlantaZona p = new PlantaZona(this, (EnumPlantas) Enum.Parse(typeof(EnumPlantas), codPlanta, true));
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;			
		}
		
		public List<PlantaZona> ObtenerPlantas(GrupoActividad g)
		{
			List<PlantaZona> r = new List<PlantaZona>();
			string sSQL = "SELECT * FROM quest_zona_obtenerplantas(:param1, :param2, :param3) AS t(planta)";
			object[] aParam = {Enum.GetName(typeof(TipoGrupo), g.Tipo).ToLower(), g.Denominacion, this._codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParam);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					string codPlanta = (string) dr["planta"];
					PlantaZona p = new PlantaZona(this, (EnumPlantas) Enum.Parse(typeof(EnumPlantas), codPlanta, true));
					r.Add(p);
				}
			}
			else DBUtils.ExceptionBox(ds.Tables[0], dbOrigen.PGSQL);
			return r;			
		}		
		
		public List<PlantaEdificio> ObtenerPlantasEdificio()
		{
			List<PlantaEdificio> r = new List<PlantaEdificio>();
			string sSQL = "SELECT * FROM quest_zona_obtenerplantasedificio(:param1)";
			object[] aParametros = {this._codigo};
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				foreach(DataRow dr in ds.Tables[0].Rows)
				{
					Edificio e = new Edificio(this, (string) dr["edificio"], (int[]) dr["checklist_plantas"]);
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
			string sSQL = "SELECT * FROM quest_zona_obtenerestancias(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestancias(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestancias(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasutiles(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public List<Estancia> ObtenerEstanciasDocentes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasdocentes(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasDocentes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasdocentes(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasocupadas(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasocupadas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasocupadas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasocupadas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasnoocupadas(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasnoocupadas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasnoocupadas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerestanciasnoocupadas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerDespachosOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerdespachosocupados(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerDespachosOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerdespachosocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerdespachosnoocupados(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_obtenerdespachosnoocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerAdmonOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_zona_obteneradmonocupados(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerAdmonOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_obteneradmonocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_zona_obteneradmonnoocupados(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_obteneradmonnoocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public long NumEstancias()
		{
			string sSQL = "SELECT * FROM quest_zona_numestancias(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestancias(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestancias(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestancias(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasutiles(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasutiles(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasdocentes(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasdocentes(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasocupadas(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasocupadas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasocupadas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasocupadas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasnoocupadas(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasnoocupadas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasnoocupadas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numestanciasnoocupadas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numdespachosocupados(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numdespachosocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numdespachosnoocupados(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numdespachosnoocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numadmonocupados(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numadmonocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numadmonnoocupados(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numadmonnoocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficie(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficie(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficie(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double SuperficieEstancias(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_superficie(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieutil(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieutil(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficiedocente(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficiedocente(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieestanciasocupadas(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieestanciasocupadas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieestanciasocupadas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieestanciasocupadas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieestanciasnoocupadas(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieestanciasnoocupadas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieestanciasnoocupadas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieestanciasnoocupadas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficiedespachosocupados(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficiedespachosocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficiedespachosnoocupados(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficiedespachosnoocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieadmonocupados(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieadmonocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieadmonnoocupados(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_superficieadmonnoocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_ubicaciones(:param1)";
			object[] aParametros = {this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicaciones(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicaciones(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicaciones(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicaciones(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}		
		
		public long NumPersonas()
		{
			string sSQL = "SELECT * FROM quest_zona_numpersonas(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpersonas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpersonas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpersonas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidad(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidad(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidad(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidad(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_ubicacionespas(:param1)";
			object[] aParametros = {this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionespas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionespas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPAS(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionespas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}		
		
		public long NumPAS()
		{
			string sSQL = "SELECT * FROM quest_zona_numpas(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadpas(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadpas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadpas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadpas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_ubicacionespdi(:param1)";
			object[] aParametros = {this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionespdi(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionespdi(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDI(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionespdi(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public long NumPDI()
		{
			string sSQL = "SELECT * FROM quest_zona_numpdi(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpdi(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpdi(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpdi(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadpdi(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadpdi(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadpdi(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadpdi(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_ubicacionescargos(:param1)";
			object[] aParametros = {this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesPDICargos(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionescargos(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public long NumPDICargos()
		{
			string sSQL = "SELECT * FROM quest_zona_numpdicargos(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numpdicargos(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_ubicacionesbecarios(:param1)";
			object[] aParametros = {this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionesbecarios(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionesbecarios(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesBecarios(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionesbecarios(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public long NumBecarios()
		{
			string sSQL = "SELECT * FROM quest_zona_numbecarios(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numbecarios(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numbecarios(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numbecarios(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadbecarios(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
			if (r.GetType() == typeof(double))
			{
				return (double) r;
			}
			else
			{
				return 0;
			}
		}
		
		public double CalcularDensidadBecarios(DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_densidadbecarios(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadbecarios(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadbecarios(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_ubicacionesexternos(:param1)";
			object[] aParametros = {this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionesexternos(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionesexternos(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public List<Ubicacion> ObtenerUbicacionesExternos(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_zona_ubicacionesexternos(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			List<Ubicacion> r = new List<Ubicacion>();
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			if (ds.Tables[0].TableName != "Excepcion")
			{
				r = ObjectFactory.generarListaUbicaciones(ds);
			}
			return r;
		}
		
		public long NumExternos()
		{
			string sSQL = "SELECT * FROM quest_zona_numexternos(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numexternos(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numexternos(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_numexternos(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadexternos(:param1)";
			object[] aParametros = {this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadexternos(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadexternos(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_zona_densidadexternos(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			object r = DBUtils.GetScalar(dbOrigen.PGSQL, sSQL, aParametros);
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
		
		public int Insert()
		{
			return 0;
		}
		
		public int Delete()
		{
			return 0;
		}
		
		public int Update()
		{
			return 0;
		}		
	}
}
