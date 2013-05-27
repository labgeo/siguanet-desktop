/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 24/04/2008
 * Hora: 16:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmSuplantacion
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
			this.cbPerfil = new System.Windows.Forms.ComboBox();
			this.lbTitulo = new System.Windows.Forms.Label();
			this.bOK = new System.Windows.Forms.Button();
			this.lbPerfilPersonalizado = new System.Windows.Forms.Label();
			this.txPerfilPersonalizado = new System.Windows.Forms.TextBox();
			this.rbPerfilDefault = new System.Windows.Forms.RadioButton();
			this.rbPerfilAjeno = new System.Windows.Forms.RadioButton();
			this.lbPerfil = new System.Windows.Forms.Label();
			this.lbPerfilDefault = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbPerfil
			// 
			this.cbPerfil.FormattingEnabled = true;
			this.cbPerfil.Location = new System.Drawing.Point(12, 84);
			this.cbPerfil.Name = "cbPerfil";
			this.cbPerfil.Size = new System.Drawing.Size(214, 21);
			this.cbPerfil.TabIndex = 4;
			// 
			// lbTitulo
			// 
			this.lbTitulo.AutoSize = true;
			this.lbTitulo.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lbTitulo.Location = new System.Drawing.Point(12, 9);
			this.lbTitulo.Name = "lbTitulo";
			this.lbTitulo.Size = new System.Drawing.Size(211, 13);
			this.lbTitulo.TabIndex = 0;
			this.lbTitulo.Text = "¿Con qué perfil de usuario deseas trabajar?";
			// 
			// bOK
			// 
			this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bOK.Location = new System.Drawing.Point(159, 150);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(67, 23);
			this.bOK.TabIndex = 7;
			this.bOK.Text = "Continuar";
			this.bOK.UseVisualStyleBackColor = true;
			// 
			// lbPerfilPersonalizado
			// 
			this.lbPerfilPersonalizado.AutoSize = true;
			this.lbPerfilPersonalizado.Location = new System.Drawing.Point(12, 108);
			this.lbPerfilPersonalizado.Name = "lbPerfilPersonalizado";
			this.lbPerfilPersonalizado.Size = new System.Drawing.Size(150, 13);
			this.lbPerfilPersonalizado.TabIndex = 5;
			this.lbPerfilPersonalizado.Text = "Perfil personalizado (opcional):";
			// 
			// txPerfilPersonalizado
			// 
			this.txPerfilPersonalizado.Location = new System.Drawing.Point(12, 124);
			this.txPerfilPersonalizado.Name = "txPerfilPersonalizado";
			this.txPerfilPersonalizado.Size = new System.Drawing.Size(214, 20);
			this.txPerfilPersonalizado.TabIndex = 6;
			// 
			// rbPerfilDefault
			// 
			this.rbPerfilDefault.AutoSize = true;
			this.rbPerfilDefault.Location = new System.Drawing.Point(12, 25);
			this.rbPerfilDefault.Name = "rbPerfilDefault";
			this.rbPerfilDefault.Size = new System.Drawing.Size(61, 17);
			this.rbPerfilDefault.TabIndex = 1;
			this.rbPerfilDefault.TabStop = true;
			this.rbPerfilDefault.Text = "Mi perfil";
			this.rbPerfilDefault.UseVisualStyleBackColor = true;
			this.rbPerfilDefault.CheckedChanged += new System.EventHandler(this.RbPerfilDefaultCheckedChanged);
			// 
			// rbPerfilAjeno
			// 
			this.rbPerfilAjeno.AutoSize = true;
			this.rbPerfilAjeno.Location = new System.Drawing.Point(12, 48);
			this.rbPerfilAjeno.Name = "rbPerfilAjeno";
			this.rbPerfilAjeno.Size = new System.Drawing.Size(70, 17);
			this.rbPerfilAjeno.TabIndex = 2;
			this.rbPerfilAjeno.TabStop = true;
			this.rbPerfilAjeno.Text = "Otro perfil";
			this.rbPerfilAjeno.UseVisualStyleBackColor = true;
			// 
			// lbPerfil
			// 
			this.lbPerfil.AutoSize = true;
			this.lbPerfil.Location = new System.Drawing.Point(13, 68);
			this.lbPerfil.Name = "lbPerfil";
			this.lbPerfil.Size = new System.Drawing.Size(33, 13);
			this.lbPerfil.TabIndex = 3;
			this.lbPerfil.Text = "Perfil:";
			// 
			// lbPerfilDefault
			// 
			this.lbPerfilDefault.AutoSize = true;
			this.lbPerfilDefault.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbPerfilDefault.Location = new System.Drawing.Point(79, 27);
			this.lbPerfilDefault.Name = "lbPerfilDefault";
			this.lbPerfilDefault.Size = new System.Drawing.Size(22, 13);
			this.lbPerfilDefault.TabIndex = 8;
			this.lbPerfilDefault.Text = "( ?)";
			// 
			// frmSuplantacion
			// 
			this.AcceptButton = this.bOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(238, 181);
			this.Controls.Add(this.lbPerfilDefault);
			this.Controls.Add(this.lbPerfil);
			this.Controls.Add(this.rbPerfilAjeno);
			this.Controls.Add(this.rbPerfilDefault);
			this.Controls.Add(this.txPerfilPersonalizado);
			this.Controls.Add(this.lbPerfilPersonalizado);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.lbTitulo);
			this.Controls.Add(this.cbPerfil);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSuplantacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Suplantación de perfil de usuario";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lbPerfilDefault;
		private System.Windows.Forms.RadioButton rbPerfilAjeno;
		private System.Windows.Forms.TextBox txPerfilPersonalizado;
		private System.Windows.Forms.Label lbTitulo;
		private System.Windows.Forms.RadioButton rbPerfilDefault;
		private System.Windows.Forms.Label lbPerfilPersonalizado;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Label lbPerfil;
		private System.Windows.Forms.ComboBox cbPerfil;
	}
}
