/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 27/02/2008
 * Hora: 13:45
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmEsquemaBD
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
			this.tvEsquemas = new System.Windows.Forms.TreeView();
			this.mColumna = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemCCopiarNombre = new System.Windows.Forms.ToolStripMenuItem();
			this.mRelacion = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemRCopiarNombre = new System.Windows.Forms.ToolStripMenuItem();
			this.mColumnas = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemCopiarColumnas = new System.Windows.Forms.ToolStripMenuItem();
			this.mColumna.SuspendLayout();
			this.mRelacion.SuspendLayout();
			this.mColumnas.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvEsquemas
			// 
			this.tvEsquemas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvEsquemas.Location = new System.Drawing.Point(0, 0);
			this.tvEsquemas.Name = "tvEsquemas";
			this.tvEsquemas.Size = new System.Drawing.Size(473, 572);
			this.tvEsquemas.TabIndex = 0;
			this.tvEsquemas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvEsquemasNodeMouseClick);
			// 
			// mColumna
			// 
			this.mColumna.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemCCopiarNombre});
			this.mColumna.Name = "mColumna";
			this.mColumna.Size = new System.Drawing.Size(156, 26);
			// 
			// mitemCCopiarNombre
			// 
			this.mitemCCopiarNombre.Name = "mitemCCopiarNombre";
			this.mitemCCopiarNombre.Size = new System.Drawing.Size(155, 22);
			this.mitemCCopiarNombre.Text = "Copiar nombre";
			this.mitemCCopiarNombre.Click += new System.EventHandler(this.MitemCCopiarNombreClick);
			// 
			// mRelacion
			// 
			this.mRelacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemRCopiarNombre});
			this.mRelacion.Name = "mRelacion";
			this.mRelacion.Size = new System.Drawing.Size(156, 26);
			// 
			// mitemRCopiarNombre
			// 
			this.mitemRCopiarNombre.Name = "mitemRCopiarNombre";
			this.mitemRCopiarNombre.Size = new System.Drawing.Size(155, 22);
			this.mitemRCopiarNombre.Text = "Copiar nombre";
			this.mitemRCopiarNombre.Click += new System.EventHandler(this.MitemRCopiarNombreClick);
			// 
			// mColumnas
			// 
			this.mColumnas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemCopiarColumnas});
			this.mColumnas.Name = "mColumnas";
			this.mColumnas.Size = new System.Drawing.Size(223, 26);
			// 
			// mitemCopiarColumnas
			// 
			this.mitemCopiarColumnas.Name = "mitemCopiarColumnas";
			this.mitemCopiarColumnas.Size = new System.Drawing.Size(222, 22);
			this.mitemCopiarColumnas.Text = "Copiar nombres de columnas";
			this.mitemCopiarColumnas.Click += new System.EventHandler(this.MitemCopiarColumnasClick);
			// 
			// frmEsquemaBD
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 572);
			this.Controls.Add(this.tvEsquemas);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmEsquemaBD";
			this.Text = "Visor de esquemas de Base de Datos";
			this.mColumna.ResumeLayout(false);
			this.mRelacion.ResumeLayout(false);
			this.mColumnas.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem mitemCopiarColumnas;
		private System.Windows.Forms.ContextMenuStrip mColumnas;
		private System.Windows.Forms.ToolStripMenuItem mitemRCopiarNombre;
		private System.Windows.Forms.ContextMenuStrip mRelacion;
		private System.Windows.Forms.ToolStripMenuItem mitemCCopiarNombre;
		private System.Windows.Forms.ContextMenuStrip mColumna;
		private System.Windows.Forms.TreeView tvEsquemas;
	}
}
