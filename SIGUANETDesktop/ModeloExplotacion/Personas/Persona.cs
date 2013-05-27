/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/07/2006
 * Time: 10:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.Utilidades;

namespace SIGUANETDesktop.ModeloExplotacion.Personas
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public class Persona
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
		
		private string _nombre = string.Empty;
		public string Nombre
		{
			get
			{
				return _nombre;
			}
			set
			{
				_nombre = value;
			}
		}
		
		private string _apellido1 = string.Empty;
		public string Apellido1
		{
			get
			{
				return _apellido1;
			}
			set
			{
				_apellido1 = value;
			}
		}
		
		private string _apellido2 = string.Empty;
		public string Apellido2
		{
			get
			{
				return _apellido2;
			}
			set
			{
				_apellido2 = value;
			}			
		}
		
		private bool _esPAS = false;
		public bool EsPAS
		{
			get
			{
				return _esPAS;
			}
		}
		
		private bool _esPDI = false;
		public bool EsPDI
		{
			get
			{
				return _esPDI;
			}
		}
		
		private bool _esPDICargo = false;
		public bool EsPDICargo
		{
			get
			{
				return _esPDICargo;
			}
		}		
		
		private bool _esBecario = false;
		public bool EsBecario
		{
			get
			{
				return _esBecario;
			}
		}
		
		private bool _esExterno = false;
		public bool EsExterno
		{
			get
			{
				return _esExterno;
			}
		}
		
		public Persona(string nif)
		{
			
		}
		public Persona(string nif, string apellido1, string apellido2, string nombre, bool espas, bool espdi, bool espdicargo, bool esbecario, bool esexterno)
		{
			_nif = nif;
			_apellido1 = apellido1;
			_apellido2 = apellido2;
			_nombre = nombre;
			_esPAS = espas;
			_esPDI = espdi;
			_esPDICargo = espdicargo;
			_esBecario = esbecario;
			_esExterno = esexterno;
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
		
		public override string ToString()
		{
			string nombrePila = Regex.FirstUpper(_nombre.ToLower());
			string nombreCompleto = string.Format("{0} {1} {2}", nombrePila, _apellido1, _apellido2);
			int i = 0;
			string[] tipos = new string[4];
			if (this._esPAS) tipos[i++] = "PAS";
			if (this._esPDI) tipos[i++] = "PDI";
			if (this._esPDICargo) tipos[i++] = "CARGO";
			if (this._esBecario) tipos[i++] = "Becario";
			if (this._esExterno) tipos[i++] = "Externo";
			Array.Resize(ref tipos, i);
			return string.Format("{0} ({1})", nombreCompleto, string.Join(", ", tipos));
		}
	}
}
