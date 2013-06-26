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
	partial class controlClienteSQL : System.Windows.Forms.UserControl
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlClienteSQL));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tscbOrigen = new System.Windows.Forms.ToolStripComboBox();
			this.tsbEjecutar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbBorrarSQL = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tssbBorrarOutput = new System.Windows.Forms.ToolStripSplitButton();
			this.miBorrarOutputActivo = new System.Windows.Forms.ToolStripMenuItem();
			this.miBorrarOutputTodos = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslMsg = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txSQL = new System.Windows.Forms.TextBox();
			this.tcOutput = new System.Windows.Forms.TabControl();
			this.tp0 = new System.Windows.Forms.TabPage();
			this.mTab = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemCerrar = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemCerrarTodos = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tcOutput.SuspendLayout();
			this.mTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tscbOrigen,
									this.tsbEjecutar,
									this.toolStripSeparator1,
									this.tsbBorrarSQL,
									this.toolStripSeparator2,
									this.tssbBorrarOutput});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(542, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tscbOrigen
			// 
			this.tscbOrigen.Name = "tscbOrigen";
			this.tscbOrigen.Size = new System.Drawing.Size(121, 25);
			// 
			// tsbEjecutar
			// 
			this.tsbEjecutar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEjecutar.Image")));
			this.tsbEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEjecutar.Name = "tsbEjecutar";
			this.tsbEjecutar.Size = new System.Drawing.Size(51, 22);
			this.tsbEjecutar.Text = "Ejecutar";
			this.tsbEjecutar.Click += new System.EventHandler(this.TsbEjecutarClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbBorrarSQL
			// 
			this.tsbBorrarSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbBorrarSQL.Image = ((System.Drawing.Image)(resources.GetObject("tsbBorrarSQL.Image")));
			this.tsbBorrarSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbBorrarSQL.Name = "tsbBorrarSQL";
			this.tsbBorrarSQL.Size = new System.Drawing.Size(92, 22);
			this.tsbBorrarSQL.Text = "Borrar panel SQL";
			this.tsbBorrarSQL.Click += new System.EventHandler(this.TsbBorrarSQLClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tssbBorrarOutput
			// 
			this.tssbBorrarOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tssbBorrarOutput.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.miBorrarOutputActivo,
									this.miBorrarOutputTodos});
			this.tssbBorrarOutput.Image = ((System.Drawing.Image)(resources.GetObject("tssbBorrarOutput.Image")));
			this.tssbBorrarOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tssbBorrarOutput.Name = "tssbBorrarOutput";
			this.tssbBorrarOutput.Size = new System.Drawing.Size(150, 22);
			this.tssbBorrarOutput.Text = "Borrar panel de resultados";
			// 
			// miBorrarOutputActivo
			// 
			this.miBorrarOutputActivo.Name = "miBorrarOutputActivo";
			this.miBorrarOutputActivo.Size = new System.Drawing.Size(196, 22);
			this.miBorrarOutputActivo.Text = "Sólo el resultado activo";
			this.miBorrarOutputActivo.Click += new System.EventHandler(this.MiBorrarOutputActivoClick);
			// 
			// miBorrarOutputTodos
			// 
			this.miBorrarOutputTodos.Name = "miBorrarOutputTodos";
			this.miBorrarOutputTodos.Size = new System.Drawing.Size(196, 22);
			this.miBorrarOutputTodos.Text = "Todos los resultados";
			this.miBorrarOutputTodos.Click += new System.EventHandler(this.MiBorrarOutputTodosClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsslMsg});
			this.statusStrip1.Location = new System.Drawing.Point(0, 422);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(542, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslMsg
			// 
			this.tsslMsg.Name = "tsslMsg";
			this.tsslMsg.Size = new System.Drawing.Size(69, 17);
			this.tsslMsg.Text = "Terminal SQL";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txSQL);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tcOutput);
			this.splitContainer1.Size = new System.Drawing.Size(542, 397);
			this.splitContainer1.SplitterDistance = 120;
			this.splitContainer1.TabIndex = 3;
			// 
			// txSQL
			// 
			this.txSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txSQL.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txSQL.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txSQL.Location = new System.Drawing.Point(0, 0);
			this.txSQL.Multiline = true;
			this.txSQL.Name = "txSQL";
			this.txSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txSQL.Size = new System.Drawing.Size(542, 120);
			this.txSQL.TabIndex = 0;
			this.txSQL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxSQLKeyUp);
			// 
			// tcOutput
			// 
			this.tcOutput.Controls.Add(this.tp0);
			this.tcOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcOutput.Location = new System.Drawing.Point(0, 0);
			this.tcOutput.Name = "tcOutput";
			this.tcOutput.SelectedIndex = 0;
			this.tcOutput.Size = new System.Drawing.Size(542, 273);
			this.tcOutput.TabIndex = 0;
			this.tcOutput.SelectedIndexChanged += new System.EventHandler(this.TcOutputSelectedIndexChanged);
			// 
			// tp0
			// 
			this.tp0.Location = new System.Drawing.Point(4, 22);
			this.tp0.Name = "tp0";
			this.tp0.Padding = new System.Windows.Forms.Padding(3);
			this.tp0.Size = new System.Drawing.Size(534, 247);
			this.tp0.TabIndex = 0;
			this.tp0.Text = "No hay resultados";
			this.tp0.UseVisualStyleBackColor = true;
			// 
			// mTab
			// 
			this.mTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemCerrar,
									this.mitemCerrarTodos});
			this.mTab.Name = "mTab";
			this.mTab.Size = new System.Drawing.Size(216, 48);
			// 
			// mitemCerrar
			// 
			this.mitemCerrar.Name = "mitemCerrar";
			this.mitemCerrar.Size = new System.Drawing.Size(215, 22);
			this.mitemCerrar.Text = "Cerrar resultado activo";
			this.mitemCerrar.Click += new System.EventHandler(this.MitemCerrarClick);
			// 
			// mitemCerrarTodos
			// 
			this.mitemCerrarTodos.Name = "mitemCerrarTodos";
			this.mitemCerrarTodos.Size = new System.Drawing.Size(215, 22);
			this.mitemCerrarTodos.Text = "Cerrar todos los resultados";
			this.mitemCerrarTodos.Click += new System.EventHandler(this.MitemCerrarTodosClick);
			// 
			// controlClienteSQL
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "controlClienteSQL";
			this.Size = new System.Drawing.Size(542, 444);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tcOutput.ResumeLayout(false);
			this.mTab.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem mitemCerrarTodos;
		private System.Windows.Forms.ToolStripMenuItem mitemCerrar;
		private System.Windows.Forms.ContextMenuStrip mTab;
		private System.Windows.Forms.TabPage tp0;
		private System.Windows.Forms.TabControl tcOutput;
		private System.Windows.Forms.ToolStripStatusLabel tsslMsg;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripSplitButton tssbBorrarOutput;
		private System.Windows.Forms.ToolStripMenuItem miBorrarOutputActivo;
		private System.Windows.Forms.ToolStripMenuItem miBorrarOutputTodos;
		private System.Windows.Forms.ToolStripComboBox tscbOrigen;
		private System.Windows.Forms.TextBox txSQL;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbBorrarSQL;
		private System.Windows.Forms.ToolStripButton tsbEjecutar;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
