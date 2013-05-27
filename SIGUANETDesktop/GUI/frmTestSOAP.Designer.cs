/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 10/04/2007
 * Time: 17:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmTestSOAP : System.Windows.Forms.Form
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
			this.txTestSOAP = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txTestSOAP
			// 
			this.txTestSOAP.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.txTestSOAP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txTestSOAP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txTestSOAP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txTestSOAP.Location = new System.Drawing.Point(0, 0);
			this.txTestSOAP.Multiline = true;
			this.txTestSOAP.Name = "txTestSOAP";
			this.txTestSOAP.ReadOnly = true;
			this.txTestSOAP.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txTestSOAP.Size = new System.Drawing.Size(523, 211);
			this.txTestSOAP.TabIndex = 0;
			// 
			// frmTestSOAP
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(523, 211);
			this.Controls.Add(this.txTestSOAP);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTestSOAP";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Test del Servicio Web";
			this.Shown += new System.EventHandler(this.FrmTestSOAPShown);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txTestSOAP;
	}
}
