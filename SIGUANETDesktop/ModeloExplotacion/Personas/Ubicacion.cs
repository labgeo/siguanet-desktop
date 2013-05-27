/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 30/10/2006
 * Time: 16:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using SIGUANETDesktop.ModeloExplotacion.Espacios;

namespace SIGUANETDesktop.ModeloExplotacion.Personas
{
	/// <summary>
	/// Define una asociación entre una persona y una estancia.
	/// </summary>
	public class Ubicacion
	{
		private Persona _persona = null;
		public Persona Persona
		{
			get
			{
				return _persona;
			}
		}
		
		private Estancia _estancia = null;
		public Estancia Estancia
		{
			get
			{
				return _estancia;
			}
		}		
		
		public Ubicacion(Persona persona, Estancia estancia)
		{
			_persona = persona;
			_estancia = estancia;			
		}
	}
}
