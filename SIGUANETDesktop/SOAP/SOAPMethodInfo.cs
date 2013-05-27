/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 24/02/2007
 * Time: 20:28
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
	/// Description of SOAPMethodUI.
	/// </summary>
	public class SOAPMethodInfo
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
		
		private string _returnType = string.Empty;
		[XmlElement]
		public string ReturnType
		{
			get
			{
				return this._returnType;
			}
			set
			{
				this._returnType = value;
			}
		}
		
		private bool _public = true;
		[XmlAttribute]
		public bool Public
		{
			get
			{
				return this._public;
			}
			set
			{
				this._public = value;
			}
		}
		
		private bool _obsolete = false;
		[XmlAttribute]
		public bool Obsolete
		{
			get
			{
				return this._obsolete;
			}
			set
			{
				this._obsolete = value;
			}
		}
		
		private List<SOAPParamInfo> _parameters = new List<SOAPParamInfo>();
		[XmlArray]
		public List<SOAPParamInfo> Parameters
		{
			get
			{
				return this._parameters;
			}
			set
			{
				this._parameters = value;
			}
		}
		
		public SOAPMethodInfo()
		{
		}	
		
		//TONI - Lo he añadido para poder cargar los métodos en un list box y mostrar la etiqueta.
		public override string ToString()
		{
			return Label;
		}
	}
}
