/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/11/2006
 * Time: 9:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Globalization;
using PdfSharp.Drawing;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of ParamField.
	/// </summary>
	public class ParamField
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
		
		private string _subfix = string.Empty;
		[XmlElement()]
		public string Subfix 
		{
			get 
			{
				return _subfix;
			}
			set 
			{
				_subfix = value;
			}
		}
		
		private string _bindClassName = string.Empty;
		[XmlElement()]
		public string BindClassName 
		{
			get 
			{
				return _bindClassName;
			}
			set 
			{
				_bindClassName = value;
			}
		}
		private string _bindTableName = string.Empty;
		[XmlElement()]
		public string BindTableName 
		{
			get 
			{
				return _bindTableName;
			}
			set 
			{
				_bindTableName = value;
			}
		}
		
		private string _bindPropertyName = string.Empty;
		[XmlElement()]
		public string BindPropertyName 
		{
			get 
			{
				return _bindPropertyName;
			}
			set 
			{
				_bindPropertyName = value;
			}
		}
		
		private string _bindPropertyColumnName = string.Empty;
		[XmlElement()]
		public string BindPropertyColumnName 
		{
			get 
			{
				return _bindPropertyColumnName;
			}
			set 
			{
				_bindPropertyColumnName = value;
			}
		}
		
		private string _bindValueColumnName = string.Empty;
		[XmlElement()]
		public string BindValueColumnName 
		{
			get 
			{
				return _bindValueColumnName;
			}
			set 
			{
				_bindValueColumnName = value;
			}
		}
		
		private ValueParsingOption _bindPropertyFormat = ValueParsingOption.None;
		[XmlElement()]
		public ValueParsingOption BindPropertyFormat {
			get 
			{
				return _bindPropertyFormat;
			}
			set 
			{
				_bindPropertyFormat = value;
			}
		}
		
		private string _bindPropertyCultureName = string.Empty;
		[XmlElement()]
		public string BindPropertyCultureName 
		{
			get 
			{
				return _bindPropertyCultureName;
			}
			set 
			{
				_bindPropertyCultureName = value;
			}
		}
		
		public ParamField()
		{
		}
		
		public void Draw(XGraphics gfx, object param)
		{
			TransformsProvider tp = new TransformsProvider(gfx);
			XFont font = new XFont(this.FontFamilyName, this.FontSize, this.FontStyle);
			XSolidBrush brush = new XSolidBrush(XColor.FromName(this.FontColorName));
			string s = string.Empty;

			if (param is DBNull)
			{
				s = string.Format("{0} {1} {2}", this._prefix, string.Empty, this._subfix);
			}
			if (param is string)
			{
				switch (_bindPropertyFormat) {
					case ValueParsingOption.None:
						s = string.Format("{0} {1} {2}", this._prefix, param, this._subfix).Trim();
						break;
					case ValueParsingOption.ParseInteger:
						int intVal;
						if (int.TryParse((string) param, out intVal))
						{
							s = string.Format("{0} {1} {2}", this._prefix, intVal.ToString("#,###"), this._subfix).Trim();
						}
						else
						{
							s = string.Format("{0} {1} {2}", this._prefix, param, this._subfix).Trim();
						}
						break;
					case ValueParsingOption.ParseFloat:
						double floatVal;
						CultureInfo culture = null;
						try 
						{
							culture = CultureInfo.GetCultureInfo(this._bindPropertyCultureName);
						}
						catch
						{
							//Do nothing
						}
						if (culture == null)
						{
							s = string.Format("{0} {1} {2}", this._prefix, param, this._subfix).Trim();
						}
						else
						{
							if (double.TryParse((string) param, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, culture, out floatVal))
							{
								s = string.Format("{0} {1} {2}", this._prefix, floatVal.ToString("#,###.##"), this._subfix).Trim();
							}
							else
							{
								s = string.Format("{0} {1} {2}", this._prefix, param, this._subfix).Trim();
							}
						}
						break;
				}
			}
			if (param is int)
			{
				int intVal = (int) param;
				s = string.Format("{0} {1} {2}", this._prefix, (intVal).ToString("#,###"), this._subfix).Trim();
			}
			if ((param is double) || (param is float))
			{
				double floatVal = (double) param;
				s = string.Format("{0} {1} {2}", this._prefix, floatVal.ToString("#,###.##"), this._subfix).Trim();
			}
			
			if (base.Rect == XRect.Empty)
			{
				double x = tp.CmsToPts(this.X);
				double y = tp.CmsToPts(this.Y);
				gfx.DrawString(s, font, brush, x, y, XStringFormat.TopLeft);
			}
			else
			{
				XRect rect = tp.FromCmsToPts(base.Rect);
				gfx.DrawString(s, font, brush, rect, base.Format);
			}			
		}		
	}
}
