/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/10/2006
 * Time: 13:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using SharpMap.Layers;
using SharpMap.Styles;
using SIGUANETDesktop.ModeloCartografia.Simbologia;


namespace SIGUANETDesktop.ModeloCartografia
{
	/// <summary>
	/// Description of EntradaLeyendaTematica.
	/// </summary>
	public class EntradaLeyendaTematica
		: EntradaLeyendaBD
	{
		public enum TipoOrdenacion
		{
			Ascendente,
			Descendente,
			Ninguna
		}

		private TipoOrdenacion _ordenacion = TipoOrdenacion.Ninguna;
		public TipoOrdenacion Ordenacion
		{
			get
			{
				return _ordenacion;
			}
			set
			{
				_ordenacion = value;
			}
		}
		private List<SubEntradaLeyendaTematica> _items = new List<SubEntradaLeyendaTematica>();
		public List<SubEntradaLeyendaTematica> Items
		{
			get
			{
				return _items;
			}
		}
		
		public void AgregarSubEntrada(SubEntradaLeyendaTematica entrada)
		{
			bool cancel = false;
			foreach (SubEntradaLeyendaTematica el in _items)
			{
				if (el.UID == entrada.UID)
				{
					cancel = true;
					break;
				}
			}
			if (!cancel) _items.Add(entrada);
		}
		
		public void Reiniciar()
		{
			_items.Clear();
		}		
		
		public EntradaLeyendaTematica(string uid, VectorLayer capa, string titulo, TipoOrdenacion ordenacion)
			: base(uid, capa, titulo)
		{
			_ordenacion = ordenacion;
		}
		
		public override int Render(Graphics g, int x, int y, int ancho, int alto, Font fuente, Brush colorFuente, int xTitulo, int yTitulo)
		{
			//int pos = 0;
			int posX = 0;
			int posY = y;
			
		    g.FillRectangle(new SolidBrush(Color.Red), x, y, ancho / 2, alto / 2);
		    g.FillRectangle(new SolidBrush(Color.Yellow), x + (ancho / 2), y, ancho/2, alto/2);
		    g.FillRectangle(new SolidBrush(Color.Lime), x, y + (alto / 2), ancho / 2, alto / 2);
		    g.FillRectangle(new SolidBrush(Color.Orange), x + (ancho / 2), y + (alto / 2), ancho / 2, alto / 2);
	     	g.DrawString(base.Titulo, fuente, colorFuente, xTitulo, yTitulo);
	     	
	     	if (_ordenacion == TipoOrdenacion.Ascendente || _ordenacion == TipoOrdenacion.Descendente)
	     	{
	     		_items.Sort();
	     		if (_ordenacion == TipoOrdenacion.Descendente) _items.Reverse();
	     	}

			posX = x + Constantes.indentacion;
			foreach (SubEntradaLeyendaTematica subEl in _items)
			{
			    //posY = y + (++pos * Constantes.distCuadroV);
			    posY += Constantes.distCuadroV;
			    subEl.Render(g, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro, fuente, Constantes.colorFuente, posX + Constantes.distCuadroLabel, posY);
			}
			return posY;
		}		
	}
}
