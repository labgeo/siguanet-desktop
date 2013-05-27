/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 29/09/2006
 * Time: 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using SharpMap.Layers;

namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{

	
	public class SimbAccesos
		: SimbBase
	{
		public override string titulo { get { return "Accesos"; } }
		public override Color color_ColorContorno { get { return Color.Black;} }
		public override Color color_ColorRelleno { get { return Color.FromArgb(255,235,255); } }//GhostWhite
		public override HatchStyle print_Trama { get { return  HatchStyle.SmallConfetti; } }
		public override Color print_ColorTrama { get { return Color.FromArgb(204,204,204); } }//Gainsboro
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.trama; } }
	}
	
	
	public class SimbMuros 
		: SimbBase
	{
		public override string titulo { get { return "Muros"; } }
		public override Color color_ColorContorno { get { return Color.Silver; } }
		public override Color color_ColorRelleno { get { return Color.FromArgb(243,243,243); } }	//WhiteSmoke	
		public override Color print_ColorContorno { get { return Color.FromArgb(156,156,156); } }//Gray
		public override Color print_ColorRelleno { get { return Color.FromArgb(225,225,225); } }//Gainsboro
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.solido; } }
	}
	
	public  class SimbAdministracion
		: SimbBase
	{
		public override string titulo { get { return "Administración"; } }
		public override Color color_ColorContorno { get { return Color.Gray; } }
		public override Color color_ColorRelleno { get { return Color.Silver;  } }
		public override HatchStyle print_Trama { get { return  HatchStyle.Percent10; } }
		public override Color print_ColorTrama { get { return Color.Gray; } }
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.trama; } }
	}	
		
	public  class SimbBiblioteca 
		: SimbBase
	{
		public override string titulo { get { return "Biblioteca"; } }
		public override Color color_ColorRelleno { get { return Color.FromArgb(255,128,255); } }	//Violet	
		public override Color print_ColorRelleno { get { return Color.LightYellow; } }
	    public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.solido; } }
	}
		
	public  class SimbAseos 
		: SimbBase
	{
		public override string titulo { get { return "Aseos"; } }
		public override Color color_ColorRelleno { get { return Color.Yellow; } }		
		public override Color print_ColorRelleno { get { return Color.Gray; } }
	    public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.solido; } }
	}

	public class SimbComunes
		: SimbBase
	{
		public override string titulo { get { return "Zonas comunes"; } }
		public override Color color_ColorRelleno { get { return Color.Olive; } }	
		public override Color print_ColorRelleno { get { return Color.DarkSlateGray; } }
	    public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.solido; } }
	}

	public  class SimbConserjeria 
		: SimbBase
	{
		public override string titulo { get { return "Conserjería"; } }
		public override Color color_ColorRelleno { get { return Color.Black; } }
		public override Color print_ColorRelleno { get { return Color.Black; } }
	    public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.solido; } }
	}
			
	public class SimbDespachos
		: SimbBase
	{
		public override string titulo { get { return "Despachos"; } }
		public override Color color_ColorContorno { get { return Color.Silver; } }
		public override Color color_ColorRelleno { get { return Color.PaleGreen; } }
		public override Color print_ColorContorno { get { return Color.Black; } }
		public override Color print_ColorRelleno { get { return Color.Lavender; } }
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.solido; } }
	}
		
	public class SimbDocencia 
		: SimbBase
	{
		public override string titulo { get { return "Docencia"; } }
		public override Color color_ColorContorno { get { return Color.DarkTurquoise; } }
		public override Color color_ColorRelleno { get { return Color.LightCyan; } }
		public override HatchStyle print_Trama { get { return  HatchStyle.ForwardDiagonal; } }
		public override Color print_ColorTrama { get { return Color.DimGray; } }
		public override Color print_ColorTramaFondo { get { return Color.Transparent; } }
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.trama;	 } }	
	}			
	
	public class SimbInformatica
		: SimbBase
	{
		public override string titulo { get { return "Aulas informática"; } }
		public override Color color_ColorRelleno { get { return Color.FromArgb(192,192,255); } }//MediumPurple
		public override Color print_ColorContorno { get { return Color.SlateGray; } }
		public override HatchStyle print_Trama { get { return  HatchStyle.ZigZag; } }
		public override Color print_ColorTrama { get { return Color.LightGray; } }
		public override Color print_ColorTramaFondo { get { return Color.WhiteSmoke; } }
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.trama;	 } }	
	}		
	
	public class SimbLaboratorios
		: SimbBase
	{
		public override string titulo { get { return "Laboratorios"; } }
		public override Color color_ColorRelleno { get { return Color.Gold; } }
		public override Color print_ColorContorno { get { return Color.Black; } }
		public override HatchStyle print_Trama { get { return  HatchStyle.BackwardDiagonal; } }
		public override Color print_ColorTrama { get { return Color.Gray; } }
		public override Color print_ColorTramaFondo { get { return Color.Transparent; } }
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.trama; } }		
	}	
	
	public class SimbSeminarios
		: SimbBase
	{
		public override string titulo { get { return "Seminarios"; } }
		public override Color color_ColorContorno { get { return Color.PeachPuff; } }
		public override Color color_ColorRelleno { get { return Color.Bisque; } }
		public override Color print_ColorContorno { get { return Color.Gray; } }
		public override HatchStyle print_Trama { get { return  HatchStyle.LargeGrid; } }
		public override Color print_ColorTrama { get { return Color.Gray; } }
		public override Color print_ColorTramaFondo { get { return Color.Transparent; } }
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.trama; } }		
	}		
	
	public class SimbSalas 
		: SimbBase
	{
		public override string titulo { get { return "Salas"; } }
		public override Color color_ColorRelleno { get { return Color.DarkTurquoise; } }
		public override HatchStyle print_Trama { get { return  HatchStyle.OutlinedDiamond; } }
		public override Color print_ColorTrama { get { return Color.Gray; } }
		public override Color print_ColorTramaFondo { get { return Color.Transparent; } }
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.trama;	 } }	
	}		
	
	public  class SimbVarios
		: SimbBase
	{
		public override string titulo { get { return "Varios"; } }
		public override Color color_ColorRelleno { get { return Color.FromArgb(192,0,192); } }
		public override HatchStyle print_Trama { get { return  HatchStyle.SmallConfetti; } }
		public override Color print_ColorTrama { get { return Color.Gray; } }
		public override Color print_ColorTramaFondo { get { return Color.Transparent; } }
		public override TipoRelleno print_TipoRelleno { get { return TipoRelleno.trama;	 } }	
	}
}
