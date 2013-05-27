/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/11/2006
 * Time: 10:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Collections.Generic;
using PdfSharp;
using PdfSharp.Drawing;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of LayoutHelper.
	/// </summary>
	public static class LayoutHelper
	{
		public enum RunTimeTemplates
		{
			None,
			BuiltInDINA4PortraitLayout,
			BuiltInDINA4LandscapeLayout,
		}
		
		public static SimpleLayout GetDefaultLayout(RunTimeTemplates sel)
		{
			SimpleLayout lyt = new SimpleLayout();
			Frame fEdif = new Frame();
			Frame fEdifCod = new Frame();
			Frame fPlanta = new Frame();
			Frame fEdifDenom = new Frame();
			Frame fTitulo = new Frame();
			Frame fLogoSIGUA = new Frame();
			Frame fMarco = new Frame();
			Frame fMapa = new Frame();
			Frame fPie = new Frame();
			Frame fSubPie = new Frame();
			Frame fLogoLABSIG = new Frame();
			TextField edif = new TextField();
			ParamField edifCod = new ParamField();
			ParamField planta = new ParamField();
			ParamField edifDenom = new ParamField();
			ParamField titulo = new ParamField();
			DateStampField fecha = new DateStampField();
			Logo logoSIGUA = new Logo();
			Logo logoLABSIG = new Logo();
			edif.Text = "edificio";
			titulo.Prefix = "CODIFICACIÓN DE ESTANCIAS -";
			fecha.Prefix = "Generado el";
			
			switch (sel) 
			{
				case RunTimeTemplates.BuiltInDINA4PortraitLayout:
					lyt.Size = PageSize.A4;
					lyt.Orientation = PageOrientation.Portrait;
					
					fEdif.Left = 2.3;
					fEdif.Top = 1.4;
					fEdif.Width = 1.6;
					fEdif.Height = 0.3;
					fEdif.LineColorName = "Black";
					fEdif.LineWidth = 1;					
					fEdif.FillColorName = "Black";
					lyt.SimpleFrames.Add(fEdif);
					
					fEdifCod.Left = fEdif.Left;
					fEdifCod.Top = fEdif.Top + fEdif.Height;
					fEdifCod.Width = fEdif.Width;
					fEdifCod.Height = 0.7;
					fEdif.LineColorName = "Black";
					fEdif.LineWidth = 1;
					lyt.SimpleFrames.Add(fEdifCod);					
					
					fPlanta.Left = fEdifCod.Left;
					fPlanta.Top = fEdifCod.Top + fEdifCod.Height;
					fPlanta.Width = fEdifCod.Width;
					fPlanta.Height = 0.4;
					fPlanta.LineColorName = "Black";
					fPlanta.LineWidth = 1;					
					fPlanta.FillColorName = "LightGray";
					lyt.SimpleFrames.Add(fPlanta);
					
					fEdifDenom.Left = 4.1;
					fEdifDenom.Top = 1.4;
					fEdifDenom.Width = 12.1;
					fEdifDenom.Height = 1.0;
					fEdifDenom.LineColorName = "Black";
					fEdifDenom.LineWidth = 1;					
					fEdifDenom.FillColorName = "Black";
					lyt.SimpleFrames.Add(fEdifDenom);
					
					fTitulo.Left = fEdifDenom.Left;
					fTitulo.Top = fEdifDenom.Top + fEdifDenom.Height;
					fTitulo.Width = fEdifDenom.Width;
					fTitulo.Height = 0.4;
					fTitulo.LineColorName = "Black";
					fTitulo.LineWidth = 1;					
					fTitulo.FillColorName = "LightGray";
					lyt.SimpleFrames.Add(fTitulo);
					
					fLogoSIGUA.Left = 16.3;
					fLogoSIGUA.Top = 1.4;
					fLogoSIGUA.Width = 2.7;
					fLogoSIGUA.Height = 1.4;
					fLogoSIGUA.LineColorName = "Black";
					fLogoSIGUA.LineWidth = 1;
					lyt.SimpleFrames.Add(fLogoSIGUA);

					fMarco.Left = 2.3;
					fMarco.Top = 3.1;
					fMarco.Width = 16.7;
					fMarco.Height = 25.2;
					fMarco.LineColorName = "Black";
					fMarco.LineWidth = 1;
					lyt.SimpleFrames.Add(fMarco);					
					
					fMapa.Left = 2.3;
					fMapa.Top = 3.1;
					fMapa.Width = 16.7;
					fMapa.Height = 23.8;
					fMapa.LineColorName = "Red";
					fMapa.LineWidth = 1;
					//NO VISIBLE
					fMapa.Visible = false;
					lyt.SimpleFrames.Add(fMapa);
					
					fPie.Left = fMapa.Left;
					fPie.Top = fMapa.Top + fMapa.Height;
					fPie.Width = fMapa.Width;
					fPie.Height = 1.4;
					fPie.LineColorName = "Red";
					fPie.LineWidth = 1;
					//NO VISIBLE
					fPie.Visible = false;
					lyt.SimpleFrames.Add(fPie);
					
					fSubPie.Left = fPie.Left;
					fSubPie.Top = fPie.Top + (fPie.Height / 2);
					fSubPie.Width = fPie.Width;
					fSubPie.Height = fPie.Height / 2;
					fSubPie.LineColorName = "Red";
					fSubPie.LineWidth = 1;
					//NO VISIBLE
					fSubPie.Visible = false;
					lyt.SimpleFrames.Add(fSubPie);
					
					fLogoLABSIG.Left = fPie.Left;
					fLogoLABSIG.Top = fPie.Top;
					fLogoLABSIG.Width = 3.5;
					fLogoLABSIG.Height = fPie.Height;
					fLogoLABSIG.LineColorName = "Red";
					fLogoLABSIG.LineWidth = 1;					
					//NO VISIBLE
					fLogoLABSIG.Visible = false;
					lyt.SimpleFrames.Add(fLogoLABSIG);					
					
					edif.Rect = fEdif.Rect;
					edif.FontFamilyName = "Verdana";
					edif.FontSize = 8.0;
					edif.FontStyle = XFontStyle.Bold;
					edif.FontColorName = "White";
					lyt.TextFields.Add(edif);
					
					edifCod.Rect = fEdifCod.Rect;
					edifCod.FontFamilyName = "Arial";
					edifCod.FontSize = 12.0;
					edifCod.FontStyle = XFontStyle.Bold;
					edifCod.FontColorName = "Black";
					edifCod.BindClassName = "SIGUANETDesktop.ModeloExplotacion.Espacios.Edificio";
					edifCod.BindPropertyName = "Codigo";
					lyt.TextFields.Add(edifCod);
					
					planta.Rect = fPlanta.Rect;
					planta.FontFamilyName = "Arial";
					planta.FontSize = 11.0;
					planta.FontStyle = XFontStyle.Bold;
					planta.FontColorName = "Black";
					planta.BindClassName = "SIGUANETDesktop.ModeloExplotacion.Espacios.PlantaEdificio";
					planta.BindPropertyName = "StringPlanta";
					lyt.TextFields.Add(planta);					
					
					edifDenom.Rect = fEdifDenom.Rect;
					edifDenom.FontFamilyName = "Arial";
					edifDenom.FontSize = 14.0;
					edifDenom.FontStyle = XFontStyle.Bold;
					edifDenom.FontColorName = "White";
					edifDenom.BindClassName = "SIGUANETDesktop.ModeloExplotacion.Espacios.Edificio";
					edifDenom.BindPropertyName = "Denominacion";
					lyt.TextFields.Add(edifDenom);
					
					titulo.Rect = fTitulo.Rect;
					titulo.FontFamilyName = "Arial";
					titulo.FontSize = 9.0;
					titulo.FontStyle = XFontStyle.Bold;
					titulo.FontColorName = "Black";
					titulo.BindClassName = "System.String";
					lyt.TextFields.Add(titulo);
					
					fecha.Rect = fSubPie.Rect;
					fecha.FontFamilyName = "Arial";
					fecha.FontSize = 7.0;
					fecha.FontStyle = XFontStyle.Regular;
					fecha.FontColorName = "Black";
					lyt.TextFields.Add(fecha);
					
					logoSIGUA.Rect = fLogoSIGUA.Rect;
					logoSIGUA.RscName = "SIGUANETDesktop.ModeloCartografia.PDF.LogoSIGUA.bmp";
					lyt.Logos.Add(logoSIGUA);
					
					logoLABSIG.Rect = fLogoLABSIG.Rect;
					logoLABSIG.RscName = "SIGUANETDesktop.ModeloCartografia.PDF.LogoLABSIG.bmp";
					lyt.Logos.Add(logoLABSIG);					
					
					//MainMap
					lyt.MainMap.SetFromFrame(fMapa, 1.5, 1.5);
					lyt.MainMap.OverrideVectorLayerStyle = false;
					lyt.MainMap.OverrideLabelLayerStyle = true;
					lyt.MainMap.LabelFontFamilyName = "Arial";
					lyt.MainMap.LabelFontSize = 6.0;
					lyt.MainMap.LabelFontColorName = "Black";
					lyt.MainMap.LabelFontStyle = XFontStyle.Regular;
					lyt.MainMap.Scale.Visible = true;
					lyt.MainMap.Scale.X = fPie.Left + fPie.Width;
					lyt.MainMap.Scale.Y = fPie.Top;
					lyt.MainMap.Scale.Anchor = AnchorType.TopRight;
					lyt.MainMap.Scale.Height = 7;
					lyt.MainMap.Scale.IntervalSize = 5.0;
					lyt.MainMap.Scale.NumIntervals = 4;
					lyt.MainMap.Scale.Unit = "m";
					lyt.MainMap.Scale.FillColorName = "Black";
					lyt.MainMap.Scale.FontFamilyName = "Verdana";
					lyt.MainMap.Scale.FontStyle = XFontStyle.Regular;
					lyt.MainMap.Scale.FontSize = 8;
					lyt.MainMap.Scale.FontColorName = "Black";
					lyt.MainMap.GeoMarks.Visible = false;					
					break;
				case RunTimeTemplates.BuiltInDINA4LandscapeLayout:
					lyt.Size = PageSize.A4;
					lyt.Orientation = PageOrientation.Landscape;

					fEdif.Left = 1.7;
					fEdif.Top = 1.7;
					fEdif.Width = 2.0;
					fEdif.Height = 0.3;
					fEdif.LineColorName = "Black";
					fEdif.LineWidth = 1;					
					fEdif.FillColorName = "Black";
					lyt.SimpleFrames.Add(fEdif);
					
					fEdifCod.Left = fEdif.Left;
					fEdifCod.Top = fEdif.Top + fEdif.Height;
					fEdifCod.Width = fEdif.Width;
					fEdifCod.Height = 0.7;
					fEdif.LineColorName = "Black";
					fEdif.LineWidth = 1;
					lyt.SimpleFrames.Add(fEdifCod);					
					
					fPlanta.Left = fEdifCod.Left;
					fPlanta.Top = fEdifCod.Top + fEdifCod.Height;
					fPlanta.Width = fEdifCod.Width;
					fPlanta.Height = 0.4;
					fPlanta.LineColorName = "Black";
					fPlanta.LineWidth = 1;					
					fPlanta.FillColorName = "LightGray";
					lyt.SimpleFrames.Add(fPlanta);
					
					fEdifDenom.Left = 3.9;
					fEdifDenom.Top = 1.7;
					fEdifDenom.Width = 20.6;
					fEdifDenom.Height = 1.0;
					fEdifDenom.LineColorName = "Black";
					fEdifDenom.LineWidth = 1;					
					fEdifDenom.FillColorName = "Black";
					lyt.SimpleFrames.Add(fEdifDenom);
					
					fTitulo.Left = fEdifDenom.Left;
					fTitulo.Top = fEdifDenom.Top + fEdifDenom.Height;
					fTitulo.Width = fEdifDenom.Width;
					fTitulo.Height = 0.4;
					fTitulo.LineColorName = "Black";
					fTitulo.LineWidth = 1;					
					fTitulo.FillColorName = "LightGray";
					lyt.SimpleFrames.Add(fTitulo);
					
					fLogoSIGUA.Left = 24.6;
					fLogoSIGUA.Top = 1.7;
					fLogoSIGUA.Width = 3.2;
					fLogoSIGUA.Height = 1.4;
					fLogoSIGUA.LineColorName = "Black";
					fLogoSIGUA.LineWidth = 1;
					lyt.SimpleFrames.Add(fLogoSIGUA);

					fMarco.Left = 1.7;
					fMarco.Top = 3.3;
					fMarco.Width = 26.1;
					fMarco.Height = 16.3;
					fMarco.LineColorName = "Black";
					fMarco.LineWidth = 1;
					lyt.SimpleFrames.Add(fMarco);					
					
					fMapa.Left = 1.7;
					fMapa.Top = 3.3;
					fMapa.Width = 26.1;
					fMapa.Height = 15.1;
					fMapa.LineColorName = "Red";
					fMapa.LineWidth = 1;
					//NO VISIBLE
					fMapa.Visible = false;
					lyt.SimpleFrames.Add(fMapa);
					
					fPie.Left = fMapa.Left;
					fPie.Top = fMapa.Top + fMapa.Height;
					fPie.Width = fMapa.Width;
					fPie.Height = 1.2;
					fPie.LineColorName = "Red";
					fPie.LineWidth = 1;
					//NO VISIBLE
					fPie.Visible = false;
					lyt.SimpleFrames.Add(fPie);
					
					fSubPie.Left = fPie.Left;
					fSubPie.Top = fPie.Top + (fPie.Height / 2);
					fSubPie.Width = fPie.Width;
					fSubPie.Height = fPie.Height / 2;
					fSubPie.LineColorName = "Red";
					fSubPie.LineWidth = 1;
					//NO VISIBLE
					fSubPie.Visible = false;
					lyt.SimpleFrames.Add(fSubPie);
					
					fLogoLABSIG.Left = fPie.Left;
					fLogoLABSIG.Top = fPie.Top;
					fLogoLABSIG.Width = 3.5;
					fLogoLABSIG.Height = fPie.Height;
					fLogoLABSIG.LineColorName = "Red";
					fLogoLABSIG.LineWidth = 1;					
					//NO VISIBLE
					fLogoLABSIG.Visible = false;
					lyt.SimpleFrames.Add(fLogoLABSIG);					
					
					edif.Rect = fEdif.Rect;
					edif.FontFamilyName = "Verdana";
					edif.FontSize = 8.0;
					edif.FontStyle = XFontStyle.Bold;
					edif.FontColorName = "White";
					lyt.TextFields.Add(edif);
					
					edifCod.Rect = fEdifCod.Rect;
					edifCod.FontFamilyName = "Arial";
					edifCod.FontSize = 12.0;
					edifCod.FontStyle = XFontStyle.Bold;
					edifCod.FontColorName = "Black";
					edifCod.BindClassName = "SIGUANETDesktop.ModeloExplotacion.Espacios.Edificio";
					edifCod.BindPropertyName = "Codigo";
					lyt.TextFields.Add(edifCod);
					
					planta.Rect = fPlanta.Rect;
					planta.FontFamilyName = "Arial";
					planta.FontSize = 11.0;
					planta.FontStyle = XFontStyle.Bold;
					planta.FontColorName = "Black";
					planta.BindClassName = "SIGUANETDesktop.ModeloExplotacion.Espacios.PlantaEdificio";
					planta.BindPropertyName = "StringPlanta";
					lyt.TextFields.Add(planta);					
					
					edifDenom.Rect = fEdifDenom.Rect;
					edifDenom.FontFamilyName = "Arial";
					edifDenom.FontSize = 14.0;
					edifDenom.FontStyle = XFontStyle.Bold;
					edifDenom.FontColorName = "White";
					edifDenom.BindClassName = "SIGUANETDesktop.ModeloExplotacion.Espacios.Edificio";
					edifDenom.BindPropertyName = "Denominacion";
					lyt.TextFields.Add(edifDenom);
					
					titulo.Rect = fTitulo.Rect;
					titulo.FontFamilyName = "Arial";
					titulo.FontSize = 9.0;
					titulo.FontStyle = XFontStyle.Bold;
					titulo.FontColorName = "Black";
					titulo.BindClassName = "System.String";
					lyt.TextFields.Add(titulo);
					
					fecha.Rect = fSubPie.Rect;
					fecha.FontFamilyName = "Arial";
					fecha.FontSize = 7.0;
					fecha.FontStyle = XFontStyle.Regular;
					fecha.FontColorName = "Black";
					lyt.TextFields.Add(fecha);
					
					logoSIGUA.Rect = fLogoSIGUA.Rect;
					logoSIGUA.RscName = "SIGUANETDesktop.ModeloCartografia.PDF.LogoSIGUA.bmp";
					lyt.Logos.Add(logoSIGUA);
					
					logoLABSIG.Rect = fLogoLABSIG.Rect;
					logoLABSIG.RscName = "SIGUANETDesktop.ModeloCartografia.PDF.LogoLABSIG.bmp";
					lyt.Logos.Add(logoLABSIG);					
					
					//MainMap
					lyt.MainMap.SetFromFrame(fMapa, 1.5, 1.5);
					lyt.MainMap.OverrideVectorLayerStyle = false;
					lyt.MainMap.OverrideLabelLayerStyle = true;
					lyt.MainMap.LabelFontFamilyName = "Arial";
					lyt.MainMap.LabelFontSize = 6.0;
					lyt.MainMap.LabelFontColorName = "Black";
					lyt.MainMap.LabelFontStyle = XFontStyle.Regular;					
					lyt.MainMap.Scale.Visible = true;
					lyt.MainMap.Scale.X = fPie.Left + fPie.Width;
					lyt.MainMap.Scale.Y = fPie.Top;
					lyt.MainMap.Scale.Anchor = AnchorType.TopRight;
					lyt.MainMap.Scale.Height = 7;
					lyt.MainMap.Scale.IntervalSize = 5.0;
					lyt.MainMap.Scale.NumIntervals = 4;
					lyt.MainMap.Scale.Unit = "m";
					lyt.MainMap.Scale.FillColorName = "Black";
					lyt.MainMap.Scale.FontFamilyName = "Verdana";
					lyt.MainMap.Scale.FontStyle = XFontStyle.Regular;
					lyt.MainMap.Scale.FontSize = 8;
					lyt.MainMap.Scale.FontColorName = "Black";
					lyt.MainMap.GeoMarks.Visible = false;					
					break;
				default:
					lyt.Size = PageSize.A4;
					lyt.Orientation = PageOrientation.Portrait;
					//SimpleFrames
					Frame f = new Frame();
					f.Left = 2;
					f.Top = 2;
					f.Width = 17;
					f.Height = 26;
					f.LineColorName = "Black";
					f.LineWidth = 1;
					lyt.SimpleFrames.Add(f);
					//MainMap
					lyt.MainMap.Left = 3;
					lyt.MainMap.Top = 3;
					lyt.MainMap.Width = 15;
					lyt.MainMap.Height = 23;
					lyt.MainMap.GeomLineColorName = "Black";
					lyt.MainMap.GeomLineWidth = 1;
					lyt.MainMap.GeomFillColorName = "Transparent";
					lyt.MainMap.OverrideVectorLayerStyle = true;
					lyt.MainMap.OverrideLabelLayerStyle = true;
					lyt.MainMap.Scale.Visible = true;
					lyt.MainMap.Scale.X = 18;
					lyt.MainMap.Scale.Y = 21;
					lyt.MainMap.Scale.Anchor = AnchorType.TopRight;
					lyt.MainMap.Scale.Height = 7;
					lyt.MainMap.Scale.IntervalSize = 5;
					lyt.MainMap.Scale.NumIntervals = 5;
					lyt.MainMap.Scale.Unit = "m";
					lyt.MainMap.Scale.FillColorName = "Black";
					lyt.MainMap.Scale.FontFamilyName = "Verdana";
					lyt.MainMap.Scale.FontStyle = XFontStyle.Regular;
					lyt.MainMap.Scale.FontSize = 8;
					lyt.MainMap.Scale.FontColorName = "Black";
					lyt.MainMap.GeoMarks.Visible = false;
					break;
			}
			return lyt;
		}
	}
}
