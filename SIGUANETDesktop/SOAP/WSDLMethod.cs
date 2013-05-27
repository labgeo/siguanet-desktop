/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 12/03/2007
 * Time: 20:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

namespace SIGUANETDesktop.SOAP
{
	/// <summary>
	/// Description of WSDLMethod.
	/// </summary>
	public class WSDLMethod
	{
		private const string RETURNTYPESEARCH1 = "/wsdl:definitions/wsdl:types/s:schema/s:element[@name=\"{0}Response\"]/s:complexType/s:sequence/s:element";
		private const string RETURNTYPESEARCH2 = "/wsdl:definitions/wsdl:types/s:schema/s:element[@name=\"{0}Response\"]/s:complexType/s:sequence/s:element/s:complexType/s:sequence/s:element";
		private const string PARAMSEARCH = "/wsdl:definitions/wsdl:types/s:schema/s:element[@name=\"{0}\"]/s:complexType/s:sequence/s:element";
		
		private string _name = string.Empty;
		public string Name
		{
			get
			{
				return _name;
			}
		}
		
		private string _description = string.Empty;
		public string Description
		{
			get
			{
				return _description;
			}
		}
		
		private string _returnType = string.Empty;
		public string ReturnType
		{
			get
			{
				return _returnType;
			}
		}
		
		private List<WSDLParam> _parameters = new List<WSDLParam>();
		public List<WSDLParam> Parameters
		{
			get
			{
				return _parameters;
			}
		}
		
		internal WSDLMethod(XPathNavigator nav, XmlNamespaceManager mngr, string methodName, string methodDescription)
		{
			this._name = methodName;
			this._description = methodDescription;
			
			XPathExpression returntypeExpr1 = nav.Compile(string.Format(RETURNTYPESEARCH1, methodName));
			returntypeExpr1.SetContext(mngr);
			string sType = nav.SelectSingleNode(returntypeExpr1).GetAttribute("type", string.Empty);
			if(sType == string.Empty)
			{
				XPathExpression returntypeExpr2 = nav.Compile(string.Format(RETURNTYPESEARCH2, methodName));
				returntypeExpr2.SetContext(mngr);
				sType = nav.SelectSingleNode(returntypeExpr2).GetAttribute("ref", string.Empty);
			}
			this._returnType = sType;
			
			XPathExpression paramExpr = nav.Compile(string.Format(PARAMSEARCH, methodName));
			paramExpr.SetContext(mngr);
			XPathNodeIterator navset = nav.Select(paramExpr);
			while(navset.MoveNext())
			{
				string name = navset.Current.GetAttribute("name", string.Empty);
				string dataType = navset.Current.GetAttribute("type", string.Empty);
				this._parameters.Add(new WSDLParam(name, dataType));
			}
		}
	}
}
