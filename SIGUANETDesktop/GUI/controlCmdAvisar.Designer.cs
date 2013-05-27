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
	partial class controlCmdAvisar : System.Windows.Forms.UserControl
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbDesc = new System.Windows.Forms.Label();
			this.txDesc = new System.Windows.Forms.TextBox();
			this.opPGSQL = new System.Windows.Forms.RadioButton();
			this.lbOrigen = new System.Windows.Forms.Label();
			this.opORA = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.grdExpresiones = new System.Windows.Forms.DataGridView();
			this.lbExpresiones = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txSQL = new System.Windows.Forms.TextBox();
			this.lbSQL = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdExpresiones)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbDesc);
			this.panel1.Controls.Add(this.txDesc);
			this.panel1.Controls.Add(this.opPGSQL);
			this.panel1.Controls.Add(this.lbOrigen);
			this.panel1.Controls.Add(this.opORA);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(434, 61);
			this.panel1.TabIndex = 4;
			// 
			// lbDesc
			// 
			this.lbDesc.AutoSize = true;
			this.lbDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbDesc.Location = new System.Drawing.Point(0, 27);
			this.lbDesc.Name = "lbDesc";
			this.lbDesc.Size = new System.Drawing.Size(65, 13);
			this.lbDesc.TabIndex = 5;
			this.lbDesc.Text = "Descripción:";
			// 
			// txDesc
			// 
			this.txDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txDesc.Location = new System.Drawing.Point(0, 40);
			this.txDesc.Name = "txDesc";
			this.txDesc.Size = new System.Drawing.Size(434, 21);
			this.txDesc.TabIndex = 4;
			this.txDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyUp);
			this.txDesc.TextChanged += new System.EventHandler(this.TxDescTextChanged);
			this.txDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyDown);
			// 
			// opPGSQL
			// 
			this.opPGSQL.AutoSize = true;
			this.opPGSQL.Location = new System.Drawing.Point(111, 3);
			this.opPGSQL.Name = "opPGSQL";
			this.opPGSQL.Size = new System.Drawing.Size(81, 17);
			this.opPGSQL.TabIndex = 2;
			this.opPGSQL.TabStop = true;
			this.opPGSQL.Text = "PostgreSQL";
			this.opPGSQL.UseVisualStyleBackColor = true;
			this.opPGSQL.Click += new System.EventHandler(this.OpPGSQLClick);
			// 
			// lbOrigen
			// 
			this.lbOrigen.AutoSize = true;
			this.lbOrigen.Location = new System.Drawing.Point(0, 5);
			this.lbOrigen.Name = "lbOrigen";
			this.lbOrigen.Size = new System.Drawing.Size(43, 13);
			this.lbOrigen.TabIndex = 0;
			this.lbOrigen.Text = "Origen:";
			// 
			// opORA
			// 
			this.opORA.AutoSize = true;
			this.opORA.Location = new System.Drawing.Point(49, 3);
			this.opORA.Name = "opORA";
			this.opORA.Size = new System.Drawing.Size(56, 17);
			this.opORA.TabIndex = 1;
			this.opORA.TabStop = true;
			this.opORA.Text = "Oracle";
			this.opORA.UseVisualStyleBackColor = true;
			this.opORA.Click += new System.EventHandler(this.OpORAClick);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.grdExpresiones);
			this.panel3.Controls.Add(this.lbExpresiones);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 97);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(434, 176);
			this.panel3.TabIndex = 5;
			// 
			// grdExpresiones
			// 
			this.grdExpresiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdExpresiones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdExpresiones.Location = new System.Drawing.Point(0, 13);
			this.grdExpresiones.Name = "grdExpresiones";
			this.grdExpresiones.Size = new System.Drawing.Size(434, 163);
			this.grdExpresiones.TabIndex = 5;
			// 
			// lbExpresiones
			// 
			this.lbExpresiones.AutoSize = true;
			this.lbExpresiones.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbExpresiones.Location = new System.Drawing.Point(0, 0);
			this.lbExpresiones.Name = "lbExpresiones";
			this.lbExpresiones.Size = new System.Drawing.Size(117, 13);
			this.lbExpresiones.TabIndex = 4;
			this.lbExpresiones.Text = "Expresiones a evaluar:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txSQL);
			this.panel2.Controls.Add(this.lbSQL);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 61);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(434, 36);
			this.panel2.TabIndex = 6;
			// 
			// txSQL
			// 
			this.txSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txSQL.Location = new System.Drawing.Point(0, 13);
			this.txSQL.Multiline = true;
			this.txSQL.Name = "txSQL";
			this.txSQL.Size = new System.Drawing.Size(434, 23);
			this.txSQL.TabIndex = 4;
			this.txSQL.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxSQLKeyUp);
			this.txSQL.TextChanged += new System.EventHandler(this.TxSQLTextChanged);
			this.txSQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxSQLKeyDown);
			// 
			// lbSQL
			// 
			this.lbSQL.AutoSize = true;
			this.lbSQL.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbSQL.Location = new System.Drawing.Point(0, 0);
			this.lbSQL.Name = "lbSQL";
			this.lbSQL.Size = new System.Drawing.Size(80, 13);
			this.lbSQL.TabIndex = 3;
			this.lbSQL.Text = "Sentencia SQL:";
			// 
			// controlCmdAvisar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Name = "controlCmdAvisar";
			this.Size = new System.Drawing.Size(434, 273);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdExpresiones)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lbSQL;
		private System.Windows.Forms.TextBox txSQL;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbExpresiones;
		private System.Windows.Forms.DataGridView grdExpresiones;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton opORA;
		private System.Windows.Forms.Label lbOrigen;
		private System.Windows.Forms.RadioButton opPGSQL;
		private System.Windows.Forms.TextBox txDesc;
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.Panel panel1;
	}
}
