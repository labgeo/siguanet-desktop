/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 13/11/2006
 * Time: 12:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Drawing;
using PdfSharp.Drawing;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of Logo.
	/// </summary>
	public class Logo
	{
		private string _name = "Logo";
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
		
		private string _rscName = string.Empty;
		[XmlAttribute()]
		public string RscName 
		{
			get 
			{
				return _rscName;
			}
			set 
			{
				_rscName = value;
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
		
		public Logo()
		{
		}
		
		public void Draw(XGraphics gfx)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			if (this._rect != XRect.Empty)
			{
				XRect rect = tp.FromCmsToPts(this._rect);
				//Margen de seguridad del 5%
				rect.Inflate(-((5 * rect.Width) / 100), -((5 * rect.Height) / 100));
				try
				{
					System.IO.Stream imgStream =  this.GetType().Assembly.GetManifestResourceStream(this._rscName);
    				Image img = Image.FromStream(imgStream);
    				gfx.DrawImage(XImage.FromGdiPlusImage(img), rect);
    				imgStream.Close();
				}
				catch
				{					
					//Do nothing
				}
			}						
		}
	}
}
