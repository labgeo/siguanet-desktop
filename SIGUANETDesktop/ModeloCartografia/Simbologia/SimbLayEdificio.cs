/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 28/09/2006
 * Time: 12:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using SharpMap.Layers;


namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{
	/// <summary>
	/// Description of SimbLayEdificio.
	/// </summary>
	/// 
	
	
	public class SimbLayEdificio
		: SimbBase
	{
		public override string titulo { get { return "Estancias"; } }
		public override Color color_ColorRelleno { get { return Color.Transparent; } }
		public override Color color_ColorContorno { get { return Color.DarkGray; } }
	}
}
