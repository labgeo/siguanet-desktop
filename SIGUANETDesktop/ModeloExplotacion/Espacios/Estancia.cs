/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 04/07/2006
 * Time: 12:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Collections.Generic;
using SharpMap.Geometries;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.ModeloExplotacion.Usos;
using SIGUANETDesktop.ModeloExplotacion.Utilidades;

namespace SIGUANETDesktop.ModeloExplotacion.Espacios
{
	/// <summary>
	/// Description of Estancia.
	/// </summary>
	public class Estancia
		:IDBEntity
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
		
		private long _gid = -1;
		public long GID
		{
			get
			{
				return _gid;
			}
		}
		
		private string _codigo;
		public string Codigo
		{
			get
			{
				return _codigo;
			}
			set 
			{
				_codigo = value;
			}
		}
		
		private string _denominacion;
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
		
		private MultiPolygon _geometria = null;
		public MultiPolygon Geometria
		{
			get
			{
				return _geometria;
			}
			set
			{
				_geometria = value;
			}
		}
		
		
		private PlantaEdificio _plantaEdificio = null;
		public PlantaEdificio PlantaEdificio
		{
			get
			{
				return _plantaEdificio;
			}
			set 
			{
				_plantaEdificio = value;
			}
		}
		
		private ActividadSIGUA _actividad = null;
		public ActividadSIGUA Actividad
		{
			get
			{
				return _actividad;
			}
			set
			{
				_actividad = value;
			}
		}
		
		private DepartamentoSIGUA _adscripcion;
		public DepartamentoSIGUA Adscripcion
		{
			get
			{
				return _adscripcion;
			}
			set
			{
				_adscripcion = value;
			}
		}
		
		public Estancia(string codigo)
		{
			_codigo = codigo;
		}
		
		public List<Persona> ObtenerPersonas()
		{
			string sSQL = "SELECT * FROM quest_estancia_obtenerpersonas(:param1)";
			object[] aParametros = {this._codigo};
			List<Persona> r = new List<Persona>();
			DataSet ds = DBUtils.GetDataSet(dbOrigen.PGSQL, sSQL, aParametros);
			r = ObjectFactory.generarListaPersonas(ds);
			return r;
		}
		
		public long NumPersonas()
		{
			string sSQL = "SELECT * FROM quest_estancia_numpersonas(:param1)";
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
		
		public double CalcularDensidad()
		{
			return 0;			
		}
		
		public List<PAS> ObtenerPAS()
		{
			List<PAS> r = new List<PAS>();
			return r;
		}
		
		public int NumPAS()
		{
			return 0;			
		}
		
		public double CalcularDensidadPAS()
		{
			return 0;			
		}
		
		public List<PDI> ObtenerPDI()
		{
			List<PDI> r = new List<PDI>();
			return r;
		}
		
		public int NumPDI()
		{
			return 0;			
		}
		
		public double CalcularDensidadPDI()
		{
			return 0;			
		}
		
		public List<Becario> ObtenerBecarios()
		{
			List<Becario> r = new List<Becario>();
			return r;
		}
		
		public int NumBecarios()
		{
			return 0;			
		}
		
		public double CalcularDensidadBecarios()
		{
			return 0;			
		}
		
		public List<Externo> ObtenerExternos()
		{
			List<Externo> r = new List<Externo>();
			return r;			
		}
		
		public int NumExternos()
		{
			return 0;			
		}
		
		public double CalcularDensidadExternos()
		{
			return 0;			
		}
		
		public DataSet EstadisticaPersonal()
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
