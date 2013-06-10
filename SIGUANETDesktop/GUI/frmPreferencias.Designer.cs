/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 22/02/2008
 * Hora: 14:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmPreferencias
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Credenciales de acceso a BD");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Modelo de Documento");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
									treeNode1,
									treeNode2});
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Consultas al catálogo interno");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("PostgreSQL", new System.Windows.Forms.TreeNode[] {
									treeNode4});
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Consultas al catálogo interno");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("ORACLE", new System.Windows.Forms.TreeNode[] {
									treeNode6});
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Base de datos", new System.Windows.Forms.TreeNode[] {
									treeNode5,
									treeNode7});
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvPreferencias = new System.Windows.Forms.TreeView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bCancelar = new System.Windows.Forms.Button();
			this.bAceptar = new System.Windows.Forms.Button();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvPreferencias);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel2);
			this.splitContainer1.Panel2.Controls.Add(this.panel1);
			this.splitContainer1.Size = new System.Drawing.Size(713, 455);
			this.splitContainer1.SplitterDistance = 237;
			this.splitContainer1.TabIndex = 0;
			// 
			// tvPreferencias
			// 
			this.tvPreferencias.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvPreferencias.HideSelection = false;
			this.tvPreferencias.Location = new System.Drawing.Point(0, 0);
			this.tvPreferencias.Name = "tvPreferencias";
			treeNode1.Name = "AuthSearch";
			treeNode1.Text = "Credenciales de acceso a BD";
			treeNode2.Name = "SGDSearch";
			treeNode2.Text = "Modelo de Documento";
			treeNode3.Name = "General";
			treeNode3.Tag = "";
			treeNode3.Text = "General";
			treeNode4.Name = "PGSQLSchemaQuery";
			treeNode4.Text = "Consultas al catálogo interno";
			treeNode5.Name = "PGSQL";
			treeNode5.Text = "PostgreSQL";
			treeNode6.Name = "ORASchemaQuery";
			treeNode6.Text = "Consultas al catálogo interno";
			treeNode7.Name = "ORA";
			treeNode7.Text = "ORACLE";
			treeNode8.Name = "BD";
			treeNode8.Text = "Base de datos";
			this.tvPreferencias.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode3,
									treeNode8});
			this.tvPreferencias.Size = new System.Drawing.Size(237, 455);
			this.tvPreferencias.TabIndex = 0;
			this.tvPreferencias.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvPreferenciasNodeMouseClick);
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(472, 414);
			this.panel2.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bCancelar);
			this.panel1.Controls.Add(this.bAceptar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 414);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(472, 41);
			this.panel1.TabIndex = 0;
			// 
			// bCancelar
			// 
			this.bCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancelar.Location = new System.Drawing.Point(401, 8);
			this.bCancelar.Name = "bCancelar";
			this.bCancelar.Size = new System.Drawing.Size(59, 30);
			this.bCancelar.TabIndex = 10;
			this.bCancelar.Text = "Cancelar";
			this.bCancelar.UseVisualStyleBackColor = true;
			this.bCancelar.Click += new System.EventHandler(this.BCancelarClick);
			// 
			// bAceptar
			// 
			this.bAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bAceptar.Location = new System.Drawing.Point(336, 8);
			this.bAceptar.Name = "bAceptar";
			this.bAceptar.Size = new System.Drawing.Size(59, 30);
			this.bAceptar.TabIndex = 9;
			this.bAceptar.Text = "Aceptar";
			this.bAceptar.UseVisualStyleBackColor = true;
			this.bAceptar.Click += new System.EventHandler(this.BAceptarClick);
			// 
			// frmPreferencias
			// 
			this.AcceptButton = this.bAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancelar;
			this.ClientSize = new System.Drawing.Size(713, 455);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPreferencias";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuración de opciones de SIGUANETDektop";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TreeView tvPreferencias;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button bAceptar;
		private System.Windows.Forms.Button bCancelar;
	}
}
