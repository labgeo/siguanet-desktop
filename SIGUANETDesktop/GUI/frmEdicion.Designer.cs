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
	partial class frmEdicion : System.Windows.Forms.Form
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
			this.components = new System.ComponentModel.Container();
			this.bsDatos = new System.Windows.Forms.BindingSource(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.bCancelar = new System.Windows.Forms.Button();
			this.bAceptar = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslMsg = new System.Windows.Forms.ToolStripStatusLabel();
			this.dgvDatos = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.bsDatos)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bCancelar);
			this.panel1.Controls.Add(this.bAceptar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 333);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(657, 47);
			this.panel1.TabIndex = 2;
			// 
			// bCancelar
			// 
			this.bCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bCancelar.AutoSize = true;
			this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancelar.Location = new System.Drawing.Point(595, 5);
			this.bCancelar.Name = "bCancelar";
			this.bCancelar.Size = new System.Drawing.Size(59, 30);
			this.bCancelar.TabIndex = 1;
			this.bCancelar.Text = "Cancelar";
			this.bCancelar.UseVisualStyleBackColor = true;
			this.bCancelar.Click += new System.EventHandler(this.BCancelarClick);
			// 
			// bAceptar
			// 
			this.bAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bAceptar.AutoSize = true;
			this.bAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAceptar.Location = new System.Drawing.Point(530, 5);
			this.bAceptar.Name = "bAceptar";
			this.bAceptar.Size = new System.Drawing.Size(59, 30);
			this.bAceptar.TabIndex = 0;
			this.bAceptar.Text = "Aceptar";
			this.bAceptar.UseVisualStyleBackColor = true;
			this.bAceptar.Click += new System.EventHandler(this.BAceptarClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgvDatos);
			this.panel2.Controls.Add(this.statusStrip1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(657, 333);
			this.panel2.TabIndex = 3;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsslMsg});
			this.statusStrip1.Location = new System.Drawing.Point(0, 311);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(657, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslMsg
			// 
			this.tsslMsg.Name = "tsslMsg";
			this.tsslMsg.Size = new System.Drawing.Size(146, 17);
			this.tsslMsg.Text = "Nº de registros recuperados:";
			// 
			// dgvDatos
			// 
			this.dgvDatos.AllowUserToOrderColumns = true;
			this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDatos.Location = new System.Drawing.Point(0, 0);
			this.dgvDatos.Name = "dgvDatos";
			this.dgvDatos.Size = new System.Drawing.Size(657, 311);
			this.dgvDatos.TabIndex = 3;
			// 
			// frmEdicion
			// 
			this.AcceptButton = this.bAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancelar;
			this.ClientSize = new System.Drawing.Size(657, 380);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "frmEdicion";
			this.Text = "frmEdicion";
			((System.ComponentModel.ISupportInitialize)(this.bsDatos)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripStatusLabel tsslMsg;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button bAceptar;
		private System.Windows.Forms.Button bCancelar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.BindingSource bsDatos;
		private System.Windows.Forms.DataGridView dgvDatos;
	}
}
