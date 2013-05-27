/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/11/2006
 * Time: 9:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using PdfSharp.Drawing;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of DateStampField.
	/// </summary>
	public class DateStampField
		: TextField
	{
		private string _prefix = string.Empty;
		[XmlElement()]
		public string Prefix 
		{
			get 
			{
				return _prefix;
			}
			set 
			{
				_prefix = value;
			}
		}
		
		public DateStampField()
		{
		}
		
		public new void Draw(XGraphics gfx)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			XFont font = new XFont(this.FontFamilyName, this.FontSize, this.FontStyle);
			XSolidBrush brush = new XSolidBrush(XColor.FromName(this.FontColorName));
			string txt = string.Format("{0} {1}", this._prefix, DateTime.Today.ToShortDateString());
			if (base.Rect == XRect.Empty)
			{
				double x = tp.CmsToPts(this.X);
				double y = tp.CmsToPts(this.Y);
				gfx.DrawString(txt, font, brush, x, y, XStringFormat.TopLeft);				
			}
			else
			{
				XRect rect = tp.FromCmsToPts(base.Rect);
				gfx.DrawString(txt, font, brush, rect, base.Format);
			}
		}
	}
}
