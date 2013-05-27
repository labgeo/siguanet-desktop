/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 18/04/2008
 * Hora: 8:04
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.Extension;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmAutentificacion.
	/// </summary>
	public partial class frmAutentificacion : Form, IUserLoginView
	{
		private string _usr = string.Empty;
		public string Usr
		{
			get
			{
				return this._usr;
			}
		}
		
		private string _clave = string.Empty;
		public string Clave
		{
			get
			{
				return this._clave;
			}
		}
		
		public bool IsAnonymous
		{
			get 
			{
				return this.rbAnonimo.Checked;
			}
		}
		
		private string _perfilPersonalizado = string.Empty;
		public string PerfilPersonalizado
		{
			get
			{
				return this._perfilPersonalizado;
			}
		}
		
		private bool _SRSByPass = false;
		public bool SRSByPass 
		{
			get 
			{
				return _SRSByPass; 
			}
		}
		
		public frmAutentificacion()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
			this.rbAnonimo.Checked = true;
			this.lbPerfilPersonalizado.Enabled = this.txPerfilPersonalizado.Enabled = true;
			this.lbUsuario.Enabled = this.txUsuario.Enabled = this.ckSRSBypass.Enabled = false;
		}
		
		public object[] GetAuthInfo ()
		{
			return new object[] { this._usr };
		}
		
		public void ShowView ()
		{
			this.ShowDialog ();
		}
		
		void RbAutentificadoCheckedChanged(object sender, EventArgs e)
		{
			this.lbPerfilPersonalizado.Enabled = this.txPerfilPersonalizado.Enabled = this.rbAnonimo.Checked;
			this.lbUsuario.Enabled = this.txUsuario.Enabled = 
				this.ckSRSBypass.Enabled = this.rbAutentificado.Checked;
			if (!this.rbAutentificado.Checked)
			{
				this.txUsuario.Text = this._usr = string.Empty;
			}
			else
			{
				this.txUsuario.Focus();
			}
		}

		void TxUsuarioTextChanged(object sender, EventArgs e)
		{
			this._usr = this.txUsuario.Text;
		}
			
		void TxPerfilPersonalizadoTextChanged(object sender, EventArgs e)
		{
			this._perfilPersonalizado = this.txPerfilPersonalizado.Text;
		}
		
		void CkSRSBypassCheckedChanged(object sender, EventArgs e)
		{
			this._SRSByPass = this.ckSRSBypass.Checked;
		}
	}
}
