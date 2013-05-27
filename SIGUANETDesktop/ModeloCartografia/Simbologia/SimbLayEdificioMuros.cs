/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 28/09/2006
 * Time: 14:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using SharpMap.Layers;

namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{

	public class SimbLayEdificioMuro
		: SimbBase
		
	{
	 public override string titulo {get{return "Muros";}}
     public override Color color_ColorContorno {get{return Color.DarkGray;;}} 
     public override Color color_ColorRelleno {get{return Color.Gainsboro;}} 
     //public override TipoRelleno print_TipoRelleno {get{return TipoRelleno.solido;}}
	}	
}
