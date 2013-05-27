/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/04/2007
 * Time: 11:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.SOAP;

namespace SIGUANETDesktop.ModeloClienteSOAP
{
	/// <summary>
	/// Description of SOAPGroup.
	/// </summary>
	public class SOAPGroup
	{
		public SOAPGroup()
		{
		}
		
		private string _label = "Nuevo grupo";
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
		[XmlAttribute]
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
		
		private List<SOAPMethodInfo> _methods = new List<SOAPMethodInfo>();
		[XmlArray]
		public List<SOAPMethodInfo> Methods
		{
			get
			{
				return this._methods;
			}
			set
			{
				this._methods = value;
			}
		}
		
		public void AddMethod(WSDLProxyMethod m)
		{
			if (this.MethodExists(m.Name) && !this.MethodIsObsolete(m.Name))
			{
				throw new ApplicationException(string.Format("El método {0} ya está incluido en la lista de métodos de este grupo. Bórrelo o márquelo como obsoleto.", m.Name));
			}
			SOAPMethodInfo smi = new SOAPMethodInfo();
			smi.Name = m.Name;
			smi.Label = m.Name;
			smi.ReturnType = m.ReturnType.Name;
			foreach(WSDLProxyParam p in m.Parameters)
			{
				SOAPParamInfo spi = new SOAPParamInfo();
				spi.Name = p.Name;
				spi.Label = p.Name;
				spi.DataType = p.DataType.Name;
				smi.Parameters.Add(spi);
			}
			this._methods.Add(smi);
		}
		
		public void AddMethod(SOAPMethodInfo m)
		{
			if (this.MethodExists(m.Name) && !this.MethodIsObsolete(m.Name))
			{
				throw new ApplicationException(string.Format("El método {0} ya está incluido en la lista de métodos del grupo {1}. Bórrelo o márquelo como obsoleto.", m.Name, this._label));
			}
			this._methods.Add(m);
		}
		
		private bool MethodExists(string name)
		{
			foreach (SOAPMethodInfo m in this._methods)
			{
				if (m.Name == name) return true;
			}
			return false;
		}
		
		private bool MethodIsObsolete(string name)
		{
			foreach (SOAPMethodInfo m in this._methods)
			{
				if (m.Name == name && m.Obsolete) return true;				
			}
			return false;
		}		
	}
}
