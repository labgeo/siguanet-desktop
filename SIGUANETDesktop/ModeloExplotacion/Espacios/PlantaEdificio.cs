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

namespace SIGUANETDesktop.ModeloExplotacion.Espacios
{
	/// <summary>
	/// Description of PlantaEdificio.
	/// </summary>
	public class PlantaEdificio
		:IUnidadGeoEstadistica
	{
		
		public string NextCodEstancia()
		{
			string r = string.Empty;
			return r;
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
		
		private Edificio _edificio = null;
		public Edificio Edificio
		{
			get
			{
				return _edificio;
			}
		}
		
		private EnumPlantas _planta = EnumPlantas.PB;
		public EnumPlantas Planta
		{
			get
			{
				return _planta;
			}
		}
		
		public string StringPlanta
		{
			get
			{
				switch (this._planta)
				{
					case EnumPlantas.PS: return "sótano";
					case EnumPlantas.PB: 
					case EnumPlantas.P1: 
					case EnumPlantas.P2: 
					case EnumPlantas.P3: 
					case EnumPlantas.P4: return Enum.GetName(typeof(EnumPlantas), this._planta);
					default: return string.Empty;
				}
			}
		}		
		
		public PlantaEdificio(Edificio edificio, EnumPlantas planta)
		{
			_edificio = edificio;
			_planta = planta;
			_codigo = edificio.Codigo + planta.ToString();
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestancias(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestancias(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstancias(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestancias(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasutiles(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasDocentes(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasdocentes(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasDocentes(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasdocentes(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasocupadas(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasocupadas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasocupadas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasOcupadas(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasocupadas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}

		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasnoocupadas(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasnoocupadas(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, ActividadSIGUA uso)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasnoocupadas(:param1, :param2)";
			object[] aParametros = {uso.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerEstanciasNoOcupadas(out DataSet ds, GrupoActividad grupo)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerestanciasnoocupadas(:param1, :param2, :param3)";
			object[] aParametros = {Enum.GetName(typeof(TipoGrupo), grupo.Tipo).ToLower(), grupo.Denominacion, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerDespachosOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerdespachosocupados(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerDespachosOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerdespachosocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerdespachosnoocupados(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;			
		}
		
		public List<Estancia> ObtenerDespachosNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obtenerdespachosnoocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerAdmonOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obteneradmonocupados(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerAdmonOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obteneradmonocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obteneradmonnoocupados(:param1)";
			object[] aParametros = {this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}
		
		public List<Estancia> ObtenerAdmonNoOcupados(out DataSet ds, DepartamentoSIGUA adscripcion)
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_obteneradmonnoocupados(:param1, :param2)";
			object[] aParametros = {adscripcion.Codigo, this._codigo};
			ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			List<Estancia> r = ObjectFactory.generarListaEstancias(ds);
			return r;
		}		
		
		public long NumEstancias()
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_numestancias(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestancias(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestancias(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestancias(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasutiles(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasutiles(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasdocentes(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasdocentes(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasocupadas(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasocupadas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasocupadas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasocupadas(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasnoocupadas(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasnoocupadas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasnoocupadas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numestanciasnoocupadas(:param1, :param2, :param3)";
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
		    string sSQL = "SELECT * FROM quest_plantaedificio_numdespachosocupados(:param1)";
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
		    string sSQL = "SELECT * FROM quest_plantaedificio_numdespachosocupados(:param1, :param2)";
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
		    string sSQL = "SELECT * FROM quest_plantaedificio_numdespachosnoocupados(:param1)";
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
		    string sSQL = "SELECT * FROM quest_plantaedificio_numdespachosnoocupados(:param1, :param2)";
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
		    string sSQL = "SELECT * FROM quest_plantaedificio_numadmonocupados(:param1)";
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
		    string sSQL = "SELECT * FROM quest_plantaedificio_numadmonocupados(:param1, :param2)";
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
		    string sSQL = "SELECT * FROM quest_plantaedificio_numadmonnoocupados(:param1)";
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
		    string sSQL = "SELECT * FROM quest_plantaedificio_numadmonnoocupados(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficie(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficie(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficie(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficie(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieutil(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieutil(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficiedocente(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficiedocente(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieestanciasocupadas(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieestanciasocupadas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieestanciasocupadas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieestanciasocupadas(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieestanciasnoocupadas(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieestanciasnoocupadas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieestanciasnoocupadas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieestanciasnoocupadas(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficiedespachosocupados(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficiedespachosocupados(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficiedespachosnoocupados(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficiedespachosnoocupados(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieadmonocupados(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieadmonocupados(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieadmonnoocupados(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_superficieadmonnoocupados(:param1, :param2)";
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
		
		public DataSet EstadisticaDepartamentosSIGUA()
		{
			string sSQL = "SELECT * FROM quest_plantaedificio_estadisticadepartamentossigua(:param1)" + 
						  " AS (cod varchar, txt varchar, conteo int8, superficie float8)";
			object[] aParametros = {this._codigo};
			DataSet r = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicaciones(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicaciones(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicaciones(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicaciones(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpersonas(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpersonas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpersonas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpersonas(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidad(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidad(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidad(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidad(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionespas(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionespas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionespas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionespas(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpas(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpas(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadpas(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadpas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadpas(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadpas(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionespdi(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionespdi(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionespdi(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionespdi(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpdi(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpdi(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpdi(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpdi(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadpdi(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadpdi(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadpdi(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadpdi(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionescargos(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionescargos(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpdicargos(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numpdicargos(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionesbecarios(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionesbecarios(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionesbecarios(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionesbecarios(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numbecarios(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numbecarios(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numbecarios(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numbecarios(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadbecarios(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadbecarios(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadbecarios(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadbecarios(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionesexternos(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionesexternos(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionesexternos(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_ubicacionesexternos(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numexternos(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numexternos(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numexternos(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_numexternos(:param1, :param2, :param3)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadexternos(:param1)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadexternos(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadexternos(:param1, :param2)";
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
			string sSQL = "SELECT * FROM quest_plantaedificio_densidadexternos(:param1, :param2, :param3)";
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
	}
}
