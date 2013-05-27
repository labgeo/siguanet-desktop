/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/04/2007
 * Time: 11:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloClienteSOAP
{
	/// <summary>
	/// Description of SOAPPublicCategory.
	/// </summary>
	public class SOAPPublicContainer : ISOAPContainer
	{
		public SOAPPublicContainer()
		{
		}
		
		private string _name = "Métodos comunes";
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
		
		private string _comment = "Contenedor de WebMethods para acceso anónimo";
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
		
		private List<SOAPGroup> _groups = new List<SOAPGroup>();
		[XmlArray]
		public List<SOAPGroup> Groups
		{
			get
			{
				return this._groups;
			}
			set
			{
				this._groups = value;
			}
		}		
	}
}
