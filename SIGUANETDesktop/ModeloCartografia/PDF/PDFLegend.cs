/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 15/11/2006
 * Time: 12:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using PdfSharp.Drawing;
using SharpMap.Styles;
using System.Xml.Serialization;
using SIGUANETDesktop.ModeloCartografia;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of PDFLegend.
	/// </summary>
	public class PDFLegend
	{
		private double _maxWidth = 17;
		[XmlAttribute()]
		public double MaxWidth
		{
			get
			{
				return _maxWidth;
			}
			set
			{
				_maxWidth = value;
				
			}
		}
		
		private double _left = 1.5;
		[XmlAttribute()]
		public double Left
		{
			get
			{
				return _left;
			}
			set
			{
				_left = value;
			}
		}
		
		private double _top = 1.5;
		[XmlAttribute()]
		public double Top
		{
			get
			{
				return _top;
			}
			set
			{
				_top = value;
			}
		}		
		
		private TextField _legendTitle = new TextField();
		[XmlElement()]
		public TextField LegendTitle
		{
			get
			{
				return _legendTitle;
			}
			set
			{
				_legendTitle = value;
			}
		}
		
		private double _legendTitleHeight = 1.0;
		[XmlAttribute()]
		public double LegendTitleHeight
		{
			get
			{
				return _legendTitleHeight;
			}
			set
			{
				_legendTitleHeight = value;
			}
		}
		
		private string _defaultLegendTitleText = "Leyenda";
		[XmlAttribute()]
		public string DefaultLegendTitleText
		{
			get
			{
				return _defaultLegendTitleText;
			}
			set
			{
				_defaultLegendTitleText = value;
			}
		}		
		
		private double _symbolWidth = 0.75;
		[XmlAttribute()]
		public double SymbolWidth
		{
			get
			{
				return _symbolWidth;
			}
			set
			{
				_symbolWidth = value;
			}
		}
		
		private double _symbolHeight = 0.5;
		[XmlAttribute()]
		public double SymbolHeight
		{
			get
			{
				return _symbolHeight;
			}
			set
			{
				_symbolHeight = value;
			}
		}
		
		private double _titleSpacing = 0.15;
		[XmlAttribute()]
		public double TitleSpacing
		{
			get
			{
				return _titleSpacing;
			}
			set
			{
				_titleSpacing = value;
			}
		}
		
		private double _entryIndent = 0.25;
		[XmlAttribute()]
		public double EntryIndent
		{
			get
			{
				return _entryIndent;
			}
			set
			{
				_entryIndent = value;
			}
		}		
		
		private double _subentryIndent = 0.25;
		[XmlAttribute()]
		public double SubEntryIndent
		{
			get
			{
				return _subentryIndent;
			}
			set
			{
				_subentryIndent = value;
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
		
		private bool _frameVisible = true;
		[XmlAttribute()]
		public bool FrameVisible
		{
			get
			{
				return _frameVisible;
			}
			set
			{
				_frameVisible = value;				
			}
		}
		
		public PDFLegend()
		{
		}
		
		public void Draw(XGraphics gfx, Leyenda legend)
		{
			this.DrawLegendTitle(gfx);
			double y = this._top + this._legendTitleHeight;
			foreach (EntradaLeyenda le in legend.Items)
			{
				this.DrawLegendEntry(gfx, ref y, le);
				
			}
			if (legend.EntradaConsulta != null)
			{
				this.DrawLegendEntry(gfx, ref y, legend.EntradaConsulta);
			}
			if (legend.EntradaSeleccion != null)
			{
				this.DrawLegendEntry(gfx, ref y, legend.EntradaSeleccion);
			}
			if (legend.EntradaInformacion != null)
			{
				this.DrawLegendEntry(gfx, ref y, legend.EntradaInformacion);
			}			
			
			if (this._frameVisible)
			{
				Frame f = new Frame();
				f.Left = this._left;
				f.Top = this._top;
				f.Width = this._maxWidth;
				f.Height = (y + (this._symbolHeight / 2)) - this._top;
				f.Draw(gfx);				
			}

		}
		
		private void DrawLegendTitle(XGraphics gfx)
		{
			Frame fLegendTitle = new Frame();
			fLegendTitle.Left = this._left;
			fLegendTitle.Top = this._top;
			fLegendTitle.Width = this._maxWidth;
			fLegendTitle.Height = this._legendTitleHeight;
			if (this._legendTitle.Text == string.Empty) this._legendTitle.Text = this._defaultLegendTitleText;
			this._legendTitle.Rect = fLegendTitle.Rect;
			this._legendTitle.Draw(gfx);
		}
		
		private void DrawLegendEntry(XGraphics gfx, ref double yPos, EntradaLeyenda le)
		{
			
			string lineColor = Color.Black.Name;
			double lineWidth = 1.0;
			string fillColor = Color.Transparent.Name;
			
			if (le is EntradaLeyendaTematica)
			{
				double x = this._left + this._entryIndent;
				double y = yPos;
				Frame fAux = new Frame();
				fAux.Width = this._symbolWidth / 2;
				fAux.Height = this._symbolHeight / 2;
				fAux.Left = x;
				fAux.Top = y;
				fAux.FillColorName = fAux.LineColorName = Color.Red.Name;
				fAux.Draw(gfx);
				fAux.Left = x + (this._symbolWidth / 2);
				fAux.Top = y;
				fAux.FillColorName = fAux.LineColorName = Color.Yellow.Name;
				fAux.Draw(gfx);
				fAux.Left = x;
				fAux.Top = y + (this._symbolHeight / 2);
				fAux.FillColorName = fAux.LineColorName = Color.Lime.Name;
				fAux.Draw(gfx);
				fAux.Left = x + (this._symbolWidth / 2);
				fAux.Top = y + (this._symbolHeight / 2);
				fAux.FillColorName = fAux.LineColorName = Color.Orange.Name;
				fAux.Draw(gfx);
			}
			else if (le is EntradaLeyendaBD)
			{
				VectorStyle symb = (le as EntradaLeyendaBD).Capa.Style;
				lineColor = symb.Outline.Color.Name;
				lineWidth = symb.Outline.Width;
				if (symb.Fill is SolidBrush) fillColor = (symb.Fill as SolidBrush).Color.Name;
			}
			
			Frame fSymb = new Frame();
			fSymb.Left = this._left + this._entryIndent;
			fSymb.Top = yPos;
			fSymb.Width = this._symbolWidth;
			fSymb.Height = this._symbolHeight;
			fSymb.LineColorName = lineColor;
			fSymb.LineWidth = lineWidth;
			fSymb.FillColorName = fillColor;
			fSymb.Draw(gfx);			
			
			Frame fTitle = new Frame();
			fTitle.Left = fSymb.Left + fSymb.Width + this._titleSpacing;
			fTitle.Top = yPos;
			fTitle.Width = this._maxWidth - this._entryIndent - fSymb.Width - this._titleSpacing;
			fTitle.Height = fSymb.Height;

			TextField title = new TextField();
			title.Rect = fTitle.Rect;
			title.Format = XStringFormat.TopLeft;
			title.FontSize = this._fontSize;
			title.FontFamilyName = this._fontFamilyName;
			title.FontColorName = this._fontColorName;
			title.FontStyle = this._fontStyle;
			title.Text = le.Titulo;
			title.Draw(gfx);
			
			yPos += this._symbolHeight + (this._symbolHeight / 2);
			
			if (le is EntradaLeyendaTematica)
			{
				foreach (SubEntradaLeyendaTematica sle in (le as EntradaLeyendaTematica).Items)
				{
					this.DrawSubLegendEntry(gfx, ref yPos, sle);
				}
			}
		}
		
		private void DrawSubLegendEntry(XGraphics gfx, ref double yPos, SubEntradaLeyendaTematica sle)
		{
			string lineColor = Color.Black.Name;
			double lineWidth = 1.0;
			string fillColor = Color.Transparent.Name;
							
			lineColor = sle.SimbLinea.Color.Name;
			lineWidth = sle.SimbLinea.Width;
			if (sle.SimbRelleno is SolidBrush) fillColor = (sle.SimbRelleno as SolidBrush).Color.Name;
									
			Frame fSymb = new Frame();
			fSymb.Left = this._left + this._entryIndent + this._subentryIndent;
			fSymb.Top = yPos;
			fSymb.Width = this._symbolWidth;
			fSymb.Height = this._symbolHeight;
			fSymb.LineColorName = lineColor;
			fSymb.LineWidth = lineWidth;
			fSymb.FillColorName = fillColor;			
			fSymb.Draw(gfx);

			Frame fTitle = new Frame();
			fTitle.Left = fSymb.Left + fSymb.Width + this._titleSpacing;
			fTitle.Top = yPos;
			fTitle.Width = this._maxWidth - (this._entryIndent + this._subentryIndent) - fSymb.Width - this._titleSpacing;
			fTitle.Height = fSymb.Height;

			TextField title = new TextField();
			title.Rect = fTitle.Rect;
			title.Format = XStringFormat.TopLeft;
			title.FontSize = this._fontSize;
			title.FontFamilyName = this._fontFamilyName;
			title.FontColorName = this._fontColorName;
			title.FontStyle = this._fontStyle;
			title.Text = sle.Titulo;
			title.Draw(gfx);
			
			yPos += this._symbolHeight + (this._symbolHeight / 2);
		}		
	}
}
