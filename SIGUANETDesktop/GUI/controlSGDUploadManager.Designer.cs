// Copyright 2009 - José Tomás Navarro Carrión (www.gisandchips.org)

namespace SIGUANETDesktop.GUI
{
	partial class controlSGDUploadManager
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
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bOK = new System.Windows.Forms.Button();
			this.txDestino = new System.Windows.Forms.TextBox();
			this.lDestino = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(375, 20);
			this.panel1.TabIndex = 23;
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(406, 15);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Cliente de uploading del documento actual SIGUANETDesktop";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.panel2.Controls.Add(this.bOK);
			this.panel2.Controls.Add(this.txDestino);
			this.panel2.Controls.Add(this.lDestino);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 20);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(375, 30);
			this.panel2.TabIndex = 24;
			// 
			// bOK
			// 
			this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bOK.Location = new System.Drawing.Point(304, 3);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(65, 20);
			this.bOK.TabIndex = 2;
			this.bOK.Text = "OK";
			this.bOK.UseVisualStyleBackColor = true;
			this.bOK.Click += new System.EventHandler(this.BOKClick);
			// 
			// txDestino
			// 
			this.txDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txDestino.Location = new System.Drawing.Point(55, 4);
			this.txDestino.Name = "txDestino";
			this.txDestino.Size = new System.Drawing.Size(243, 20);
			this.txDestino.TabIndex = 1;
			// 
			// lDestino
			// 
			this.lDestino.AutoSize = true;
			this.lDestino.Location = new System.Drawing.Point(3, 6);
			this.lDestino.Name = "lDestino";
			this.lDestino.Size = new System.Drawing.Size(46, 13);
			this.lDestino.TabIndex = 0;
			this.lDestino.Text = "Destino:";
			// 
			// controlSGDUploadManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "controlSGDUploadManager";
			this.Size = new System.Drawing.Size(375, 54);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lDestino;
		private System.Windows.Forms.TextBox txDestino;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel1;
	}
}
