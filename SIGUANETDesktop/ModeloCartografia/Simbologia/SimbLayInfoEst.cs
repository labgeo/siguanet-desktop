/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 29/09/2006
 * Time: 9:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using SharpMap.Layers;

namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{
	/// <summary>
	/// Description of SimbLayInfoEst.
	/// </summary>

	public class SimbLayInfoEst
		: SimbBase
	{
		public override string titulo { get { return "Información"; } }
		public override bool contorno {get{return false;}}
		//public override Color color_ColorRelleno { get { return Color.Transparent; } }
		//public override Color color_ColorContorno { get { return Color.Turquoise; } }
		public override HatchStyle color_Trama {get{return HatchStyle.DottedGrid;}}
		public override Color color_ColorTramaFondo {get{return Color.Transparent;}}
		public override TipoRelleno color_TipoRelleno {get{return TipoRelleno.trama;}}
        public override Color color_ColorTrama {get{return Color.Red;}}
		public override bool visible {get{return false;}}		
	}

}
