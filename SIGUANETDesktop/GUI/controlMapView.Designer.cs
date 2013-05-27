/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 02/01/2007
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlMapView : System.Windows.Forms.UserControl
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
			this.MapBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.MapBox)).BeginInit();
			this.SuspendLayout();
			// 
			// MapBox
			// 
			this.MapBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapBox.Location = new System.Drawing.Point(0, 0);
			this.MapBox.Name = "MapBox";
			this.MapBox.Size = new System.Drawing.Size(150, 150);
			this.MapBox.TabIndex = 0;
			this.MapBox.TabStop = false;
			// 
			// controlMapView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MapBox);
			this.Name = "controlMapView";
			((System.ComponentModel.ISupportInitialize)(this.MapBox)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox MapBox;
	}
}
