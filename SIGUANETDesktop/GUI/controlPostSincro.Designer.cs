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
	partial class controlPostSincro : System.Windows.Forms.UserControl
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
			this.lbComent = new System.Windows.Forms.Label();
			this.txDesc = new System.Windows.Forms.TextBox();
			this.lbDesc = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txComent = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbComent);
			this.panel1.Controls.Add(this.txDesc);
			this.panel1.Controls.Add(this.lbDesc);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(434, 49);
			this.panel1.TabIndex = 3;
			// 
			// lbComent
			// 
			this.lbComent.AutoSize = true;
			this.lbComent.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComent.Location = new System.Drawing.Point(0, 34);
			this.lbComent.Name = "lbComent";
			this.lbComent.Size = new System.Drawing.Size(71, 13);
			this.lbComent.TabIndex = 2;
			this.lbComent.Text = "Comentarios:";
			// 
			// txDesc
			// 
			this.txDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDesc.Location = new System.Drawing.Point(0, 13);
			this.txDesc.Name = "txDesc";
			this.txDesc.Size = new System.Drawing.Size(434, 21);
			this.txDesc.TabIndex = 1;
			this.txDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyUp);
			this.txDesc.TextChanged += new System.EventHandler(this.TxDescTextChanged);
			this.txDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyDown);			
			// 
			// lbDesc
			// 
			this.lbDesc.AutoSize = true;
			this.lbDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDesc.Location = new System.Drawing.Point(0, 0);
			this.lbDesc.Name = "lbDesc";
			this.lbDesc.Size = new System.Drawing.Size(65, 13);
			this.lbDesc.TabIndex = 0;
			this.lbDesc.Text = "Descripción:";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txComent);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 49);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(434, 224);
			this.panel3.TabIndex = 5;
			// 
			// txComent
			// 
			this.txComent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComent.Location = new System.Drawing.Point(0, 0);
			this.txComent.Multiline = true;
			this.txComent.Name = "txComent";
			this.txComent.Size = new System.Drawing.Size(434, 224);
			this.txComent.TabIndex = 1;
			this.txComent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxComentKeyUp);
			this.txComent.TextChanged += new System.EventHandler(this.TxComentTextChanged);
			this.txComent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxComentKeyDown);			
			// 
			// controlPostSincro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Name = "controlPostSincro";
			this.Size = new System.Drawing.Size(434, 273);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txComent;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.TextBox txDesc;
		private System.Windows.Forms.Label lbComent;
		private System.Windows.Forms.Panel panel1;
	}
}
