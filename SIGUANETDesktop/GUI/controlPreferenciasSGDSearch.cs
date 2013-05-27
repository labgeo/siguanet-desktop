/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 12/03/2008
 * Hora: 14:13
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
	/// Description of controlPreferenciasSGDSearch.
	/// </summary>
	public partial class controlPreferenciasSGDSearch : UserControl
	{
		public controlPreferenciasSGDSearch()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			bool useLocal = false;
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDUseLocal), out useLocal);
			this.rbLocal.Checked = useLocal;
			
			bool useRemote = !useLocal;
			this.rbRemote.Checked = useRemote;

			string url = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadURL);
			bool useLocalCopy = false;
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDUseLocalCopy), out useLocalCopy);
			this.txURL.Text = url;
			this.ckUseLocalCopy.Checked = useLocalCopy;
			
			bool useCredentials = false;
			bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadUsingCredentials), out useCredentials);
			this.ckCredentials.Checked = useCredentials;
			string login = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithLogin);
			string password = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithPassword);
			this.txLogin.Text = login;
			this.txPassword.Text = password;
			this.lLogin.Enabled = this.txLogin.Enabled = this.ckCredentials.Checked;
			this.lPassword.Enabled = this.txPassword.Enabled = this.ckCredentials.Checked;
			
			this.SyncControls(useRemote);
		}
		
		private void SyncControls(bool enable)
		{
			this.lbURL.Enabled = this.txURL.Enabled = this.ckUseLocalCopy.Enabled = this.ckCredentials.Enabled = enable;
		}
		
		private void SyncPrefs()
		{
			AdministradorPreferencias.Update(PrefsGlobal.SGDUseLocal, this.rbLocal.Checked.ToString());
			AdministradorPreferencias.Update(PrefsGlobal.SGDUseRemote, this.rbRemote.Checked.ToString());
			SyncControls(this.rbRemote.Checked);
		}
		
		void TxURLTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.SGDDownloadURL, this.txURL.Text.Trim());
		}
		
		void CkUseLocalCopyCheckedChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.SGDUseLocalCopy, this.ckUseLocalCopy.Checked.ToString());
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
			AdministradorPreferencias.Update(PrefsGlobal.SGDDownloadUsingCredentials, this.ckCredentials.Checked.ToString());
			this.lLogin.Enabled = this.txLogin.Enabled = this.ckCredentials.Checked;
			this.lPassword.Enabled = this.txPassword.Enabled = this.ckCredentials.Checked;
		}
		
		void TxLoginTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.SGDDownloadWithLogin, this.txLogin.Text.Trim());
		}
		
		void TxPasswordTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.SGDDownloadWithPassword, this.txPassword.Text.Trim());
		}
	}
}
