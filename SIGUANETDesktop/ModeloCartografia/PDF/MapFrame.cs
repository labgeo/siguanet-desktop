/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 02/11/2006
 * Time: 14:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using PdfSharp.Drawing;
using SharpMap;
using SharpMap.Layers;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Styles;
using SharpMap.Geometries;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of MapFrame.
	/// </summary>
	public class MapFrame
		: Frame
	{
		private struct PDFGeom
		{
			public readonly XGraphicsPath Geometry;
			public readonly XPen LineStyle;
			public readonly XBrush FillStyle;
			
			public PDFGeom(XGraphicsPath geometry, XPen lineStyle, XBrush fillStyle)
			{
				this.Geometry = geometry;
				this.LineStyle = lineStyle;
				this.FillStyle = fillStyle;
			}
		}
		
		private struct PDFLabel
		{
			public readonly string Text;
			public readonly XPoint Point;
			public readonly XFont Font;
			public readonly XBrush Brush;
			
			public PDFLabel(string text, XPoint point, XFont font, XBrush brush)
			{
				this.Text = text;
				this.Point = point;
				this.Font = font;
				this.Brush = brush;
			}
		}
		
		//Cache de geometría
		private Collection<PDFGeom> _geomCache = new Collection<PDFGeom>();
		//Cache de etiquetas
		private Collection<PDFLabel> _labelCache = new Collection<PDFLabel>();
		
		private bool _cacheIsEmpty = true;
		
		private string _geomLineColorName = "Black";
		[XmlAttribute()]
		public string GeomLineColorName 
		{
			get 
			{
				return _geomLineColorName;
			}
			set 
			{
				_geomLineColorName = value;
			}
		}
		
		private double _geomLineWidth = 1;
		[XmlAttribute()]
		public double GeomLineWidth 
		{
			get 
			{
				return _geomLineWidth;
			}
			set 
			{
				_geomLineWidth = value;
			}
		}
		
		private string _geomFillColorName = "Transparent";
		[XmlAttribute()]
		public string GeomFillColorName 
		{
			get 
			{
				return _geomFillColorName;
			}
			set 
			{
				_geomFillColorName = value;
			}
		}
		
		private string _labelFontFamilyName = "Verdana";
		[XmlAttribute()]
		public string LabelFontFamilyName 
		{
			get 
			{
				return _labelFontFamilyName;
			}
			set 
			{
				_labelFontFamilyName = value;
			}
		}
		
		private double _labelFontSize = 7.0;
		[XmlAttribute()]
		public double LabelFontSize 
		{
			get 
			{
				return _labelFontSize;
			}
			set 
			{
				_labelFontSize = value;
			}
		}		
		
		private XFontStyle _labelFontStyle = XFontStyle.Regular;
		[XmlAttribute()]
		public XFontStyle LabelFontStyle
		{
			get
			{
				return _labelFontStyle;
			}
			set
			{
				_labelFontStyle = value;
			}
		}
		
		private string _labelFontColorName = "Black";
		[XmlAttribute()]
		public string LabelFontColorName 
		{
			get 
			{
				return _labelFontColorName;
			}
			set 
			{
				_labelFontColorName = value;
			}
		}
		
		private bool _overrideVectorLayerStyle = false;
		[XmlAttribute()]
		public bool OverrideVectorLayerStyle 
		{
			get 
			{
				return _overrideVectorLayerStyle;
			}
			set 
			{
				_overrideVectorLayerStyle = value;
			}
		}
		
		private bool _overrideLabelLayerStyle = false;
		[XmlAttribute()]
		public bool OverrideLabelLayerStyle 
		{
			get 
			{
				return _overrideLabelLayerStyle;
			}
			set 
			{
				_overrideLabelLayerStyle = value;
			}
		}		
		
		private GraphicScale _scale = new GraphicScale();
		[XmlElement()]
		public GraphicScale Scale 
		{
			get 
			{
				return _scale;
			}
			set 
			{
				_scale = value;
			}
		}
		
		private CoordinateMarks _geomarks = new CoordinateMarks();
		[XmlElement()]
		public CoordinateMarks GeoMarks 
		{
			get 
			{
				return _geomarks;
			}
			set 
			{
				_geomarks = value;
			}
		}
		
		public MapFrame()
		{
		}
		
		public void SetFromFrame(Frame f, double marginPercentHorizontal, double marginPercentVertical)
		{
			base.Left = f.Left + ((marginPercentHorizontal * f.Width) / 100);
			base.Top = f.Top + ((marginPercentVertical * f.Height) / 100);
			base.Width = f.Width - ((2 * marginPercentHorizontal * f.Width) / 100);
			base.Height = f.Height -((2 * marginPercentVertical * f.Height) / 100);			
		}
		
		public void Draw(XGraphics gfx, Map map)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			XRect rect = tp.FromCmsToPts(new XRect(this.Left, this.Top, this.Width, this.Height));
			double geomScaleFactor;
			geomScaleFactor = tp.WorldToPaperScale(map.GetExtents(), rect);
			XRect geomFrame = tp.WorldToPaperRect(map.GetExtents(), rect);
			XGraphicsState state = gfx.Save();
			gfx.TranslateTransform(geomFrame.X, geomFrame.Bottom);			
			if (this._cacheIsEmpty)
			{
				foreach (Layer lyr in map.Layers) 
				{
					if ((lyr) is VectorLayer)
					{
						if (this._overrideVectorLayerStyle)
						{
							this.DrawVectorLayer(gfx, map, geomScaleFactor, (VectorLayer) lyr, this._geomLineColorName, this._geomLineWidth, this._geomFillColorName);
						}
						else
						{
							if ((lyr as VectorLayer).Theme == null)
							{
								this.DrawVectorLayer(gfx, map, geomScaleFactor, (VectorLayer) lyr);
							}
							else
							{
								this.DrawThemeLayer(gfx, map, geomScaleFactor, (VectorLayer) lyr);
								
							}
						}
					}
					if (lyr is LabelLayer)
					{
						if (this._overrideLabelLayerStyle)
						{
							this.DrawLabelLayer(gfx, map, geomScaleFactor, (LabelLayer) lyr, _labelFontFamilyName, _labelFontSize, _labelFontStyle, _labelFontColorName);
						}
						else
						{
							LabelStyle simb = (lyr as LabelLayer).Style;
							this.DrawLabelLayer(gfx, map, geomScaleFactor, (LabelLayer) lyr, simb.Font.FontFamily.Name, simb.Font.Size, (XFontStyle) simb.Font.Style, simb.ForeColor.Name);
						}
					}
				}
				this._cacheIsEmpty = false;
			}
			else
			{
				foreach(PDFGeom g in this._geomCache)
				{
					if (g.FillStyle == null) gfx.DrawPath(g.LineStyle, g.Geometry);
					else if (g.LineStyle == null) gfx.DrawPath(g.FillStyle, g.Geometry);
					else 
					gfx.DrawPath(g.LineStyle, g.FillStyle, g.Geometry);
				}
				foreach(PDFLabel l in this._labelCache)
				{
					gfx.DrawString(l.Text, l.Font, l.Brush, l.Point, XStringFormat.Center);
				}
			}
			
			gfx.Restore(state);
			_scale.Draw(gfx, geomScaleFactor);
			_geomarks.Draw(gfx, map.GetExtents(), rect);
		}
		
		private void DrawVectorLayer(XGraphics gfx, Map map, double scaleFactor, VectorLayer lyr, string lineColor, double lineWidth, string fillColor)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			BoundingBox geombox = map.GetExtents();
			
			XPen xp = new XPen(XColor.FromName(lineColor), lineWidth);
			XSolidBrush xb = new XSolidBrush(XColor.FromName(fillColor));
			
			foreach (Geometry geom in (lyr as VectorLayer).DataSource.GetGeometriesInView(geombox)) 
			{
				if ((geom) is MultiLineString)
				{
					XGraphicsPath g = tp.TransformGeom(scaleFactor, (MultiLineString)geom, geombox);
					this._geomCache.Add(new PDFGeom(g, xp, null));
					gfx.DrawPath(xp, g);
				}
				if ((geom) is MultiPolygon)
				{
					XGraphicsPath g = tp.TransformGeom(scaleFactor, (MultiPolygon)geom, geombox);
					this._geomCache.Add(new PDFGeom(g, xp, xb));
					gfx.DrawPath(xp, xb, g);
				}
			}						
		}
		
		private void DrawVectorLayer(XGraphics gfx, Map map, double scaleFactor, VectorLayer lyr)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			BoundingBox geombox = map.GetExtents();
			
			XPen xp = new XPen(XColor.FromArgb(lyr.Style.Outline.Color), lyr.Style.Outline.Width);
			xp.DashStyle = (XDashStyle) lyr.Style.Outline.DashStyle;
			XSolidBrush xb = null;
			
			foreach (Geometry geom in lyr.DataSource.GetGeometriesInView(geombox)) 
			{
				if (geom is MultiLineString)
				{
					XGraphicsPath g = tp.TransformGeom(scaleFactor, (MultiLineString)geom, geombox);
					this._geomCache.Add(new PDFGeom(g, xp, null));
					gfx.DrawPath(xp, g);					
				}
				if (geom is MultiPolygon)
				{
					XGraphicsPath g = tp.TransformGeom(scaleFactor, (MultiPolygon)geom, geombox);
					if (lyr.Style.EnableOutline)
					{
						if (lyr.Style.Fill != null)
						{
							if ((lyr.Style.Fill) is SolidBrush)
							{
								xb = new XSolidBrush(XColor.FromArgb((lyr.Style.Fill as SolidBrush).Color));								
							}
							else
							{
								xb = new XSolidBrush(XColor.FromKnownColor(KnownColor.Transparent));
							}
							this._geomCache.Add(new PDFGeom(g, xp, xb));
							gfx.DrawPath(xp, xb, g);
						}
						else
						{
							this._geomCache.Add(new PDFGeom(g, xp, null));
							gfx.DrawPath(xp, g);
						}
					}
					else
					{
						if (lyr.Style.Fill != null)
						{
							if ((lyr.Style.Fill) is SolidBrush)
							{
								xb = new XSolidBrush(XColor.FromArgb((lyr.Style.Fill as SolidBrush).Color));
							}
							else
							{
								xb = new XSolidBrush(XColor.FromKnownColor(KnownColor.Transparent));
							}							
							this._geomCache.Add(new PDFGeom(g, null, xb));
							gfx.DrawPath(xb, g);
						}
					}
				}
			}
		}
		
		private void DrawThemeLayer(XGraphics gfx, Map map, double scaleFactor, VectorLayer lyr)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			BoundingBox geombox = map.GetExtents();
			
			FeatureDataSet fds = new FeatureDataSet();
			try
			{
				lyr.DataSource.ExecuteIntersectionQuery(geombox, fds);
				FeatureDataTable fdt = fds.Tables[0];
				for (int i = 0; i < fdt.Count; i++)
				{
					FeatureDataRow fdr = fdt[i];
					VectorStyle s = (VectorStyle) lyr.Theme.GetStyle(fdr);
					Geometry geom = fdr.Geometry;
					XPen xp = new XPen(XColor.FromArgb(s.Outline.Color), s.Outline.Width);
					xp.DashStyle = (XDashStyle) s.Outline.DashStyle;
					XSolidBrush xb = null;
					if (geom is MultiLineString)
					{
						XGraphicsPath g = tp.TransformGeom(scaleFactor, (MultiLineString)geom, geombox);
						this._geomCache.Add(new PDFGeom(g, xp, null));
						gfx.DrawPath(xp, g);					
					}
					if (geom is MultiPolygon)
					{
						XGraphicsPath g = tp.TransformGeom(scaleFactor, (MultiPolygon)geom, geombox);
						if (s.Fill != null)
						{
							if ((s.Fill) is SolidBrush)
							{
								xb = new XSolidBrush(XColor.FromArgb((s.Fill as SolidBrush).Color));
							}
							else
							{
								xb = new XSolidBrush(XColor.FromKnownColor(KnownColor.Transparent));
							}
							this._geomCache.Add(new PDFGeom(g, xp, xb));
							gfx.DrawPath(xp, xb, g);
						}
						else
						{
							this._geomCache.Add(new PDFGeom(g, xp, null));
							gfx.DrawPath(xp, g);
						}
					}
				}							
			}
			catch
			{
				//Do nothing, no render
			}			
		}
		
		private void DrawLabelLayer(XGraphics gfx, Map map, double scaleFactor, LabelLayer lyr, string fontFamily, double fontSize, XFontStyle fontStyle, string fontColor)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			BoundingBox geombox = map.GetExtents();
			
			XFont font = new XFont(fontFamily, fontSize, fontStyle);
			XSolidBrush brush = new XSolidBrush(XColor.FromName(fontColor));
			
			FeatureDataSet fds = new FeatureDataSet();
			try
			{
				lyr.DataSource.ExecuteIntersectionQuery(geombox, fds);
				FeatureDataTable fdt = fds.Tables[0];
				for (int i = 0; i < fdt.Count; i++)
				{
					FeatureDataRow fdr = fdt[i];
					object s = string.Empty;
					if (lyr.LabelStringDelegate == null)
					{
						s = fdr[lyr.LabelColumn];
					}
					else
					{
						s = lyr.LabelStringDelegate(fdr);
					}
					
					Geometry geom = fdr.Geometry;
					if ((geom) is SharpMap.Geometries.Point)
					{
						XPoint p = tp.TransformGeom(scaleFactor, (SharpMap.Geometries.Point)geom, geombox);
						this._labelCache.Add(new PDFLabel(s.ToString(), p, font, brush));
						gfx.DrawString(s.ToString(), font, brush, p, XStringFormat.Center);
					}
				}							
			}
			catch
			{
				//Do nothing, no render
			}			
		}
	}
}
