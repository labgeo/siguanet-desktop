/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/04/2007
 * Time: 11:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Reflection;

namespace SIGUANETDesktop.SOAP
{
	/// <summary>
	/// Description of WSDLProxyMethod.
	/// </summary>
	public class WSDLProxyMethod
	{
		private string _name = string.Empty;
		public string Name
		{
			get
			{
				return this._name;
			}
		}
		
		private Type _returnType = null;
		public Type ReturnType
		{
			get
			{
				return this._returnType;
			}
		}
		
		private List<WSDLProxyParam> _parameters = new List<WSDLProxyParam>();
		public List<WSDLProxyParam> Parameters
		{
			get
			{
				return this._parameters;
			}
		}
		
		internal WSDLProxyMethod(MethodInfo mi)
		{
			this._name = mi.Name;
			if (mi.ReturnParameter != null)
			{
				this._returnType = mi.ReturnParameter.ParameterType;
			}
			ParameterInfo[] parameters = mi.GetParameters();
			foreach (ParameterInfo pi in parameters)
			{
				this._parameters.Add(new WSDLProxyParam(pi));
			}
		}
	}
}
