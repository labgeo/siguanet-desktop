/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 13/03/2008
 * Hora: 10:13
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlPreferenciasAuthSearch.
	/// </summary>
	public partial class controlPreferenciasAuthSearch : UserControl
	{
		public controlPreferenciasAuthSearch()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			bool useLocal = false;
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.AuthUseLocal), out useLocal);
			this.rbLocal.Checked = useLocal;
			
			bool useRemote = !useLocal;
			this.rbRemote.Checked = useRemote;
			
			string url = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadURL);
			this.txURL.Text = url;
			
			bool useCredentials = false;
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadUsingCredentials), out useCredentials);
			this.ckCredentials.Checked = useCredentials;
			string login = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadWithLogin);
			string password = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadWithPassword);
			this.txLogin.Text = login;
			this.txPassword.Text = password;
			this.lLogin.Enabled = this.txLogin.Enabled = this.ckCredentials.Checked;
			this.lPassword.Enabled = this.txPassword.Enabled = this.ckCredentials.Checked;
			
			this.SyncControls(useRemote);
		}
		
		private void SyncControls(bool enable)
		{
			this.lbURL.Enabled = this.txURL.Enabled = this.ckCredentials.Enabled = enable;
		}
		
		private void SyncPrefs()
		{
			AdministradorPreferencias.Update(PrefsGlobal.AuthUseLocal, this.rbLocal.Checked.ToString());
			AdministradorPreferencias.Update(PrefsGlobal.AuthUseRemote, this.rbRemote.Checked.ToString());
			SyncControls(this.rbRemote.Checked);
		}
		
		void TxURLTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.AuthDownloadURL, this.txURL.Text.Trim());
		}
		
		void RbLocalCheckedChanged(object sender, EventArgs e)
		{
			this.SyncPrefs();
		}
		
		void RbRemoteCheckedChanged(object sender, EventArgs e)
		{
			this.SyncPrefs();
		}
		
		void CkCredentialsCheckedChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.AuthDownloadUsingCredentials, this.ckCredentials.Checked.ToString());
			this.lLogin.Enabled = this.txLogin.Enabled = this.ckCredentials.Checked;
			this.lPassword.Enabled = this.txPassword.Enabled = this.ckCredentials.Checked;
		}
		
		void TxLoginTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.AuthDownloadWithLogin, this.txLogin.Text.Trim());
		}
		
		void TxPasswordTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.AuthDownloadWithPassword, this.txPassword.Text.Trim());
		}
	}
}
