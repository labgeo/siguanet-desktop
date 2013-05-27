/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 28/09/2006
 * Time: 17:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using SharpMap.Layers;

namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{
	/// <summary>
	/// Description of SimbSelEst.
	/// </summary>
	public class SimbLaySelEst
		: SimbBase
	{
		public override string titulo { get { return "Estancia seleccionada"; } }
		public override Color color_ColorRelleno { get { return Color.Red; } }
		public override Color color_ColorContorno { get { return Color.Yellow; } }
		public override float width {get { return 3.0F; } }
	
	}			

}
