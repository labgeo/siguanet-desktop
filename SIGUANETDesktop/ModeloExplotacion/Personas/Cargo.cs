/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 14/07/2006
 * Time: 14:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;

namespace SIGUANETDesktop.ModeloExplotacion.Personas
{
	/// <summary>
	/// Description of Cargo.
	/// </summary>
	public class Cargo
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
		
		public Cargo(string codigo)
		{
			_codigo = codigo;
		}
		
		public Persona ObtenerPersona()
		{
			Persona r = null;
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
