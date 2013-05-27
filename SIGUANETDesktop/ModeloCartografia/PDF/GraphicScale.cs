/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 02/11/2006
 * Time: 14:33
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
	/// Description of GraphicScale.
	/// </summary>
	public class GraphicScale
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
		
		private double _x = 0.0;
		[XmlAttribute()]
		public double X 
		{
			get 
			{
				return _x;
			}
			set 
			{
				_x = value;
			}
		}
		
		private double _y = 0.0;
		[XmlAttribute()]
		public double Y 
		{
			get 
			{
				return _y;
			}
			set 
			{
				_y = value;
			}
		}
		
		private AnchorType _anchor = AnchorType.TopLeft;
		[XmlAttribute()]
		public AnchorType Anchor 
		{
			get 
			{
				return _anchor;
			}
			set 
			{
				_anchor = value;
			}
		}
		
		private double _intervalSize = 2.0;
		[XmlElement()]
		public double IntervalSize 
		{
			get 
			{
				return _intervalSize;
			}
			set 
			{
				_intervalSize = value;
			}
		}
		
		private int _numIntervals = 5;
		[XmlElement()]
		public int NumIntervals 
		{
			get 
			{
				return _numIntervals;
			}
			set 
			{
				_numIntervals = value;
			}
		}
		
		private string _fillColorName = "Black";
		[XmlAttribute()]
		public string FillColorName 
		{
			get 
			{
				return _fillColorName;
			}
			set 
			{
				_fillColorName = value;
			}
		}
		private string _unit = "m";
		[XmlElement()]
		public string Unit 
		{
			get 
			{
				return _unit;
			}
			set 
			{
				_unit = value;
			}
		}
		private double _height = 5.0;
		[XmlAttribute()]
		public double Height 
		{
			get 
			{
				return _height;
			}
			set 
			{
				_height = value;
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
		
		private double _fontSize = 6.0;
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
		
		private XFontStyle _fontStyle = XFontStyle.Bold;
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
		
		private string _fontColorName = "Black";
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
		
		public GraphicScale()
		{
		}
		
		public void Draw(XGraphics gfx, double mapSF)
		{
			if (_visible)
			{
				TransformsProvider tp = new TransformsProvider(gfx);
				double x = 0.0;
				double y = 0.0;
				double width = this._intervalSize * mapSF;
				XBrush fillColor = new XSolidBrush(XColor.FromName(this._fillColorName));
				XFont font = new XFont(_fontFamilyName, _fontSize, _fontStyle);
				XBrush fontColor = new XSolidBrush(XColor.FromName(this._fontColorName));
				XRect firstInterval = XRect.Empty;
				switch (Anchor) {
					case AnchorType.TopLeft:
						x = tp.CmsToPts(this._x);
						y = tp.CmsToPts(_y) + font.Height;
						break;
					case AnchorType.BottomLeft:
						x = tp.CmsToPts(this._x);
						y = tp.CmsToPts(_y) - this._height;
						break;
					case AnchorType.TopRight:
						x = tp.CmsToPts(this._x) - (width * this._numIntervals) - (font.Size * 1.5) - ((this._unit.Length + 1) * font.Size);
						y = tp.CmsToPts(_y) + font.Height;
						break;
					case AnchorType.BottomRight:
						x = tp.CmsToPts(this._x) - (width * this._numIntervals) - (font.Size * 1.5) - ((this._unit.Length + 1)* font.Size);
						y = tp.CmsToPts(_y) - this._height;
						break;
					default:
						x = tp.CmsToPts(this._x);
						y = tp.CmsToPts(_y) - this._height;
						break;
				}
				for (int i = 0; i <= this._numIntervals - 1; i++) 
				{
					if (i == 0)
					{
						firstInterval = new XRect(x, y, width, this._height);
						gfx.DrawRectangle(new XPen(XColors.Black), firstInterval);
					}
					else
					{
						if (i % 2 == 0)
						{
							gfx.DrawRectangle(new XPen(XColors.Black), x + (width * i), y, width, this._height);
						}
						else
						{
							gfx.DrawRectangle(new XPen(XColors.Black), fillColor, x + (width * i), y, width, this._height);
						}
					}
				}
				x = firstInterval.Left;
				y = firstInterval.Top - font.Height;
				for (int i = 1; i <= this._numIntervals; i++) {
					gfx.DrawString((this._intervalSize * i).ToString(), font, fontColor, x + (width * i), y, XStringFormat.TopCenter);
				}
				gfx.DrawString(this._unit, font, fontColor, x + (width * this._numIntervals) + (font.Size * 1.5), y, XStringFormat.TopLeft);
			}
		}
	}
}
