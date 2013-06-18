/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 18/03/2008
 * Hora: 9:44
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using SIGUANETDesktop.Perfiles;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.XML;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlSRSManager.
	/// </summary>
	public partial class controlSRSManager : UserControl
	{
		private RemoteSettings _srs = new RemoteSettings();
		public controlSRSManager(bool createOnlyMode)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.cbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbPerfil.DataSource = Enum.GetNames(typeof(ProfileType));
			this.BindSettings();
			if (createOnlyMode) {
				this.panel1.Visible = false;
				this.panel2.Visible = false;
				this.panel3.Visible = false;
				this.bGuardar.Left = this.cbPerfil.Left + this.cbPerfil.Width - this.bGuardar.Width;
				this.bGuardar.Top = this.bGuardar.Top + this.cbPerfil.Height + ((this.bGuardar.Height * 20) / 100);
				foreach (Control c in this.Controls) {
					c.Top = c.Top - ((this.Height * 15) / 100);
				}
			}
		}
		
		public int GetCreateOnlyModeHeight ()
		{
			return this.bGuardar.Top + this.bGuardar.Height;
		}
		
		public int GetCreateOnlyModeWidth ()
		{
			return this.bGuardar.Left + this.bGuardar.Width;
		}
		
		private void BindSettings()
		{
			this.txVersion.DataBindings.Clear();
			this.txVersion.DataBindings.Add("Text", this._srs, "Version");
			this.txServidor.DataBindings.Clear();
			this.txServidor.DataBindings.Add("Text", this._srs, "PGSQLHost");
			this.txPuerto.DataBindings.Clear();
			this.txPuerto.DataBindings.Add("Text", this._srs, "PGSQLPort");
			this.txBD.DataBindings.Clear();
			this.txBD.DataBindings.Add("Text", this._srs, "PGSQLDb");
			this.txUsuario.DataBindings.Clear();
			this.txUsuario.DataBindings.Add("Text", this._srs, "PGSQLUsr");
			this.txClave.DataBindings.Clear();
			this.txClave.DataBindings.Add("Text", this._srs, "PGSQLPwd");
			this.txTimeout.DataBindings.Clear();
			this.txTimeout.DataBindings.Add("Text", this._srs, "PGSQLCmdTimeOut");
			this.cbPerfil.DataBindings.Clear();
			this.cbPerfil.DataBindings.Add("SelectedItem", this._srs, "Perfil");
		}
		
		void BGuardarClick(object sender, EventArgs e)
		{
			this.folderBrowserDialog1.Description = "Seleccione la carpeta de destino";
			if (this.folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
			{
				this._srs.Serializar(this.folderBrowserDialog1.SelectedPath, true);
			}
		}
		
		void BOKClick(object sender, EventArgs e)
		{
			try
			{
				bool checkCredentials = false;
				if (this.txOrigen.Text.Trim() == RemoteSettings.GetDefaultRemoteLocation(ProfileType.Anonymous, Loader.Version))
				{
					checkCredentials = true;
				}
				else if (this.txOrigen.Text.Trim() == RemoteSettings.GetDefaultRemoteLocation(ProfileType.Interno, Loader.Version))
				{
					checkCredentials = true;
				}
				else if (this.txOrigen.Text.Trim() == RemoteSettings.GetDefaultRemoteLocation(ProfileType.Departamento, Loader.Version))
				{
					checkCredentials = true;
				}
				else if (this.txOrigen.Text.Trim() == RemoteSettings.GetDefaultRemoteLocation(ProfileType.Administrador, Loader.Version))
				{
					checkCredentials = true;
				}
				else if (this.txOrigen.Text.Trim() == RemoteSettings.GetDefaultRemoteLocation(ProfileType.Root, Loader.Version))
				{
					checkCredentials = true;
				}
				bool useCredentials = false;
				string httpUsr = string.Empty;
				string httpPwd = string.Empty;
				if (checkCredentials)
				{
					bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadUsingCredentials), out useCredentials);
					if (useCredentials)
					{
						httpUsr = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadWithLogin);
						httpPwd = AdministradorPreferencias.Read(PrefsGlobal.AuthDownloadWithPassword);
					}
				}
				this._srs = (RemoteSettings) XMLUtils.DeserializarDocumento(this.txOrigen.Text.Trim(), httpUsr, httpPwd, typeof(RemoteSettings));
				this._srs.Desencriptar();
				this.BindSettings();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void TxOrigenKeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case ((Keys.Control | Keys.P)):
					this.txOrigen.Text = RemoteSettings.GetDefaultRemoteLocation(ProfileType.Anonymous, Loader.Version);
					break;
				case ((Keys.Control | Keys.I)):
					this.txOrigen.Text = RemoteSettings.GetDefaultRemoteLocation(ProfileType.Interno, Loader.Version);
					break;
				case ((Keys.Control | Keys.D)):
					this.txOrigen.Text = RemoteSettings.GetDefaultRemoteLocation(ProfileType.Departamento, Loader.Version);
					break;
				case ((Keys.Control | Keys.A)):
					this.txOrigen.Text = RemoteSettings.GetDefaultRemoteLocation(ProfileType.Administrador, Loader.Version);
					break;
				case ((Keys.Control | Keys.R)):
					this.txOrigen.Text = RemoteSettings.GetDefaultRemoteLocation(ProfileType.Root, Loader.Version);
					break;
			}			
		}
		
		void BUploadClick(object sender, EventArgs e)
		{
			WebClient wcli = new WebClient();
			try
			{
				if (txDestino.Text.Trim() != string.Empty)
				{
					NameValueCollection nvc = new NameValueCollection();
					nvc.Add("FILENAME", _srs.BuildFormalFileName());
					nvc.Add("DATA", _srs.Serializar(true));
					byte[] r = wcli.UploadValues(txDestino.Text.Trim(), nvc);
					System.Diagnostics.Debug.Print(System.Text.ASCIIEncoding.ASCII.GetString(r));
					if (wcli.ResponseHeaders["Status"] != null)
					{
						switch (wcli.ResponseHeaders["Status"])
						{
							case "200":
								MessageBox.Show("El servidor de destino respondió: 200 (OK)", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
								break;
							case "404":
								throw new Exception("El servidor de destino respondió: 404 (Not found)");
							default:
								throw new Exception(string.Format("El servidor de destino respondió: {0}", wcli.ResponseHeaders["Status"]));
						}
					}
					else
					{
						throw new Exception("El destino no es válido");
					}
				}
				else
				{
					throw new Exception("No se ha especificado URI de destino");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}			
		}
	}
}
