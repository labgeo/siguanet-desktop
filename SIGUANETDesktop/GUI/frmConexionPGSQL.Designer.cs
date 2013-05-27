/*
 * Created by SharpDevelop.
 * User: ${USER}
 * Date: ${DATE}
 * Time: ${TIME}
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmConexionPGSQL : System.Windows.Forms.Form
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
			this.lbUsuario = new System.Windows.Forms.Label();
			this.lbClave = new System.Windows.Forms.Label();
			this.lbPuerto = new System.Windows.Forms.Label();
			this.lbServidor = new System.Windows.Forms.Label();
			this.lbBD = new System.Windows.Forms.Label();
			this.txServidor = new System.Windows.Forms.TextBox();
			this.txBD = new System.Windows.Forms.TextBox();
			this.txPuerto = new System.Windows.Forms.TextBox();
			this.txUsuario = new System.Windows.Forms.TextBox();
			this.txClave = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// bCancelar
			// 
			this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancelar.Location = new System.Drawing.Point(221, 140);
			this.bCancelar.Name = "bCancelar";
			this.bCancelar.Size = new System.Drawing.Size(59, 30);
			this.bCancelar.TabIndex = 6;
			this.bCancelar.Text = "Cancelar";
			this.bCancelar.UseVisualStyleBackColor = true;
			this.bCancelar.Click += new System.EventHandler(this.BCancelarClick);
			// 
			// bAceptar
			// 
			this.bAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAceptar.Location = new System.Drawing.Point(156, 140);
			this.bAceptar.Name = "bAceptar";
			this.bAceptar.Size = new System.Drawing.Size(59, 30);
			this.bAceptar.TabIndex = 5;
			this.bAceptar.Text = "Aceptar";
			this.bAceptar.UseVisualStyleBackColor = true;
			this.bAceptar.Click += new System.EventHandler(this.BAceptarClick);
			// 
			// lbUsuario
			// 
			this.lbUsuario.AutoSize = true;
			this.lbUsuario.Location = new System.Drawing.Point(12, 90);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(46, 13);
			this.lbUsuario.TabIndex = 5;
			this.lbUsuario.Text = "Usuario:";
			// 
			// lbClave
			// 
			this.lbClave.AutoSize = true;
			this.lbClave.Location = new System.Drawing.Point(12, 117);
			this.lbClave.Name = "lbClave";
			this.lbClave.Size = new System.Drawing.Size(37, 13);
			this.lbClave.TabIndex = 6;
			this.lbClave.Text = "Clave:";
			// 
			// lbPuerto
			// 
			this.lbPuerto.AutoSize = true;
			this.lbPuerto.Location = new System.Drawing.Point(12, 36);
			this.lbPuerto.Name = "lbPuerto";
			this.lbPuerto.Size = new System.Drawing.Size(41, 13);
			this.lbPuerto.TabIndex = 8;
			this.lbPuerto.Text = "Puerto:";
			// 
			// lbServidor
			// 
			this.lbServidor.AutoSize = true;
			this.lbServidor.Location = new System.Drawing.Point(12, 9);
			this.lbServidor.Name = "lbServidor";
			this.lbServidor.Size = new System.Drawing.Size(49, 13);
			this.lbServidor.TabIndex = 7;
			this.lbServidor.Text = "Servidor:";
			// 
			// lbBD
			// 
			this.lbBD.AutoSize = true;
			this.lbBD.Location = new System.Drawing.Point(12, 63);
			this.lbBD.Name = "lbBD";
			this.lbBD.Size = new System.Drawing.Size(78, 13);
			this.lbBD.TabIndex = 9;
			this.lbBD.Text = "Base de datos:";
			// 
			// txServidor
			// 
			this.txServidor.Location = new System.Drawing.Point(97, 6);
			this.txServidor.MaxLength = 50;
			this.txServidor.Name = "txServidor";
			this.txServidor.Size = new System.Drawing.Size(183, 20);
			this.txServidor.TabIndex = 0;
			// 
			// txBD
			// 
			this.txBD.Location = new System.Drawing.Point(97, 60);
			this.txBD.MaxLength = 50;
			this.txBD.Name = "txBD";
			this.txBD.Size = new System.Drawing.Size(183, 20);
			this.txBD.TabIndex = 2;
			// 
			// txPuerto
			// 
			this.txPuerto.Location = new System.Drawing.Point(97, 33);
			this.txPuerto.MaxLength = 4;
			this.txPuerto.Name = "txPuerto";
			this.txPuerto.Size = new System.Drawing.Size(183, 20);
			this.txPuerto.TabIndex = 1;
			// 
			// txUsuario
			// 
			this.txUsuario.Location = new System.Drawing.Point(97, 87);
			this.txUsuario.MaxLength = 50;
			this.txUsuario.Name = "txUsuario";
			this.txUsuario.Size = new System.Drawing.Size(183, 20);
			this.txUsuario.TabIndex = 3;
			// 
			// txClave
			// 
			this.txClave.Location = new System.Drawing.Point(97, 114);
			this.txClave.MaxLength = 50;
			this.txClave.Name = "txClave";
			this.txClave.PasswordChar = '*';
			this.txClave.Size = new System.Drawing.Size(183, 20);
			this.txClave.TabIndex = 4;
			// 
			// frmConexionPGSQL
			// 
			this.AcceptButton = this.bAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancelar;
			this.ClientSize = new System.Drawing.Size(292, 180);
			this.Controls.Add(this.txClave);
			this.Controls.Add(this.txUsuario);
			this.Controls.Add(this.txPuerto);
			this.Controls.Add(this.txBD);
			this.Controls.Add(this.txServidor);
			this.Controls.Add(this.lbBD);
			this.Controls.Add(this.lbPuerto);
			this.Controls.Add(this.lbServidor);
			this.Controls.Add(this.lbClave);
			this.Controls.Add(this.lbUsuario);
			this.Controls.Add(this.bCancelar);
			this.Controls.Add(this.bAceptar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConexionPGSQL";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Parámetros de conexión a PostgreSQL";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConexionPGSQLFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txClave;
		private System.Windows.Forms.TextBox txUsuario;
		private System.Windows.Forms.TextBox txPuerto;
		private System.Windows.Forms.TextBox txBD;
		private System.Windows.Forms.TextBox txServidor;
		private System.Windows.Forms.Label lbBD;
		private System.Windows.Forms.Label lbServidor;
		private System.Windows.Forms.Label lbPuerto;
		private System.Windows.Forms.Label lbClave;
		private System.Windows.Forms.Label lbUsuario;
		private System.Windows.Forms.Button bAceptar;
		private System.Windows.Forms.Button bCancelar;
	}
}
