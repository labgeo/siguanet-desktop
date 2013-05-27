/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 02/11/2006
 * Time: 13:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using PdfSharp;
using PdfSharp.Drawing;
using SharpMap.Geometries;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of TransformsProvider.
	/// </summary>

	public struct TransformsProvider
	{
		private double _widthCms;
		public double WidthCms 
		{
			get 
			{
				return _widthCms;
			}
		}
		
		private double _heightCms;
		public double HeightCms 
		{
			get 
			{
				return _heightCms;
			}
		}
		
		private double _widthPts;
		public double WidthPts 
		{
			get 
			{
				return _widthPts;
			}
		}
		private double _heightPts;
		public double HeightPts 
		{
			get 
			{
				return _heightPts;
			}
		}
		
		public TransformsProvider(XGraphics gfx)
		{
			this._widthCms = 0.0;
			this._heightCms = 0.0;
			this._widthPts = gfx.PageSize.Width;
			this._heightPts = gfx.PageSize.Height;
			switch (this.InferePageSize(gfx.PageSize)) 
			{
				case PdfSharp.PageSize.A4:
					switch (this.InferePageOrientation(gfx.PageSize)) 
					{
						case PdfSharp.PageOrientation.Portrait:
							this._widthCms = Sizes.A4P.Width;
							this._heightCms = Sizes.A4P.Height;
							break;
						case PdfSharp.PageOrientation.Landscape:
							this._widthCms = Sizes.A4L.Width;
							this._heightCms = Sizes.A4L.Height;
							break;
						default:
							this._widthCms = Sizes.A4P.Width;
							this._heightCms = Sizes.A4P.Height;
							break;
					}
					break;
				case PdfSharp.PageSize.A3:
					switch (this.InferePageOrientation(gfx.PageSize)) 
					{
						case PdfSharp.PageOrientation.Portrait:
							this._widthCms = Sizes.A3P.Width;
							this._heightCms = Sizes.A3P.Height;
							break;
						case PdfSharp.PageOrientation.Landscape:
							this._widthCms = Sizes.A3L.Width;
							this._heightCms = Sizes.A3L.Height;
							break;
						default:
							this._widthCms = Sizes.A3P.Width;
							this._heightCms = Sizes.A3P.Height;
							break;
					}
					break;
				default:
					switch (this.InferePageOrientation(gfx.PageSize)) 
					{
						case PdfSharp.PageOrientation.Portrait:
							this._widthCms = Sizes.A4P.Width;
							this._heightCms = Sizes.A4P.Height;
							break;
						case PdfSharp.PageOrientation.Landscape:
							this._widthCms = Sizes.A4L.Width;
							this._heightCms = Sizes.A4L.Height;
							break;
						default:
							this._widthCms = Sizes.A4P.Width;
							this._heightCms = Sizes.A4P.Height;
							break;
					}
					break;
			}
		}
		
		public XRect FromCmsToPts(XRect rect)
		{
			XRect r = new XRect(CmsToPts(rect.Left), CmsToPts(rect.Top), CmsToPts(rect.Width), CmsToPts(rect.Height));
			return r;
		}
		
		public double CmsToPts(double value)
		{
			double r = (value * this._widthPts) / this._widthCms;
			return r;
		}
		
		public double WorldToPaperScale(BoundingBox worldBox, XRect mapRect)
		{
			double scaleFactor = 0.0;
			if ((!this.IsInvalidBox(worldBox)) && (!this.IsInvalidBox(mapRect)))
			{
				try 
				{
					if (WorldBoxFitsPaperRect(worldBox, mapRect))
					{
						if (mapRect.Width >= mapRect.Height)
						{
							scaleFactor = mapRect.Width / worldBox.Width;
						}
						if (mapRect.Height >= mapRect.Width)
						{
							scaleFactor = mapRect.Height / worldBox.Height;
						}
					}
					else
					{
						if (mapRect.Width >= mapRect.Height)
						{
							scaleFactor = mapRect.Height / worldBox.Height;
						}
						if (mapRect.Height >= mapRect.Width)
						{
							scaleFactor = mapRect.Width / worldBox.Width;
						}
					}
				}
				catch (Exception ex) 
				{
					throw ex;
				}
			}
			return scaleFactor;
		}
		
		public XRect WorldToPaperRect(BoundingBox worldBox, XRect mapRect)
		{
			XRect r = XRect.Empty;
			double scaleFactor = 0.0;
			double x = 0.0;
			double y = 0.0;
			double w = 0.0;
			double h = 0.0;
			if ((!this.IsInvalidBox(worldBox)) && (!this.IsInvalidBox(mapRect)))
			{
				try 
				{
					if (WorldBoxFitsPaperRect(worldBox, mapRect))
					{
						if (mapRect.Width >= mapRect.Height)
						{
							scaleFactor = mapRect.Width / worldBox.Width;
							w = mapRect.Width;
							x = mapRect.X;
							h = worldBox.Height * scaleFactor;
							y = mapRect.Y + ((mapRect.Height - h) / 2);
						}
						if (mapRect.Height >= mapRect.Width)
						{
							scaleFactor = mapRect.Height / worldBox.Height;
							w = worldBox.Width * scaleFactor;
							x = mapRect.X + ((mapRect.Width - w) / 2);
							h = mapRect.Height;
							y = mapRect.Y;
						}
					}
					else
					{
						if (mapRect.Width >= mapRect.Height)
						{
							scaleFactor = mapRect.Height / worldBox.Height;
							w = worldBox.Width * scaleFactor;
							x = mapRect.X + ((mapRect.Width - w) / 2);
							h = mapRect.Height;
							y = mapRect.Y;
						}
						if (mapRect.Height >= mapRect.Width)
						{
							scaleFactor = mapRect.Width / worldBox.Width;
							w = mapRect.Width;
							x = mapRect.X;
							h = worldBox.Height * scaleFactor;
							y = mapRect.Y + ((mapRect.Height - h) / 2);
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			r = new XRect(x, y, w, h);
			return r;
		}
		
		private bool IsInvalidBox(BoundingBox b)
		{
			return ((b.Width == 0) || (b.Height == 0));
		}
		
		private bool IsInvalidBox(XRect b)
		{
			return ((b.Width == 0) || (b.Height == 0));
		}		
		
		private bool WorldBoxFitsPaperRect(BoundingBox box, XRect rect)
		{
			double worldRatio = box.Width / box.Height;
			double paperRatio = rect.Width / rect.Height;
			if ((rect.Width <= rect.Height))
			{
				return (worldRatio <= paperRatio);
			}
			else
			{
				return (worldRatio >= paperRatio);
			}
		}
		
		public XPoint TransformGeom(double sf, SharpMap.Geometries.Point geom, BoundingBox geomBox)
		{
			double xmin = geomBox.Left;
			double ymin = geomBox.Bottom;
			return new XPoint((geom.X - xmin) * sf, -(geom.Y - ymin) * sf);
		}
		
		public XGraphicsPath TransformGeom(double sf, LineString geom, BoundingBox geomBox)
		{
			double xmin = geomBox.Left;
			double ymin = geomBox.Bottom;
			XGraphicsPath xgp = new XGraphicsPath();
			int i = 0;
			XPoint[] listXPoints = new XPoint[geom.Vertices.Count];
			foreach (Point p in geom.Vertices) 
			{
				//XPoint pCopy = new XPoint((p.X - xmin) * sf, -(p.Y - ymin) * sf);
				XPoint pCopy = TransformGeom(sf, p, geomBox);
				listXPoints[i++] = pCopy;
			}
			xgp.AddLines(listXPoints);
			return xgp;
		}
		
		public XGraphicsPath TransformGeom(double sf, Polygon geom, BoundingBox geomBox)
		{
			double xmin = geomBox.Left;
			double ymin = geomBox.Bottom;
			XGraphicsPath xgp = new XGraphicsPath();
			int i = 0;
			XPoint[] listXPoints = new XPoint[geom.ExteriorRing.Vertices.Count];
			foreach (Point p in geom.ExteriorRing.Vertices) 
			{
				//XPoint pCopy = new XPoint((p.X - xmin) * sf, -(p.Y - ymin) * sf);
				XPoint pCopy = TransformGeom(sf, p, geomBox);
				listXPoints[i++] = pCopy;
			}
			xgp.AddPolygon(listXPoints);
			
			foreach (LinearRing r in geom.InteriorRings)
			{
				i = 0;
				listXPoints = new XPoint[r.Vertices.Count];
				foreach (Point p in r.Vertices)
				{
					//XPoint pCopy = new XPoint((p.X - xmin) * sf, -(p.Y - ymin) * sf);
					XPoint pCopy = TransformGeom(sf, p, geomBox);
					listXPoints[i++] = pCopy;
				}
				xgp.AddPolygon(listXPoints);
			}
			return xgp;
		}		
		
		public XGraphicsPath TransformGeom(double sf, MultiLineString geom, BoundingBox geomBox)
		{
			XGraphicsPath xgp = new XGraphicsPath();
			foreach (LineString ls in (geom as MultiLineString).LineStrings) 
			{
				xgp.AddPath(TransformGeom(sf, ls, geomBox), false);
			}
			return xgp;
		}
		
		public XGraphicsPath TransformGeom(double sf, MultiPolygon geom, BoundingBox geomBox)
		{
			XGraphicsPath xgp = new XGraphicsPath();
			foreach (Polygon pol in (geom as MultiPolygon).Polygons) 
			{
				xgp.AddPath(TransformGeom(sf, pol, geomBox), false);
			}
			return xgp;
		}
		
		private PageSize InferePageSize(XSize size)
		{
			System.Drawing.Size calcSize;
			PageSize inferredPS = PageSize.A4;
			foreach (PageSize ps in Enum.GetValues(typeof(PageSize))) 
			{
				if (ps != PageSize.Undefined)
				{
					calcSize = PageSizeConverter.ToSize(ps);
					if (calcSize.Width == size.Width && calcSize.Height == size.Height)
					{
						inferredPS = ps;
						break;
					}
					if (calcSize.Width == size.Height && calcSize.Height == size.Width)
					{
						inferredPS = ps;
						break;
					}
				}
			}
			return inferredPS;
		}
		
		private PageOrientation InferePageOrientation(XSize size)
		{
			if (size.Height >= size.Width)
			{
				return PageOrientation.Portrait;
			}
			else
			{
				return PageOrientation.Landscape;
			}
		}
	}
}
