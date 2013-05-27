/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 28/02/2007
 * Time: 20:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.SOAP;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmConexionSOAP.
	/// </summary>
	public partial class frmConexionSOAP
	{
		private bool cancelarCierre = false;
		public frmConexionSOAP()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (!SOAPSettings.UseDefaultAccess)
			{
				this.chAccesoDefault.Checked = false;
				this.txWSDL.Enabled = true;
				this.txWSUI.Enabled = true;
				this.lbWSDL.Enabled = true;
				this.lbWSUI.Enabled = true;
				this.txWSDL.Text = SOAPSettings.WSDLLocation;
				this.txWSUI.Text = SOAPSettings.WSUILocation;
			}
			else
			{
				this.chAccesoDefault.Checked = true;
				this.txWSDL.Clear();
				this.txWSUI.Clear();
				this.txWSDL.Enabled = false;
				this.txWSUI.Enabled = false;
				this.lbWSDL.Enabled = false;
				this.lbWSUI.Enabled = false;
			}
			
			if (!SOAPSettings.UseContractCredentials)
			{
				this.ckContractCredentials.Checked = false;
				this.txContractUsr.Clear();
				this.txContractPwd.Clear();
				this.txContractUsr.Enabled = false;
				this.txContractPwd.Enabled = false;
				this.lContractUsr.Enabled = false;
				this.lContractPwd.Enabled = false;
			}
			else
			{
				this.ckContractCredentials.Checked = true;
				this.txContractUsr.Enabled = true;
				this.txContractPwd.Enabled = true;
				this.lContractUsr.Enabled = true;
				this.lContractPwd.Enabled = true;				
			}
			
			if (!SOAPSettings.UseAnonymousCredentials)
			{
				this.chCredencialesAnonimo.Checked = false;
				this.txUsuario.Enabled = true;
				this.txClave.Enabled = true;
				this.lbUsuario.Enabled = true;
				this.lbClave.Enabled = true;
				this.txUsuario.Text = SOAPSettings.HTTPUsr;
				this.txClave.Text = SOAPSettings.HTTPPwd;
			}
			else
			{
				this.chCredencialesAnonimo.Checked = true;
				this.txUsuario.Clear();
				this.txClave.Clear();
				this.txUsuario.Enabled = false;
				this.txClave.Enabled = false;
				this.lbUsuario.Enabled = false;
				this.lbClave.Enabled = false;
			}
		}
		
		void ChCredencialesAnonimoCheckedChanged(object sender, System.EventArgs e)
		{
			if (!this.chCredencialesAnonimo.Checked)
			{
				this.txUsuario.Enabled = true;
				this.txClave.Enabled = true;
				this.lbUsuario.Enabled = true;
				this.lbClave.Enabled = true;				
				this.txUsuario.Clear();
				this.txClave.Clear();
			}
			else
			{
				this.txUsuario.Clear();
				this.txClave.Clear();
				this.txUsuario.Enabled = false;
				this.txClave.Enabled = false;
				this.lbUsuario.Enabled = false;
				this.lbClave.Enabled = false;				
			}			
			
		}
		
		void ChAccesoDefaultCheckedChanged(object sender, System.EventArgs e)
		{
			if (!this.chAccesoDefault.Checked)
			{
				this.txWSDL.Enabled = true;
				this.txWSUI.Enabled = true;
				this.lbWSDL.Enabled = true;
				this.lbWSUI.Enabled = true;
				this.txWSDL.Text = SOAPSettings.WSDLLocation;
				this.txWSUI.Text = SOAPSettings.WSUILocation;
			}
			else
			{
				this.txWSDL.Clear();
				this.txWSUI.Clear();
				this.txWSDL.Enabled = false;
				this.txWSUI.Enabled = false;
				this.lbWSDL.Enabled = false;
				this.lbWSUI.Enabled = false;
			}
		}
		
		void CkContractCredentialsCheckedChanged(object sender, EventArgs e)
		{
			if (!this.ckContractCredentials.Checked)
			{
				this.txContractUsr.Clear();
				this.txContractPwd.Clear();
				this.txContractUsr.Enabled = false;
				this.txContractPwd.Enabled = false;
				this.lContractUsr.Enabled = false;
				this.lContractPwd.Enabled = false;				
			}
			else
			{
				this.txContractUsr.Enabled = true;
				this.txContractPwd.Enabled = true;
				this.lContractUsr.Enabled = true;
				this.lContractPwd.Enabled = true;				
			}
		}		
		
		void FrmConexionSOAPFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			if (cancelarCierre)
			{
				cancelarCierre = false;
				e.Cancel = true;
			}			
		}
		
		void BAceptarClick(object sender, System.EventArgs e)
		{
			try
			{
				SOAPSettings.UseDefaultAccess = this.chAccesoDefault.Checked;
				SOAPSettings.UseAnonymousCredentials = this.chCredencialesAnonimo.Checked;
				SOAPSettings.UseContractCredentials = this.ckContractCredentials.Checked;
				if (!SOAPSettings.UseDefaultAccess)
				{
					SOAPSettings.WSDLLocation = this.txWSDL.Text.Trim();
					SOAPSettings.WSUILocation = this.txWSUI.Text.Trim();
				}
				if (SOAPSettings.UseContractCredentials)
				{
					SOAPSettings.ContractHttpUsr = this.txContractUsr.Text.Trim();
					SOAPSettings.ContractHttpPwd = this.txContractPwd.Text.Trim();
				}
				else
				{
					SOAPSettings.ContractHttpUsr = string.Empty;
					SOAPSettings.ContractHttpPwd = string.Empty;
				}
				if (!SOAPSettings.UseAnonymousCredentials)
				{
					SOAPSettings.HTTPUsr = this.txUsuario.Text.Trim();
					SOAPSettings.HTTPPwd = this.txClave.Text.Trim();
				}
				MessageBox.Show("RECUERDE: Si hay una sesión SOAP iniciada y ha modificado sus credenciales de usuario o la dirección de los ficheros WSDL o WSUI debe reiniciarla para que tengan efecto los cambios", "Sesión SOAP", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				cancelarCierre = true;
				MessageBox.Show(ex.Message, "Conexión SOAP", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void BCancelarClick(object sender, System.EventArgs e)
		{
			this.cancelarCierre = false;
		}
	}
}
