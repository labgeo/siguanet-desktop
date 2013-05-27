/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 09/05/2008
 * Hora: 13:46
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmPerfilMultiple
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
			this.bOK = new System.Windows.Forms.Button();
			this.lbTitulo = new System.Windows.Forms.Label();
			this.cbPerfil = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// bOK
			// 
			this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bOK.Location = new System.Drawing.Point(151, 52);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(67, 23);
			this.bOK.TabIndex = 8;
			this.bOK.Text = "Continuar";
			this.bOK.UseVisualStyleBackColor = true;
			// 
			// lbTitulo
			// 
			this.lbTitulo.AutoSize = true;
			this.lbTitulo.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lbTitulo.Location = new System.Drawing.Point(12, 9);
			this.lbTitulo.Name = "lbTitulo";
			this.lbTitulo.Size = new System.Drawing.Size(211, 13);
			this.lbTitulo.TabIndex = 9;
			this.lbTitulo.Text = "¿Con qué perfil de usuario deseas trabajar?";
			// 
			// cbPerfil
			// 
			this.cbPerfil.FormattingEnabled = true;
			this.cbPerfil.Location = new System.Drawing.Point(9, 25);
			this.cbPerfil.Name = "cbPerfil";
			this.cbPerfil.Size = new System.Drawing.Size(209, 21);
			this.cbPerfil.TabIndex = 10;
			// 
			// frmPerfilMultiple
			// 
			this.AcceptButton = this.bOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(230, 87);
			this.Controls.Add(this.cbPerfil);
			this.Controls.Add(this.lbTitulo);
			this.Controls.Add(this.bOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPerfilMultiple";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmPerfilMultiple";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox cbPerfil;
		private System.Windows.Forms.Label lbTitulo;
		private System.Windows.Forms.Button bOK;
	}
}
