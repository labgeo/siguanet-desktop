/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/10/2006
 * Time: 8:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using SharpMap.Layers;
using SharpMap.Styles;

namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{
	/// <summary>
	/// Description of Renderizador.
	/// </summary>
	public static class Renderizador
	{
		
		public static void render(VectorLayer capa, TipoPaleta paleta, SimbBase simb)
     	{
	     	switch(paleta)
	     	{
				case (TipoPaleta.predeterminada):			
					capa.Style.EnableOutline = simb.contorno;
					capa.Style.Outline = new Pen(simb.color_ColorContorno, simb.width);
					switch (simb.color_TipoRelleno)
					{
						case (TipoRelleno.solido):
							capa.Style.Fill = new SolidBrush(simb.color_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							capa.Style.Fill = new HatchBrush(simb.color_Trama, simb.color_ColorTrama, simb.color_ColorTramaFondo);
							break;
					}
					capa.Enabled = simb.visible;
					break;
				case (TipoPaleta.impresion):
					capa.Style.EnableOutline = simb.contorno;
					capa.Style.Outline = new Pen(simb.print_ColorContorno, simb.width);
					capa.Enabled = simb.visible;
					switch (simb.print_TipoRelleno)
					{
						case (TipoRelleno.solido):
							capa.Style.Fill = new SolidBrush(simb.print_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							capa.Style.Fill = new HatchBrush(simb.print_Trama, simb.print_ColorTrama, simb.print_ColorTramaFondo);
							break;
					}
					capa.Enabled = simb.visible;
					break;
				default:
					capa.Style.EnableOutline = simb.contorno;
					capa.Style.Outline = new Pen(simb.color_ColorContorno, simb.width);
					switch (simb.color_TipoRelleno)
					{
						case (TipoRelleno.solido):
							capa.Style.Fill = new SolidBrush(simb.color_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							capa.Style.Fill = new HatchBrush(simb.color_Trama, simb.color_ColorTrama, simb.color_ColorTramaFondo);
							break;
					}
					capa.Enabled = simb.visible;
					break;					
	     	}
		}	
		
		public static void dibujarLeyenda(Graphics g, int x, int y, int posicion, TipoPaleta paleta, SimbBase simb)
	    {
	     	int posX = x + Constantes.distPanelLeyenda;
		    int posY = y + (posicion * Constantes.distCuadroV);

	     	switch(paleta)
	     	{	     			
	     	  case (TipoPaleta.predeterminada):
		     	g.DrawRectangle(new Pen(simb.color_ColorContorno, simb.width), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
		     	switch (simb.color_TipoRelleno)
					{
						case (TipoRelleno.solido):
							g.FillRectangle(new SolidBrush(simb.color_ColorRelleno), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
							break;
						case (TipoRelleno.trama):
							g.FillRectangle(new HatchBrush(simb.color_Trama,simb.color_ColorTrama, simb.color_ColorTramaFondo), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
							break;
					}
	   	        g.DrawString(simb.titulo, new Font(Constantes.familiaFuente, Constantes.sizeFuente, Constantes.estiloFuente, Constantes.unidadFuente),Constantes.colorFuente,posX+ Constantes.distCuadroLabel, posY);
		      	break;
		      case (TipoPaleta.impresion):
		     	g.DrawRectangle(new Pen(simb.print_ColorContorno, simb.width), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
		      	g.DrawString(simb.titulo, new Font(Constantes.familiaFuente, Constantes.sizeFuente, Constantes.estiloFuente, Constantes.unidadFuente),Constantes.colorFuente,posX+ Constantes.distCuadroLabel, posY);
		      	switch (simb.print_TipoRelleno)
					{
						case (TipoRelleno.solido):
							g.FillRectangle(new SolidBrush(simb.print_ColorRelleno), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
							break;
						case (TipoRelleno.trama):
							g.FillRectangle(new HatchBrush(simb.print_Trama,simb.print_ColorTrama, simb.print_ColorTramaFondo), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
							break;
					}
		      	break;
	     	  default:
		     	g.DrawRectangle(new Pen(simb.color_ColorContorno, simb.width), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
		     	switch (simb.color_TipoRelleno)
					{
						case (TipoRelleno.solido):
							g.FillRectangle(new SolidBrush(simb.color_ColorRelleno), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
							break;
						case (TipoRelleno.trama):
							g.FillRectangle(new HatchBrush(simb.color_Trama,simb.color_ColorTrama, simb.color_ColorTramaFondo), posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
							break;
					}
	   	        g.DrawString(simb.titulo, new Font(Constantes.familiaFuente, Constantes.sizeFuente, Constantes.estiloFuente, Constantes.unidadFuente),Constantes.colorFuente,posX+ Constantes.distCuadroLabel, posY);
		      	break;		      	
	     	}
	     }	
		
		public static VectorStyle obtenerEstilo(TipoPaleta paleta, SimbBase simb)
     	{
			VectorStyle vs = new VectorStyle();
	     	switch(paleta)
	     	{
	     		case (TipoPaleta.predeterminada):
	     			vs.EnableOutline = simb.contorno;
					vs.Outline = new Pen(simb.color_ColorContorno, simb.width);

					switch (simb.color_TipoRelleno)
					{
						case (TipoRelleno.solido):
							vs.Fill = new SolidBrush(simb.color_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							vs.Fill = new HatchBrush(simb.color_Trama, simb.color_ColorTrama, simb.color_ColorTramaFondo);
							break;
					}
					break;
				case (TipoPaleta.impresion):
					vs.EnableOutline = simb.contorno;
					vs.Outline = new Pen(simb.print_ColorContorno, simb.width);
					switch (simb.print_TipoRelleno)
					{
						case (TipoRelleno.solido):
							vs.Fill = new SolidBrush(simb.print_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							vs.Fill = new HatchBrush(simb.print_Trama, simb.print_ColorTrama, simb.print_ColorTramaFondo);
							break;
					}
					break;
				default:
	     			vs.EnableOutline = simb.contorno;
					vs.Outline = new Pen(simb.color_ColorContorno, simb.width);

					switch (simb.color_TipoRelleno)
					{
						case (TipoRelleno.solido):
							vs.Fill = new SolidBrush(simb.color_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							vs.Fill = new HatchBrush(simb.color_Trama, simb.color_ColorTrama, simb.color_ColorTramaFondo);
							break;
					}					
					break;
	     	}
	     	return vs;
		}	
	}
}
*/
