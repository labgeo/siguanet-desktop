/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 15/05/2008
 * Hora: 8:37
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using SIGUANETDesktop.Perfiles;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlProfileBrowser.
	/// </summary>
	public partial class controlProfileBrowser : UserControl
	{
		public controlProfileBrowser()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.lbWarning.Visible = false;
			
		}
		
		void TxPersonaKeyUp(object sender, KeyEventArgs e)
		{
			Collection<UserProfile> collection = null;
			if (e.KeyData == Keys.Enter)
			{
				if (!DBSettings.PGSQLSettingsOK)
				{
					frmConexionPGSQL w = new frmConexionPGSQL();
					DialogResult r = w.ShowDialog();
					if (r == DialogResult.OK)
					{
						if (DBUtils.TestConnection(dbOrigen.PGSQL))
						{
							collection = UserProfileQuery.GetProfilesByUser(this.txPersona.Text.Trim());
						}
					}								
				}
				else
				{
					if (DBUtils.TestConnection(dbOrigen.PGSQL))
					{
						collection = UserProfileQuery.GetProfilesByUser(this.txPersona.Text.Trim());
					}
				}
				this.ClearAllSettings(true);
				if (collection != null && collection.Count > 0)
				{
					this.RenderList(collection);
				}
			}
		}
		
		private void RenderList(Collection<UserProfile> collection)
		{
			this.lvUsuarios.Clear();
			foreach (UserProfile up in collection)
			{
				ListViewItem u = new ListViewItem(up.UserName);
				u.Tag = up;
				this.lvUsuarios.Items.Add(u);
			}
		}
		
		private void UserBindSettings(UserProfile up)
		{
			this.txNIF.DataBindings.Clear();
			this.txNIF.DataBindings.Add("Text", up, "UserId");
			this.txIdDpto.DataBindings.Clear();
			this.txIdDpto.DataBindings.Add("Text", up, "ManagedDeptId");
			this.txNombreDpto.DataBindings.Clear();
			this.txNombreDpto.DataBindings.Add("Text", up, "ManagedDeptName");
			this.lvPerfiles.Clear();
			foreach (Profile p in up.Profiles)
			{
				ListViewItem pItem = new ListViewItem(p.ToString(), 0);
				pItem.Tag = p;
				this.lvPerfiles.Items.Add(pItem);
			}
			
			if (this.lvPerfiles.Items.Count > 0)
			{
				this.lvPerfiles.Items[0].Selected = true;
			}
		}
		
		private void ProfileBindSettings(Profile p)
		{
			this.txGenerico.DataBindings.Clear();
			this.txGenerico.DataBindings.Add("Text", p, "Generic");
			this.txPersonalizado.DataBindings.Clear();
			this.txPersonalizado.DataBindings.Add("Text", p, "Custom");
			this.txLocalizacion.DataBindings.Clear();
			this.txLocalizacion.DataBindings.Add("Text", p, "SGDLocation");
			this.txDescripcion.DataBindings.Clear();
			this.txDescripcion.DataBindings.Add("Text", p, "SGDDescription");
			this.txCaducidad.DataBindings.Clear();
			this.txCaducidad.DataBindings.Add("Text", p, "SGDExpirationDate");
			this.lbWarning.Visible = !p.SGDDeserialized;
		}
		
		private void ClearAllSettings(bool clearUsers)
		{
			if (clearUsers) this.lvUsuarios.Clear();
			this.txNIF.DataBindings.Clear();
			this.txNIF.Clear();
			this.txIdDpto.DataBindings.Clear();
			this.txIdDpto.Clear();
			this.txNombreDpto.DataBindings.Clear();
			this.txNombreDpto.Clear();
			
			this.lvPerfiles.Clear();
			this.txGenerico.DataBindings.Clear();
			this.txGenerico.Clear();
			this.txPersonalizado.DataBindings.Clear();
			this.txPersonalizado.Clear();
			this.txLocalizacion.DataBindings.Clear();
			this.txLocalizacion.Clear();
			this.txDescripcion.DataBindings.Clear();
			this.txDescripcion.Clear();
			this.lbWarning.Visible = false;
		}
		
		void LvUsuariosSelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lvUsuarios.SelectedItems.Count > 0)
			{
				this.ClearAllSettings(false);
				this.UserBindSettings((UserProfile) this.lvUsuarios.SelectedItems[0].Tag);
			}
		}
		
		void LvPerfilesSelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lvPerfiles.SelectedItems.Count > 0)
			{
				this.ProfileBindSettings((Profile) this.lvPerfiles.SelectedItems[0].Tag);
			}
		}
	}
}
