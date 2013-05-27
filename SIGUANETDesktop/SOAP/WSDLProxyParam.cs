/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/04/2007
 * Time: 11:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Reflection;

namespace SIGUANETDesktop.SOAP
{
	/// <summary>
	/// Description of WSDLProxyParam.
	/// </summary>
	public class WSDLProxyParam
	{
		private string _name = string.Empty;
		public string Name
		{
			get
			{
				return _name;
			}
		}
		
		private Type _dataType = null;
		public Type DataType
		{
			get
			{
				return _dataType;
			}
		}
		
		internal WSDLProxyParam(ParameterInfo pi)
		{
			this._name = pi.Name;
			this._dataType = pi.ParameterType;
		}
	}
}
