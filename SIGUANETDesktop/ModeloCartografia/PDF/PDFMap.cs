/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/11/2006
 * Time: 10:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using SharpMap;
using SharpMap.Styles;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.ModeloCartografia;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of PDFMap.
	/// </summary>
	public class PDFMap
	{
		private Map _Map;
		private List<object> _BindObjs;
		
		private SimpleLayout _layout = null;
		public SimpleLayout Layout 
		{
			get 
			{
				return _layout;
			}
		}
		
		public PDFMap(Map map, List<object> bindObjects, LayoutHelper.RunTimeTemplates template)
		{
			_BindObjs = bindObjects;
			_Map = map;
			_layout = LayoutHelper.GetDefaultLayout(template);
		}
		
		public void Render(XGraphics gfx)
		{
			foreach (Frame f in _layout.SimpleFrames) 
			{
				if (f.Visible) f.Draw(gfx);
			}
			
			foreach (Logo l in _layout.Logos)
			{
				l.Draw(gfx);
			}
			
			if (_Map != null)
			{
				_layout.MainMap.Draw(gfx, _Map);
			}
			
			foreach (TextField t in _layout.TextFields) {
				if (t is TextField)
				{
					(t as TextField).Draw(gfx);
				}
				if (t is DateStampField)
				{
					(t as DateStampField).Draw(gfx);
				}
				if (t is ParamField)
				{
					ParamField p = (ParamField)t;
					Type theType = Type.GetType(p.BindClassName);
					foreach (object obj in _BindObjs) 
					{
						if (object.ReferenceEquals(obj.GetType(), theType))
						{
							if (object.ReferenceEquals(theType, typeof(DataRow)))
							{
								DataRow dr = (DataRow)obj;
								if (!(dr[p.BindPropertyName] == null))
								{
									p.Draw(gfx, dr[p.BindPropertyName]);
									break;
								}
							}
							else if (object.ReferenceEquals(theType, typeof(DataRowView))) 
							{
								DataRowView drv = (DataRowView)obj;
								if (!(drv[p.BindPropertyName] == null))
								{
									p.Draw(gfx, drv[p.BindPropertyName]);
									break;
								}
							}
							else if (object.ReferenceEquals(theType, typeof(DataTable))) 
							{
								object val = this.GetValue((DataTable)obj, p.BindTableName, p.BindPropertyName, p.BindPropertyColumnName, p.BindValueColumnName);
								if (!(val == null))
								{
									p.Draw(gfx, val);
									break;
								}
							}
							else if (object.ReferenceEquals(theType, typeof(DataView))) 
							{
								object val = this.GetValue((obj as DataView).Table, p.BindTableName, p.BindPropertyName, p.BindPropertyColumnName, p.BindValueColumnName);
								if (!(val == null))
								{
									p.Draw(gfx, val);
									break;
								}
							}
							else if (object.ReferenceEquals(theType, typeof(string)))
							{
								p.Draw(gfx, obj);
								break;
							}
							else
							{
								//UN BUEN EJEMPLO SOBRE CÓMO USAR Reflection
								p.Draw(gfx, theType.InvokeMember(p.BindPropertyName, BindingFlags.GetProperty, null, obj, null));
								break;
							}
						}
					}
				}
			}
		}
		public void ChangeLayout(LayoutHelper.RunTimeTemplates template)
		{
				_layout = LayoutHelper.GetDefaultLayout(template);
		}
		
		public void ChangeLayout(string cfgFile)
		{
			SimpleLayout lyt = this.DeserializeLayout(cfgFile);
			if (lyt == null)
			{
				_layout = LayoutHelper.GetDefaultLayout(LayoutHelper.RunTimeTemplates.None);
			}
			else
			{
				_layout = lyt;
			}
		}
		
		public void Print(System.Drawing.Graphics g)
		{
			g.PageUnit = System.Drawing.GraphicsUnit.Point;
			XGraphics gfx = XGraphics.FromGraphics(g, XSize.FromSize(PageSizeConverter.ToSize(_layout.Size)));
			this.Render(gfx);
			gfx.Dispose();
		}
		
		public void PrintLegend(System.Drawing.Graphics g, Leyenda legend)
		{
				g.PageUnit = System.Drawing.GraphicsUnit.Point;
				XGraphics gfx = XGraphics.FromGraphics(g, XSize.FromSize(PageSizeConverter.ToSize(PageSize.A4)));
				this.CreateLegend(gfx, legend);
				gfx.Dispose();
		}
		
		public void Save(string path)
		{
			try 
			{
				PdfDocument document = new PdfDocument();
				PdfPage page = new PdfPage();
				page.Size = _layout.Size;
				page.Orientation = _layout.Orientation;
				document.AddPage(page);
				XGraphics gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Replace);
				this.Render(gfx);
				document.Save(path);
				gfx.Dispose();
			}
			catch (Exception ex) 
			{
				throw ex;
			}
		}
		
		public void Save(string path, Leyenda legend)
		{
			try 
			{
				PdfDocument document = new PdfDocument();
				PdfPage page = new PdfPage();
				page.Size = _layout.Size;
				page.Orientation = _layout.Orientation;
				document.AddPage(page);
				XGraphics gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Replace);
				this.Render(gfx);

				PdfPage pageL = new PdfPage();
				pageL.Size = PageSize.A4;
				pageL.Orientation = PageOrientation.Portrait;
				document.AddPage(pageL);
				gfx = XGraphics.FromPdfPage(pageL, XGraphicsPdfPageOptions.Replace);
				this.CreateLegend(gfx, legend);
								
				document.Save(path);
				gfx.Dispose();
			}
			catch (Exception ex) 
			{
				throw ex;
			}
		}		
		
		private SimpleLayout DeserializeLayout(string path)
		{
			XmlSerializer x = null;
			FileStream fs = null;
			XmlTextReader r = null;
			SimpleLayout lyt = null;
			try 
			{
				x = new XmlSerializer(typeof(SimpleLayout));
				fs = new FileStream(path, FileMode.Open);
				r = new XmlTextReader(fs);
				lyt = (SimpleLayout) x.Deserialize(r);
				r.Close();
				fs.Close();
			}
			catch (Exception ex) 
			{
				if (!(r == null)) r.Close();
				if (!(fs == null)) fs.Close();
				throw ex;
			}
			return lyt;
		}
		
		private object GetValue(DataTable dt, string tableName, string propertyName, string propertyFieldName, string valueFieldName)
		{
			object r = null;
			try 
			{
				if (tableName == dt.TableName)
				{
					foreach (DataRow dr in dt.Rows) {
						if ((dr[propertyFieldName]as string).Trim().ToUpper() == propertyName.Trim().ToUpper())
						{
							r = dr[valueFieldName];
							break;
						}
					}
				}
			}
			catch
			{
				//Do nothing (no render)
			}
			return r;
		}
		
		private void CreateLegend(XGraphics gfx, Leyenda legend)
		{
			PDFLegend pdfL = new PDFLegend();
			pdfL.Left = 1.5;
			pdfL.Top = 1.5;
			pdfL.MaxWidth = 18.0;
			pdfL.FrameVisible = true;
			pdfL.LegendTitleHeight = 1.0;
			pdfL.LegendTitle.FontFamilyName = "Tahoma";
			pdfL.LegendTitle.FontSize = 16.0;
			pdfL.LegendTitle.FontColorName = "Black";
			pdfL.LegendTitle.FontStyle = XFontStyle.BoldItalic;
			pdfL.LegendTitle.Text = "Leyenda";
			pdfL.EntryIndent = 1.0;
			pdfL.SubEntryIndent = 0.25;
			pdfL.SymbolWidth = 1.0;
			pdfL.SymbolHeight = 0.5;
			pdfL.FontFamilyName = "Tahoma";
			pdfL.FontSize = 10.0;
			pdfL.FontColorName = "Black";
			pdfL.FontStyle = XFontStyle.Bold;
			pdfL.TitleSpacing = 0.2;
			pdfL.Draw(gfx, legend);
		}
	}
}
