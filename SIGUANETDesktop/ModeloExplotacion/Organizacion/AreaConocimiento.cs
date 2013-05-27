/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 14/07/2006
 * Time: 13:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.ModeloExplotacion.Espacios;

namespace SIGUANETDesktop.ModeloExplotacion.Organizacion
{
	/// <summary>
	/// Description of AreaConocimiento.
	/// </summary>
	public class AreaConocimiento
	{
		
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
		}
		
		public AreaConocimiento(string codigo)
		{
			_codigo = codigo;
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
		
		public Departamento InferirDepartamento()
		{
			Departamento r = null;
			return r;
		}
		
		public List<Estancia> InferirEstancias()
		{
			List<Estancia> r = new List<Estancia>();
			return r;
		}
	}
}
