// Copyright 2009 - José Tomás Navarro Carrión (www.gisandchips.org)

namespace SIGUANETDesktop.GUI
{
	partial class controlPreferenciasLoginService
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
			this.lbEndPoint = new System.Windows.Forms.Label();
			this.txEndPoint = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lbEndPoint
			// 
			this.lbEndPoint.AutoSize = true;
			this.lbEndPoint.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEndPoint.Location = new System.Drawing.Point(3, 3);
			this.lbEndPoint.Name = "lbEndPoint";
			this.lbEndPoint.Size = new System.Drawing.Size(164, 13);
			this.lbEndPoint.TabIndex = 0;
			this.lbEndPoint.Text = "Identificador del servicio de login:";
			// 
			// txEndPoint
			// 
			this.txEndPoint.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEndPoint.Location = new System.Drawing.Point(3, 16);
			this.txEndPoint.Name = "txEndPoint";
			this.txEndPoint.Size = new System.Drawing.Size(417, 20);
			this.txEndPoint.TabIndex = 1;
			this.txEndPoint.TextChanged += new System.EventHandler(this.TxEndPointTextChanged);
			// 
			// controlPreferenciasLoginService
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txEndPoint);
			this.Controls.Add(this.lbEndPoint);
			this.Name = "controlPreferenciasLoginService";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(423, 150);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txEndPoint;
		private System.Windows.Forms.Label lbEndPoint;
	}
}
