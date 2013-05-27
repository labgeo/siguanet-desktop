/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 24/02/2007
 * Time: 20:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SIGUANETDesktop.SOAP
{
	/// <summary>
	/// Description of SOAPParamUI.
	/// </summary>
	public class SOAPParamInfo
	{
		private string _name = string.Empty;
		[XmlAttribute]
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		
		private string _dataType = null;
		[XmlAttribute]
		public string DataType
		{
			get
			{
				return this._dataType;
			}
			set
			{
				this._dataType = value;
			}
		}
		
		private string _label = string.Empty;
		[XmlAttribute]
		public string Label
		{
			get
			{
				return this._label;
			}
			set
			{
				this._label = value;
			}
		}
		
		private string _comment = string.Empty;
		[XmlElement]
		public string Comment
		{
			get
			{
				return this._comment;
			}
			set
			{
				this._comment = value;
			}
		}
		
		private string _defaultValue = string.Empty;
		[XmlAttribute]
		public string DefaultValue
		{
			get
			{
				return this._defaultValue;
			}
			set
			{
				this._defaultValue = value;
			}
		}
		
		private bool _allowEmpty = true;
		[XmlAttribute]
		public bool AllowEmpty
		{
			get
			{
				return this._allowEmpty;
			}
			set
			{
				this._allowEmpty = value;
			}
		}		
		
		private string _dataSource = string.Empty;
		[XmlAttribute]
		public string DataSource
		{
			get
			{
				return this._dataSource;
			}
			set
			{
				this._dataSource = value;
			}
		}
		
		private string _valueMember = string.Empty;
		[XmlAttribute]
		public string ValueMember
		{
			get
			{
				return this._valueMember;
			}
			set
			{
				this._valueMember = value;
			}
		}
		
		private string _displayMember = string.Empty;
		[XmlAttribute]
		public string DisplayMember
		{
			get
			{
				return this._displayMember;
			}
			set
			{
				this._displayMember = value;
			}
		}
		
		private object _paramValue = string.Empty;
		[XmlIgnore]
		public object ParamValue
		{
			get
			{
				return this._paramValue;
			}
			set
			{
				this._paramValue = value;
			}
		}	
		
		
		public SOAPParamInfo()
		{
		}
	}
}
