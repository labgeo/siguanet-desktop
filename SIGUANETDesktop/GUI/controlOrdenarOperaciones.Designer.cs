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
	partial class controlOrdenarOperaciones : System.Windows.Forms.UserControl
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
			this.bAbajo = new System.Windows.Forms.Button();
			this.bArriba = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lOperaciones = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bAbajo
			// 
			this.bAbajo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bAbajo.Font = new System.Drawing.Font("Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.bAbajo.Location = new System.Drawing.Point(3, 106);
			this.bAbajo.Name = "bAbajo";
			this.bAbajo.Size = new System.Drawing.Size(64, 34);
			this.bAbajo.TabIndex = 1;
			this.bAbajo.Text = "Ñ";
			this.bAbajo.UseVisualStyleBackColor = true;
			this.bAbajo.Click += new System.EventHandler(this.BAbajoClick);
			// 
			// bArriba
			// 
			this.bArriba.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bArriba.Font = new System.Drawing.Font("Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.bArriba.Location = new System.Drawing.Point(3, 66);
			this.bArriba.Name = "bArriba";
			this.bArriba.Size = new System.Drawing.Size(64, 34);
			this.bArriba.TabIndex = 0;
			this.bArriba.Text = "D";
			this.bArriba.UseVisualStyleBackColor = true;
			this.bArriba.Click += new System.EventHandler(this.BArribaClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lOperaciones);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(466, 206);
			this.panel2.TabIndex = 1;
			// 
			// lOperaciones
			// 
			this.lOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lOperaciones.FormattingEnabled = true;
			this.lOperaciones.IntegralHeight = false;
			this.lOperaciones.Location = new System.Drawing.Point(0, 0);
			this.lOperaciones.Name = "lOperaciones";
			this.lOperaciones.Size = new System.Drawing.Size(466, 206);
			this.lOperaciones.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.bArriba, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.bAbajo, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(396, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(70, 206);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// controlOrdenarOperaciones
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.panel2);
			this.Name = "controlOrdenarOperaciones";
			this.Size = new System.Drawing.Size(466, 206);
			this.panel2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListBox lOperaciones;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button bArriba;
		private System.Windows.Forms.Button bAbajo;
	}
}
