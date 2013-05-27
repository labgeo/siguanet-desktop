/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 18/04/2008
 * Hora: 8:04
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmAutentificacion
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
			this.rbAnonimo = new System.Windows.Forms.RadioButton();
			this.rbAutentificado = new System.Windows.Forms.RadioButton();
			this.lbUsuario = new System.Windows.Forms.Label();
			this.txUsuario = new System.Windows.Forms.TextBox();
			this.bOK = new System.Windows.Forms.Button();
			this.lbPerfilPersonalizado = new System.Windows.Forms.Label();
			this.txPerfilPersonalizado = new System.Windows.Forms.TextBox();
			this.ckSRSBypass = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// rbAnonimo
			// 
			this.rbAnonimo.AutoSize = true;
			this.rbAnonimo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbAnonimo.Location = new System.Drawing.Point(12, 12);
			this.rbAnonimo.Name = "rbAnonimo";
			this.rbAnonimo.Size = new System.Drawing.Size(104, 17);
			this.rbAnonimo.TabIndex = 0;
			this.rbAnonimo.TabStop = true;
			this.rbAnonimo.Text = "Acceso anónimo";
			this.rbAnonimo.UseVisualStyleBackColor = true;
			// 
			// rbAutentificado
			// 
			this.rbAutentificado.AutoSize = true;
			this.rbAutentificado.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rbAutentificado.Location = new System.Drawing.Point(12, 86);
			this.rbAutentificado.Name = "rbAutentificado";
			this.rbAutentificado.Size = new System.Drawing.Size(147, 17);
			this.rbAutentificado.TabIndex = 3;
			this.rbAutentificado.TabStop = true;
			this.rbAutentificado.Text = "Acceso con identificación";
			this.rbAutentificado.UseVisualStyleBackColor = true;
			this.rbAutentificado.CheckedChanged += new System.EventHandler(this.RbAutentificadoCheckedChanged);
			// 
			// lbUsuario
			// 
			this.lbUsuario.AutoSize = true;
			this.lbUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbUsuario.Location = new System.Drawing.Point(12, 106);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(29, 13);
			this.lbUsuario.TabIndex = 4;
			this.lbUsuario.Text = "DNI:";
			// 
			// txUsuario
			// 
			this.txUsuario.Location = new System.Drawing.Point(12, 123);
			this.txUsuario.Name = "txUsuario";
			this.txUsuario.Size = new System.Drawing.Size(150, 20);
			this.txUsuario.TabIndex = 5;
			this.txUsuario.TextChanged += new System.EventHandler(this.TxUsuarioTextChanged);
			// 
			// bOK
			// 
			this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bOK.Location = new System.Drawing.Point(95, 186);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(67, 23);
			this.bOK.TabIndex = 9;
			this.bOK.Text = "Continuar";
			this.bOK.UseVisualStyleBackColor = true;
			// 
			// lbPerfilPersonalizado
			// 
			this.lbPerfilPersonalizado.AutoSize = true;
			this.lbPerfilPersonalizado.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbPerfilPersonalizado.Location = new System.Drawing.Point(12, 32);
			this.lbPerfilPersonalizado.Name = "lbPerfilPersonalizado";
			this.lbPerfilPersonalizado.Size = new System.Drawing.Size(150, 13);
			this.lbPerfilPersonalizado.TabIndex = 1;
			this.lbPerfilPersonalizado.Text = "Perfil personalizado (opcional):";
			// 
			// txPerfilPersonalizado
			// 
			this.txPerfilPersonalizado.Location = new System.Drawing.Point(12, 48);
			this.txPerfilPersonalizado.Name = "txPerfilPersonalizado";
			this.txPerfilPersonalizado.Size = new System.Drawing.Size(150, 20);
			this.txPerfilPersonalizado.TabIndex = 2;
			this.txPerfilPersonalizado.TextChanged += new System.EventHandler(this.TxPerfilPersonalizadoTextChanged);
			// 
			// ckSRSBypass
			// 
			this.ckSRSBypass.AutoSize = true;
			this.ckSRSBypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ckSRSBypass.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ckSRSBypass.Location = new System.Drawing.Point(12, 160);
			this.ckSRSBypass.Name = "ckSRSBypass";
			this.ckSRSBypass.Size = new System.Drawing.Size(85, 17);
			this.ckSRSBypass.TabIndex = 8;
			this.ckSRSBypass.Text = "SRS Bypass";
			this.ckSRSBypass.UseVisualStyleBackColor = true;
			this.ckSRSBypass.CheckedChanged += new System.EventHandler(this.CkSRSBypassCheckedChanged);
			// 
			// frmAutentificacion
			// 
			this.AcceptButton = this.bOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(175, 219);
			this.ControlBox = false;
			this.Controls.Add(this.ckSRSBypass);
			this.Controls.Add(this.txPerfilPersonalizado);
			this.Controls.Add(this.lbPerfilPersonalizado);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.txUsuario);
			this.Controls.Add(this.lbUsuario);
			this.Controls.Add(this.rbAutentificado);
			this.Controls.Add(this.rbAnonimo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAutentificacion";
			this.Text = "Identificación de usuario";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txUsuario;
		private System.Windows.Forms.Label lbUsuario;
		private System.Windows.Forms.CheckBox ckSRSBypass;
		private System.Windows.Forms.TextBox txPerfilPersonalizado;
		private System.Windows.Forms.Label lbPerfilPersonalizado;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.RadioButton rbAutentificado;
		private System.Windows.Forms.RadioButton rbAnonimo;
	}
}
