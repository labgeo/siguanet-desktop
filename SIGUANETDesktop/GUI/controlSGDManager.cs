/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 18/03/2008
 * Hora: 9:44
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.Perfiles;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.Preferencias;
using SIGUANETDesktop.XML;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlSGDmanager.
	/// </summary>
	public partial class controlSGDManager : UserControl
	{
		private Root _doc = new Root();
		public controlSGDManager()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.cbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbPerfil.DataSource = Enum.GetValues(typeof(ProfileType));
			this.ckSinCaducidad.Enabled = false;
			this.ckSinCaducidad.Checked = true;
			this.dateTimePicker1.MaxDate = Root.NO_EXPIRATION;
			this.BindSettings();
		}
		
		private void BindSettings()
		{
			this.txVersion.DataBindings.Clear();
			this.txVersion.DataBindings.Add("Text", this._doc, "Version");
			this.txAutor.DataBindings.Clear();
			this.txAutor.DataBindings.Add("Text", this._doc, "Autor");
			this.cbPerfil.DataBindings.Clear();
			this.cbPerfil.DataBindings.Add("SelectedItem", this._doc, "Perfil");
			this.txPerfilPersonalizado.DataBindings.Clear();
			this.txPerfilPersonalizado.DataBindings.Add("Text", this._doc, "PerfilPersonalizado");
			this.dateTimePicker1.DataBindings.Clear();
			this.dateTimePicker1.DataBindings.Add("Value", this._doc, "Caducidad");
			this.ckSinCaducidad.CheckedChanged -= this.CkSinCaducidadCheckedChanged;
			this.ckSinCaducidad.Checked = (this._doc.Caducidad == Root.NO_EXPIRATION);
			this.dateTimePicker1.Enabled = !this.ckSinCaducidad.Checked;
			this.ckSinCaducidad.CheckedChanged += this.CkSinCaducidadCheckedChanged;
			this.tvModulos.Nodes.Clear();
			foreach (PropertyInfo p in this._doc.RootModules)
			{
				TreeNode n = new TreeNode(p.Name);
				n.Tag = p;
				n.Checked = (p.GetValue(this._doc, null) as RootModule).Enabled;
				this.tvModulos.Nodes.Add(n);
			}
		}
		
		void TvModulosBeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			PropertyInfo p = (PropertyInfo) e.Node.Tag;
			RootModule rmod = (RootModule) p.GetValue(this._doc, null);
			if (e.Node.Checked && rmod.HasData)
			{
				DialogResult r = MessageBox.Show("Se perderán todos los datos asociados a este módulo del documento cargado en memoria (los cambios no afectan al documento en origen). ¿Deshabilitar de todas formas?", "Gestor de plantillas SGD", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (r == DialogResult.No) e.Cancel = true;
			}
		}
		
		void TvModulosAfterCheck(object sender, TreeViewEventArgs e)
		{
			PropertyInfo p = (PropertyInfo) e.Node.Tag;
			RootModule rmod = (RootModule) p.GetValue(this._doc, null);
			rmod.Enabled = e.Node.Checked;
		}
		
		void BGuardarClick(object sender, EventArgs e)
		{
			this.folderBrowserDialog1.Description = "Seleccione la carpeta de destino";
			if (this.folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
			{
				//A todos los efectos se trata de un nuevo documento basado en un documento serializado de origen,
				//por tanto, establecemos la fecha
				this._doc.Modificado = DateTime.Now;
				this._doc.Serializar(this.folderBrowserDialog1.SelectedPath);
			}
		}
		
		void BOKClick(object sender, EventArgs e)
		{
			try
			{
				bool checkCredentials = false;
				if (this.txOrigen.Text.Trim() == RemoteSettings.GetDefaultRemoteLocation(ProfileType.Publico, Loader.Version))
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
					bool.TryParse(AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadUsingCredentials), out useCredentials);
					if (useCredentials)
					{
						httpUsr = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithLogin);
						httpPwd = AdministradorPreferencias.Read(PrefsGlobal.SGDDownloadWithPassword);
					}
				}
				
				this._doc = (Root) XMLUtils.DeserializarDocumento(this.txOrigen.Text.Trim(), httpUsr, httpPwd, typeof(Root));
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
					this.txOrigen.Text = Root.GetDefaultRemoteLocation(ProfileType.Publico, string.Empty, Loader.Version);
					break;
				case ((Keys.Control | Keys.I)):
					this.txOrigen.Text = Root.GetDefaultRemoteLocation(ProfileType.Interno, string.Empty, Loader.Version);
					break;
				case ((Keys.Control | Keys.D)):
					this.txOrigen.Text = Root.GetDefaultRemoteLocation(ProfileType.Departamento, string.Empty, Loader.Version);
					break;
				case ((Keys.Control | Keys.A)):
					this.txOrigen.Text = Root.GetDefaultRemoteLocation(ProfileType.Administrador, string.Empty, Loader.Version);
					break;
				case ((Keys.Control | Keys.R)):
					this.txOrigen.Text = Root.GetDefaultRemoteLocation(ProfileType.Root, string.Empty, Loader.Version);
					break;
			}
		}
		
		void CkSinCaducidadCheckedChanged(object sender, EventArgs e)
		{
			//La caducidad sólo aplica a perfiles personalizados
			if (this._doc.PerfilPersonalizado != string.Empty)
			{
				this.dateTimePicker1.Enabled = !this.ckSinCaducidad.Checked;
				if (this.ckSinCaducidad.Checked)
				{
					this.dateTimePicker1.Value = Root.NO_EXPIRATION;
				}
				else
				{
					this.dateTimePicker1.Value = DateTime.Now;
				}
			}
		}
		
		void TxPerfilPersonalizadoTextChanged(object sender, EventArgs e)
		{
			this.ckSinCaducidad.Enabled = (this.txPerfilPersonalizado.Text.Trim() != string.Empty);
		}
	}
}
