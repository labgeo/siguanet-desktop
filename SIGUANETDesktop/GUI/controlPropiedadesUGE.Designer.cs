/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/07/2006
 * Time: 13:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlPropiedadesUGE : System.Windows.Forms.UserControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlPropiedadesUGE));
			this.lstPropiedades = new System.Windows.Forms.ListView();
			this.chPropiedad = new System.Windows.Forms.ColumnHeader();
			this.chValor = new System.Windows.Forms.ColumnHeader();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.pgPropiedades = new System.Windows.Forms.ProgressBar();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstPropiedades
			// 
			this.lstPropiedades.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstPropiedades.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.chPropiedad,
									this.chValor});
			this.lstPropiedades.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstPropiedades.Location = new System.Drawing.Point(3, 3);
			this.lstPropiedades.Name = "lstPropiedades";
			this.lstPropiedades.Size = new System.Drawing.Size(489, 329);
			this.lstPropiedades.TabIndex = 0;
			this.lstPropiedades.UseCompatibleStateImageBehavior = false;
			this.lstPropiedades.View = System.Windows.Forms.View.Details;
			this.lstPropiedades.ItemActivate += new System.EventHandler(this.itemSeleccionado);
			// 
			// chPropiedad
			// 
			this.chPropiedad.Text = "Propiedad";
			this.chPropiedad.Width = 300;
			// 
			// chValor
			// 
			this.chValor.Text = "Valor";
			this.chValor.Width = 150;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.lstPropiedades, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.pgPropiedades, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(495, 355);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// pgPropiedades
			// 
			this.pgPropiedades.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgPropiedades.Location = new System.Drawing.Point(3, 338);
			this.pgPropiedades.Name = "pgPropiedades";
			this.pgPropiedades.Size = new System.Drawing.Size(489, 14);
			this.pgPropiedades.TabIndex = 1;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Layers.gif");
			this.imageList1.Images.SetKeyName(1, "Tabla.gif");
			// 
			// controlPropiedadesUGE
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "controlPropiedadesUGE";
			this.Size = new System.Drawing.Size(495, 355);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ProgressBar pgPropiedades;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ColumnHeader chValor;
		private System.Windows.Forms.ColumnHeader chPropiedad;
		private System.Windows.Forms.ListView lstPropiedades;
	}
}
