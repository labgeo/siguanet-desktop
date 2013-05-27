/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 14/07/2006
 * Time: 13:08
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
	/// Description of SubUnidad.
	/// </summary>
	public class SubUnidad
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
		
		public SubUnidad(string codigo)
		{
			_codigo = codigo;
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
		
		public Unidad InferirUnidad()
		{
			Unidad r = null;
			return r;
		}
		
		public List<Estancia> InferirEstancias()
		{
			List<Estancia> r = new List<Estancia>();
			return r;
		}
	}
}
