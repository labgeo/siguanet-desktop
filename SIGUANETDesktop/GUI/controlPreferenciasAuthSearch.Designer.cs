/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 13/03/2008
 * Hora: 10:13
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlPreferenciasAuthSearch
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
			this.txURL = new System.Windows.Forms.TextBox();
			this.lbURL = new System.Windows.Forms.Label();
			this.rbLocal = new System.Windows.Forms.RadioButton();
			this.rbRemote = new System.Windows.Forms.RadioButton();
			this.ckCredentials = new System.Windows.Forms.CheckBox();
			this.lLogin = new System.Windows.Forms.Label();
			this.txLogin = new System.Windows.Forms.TextBox();
			this.txPassword = new System.Windows.Forms.TextBox();
			this.lPassword = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txURL
			// 
			this.txURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txURL.Location = new System.Drawing.Point(22, 65);
			this.txURL.Name = "txURL";
			this.txURL.Size = new System.Drawing.Size(326, 20);
			this.txURL.TabIndex = 3;
			this.txURL.TextChanged += new System.EventHandler(this.TxURLTextChanged);
			// 
			// lbURL
			// 
			this.lbURL.AutoSize = true;
			this.lbURL.Location = new System.Drawing.Point(22, 49);
			this.lbURL.Name = "lbURL";
			this.lbURL.Size = new System.Drawing.Size(82, 13);
			this.lbURL.TabIndex = 2;
			this.lbURL.Text = "URL de enlace:";
			// 
			// rbLocal
			// 
			this.rbLocal.AutoSize = true;
			this.rbLocal.Location = new System.Drawing.Point(6, 6);
			this.rbLocal.Name = "rbLocal";
			this.rbLocal.Size = new System.Drawing.Size(180, 17);
			this.rbLocal.TabIndex = 4;
			this.rbLocal.TabStop = true;
			this.rbLocal.Text = "Obtener credenciales localmente";
			this.rbLocal.UseVisualStyleBackColor = true;
			this.rbLocal.CheckedChanged += new System.EventHandler(this.RbLocalCheckedChanged);
			// 
			// rbRemote
			// 
			this.rbRemote.AutoSize = true;
			this.rbRemote.Location = new System.Drawing.Point(6, 29);
			this.rbRemote.Name = "rbRemote";
			this.rbRemote.Size = new System.Drawing.Size(196, 17);
			this.rbRemote.TabIndex = 5;
			this.rbRemote.TabStop = true;
			this.rbRemote.Text = "Obtener credenciales de un servidor";
			this.rbRemote.UseVisualStyleBackColor = true;
			this.rbRemote.CheckedChanged += new System.EventHandler(this.RbRemoteCheckedChanged);
			// 
			// ckCredentials
			// 
			this.ckCredentials.AutoSize = true;
			this.ckCredentials.Location = new System.Drawing.Point(22, 91);
			this.ckCredentials.Name = "ckCredentials";
			this.ckCredentials.Size = new System.Drawing.Size(260, 17);
			this.ckCredentials.TabIndex = 6;
			this.ckCredentials.Text = "Se requieren credenciales para acceder a la URL";
			this.ckCredentials.UseVisualStyleBackColor = true;
			this.ckCredentials.CheckedChanged += new System.EventHandler(this.CkCredentialsCheckedChanged);
			// 
			// lLogin
			// 
			this.lLogin.AutoSize = true;
			this.lLogin.Location = new System.Drawing.Point(22, 111);
			this.lLogin.Name = "lLogin";
			this.lLogin.Size = new System.Drawing.Size(46, 13);
			this.lLogin.TabIndex = 7;
			this.lLogin.Text = "Usuario:";
			// 
			// txLogin
			// 
			this.txLogin.Location = new System.Drawing.Point(22, 127);
			this.txLogin.Name = "txLogin";
			this.txLogin.Size = new System.Drawing.Size(106, 20);
			this.txLogin.TabIndex = 8;
			this.txLogin.TextChanged += new System.EventHandler(this.TxLoginTextChanged);
			// 
			// txPassword
			// 
			this.txPassword.Location = new System.Drawing.Point(134, 127);
			this.txPassword.Name = "txPassword";
			this.txPassword.PasswordChar = '*';
			this.txPassword.Size = new System.Drawing.Size(106, 20);
			this.txPassword.TabIndex = 10;
			this.txPassword.TextChanged += new System.EventHandler(this.TxPasswordTextChanged);
			// 
			// lPassword
			// 
			this.lPassword.AutoSize = true;
			this.lPassword.Location = new System.Drawing.Point(134, 111);
			this.lPassword.Name = "lPassword";
			this.lPassword.Size = new System.Drawing.Size(64, 13);
			this.lPassword.TabIndex = 9;
			this.lPassword.Text = "Contraseña:";
			// 
			// controlPreferenciasAuthSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txPassword);
			this.Controls.Add(this.lPassword);
			this.Controls.Add(this.txLogin);
			this.Controls.Add(this.lLogin);
			this.Controls.Add(this.ckCredentials);
			this.Controls.Add(this.rbLocal);
			this.Controls.Add(this.rbRemote);
			this.Controls.Add(this.txURL);
			this.Controls.Add(this.lbURL);
			this.Name = "controlPreferenciasAuthSearch";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(354, 163);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lPassword;
		private System.Windows.Forms.TextBox txPassword;
		private System.Windows.Forms.TextBox txLogin;
		private System.Windows.Forms.Label lLogin;
		private System.Windows.Forms.CheckBox ckCredentials;
		private System.Windows.Forms.RadioButton rbRemote;
		private System.Windows.Forms.RadioButton rbLocal;
		private System.Windows.Forms.Label lbURL;
		private System.Windows.Forms.TextBox txURL;
	}
}
