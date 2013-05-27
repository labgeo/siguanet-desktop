/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 28/09/2006
 * Time: 17:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using SharpMap.Layers;

namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{
	/// <summary>
	/// Description of SimbLaySelPlanta.
	/// </summary>
	public class SimbLaySelPlanta
		: SimbBase
	{
		public override string titulo { get { return "Consulta"; } }
		public override Color color_ColorRelleno { get { return Color.Transparent; } }
		public override Color color_ColorContorno { get { return Color.Red; } }
        public override float width	{ get { return 3.5F; } }	
	}		

}
