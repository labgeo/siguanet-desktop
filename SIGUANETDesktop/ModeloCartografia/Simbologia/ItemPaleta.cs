/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 19/10/2006
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{
	/// <summary>
	/// Description of ItemPaleta.
	/// </summary>
	/// Se define una estructura (ItemPaleta) que deriva de IComparable (clase de .NET)
	public struct ItemPaleta : IComparable
	{
		/* Se definen las tres propiedades públicas: 
		- prioridad o peso (_prioridad), 
		- simbolo de línea (_SimbLinea) 
        - relleno(_simbRelleno).
		*/
		private int _prioridad;
		private Pen _simbLinea;
		private Brush _simbRelleno;
		
		public ItemPaleta(int prioridad, Pen simbLinea, Brush simbRelleno)
		{
			_prioridad = prioridad;
			_simbLinea = simbLinea;
			_simbRelleno = simbRelleno;
		}
		public int Prioridad
		{
			get { return _prioridad;}
			set { _prioridad = value;}
		}
		
		public Pen SimbLinea
		{
			get 
			{
				if (_simbLinea == null)
				{
					_simbLinea = new Pen(Color.Black);
				}
				return _simbLinea;
			}
			set
			{
				_simbLinea = value;
			}
		}
		
		public Brush SimbRelleno
		{
			get 
			{
				if (_simbRelleno == null)
				{
					_simbRelleno = new SolidBrush(Color.Transparent);
				}				
				return _simbRelleno;
			}
			set
			{
				_simbRelleno = value;
			}			
		}
		// Se sobrecarga el método CompareTo para que un objeto ItemPaleta sea comparado con otro ItemPaleta
		public int CompareTo(object obj)
		{
			if (obj is ItemPaleta)
			{
				ItemPaleta _itemP = (ItemPaleta) obj;
				return _prioridad.CompareTo(_itemP._prioridad);
			}
			else
                throw new ArgumentException("El objeto no es un ItemPaleta.");

		}
	}
}
