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
	partial class frmConexionORA : System.Windows.Forms.Form
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
			this.txTNS = new System.Windows.Forms.TextBox();
			this.lbTNS = new System.Windows.Forms.Label();
			this.bCancelar = new System.Windows.Forms.Button();
			this.bAceptar = new System.Windows.Forms.Button();
			this.txClave = new System.Windows.Forms.TextBox();
			this.txUsuario = new System.Windows.Forms.TextBox();
			this.lbClave = new System.Windows.Forms.Label();
			this.lbUsuario = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txTNS
			// 
			this.txTNS.Location = new System.Drawing.Point(97, 9);
			this.txTNS.MaxLength = 50;
			this.txTNS.Name = "txTNS";
			this.txTNS.Size = new System.Drawing.Size(183, 20);
			this.txTNS.TabIndex = 0;
			// 
			// lbTNS
			// 
			this.lbTNS.AutoSize = true;
			this.lbTNS.Location = new System.Drawing.Point(12, 12);
			this.lbTNS.Name = "lbTNS";
			this.lbTNS.Size = new System.Drawing.Size(73, 13);
			this.lbTNS.TabIndex = 11;
			this.lbTNS.Text = "Servicio TNS:";
			// 
			// bCancelar
			// 
			this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancelar.Location = new System.Drawing.Point(221, 90);
			this.bCancelar.Name = "bCancelar";
			this.bCancelar.Size = new System.Drawing.Size(59, 30);
			this.bCancelar.TabIndex = 4;
			this.bCancelar.Text = "Cancelar";
			this.bCancelar.UseVisualStyleBackColor = true;
			this.bCancelar.Click += new System.EventHandler(this.BCancelarClick);
			// 
			// bAceptar
			// 
			this.bAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAceptar.Location = new System.Drawing.Point(156, 90);
			this.bAceptar.Name = "bAceptar";
			this.bAceptar.Size = new System.Drawing.Size(59, 30);
			this.bAceptar.TabIndex = 3;
			this.bAceptar.Text = "Aceptar";
			this.bAceptar.UseVisualStyleBackColor = true;
			this.bAceptar.Click += new System.EventHandler(this.BAceptarClick);
			// 
			// txClave
			// 
			this.txClave.Location = new System.Drawing.Point(97, 63);
			this.txClave.MaxLength = 50;
			this.txClave.Name = "txClave";
			this.txClave.PasswordChar = '*';
			this.txClave.Size = new System.Drawing.Size(183, 20);
			this.txClave.TabIndex = 2;
			// 
			// txUsuario
			// 
			this.txUsuario.Location = new System.Drawing.Point(97, 36);
			this.txUsuario.MaxLength = 50;
			this.txUsuario.Name = "txUsuario";
			this.txUsuario.Size = new System.Drawing.Size(183, 20);
			this.txUsuario.TabIndex = 1;
			// 
			// lbClave
			// 
			this.lbClave.AutoSize = true;
			this.lbClave.Location = new System.Drawing.Point(12, 66);
			this.lbClave.Name = "lbClave";
			this.lbClave.Size = new System.Drawing.Size(37, 13);
			this.lbClave.TabIndex = 15;
			this.lbClave.Text = "Clave:";
			// 
			// lbUsuario
			// 
			this.lbUsuario.AutoSize = true;
			this.lbUsuario.Location = new System.Drawing.Point(12, 39);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(46, 13);
			this.lbUsuario.TabIndex = 14;
			this.lbUsuario.Text = "Usuario:";
			// 
			// frmConexionORA
			// 
			this.AcceptButton = this.bAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancelar;
			this.ClientSize = new System.Drawing.Size(292, 131);
			this.Controls.Add(this.txClave);
			this.Controls.Add(this.txUsuario);
			this.Controls.Add(this.lbClave);
			this.Controls.Add(this.lbUsuario);
			this.Controls.Add(this.txTNS);
			this.Controls.Add(this.lbTNS);
			this.Controls.Add(this.bCancelar);
			this.Controls.Add(this.bAceptar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConexionORA";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Parámetros de conexión a Oracle";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lbUsuario;
		private System.Windows.Forms.Label lbClave;
		private System.Windows.Forms.TextBox txUsuario;
		private System.Windows.Forms.TextBox txClave;
		private System.Windows.Forms.Label lbTNS;
		private System.Windows.Forms.TextBox txTNS;
		private System.Windows.Forms.Button bAceptar;
		private System.Windows.Forms.Button bCancelar;
	}
}
