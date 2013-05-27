/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 25/04/2007
 * Time: 23:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloClienteSOAP;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmGruposSOAP.
	/// </summary>
	public partial class frmGruposSOAP
	{
		private bool cancelarCierre = false;
		
		private SOAPServiceInfo _soap = null;
		private SOAPGroup _grupo = null;
		public SOAPGroup Grupo
		{
			get
			{
				return this._grupo;
			}
		}
		
		public bool ConservarCopia
		{
			get
			{
				return this.rCopiar.Checked;
			}
		}
		
		public frmGruposSOAP(SOAPServiceInfo soap)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			if (soap != null)
			{
				this._soap = soap;
				this.lG.DataSource = this._soap.PublicContainer.Groups;
				this.lG.DisplayMember = "Label";
				this.lG.ValueMember = "Label";
			}			
		}
		
		void RGCCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.rGC.Checked)
			{
				this.lG.DataSource = null;
				this.lG.Items.Clear();
				this.lG.DataSource = this._soap.PublicContainer.Groups;
				this.lG.DisplayMember = "Label";
				this.lG.ValueMember = "Label";				
			}
		}
		
		void RGECheckedChanged(object sender, System.EventArgs e)
		{
			if (this.rGE.Checked)
			{
				this.lG.DataSource = null;
				this.lG.Items.Clear();				
				this.lG.DataSource = this._soap.PrivateContainer.Groups;
				this.lG.DisplayMember = "Label";
				this.lG.ValueMember = "Label";				
			}
		}
		
		void FrmGruposSOAPFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			if (cancelarCierre)
			{
				this.cancelarCierre = false;
				e.Cancel = true;
			}
		}
		
		void BAceptarClick(object sender, System.EventArgs e)
		{
			if (this.lG.SelectedItem != null)
			{
				this._grupo = (SOAPGroup) this.lG.SelectedItem;
			}
			else
			{
				this.cancelarCierre = true;
				MessageBox.Show("Seleccione el grupo de destino", "Mover método", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void BCancelarClick(object sender, System.EventArgs e)
		{
			this.cancelarCierre = false;
		}
	}
}
