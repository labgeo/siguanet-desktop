/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 24/04/2008
 * Hora: 16:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.Perfiles;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmSuplantacion.
	/// </summary>
	public partial class frmSuplantacion : Form
	{	
		private bool _usarDefault = true;
		public bool UsarDefault
		{
			get
			{
				return _usarDefault;
			}
			set
			{
				_usarDefault = value;
			}
		}
		
		private ProfileType _perfil = ProfileType.Root;
		public ProfileType Perfil
		{
			get
			{
				return _perfil;
			}
			set
			{
				_perfil = value;
			}
		}
		
		private string _perfilPersonalizado = string.Empty;
		public string PerfilPersonalizado
		{
			get
			{
				return _perfilPersonalizado;
			}
			set
			{
				_perfilPersonalizado = value;
			}
		}		
		
		public frmSuplantacion()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			if (Loader.CustomProfile == null || Loader.CustomProfile == string.Empty)
			{
				this.lbPerfilDefault.Text = string.Format("({0})", Enum.GetName(typeof(ProfileType), Loader.Profile));
			}
			else
			{
				this.lbPerfilDefault.Text = string.Format("({0}.{1})", Enum.GetName(typeof(ProfileType), Loader.Profile), Loader.CustomProfile);
			}
			
			this.cbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbPerfil.DataSource = Enum.GetValues(typeof(ProfileType));
			this.cbPerfil.DataBindings.Clear();
			this.cbPerfil.DataBindings.Add("SelectedItem", this, "Perfil");
			this.cbPerfil.SelectedIndex = 0;
			this.txPerfilPersonalizado.DataBindings.Clear();
			this.txPerfilPersonalizado.DataBindings.Add("Text", this, "PerfilPersonalizado");
		}
		
		void RbPerfilDefaultCheckedChanged(object sender, EventArgs e)
		{
			this._usarDefault = this.rbPerfilDefault.Checked;
			this.lbPerfil.Enabled = this.rbPerfilAjeno.Checked;
			this.cbPerfil.Enabled = this.rbPerfilAjeno.Checked;
			this.lbPerfilPersonalizado.Enabled = this.rbPerfilAjeno.Checked;
			this.txPerfilPersonalizado.Enabled = this.rbPerfilAjeno.Checked;
		}
	}
}
