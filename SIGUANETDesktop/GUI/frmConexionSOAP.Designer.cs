/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 28/02/2007
 * Time: 20:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmConexionSOAP : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.bCancelar = new System.Windows.Forms.Button();
			this.bAceptar = new System.Windows.Forms.Button();
			this.txWSDL = new System.Windows.Forms.TextBox();
			this.lbWSDL = new System.Windows.Forms.Label();
			this.txClave = new System.Windows.Forms.TextBox();
			this.txUsuario = new System.Windows.Forms.TextBox();
			this.lbClave = new System.Windows.Forms.Label();
			this.lbUsuario = new System.Windows.Forms.Label();
			this.lbWSUI = new System.Windows.Forms.Label();
			this.txWSUI = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpCredenciales = new System.Windows.Forms.TabPage();
			this.chCredencialesAnonimo = new System.Windows.Forms.CheckBox();
			this.tpAcceso = new System.Windows.Forms.TabPage();
			this.ckContractCredentials = new System.Windows.Forms.CheckBox();
			this.txContractUsr = new System.Windows.Forms.TextBox();
			this.lContractUsr = new System.Windows.Forms.Label();
			this.lContractPwd = new System.Windows.Forms.Label();
			this.txContractPwd = new System.Windows.Forms.TextBox();
			this.chAccesoDefault = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1.SuspendLayout();
			this.tpCredenciales.SuspendLayout();
			this.tpAcceso.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// bCancelar
			// 
			this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancelar.Location = new System.Drawing.Point(307, 6);
			this.bCancelar.Name = "bCancelar";
			this.bCancelar.Size = new System.Drawing.Size(59, 30);
			this.bCancelar.TabIndex = 12;
			this.bCancelar.Text = "Cancelar";
			this.bCancelar.UseVisualStyleBackColor = true;
			this.bCancelar.Click += new System.EventHandler(this.BCancelarClick);
			// 
			// bAceptar
			// 
			this.bAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAceptar.Location = new System.Drawing.Point(242, 6);
			this.bAceptar.Name = "bAceptar";
			this.bAceptar.Size = new System.Drawing.Size(59, 30);
			this.bAceptar.TabIndex = 11;
			this.bAceptar.Text = "Aceptar";
			this.bAceptar.UseVisualStyleBackColor = true;
			this.bAceptar.Click += new System.EventHandler(this.BAceptarClick);
			// 
			// txWSDL
			// 
			this.txWSDL.Enabled = false;
			this.txWSDL.Location = new System.Drawing.Point(67, 35);
			this.txWSDL.MaxLength = 50;
			this.txWSDL.Name = "txWSDL";
			this.txWSDL.Size = new System.Drawing.Size(288, 20);
			this.txWSDL.TabIndex = 8;
			// 
			// lbWSDL
			// 
			this.lbWSDL.AutoSize = true;
			this.lbWSDL.Enabled = false;
			this.lbWSDL.Location = new System.Drawing.Point(6, 38);
			this.lbWSDL.Name = "lbWSDL";
			this.lbWSDL.Size = new System.Drawing.Size(42, 13);
			this.lbWSDL.TabIndex = 7;
			this.lbWSDL.Text = "WSDL:";
			// 
			// txClave
			// 
			this.txClave.Enabled = false;
			this.txClave.Location = new System.Drawing.Point(66, 62);
			this.txClave.MaxLength = 50;
			this.txClave.Name = "txClave";
			this.txClave.PasswordChar = '*';
			this.txClave.Size = new System.Drawing.Size(288, 20);
			this.txClave.TabIndex = 5;
			// 
			// txUsuario
			// 
			this.txUsuario.Enabled = false;
			this.txUsuario.Location = new System.Drawing.Point(66, 35);
			this.txUsuario.MaxLength = 50;
			this.txUsuario.Name = "txUsuario";
			this.txUsuario.Size = new System.Drawing.Size(288, 20);
			this.txUsuario.TabIndex = 3;
			// 
			// lbClave
			// 
			this.lbClave.AutoSize = true;
			this.lbClave.Enabled = false;
			this.lbClave.Location = new System.Drawing.Point(8, 65);
			this.lbClave.Name = "lbClave";
			this.lbClave.Size = new System.Drawing.Size(37, 13);
			this.lbClave.TabIndex = 4;
			this.lbClave.Text = "Clave:";
			// 
			// lbUsuario
			// 
			this.lbUsuario.AutoSize = true;
			this.lbUsuario.Enabled = false;
			this.lbUsuario.Location = new System.Drawing.Point(8, 38);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(46, 13);
			this.lbUsuario.TabIndex = 2;
			this.lbUsuario.Text = "Usuario:";
			// 
			// lbWSUI
			// 
			this.lbWSUI.AutoSize = true;
			this.lbWSUI.Enabled = false;
			this.lbWSUI.Location = new System.Drawing.Point(6, 65);
			this.lbWSUI.Name = "lbWSUI";
			this.lbWSUI.Size = new System.Drawing.Size(39, 13);
			this.lbWSUI.TabIndex = 9;
			this.lbWSUI.Text = "WSUI:";
			// 
			// txWSUI
			// 
			this.txWSUI.Enabled = false;
			this.txWSUI.Location = new System.Drawing.Point(67, 62);
			this.txWSUI.MaxLength = 50;
			this.txWSUI.Name = "txWSUI";
			this.txWSUI.Size = new System.Drawing.Size(288, 20);
			this.txWSUI.TabIndex = 10;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpCredenciales);
			this.tabControl1.Controls.Add(this.tpAcceso);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(369, 189);
			this.tabControl1.TabIndex = 11;
			// 
			// tpCredenciales
			// 
			this.tpCredenciales.Controls.Add(this.chCredencialesAnonimo);
			this.tpCredenciales.Controls.Add(this.txUsuario);
			this.tpCredenciales.Controls.Add(this.lbUsuario);
			this.tpCredenciales.Controls.Add(this.lbClave);
			this.tpCredenciales.Controls.Add(this.txClave);
			this.tpCredenciales.Location = new System.Drawing.Point(4, 22);
			this.tpCredenciales.Name = "tpCredenciales";
			this.tpCredenciales.Padding = new System.Windows.Forms.Padding(3);
			this.tpCredenciales.Size = new System.Drawing.Size(361, 163);
			this.tpCredenciales.TabIndex = 0;
			this.tpCredenciales.Text = "Autentificación";
			this.tpCredenciales.UseVisualStyleBackColor = true;
			// 
			// chCredencialesAnonimo
			// 
			this.chCredencialesAnonimo.AutoSize = true;
			this.chCredencialesAnonimo.Checked = true;
			this.chCredencialesAnonimo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chCredencialesAnonimo.Location = new System.Drawing.Point(8, 13);
			this.chCredencialesAnonimo.Name = "chCredencialesAnonimo";
			this.chCredencialesAnonimo.Size = new System.Drawing.Size(175, 17);
			this.chCredencialesAnonimo.TabIndex = 1;
			this.chCredencialesAnonimo.Text = "Acceder como usuario anónimo";
			this.chCredencialesAnonimo.UseVisualStyleBackColor = true;
			this.chCredencialesAnonimo.CheckedChanged += new System.EventHandler(this.ChCredencialesAnonimoCheckedChanged);
			// 
			// tpAcceso
			// 
			this.tpAcceso.Controls.Add(this.ckContractCredentials);
			this.tpAcceso.Controls.Add(this.txContractUsr);
			this.tpAcceso.Controls.Add(this.lContractUsr);
			this.tpAcceso.Controls.Add(this.lContractPwd);
			this.tpAcceso.Controls.Add(this.txContractPwd);
			this.tpAcceso.Controls.Add(this.chAccesoDefault);
			this.tpAcceso.Controls.Add(this.txWSUI);
			this.tpAcceso.Controls.Add(this.lbWSDL);
			this.tpAcceso.Controls.Add(this.lbWSUI);
			this.tpAcceso.Controls.Add(this.txWSDL);
			this.tpAcceso.Location = new System.Drawing.Point(4, 22);
			this.tpAcceso.Name = "tpAcceso";
			this.tpAcceso.Padding = new System.Windows.Forms.Padding(3);
			this.tpAcceso.Size = new System.Drawing.Size(361, 163);
			this.tpAcceso.TabIndex = 1;
			this.tpAcceso.Text = "Puntos de acceso";
			this.tpAcceso.UseVisualStyleBackColor = true;
			// 
			// ckContractCredentials
			// 
			this.ckContractCredentials.AutoSize = true;
			this.ckContractCredentials.Location = new System.Drawing.Point(8, 88);
			this.ckContractCredentials.Name = "ckContractCredentials";
			this.ckContractCredentials.Size = new System.Drawing.Size(259, 17);
			this.ckContractCredentials.TabIndex = 11;
			this.ckContractCredentials.Text = "Usar credenciales para leer los puntos de acceso";
			this.ckContractCredentials.UseVisualStyleBackColor = true;
			this.ckContractCredentials.CheckedChanged += new System.EventHandler(this.CkContractCredentialsCheckedChanged);
			// 
			// txContractUsr
			// 
			this.txContractUsr.Enabled = false;
			this.txContractUsr.Location = new System.Drawing.Point(66, 110);
			this.txContractUsr.MaxLength = 50;
			this.txContractUsr.Name = "txContractUsr";
			this.txContractUsr.Size = new System.Drawing.Size(288, 20);
			this.txContractUsr.TabIndex = 13;
			// 
			// lContractUsr
			// 
			this.lContractUsr.AutoSize = true;
			this.lContractUsr.Enabled = false;
			this.lContractUsr.Location = new System.Drawing.Point(8, 113);
			this.lContractUsr.Name = "lContractUsr";
			this.lContractUsr.Size = new System.Drawing.Size(46, 13);
			this.lContractUsr.TabIndex = 12;
			this.lContractUsr.Text = "Usuario:";
			// 
			// lContractPwd
			// 
			this.lContractPwd.AutoSize = true;
			this.lContractPwd.Enabled = false;
			this.lContractPwd.Location = new System.Drawing.Point(8, 140);
			this.lContractPwd.Name = "lContractPwd";
			this.lContractPwd.Size = new System.Drawing.Size(37, 13);
			this.lContractPwd.TabIndex = 14;
			this.lContractPwd.Text = "Clave:";
			// 
			// txContractPwd
			// 
			this.txContractPwd.Enabled = false;
			this.txContractPwd.Location = new System.Drawing.Point(66, 137);
			this.txContractPwd.MaxLength = 50;
			this.txContractPwd.Name = "txContractPwd";
			this.txContractPwd.PasswordChar = '*';
			this.txContractPwd.Size = new System.Drawing.Size(288, 20);
			this.txContractPwd.TabIndex = 15;
			// 
			// chAccesoDefault
			// 
			this.chAccesoDefault.AutoSize = true;
			this.chAccesoDefault.Checked = true;
			this.chAccesoDefault.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chAccesoDefault.Location = new System.Drawing.Point(8, 12);
			this.chAccesoDefault.Name = "chAccesoDefault";
			this.chAccesoDefault.Size = new System.Drawing.Size(193, 17);
			this.chAccesoDefault.TabIndex = 6;
			this.chAccesoDefault.Text = "Usar puntos de acceso por defecto";
			this.chAccesoDefault.UseVisualStyleBackColor = true;
			this.chAccesoDefault.CheckedChanged += new System.EventHandler(this.ChAccesoDefaultCheckedChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bAceptar);
			this.panel1.Controls.Add(this.bCancelar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 189);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(369, 42);
			this.panel1.TabIndex = 12;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(369, 189);
			this.panel2.TabIndex = 13;
			// 
			// frmConexionSOAP
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 231);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConexionSOAP";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Parámetros de conexión al Servicio SOAP de SIGUANET";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConexionSOAPFormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tpCredenciales.ResumeLayout(false);
			this.tpCredenciales.PerformLayout();
			this.tpAcceso.ResumeLayout(false);
			this.tpAcceso.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox ckContractCredentials;
		private System.Windows.Forms.TextBox txContractUsr;
		private System.Windows.Forms.Label lContractUsr;
		private System.Windows.Forms.Label lContractPwd;
		private System.Windows.Forms.TextBox txContractPwd;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.CheckBox chAccesoDefault;
		private System.Windows.Forms.CheckBox chCredencialesAnonimo;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tpCredenciales;
		private System.Windows.Forms.TabPage tpAcceso;
		private System.Windows.Forms.TextBox txWSDL;
		private System.Windows.Forms.TextBox txWSUI;
		private System.Windows.Forms.Label lbWSUI;
		private System.Windows.Forms.Label lbWSDL;
		private System.Windows.Forms.Label lbUsuario;
		private System.Windows.Forms.Label lbClave;
		private System.Windows.Forms.TextBox txUsuario;
		private System.Windows.Forms.TextBox txClave;
		private System.Windows.Forms.Button bAceptar;
		private System.Windows.Forms.Button bCancelar;
	}
}
