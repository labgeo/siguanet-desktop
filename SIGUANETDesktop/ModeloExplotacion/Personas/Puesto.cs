/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 14/07/2006
 * Time: 14:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Personas;

namespace SIGUANETDesktop.ModeloExplotacion.Personas
{
	/// <summary>
	/// Description of Puesto.
	/// </summary>
	public class Puesto
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
		
		private EnumTiposPuesto _tipoPuesto = EnumTiposPuesto.CAMBIAR;
		public EnumTiposPuesto TipoPuesto
		{
			get
			{
				return _tipoPuesto;
			}
			set
			{
				_tipoPuesto = value;
			}
		}
		
		private bool _esInvestigador = false;
		public bool EsInvestigador
		{
			get
			{
				return _esInvestigador;
			}
			set
			{
				_esInvestigador = value;
			}
		}
		private int _etic = 0;
		public int ETIC
		{
			get
			{
				return _etic;
			}
			set
			{
				_etic = value;
			}
		}
		
		public Puesto(string codigo)
		{
			_codigo = codigo;
		}
		
		public List<Estancia> ObtenerEstancias()
		{
			List<Estancia> r = new List<Estancia>();
			return r;
		}
		
		public List<PAS> ObtenerPAS()
		{
			List<PAS> r = new List<PAS>();
			return r;
		}

		public List<PDI> ObtenerPDI()
		{
			List<PDI> r = new List<PDI>();
			return r;
		}
		
		public List<Becario> ObtenerBecarios()
		{
			List<Becario> r = new List<Becario>();
			return r;
		}
		
		public List<Externo> ObtenerExternos()
		{
			List<Externo> r = new List<Externo>();
			return r;
		}		
		
		public int NumPAS()
		{
			return 0;			
		}
		
		public int NumPDI()
		{
			return 0;			
		}
		
		public int NumBecarios()
		{
			return 0;			
		}
		
		public int NumExternos()
		{
			return 0;			
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
