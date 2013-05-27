/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/11/2006
 * Time: 9:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using PdfSharp;
using PdfSharp.Drawing;
using System.Xml;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of SimpleLayout.
	/// </summary>
	public class SimpleLayout
	{
		private string _name = string.Empty;
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
		
		private PageSize _size = PageSize.A4;
		[XmlAttribute()]
		public PageSize Size 
		{
			get 
			{
				return _size;
			}
			set 
			{
				_size = value;
			}
		}
		
		private PageOrientation _orientation = PageOrientation.Portrait;
		[XmlAttribute()]
		public PageOrientation Orientation 
		{
			get 
			{
				return _orientation;
			}
			set 
			{
				_orientation = value;
			}
		}
		
		private List<Frame> _simpleFrames = new List<Frame>();
		[XmlArray()]
		public List<Frame> SimpleFrames 
		{
			get 
			{
				return _simpleFrames;
			}
			set 
			{
				_simpleFrames = value;
			}
		}
		
		private MapFrame _mainMap = new MapFrame();
		[XmlElement()]
		public MapFrame MainMap 
		{
			get 
			{
				return _mainMap;
			}
			set 
			{
				_mainMap = value;
			}
		}
		
		private List<TextField> _textFields = new List<TextField>();
		[XmlArray(), XmlArrayItem(Type = typeof(TextField)), XmlArrayItem(Type = typeof(DateStampField)), XmlArrayItem(Type = typeof(ParamField))]
		public List<TextField> TextFields 
		{
			get 
			{
				return _textFields;
			}
			set 
			{
				_textFields = value;
			}
		}
		
		private List<Logo> _logos = new List<Logo>();
		[XmlArray()]
		public List<Logo> Logos
		{
			get 
			{
				return _logos;
			}
			set 
			{
				_logos = value;
			}
		}		
		
		public SimpleLayout()
		{
		}		
		
		public void ToXML(string path)
		{
			XmlSerializer x = null;
			XmlTextWriter w = null;
			try 
			{
				x = new XmlSerializer(this.GetType());
				w = new XmlTextWriter(path, System.Text.Encoding.Unicode);
				w.Formatting = Formatting.Indented;
				w.Indentation = 2;
				x.Serialize(w, this);
				w.Close();
			}
			catch (Exception ex) 
			{
				if (!(w == null)) w.Close();
				throw ex;
			}
		}		
	}
}
