/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 02/11/2006
 * Time: 14:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using PdfSharp.Drawing;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of Frame.
	/// </summary>
	public class Frame
	{
		private double _Top = 0.0;
		[XmlAttribute()]
		public double Top 
		{
			get 
			{
				return _Top;
			}
			set 
			{
				_Top = value;
			}
		}
		
		private double _Left = 0.0;
		[XmlAttribute()]
		public double Left 
		{
			get 
			{
				return _Left;
			}
			set 
			{
				_Left = value;
			}
		}
		
		private double _Width = 0.0;
		[XmlAttribute()]
		public double Width 
		{
			get 
			{
				return _Width;
			}
			set 
			{
				_Width = value;
			}
		}
		
		private double _Height = 0.0;
		[XmlAttribute()]
		public double Height 
		{
			get 
			{
				return _Height;
			}
			set 
			{
				_Height = value;
			}
		}
		
		[XmlIgnore()]
		public XRect Rect
		{
			get
			{
				return new XRect(this._Left, this._Top, this._Width, this._Height);
			}
		}
		
		private string _lineColorName = "Black";
		[XmlAttribute()]
		public string LineColorName 
		{
			get 
			{
				return _lineColorName;
			}
			set 
			{
				_lineColorName = value;
			}
		}
		
		private double _lineWidth = 1;
		[XmlAttribute()]
		public double LineWidth 
		{
			get 
			{
				return _lineWidth;
			}
			set 
			{
				_lineWidth = value;
			}
		}
		
		private string _fillColorName = "Transparent";
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
		
		private bool _visible = true;
		[XmlAttribute()]
		public bool Visible
		{
			get
			{
				return this._visible;
			}
			set
			{
				_visible = value;
			}
		}
				
		public Frame()
		{
		}
		
		public void Draw(XGraphics gfx)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			XRect rect = tp.FromCmsToPts(new XRect(_Left, _Top, _Width, _Height));
			if (this._fillColorName == Color.Transparent.Name)
			{
				gfx.DrawRectangle(new XPen(XColor.FromName(_lineColorName), _lineWidth), rect);
			}
			else
			{
				gfx.DrawRectangle(new XPen(XColor.FromName(_lineColorName), _lineWidth), new XSolidBrush(XColor.FromName(_fillColorName)), rect);
			}
		}		
	}
}
