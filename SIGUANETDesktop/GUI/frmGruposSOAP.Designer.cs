/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 25/04/2007
 * Time: 23:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmGruposSOAP : System.Windows.Forms.Form
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
			this.gbG = new System.Windows.Forms.GroupBox();
			this.lG = new System.Windows.Forms.ListBox();
			this.lbG = new System.Windows.Forms.Label();
			this.rGE = new System.Windows.Forms.RadioButton();
			this.rGC = new System.Windows.Forms.RadioButton();
			this.gbOperacion = new System.Windows.Forms.GroupBox();
			this.rMover = new System.Windows.Forms.RadioButton();
			this.rCopiar = new System.Windows.Forms.RadioButton();
			this.bAceptar = new System.Windows.Forms.Button();
			this.bCancelar = new System.Windows.Forms.Button();
			this.gbG.SuspendLayout();
			this.gbOperacion.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbG
			// 
			this.gbG.Controls.Add(this.lG);
			this.gbG.Controls.Add(this.lbG);
			this.gbG.Controls.Add(this.rGE);
			this.gbG.Controls.Add(this.rGC);
			this.gbG.Location = new System.Drawing.Point(12, 12);
			this.gbG.Name = "gbG";
			this.gbG.Size = new System.Drawing.Size(288, 188);
			this.gbG.TabIndex = 0;
			this.gbG.TabStop = false;
			this.gbG.Text = "Grupos disponibles:";
			// 
			// lG
			// 
			this.lG.FormattingEnabled = true;
			this.lG.IntegralHeight = false;
			this.lG.Location = new System.Drawing.Point(6, 56);
			this.lG.Name = "lG";
			this.lG.Size = new System.Drawing.Size(276, 126);
			this.lG.TabIndex = 3;
			// 
			// lbG
			// 
			this.lbG.AutoSize = true;
			this.lbG.Location = new System.Drawing.Point(6, 40);
			this.lbG.Name = "lbG";
			this.lbG.Size = new System.Drawing.Size(156, 13);
			this.lbG.TabIndex = 2;
			this.lbG.Text = "Seleccione el grupo de destino:";
			// 
			// rGE
			// 
			this.rGE.AutoSize = true;
			this.rGE.Location = new System.Drawing.Point(134, 20);
			this.rGE.Name = "rGE";
			this.rGE.Size = new System.Drawing.Size(132, 17);
			this.rGE.TabIndex = 1;
			this.rGE.Text = "Ver grupos específicos";
			this.rGE.UseVisualStyleBackColor = true;
			this.rGE.CheckedChanged += new System.EventHandler(this.RGECheckedChanged);
			// 
			// rGC
			// 
			this.rGC.AutoSize = true;
			this.rGC.Checked = true;
			this.rGC.Location = new System.Drawing.Point(6, 20);
			this.rGC.Name = "rGC";
			this.rGC.Size = new System.Drawing.Size(122, 17);
			this.rGC.TabIndex = 0;
			this.rGC.TabStop = true;
			this.rGC.Text = "Ver grupos comunes";
			this.rGC.UseVisualStyleBackColor = true;
			this.rGC.CheckedChanged += new System.EventHandler(this.RGCCheckedChanged);
			// 
			// gbOperacion
			// 
			this.gbOperacion.Controls.Add(this.rMover);
			this.gbOperacion.Controls.Add(this.rCopiar);
			this.gbOperacion.Location = new System.Drawing.Point(12, 206);
			this.gbOperacion.Name = "gbOperacion";
			this.gbOperacion.Size = new System.Drawing.Size(288, 76);
			this.gbOperacion.TabIndex = 1;
			this.gbOperacion.TabStop = false;
			this.gbOperacion.Text = "Al mover el método:";
			// 
			// rMover
			// 
			this.rMover.AutoSize = true;
			this.rMover.Location = new System.Drawing.Point(6, 43);
			this.rMover.Name = "rMover";
			this.rMover.Size = new System.Drawing.Size(201, 17);
			this.rMover.TabIndex = 1;
			this.rMover.TabStop = true;
			this.rMover.Text = "Quitar el método del grupo de origen";
			this.rMover.UseVisualStyleBackColor = true;
			// 
			// rCopiar
			// 
			this.rCopiar.AutoSize = true;
			this.rCopiar.Checked = true;
			this.rCopiar.Location = new System.Drawing.Point(6, 20);
			this.rCopiar.Name = "rCopiar";
			this.rCopiar.Size = new System.Drawing.Size(230, 17);
			this.rCopiar.TabIndex = 0;
			this.rCopiar.TabStop = true;
			this.rCopiar.Text = "Conservar el método en el grupo de origen";
			this.rCopiar.UseVisualStyleBackColor = true;
			// 
			// bAceptar
			// 
			this.bAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAceptar.Location = new System.Drawing.Point(176, 288);
			this.bAceptar.Name = "bAceptar";
			this.bAceptar.Size = new System.Drawing.Size(59, 30);
			this.bAceptar.TabIndex = 13;
			this.bAceptar.Text = "Aceptar";
			this.bAceptar.UseVisualStyleBackColor = true;
			this.bAceptar.Click += new System.EventHandler(this.BAceptarClick);
			// 
			// bCancelar
			// 
			this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancelar.Location = new System.Drawing.Point(241, 288);
			this.bCancelar.Name = "bCancelar";
			this.bCancelar.Size = new System.Drawing.Size(59, 30);
			this.bCancelar.TabIndex = 14;
			this.bCancelar.Text = "Cancelar";
			this.bCancelar.UseVisualStyleBackColor = true;
			this.bCancelar.Click += new System.EventHandler(this.BCancelarClick);
			// 
			// frmGruposSOAP
			// 
			this.AcceptButton = this.bAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancelar;
			this.ClientSize = new System.Drawing.Size(312, 329);
			this.Controls.Add(this.bAceptar);
			this.Controls.Add(this.bCancelar);
			this.Controls.Add(this.gbOperacion);
			this.Controls.Add(this.gbG);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmGruposSOAP";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Grupos SOAP";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGruposSOAPFormClosing);
			this.gbG.ResumeLayout(false);
			this.gbG.PerformLayout();
			this.gbOperacion.ResumeLayout(false);
			this.gbOperacion.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button bCancelar;
		private System.Windows.Forms.Button bAceptar;
		private System.Windows.Forms.RadioButton rCopiar;
		private System.Windows.Forms.RadioButton rMover;
		private System.Windows.Forms.ListBox lG;
		private System.Windows.Forms.GroupBox gbOperacion;
		private System.Windows.Forms.RadioButton rGC;
		private System.Windows.Forms.RadioButton rGE;
		private System.Windows.Forms.Label lbG;
		private System.Windows.Forms.GroupBox gbG;
	}
}
