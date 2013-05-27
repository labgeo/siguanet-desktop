/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 28/09/2006
 * Time: 13:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;

namespace SIGUANETDesktop.ModeloCartografia.Simbologia
{

	
	public static class Constantes
	{

		public const int distPanelLeyenda = 20;
		public const int indentacion = 10;
		public const int anchoCuadro = 20;
		public const int altoCuadro = 15;
		public const int distCuadroLabel = anchoCuadro + 5;
		public const int distCuadroV = altoCuadro + 5;
		public const string familiaFuente = "Tahoma";
		public const int sizeFuente = 11;
		public const FontStyle estiloFuente = FontStyle.Regular;
		public static Brush colorFuente = Brushes.Black;
		public const GraphicsUnit unidadFuente = GraphicsUnit.World; 
	}
}
