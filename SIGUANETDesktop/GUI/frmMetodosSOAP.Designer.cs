/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 01/04/2007
 * Time: 20:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmMetodosSOAP : System.Windows.Forms.Form
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
			this.lMetodos = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// bCancelar
			// 
			this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancelar.Location = new System.Drawing.Point(291, 116);
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
			this.bAceptar.Location = new System.Drawing.Point(226, 116);
			this.bAceptar.Name = "bAceptar";
			this.bAceptar.Size = new System.Drawing.Size(59, 30);
			this.bAceptar.TabIndex = 11;
			this.bAceptar.Text = "Aceptar";
			this.bAceptar.UseVisualStyleBackColor = true;
			this.bAceptar.Click += new System.EventHandler(this.BAceptarClick);
			// 
			// lMetodos
			// 
			this.lMetodos.FormattingEnabled = true;
			this.lMetodos.HorizontalScrollbar = true;
			this.lMetodos.IntegralHeight = false;
			this.lMetodos.Location = new System.Drawing.Point(12, 12);
			this.lMetodos.Name = "lMetodos";
			this.lMetodos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lMetodos.Size = new System.Drawing.Size(338, 98);
			this.lMetodos.TabIndex = 13;
			// 
			// frmMetodosSOAP
			// 
			this.AcceptButton = this.bAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancelar;
			this.ClientSize = new System.Drawing.Size(362, 158);
			this.Controls.Add(this.lMetodos);
			this.Controls.Add(this.bCancelar);
			this.Controls.Add(this.bAceptar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMetodosSOAP";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Métodos disponibles en el Servicio SOAP de SIGUANET";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMetodosSOAPFormClosing);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox lMetodos;
		private System.Windows.Forms.Button bAceptar;
		private System.Windows.Forms.Button bCancelar;
	}
}
