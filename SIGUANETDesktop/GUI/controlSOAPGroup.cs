/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 26/04/2007
 * Time: 10:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloClienteSOAP;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlSOAPGroup.
	/// </summary>
	public partial class controlSOAPGroup
	{
		public controlSOAPGroup(TreeNode n)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.txDesc.Text = (n.Tag as SOAPGroup).Label;
			this.txComent.Text = (n.Tag as SOAPGroup).Comment;
		}
	}
}
