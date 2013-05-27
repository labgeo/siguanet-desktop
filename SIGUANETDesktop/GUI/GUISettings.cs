/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 26/04/2007
 * Time: 13:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of GUISettings.
	/// </summary>
	public static class GUISettings
	{
		private static bool _useSOAPGroups = true;
		public static bool UseSOAPGroups
		{
			get
			{
				return _useSOAPGroups;
			}
			set
			{
				_useSOAPGroups = value;
			}
		}
	}
}
