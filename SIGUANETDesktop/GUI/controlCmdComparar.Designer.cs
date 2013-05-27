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
	partial class controlCmdComparar : System.Windows.Forms.UserControl
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
			this.grdJoin = new System.Windows.Forms.DataGridView();
			this.lbRel = new System.Windows.Forms.Label();
			this.txTblSIGUA = new System.Windows.Forms.TextBox();
			this.lbTblSIGUA = new System.Windows.Forms.Label();
			this.txTblCPD = new System.Windows.Forms.TextBox();
			this.lbTblCPD = new System.Windows.Forms.Label();
			this.txDesc = new System.Windows.Forms.TextBox();
			this.lbDesc = new System.Windows.Forms.Label();
			this.txDireccion = new System.Windows.Forms.TextBox();
			this.lbDireccion = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdJoin)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.grdJoin);
			this.panel1.Controls.Add(this.lbRel);
			this.panel1.Controls.Add(this.txTblSIGUA);
			this.panel1.Controls.Add(this.lbTblSIGUA);
			this.panel1.Controls.Add(this.txTblCPD);
			this.panel1.Controls.Add(this.lbTblCPD);
			this.panel1.Controls.Add(this.txDesc);
			this.panel1.Controls.Add(this.lbDesc);
			this.panel1.Controls.Add(this.txDireccion);
			this.panel1.Controls.Add(this.lbDireccion);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(434, 273);
			this.panel1.TabIndex = 0;
			// 
			// grdJoin
			// 
			this.grdJoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdJoin.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdJoin.Location = new System.Drawing.Point(0, 149);
			this.grdJoin.Name = "grdJoin";
			this.grdJoin.Size = new System.Drawing.Size(434, 124);
			this.grdJoin.TabIndex = 41;
			// 
			// lbRel
			// 
			this.lbRel.AutoSize = true;
			this.lbRel.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbRel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRel.Location = new System.Drawing.Point(0, 136);
			this.lbRel.Name = "lbRel";
			this.lbRel.Size = new System.Drawing.Size(126, 13);
			this.lbRel.TabIndex = 40;
			this.lbRel.Text = "Diseño de la relación:";
			// 
			// txTblSIGUA
			// 
			this.txTblSIGUA.Dock = System.Windows.Forms.DockStyle.Top;
			this.txTblSIGUA.Location = new System.Drawing.Point(0, 115);
			this.txTblSIGUA.Name = "txTblSIGUA";
			this.txTblSIGUA.Size = new System.Drawing.Size(434, 21);
			this.txTblSIGUA.TabIndex = 19;
			this.txTblSIGUA.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxTblSIGUAKeyUp);
			this.txTblSIGUA.TextChanged += new System.EventHandler(this.TxTblSIGUATextChanged);
			this.txTblSIGUA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxTblSIGUAKeyDown);
			// 
			// lbTblSIGUA
			// 
			this.lbTblSIGUA.AutoSize = true;
			this.lbTblSIGUA.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTblSIGUA.Location = new System.Drawing.Point(0, 102);
			this.lbTblSIGUA.Name = "lbTblSIGUA";
			this.lbTblSIGUA.Size = new System.Drawing.Size(204, 13);
			this.lbTblSIGUA.TabIndex = 18;
			this.lbTblSIGUA.Text = "Nombre de tabla SIGUANET o SELECT FROM:";
			// 
			// txTblCPD
			// 
			this.txTblCPD.Dock = System.Windows.Forms.DockStyle.Top;
			this.txTblCPD.Location = new System.Drawing.Point(0, 81);
			this.txTblCPD.Name = "txTblCPD";
			this.txTblCPD.Size = new System.Drawing.Size(434, 21);
			this.txTblCPD.TabIndex = 17;
			this.txTblCPD.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxTblCPDKeyUp);
			this.txTblCPD.TextChanged += new System.EventHandler(this.TxTblCPDTextChanged);
			this.txTblCPD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxTblCPDKeyDown);
			// 
			// lbTblCPD
			// 
			this.lbTblCPD.AutoSize = true;
			this.lbTblCPD.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTblCPD.Location = new System.Drawing.Point(0, 68);
			this.lbTblCPD.Name = "lbTblCPD";
			this.lbTblCPD.Size = new System.Drawing.Size(193, 13);
			this.lbTblCPD.TabIndex = 16;
			this.lbTblCPD.Text = "Nombre de tabla CPD o SELECT FROM:";
			// 
			// txDesc
			// 
			this.txDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDesc.Location = new System.Drawing.Point(0, 47);
			this.txDesc.Name = "txDesc";
			this.txDesc.Size = new System.Drawing.Size(434, 21);
			this.txDesc.TabIndex = 15;
			this.txDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyUp);
			this.txDesc.TextChanged += new System.EventHandler(this.TxDescTextChanged);
			this.txDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyDown);
			// 
			// lbDesc
			// 
			this.lbDesc.AutoSize = true;
			this.lbDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDesc.Location = new System.Drawing.Point(0, 34);
			this.lbDesc.Name = "lbDesc";
			this.lbDesc.Size = new System.Drawing.Size(65, 13);
			this.lbDesc.TabIndex = 14;
			this.lbDesc.Text = "Descripción:";
			// 
			// txDireccion
			// 
			this.txDireccion.BackColor = System.Drawing.SystemColors.Info;
			this.txDireccion.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.txDireccion.Location = new System.Drawing.Point(0, 13);
			this.txDireccion.Name = "txDireccion";
			this.txDireccion.ReadOnly = true;
			this.txDireccion.Size = new System.Drawing.Size(434, 21);
			this.txDireccion.TabIndex = 13;
			// 
			// lbDireccion
			// 
			this.lbDireccion.AutoSize = true;
			this.lbDireccion.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDireccion.Location = new System.Drawing.Point(0, 0);
			this.lbDireccion.Name = "lbDireccion";
			this.lbDireccion.Size = new System.Drawing.Size(143, 13);
			this.lbDireccion.TabIndex = 12;
			this.lbDireccion.Text = "Dirección de la comparación:";
			// 
			// controlCmdComparar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "controlCmdComparar";
			this.Size = new System.Drawing.Size(434, 273);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdJoin)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txDireccion;
		private System.Windows.Forms.Label lbDireccion;
		private System.Windows.Forms.DataGridView grdJoin;
		private System.Windows.Forms.Label lbRel;
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.TextBox txDesc;
		private System.Windows.Forms.Label lbTblCPD;
		private System.Windows.Forms.TextBox txTblCPD;
		private System.Windows.Forms.Label lbTblSIGUA;
		private System.Windows.Forms.TextBox txTblSIGUA;
		private System.Windows.Forms.Panel panel1;
	}
}
