/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/10/2006
 * Time: 12:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using SharpMap.Layers;

namespace SIGUANETDesktop.ModeloCartografia
{
	/// <summary>
	/// Description of EntradaLeyenda.
	/// </summary>
	public abstract class EntradaLeyenda
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
		
		protected Layer _capa;
		
		public abstract int Render(Graphics g, int x, int y, int ancho, int alto, Font fuente, Brush colorFuente, int xTitulo, int yTitulo);
		
		public int CompareTo(object obj)
		{
			if (obj is EntradaLeyenda)
			{
				EntradaLeyenda el = (EntradaLeyenda) obj;
				return _uid.CompareTo(el._uid);
			}
			else
			{
                throw new ArgumentException("El objeto no es una Entrada de Leyenda.");
			}
		}		
	}
}
