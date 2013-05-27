/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/05/2006
 * Time: 16:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace SIGUANETDesktop.DB
{
	public enum dbOrigen
	{
		Ninguno,
		ORA,
		PGSQL
	}
	
	public enum dbRelationType
	{
		Table,
		View,
		Unknown
	}
}
