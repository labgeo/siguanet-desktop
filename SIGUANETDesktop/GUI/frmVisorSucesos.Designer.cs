/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 24/04/2008
 * Hora: 9:37
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmVisorSucesos
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
			this.lvSucesos = new System.Windows.Forms.ListView();
			this.cTipo = new System.Windows.Forms.ColumnHeader();
			this.cFecha = new System.Windows.Forms.ColumnHeader();
			this.cHora = new System.Windows.Forms.ColumnHeader();
			this.cOrigen = new System.Windows.Forms.ColumnHeader();
			this.cDescripción = new System.Windows.Forms.ColumnHeader();
			this.tcSucesos = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.tpDetalle = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvInnerExceptions = new System.Windows.Forms.TreeView();
			this.txIEDescription = new System.Windows.Forms.TextBox();
			this.tcSucesos.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.tpDetalle.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvSucesos
			// 
			this.lvSucesos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lvSucesos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.cTipo,
									this.cFecha,
									this.cHora,
									this.cOrigen,
									this.cDescripción});
			this.lvSucesos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSucesos.Location = new System.Drawing.Point(3, 3);
			this.lvSucesos.Name = "lvSucesos";
			this.lvSucesos.Size = new System.Drawing.Size(715, 295);
			this.lvSucesos.TabIndex = 0;
			this.lvSucesos.UseCompatibleStateImageBehavior = false;
			this.lvSucesos.View = System.Windows.Forms.View.Details;
			this.lvSucesos.ItemActivate += new System.EventHandler(this.LvSucesosItemActivate);
			// 
			// cTipo
			// 
			this.cTipo.Text = "Tipo";
			this.cTipo.Width = 119;
			// 
			// cFecha
			// 
			this.cFecha.Text = "Fecha";
			this.cFecha.Width = 80;
			// 
			// cHora
			// 
			this.cHora.Text = "Hora";
			this.cHora.Width = 71;
			// 
			// cOrigen
			// 
			this.cOrigen.Text = "Origen";
			this.cOrigen.Width = 141;
			// 
			// cDescripción
			// 
			this.cDescripción.Text = "Descripción";
			this.cDescripción.Width = 400;
			// 
			// tcSucesos
			// 
			this.tcSucesos.Controls.Add(this.tpGeneral);
			this.tcSucesos.Controls.Add(this.tpDetalle);
			this.tcSucesos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcSucesos.Location = new System.Drawing.Point(0, 0);
			this.tcSucesos.Name = "tcSucesos";
			this.tcSucesos.SelectedIndex = 0;
			this.tcSucesos.Size = new System.Drawing.Size(729, 327);
			this.tcSucesos.TabIndex = 1;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.lvSucesos);
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneral.Size = new System.Drawing.Size(721, 301);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "General";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// tpDetalle
			// 
			this.tpDetalle.Controls.Add(this.splitContainer1);
			this.tpDetalle.Location = new System.Drawing.Point(4, 22);
			this.tpDetalle.Name = "tpDetalle";
			this.tpDetalle.Padding = new System.Windows.Forms.Padding(3);
			this.tpDetalle.Size = new System.Drawing.Size(721, 301);
			this.tpDetalle.TabIndex = 1;
			this.tpDetalle.Text = "Detalle del suceso seleccionado";
			this.tpDetalle.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvInnerExceptions);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txIEDescription);
			this.splitContainer1.Size = new System.Drawing.Size(715, 295);
			this.splitContainer1.SplitterDistance = 238;
			this.splitContainer1.TabIndex = 0;
			// 
			// tvInnerExceptions
			// 
			this.tvInnerExceptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvInnerExceptions.Location = new System.Drawing.Point(0, 0);
			this.tvInnerExceptions.Name = "tvInnerExceptions";
			this.tvInnerExceptions.Size = new System.Drawing.Size(238, 295);
			this.tvInnerExceptions.TabIndex = 0;
			this.tvInnerExceptions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvInnerExceptionsAfterSelect);
			// 
			// txIEDescription
			// 
			this.txIEDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txIEDescription.Location = new System.Drawing.Point(0, 0);
			this.txIEDescription.Multiline = true;
			this.txIEDescription.Name = "txIEDescription";
			this.txIEDescription.ReadOnly = true;
			this.txIEDescription.Size = new System.Drawing.Size(473, 295);
			this.txIEDescription.TabIndex = 0;
			// 
			// frmVisorSucesos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 327);
			this.Controls.Add(this.tcSucesos);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmVisorSucesos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Visor de sucesos";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVisorSucesosFormClosing);
			this.tcSucesos.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.tpDetalle.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txIEDescription;
		private System.Windows.Forms.TreeView tvInnerExceptions;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabPage tpDetalle;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.TabControl tcSucesos;
		private System.Windows.Forms.ColumnHeader cHora;
		private System.Windows.Forms.ListView lvSucesos;
		private System.Windows.Forms.ColumnHeader cDescripción;
		private System.Windows.Forms.ColumnHeader cOrigen;
		private System.Windows.Forms.ColumnHeader cFecha;
		private System.Windows.Forms.ColumnHeader cTipo;
	}
}
