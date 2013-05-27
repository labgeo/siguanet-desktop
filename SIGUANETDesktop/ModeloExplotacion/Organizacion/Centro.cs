/*
 * Created by SharpDevelop.
 * User: Jose Tom�s
 * Date: 14/07/2006
 * Time: 11:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Collections.Generic;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Personas;

namespace SIGUANETDesktop.ModeloExplotacion.Organizacion
{
	/// <summary>
	/// Description of Centro.
	/// </summary>
	public class Centro
		:DepartamentoSIGUA, IDBEntity
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
		
		private string _denominacion = string.Empty;
		public new string Denominacion
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
		
		public Centro(string codigo)
			:base(codigo)
		{
			
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
