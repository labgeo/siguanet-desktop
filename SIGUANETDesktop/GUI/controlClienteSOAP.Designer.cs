/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 06/04/2007
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlClienteSOAP : System.Windows.Forms.UserControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlClienteSOAP));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbOK = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslMsg = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpResultado = new System.Windows.Forms.TabPage();
			this.dgResultado = new System.Windows.Forms.DataGridView();
			this.tpAyuda = new System.Windows.Forms.TabPage();
			this.txAyuda = new System.Windows.Forms.TextBox();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpResultado.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgResultado)).BeginInit();
			this.tpAyuda.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripSeparator1,
									this.tsbOK,
									this.toolStripSeparator2,
									this.tsbGuardar,
									this.toolStripSeparator3});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(116, 333);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.SizeChanged += new System.EventHandler(this.ToolStrip1SizeChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
			// 
			// tsbOK
			// 
			this.tsbOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbOK.Image = ((System.Drawing.Image)(resources.GetObject("tsbOK.Image")));
			this.tsbOK.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOK.Name = "tsbOK";
			this.tsbOK.Size = new System.Drawing.Size(114, 17);
			this.tsbOK.Text = "Ejecutar";
			this.tsbOK.ToolTipText = "Enviar la solicitud al Servicio Web";
			this.tsbOK.Click += new System.EventHandler(this.TsbOKClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
			// 
			// tsbGuardar
			// 
			this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardar.Image")));
			this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbGuardar.Name = "tsbGuardar";
			this.tsbGuardar.Size = new System.Drawing.Size(114, 17);
			this.tsbGuardar.Text = "Guardar resultado";
			this.tsbGuardar.ToolTipText = "Guarda el resultado en un fichero de texto de tipo CSV";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(114, 6);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsslMsg});
			this.statusStrip1.Location = new System.Drawing.Point(0, 311);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(506, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslMsg
			// 
			this.tsslMsg.Name = "tsslMsg";
			this.tsslMsg.Size = new System.Drawing.Size(174, 17);
			this.tsslMsg.Text = "Cliente SOAP Unidad de Geomática";
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
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
			this.splitContainer1.Size = new System.Drawing.Size(626, 333);
			this.splitContainer1.SplitterDistance = 116;
			this.splitContainer1.TabIndex = 2;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpResultado);
			this.tabControl1.Controls.Add(this.tpAyuda);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(506, 311);
			this.tabControl1.TabIndex = 2;
			// 
			// tpResultado
			// 
			this.tpResultado.Controls.Add(this.dgResultado);
			this.tpResultado.Location = new System.Drawing.Point(4, 22);
			this.tpResultado.Name = "tpResultado";
			this.tpResultado.Padding = new System.Windows.Forms.Padding(3);
			this.tpResultado.Size = new System.Drawing.Size(498, 285);
			this.tpResultado.TabIndex = 0;
			this.tpResultado.Text = "Resultado";
			this.tpResultado.UseVisualStyleBackColor = true;
			// 
			// dgResultado
			// 
			this.dgResultado.AllowUserToAddRows = false;
			this.dgResultado.AllowUserToDeleteRows = false;
			this.dgResultado.AllowUserToOrderColumns = true;
			this.dgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgResultado.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgResultado.Location = new System.Drawing.Point(3, 3);
			this.dgResultado.Name = "dgResultado";
			this.dgResultado.Size = new System.Drawing.Size(492, 279);
			this.dgResultado.TabIndex = 0;
			// 
			// tpAyuda
			// 
			this.tpAyuda.Controls.Add(this.txAyuda);
			this.tpAyuda.Location = new System.Drawing.Point(4, 22);
			this.tpAyuda.Name = "tpAyuda";
			this.tpAyuda.Padding = new System.Windows.Forms.Padding(3);
			this.tpAyuda.Size = new System.Drawing.Size(498, 285);
			this.tpAyuda.TabIndex = 1;
			this.tpAyuda.Text = "Ayuda";
			this.tpAyuda.UseVisualStyleBackColor = true;
			// 
			// txAyuda
			// 
			this.txAyuda.BackColor = System.Drawing.SystemColors.Window;
			this.txAyuda.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txAyuda.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txAyuda.Location = new System.Drawing.Point(3, 3);
			this.txAyuda.Multiline = true;
			this.txAyuda.Name = "txAyuda";
			this.txAyuda.ReadOnly = true;
			this.txAyuda.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txAyuda.Size = new System.Drawing.Size(492, 279);
			this.txAyuda.TabIndex = 0;
			// 
			// controlClienteSOAP
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "controlClienteSOAP";
			this.Size = new System.Drawing.Size(626, 333);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tpResultado.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgResultado)).EndInit();
			this.tpAyuda.ResumeLayout(false);
			this.tpAyuda.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txAyuda;
		private System.Windows.Forms.TabPage tpAyuda;
		private System.Windows.Forms.DataGridView dgResultado;
		private System.Windows.Forms.TabPage tpResultado;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripStatusLabel tsslMsg;
		private System.Windows.Forms.ToolStripButton tsbGuardar;
		private System.Windows.Forms.ToolStripButton tsbOK;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
