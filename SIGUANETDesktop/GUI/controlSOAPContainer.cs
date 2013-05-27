/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 26/04/2007
 * Time: 10:28
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
	/// Description of controlSOAPContainer.
	/// </summary>
	public partial class controlSOAPContainer
	{
		public controlSOAPContainer(TreeNode n)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.txDesc.Text = (n.Tag as ISOAPContainer).Name;
			this.txComent.Text = (n.Tag as ISOAPContainer).Comment;			
		}
	}
}
