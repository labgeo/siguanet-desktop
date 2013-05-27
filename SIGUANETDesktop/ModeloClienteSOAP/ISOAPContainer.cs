/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 26/04/2007
 * Time: 10:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace SIGUANETDesktop.ModeloClienteSOAP
{
	/// <summary>
	/// Description of ISOAPContainer.
	/// </summary>
	public interface ISOAPContainer
	{
		string Name { get; set;}
		string Comment { get; set;}
		List<SOAPGroup> Groups { get; set;}
	}
}
