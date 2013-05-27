/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/07/2006
 * Time: 9:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloExplotacion.Espacios;

namespace SIGUANETDesktop.ModeloExplotacion.Usos
{
	/// <summary>
	/// Description of ActividadSIGUA.
	/// </summary>
	public class ActividadSIGUA
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
		
		private short _codigo = -1;
		public short Codigo
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
		
		private GrupoPropio _grupopropio = null;
		public GrupoPropio GrupoPropio
		{
			get
			{
				return _grupopropio;
			}
			set
			{
				_grupopropio = value;
			}
		}
		
		private GrupoCRUE _grupoCRUE = null;
		public GrupoCRUE GrupoCRUE
		{
			get
			{
				return _grupoCRUE;
			}
			set
			{
				_grupoCRUE = value;
			}
		}		

		private GrupoUXXI _grupoUXXI = null;
		public GrupoUXXI GrupoUXXI
		{
			get
			{
				return _grupoUXXI;
			}
			set
			{
				_grupoUXXI = value;
			}
		}
		
		public ActividadSIGUA(short codigo)
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
