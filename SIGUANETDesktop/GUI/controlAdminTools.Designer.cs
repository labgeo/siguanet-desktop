/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 17/03/2008
 * Hora: 14:36
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlAdminTools
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlAdminTools));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.bSGD = new System.Windows.Forms.ToolStripButton();
			this.bSGDUpload = new System.Windows.Forms.ToolStripButton();
			this.bSRS = new System.Windows.Forms.ToolStripButton();
			this.bPerfiles = new System.Windows.Forms.ToolStripButton();
			this.bUpload = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
			this.splitContainer1.Size = new System.Drawing.Size(486, 266);
			this.splitContainer1.SplitterDistance = 124;
			this.splitContainer1.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.bSGD,
									this.bSGDUpload,
									this.bSRS,
									this.bPerfiles,
									this.bUpload});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(124, 266);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// bSGD
			// 
			this.bSGD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.bSGD.Image = ((System.Drawing.Image)(resources.GetObject("bSGD.Image")));
			this.bSGD.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bSGD.Name = "bSGD";
			this.bSGD.Size = new System.Drawing.Size(122, 17);
			this.bSGD.Text = "Gestor SGD";
			this.bSGD.ToolTipText = "Gestor de documentos SIGUANETDesktop";
			this.bSGD.Click += new System.EventHandler(this.BSGDClick);
			// 
			// bSGDUpload
			// 
			this.bSGDUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.bSGDUpload.Image = ((System.Drawing.Image)(resources.GetObject("bSGDUpload.Image")));
			this.bSGDUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bSGDUpload.Name = "bSGDUpload";
			this.bSGDUpload.Size = new System.Drawing.Size(122, 17);
			this.bSGDUpload.Text = "SGD Upload";
			this.bSGDUpload.Click += new System.EventHandler(this.BSGDUploadClick);
			// 
			// bSRS
			// 
			this.bSRS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.bSRS.Image = ((System.Drawing.Image)(resources.GetObject("bSRS.Image")));
			this.bSRS.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bSRS.Name = "bSRS";
			this.bSRS.Size = new System.Drawing.Size(122, 17);
			this.bSRS.Text = "Gestor SRS";
			this.bSRS.ToolTipText = "Gestor de ajustes remotos SIGUANETDesktop";
			this.bSRS.Click += new System.EventHandler(this.BSRSClick);
			// 
			// bPerfiles
			// 
			this.bPerfiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.bPerfiles.Image = ((System.Drawing.Image)(resources.GetObject("bPerfiles.Image")));
			this.bPerfiles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bPerfiles.Name = "bPerfiles";
			this.bPerfiles.Size = new System.Drawing.Size(122, 17);
			this.bPerfiles.Text = "Buscador de perfiles";
			this.bPerfiles.Click += new System.EventHandler(this.BPerfilesClick);
			// 
			// bUpload
			// 
			this.bUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.bUpload.Image = ((System.Drawing.Image)(resources.GetObject("bUpload.Image")));
			this.bUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bUpload.Name = "bUpload";
			this.bUpload.Size = new System.Drawing.Size(122, 17);
			this.bUpload.Text = "Upload";
			this.bUpload.Click += new System.EventHandler(this.BHTTPPUTClick);
			// 
			// controlAdminTools
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "controlAdminTools";
			this.Size = new System.Drawing.Size(486, 266);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripButton bUpload;
		private System.Windows.Forms.ToolStripButton bSGDUpload;
		private System.Windows.Forms.ToolStripButton bPerfiles;
		private System.Windows.Forms.ToolStripButton bSGD;
		private System.Windows.Forms.ToolStripButton bSRS;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
