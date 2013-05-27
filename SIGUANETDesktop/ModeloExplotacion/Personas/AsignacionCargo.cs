/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 14/07/2006
 * Time: 12:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.ModeloExplotacion.Personas
{
	/// <summary>
	/// Description of AsignacionCargo.
	/// </summary>
	public class AsignacionCargo
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
		
		private string _nif = string.Empty;
		public string NIF
		{
			get
			{
				return _nif;
			}
		}
		
		private Cargo _cargo = null;
		public Cargo Cargo
		{
			get
			{
				return _cargo;
			}
		}
		
		
		public AsignacionCargo(string nif, Cargo cargo)
		{
			_nif = nif;
			_cargo = cargo;	
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
