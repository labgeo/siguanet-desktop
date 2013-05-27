/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 12/03/2007
 * Time: 20:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Xml;
using System.Xml.XPath;

namespace SIGUANETDesktop.SOAP
{
	/// <summary>
	/// Description of WSDLParam.
	/// </summary>
	public class WSDLParam
	{
		private string _name = string.Empty;
		public string Name
		{
			get
			{
				return _name;
			}
		}
		
		private string _dataType = string.Empty;
		public string DataType
		{
			get
			{
				return _dataType;
			}
		}
		
		internal WSDLParam(string name, string dataType)
		{
			this._name = name;
			this._dataType = dataType;
		}
	}
}
