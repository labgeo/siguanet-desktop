/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 04/12/2006
 * Time: 9:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmArbolDatos : System.Windows.Forms.Form
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.twNavegador = new System.Windows.Forms.TreeView();
			this.dg = new System.Windows.Forms.DataGridView();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslNumFilas = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.twNavegador);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dg);
			this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
			this.splitContainer1.Size = new System.Drawing.Size(661, 539);
			this.splitContainer1.SplitterDistance = 220;
			this.splitContainer1.TabIndex = 0;
			// 
			// twNavegador
			// 
			this.twNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
			this.twNavegador.HideSelection = false;
			this.twNavegador.Location = new System.Drawing.Point(0, 0);
			this.twNavegador.Name = "twNavegador";
			this.twNavegador.Size = new System.Drawing.Size(220, 539);
			this.twNavegador.TabIndex = 1;
			this.twNavegador.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SeleccionarNodo);
			// 
			// dg
			// 
			this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dg.Location = new System.Drawing.Point(0, 0);
			this.dg.Name = "dg";
			this.dg.Size = new System.Drawing.Size(437, 517);
			this.dg.TabIndex = 3;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tslNumFilas});
			this.statusStrip1.Location = new System.Drawing.Point(0, 517);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(437, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tslNumFilas
			// 
			this.tslNumFilas.Name = "tslNumFilas";
			this.tslNumFilas.Size = new System.Drawing.Size(86, 17);
			this.tslNumFilas.Text = "No hay registros";
			// 
			// frmArbolDatos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 539);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmArbolDatos";
			this.Text = "SIGUANETDesktop TreeDATA - Visor Alfanumérico de datos SIGUANET";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripStatusLabel tslNumFilas;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.DataGridView dg;
		private System.Windows.Forms.TreeView twNavegador;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
