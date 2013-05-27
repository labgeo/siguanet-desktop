/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 02/11/2006
 * Time: 13:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;

namespace SIGUANETDesktop.ModeloCartografia.PDF
{
	/// <summary>
	/// Description of Sizes.
	/// </summary>
	public struct Sizes
	{
		public static readonly SizeF A4P = new SizeF(21.0F, 29.7F);
		public static readonly SizeF A4L = new SizeF(29.7F, 21.0F);
		public static readonly SizeF A3P = new SizeF(29.7F, 21.0F * 2);
		public static readonly SizeF A3L = new SizeF(21.0F * 2, 29.7F);
	}
}
