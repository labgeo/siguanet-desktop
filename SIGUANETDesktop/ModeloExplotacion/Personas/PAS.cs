/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/07/2006
 * Time: 10:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;

namespace SIGUANETDesktop.ModeloExplotacion.Personas
{
	/// <summary>
	/// Description of PAS.
	/// </summary>
	public class PAS
		:Persona
	{
		
		public new bool CanQuery
		{
			get
			{
				return false;
			}
		}		
		
		public new bool CanInsert
		{
			get
			{
				return false;
			}
		}
		
		public new bool CanDelete
		{
			get
			{
				return false;
			}
		}
		
		public new bool CanUpdate
		{
			get
			{
				return false;
			}
		}
		
		private bool _allowInsert = false;
		public new bool AllowInsert
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
		public new bool AllowDelete
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
		public new bool AllowUpdate
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
		
		private Centro _centro = null;
		public Centro Centro
		{
			get
			{
				return _centro;
			}
			set
			{
				_centro = value;
			}
		}
		
		private Unidad _unidad = null;
		public Unidad Unidad
		{
			get
			{
				return _unidad;
			}
			set
			{
				_unidad = value;
			}
		}
		
		private SubUnidad _subunidad = null;
		public SubUnidad SubUnidad
		{
			get
			{
				return _subunidad;
			}
			set
			{
				_subunidad = value;
			}
		}
		
		private Puesto _puesto = null;
		public Puesto Puesto
		{
			get
			{
				return _puesto;
			}
			set
			{
				_puesto = value;
			}
		}
		
		private List<Estancia> _estancias = new List<Estancia>();
		public List<Estancia> Estancias
		{
			get
			{
				return _estancias;
			}
			set
			{
				_estancias = value;
			}
		}
		
		private List<AsignacionCargo> _cargosAsignados = new List<AsignacionCargo>();
		public List<AsignacionCargo> CargosAsignados
		{
			get
			{
				return _cargosAsignados;
			}
			set
			{
				_cargosAsignados = value;
			}
		}		
		
		public PAS(string nif)
			:base(nif)
		{
			
		}
		
		private List<AsignacionCargo> ObtenerAsignacionesCargo(string nif)
		{
			List<AsignacionCargo> r = new List<AsignacionCargo>();
			return r;
		}
		
		public new int Insert()
		{
			return 0;
		}
		
		public new int Delete()
		{
			return 0;
		}
		
		public new int Update()
		{
			return 0;
		}		
	}
}
