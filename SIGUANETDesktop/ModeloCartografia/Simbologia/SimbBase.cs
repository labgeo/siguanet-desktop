/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 05/10/2006
 * Time: 16:50
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
	/// Description of SimbBase.
	/// </summary>
	public abstract class SimbBase
	{
		public virtual string titulo {get{return "Nombre Layer";}}
		public virtual bool contorno {get{return true;}}
		public virtual float width {get{return 1.0F;}}
		
		public virtual Color color_ColorContorno {get{return Color.Black;}}
		public virtual Color color_ColorRelleno {get{return Color.Transparent;}}
		public virtual HatchStyle color_Trama {get{return HatchStyle.Horizontal;}}
		public virtual Color color_ColorTramaFondo {get{return Color.Transparent;}}
		public virtual TipoRelleno color_TipoRelleno {get{return TipoRelleno.solido;}}
		public virtual Color color_ColorTrama {get{return Color.Gray;}}
		
		public virtual Color print_ColorContorno {get{return Color.Black;}}
		public virtual Color print_ColorRelleno {get{return Color.Transparent;}}
		public virtual HatchStyle print_Trama {get{return HatchStyle.Horizontal;}}
		public virtual Color print_ColorTrama {get{return Color.Black;}}
		public virtual Color print_ColorTramaFondo {get{return Color.Transparent;}}
		public virtual TipoRelleno print_TipoRelleno {get{return TipoRelleno.solido;}}
		public virtual bool visible {get{return true;}}

	}
}
