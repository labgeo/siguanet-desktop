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
	partial class controlCmdSincronizar : System.Windows.Forms.UserControl
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
			this.panel3 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpJoins = new System.Windows.Forms.TabPage();
			this.grdJoins = new System.Windows.Forms.DataGridView();
			this.tpCorrespondencias = new System.Windows.Forms.TabPage();
			this.grdCorrespondencias = new System.Windows.Forms.DataGridView();
			this.tpDefaults = new System.Windows.Forms.TabPage();
			this.grdDefaults = new System.Windows.Forms.DataGridView();
			this.tpSimulaciones = new System.Windows.Forms.TabPage();
			this.grdSimulaciones = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lnkConfigurarExc = new System.Windows.Forms.LinkLabel();
			this.rbDesactivarExc = new System.Windows.Forms.RadioButton();
			this.rbActivarExc = new System.Windows.Forms.RadioButton();
			this.lbExc = new System.Windows.Forms.Label();
			this.txTblSIGUA = new System.Windows.Forms.TextBox();
			this.lbTblSIGUA = new System.Windows.Forms.Label();
			this.txTblCPD = new System.Windows.Forms.TextBox();
			this.lbTblCPD = new System.Windows.Forms.Label();
			this.txDesc = new System.Windows.Forms.TextBox();
			this.lbDesc = new System.Windows.Forms.Label();
			this.txDireccion = new System.Windows.Forms.TextBox();
			this.lbDireccion = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpJoins.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdJoins)).BeginInit();
			this.tpCorrespondencias.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCorrespondencias)).BeginInit();
			this.tpDefaults.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdDefaults)).BeginInit();
			this.tpSimulaciones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdSimulaciones)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
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
			this.panel1.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.tabControl1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 136);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(305, 137);
			this.panel3.TabIndex = 23;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpJoins);
			this.tabControl1.Controls.Add(this.tpCorrespondencias);
			this.tabControl1.Controls.Add(this.tpDefaults);
			this.tabControl1.Controls.Add(this.tpSimulaciones);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(305, 137);
			this.tabControl1.TabIndex = 23;
			// 
			// tpJoins
			// 
			this.tpJoins.Controls.Add(this.grdJoins);
			this.tpJoins.Location = new System.Drawing.Point(4, 22);
			this.tpJoins.Name = "tpJoins";
			this.tpJoins.Padding = new System.Windows.Forms.Padding(3);
			this.tpJoins.Size = new System.Drawing.Size(297, 111);
			this.tpJoins.TabIndex = 0;
			this.tpJoins.Text = "Diseño de la relación";
			this.tpJoins.UseVisualStyleBackColor = true;
			// 
			// grdJoins
			// 
			this.grdJoins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdJoins.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdJoins.Location = new System.Drawing.Point(3, 3);
			this.grdJoins.Name = "grdJoins";
			this.grdJoins.Size = new System.Drawing.Size(291, 105);
			this.grdJoins.TabIndex = 22;
			// 
			// tpCorrespondencias
			// 
			this.tpCorrespondencias.Controls.Add(this.grdCorrespondencias);
			this.tpCorrespondencias.Location = new System.Drawing.Point(4, 22);
			this.tpCorrespondencias.Name = "tpCorrespondencias";
			this.tpCorrespondencias.Padding = new System.Windows.Forms.Padding(3);
			this.tpCorrespondencias.Size = new System.Drawing.Size(297, 115);
			this.tpCorrespondencias.TabIndex = 1;
			this.tpCorrespondencias.Text = "Correspondencias entre campos";
			this.tpCorrespondencias.UseVisualStyleBackColor = true;
			// 
			// grdCorrespondencias
			// 
			this.grdCorrespondencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdCorrespondencias.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdCorrespondencias.Location = new System.Drawing.Point(3, 3);
			this.grdCorrespondencias.Name = "grdCorrespondencias";
			this.grdCorrespondencias.Size = new System.Drawing.Size(291, 109);
			this.grdCorrespondencias.TabIndex = 0;
			// 
			// tpDefaults
			// 
			this.tpDefaults.Controls.Add(this.grdDefaults);
			this.tpDefaults.Location = new System.Drawing.Point(4, 22);
			this.tpDefaults.Name = "tpDefaults";
			this.tpDefaults.Size = new System.Drawing.Size(297, 115);
			this.tpDefaults.TabIndex = 2;
			this.tpDefaults.Text = "Valores por defecto para campos sin correspondencia";
			this.tpDefaults.UseVisualStyleBackColor = true;
			// 
			// grdDefaults
			// 
			this.grdDefaults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdDefaults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdDefaults.Location = new System.Drawing.Point(0, 0);
			this.grdDefaults.Name = "grdDefaults";
			this.grdDefaults.Size = new System.Drawing.Size(297, 115);
			this.grdDefaults.TabIndex = 0;
			// 
			// tpSimulaciones
			// 
			this.tpSimulaciones.Controls.Add(this.grdSimulaciones);
			this.tpSimulaciones.Location = new System.Drawing.Point(4, 22);
			this.tpSimulaciones.Name = "tpSimulaciones";
			this.tpSimulaciones.Size = new System.Drawing.Size(297, 111);
			this.tpSimulaciones.TabIndex = 3;
			this.tpSimulaciones.Text = "Control de errores";
			this.tpSimulaciones.UseVisualStyleBackColor = true;
			// 
			// grdSimulaciones
			// 
			this.grdSimulaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdSimulaciones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdSimulaciones.Location = new System.Drawing.Point(0, 0);
			this.grdSimulaciones.Name = "grdSimulaciones";
			this.grdSimulaciones.Size = new System.Drawing.Size(297, 111);
			this.grdSimulaciones.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lnkConfigurarExc);
			this.panel2.Controls.Add(this.rbDesactivarExc);
			this.panel2.Controls.Add(this.rbActivarExc);
			this.panel2.Controls.Add(this.lbExc);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(305, 136);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(129, 137);
			this.panel2.TabIndex = 22;
			// 
			// lnkConfigurarExc
			// 
			this.lnkConfigurarExc.Dock = System.Windows.Forms.DockStyle.Top;
			this.lnkConfigurarExc.Location = new System.Drawing.Point(0, 51);
			this.lnkConfigurarExc.Name = "lnkConfigurarExc";
			this.lnkConfigurarExc.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
			this.lnkConfigurarExc.Size = new System.Drawing.Size(129, 24);
			this.lnkConfigurarExc.TabIndex = 3;
			this.lnkConfigurarExc.TabStop = true;
			this.lnkConfigurarExc.Text = "Configurar";
			this.lnkConfigurarExc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkConfigurarExcLinkClicked);
			// 
			// rbDesactivarExc
			// 
			this.rbDesactivarExc.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbDesactivarExc.Location = new System.Drawing.Point(0, 32);
			this.rbDesactivarExc.Name = "rbDesactivarExc";
			this.rbDesactivarExc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.rbDesactivarExc.Size = new System.Drawing.Size(129, 19);
			this.rbDesactivarExc.TabIndex = 2;
			this.rbDesactivarExc.TabStop = true;
			this.rbDesactivarExc.Text = "Desactivar";
			this.rbDesactivarExc.UseVisualStyleBackColor = true;
			this.rbDesactivarExc.Click += new System.EventHandler(this.RbDesactivarExcClick);
			this.rbDesactivarExc.CheckedChanged += new System.EventHandler(this.RbDesactivarExcCheckedChanged);
			// 
			// rbActivarExc
			// 
			this.rbActivarExc.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbActivarExc.Location = new System.Drawing.Point(0, 17);
			this.rbActivarExc.Name = "rbActivarExc";
			this.rbActivarExc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.rbActivarExc.Size = new System.Drawing.Size(129, 15);
			this.rbActivarExc.TabIndex = 1;
			this.rbActivarExc.TabStop = true;
			this.rbActivarExc.Text = "Activar";
			this.rbActivarExc.UseVisualStyleBackColor = true;
			this.rbActivarExc.Click += new System.EventHandler(this.RbActivarExcClick);
			this.rbActivarExc.CheckedChanged += new System.EventHandler(this.RbActivarExcCheckedChanged);
			// 
			// lbExc
			// 
			this.lbExc.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbExc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbExc.Location = new System.Drawing.Point(0, 0);
			this.lbExc.Name = "lbExc";
			this.lbExc.Size = new System.Drawing.Size(129, 17);
			this.lbExc.TabIndex = 0;
			this.lbExc.Text = "Excepciones";
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
			// controlCmdSincronizar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "controlCmdSincronizar";
			this.Size = new System.Drawing.Size(434, 273);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tpJoins.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdJoins)).EndInit();
			this.tpCorrespondencias.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdCorrespondencias)).EndInit();
			this.tpDefaults.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdDefaults)).EndInit();
			this.tpSimulaciones.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdSimulaciones)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridView grdSimulaciones;
		private System.Windows.Forms.TabPage tpSimulaciones;
		private System.Windows.Forms.DataGridView grdDefaults;
		private System.Windows.Forms.TabPage tpDefaults;
		private System.Windows.Forms.DataGridView grdJoins;
		private System.Windows.Forms.TabPage tpJoins;
		private System.Windows.Forms.DataGridView grdCorrespondencias;
		private System.Windows.Forms.TabPage tpCorrespondencias;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.RadioButton rbActivarExc;
		private System.Windows.Forms.Label lbExc;
		private System.Windows.Forms.RadioButton rbDesactivarExc;
		private System.Windows.Forms.LinkLabel lnkConfigurarExc;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbDireccion;
		private System.Windows.Forms.TextBox txDireccion;
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.TextBox txDesc;
		private System.Windows.Forms.Label lbTblCPD;
		private System.Windows.Forms.TextBox txTblCPD;
		private System.Windows.Forms.Label lbTblSIGUA;
		private System.Windows.Forms.TextBox txTblSIGUA;
		private System.Windows.Forms.Panel panel1;
	}
}
