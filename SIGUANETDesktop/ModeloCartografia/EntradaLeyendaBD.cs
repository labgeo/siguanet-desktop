/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/10/2006
 * Time: 12:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using SharpMap.Layers;
using SIGUANETDesktop.ModeloCartografia.Simbologia;
namespace SIGUANETDesktop.ModeloCartografia
{
	/// <summary>
	/// Description of EntradaLeyendaBD.
	/// </summary>
	public class EntradaLeyendaBD
		: EntradaLeyenda	
	{
		public VectorLayer Capa
		{
			get
			{
				return (VectorLayer) base._capa;
			}
			set
			{
				base._capa = value;
			}
		}
		
		public EntradaLeyendaBD(string uid, VectorLayer capa, string titulo)
		{
			base._capa = capa;
			base.UID = uid;
			base.Titulo = titulo;
		}
		
		public override int Render(Graphics g, int x, int y, int ancho, int alto, Font fuente, Brush colorFuente, int xTitulo, int yTitulo)
		{
			VectorLayer capaV = (VectorLayer) base._capa;
		    g.DrawRectangle(capaV.Style.Outline, x, y, ancho, alto);
	     	g.FillRectangle(capaV.Style.Fill, x, y, ancho, alto);
	     	g.DrawString(base.Titulo, fuente, colorFuente, xTitulo, yTitulo);
	     	return y;
		}		
	}
}
