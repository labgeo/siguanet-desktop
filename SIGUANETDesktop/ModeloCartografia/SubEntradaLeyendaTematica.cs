/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 26/10/2006
 * Time: 9:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using SharpMap.Styles;

namespace SIGUANETDesktop.ModeloCartografia
{
	/// <summary>
	/// Description of SubEntradaLeyendaTematica.
	/// </summary>
	public class SubEntradaLeyendaTematica
		: IComparable
	{
		private string _uid = string.Empty;
		public string UID
		{
			get
			{
				return _uid;
			}
			set
			{
				_uid = value;
			}
		}
		
		private string _titulo = string.Empty;
		public string Titulo
		{
			get
			{
				return _titulo;
			}
			set
			{
				if (value != null) _titulo = value;
			}
		}
		
		private object _valorTematico = null;
		public object ValorTematico
		{
			get
			{
				return _valorTematico;
			}
			set
			{
				_valorTematico = value;
			}
		}
		
		private object _valorOrdenacion = null;
		public object ValorOrdenacion
		{
			get
			{
				return _valorOrdenacion;
			}
			set
			{
				_valorOrdenacion = value;
			}
		}
		
		private Pen _simbLinea = new Pen(Color.Black);
		public Pen SimbLinea
		{
			get
			{
				return _simbLinea;
			}
			set
			{
				_simbLinea = value;
			}
		}
		
		private Brush _simbRelleno = Brushes.Gray;
		public Brush SimbRelleno
		{
			get
			{
				return _simbRelleno;
			}
			set
			{
				_simbRelleno = value;
			}
		}		
		public SubEntradaLeyendaTematica(string uid, VectorStyle simb, object valorTematico, object valorOrdenacion, string titulo)
		{
			_uid = uid;
			_simbLinea = simb.Outline;
			_simbRelleno = simb.Fill;
			_valorTematico = valorTematico;
			_valorOrdenacion = valorOrdenacion;
			_titulo = titulo;
		}
		
		public void Render(Graphics g, int x, int y, int ancho, int alto, Font fuente, Brush colorFuente, int xTitulo, int yTitulo)
		{
		    g.DrawRectangle(_simbLinea, x, y, ancho, alto);
	     	g.FillRectangle(_simbRelleno, x, y, ancho, alto);
	     	g.DrawString(_titulo, fuente, colorFuente, xTitulo, yTitulo);
		}		
		
		public int CompareTo(object obj)
		{
			if (obj is SubEntradaLeyendaTematica)
			{
				SubEntradaLeyendaTematica el = (SubEntradaLeyendaTematica) obj;
				if (_valorOrdenacion is string)
				{
					return (_valorOrdenacion as string).CompareTo((string) el._valorOrdenacion);
				}
				else if (_valorOrdenacion is int)
				{
					int valor = (int) _valorOrdenacion;
					return valor.CompareTo((int) el._valorOrdenacion);
				}
				else if (_valorOrdenacion is double)
				{
					double valor = (double) _valorOrdenacion;
					return valor.CompareTo((double) el._valorOrdenacion);
				}
				else
				{
					return 0;
				}
			}
			else
			{
                throw new ArgumentException("El objeto no es una SubEntrada de Leyenda Temática.");
			}
		}		
	}
}
