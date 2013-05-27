/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 12/03/2007
 * Time: 19:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace SIGUANETDesktop.SOAP
{
	/// <summary>
	/// Clase para la deserialización mediante XPath de documentos WSDL
	/// </summary>
	public class WSDLDocument
	{
		private const string WSDLNAMESPACE_PREFIX = "wsdl";
		private const string WSDLNAMESPACE_URI = "http://schemas.xmlsoap.org/wsdl/";
		private const string SOAPNAMESPACE_PREFIX = "soap";
		private const string SOAPNAMESPACE_URI = "http://schemas.xmlsoap.org/wsdl/soap/";
		private const string SCHEMANAMESPACE_PREFIX = "s";		
		private const string SCHEMANAMESPACE_URI = "http://www.w3.org/2001/XMLSchema";
		private const string SERVICESEARCH = "/wsdl:definitions/wsdl:service";
		private const string METHODSEARCH = "/wsdl:definitions/wsdl:portType/wsdl:operation";

		private string _source = string.Empty;
		
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
		
		private string _location = string.Empty;
		public string Location
		{
			get
			{
				return _location;
			}
		}
		
		private List<WSDLMethod> _methods = new List<WSDLMethod>();
		public List<WSDLMethod> Methods
		{
			get
			{
				return _methods;
			}
		}
		
		internal WSDLDocument(string buffer)
		{
			switch(buffer.Substring(0, 5).ToLower())
			{
				case("<?xml"):
					MemoryStream ms = new MemoryStream();
					StreamWriter sw = new StreamWriter(ms, System.Text.Encoding.Unicode);
					sw.Write(buffer);
					sw.Flush();
					ms.Position = 0;
					this.Deserialize(ms);
					ms.Close();
					sw.Close();
					break;
				case("http:"):
					HttpWebRequest req = (HttpWebRequest) WebRequest.Create(buffer);
					HttpWebResponse res = (HttpWebResponse) req.GetResponse();
					Stream rs = res.GetResponseStream();
					this.Deserialize(rs);
					rs.Close();
					res.Close();
					break;
				default:
					FileStream fs = new FileStream(buffer, FileMode.Open);
					this.Deserialize(fs);
					fs.Close();
					break;
			}
		}
		
		private void Deserialize(Stream s)
		{
			XPathDocument x = new XPathDocument(s);
			XPathNavigator nav = x.CreateNavigator();
			XmlNamespaceManager mngr = new XmlNamespaceManager(nav.NameTable);
			mngr.AddNamespace(WSDLNAMESPACE_PREFIX, WSDLNAMESPACE_URI);
			mngr.AddNamespace(SOAPNAMESPACE_PREFIX, SOAPNAMESPACE_URI);
			mngr.AddNamespace(SCHEMANAMESPACE_PREFIX, SCHEMANAMESPACE_URI);
			XPathExpression svcExpr = nav.Compile(SERVICESEARCH);
			svcExpr.SetContext(mngr);
			XPathNavigator svcNav = nav.SelectSingleNode(svcExpr);
			this._name = svcNav.GetAttribute("name", string.Empty);
			svcNav.MoveToChild("documentation", WSDLNAMESPACE_URI);
			this._description = svcNav.Value;
			svcNav.MoveToParent();
			svcNav.MoveToChild("port", WSDLNAMESPACE_URI);
			svcNav.MoveToChild("address", SOAPNAMESPACE_URI);
			this._location = svcNav.GetAttribute("location", string.Empty);
			
			XPathExpression mthExpr = nav.Compile(METHODSEARCH);
			mthExpr.SetContext(mngr);
			XPathNodeIterator navset = nav.Select(mthExpr);
			while(navset.MoveNext())
			{
				XPathNavigator mthNav = navset.Current;
				string mthName = mthNav.GetAttribute("name", string.Empty);
				mthNav.MoveToChild("documentation", WSDLNAMESPACE_URI);
				string mthDescription = mthNav.Value;
				this._methods.Add(new WSDLMethod(nav, mngr, mthName, mthDescription));
			}
		}
	}
}
