/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 26/10/2006
 * Time: 8:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using SharpMap.Layers;

namespace SIGUANETDesktop.ModeloCartografia
{
	/// <summary>
	/// Description of EntradaLeyendaSeleccion.
	/// </summary>
	public class EntradaLeyendaSeleccion
		: EntradaLeyendaBD
	{
		public EntradaLeyendaSeleccion(string uid, VectorLayer capa, string titulo)
			: base(uid, capa, titulo)
		{
		}
	}
}
