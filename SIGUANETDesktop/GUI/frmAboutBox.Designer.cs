// Copyright 2009 - José Tomás Navarro Carrión (www.gisandchips.org)

namespace SIGUANETDesktop.GUI
{
	partial class frmAboutBox
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAboutBox));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lbManifest = new System.Windows.Forms.Label();
			this.lVersion = new System.Windows.Forms.Label();
			this.lCopyright = new System.Windows.Forms.Label();
			this.tcInfo = new System.Windows.Forms.TabControl();
			this.tpGeeks = new System.Windows.Forms.TabPage();
			this.lbGeeks = new System.Windows.Forms.ListBox();
			this.lGeeks = new System.Windows.Forms.Label();
			this.tpDependencies = new System.Windows.Forms.TabPage();
			this.lvDependencies = new System.Windows.Forms.ListView();
			this.Assembly = new System.Windows.Forms.ColumnHeader();
			this.Version = new System.Windows.Forms.ColumnHeader();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tcInfo.SuspendLayout();
			this.tpGeeks.SuspendLayout();
			this.tpDependencies.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(391, 55);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(127, 51);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// lbManifest
			// 
			this.lbManifest.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbManifest.Location = new System.Drawing.Point(12, 109);
			this.lbManifest.Name = "lbManifest";
			this.lbManifest.Size = new System.Drawing.Size(506, 46);
			this.lbManifest.TabIndex = 1;
			this.lbManifest.Text = resources.GetString("lbManifest.Text");
			// 
			// lVersion
			// 
			this.lVersion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lVersion.Location = new System.Drawing.Point(12, 12);
			this.lVersion.Name = "lVersion";
			this.lVersion.Size = new System.Drawing.Size(498, 20);
			this.lVersion.TabIndex = 2;
			// 
			// lCopyright
			// 
			this.lCopyright.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lCopyright.Location = new System.Drawing.Point(12, 32);
			this.lCopyright.Name = "lCopyright";
			this.lCopyright.Size = new System.Drawing.Size(498, 20);
			this.lCopyright.TabIndex = 3;
			// 
			// tcInfo
			// 
			this.tcInfo.Controls.Add(this.tpGeeks);
			this.tcInfo.Controls.Add(this.tpDependencies);
			this.tcInfo.Location = new System.Drawing.Point(12, 158);
			this.tcInfo.Name = "tcInfo";
			this.tcInfo.SelectedIndex = 0;
			this.tcInfo.Size = new System.Drawing.Size(506, 173);
			this.tcInfo.TabIndex = 4;
			// 
			// tpGeeks
			// 
			this.tpGeeks.Controls.Add(this.lbGeeks);
			this.tpGeeks.Controls.Add(this.lGeeks);
			this.tpGeeks.Location = new System.Drawing.Point(4, 22);
			this.tpGeeks.Name = "tpGeeks";
			this.tpGeeks.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeeks.Size = new System.Drawing.Size(498, 147);
			this.tpGeeks.TabIndex = 0;
			this.tpGeeks.Text = "SIGUANETDesktop Geeks";
			this.tpGeeks.UseVisualStyleBackColor = true;
			// 
			// lbGeeks
			// 
			this.lbGeeks.ColumnWidth = 200;
			this.lbGeeks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbGeeks.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbGeeks.FormattingEnabled = true;
			this.lbGeeks.Location = new System.Drawing.Point(3, 32);
			this.lbGeeks.MultiColumn = true;
			this.lbGeeks.Name = "lbGeeks";
			this.lbGeeks.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.lbGeeks.Size = new System.Drawing.Size(492, 108);
			this.lbGeeks.TabIndex = 2;
			// 
			// lGeeks
			// 
			this.lGeeks.Dock = System.Windows.Forms.DockStyle.Top;
			this.lGeeks.Location = new System.Drawing.Point(3, 3);
			this.lGeeks.Name = "lGeeks";
			this.lGeeks.Size = new System.Drawing.Size(492, 29);
			this.lGeeks.TabIndex = 1;
			this.lGeeks.Text = "Estas son todas las personas que han diseñado, desarrollado o colaborado activame" +
			"nte para que puedas usar SIGUANETDesktop:";
			// 
			// tpDependencies
			// 
			this.tpDependencies.Controls.Add(this.lvDependencies);
			this.tpDependencies.Location = new System.Drawing.Point(4, 22);
			this.tpDependencies.Name = "tpDependencies";
			this.tpDependencies.Padding = new System.Windows.Forms.Padding(3);
			this.tpDependencies.Size = new System.Drawing.Size(490, 133);
			this.tpDependencies.TabIndex = 1;
			this.tpDependencies.Text = "Componentes de software";
			this.tpDependencies.UseVisualStyleBackColor = true;
			// 
			// lvDependencies
			// 
			this.lvDependencies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.Assembly,
									this.Version});
			this.lvDependencies.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvDependencies.Location = new System.Drawing.Point(3, 3);
			this.lvDependencies.Name = "lvDependencies";
			this.lvDependencies.Size = new System.Drawing.Size(484, 127);
			this.lvDependencies.TabIndex = 0;
			this.lvDependencies.UseCompatibleStateImageBehavior = false;
			this.lvDependencies.View = System.Windows.Forms.View.Details;
			// 
			// Assembly
			// 
			this.Assembly.Text = "Ensamblado";
			this.Assembly.Width = 300;
			// 
			// Version
			// 
			this.Version.Text = "Versión";
			this.Version.Width = 150;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(12, 55);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(263, 45);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 5;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(281, 55);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(104, 28);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox3.TabIndex = 6;
			this.pictureBox3.TabStop = false;
			// 
			// frmAboutBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(528, 343);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.tcInfo);
			this.Controls.Add(this.lCopyright);
			this.Controls.Add(this.lVersion);
			this.Controls.Add(this.lbManifest);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmAboutBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Acerca de SIGUANETDesktop";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tcInfo.ResumeLayout(false);
			this.tpGeeks.ResumeLayout(false);
			this.tpDependencies.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ColumnHeader Version;
		private System.Windows.Forms.ColumnHeader Assembly;
		private System.Windows.Forms.ListView lvDependencies;
		private System.Windows.Forms.TabPage tpDependencies;
		private System.Windows.Forms.ListBox lbGeeks;
		private System.Windows.Forms.Label lGeeks;
		private System.Windows.Forms.TabPage tpGeeks;
		private System.Windows.Forms.TabControl tcInfo;
		private System.Windows.Forms.Label lCopyright;
		private System.Windows.Forms.Label lVersion;
		private System.Windows.Forms.Label lbManifest;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
