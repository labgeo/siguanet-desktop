/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/11/2006
 * Time: 9:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using PdfSharp.Drawing;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of TextField.
	/// </summary>
	public class TextField
	{
		private string _name = "TextField";
		[XmlAttribute()]
		public string Name 
		{
			get 
			{
				return _name;
			}
			set 
			{
				_name = value;
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
		
		private XRect _rect = XRect.Empty;
		[XmlAttribute()]
		public XRect Rect
		{
			get
			{
				return _rect;
			}
			set
			{
				_rect = value;
			}
		}
		
		
		private XStringFormat _format = XStringFormat.Center;
		[XmlAttribute()]
		public XStringFormat Format
		{
			get
			{
				return _format;
			}
			set
			{
				_format = value;
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
		
		private double _fontSize = 10.0;
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
		
		private string _text = string.Empty;
		[XmlElement()]
		public string Text 
		{
			get 
			{
				return _text;
			}
			set 
			{
				_text = value;
			}
		}
		
		public TextField()
		{
		}
		
		public void Draw(XGraphics gfx)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			XFont font = new XFont(this._fontFamilyName, this._fontSize, this._fontStyle);
			XSolidBrush brush = new XSolidBrush(XColor.FromName(this._fontColorName));
			if (this._rect == XRect.Empty)
			{
				double x = tp.CmsToPts(this._x);
				double y = tp.CmsToPts(this._y);
				gfx.DrawString(this._text, font, brush, x, y, XStringFormat.TopLeft);
			}
			else
			{
				XRect rect = tp.FromCmsToPts(this._rect);
				gfx.DrawString(this._text, font, brush, rect, this._format);
			}
		}
	}
}
