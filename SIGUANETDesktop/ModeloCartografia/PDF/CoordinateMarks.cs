/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 02/11/2006
 * Time: 14:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using PdfSharp.Drawing;
using SharpMap.Geometries;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of CoordinateMarks.
	/// </summary>
	public class CoordinateMarks
	{
		private bool _visible = true;
		[XmlElement()]
		public bool Visible 
		{
			get 
			{
				return _visible;
			}
			set 
			{
				_visible = value;
			}
		}
		
		private string _fontFamilyName = "Verdana";
		[XmlAttribute()]
		public string FontFamilyName 
		{
			get 
			{
				return _fontFamilyName;
			}
			set 
			{
				_fontFamilyName = value;
			}
		}
		
		private double _fontSize = 5.0;
		[XmlAttribute()]
		public double FontSize 
		{
			get 
			{
				return _fontSize;
			}
			set 
			{
				_fontSize = value;
			}
		}
		
		private XFontStyle _fontStyle = XFontStyle.Regular;
		[XmlAttribute()]
		public XFontStyle FontStyle 
		{
			get 
			{
				return _fontStyle;
			}
			set 
			{
				_fontStyle = value;
			}
		}
		
		private string _fontColorName = "Gray";
		[XmlAttribute()]
		public string FontColorName 
		{
			get 
			{
				return _fontColorName;
			}
			set 
			{
				_fontColorName = value;
			}
		}
		
		private string _tickColorName = "Gray";
		[XmlAttribute()]
		public string TickColorName 
		{
			get 
			{
				return _tickColorName;
			}
			set 
			{
				_tickColorName = value;
			}
		}
		
		public CoordinateMarks()
		{
		}
		
		public void Draw(XGraphics gfx, BoundingBox geombox, XRect mapframe)
		{
			if (this._visible)
			{
				TransformsProvider tp = new TransformsProvider(gfx);
				double geomScaleFactor = tp.WorldToPaperScale(geombox, mapframe);
				XRect geomFrame = tp.WorldToPaperRect(geombox, mapframe);
				double mapWorldXmin = geombox.Left - ((geomFrame.Left - mapframe.Left) / geomScaleFactor);
				double mapWorldYmin = geombox.Bottom - ((mapframe.Bottom - geomFrame.Bottom) / geomScaleFactor);
				double mapWorldXmax = geombox.Right + ((mapframe.Right - geomFrame.Right) / geomScaleFactor);
				double mapWorldYmax = geombox.Top + ((geomFrame.Top - mapframe.Top) / geomScaleFactor);
				XFont font = new XFont(this._fontFamilyName, this._fontSize, this._fontStyle);
				XBrush fontColor = new XSolidBrush(XColor.FromName(this._fontColorName));
				XColor tickColor = XColor.FromName(this._tickColorName);
				gfx.DrawString(mapWorldXmin.ToString("0.00"), font, fontColor, mapframe.Left, mapframe.Top - (this._fontSize / 2), XStringFormat.BottomCenter);
				gfx.DrawString(mapWorldXmin.ToString("0.00"), font, fontColor, mapframe.Left, mapframe.Bottom + (this._fontSize / 2), XStringFormat.TopCenter);
				gfx.DrawString(mapWorldXmax.ToString("0.00"), font, fontColor, mapframe.Right, mapframe.Top - (this._fontSize / 2), XStringFormat.BottomCenter);
				gfx.DrawString(mapWorldXmax.ToString("0.00"), font, fontColor, mapframe.Right, mapframe.Bottom + (this._fontSize / 2), XStringFormat.TopCenter);
				gfx.DrawString(mapWorldYmin.ToString("0.00"), font, fontColor, mapframe.Left, mapframe.Bottom - (this._fontSize / 2), XStringFormat.BottomCenter);
				gfx.DrawString(mapWorldYmin.ToString("0.00"), font, fontColor, mapframe.Right, mapframe.Bottom - (this._fontSize / 2), XStringFormat.BottomCenter);
				gfx.DrawString(mapWorldYmax.ToString("0.00"), font, fontColor, mapframe.Left, mapframe.Top + (this._fontSize / 2), XStringFormat.TopCenter);
				gfx.DrawString(mapWorldYmax.ToString("0.00"), font, fontColor, mapframe.Right, mapframe.Top + (this._fontSize / 2), XStringFormat.TopCenter);
				gfx.DrawLine(new XPen(tickColor), mapframe.Left - (this._fontSize / 2), mapframe.Top, mapframe.Left + (this._fontSize / 2), mapframe.Top);
				gfx.DrawLine(new XPen(tickColor), mapframe.Left, mapframe.Top - (this._fontSize / 2), mapframe.Left, mapframe.Top + (this._fontSize / 2));
				gfx.DrawLine(new XPen(tickColor), mapframe.Right - (this._fontSize / 2), mapframe.Top, mapframe.Right + (this._fontSize / 2), mapframe.Top);
				gfx.DrawLine(new XPen(tickColor), mapframe.Right, mapframe.Top - (this._fontSize / 2), mapframe.Right, mapframe.Top + (this._fontSize / 2));
				gfx.DrawLine(new XPen(tickColor), mapframe.Left - (this._fontSize / 2), mapframe.Bottom, mapframe.Left + (this._fontSize / 2), mapframe.Bottom);
				gfx.DrawLine(new XPen(tickColor), mapframe.Left, mapframe.Bottom - (this._fontSize / 2), mapframe.Left, mapframe.Bottom + (this._fontSize / 2));
				gfx.DrawLine(new XPen(tickColor), mapframe.Right - (this._fontSize / 2), mapframe.Bottom, mapframe.Right + (this._fontSize / 2), mapframe.Bottom);
				gfx.DrawLine(new XPen(tickColor), mapframe.Right, mapframe.Bottom - (this._fontSize / 2), mapframe.Right, mapframe.Bottom + (this._fontSize / 2));

				//Algoritmo de cálculo de TickMarcks (4 intervalos)
				double sfX = mapframe.Width / (mapWorldXmax - mapWorldXmin);
				double tx = (mapWorldXmax - mapWorldXmin) / 4;
				double tx2 = tx + 10 - (tx % 10);
				double xtick = mapWorldXmin + tx2 - (mapWorldXmin % tx2);
				while (xtick < mapWorldXmax) {
					double xtickPts = mapframe.Left + ((xtick - mapWorldXmin) * sfX);
					//Control para evitar superposición de textos
					if ((xtickPts - mapframe.Left) > (this._fontSize * 9) & (mapframe.Right - xtickPts) > (this._fontSize * 9))
					{
						gfx.DrawLine(new XPen(tickColor), xtickPts, mapframe.Top - (this._fontSize / 2), xtickPts, mapframe.Top);
						gfx.DrawString(xtick.ToString("0"), font, fontColor, xtickPts, mapframe.Top - (_fontSize / 2), XStringFormat.BottomCenter);
						gfx.DrawLine(new XPen(tickColor), xtickPts, mapframe.Bottom + (this._fontSize / 2), xtickPts, mapframe.Bottom);
						gfx.DrawString(xtick.ToString("0"), font, fontColor, xtickPts, mapframe.Bottom + (this._fontSize / 2), XStringFormat.TopCenter);
					}
					xtick += tx2;
				}
				double sfY = mapframe.Height / (mapWorldYmax - mapWorldYmin);
				double ty = (mapWorldYmax - mapWorldYmin) / 4;
				double ty2 = ty + 10 - (ty % 10);
				double ytick = mapWorldYmin + ty2 - (mapWorldYmin % ty2);
				while (ytick < mapWorldYmax) 
				{
					double ytickPts = mapframe.Bottom - ((ytick - mapWorldYmin) * sfY);
					//Control para evitar superposición de textos
					if ((ytickPts - mapframe.Top) > (this._fontSize * 9) & (mapframe.Bottom - ytickPts) > (this._fontSize * 9))
					{
						gfx.DrawLine(new XPen(tickColor), mapframe.Left - (this._fontSize / 2), ytickPts, mapframe.Left, ytickPts);
						gfx.DrawString(ytick.ToString("0"), font, fontColor, mapframe.Left, ytickPts - (this._fontSize / 2), XStringFormat.BottomCenter);
						gfx.DrawLine(new XPen(tickColor), mapframe.Right + (this._fontSize / 2), ytickPts, mapframe.Right, ytickPts);
						gfx.DrawString(ytick.ToString("0"), font, fontColor, mapframe.Right, ytickPts - (this._fontSize / 2), XStringFormat.BottomCenter);
					}
					ytick += ty2;
				}
			}
		}		
	}
}
