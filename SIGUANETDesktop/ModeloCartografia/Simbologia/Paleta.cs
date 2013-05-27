/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 19/10/2006
 * Time: 14:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using SharpMap.Styles;

namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{
	/// <summary>
	/// Description of PaletaEstandar.
	/// </summary>
	/// Se crea la estructura de Paleta que contendrá 3 arrays de paletas (ItemPaleta)
	public struct Paleta
	{
		private static bool _predeterminadosOrdenados = false;
		public static ItemPaleta PredeterminadoPorDefecto = new ItemPaleta(-1, new Pen(Color.Black), new SolidBrush(Color.LightYellow));
		//ItemPaleta predeterminada
		public static ItemPaleta[] Predeterminados = 
			new ItemPaleta[] 
			{
				new ItemPaleta(100, new Pen(Color.Black), new SolidBrush(Color.CadetBlue)),
				new ItemPaleta(110, new Pen(Color.Black), new SolidBrush(Color.Goldenrod)),
				new ItemPaleta(120, new Pen(Color.Black), new SolidBrush(Color.DarkKhaki)),
				new ItemPaleta(130, new Pen(Color.Black), new SolidBrush(Color.OliveDrab)),
				new ItemPaleta(140, new Pen(Color.Black), new SolidBrush(Color.MediumVioletRed)),
				new ItemPaleta(150, new Pen(Color.Black), new SolidBrush(Color.MediumOrchid)),
				new ItemPaleta(160, new Pen(Color.Black), new SolidBrush(Color.CornflowerBlue)),
				new ItemPaleta(170, new Pen(Color.Black), new SolidBrush(Color.MediumSlateBlue)),
				new ItemPaleta(180, new Pen(Color.Black), new SolidBrush(Color.Chocolate)),
				new ItemPaleta(190, new Pen(Color.Black), new SolidBrush(Color.SandyBrown)),
				new ItemPaleta(200, new Pen(Color.Black), new SolidBrush(Color.Firebrick)),
				new ItemPaleta(210, new Pen(Color.Black), new SolidBrush(Color.DarkTurquoise)),
				new ItemPaleta(220, new Pen(Color.Black), new SolidBrush(Color.PaleVioletRed)),
				new ItemPaleta(230, new Pen(Color.Black), new SolidBrush(Color.RosyBrown)),
				new ItemPaleta(240, new Pen(Color.Black), new SolidBrush(Color.Tomato)),
				new ItemPaleta(250, new Pen(Color.Black), new SolidBrush(Color.Yellow)),
				new ItemPaleta(260, new Pen(Color.Black), new SolidBrush(Color.Magenta)),
				new ItemPaleta(270, new Pen(Color.Black), new SolidBrush(Color.Gold)),
				new ItemPaleta(280, new Pen(Color.Black), new SolidBrush(Color.GreenYellow)),
				new ItemPaleta(290, new Pen(Color.Black), new SolidBrush(Color.Aquamarine))
		   };

		private static bool _pastelesOrdenados = false;
		public static ItemPaleta PastelPorDefecto = new ItemPaleta(-1, new Pen(Color.Black), new SolidBrush(Color.DarkGray));
		// Itempaleta para el caso de colores por pastel. No incluye tramas
		public static ItemPaleta[] Pasteles = 
			new ItemPaleta[] 
			{
				new ItemPaleta(100, new Pen(Color.Black), new SolidBrush(Color.Lavender)),
				new ItemPaleta(110, new Pen(Color.Black), new SolidBrush(Color.LavenderBlush)),
				new ItemPaleta(120, new Pen(Color.Black), new SolidBrush(Color.LemonChiffon)),
				new ItemPaleta(130, new Pen(Color.Black), new SolidBrush(Color.OldLace)),
				new ItemPaleta(140, new Pen(Color.Black), new SolidBrush(Color.AntiqueWhite)),
				new ItemPaleta(150, new Pen(Color.Black), new SolidBrush(Color.PeachPuff)),
				new ItemPaleta(160, new Pen(Color.Black), new SolidBrush(Color.Thistle)),
				new ItemPaleta(170, new Pen(Color.Black), new SolidBrush(Color.Wheat)),
				new ItemPaleta(180, new Pen(Color.Black), new SolidBrush(Color.PaleGoldenrod)),
				new ItemPaleta(190, new Pen(Color.Black), new SolidBrush(Color.PaleGreen)),
				new ItemPaleta(200, new Pen(Color.Black), new SolidBrush(Color.Plum)),
				new ItemPaleta(210, new Pen(Color.Black), new SolidBrush(Color.Tan)),
				new ItemPaleta(220, new Pen(Color.Black), new SolidBrush(Color.PaleTurquoise)),
				new ItemPaleta(230, new Pen(Color.Black), new SolidBrush(Color.LightSkyBlue)),
				new ItemPaleta(240, new Pen(Color.Black), new SolidBrush(Color.LightSalmon)),
				new ItemPaleta(250, new Pen(Color.Black), new SolidBrush(Color.WhiteSmoke)),
				new ItemPaleta(260, new Pen(Color.Black), new SolidBrush(Color.AliceBlue)),
				new ItemPaleta(270, new Pen(Color.Black), new SolidBrush(Color.Aquamarine)),
				new ItemPaleta(280, new Pen(Color.Black), new SolidBrush(Color.LightPink)),
				new ItemPaleta(290, new Pen(Color.Black), new SolidBrush(Color.LightSteelBlue))
		   };

		private static bool _tramadosOrdenados = false;
		public static ItemPaleta TramadoPorDefecto = new ItemPaleta(-1, new Pen(Color.Black), new SolidBrush(Color.LightYellow));
		// ItemPaleta para tramas. Puede contener o no tramas.
		public static ItemPaleta[] Tramados = 
			new ItemPaleta[] 
			{
				new ItemPaleta(100, new Pen(Color.Black), new HatchBrush(HatchStyle.BackwardDiagonal, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(110, new Pen(Color.Black), new HatchBrush(HatchStyle.Cross, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(120, new Pen(Color.Black), new HatchBrush(HatchStyle.DiagonalCross, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(130, new Pen(Color.Black), new HatchBrush(HatchStyle.DottedGrid, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(140, new Pen(Color.Black), new HatchBrush(HatchStyle.ForwardDiagonal, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(150, new Pen(Color.Black), new HatchBrush(HatchStyle.Horizontal, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(160, new Pen(Color.Black), new HatchBrush(HatchStyle.HorizontalBrick, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(170, new Pen(Color.Black), new HatchBrush(HatchStyle.LargeConfetti, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(180, new Pen(Color.Black), new HatchBrush(HatchStyle.LargeGrid, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(190, new Pen(Color.Black), new HatchBrush(HatchStyle.OutlinedDiamond, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(200, new Pen(Color.Black), new HatchBrush(HatchStyle.Percent20, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(210, new Pen(Color.Black), new HatchBrush(HatchStyle.Percent40, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(220, new Pen(Color.Black), new HatchBrush(HatchStyle.Percent80, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(230, new Pen(Color.Black), new HatchBrush(HatchStyle.SmallConfetti, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(240, new Pen(Color.Black), new HatchBrush(HatchStyle.SmallGrid, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(250, new Pen(Color.Black), new HatchBrush(HatchStyle.Vertical, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(260, new Pen(Color.Black), new HatchBrush(HatchStyle.Wave, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(270, new Pen(Color.Black), new HatchBrush(HatchStyle.Weave, Color.Gainsboro, Color.Transparent)),
				new ItemPaleta(280, new Pen(Color.Black), new SolidBrush(Color.Azure)),
				new ItemPaleta(290, new Pen(Color.Black), new SolidBrush(Color.LightSteelBlue))
		   };
		
		public static VectorStyle obtenerEstiloPorDefecto(TipoPaleta tipo)
		{
			VectorStyle vs = new VectorStyle();
	     	switch(tipo)
	     	{
	     		case (TipoPaleta.predeterminada):
	     			vs.Outline = PredeterminadoPorDefecto.SimbLinea;
	     			vs.Fill = PredeterminadoPorDefecto.SimbRelleno;
					break;
	     		case (TipoPaleta.pastel):
					vs.Outline = PastelPorDefecto.SimbLinea;
					vs.Fill = PastelPorDefecto.SimbRelleno;
					break;					
				case (TipoPaleta.tramado):
					vs.Outline = TramadoPorDefecto.SimbLinea;
					vs.Fill = TramadoPorDefecto.SimbRelleno;
					break;
				default:
	     			vs.Outline = PredeterminadoPorDefecto.SimbLinea;
	     			vs.Fill = PredeterminadoPorDefecto.SimbRelleno;
					break;
	     	}
	     	vs.EnableOutline = true;
	     	return vs;			
			
		}
		
		// Método para obtener el item correspondiente del Array de ItemPaleta y ordenarlo en función del peso (prioridad)
		private static ItemPaleta obtenerItem(int posicion, ItemPaleta[] items)
		{
			Array.Sort(items);
			return items[posicion -1];
		}
		
		public static VectorStyle obtenerEstilo(int posicion, TipoPaleta tipo)
     	{
			VectorStyle vs = new VectorStyle();
			ItemPaleta ip;
	     	switch(tipo)
	     	{
	     		case (TipoPaleta.predeterminada):
	     			ip = obtenerItem(posicion,Predeterminados);
					break;
	     		case (TipoPaleta.pastel):
					ip = obtenerItem(posicion, Pasteles);
					break;					
				case (TipoPaleta.tramado):
					ip = obtenerItem(posicion, Tramados);
					break;
				default:
					ip = obtenerItem(posicion,Predeterminados);
					break;
	     	}
	     	vs.EnableOutline = true;
	     	vs.Outline = ip.SimbLinea;
	     	vs.Fill = ip.SimbRelleno;
	     	return vs;
		}
		
		// Metodo para dibujar las paletas de leyenda establecidas: predeterminada, pasteles y tramas
		public static void dibujarLeyenda(Graphics g, int x, int y, int posicion, TipoPaleta tipo, string descripcion)
		{
	     	int posX = x + Constantes.distPanelLeyenda;
		    int posY = y + (posicion * Constantes.distCuadroV);	
		    ItemPaleta ip;
		    
	     	switch(tipo)
	     	{
	     	  case (TipoPaleta.predeterminada):
	     		ip = obtenerItem(posicion,Predeterminados); 			
		      	break;
		      case (TipoPaleta.pastel):
		      	ip = obtenerItem(posicion,Pasteles); 			
		      	break;
		      case (TipoPaleta.tramado):
		      	ip = obtenerItem(posicion,Tramados); 			
		      	break;
		      default:
		     	ip = obtenerItem(posicion,Predeterminados); 	
		     	break;
	     	}
	     		g.DrawRectangle(ip.SimbLinea, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
	     		g.DrawString(descripcion, new Font(Constantes.familiaFuente, Constantes.sizeFuente, Constantes.estiloFuente, Constantes.unidadFuente),Constantes.colorFuente,posX+ Constantes.distCuadroLabel, posY);
	     		g.FillRectangle(ip.SimbRelleno, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
	    }
		
		public static void dibujarLeyendaPorDefecto(Graphics g, int x, int y, int posicion, TipoPaleta tipo, string descripcion)
		{
	     	int posX = x + Constantes.distPanelLeyenda;
		    int posY = y + (posicion * Constantes.distCuadroV);	
		    ItemPaleta ip;
		    
	     	switch(tipo)
	     	{
	     	  case (TipoPaleta.predeterminada):
	     		ip = PredeterminadoPorDefecto;
		      	break;
		      case (TipoPaleta.pastel):
		      	ip = PastelPorDefecto; 			
		      	break;
		      case (TipoPaleta.tramado):
		      	ip = TramadoPorDefecto;
		      	break;
		      default:
		      	ip = PredeterminadoPorDefecto;
		     	break;
	     	}
	     		g.DrawRectangle(ip.SimbLinea, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
	     		g.DrawString(descripcion, new Font(Constantes.familiaFuente, Constantes.sizeFuente, Constantes.estiloFuente, Constantes.unidadFuente),Constantes.colorFuente,posX+ Constantes.distCuadroLabel, posY);
	     		g.FillRectangle(ip.SimbRelleno, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro);
	    }
		
		public static ItemPaleta obtenerDefinicionSimbologia(int posicion, TipoPaleta tipo)
		{
	     	switch(tipo)
	     	{
	     		case (TipoPaleta.predeterminada):
	     			if (!_predeterminadosOrdenados)
	     			{
	     				Array.Sort(Predeterminados);
	     				_predeterminadosOrdenados = true;	
	     			}
	     			return Predeterminados[posicion -1];
	     		case (TipoPaleta.pastel):
	     			if (!_pastelesOrdenados)
	     			{
	     				Array.Sort(Pasteles);
	     				_pastelesOrdenados = true;	
	     			}
	     			return Pasteles[posicion -1];
				case (TipoPaleta.tramado):
	     			if (!_tramadosOrdenados)
	     			{
	     				Array.Sort(Tramados);
	     				_tramadosOrdenados = true;	
	     			}
	     			return Tramados[posicion -1];
				default:
	     			if (!_predeterminadosOrdenados)
	     			{
	     				Array.Sort(Predeterminados);
	     				_predeterminadosOrdenados = true;	
	     			}
	     			return Predeterminados[posicion -1];
	     	}			
		}		
	}
}
