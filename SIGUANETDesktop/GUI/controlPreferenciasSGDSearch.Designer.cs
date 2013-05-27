/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 12/03/2008
 * Hora: 14:13
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlPreferenciasSGDSearch
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.rbLocal = new System.Windows.Forms.RadioButton();
			this.rbRemote = new System.Windows.Forms.RadioButton();
			this.lbURL = new System.Windows.Forms.Label();
			this.txURL = new System.Windows.Forms.TextBox();
			this.ckUseLocalCopy = new System.Windows.Forms.CheckBox();
			this.txPassword = new System.Windows.Forms.TextBox();
			this.lPassword = new System.Windows.Forms.Label();
			this.txLogin = new System.Windows.Forms.TextBox();
			this.lLogin = new System.Windows.Forms.Label();
			this.ckCredentials = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// rbLocal
			// 
			this.rbLocal.AutoSize = true;
			this.rbLocal.Location = new System.Drawing.Point(6, 6);
			this.rbLocal.Name = "rbLocal";
			this.rbLocal.Size = new System.Drawing.Size(187, 17);
			this.rbLocal.TabIndex = 0;
			this.rbLocal.TabStop = true;
			this.rbLocal.Text = "Utilizar siempre el documento local";
			this.rbLocal.UseVisualStyleBackColor = true;
			this.rbLocal.CheckedChanged += new System.EventHandler(this.RbLocalCheckedChanged);
			// 
			// rbRemote
			// 
			this.rbRemote.AutoSize = true;
			this.rbRemote.Location = new System.Drawing.Point(6, 29);
			this.rbRemote.Name = "rbRemote";
			this.rbRemote.Size = new System.Drawing.Size(200, 17);
			this.rbRemote.TabIndex = 1;
			this.rbRemote.TabStop = true;
			this.rbRemote.Text = "Obtener el documento de un servidor";
			this.rbRemote.UseVisualStyleBackColor = true;
			this.rbRemote.CheckedChanged += new System.EventHandler(this.RbRemoteCheckedChanged);
			// 
			// lbURL
			// 
			this.lbURL.AutoSize = true;
			this.lbURL.Location = new System.Drawing.Point(23, 49);
			this.lbURL.Name = "lbURL";
			this.lbURL.Size = new System.Drawing.Size(82, 13);
			this.lbURL.TabIndex = 2;
			this.lbURL.Text = "URL de enlace:";
			// 
			// txURL
			// 
			this.txURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txURL.Location = new System.Drawing.Point(23, 65);
			this.txURL.Name = "txURL";
			this.txURL.Size = new System.Drawing.Size(325, 20);
			this.txURL.TabIndex = 3;
			this.txURL.TextChanged += new System.EventHandler(this.TxURLTextChanged);
			// 
			// ckUseLocalCopy
			// 
			this.ckUseLocalCopy.AutoSize = true;
			this.ckUseLocalCopy.Location = new System.Drawing.Point(23, 91);
			this.ckUseLocalCopy.Name = "ckUseLocalCopy";
			this.ckUseLocalCopy.Size = new System.Drawing.Size(263, 17);
			this.ckUseLocalCopy.TabIndex = 4;
			this.ckUseLocalCopy.Text = "Usar copia local cuando la URL no esté accesible";
			this.ckUseLocalCopy.UseVisualStyleBackColor = true;
			this.ckUseLocalCopy.CheckedChanged += new System.EventHandler(this.CkUseLocalCopyCheckedChanged);
			// 
			// txPassword
			// 
			this.txPassword.Location = new System.Drawing.Point(135, 150);
			this.txPassword.Name = "txPassword";
			this.txPassword.PasswordChar = '*';
			this.txPassword.Size = new System.Drawing.Size(106, 20);
			this.txPassword.TabIndex = 15;
			this.txPassword.TextChanged += new System.EventHandler(this.TxPasswordTextChanged);
			// 
			// lPassword
			// 
			this.lPassword.AutoSize = true;
			this.lPassword.Location = new System.Drawing.Point(135, 134);
			this.lPassword.Name = "lPassword";
			this.lPassword.Size = new System.Drawing.Size(64, 13);
			this.lPassword.TabIndex = 14;
			this.lPassword.Text = "Contraseña:";
			// 
			// txLogin
			// 
			this.txLogin.Location = new System.Drawing.Point(23, 150);
			this.txLogin.Name = "txLogin";
			this.txLogin.Size = new System.Drawing.Size(106, 20);
			this.txLogin.TabIndex = 13;
			this.txLogin.TextChanged += new System.EventHandler(this.TxLoginTextChanged);
			// 
			// lLogin
			// 
			this.lLogin.AutoSize = true;
			this.lLogin.Location = new System.Drawing.Point(23, 134);
			this.lLogin.Name = "lLogin";
			this.lLogin.Size = new System.Drawing.Size(46, 13);
			this.lLogin.TabIndex = 12;
			this.lLogin.Text = "Usuario:";
			// 
			// ckCredentials
			// 
			this.ckCredentials.AutoSize = true;
			this.ckCredentials.Location = new System.Drawing.Point(23, 114);
			this.ckCredentials.Name = "ckCredentials";
			this.ckCredentials.Size = new System.Drawing.Size(260, 17);
			this.ckCredentials.TabIndex = 11;
			this.ckCredentials.Text = "Se requieren credenciales para acceder a la URL";
			this.ckCredentials.UseVisualStyleBackColor = true;
			this.ckCredentials.CheckedChanged += new System.EventHandler(this.CkCredentialsCheckedChanged);
			// 
			// controlPreferenciasSGDSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txPassword);
			this.Controls.Add(this.lPassword);
			this.Controls.Add(this.txLogin);
			this.Controls.Add(this.lLogin);
			this.Controls.Add(this.ckCredentials);
			this.Controls.Add(this.ckUseLocalCopy);
			this.Controls.Add(this.txURL);
			this.Controls.Add(this.lbURL);
			this.Controls.Add(this.rbLocal);
			this.Controls.Add(this.rbRemote);
			this.Name = "controlPreferenciasSGDSearch";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(354, 179);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox ckCredentials;
		private System.Windows.Forms.Label lLogin;
		private System.Windows.Forms.TextBox txLogin;
		private System.Windows.Forms.Label lPassword;
		private System.Windows.Forms.TextBox txPassword;
		private System.Windows.Forms.CheckBox ckUseLocalCopy;
		private System.Windows.Forms.RadioButton rbRemote;
		private System.Windows.Forms.RadioButton rbLocal;
		private System.Windows.Forms.TextBox txURL;
		private System.Windows.Forms.Label lbURL;
	}
}
