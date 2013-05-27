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
	partial class controlOrdenarSincros : System.Windows.Forms.UserControl
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
			this.lSincro = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.bArriba = new System.Windows.Forms.Button();
			this.bAbajo = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lSincro);
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(466, 206);
			this.panel1.TabIndex = 0;
			// 
			// lSincro
			// 
			this.lSincro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lSincro.FormattingEnabled = true;
			this.lSincro.IntegralHeight = false;
			this.lSincro.Location = new System.Drawing.Point(0, 0);
			this.lSincro.Name = "lSincro";
			this.lSincro.Size = new System.Drawing.Size(396, 206);
			this.lSincro.TabIndex = 4;
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
			this.tableLayoutPanel1.TabIndex = 3;
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
			// controlOrdenarSincro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "controlOrdenarSincro";
			this.Size = new System.Drawing.Size(466, 206);
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button bAbajo;
		private System.Windows.Forms.Button bArriba;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListBox lSincro;
		private System.Windows.Forms.Panel panel1;
	}
}
