/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 26/03/2007
 * Time: 19:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlSesionSOAP : System.Windows.Forms.UserControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlSesionSOAP));
			this.panel1 = new System.Windows.Forms.Panel();
			this.txDesc = new System.Windows.Forms.TextBox();
			this.lbDesc = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tcPrincipal = new System.Windows.Forms.TabControl();
			this.tpComent = new System.Windows.Forms.TabPage();
			this.txComent = new System.Windows.Forms.TextBox();
			this.tpMI = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lMI = new System.Windows.Forms.ListBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsNuevoMI = new System.Windows.Forms.ToolStripButton();
			this.tsBorrarMI = new System.Windows.Forms.ToolStripButton();
			this.tsSubirMI = new System.Windows.Forms.ToolStripButton();
			this.tsBajarMI = new System.Windows.Forms.ToolStripButton();
			this.tsObsoletoMI = new System.Windows.Forms.ToolStripButton();
			this.tsGuardarMI = new System.Windows.Forms.ToolStripButton();
			this.txComentarioMI = new System.Windows.Forms.TextBox();
			this.lbComentarioMI = new System.Windows.Forms.Label();
			this.chAnonimoMI = new System.Windows.Forms.CheckBox();
			this.txEtiquetaMI = new System.Windows.Forms.TextBox();
			this.lbEtiquetaMI = new System.Windows.Forms.Label();
			this.tpMV = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.lMV = new System.Windows.Forms.ListBox();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tsNuevoMV = new System.Windows.Forms.ToolStripButton();
			this.tsBorrarMV = new System.Windows.Forms.ToolStripButton();
			this.tsSubirMV = new System.Windows.Forms.ToolStripButton();
			this.tsBajarMV = new System.Windows.Forms.ToolStripButton();
			this.tsObsoletoMV = new System.Windows.Forms.ToolStripButton();
			this.tsGuardarMV = new System.Windows.Forms.ToolStripButton();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tpGeneralMV = new System.Windows.Forms.TabPage();
			this.txComentarioMV = new System.Windows.Forms.TextBox();
			this.lbComentarioMV = new System.Windows.Forms.Label();
			this.chAnonimoMV = new System.Windows.Forms.CheckBox();
			this.txEtiquetaMV = new System.Windows.Forms.TextBox();
			this.lbEtiquetaMV = new System.Windows.Forms.Label();
			this.tpParamsMV = new System.Windows.Forms.TabPage();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.lParamsMV = new System.Windows.Forms.ListBox();
			this.txComentarioParamMV = new System.Windows.Forms.TextBox();
			this.lbComentarioParamMV = new System.Windows.Forms.Label();
			this.txMiembroDisplayParamMV = new System.Windows.Forms.TextBox();
			this.lbMiembroDisplayParamMV = new System.Windows.Forms.Label();
			this.txMiembroValorParamMV = new System.Windows.Forms.TextBox();
			this.lbMiembroValorParamMV = new System.Windows.Forms.Label();
			this.txOrigenParamMV = new System.Windows.Forms.TextBox();
			this.lbOrigenParamMV = new System.Windows.Forms.Label();
			this.chNuloParamMV = new System.Windows.Forms.CheckBox();
			this.txDefaultParamMV = new System.Windows.Forms.TextBox();
			this.lbDefaultParamMV = new System.Windows.Forms.Label();
			this.txEtiquetaParamMV = new System.Windows.Forms.TextBox();
			this.lbEtiquetaParamMV = new System.Windows.Forms.Label();
			this.tpMC = new System.Windows.Forms.TabPage();
			this.containerMC = new System.Windows.Forms.SplitContainer();
			this.lMC = new System.Windows.Forms.ListBox();
			this.lbMC = new System.Windows.Forms.Label();
			this.cGC = new System.Windows.Forms.ComboBox();
			this.lbGC = new System.Windows.Forms.Label();
			this.toolsMC = new System.Windows.Forms.ToolStrip();
			this.tsNuevoMC = new System.Windows.Forms.ToolStripButton();
			this.tsBorrarMC = new System.Windows.Forms.ToolStripButton();
			this.tsSubirMC = new System.Windows.Forms.ToolStripButton();
			this.tsBajarMC = new System.Windows.Forms.ToolStripButton();
			this.tsMoverMC = new System.Windows.Forms.ToolStripButton();
			this.tsObsoletoMC = new System.Windows.Forms.ToolStripButton();
			this.tsGuardarMC = new System.Windows.Forms.ToolStripButton();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tpGeneralMC = new System.Windows.Forms.TabPage();
			this.txComentarioMC = new System.Windows.Forms.TextBox();
			this.lbComentarioMC = new System.Windows.Forms.Label();
			this.txEtiquetaMC = new System.Windows.Forms.TextBox();
			this.lbEtiquetaMC = new System.Windows.Forms.Label();
			this.tpParamsMC = new System.Windows.Forms.TabPage();
			this.containerParamsMC = new System.Windows.Forms.SplitContainer();
			this.lParamsMC = new System.Windows.Forms.ListBox();
			this.txComentarioParamMC = new System.Windows.Forms.TextBox();
			this.lbComentarioParamMC = new System.Windows.Forms.Label();
			this.txMiembroDisplayParamMC = new System.Windows.Forms.TextBox();
			this.lbMiembroDisplayParamMC = new System.Windows.Forms.Label();
			this.txMiembroValorParamMC = new System.Windows.Forms.TextBox();
			this.lbMiembroValorParamMC = new System.Windows.Forms.Label();
			this.txOrigenParamMC = new System.Windows.Forms.TextBox();
			this.lbOrigenParamMC = new System.Windows.Forms.Label();
			this.chNuloParamMC = new System.Windows.Forms.CheckBox();
			this.txDefaultParamMC = new System.Windows.Forms.TextBox();
			this.lbDefaultParamMC = new System.Windows.Forms.Label();
			this.txEtiquetaParamMC = new System.Windows.Forms.TextBox();
			this.lbEtiquetaParamMC = new System.Windows.Forms.Label();
			this.tpME = new System.Windows.Forms.TabPage();
			this.containerME = new System.Windows.Forms.SplitContainer();
			this.lME = new System.Windows.Forms.ListBox();
			this.lbME = new System.Windows.Forms.Label();
			this.cGE = new System.Windows.Forms.ComboBox();
			this.lbGE = new System.Windows.Forms.Label();
			this.toolsME = new System.Windows.Forms.ToolStrip();
			this.tsNuevoME = new System.Windows.Forms.ToolStripButton();
			this.tsBorrarME = new System.Windows.Forms.ToolStripButton();
			this.tsSubirME = new System.Windows.Forms.ToolStripButton();
			this.tsBajarME = new System.Windows.Forms.ToolStripButton();
			this.tsMoverME = new System.Windows.Forms.ToolStripButton();
			this.tsObsoletoME = new System.Windows.Forms.ToolStripButton();
			this.tsGuardarME = new System.Windows.Forms.ToolStripButton();
			this.tabControl4 = new System.Windows.Forms.TabControl();
			this.tpGeneralME = new System.Windows.Forms.TabPage();
			this.txComentarioME = new System.Windows.Forms.TextBox();
			this.lbComentarioME = new System.Windows.Forms.Label();
			this.txEtiquetaME = new System.Windows.Forms.TextBox();
			this.lbEtiquetaME = new System.Windows.Forms.Label();
			this.tpParamsME = new System.Windows.Forms.TabPage();
			this.containerParamsME = new System.Windows.Forms.SplitContainer();
			this.lParamsME = new System.Windows.Forms.ListBox();
			this.txComentarioParamME = new System.Windows.Forms.TextBox();
			this.lbComentarioParamME = new System.Windows.Forms.Label();
			this.txMiembroDisplayParamME = new System.Windows.Forms.TextBox();
			this.lbMiembroDisplayParamME = new System.Windows.Forms.Label();
			this.txMiembroValorParamME = new System.Windows.Forms.TextBox();
			this.lbMiembroValorParamME = new System.Windows.Forms.Label();
			this.txOrigenParamME = new System.Windows.Forms.TextBox();
			this.lbOrigenParamME = new System.Windows.Forms.Label();
			this.chNuloParamME = new System.Windows.Forms.CheckBox();
			this.txDefaultParamME = new System.Windows.Forms.TextBox();
			this.lbDefaultParamME = new System.Windows.Forms.Label();
			this.txEtiquetaParamME = new System.Windows.Forms.TextBox();
			this.lbEtiquetaParamME = new System.Windows.Forms.Label();
			this.tpGC = new System.Windows.Forms.TabPage();
			this.containerGC = new System.Windows.Forms.SplitContainer();
			this.lGC = new System.Windows.Forms.ListBox();
			this.toolsGC = new System.Windows.Forms.ToolStrip();
			this.tsNuevoGC = new System.Windows.Forms.ToolStripButton();
			this.tsBorrarGC = new System.Windows.Forms.ToolStripButton();
			this.tsSubirGC = new System.Windows.Forms.ToolStripButton();
			this.tsBajarGC = new System.Windows.Forms.ToolStripButton();
			this.tsGuardarGC = new System.Windows.Forms.ToolStripButton();
			this.txComentarioGC = new System.Windows.Forms.TextBox();
			this.lbComentarioGC = new System.Windows.Forms.Label();
			this.txEtiquetaGC = new System.Windows.Forms.TextBox();
			this.lbEtiquetaGC = new System.Windows.Forms.Label();
			this.tpGE = new System.Windows.Forms.TabPage();
			this.containerGE = new System.Windows.Forms.SplitContainer();
			this.lGE = new System.Windows.Forms.ListBox();
			this.toolsGE = new System.Windows.Forms.ToolStrip();
			this.tsNuevoGE = new System.Windows.Forms.ToolStripButton();
			this.tsBorrarGE = new System.Windows.Forms.ToolStripButton();
			this.tsSubirGE = new System.Windows.Forms.ToolStripButton();
			this.tsBajarGE = new System.Windows.Forms.ToolStripButton();
			this.tsGuardarGE = new System.Windows.Forms.ToolStripButton();
			this.txComentarioGE = new System.Windows.Forms.TextBox();
			this.lbComentarioGE = new System.Windows.Forms.Label();
			this.txEtiquetaGE = new System.Windows.Forms.TextBox();
			this.lbEtiquetaGE = new System.Windows.Forms.Label();
			this.dlgGuardarComo = new System.Windows.Forms.SaveFileDialog();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tcPrincipal.SuspendLayout();
			this.tpComent.SuspendLayout();
			this.tpMI.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tpMV.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tpGeneralMV.SuspendLayout();
			this.tpParamsMV.SuspendLayout();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.tpMC.SuspendLayout();
			this.containerMC.Panel1.SuspendLayout();
			this.containerMC.Panel2.SuspendLayout();
			this.containerMC.SuspendLayout();
			this.toolsMC.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tpGeneralMC.SuspendLayout();
			this.tpParamsMC.SuspendLayout();
			this.containerParamsMC.Panel1.SuspendLayout();
			this.containerParamsMC.Panel2.SuspendLayout();
			this.containerParamsMC.SuspendLayout();
			this.tpME.SuspendLayout();
			this.containerME.Panel1.SuspendLayout();
			this.containerME.Panel2.SuspendLayout();
			this.containerME.SuspendLayout();
			this.toolsME.SuspendLayout();
			this.tabControl4.SuspendLayout();
			this.tpGeneralME.SuspendLayout();
			this.tpParamsME.SuspendLayout();
			this.containerParamsME.Panel1.SuspendLayout();
			this.containerParamsME.Panel2.SuspendLayout();
			this.containerParamsME.SuspendLayout();
			this.tpGC.SuspendLayout();
			this.containerGC.Panel1.SuspendLayout();
			this.containerGC.Panel2.SuspendLayout();
			this.containerGC.SuspendLayout();
			this.toolsGC.SuspendLayout();
			this.tpGE.SuspendLayout();
			this.containerGE.Panel1.SuspendLayout();
			this.containerGE.Panel2.SuspendLayout();
			this.containerGE.SuspendLayout();
			this.toolsGE.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txDesc);
			this.panel1.Controls.Add(this.lbDesc);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(577, 44);
			this.panel1.TabIndex = 0;
			// 
			// txDesc
			// 
			this.txDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDesc.Location = new System.Drawing.Point(0, 13);
			this.txDesc.Name = "txDesc";
			this.txDesc.Size = new System.Drawing.Size(577, 20);
			this.txDesc.TabIndex = 1;
			this.txDesc.TextChanged += new System.EventHandler(this.TxDescTextChanged);
			this.txDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyDown);
			this.txDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyUp);
			// 
			// lbDesc
			// 
			this.lbDesc.AutoSize = true;
			this.lbDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDesc.Location = new System.Drawing.Point(0, 0);
			this.lbDesc.Name = "lbDesc";
			this.lbDesc.Size = new System.Drawing.Size(63, 13);
			this.lbDesc.TabIndex = 0;
			this.lbDesc.Text = "Descripción";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tcPrincipal);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 44);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(577, 410);
			this.panel2.TabIndex = 1;
			// 
			// tcPrincipal
			// 
			this.tcPrincipal.Controls.Add(this.tpComent);
			this.tcPrincipal.Controls.Add(this.tpMI);
			this.tcPrincipal.Controls.Add(this.tpMV);
			this.tcPrincipal.Controls.Add(this.tpMC);
			this.tcPrincipal.Controls.Add(this.tpME);
			this.tcPrincipal.Controls.Add(this.tpGC);
			this.tcPrincipal.Controls.Add(this.tpGE);
			this.tcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcPrincipal.Location = new System.Drawing.Point(0, 0);
			this.tcPrincipal.Name = "tcPrincipal";
			this.tcPrincipal.SelectedIndex = 0;
			this.tcPrincipal.Size = new System.Drawing.Size(577, 410);
			this.tcPrincipal.TabIndex = 0;
			// 
			// tpComent
			// 
			this.tpComent.Controls.Add(this.txComent);
			this.tpComent.Location = new System.Drawing.Point(4, 22);
			this.tpComent.Name = "tpComent";
			this.tpComent.Padding = new System.Windows.Forms.Padding(3);
			this.tpComent.Size = new System.Drawing.Size(569, 384);
			this.tpComent.TabIndex = 0;
			this.tpComent.Text = "Comentarios";
			this.tpComent.UseVisualStyleBackColor = true;
			// 
			// txComent
			// 
			this.txComent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComent.Location = new System.Drawing.Point(3, 3);
			this.txComent.Multiline = true;
			this.txComent.Name = "txComent";
			this.txComent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComent.Size = new System.Drawing.Size(563, 378);
			this.txComent.TabIndex = 0;
			this.txComent.TextChanged += new System.EventHandler(this.TxComentTextChanged);
			this.txComent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxComentKeyDown);
			this.txComent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxComentKeyUp);
			// 
			// tpMI
			// 
			this.tpMI.Controls.Add(this.splitContainer1);
			this.tpMI.Location = new System.Drawing.Point(4, 22);
			this.tpMI.Name = "tpMI";
			this.tpMI.Padding = new System.Windows.Forms.Padding(3);
			this.tpMI.Size = new System.Drawing.Size(569, 384);
			this.tpMI.TabIndex = 1;
			this.tpMI.Text = "Métodos de inicio";
			this.tpMI.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lMI);
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txComentarioMI);
			this.splitContainer1.Panel2.Controls.Add(this.lbComentarioMI);
			this.splitContainer1.Panel2.Controls.Add(this.chAnonimoMI);
			this.splitContainer1.Panel2.Controls.Add(this.txEtiquetaMI);
			this.splitContainer1.Panel2.Controls.Add(this.lbEtiquetaMI);
			this.splitContainer1.Size = new System.Drawing.Size(563, 378);
			this.splitContainer1.SplitterDistance = 223;
			this.splitContainer1.TabIndex = 0;
			// 
			// lMI
			// 
			this.lMI.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lMI.FormattingEnabled = true;
			this.lMI.IntegralHeight = false;
			this.lMI.Location = new System.Drawing.Point(0, 25);
			this.lMI.Name = "lMI";
			this.lMI.Size = new System.Drawing.Size(223, 353);
			this.lMI.TabIndex = 1;
			this.lMI.SelectedIndexChanged += new System.EventHandler(this.LMISelectedIndexChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsNuevoMI,
									this.tsBorrarMI,
									this.tsSubirMI,
									this.tsBajarMI,
									this.tsObsoletoMI,
									this.tsGuardarMI});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(223, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsNuevoMI
			// 
			this.tsNuevoMI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNuevoMI.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevoMI.Image")));
			this.tsNuevoMI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNuevoMI.Name = "tsNuevoMI";
			this.tsNuevoMI.Size = new System.Drawing.Size(23, 22);
			this.tsNuevoMI.Text = "Nuevo";
			this.tsNuevoMI.Click += new System.EventHandler(this.TsNuevoMIClick);
			// 
			// tsBorrarMI
			// 
			this.tsBorrarMI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBorrarMI.Image = ((System.Drawing.Image)(resources.GetObject("tsBorrarMI.Image")));
			this.tsBorrarMI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBorrarMI.Name = "tsBorrarMI";
			this.tsBorrarMI.Size = new System.Drawing.Size(23, 22);
			this.tsBorrarMI.Text = "Borrar";
			this.tsBorrarMI.Click += new System.EventHandler(this.TsBorrarMIClick);
			// 
			// tsSubirMI
			// 
			this.tsSubirMI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsSubirMI.Image = ((System.Drawing.Image)(resources.GetObject("tsSubirMI.Image")));
			this.tsSubirMI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSubirMI.Name = "tsSubirMI";
			this.tsSubirMI.Size = new System.Drawing.Size(23, 22);
			this.tsSubirMI.Text = "Subir";
			this.tsSubirMI.Click += new System.EventHandler(this.TsSubirMIClick);
			// 
			// tsBajarMI
			// 
			this.tsBajarMI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBajarMI.Image = ((System.Drawing.Image)(resources.GetObject("tsBajarMI.Image")));
			this.tsBajarMI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBajarMI.Name = "tsBajarMI";
			this.tsBajarMI.Size = new System.Drawing.Size(23, 22);
			this.tsBajarMI.Text = "Bajar";
			this.tsBajarMI.Click += new System.EventHandler(this.TsBajarMIClick);
			// 
			// tsObsoletoMI
			// 
			this.tsObsoletoMI.CheckOnClick = true;
			this.tsObsoletoMI.Image = ((System.Drawing.Image)(resources.GetObject("tsObsoletoMI.Image")));
			this.tsObsoletoMI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsObsoletoMI.Name = "tsObsoletoMI";
			this.tsObsoletoMI.Size = new System.Drawing.Size(70, 22);
			this.tsObsoletoMI.Text = "Obsoleto";
			this.tsObsoletoMI.ToolTipText = "Marcar como obsoleto";
			this.tsObsoletoMI.CheckedChanged += new System.EventHandler(this.TsObsoletoMICheckedChanged);
			// 
			// tsGuardarMI
			// 
			this.tsGuardarMI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsGuardarMI.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardarMI.Image")));
			this.tsGuardarMI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGuardarMI.Name = "tsGuardarMI";
			this.tsGuardarMI.Size = new System.Drawing.Size(23, 22);
			this.tsGuardarMI.Text = "Guardar como";
			this.tsGuardarMI.Click += new System.EventHandler(this.TsGuardarMIClick);
			// 
			// txComentarioMI
			// 
			this.txComentarioMI.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioMI.Location = new System.Drawing.Point(0, 63);
			this.txComentarioMI.Multiline = true;
			this.txComentarioMI.Name = "txComentarioMI";
			this.txComentarioMI.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioMI.Size = new System.Drawing.Size(336, 315);
			this.txComentarioMI.TabIndex = 6;
			// 
			// lbComentarioMI
			// 
			this.lbComentarioMI.AutoSize = true;
			this.lbComentarioMI.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioMI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioMI.Location = new System.Drawing.Point(0, 50);
			this.lbComentarioMI.Name = "lbComentarioMI";
			this.lbComentarioMI.Size = new System.Drawing.Size(76, 13);
			this.lbComentarioMI.TabIndex = 5;
			this.lbComentarioMI.Text = "Comentario:";
			// 
			// chAnonimoMI
			// 
			this.chAnonimoMI.AutoSize = true;
			this.chAnonimoMI.Dock = System.Windows.Forms.DockStyle.Top;
			this.chAnonimoMI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chAnonimoMI.Location = new System.Drawing.Point(0, 33);
			this.chAnonimoMI.Name = "chAnonimoMI";
			this.chAnonimoMI.Size = new System.Drawing.Size(336, 17);
			this.chAnonimoMI.TabIndex = 4;
			this.chAnonimoMI.Text = "Permite acceso anónimo";
			this.chAnonimoMI.UseVisualStyleBackColor = true;
			// 
			// txEtiquetaMI
			// 
			this.txEtiquetaMI.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaMI.Location = new System.Drawing.Point(0, 13);
			this.txEtiquetaMI.Name = "txEtiquetaMI";
			this.txEtiquetaMI.Size = new System.Drawing.Size(336, 20);
			this.txEtiquetaMI.TabIndex = 1;
			// 
			// lbEtiquetaMI
			// 
			this.lbEtiquetaMI.AutoSize = true;
			this.lbEtiquetaMI.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaMI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaMI.Location = new System.Drawing.Point(0, 0);
			this.lbEtiquetaMI.Name = "lbEtiquetaMI";
			this.lbEtiquetaMI.Size = new System.Drawing.Size(57, 13);
			this.lbEtiquetaMI.TabIndex = 0;
			this.lbEtiquetaMI.Text = "Etiqueta:";
			// 
			// tpMV
			// 
			this.tpMV.Controls.Add(this.splitContainer2);
			this.tpMV.Location = new System.Drawing.Point(4, 22);
			this.tpMV.Name = "tpMV";
			this.tpMV.Size = new System.Drawing.Size(569, 384);
			this.tpMV.TabIndex = 2;
			this.tpMV.Text = "Métodos visibles";
			this.tpMV.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.lMV);
			this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tabControl2);
			this.splitContainer2.Size = new System.Drawing.Size(569, 384);
			this.splitContainer2.SplitterDistance = 223;
			this.splitContainer2.TabIndex = 0;
			// 
			// lMV
			// 
			this.lMV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lMV.FormattingEnabled = true;
			this.lMV.IntegralHeight = false;
			this.lMV.Location = new System.Drawing.Point(0, 25);
			this.lMV.Name = "lMV";
			this.lMV.Size = new System.Drawing.Size(223, 359);
			this.lMV.TabIndex = 1;
			this.lMV.SelectedIndexChanged += new System.EventHandler(this.LMVSelectedIndexChanged);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsNuevoMV,
									this.tsBorrarMV,
									this.tsSubirMV,
									this.tsBajarMV,
									this.tsObsoletoMV,
									this.tsGuardarMV});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(223, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tsNuevoMV
			// 
			this.tsNuevoMV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNuevoMV.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevoMV.Image")));
			this.tsNuevoMV.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNuevoMV.Name = "tsNuevoMV";
			this.tsNuevoMV.Size = new System.Drawing.Size(23, 22);
			this.tsNuevoMV.Text = "Nuevo";
			this.tsNuevoMV.Click += new System.EventHandler(this.TsNuevoMVClick);
			// 
			// tsBorrarMV
			// 
			this.tsBorrarMV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBorrarMV.Image = ((System.Drawing.Image)(resources.GetObject("tsBorrarMV.Image")));
			this.tsBorrarMV.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBorrarMV.Name = "tsBorrarMV";
			this.tsBorrarMV.Size = new System.Drawing.Size(23, 22);
			this.tsBorrarMV.Text = "Borrar";
			this.tsBorrarMV.Click += new System.EventHandler(this.TsBorrarMVClick);
			// 
			// tsSubirMV
			// 
			this.tsSubirMV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsSubirMV.Image = ((System.Drawing.Image)(resources.GetObject("tsSubirMV.Image")));
			this.tsSubirMV.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSubirMV.Name = "tsSubirMV";
			this.tsSubirMV.Size = new System.Drawing.Size(23, 22);
			this.tsSubirMV.Text = "Subir";
			this.tsSubirMV.Click += new System.EventHandler(this.TsSubirMVClick);
			// 
			// tsBajarMV
			// 
			this.tsBajarMV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBajarMV.Image = ((System.Drawing.Image)(resources.GetObject("tsBajarMV.Image")));
			this.tsBajarMV.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBajarMV.Name = "tsBajarMV";
			this.tsBajarMV.Size = new System.Drawing.Size(23, 22);
			this.tsBajarMV.Text = "Bajar";
			this.tsBajarMV.Click += new System.EventHandler(this.TsBajarMVClick);
			// 
			// tsObsoletoMV
			// 
			this.tsObsoletoMV.CheckOnClick = true;
			this.tsObsoletoMV.Image = ((System.Drawing.Image)(resources.GetObject("tsObsoletoMV.Image")));
			this.tsObsoletoMV.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsObsoletoMV.Name = "tsObsoletoMV";
			this.tsObsoletoMV.Size = new System.Drawing.Size(70, 22);
			this.tsObsoletoMV.Text = "Obsoleto";
			this.tsObsoletoMV.ToolTipText = "Marcar como obsoleto";
			this.tsObsoletoMV.CheckedChanged += new System.EventHandler(this.TsObsoletoMVCheckedChanged);
			// 
			// tsGuardarMV
			// 
			this.tsGuardarMV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsGuardarMV.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardarMV.Image")));
			this.tsGuardarMV.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGuardarMV.Name = "tsGuardarMV";
			this.tsGuardarMV.Size = new System.Drawing.Size(23, 22);
			this.tsGuardarMV.Text = "Guardar como";
			this.tsGuardarMV.Click += new System.EventHandler(this.TsGuardarMVClick);
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tpGeneralMV);
			this.tabControl2.Controls.Add(this.tpParamsMV);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(0, 0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(342, 384);
			this.tabControl2.TabIndex = 5;
			// 
			// tpGeneralMV
			// 
			this.tpGeneralMV.Controls.Add(this.txComentarioMV);
			this.tpGeneralMV.Controls.Add(this.lbComentarioMV);
			this.tpGeneralMV.Controls.Add(this.chAnonimoMV);
			this.tpGeneralMV.Controls.Add(this.txEtiquetaMV);
			this.tpGeneralMV.Controls.Add(this.lbEtiquetaMV);
			this.tpGeneralMV.Location = new System.Drawing.Point(4, 22);
			this.tpGeneralMV.Name = "tpGeneralMV";
			this.tpGeneralMV.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneralMV.Size = new System.Drawing.Size(334, 358);
			this.tpGeneralMV.TabIndex = 0;
			this.tpGeneralMV.Text = "General";
			this.tpGeneralMV.UseVisualStyleBackColor = true;
			// 
			// txComentarioMV
			// 
			this.txComentarioMV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioMV.Location = new System.Drawing.Point(3, 71);
			this.txComentarioMV.Multiline = true;
			this.txComentarioMV.Name = "txComentarioMV";
			this.txComentarioMV.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioMV.Size = new System.Drawing.Size(328, 284);
			this.txComentarioMV.TabIndex = 10;
			// 
			// lbComentarioMV
			// 
			this.lbComentarioMV.AutoSize = true;
			this.lbComentarioMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioMV.Location = new System.Drawing.Point(3, 58);
			this.lbComentarioMV.Name = "lbComentarioMV";
			this.lbComentarioMV.Size = new System.Drawing.Size(76, 13);
			this.lbComentarioMV.TabIndex = 9;
			this.lbComentarioMV.Text = "Comentario:";
			// 
			// chAnonimoMV
			// 
			this.chAnonimoMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.chAnonimoMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chAnonimoMV.Location = new System.Drawing.Point(3, 36);
			this.chAnonimoMV.Name = "chAnonimoMV";
			this.chAnonimoMV.Size = new System.Drawing.Size(328, 22);
			this.chAnonimoMV.TabIndex = 8;
			this.chAnonimoMV.Text = "Permite acceso anónimo";
			this.chAnonimoMV.UseVisualStyleBackColor = true;
			// 
			// txEtiquetaMV
			// 
			this.txEtiquetaMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaMV.Location = new System.Drawing.Point(3, 16);
			this.txEtiquetaMV.Name = "txEtiquetaMV";
			this.txEtiquetaMV.Size = new System.Drawing.Size(328, 20);
			this.txEtiquetaMV.TabIndex = 5;
			this.txEtiquetaMV.Validated += new System.EventHandler(this.TxEtiquetaMVValidated);
			// 
			// lbEtiquetaMV
			// 
			this.lbEtiquetaMV.AutoSize = true;
			this.lbEtiquetaMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaMV.Location = new System.Drawing.Point(3, 3);
			this.lbEtiquetaMV.Name = "lbEtiquetaMV";
			this.lbEtiquetaMV.Size = new System.Drawing.Size(57, 13);
			this.lbEtiquetaMV.TabIndex = 4;
			this.lbEtiquetaMV.Text = "Etiqueta:";
			// 
			// tpParamsMV
			// 
			this.tpParamsMV.Controls.Add(this.splitContainer3);
			this.tpParamsMV.Location = new System.Drawing.Point(4, 22);
			this.tpParamsMV.Name = "tpParamsMV";
			this.tpParamsMV.Padding = new System.Windows.Forms.Padding(3);
			this.tpParamsMV.Size = new System.Drawing.Size(334, 358);
			this.tpParamsMV.TabIndex = 1;
			this.tpParamsMV.Text = "Parámetros";
			this.tpParamsMV.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(3, 3);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.lParamsMV);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.txComentarioParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.lbComentarioParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.txMiembroDisplayParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.lbMiembroDisplayParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.txMiembroValorParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.lbMiembroValorParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.txOrigenParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.lbOrigenParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.chNuloParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.txDefaultParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.lbDefaultParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.txEtiquetaParamMV);
			this.splitContainer3.Panel2.Controls.Add(this.lbEtiquetaParamMV);
			this.splitContainer3.Size = new System.Drawing.Size(328, 352);
			this.splitContainer3.SplitterDistance = 112;
			this.splitContainer3.TabIndex = 0;
			// 
			// lParamsMV
			// 
			this.lParamsMV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lParamsMV.FormattingEnabled = true;
			this.lParamsMV.IntegralHeight = false;
			this.lParamsMV.Location = new System.Drawing.Point(0, 0);
			this.lParamsMV.Name = "lParamsMV";
			this.lParamsMV.Size = new System.Drawing.Size(112, 352);
			this.lParamsMV.TabIndex = 0;
			this.lParamsMV.SelectedIndexChanged += new System.EventHandler(this.LParamsMVSelectedIndexChanged);
			// 
			// txComentarioParamMV
			// 
			this.txComentarioParamMV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioParamMV.Location = new System.Drawing.Point(0, 195);
			this.txComentarioParamMV.Multiline = true;
			this.txComentarioParamMV.Name = "txComentarioParamMV";
			this.txComentarioParamMV.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioParamMV.Size = new System.Drawing.Size(212, 157);
			this.txComentarioParamMV.TabIndex = 45;
			// 
			// lbComentarioParamMV
			// 
			this.lbComentarioParamMV.AutoSize = true;
			this.lbComentarioParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioParamMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioParamMV.Location = new System.Drawing.Point(0, 182);
			this.lbComentarioParamMV.Name = "lbComentarioParamMV";
			this.lbComentarioParamMV.Size = new System.Drawing.Size(160, 13);
			this.lbComentarioParamMV.TabIndex = 44;
			this.lbComentarioParamMV.Text = "Comentario del parámetro:";
			// 
			// txMiembroDisplayParamMV
			// 
			this.txMiembroDisplayParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.txMiembroDisplayParamMV.Location = new System.Drawing.Point(0, 162);
			this.txMiembroDisplayParamMV.Name = "txMiembroDisplayParamMV";
			this.txMiembroDisplayParamMV.Size = new System.Drawing.Size(212, 20);
			this.txMiembroDisplayParamMV.TabIndex = 43;
			// 
			// lbMiembroDisplayParamMV
			// 
			this.lbMiembroDisplayParamMV.AutoSize = true;
			this.lbMiembroDisplayParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMiembroDisplayParamMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMiembroDisplayParamMV.Location = new System.Drawing.Point(0, 149);
			this.lbMiembroDisplayParamMV.Name = "lbMiembroDisplayParamMV";
			this.lbMiembroDisplayParamMV.Size = new System.Drawing.Size(92, 13);
			this.lbMiembroDisplayParamMV.TabIndex = 42;
			this.lbMiembroDisplayParamMV.Text = "Campo display:";
			// 
			// txMiembroValorParamMV
			// 
			this.txMiembroValorParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.txMiembroValorParamMV.Location = new System.Drawing.Point(0, 129);
			this.txMiembroValorParamMV.Name = "txMiembroValorParamMV";
			this.txMiembroValorParamMV.Size = new System.Drawing.Size(212, 20);
			this.txMiembroValorParamMV.TabIndex = 41;
			// 
			// lbMiembroValorParamMV
			// 
			this.lbMiembroValorParamMV.AutoSize = true;
			this.lbMiembroValorParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMiembroValorParamMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMiembroValorParamMV.Location = new System.Drawing.Point(0, 116);
			this.lbMiembroValorParamMV.Name = "lbMiembroValorParamMV";
			this.lbMiembroValorParamMV.Size = new System.Drawing.Size(81, 13);
			this.lbMiembroValorParamMV.TabIndex = 40;
			this.lbMiembroValorParamMV.Text = "Campo valor:";
			// 
			// txOrigenParamMV
			// 
			this.txOrigenParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.txOrigenParamMV.Location = new System.Drawing.Point(0, 96);
			this.txOrigenParamMV.Name = "txOrigenParamMV";
			this.txOrigenParamMV.Size = new System.Drawing.Size(212, 20);
			this.txOrigenParamMV.TabIndex = 34;
			// 
			// lbOrigenParamMV
			// 
			this.lbOrigenParamMV.AutoSize = true;
			this.lbOrigenParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbOrigenParamMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbOrigenParamMV.Location = new System.Drawing.Point(0, 83);
			this.lbOrigenParamMV.Name = "lbOrigenParamMV";
			this.lbOrigenParamMV.Size = new System.Drawing.Size(47, 13);
			this.lbOrigenParamMV.TabIndex = 33;
			this.lbOrigenParamMV.Text = "Origen:";
			// 
			// chNuloParamMV
			// 
			this.chNuloParamMV.AutoSize = true;
			this.chNuloParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.chNuloParamMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chNuloParamMV.Location = new System.Drawing.Point(0, 66);
			this.chNuloParamMV.Name = "chNuloParamMV";
			this.chNuloParamMV.Size = new System.Drawing.Size(212, 17);
			this.chNuloParamMV.TabIndex = 32;
			this.chNuloParamMV.Text = "Permite valor nulo";
			this.chNuloParamMV.UseVisualStyleBackColor = true;
			// 
			// txDefaultParamMV
			// 
			this.txDefaultParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDefaultParamMV.Location = new System.Drawing.Point(0, 46);
			this.txDefaultParamMV.Name = "txDefaultParamMV";
			this.txDefaultParamMV.Size = new System.Drawing.Size(212, 20);
			this.txDefaultParamMV.TabIndex = 16;
			// 
			// lbDefaultParamMV
			// 
			this.lbDefaultParamMV.AutoSize = true;
			this.lbDefaultParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDefaultParamMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbDefaultParamMV.Location = new System.Drawing.Point(0, 33);
			this.lbDefaultParamMV.Name = "lbDefaultParamMV";
			this.lbDefaultParamMV.Size = new System.Drawing.Size(107, 13);
			this.lbDefaultParamMV.TabIndex = 15;
			this.lbDefaultParamMV.Text = "Valor por defecto:";
			// 
			// txEtiquetaParamMV
			// 
			this.txEtiquetaParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaParamMV.Location = new System.Drawing.Point(0, 13);
			this.txEtiquetaParamMV.Name = "txEtiquetaParamMV";
			this.txEtiquetaParamMV.Size = new System.Drawing.Size(212, 20);
			this.txEtiquetaParamMV.TabIndex = 5;
			// 
			// lbEtiquetaParamMV
			// 
			this.lbEtiquetaParamMV.AutoSize = true;
			this.lbEtiquetaParamMV.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaParamMV.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaParamMV.Location = new System.Drawing.Point(0, 0);
			this.lbEtiquetaParamMV.Name = "lbEtiquetaParamMV";
			this.lbEtiquetaParamMV.Size = new System.Drawing.Size(141, 13);
			this.lbEtiquetaParamMV.TabIndex = 4;
			this.lbEtiquetaParamMV.Text = "Etiqueta del parámetro:";
			// 
			// tpMC
			// 
			this.tpMC.Controls.Add(this.containerMC);
			this.tpMC.Location = new System.Drawing.Point(4, 22);
			this.tpMC.Name = "tpMC";
			this.tpMC.Size = new System.Drawing.Size(569, 384);
			this.tpMC.TabIndex = 3;
			this.tpMC.Text = "Métodos comunes";
			this.tpMC.UseVisualStyleBackColor = true;
			// 
			// containerMC
			// 
			this.containerMC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerMC.Location = new System.Drawing.Point(0, 0);
			this.containerMC.Name = "containerMC";
			// 
			// containerMC.Panel1
			// 
			this.containerMC.Panel1.Controls.Add(this.lMC);
			this.containerMC.Panel1.Controls.Add(this.lbMC);
			this.containerMC.Panel1.Controls.Add(this.cGC);
			this.containerMC.Panel1.Controls.Add(this.lbGC);
			this.containerMC.Panel1.Controls.Add(this.toolsMC);
			// 
			// containerMC.Panel2
			// 
			this.containerMC.Panel2.Controls.Add(this.tabControl3);
			this.containerMC.Size = new System.Drawing.Size(569, 384);
			this.containerMC.SplitterDistance = 232;
			this.containerMC.TabIndex = 0;
			// 
			// lMC
			// 
			this.lMC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lMC.FormattingEnabled = true;
			this.lMC.IntegralHeight = false;
			this.lMC.Location = new System.Drawing.Point(0, 72);
			this.lMC.Name = "lMC";
			this.lMC.Size = new System.Drawing.Size(232, 312);
			this.lMC.TabIndex = 2;
			this.lMC.SelectedIndexChanged += new System.EventHandler(this.LMCSelectedIndexChanged);
			// 
			// lbMC
			// 
			this.lbMC.AutoSize = true;
			this.lbMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMC.Location = new System.Drawing.Point(0, 59);
			this.lbMC.Name = "lbMC";
			this.lbMC.Size = new System.Drawing.Size(106, 13);
			this.lbMC.TabIndex = 0;
			this.lbMC.Text = "Métodos disponibles:";
			// 
			// cGC
			// 
			this.cGC.Dock = System.Windows.Forms.DockStyle.Top;
			this.cGC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cGC.FormattingEnabled = true;
			this.cGC.Location = new System.Drawing.Point(0, 38);
			this.cGC.Name = "cGC";
			this.cGC.Size = new System.Drawing.Size(232, 21);
			this.cGC.TabIndex = 0;
			this.cGC.SelectedIndexChanged += new System.EventHandler(this.CGCSelectedIndexChanged);
			// 
			// lbGC
			// 
			this.lbGC.AutoSize = true;
			this.lbGC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbGC.Location = new System.Drawing.Point(0, 25);
			this.lbGC.Name = "lbGC";
			this.lbGC.Size = new System.Drawing.Size(71, 13);
			this.lbGC.TabIndex = 0;
			this.lbGC.Text = "Grupo actual:";
			// 
			// toolsMC
			// 
			this.toolsMC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsNuevoMC,
									this.tsBorrarMC,
									this.tsSubirMC,
									this.tsBajarMC,
									this.tsMoverMC,
									this.tsObsoletoMC,
									this.tsGuardarMC});
			this.toolsMC.Location = new System.Drawing.Point(0, 0);
			this.toolsMC.Name = "toolsMC";
			this.toolsMC.Size = new System.Drawing.Size(232, 25);
			this.toolsMC.TabIndex = 0;
			this.toolsMC.Text = "toolStrip7";
			// 
			// tsNuevoMC
			// 
			this.tsNuevoMC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNuevoMC.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevoMC.Image")));
			this.tsNuevoMC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNuevoMC.Name = "tsNuevoMC";
			this.tsNuevoMC.Size = new System.Drawing.Size(23, 22);
			this.tsNuevoMC.Text = "Nuevo";
			this.tsNuevoMC.Click += new System.EventHandler(this.TsNuevoMCClick);
			// 
			// tsBorrarMC
			// 
			this.tsBorrarMC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBorrarMC.Image = ((System.Drawing.Image)(resources.GetObject("tsBorrarMC.Image")));
			this.tsBorrarMC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBorrarMC.Name = "tsBorrarMC";
			this.tsBorrarMC.Size = new System.Drawing.Size(23, 22);
			this.tsBorrarMC.Text = "Borrar";
			this.tsBorrarMC.Click += new System.EventHandler(this.TsBorrarMCClick);
			// 
			// tsSubirMC
			// 
			this.tsSubirMC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsSubirMC.Image = ((System.Drawing.Image)(resources.GetObject("tsSubirMC.Image")));
			this.tsSubirMC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSubirMC.Name = "tsSubirMC";
			this.tsSubirMC.Size = new System.Drawing.Size(23, 22);
			this.tsSubirMC.Text = "Subir";
			this.tsSubirMC.Click += new System.EventHandler(this.TsSubirMCClick);
			// 
			// tsBajarMC
			// 
			this.tsBajarMC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBajarMC.Image = ((System.Drawing.Image)(resources.GetObject("tsBajarMC.Image")));
			this.tsBajarMC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBajarMC.Name = "tsBajarMC";
			this.tsBajarMC.Size = new System.Drawing.Size(23, 22);
			this.tsBajarMC.Text = "Bajar";
			this.tsBajarMC.Click += new System.EventHandler(this.TsBajarMCClick);
			// 
			// tsMoverMC
			// 
			this.tsMoverMC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsMoverMC.Image = ((System.Drawing.Image)(resources.GetObject("tsMoverMC.Image")));
			this.tsMoverMC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsMoverMC.Name = "tsMoverMC";
			this.tsMoverMC.Size = new System.Drawing.Size(23, 22);
			this.tsMoverMC.Text = "Mover";
			this.tsMoverMC.ToolTipText = "Mover a otro grupo";
			this.tsMoverMC.Click += new System.EventHandler(this.TsMoverMCClick);
			// 
			// tsObsoletoMC
			// 
			this.tsObsoletoMC.CheckOnClick = true;
			this.tsObsoletoMC.Image = ((System.Drawing.Image)(resources.GetObject("tsObsoletoMC.Image")));
			this.tsObsoletoMC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsObsoletoMC.Name = "tsObsoletoMC";
			this.tsObsoletoMC.Size = new System.Drawing.Size(70, 22);
			this.tsObsoletoMC.Text = "Obsoleto";
			this.tsObsoletoMC.ToolTipText = "Marcar como obsoleto";
			this.tsObsoletoMC.CheckedChanged += new System.EventHandler(this.TsObsoletoMCCheckedChanged);
			// 
			// tsGuardarMC
			// 
			this.tsGuardarMC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsGuardarMC.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardarMC.Image")));
			this.tsGuardarMC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGuardarMC.Name = "tsGuardarMC";
			this.tsGuardarMC.Size = new System.Drawing.Size(23, 22);
			this.tsGuardarMC.Text = "Guardar";
			this.tsGuardarMC.Click += new System.EventHandler(this.TsGuardarMCClick);
			// 
			// tabControl3
			// 
			this.tabControl3.Controls.Add(this.tpGeneralMC);
			this.tabControl3.Controls.Add(this.tpParamsMC);
			this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl3.Location = new System.Drawing.Point(0, 0);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(333, 384);
			this.tabControl3.TabIndex = 0;
			// 
			// tpGeneralMC
			// 
			this.tpGeneralMC.Controls.Add(this.txComentarioMC);
			this.tpGeneralMC.Controls.Add(this.lbComentarioMC);
			this.tpGeneralMC.Controls.Add(this.txEtiquetaMC);
			this.tpGeneralMC.Controls.Add(this.lbEtiquetaMC);
			this.tpGeneralMC.Location = new System.Drawing.Point(4, 22);
			this.tpGeneralMC.Name = "tpGeneralMC";
			this.tpGeneralMC.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneralMC.Size = new System.Drawing.Size(325, 358);
			this.tpGeneralMC.TabIndex = 0;
			this.tpGeneralMC.Text = "General";
			this.tpGeneralMC.UseVisualStyleBackColor = true;
			// 
			// txComentarioMC
			// 
			this.txComentarioMC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioMC.Location = new System.Drawing.Point(3, 49);
			this.txComentarioMC.Multiline = true;
			this.txComentarioMC.Name = "txComentarioMC";
			this.txComentarioMC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioMC.Size = new System.Drawing.Size(319, 306);
			this.txComentarioMC.TabIndex = 3;
			// 
			// lbComentarioMC
			// 
			this.lbComentarioMC.AutoSize = true;
			this.lbComentarioMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioMC.Location = new System.Drawing.Point(3, 36);
			this.lbComentarioMC.Name = "lbComentarioMC";
			this.lbComentarioMC.Size = new System.Drawing.Size(76, 13);
			this.lbComentarioMC.TabIndex = 2;
			this.lbComentarioMC.Text = "Comentario:";
			// 
			// txEtiquetaMC
			// 
			this.txEtiquetaMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaMC.Location = new System.Drawing.Point(3, 16);
			this.txEtiquetaMC.Name = "txEtiquetaMC";
			this.txEtiquetaMC.Size = new System.Drawing.Size(319, 20);
			this.txEtiquetaMC.TabIndex = 1;
			this.txEtiquetaMC.Validated += new System.EventHandler(this.TxEtiquetaMCValidated);
			// 
			// lbEtiquetaMC
			// 
			this.lbEtiquetaMC.AutoSize = true;
			this.lbEtiquetaMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaMC.Location = new System.Drawing.Point(3, 3);
			this.lbEtiquetaMC.Name = "lbEtiquetaMC";
			this.lbEtiquetaMC.Size = new System.Drawing.Size(57, 13);
			this.lbEtiquetaMC.TabIndex = 0;
			this.lbEtiquetaMC.Text = "Etiqueta:";
			// 
			// tpParamsMC
			// 
			this.tpParamsMC.Controls.Add(this.containerParamsMC);
			this.tpParamsMC.Location = new System.Drawing.Point(4, 22);
			this.tpParamsMC.Name = "tpParamsMC";
			this.tpParamsMC.Padding = new System.Windows.Forms.Padding(3);
			this.tpParamsMC.Size = new System.Drawing.Size(325, 358);
			this.tpParamsMC.TabIndex = 1;
			this.tpParamsMC.Text = "Parámetros";
			this.tpParamsMC.UseVisualStyleBackColor = true;
			// 
			// containerParamsMC
			// 
			this.containerParamsMC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerParamsMC.Location = new System.Drawing.Point(3, 3);
			this.containerParamsMC.Name = "containerParamsMC";
			// 
			// containerParamsMC.Panel1
			// 
			this.containerParamsMC.Panel1.Controls.Add(this.lParamsMC);
			// 
			// containerParamsMC.Panel2
			// 
			this.containerParamsMC.Panel2.Controls.Add(this.txComentarioParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.lbComentarioParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.txMiembroDisplayParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.lbMiembroDisplayParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.txMiembroValorParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.lbMiembroValorParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.txOrigenParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.lbOrigenParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.chNuloParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.txDefaultParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.lbDefaultParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.txEtiquetaParamMC);
			this.containerParamsMC.Panel2.Controls.Add(this.lbEtiquetaParamMC);
			this.containerParamsMC.Size = new System.Drawing.Size(319, 352);
			this.containerParamsMC.SplitterDistance = 105;
			this.containerParamsMC.TabIndex = 0;
			// 
			// lParamsMC
			// 
			this.lParamsMC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lParamsMC.FormattingEnabled = true;
			this.lParamsMC.IntegralHeight = false;
			this.lParamsMC.Location = new System.Drawing.Point(0, 0);
			this.lParamsMC.Name = "lParamsMC";
			this.lParamsMC.Size = new System.Drawing.Size(105, 352);
			this.lParamsMC.TabIndex = 1;
			this.lParamsMC.SelectedIndexChanged += new System.EventHandler(this.LParamsMCSelectedIndexChanged);
			// 
			// txComentarioParamMC
			// 
			this.txComentarioParamMC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioParamMC.Location = new System.Drawing.Point(0, 195);
			this.txComentarioParamMC.Multiline = true;
			this.txComentarioParamMC.Name = "txComentarioParamMC";
			this.txComentarioParamMC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioParamMC.Size = new System.Drawing.Size(210, 157);
			this.txComentarioParamMC.TabIndex = 58;
			// 
			// lbComentarioParamMC
			// 
			this.lbComentarioParamMC.AutoSize = true;
			this.lbComentarioParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioParamMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioParamMC.Location = new System.Drawing.Point(0, 182);
			this.lbComentarioParamMC.Name = "lbComentarioParamMC";
			this.lbComentarioParamMC.Size = new System.Drawing.Size(160, 13);
			this.lbComentarioParamMC.TabIndex = 57;
			this.lbComentarioParamMC.Text = "Comentario del parámetro:";
			// 
			// txMiembroDisplayParamMC
			// 
			this.txMiembroDisplayParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.txMiembroDisplayParamMC.Location = new System.Drawing.Point(0, 162);
			this.txMiembroDisplayParamMC.Name = "txMiembroDisplayParamMC";
			this.txMiembroDisplayParamMC.Size = new System.Drawing.Size(210, 20);
			this.txMiembroDisplayParamMC.TabIndex = 56;
			// 
			// lbMiembroDisplayParamMC
			// 
			this.lbMiembroDisplayParamMC.AutoSize = true;
			this.lbMiembroDisplayParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMiembroDisplayParamMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMiembroDisplayParamMC.Location = new System.Drawing.Point(0, 149);
			this.lbMiembroDisplayParamMC.Name = "lbMiembroDisplayParamMC";
			this.lbMiembroDisplayParamMC.Size = new System.Drawing.Size(92, 13);
			this.lbMiembroDisplayParamMC.TabIndex = 55;
			this.lbMiembroDisplayParamMC.Text = "Campo display:";
			// 
			// txMiembroValorParamMC
			// 
			this.txMiembroValorParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.txMiembroValorParamMC.Location = new System.Drawing.Point(0, 129);
			this.txMiembroValorParamMC.Name = "txMiembroValorParamMC";
			this.txMiembroValorParamMC.Size = new System.Drawing.Size(210, 20);
			this.txMiembroValorParamMC.TabIndex = 54;
			// 
			// lbMiembroValorParamMC
			// 
			this.lbMiembroValorParamMC.AutoSize = true;
			this.lbMiembroValorParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMiembroValorParamMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMiembroValorParamMC.Location = new System.Drawing.Point(0, 116);
			this.lbMiembroValorParamMC.Name = "lbMiembroValorParamMC";
			this.lbMiembroValorParamMC.Size = new System.Drawing.Size(81, 13);
			this.lbMiembroValorParamMC.TabIndex = 53;
			this.lbMiembroValorParamMC.Text = "Campo valor:";
			// 
			// txOrigenParamMC
			// 
			this.txOrigenParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.txOrigenParamMC.Location = new System.Drawing.Point(0, 96);
			this.txOrigenParamMC.Name = "txOrigenParamMC";
			this.txOrigenParamMC.Size = new System.Drawing.Size(210, 20);
			this.txOrigenParamMC.TabIndex = 52;
			// 
			// lbOrigenParamMC
			// 
			this.lbOrigenParamMC.AutoSize = true;
			this.lbOrigenParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbOrigenParamMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbOrigenParamMC.Location = new System.Drawing.Point(0, 83);
			this.lbOrigenParamMC.Name = "lbOrigenParamMC";
			this.lbOrigenParamMC.Size = new System.Drawing.Size(47, 13);
			this.lbOrigenParamMC.TabIndex = 51;
			this.lbOrigenParamMC.Text = "Origen:";
			// 
			// chNuloParamMC
			// 
			this.chNuloParamMC.AutoSize = true;
			this.chNuloParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.chNuloParamMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chNuloParamMC.Location = new System.Drawing.Point(0, 66);
			this.chNuloParamMC.Name = "chNuloParamMC";
			this.chNuloParamMC.Size = new System.Drawing.Size(210, 17);
			this.chNuloParamMC.TabIndex = 50;
			this.chNuloParamMC.Text = "Permite valor nulo";
			this.chNuloParamMC.UseVisualStyleBackColor = true;
			// 
			// txDefaultParamMC
			// 
			this.txDefaultParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDefaultParamMC.Location = new System.Drawing.Point(0, 46);
			this.txDefaultParamMC.Name = "txDefaultParamMC";
			this.txDefaultParamMC.Size = new System.Drawing.Size(210, 20);
			this.txDefaultParamMC.TabIndex = 49;
			// 
			// lbDefaultParamMC
			// 
			this.lbDefaultParamMC.AutoSize = true;
			this.lbDefaultParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDefaultParamMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbDefaultParamMC.Location = new System.Drawing.Point(0, 33);
			this.lbDefaultParamMC.Name = "lbDefaultParamMC";
			this.lbDefaultParamMC.Size = new System.Drawing.Size(107, 13);
			this.lbDefaultParamMC.TabIndex = 48;
			this.lbDefaultParamMC.Text = "Valor por defecto:";
			// 
			// txEtiquetaParamMC
			// 
			this.txEtiquetaParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaParamMC.Location = new System.Drawing.Point(0, 13);
			this.txEtiquetaParamMC.Name = "txEtiquetaParamMC";
			this.txEtiquetaParamMC.Size = new System.Drawing.Size(210, 20);
			this.txEtiquetaParamMC.TabIndex = 47;
			// 
			// lbEtiquetaParamMC
			// 
			this.lbEtiquetaParamMC.AutoSize = true;
			this.lbEtiquetaParamMC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaParamMC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaParamMC.Location = new System.Drawing.Point(0, 0);
			this.lbEtiquetaParamMC.Name = "lbEtiquetaParamMC";
			this.lbEtiquetaParamMC.Size = new System.Drawing.Size(141, 13);
			this.lbEtiquetaParamMC.TabIndex = 46;
			this.lbEtiquetaParamMC.Text = "Etiqueta del parámetro:";
			// 
			// tpME
			// 
			this.tpME.Controls.Add(this.containerME);
			this.tpME.Location = new System.Drawing.Point(4, 22);
			this.tpME.Name = "tpME";
			this.tpME.Size = new System.Drawing.Size(569, 384);
			this.tpME.TabIndex = 4;
			this.tpME.Text = "Métodos específicos";
			this.tpME.UseVisualStyleBackColor = true;
			// 
			// containerME
			// 
			this.containerME.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerME.Location = new System.Drawing.Point(0, 0);
			this.containerME.Name = "containerME";
			// 
			// containerME.Panel1
			// 
			this.containerME.Panel1.Controls.Add(this.lME);
			this.containerME.Panel1.Controls.Add(this.lbME);
			this.containerME.Panel1.Controls.Add(this.cGE);
			this.containerME.Panel1.Controls.Add(this.lbGE);
			this.containerME.Panel1.Controls.Add(this.toolsME);
			// 
			// containerME.Panel2
			// 
			this.containerME.Panel2.Controls.Add(this.tabControl4);
			this.containerME.Size = new System.Drawing.Size(569, 384);
			this.containerME.SplitterDistance = 232;
			this.containerME.TabIndex = 0;
			// 
			// lME
			// 
			this.lME.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lME.FormattingEnabled = true;
			this.lME.IntegralHeight = false;
			this.lME.Location = new System.Drawing.Point(0, 72);
			this.lME.Name = "lME";
			this.lME.Size = new System.Drawing.Size(232, 312);
			this.lME.TabIndex = 6;
			this.lME.SelectedIndexChanged += new System.EventHandler(this.LMESelectedIndexChanged);
			// 
			// lbME
			// 
			this.lbME.AutoSize = true;
			this.lbME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbME.Location = new System.Drawing.Point(0, 59);
			this.lbME.Name = "lbME";
			this.lbME.Size = new System.Drawing.Size(106, 13);
			this.lbME.TabIndex = 5;
			this.lbME.Text = "Métodos disponibles:";
			// 
			// cGE
			// 
			this.cGE.Dock = System.Windows.Forms.DockStyle.Top;
			this.cGE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cGE.FormattingEnabled = true;
			this.cGE.Location = new System.Drawing.Point(0, 38);
			this.cGE.Name = "cGE";
			this.cGE.Size = new System.Drawing.Size(232, 21);
			this.cGE.TabIndex = 4;
			this.cGE.SelectedIndexChanged += new System.EventHandler(this.CGESelectedIndexChanged);
			// 
			// lbGE
			// 
			this.lbGE.AutoSize = true;
			this.lbGE.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbGE.Location = new System.Drawing.Point(0, 25);
			this.lbGE.Name = "lbGE";
			this.lbGE.Size = new System.Drawing.Size(71, 13);
			this.lbGE.TabIndex = 3;
			this.lbGE.Text = "Grupo actual:";
			// 
			// toolsME
			// 
			this.toolsME.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsNuevoME,
									this.tsBorrarME,
									this.tsSubirME,
									this.tsBajarME,
									this.tsMoverME,
									this.tsObsoletoME,
									this.tsGuardarME});
			this.toolsME.Location = new System.Drawing.Point(0, 0);
			this.toolsME.Name = "toolsME";
			this.toolsME.Size = new System.Drawing.Size(232, 25);
			this.toolsME.TabIndex = 0;
			this.toolsME.Text = "toolStrip4";
			// 
			// tsNuevoME
			// 
			this.tsNuevoME.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNuevoME.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevoME.Image")));
			this.tsNuevoME.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNuevoME.Name = "tsNuevoME";
			this.tsNuevoME.Size = new System.Drawing.Size(23, 22);
			this.tsNuevoME.Text = "Nuevo";
			this.tsNuevoME.Click += new System.EventHandler(this.TsNuevoMEClick);
			// 
			// tsBorrarME
			// 
			this.tsBorrarME.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBorrarME.Image = ((System.Drawing.Image)(resources.GetObject("tsBorrarME.Image")));
			this.tsBorrarME.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBorrarME.Name = "tsBorrarME";
			this.tsBorrarME.Size = new System.Drawing.Size(23, 22);
			this.tsBorrarME.Text = "Borrar";
			this.tsBorrarME.Click += new System.EventHandler(this.TsBorrarMEClick);
			// 
			// tsSubirME
			// 
			this.tsSubirME.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsSubirME.Image = ((System.Drawing.Image)(resources.GetObject("tsSubirME.Image")));
			this.tsSubirME.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSubirME.Name = "tsSubirME";
			this.tsSubirME.Size = new System.Drawing.Size(23, 22);
			this.tsSubirME.Text = "Subir";
			this.tsSubirME.Click += new System.EventHandler(this.TsSubirMEClick);
			// 
			// tsBajarME
			// 
			this.tsBajarME.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBajarME.Image = ((System.Drawing.Image)(resources.GetObject("tsBajarME.Image")));
			this.tsBajarME.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBajarME.Name = "tsBajarME";
			this.tsBajarME.Size = new System.Drawing.Size(23, 22);
			this.tsBajarME.Text = "Bajar";
			this.tsBajarME.Click += new System.EventHandler(this.TsBajarMEClick);
			// 
			// tsMoverME
			// 
			this.tsMoverME.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsMoverME.Image = ((System.Drawing.Image)(resources.GetObject("tsMoverME.Image")));
			this.tsMoverME.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsMoverME.Name = "tsMoverME";
			this.tsMoverME.Size = new System.Drawing.Size(23, 22);
			this.tsMoverME.Text = "Mover";
			this.tsMoverME.ToolTipText = "Mover a otro grupo";
			this.tsMoverME.Click += new System.EventHandler(this.TsMoverMEClick);
			// 
			// tsObsoletoME
			// 
			this.tsObsoletoME.Image = ((System.Drawing.Image)(resources.GetObject("tsObsoletoME.Image")));
			this.tsObsoletoME.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsObsoletoME.Name = "tsObsoletoME";
			this.tsObsoletoME.Size = new System.Drawing.Size(70, 22);
			this.tsObsoletoME.Text = "Obsoleto";
			this.tsObsoletoME.ToolTipText = "Marcar como obsoleto";
			this.tsObsoletoME.CheckedChanged += new System.EventHandler(this.TsObsoletoMECheckedChanged);
			// 
			// tsGuardarME
			// 
			this.tsGuardarME.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsGuardarME.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardarME.Image")));
			this.tsGuardarME.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGuardarME.Name = "tsGuardarME";
			this.tsGuardarME.Size = new System.Drawing.Size(23, 22);
			this.tsGuardarME.Text = "Guardar";
			this.tsGuardarME.Click += new System.EventHandler(this.TsGuardarMEClick);
			// 
			// tabControl4
			// 
			this.tabControl4.Controls.Add(this.tpGeneralME);
			this.tabControl4.Controls.Add(this.tpParamsME);
			this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl4.Location = new System.Drawing.Point(0, 0);
			this.tabControl4.Name = "tabControl4";
			this.tabControl4.SelectedIndex = 0;
			this.tabControl4.Size = new System.Drawing.Size(333, 384);
			this.tabControl4.TabIndex = 0;
			// 
			// tpGeneralME
			// 
			this.tpGeneralME.Controls.Add(this.txComentarioME);
			this.tpGeneralME.Controls.Add(this.lbComentarioME);
			this.tpGeneralME.Controls.Add(this.txEtiquetaME);
			this.tpGeneralME.Controls.Add(this.lbEtiquetaME);
			this.tpGeneralME.Location = new System.Drawing.Point(4, 22);
			this.tpGeneralME.Name = "tpGeneralME";
			this.tpGeneralME.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneralME.Size = new System.Drawing.Size(325, 358);
			this.tpGeneralME.TabIndex = 0;
			this.tpGeneralME.Text = "General";
			this.tpGeneralME.UseVisualStyleBackColor = true;
			// 
			// txComentarioME
			// 
			this.txComentarioME.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioME.Location = new System.Drawing.Point(3, 49);
			this.txComentarioME.Multiline = true;
			this.txComentarioME.Name = "txComentarioME";
			this.txComentarioME.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioME.Size = new System.Drawing.Size(319, 306);
			this.txComentarioME.TabIndex = 3;
			// 
			// lbComentarioME
			// 
			this.lbComentarioME.AutoSize = true;
			this.lbComentarioME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioME.Location = new System.Drawing.Point(3, 36);
			this.lbComentarioME.Name = "lbComentarioME";
			this.lbComentarioME.Size = new System.Drawing.Size(76, 13);
			this.lbComentarioME.TabIndex = 2;
			this.lbComentarioME.Text = "Comentario:";
			// 
			// txEtiquetaME
			// 
			this.txEtiquetaME.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaME.Location = new System.Drawing.Point(3, 16);
			this.txEtiquetaME.Name = "txEtiquetaME";
			this.txEtiquetaME.Size = new System.Drawing.Size(319, 20);
			this.txEtiquetaME.TabIndex = 1;
			this.txEtiquetaME.Validated += new System.EventHandler(this.TxEtiquetaMEValidated);
			// 
			// lbEtiquetaME
			// 
			this.lbEtiquetaME.AutoSize = true;
			this.lbEtiquetaME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaME.Location = new System.Drawing.Point(3, 3);
			this.lbEtiquetaME.Name = "lbEtiquetaME";
			this.lbEtiquetaME.Size = new System.Drawing.Size(57, 13);
			this.lbEtiquetaME.TabIndex = 0;
			this.lbEtiquetaME.Text = "Etiqueta:";
			// 
			// tpParamsME
			// 
			this.tpParamsME.Controls.Add(this.containerParamsME);
			this.tpParamsME.Location = new System.Drawing.Point(4, 22);
			this.tpParamsME.Name = "tpParamsME";
			this.tpParamsME.Padding = new System.Windows.Forms.Padding(3);
			this.tpParamsME.Size = new System.Drawing.Size(325, 358);
			this.tpParamsME.TabIndex = 1;
			this.tpParamsME.Text = "Parámetros";
			this.tpParamsME.UseVisualStyleBackColor = true;
			// 
			// containerParamsME
			// 
			this.containerParamsME.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerParamsME.Location = new System.Drawing.Point(3, 3);
			this.containerParamsME.Name = "containerParamsME";
			// 
			// containerParamsME.Panel1
			// 
			this.containerParamsME.Panel1.Controls.Add(this.lParamsME);
			// 
			// containerParamsME.Panel2
			// 
			this.containerParamsME.Panel2.Controls.Add(this.txComentarioParamME);
			this.containerParamsME.Panel2.Controls.Add(this.lbComentarioParamME);
			this.containerParamsME.Panel2.Controls.Add(this.txMiembroDisplayParamME);
			this.containerParamsME.Panel2.Controls.Add(this.lbMiembroDisplayParamME);
			this.containerParamsME.Panel2.Controls.Add(this.txMiembroValorParamME);
			this.containerParamsME.Panel2.Controls.Add(this.lbMiembroValorParamME);
			this.containerParamsME.Panel2.Controls.Add(this.txOrigenParamME);
			this.containerParamsME.Panel2.Controls.Add(this.lbOrigenParamME);
			this.containerParamsME.Panel2.Controls.Add(this.chNuloParamME);
			this.containerParamsME.Panel2.Controls.Add(this.txDefaultParamME);
			this.containerParamsME.Panel2.Controls.Add(this.lbDefaultParamME);
			this.containerParamsME.Panel2.Controls.Add(this.txEtiquetaParamME);
			this.containerParamsME.Panel2.Controls.Add(this.lbEtiquetaParamME);
			this.containerParamsME.Size = new System.Drawing.Size(319, 352);
			this.containerParamsME.SplitterDistance = 105;
			this.containerParamsME.TabIndex = 0;
			// 
			// lParamsME
			// 
			this.lParamsME.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lParamsME.FormattingEnabled = true;
			this.lParamsME.IntegralHeight = false;
			this.lParamsME.Location = new System.Drawing.Point(0, 0);
			this.lParamsME.Name = "lParamsME";
			this.lParamsME.Size = new System.Drawing.Size(105, 352);
			this.lParamsME.TabIndex = 1;
			this.lParamsME.SelectedIndexChanged += new System.EventHandler(this.LParamsMESelectedIndexChanged);
			// 
			// txComentarioParamME
			// 
			this.txComentarioParamME.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioParamME.Location = new System.Drawing.Point(0, 195);
			this.txComentarioParamME.Multiline = true;
			this.txComentarioParamME.Name = "txComentarioParamME";
			this.txComentarioParamME.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioParamME.Size = new System.Drawing.Size(210, 157);
			this.txComentarioParamME.TabIndex = 71;
			// 
			// lbComentarioParamME
			// 
			this.lbComentarioParamME.AutoSize = true;
			this.lbComentarioParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioParamME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioParamME.Location = new System.Drawing.Point(0, 182);
			this.lbComentarioParamME.Name = "lbComentarioParamME";
			this.lbComentarioParamME.Size = new System.Drawing.Size(160, 13);
			this.lbComentarioParamME.TabIndex = 70;
			this.lbComentarioParamME.Text = "Comentario del parámetro:";
			// 
			// txMiembroDisplayParamME
			// 
			this.txMiembroDisplayParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.txMiembroDisplayParamME.Location = new System.Drawing.Point(0, 162);
			this.txMiembroDisplayParamME.Name = "txMiembroDisplayParamME";
			this.txMiembroDisplayParamME.Size = new System.Drawing.Size(210, 20);
			this.txMiembroDisplayParamME.TabIndex = 69;
			// 
			// lbMiembroDisplayParamME
			// 
			this.lbMiembroDisplayParamME.AutoSize = true;
			this.lbMiembroDisplayParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMiembroDisplayParamME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMiembroDisplayParamME.Location = new System.Drawing.Point(0, 149);
			this.lbMiembroDisplayParamME.Name = "lbMiembroDisplayParamME";
			this.lbMiembroDisplayParamME.Size = new System.Drawing.Size(92, 13);
			this.lbMiembroDisplayParamME.TabIndex = 68;
			this.lbMiembroDisplayParamME.Text = "Campo display:";
			// 
			// txMiembroValorParamME
			// 
			this.txMiembroValorParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.txMiembroValorParamME.Location = new System.Drawing.Point(0, 129);
			this.txMiembroValorParamME.Name = "txMiembroValorParamME";
			this.txMiembroValorParamME.Size = new System.Drawing.Size(210, 20);
			this.txMiembroValorParamME.TabIndex = 67;
			// 
			// lbMiembroValorParamME
			// 
			this.lbMiembroValorParamME.AutoSize = true;
			this.lbMiembroValorParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMiembroValorParamME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMiembroValorParamME.Location = new System.Drawing.Point(0, 116);
			this.lbMiembroValorParamME.Name = "lbMiembroValorParamME";
			this.lbMiembroValorParamME.Size = new System.Drawing.Size(81, 13);
			this.lbMiembroValorParamME.TabIndex = 66;
			this.lbMiembroValorParamME.Text = "Campo valor:";
			// 
			// txOrigenParamME
			// 
			this.txOrigenParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.txOrigenParamME.Location = new System.Drawing.Point(0, 96);
			this.txOrigenParamME.Name = "txOrigenParamME";
			this.txOrigenParamME.Size = new System.Drawing.Size(210, 20);
			this.txOrigenParamME.TabIndex = 65;
			// 
			// lbOrigenParamME
			// 
			this.lbOrigenParamME.AutoSize = true;
			this.lbOrigenParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbOrigenParamME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbOrigenParamME.Location = new System.Drawing.Point(0, 83);
			this.lbOrigenParamME.Name = "lbOrigenParamME";
			this.lbOrigenParamME.Size = new System.Drawing.Size(47, 13);
			this.lbOrigenParamME.TabIndex = 64;
			this.lbOrigenParamME.Text = "Origen:";
			// 
			// chNuloParamME
			// 
			this.chNuloParamME.AutoSize = true;
			this.chNuloParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.chNuloParamME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chNuloParamME.Location = new System.Drawing.Point(0, 66);
			this.chNuloParamME.Name = "chNuloParamME";
			this.chNuloParamME.Size = new System.Drawing.Size(210, 17);
			this.chNuloParamME.TabIndex = 63;
			this.chNuloParamME.Text = "Permite valor nulo";
			this.chNuloParamME.UseVisualStyleBackColor = true;
			// 
			// txDefaultParamME
			// 
			this.txDefaultParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDefaultParamME.Location = new System.Drawing.Point(0, 46);
			this.txDefaultParamME.Name = "txDefaultParamME";
			this.txDefaultParamME.Size = new System.Drawing.Size(210, 20);
			this.txDefaultParamME.TabIndex = 62;
			// 
			// lbDefaultParamME
			// 
			this.lbDefaultParamME.AutoSize = true;
			this.lbDefaultParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDefaultParamME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbDefaultParamME.Location = new System.Drawing.Point(0, 33);
			this.lbDefaultParamME.Name = "lbDefaultParamME";
			this.lbDefaultParamME.Size = new System.Drawing.Size(107, 13);
			this.lbDefaultParamME.TabIndex = 61;
			this.lbDefaultParamME.Text = "Valor por defecto:";
			// 
			// txEtiquetaParamME
			// 
			this.txEtiquetaParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaParamME.Location = new System.Drawing.Point(0, 13);
			this.txEtiquetaParamME.Name = "txEtiquetaParamME";
			this.txEtiquetaParamME.Size = new System.Drawing.Size(210, 20);
			this.txEtiquetaParamME.TabIndex = 60;
			// 
			// lbEtiquetaParamME
			// 
			this.lbEtiquetaParamME.AutoSize = true;
			this.lbEtiquetaParamME.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaParamME.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaParamME.Location = new System.Drawing.Point(0, 0);
			this.lbEtiquetaParamME.Name = "lbEtiquetaParamME";
			this.lbEtiquetaParamME.Size = new System.Drawing.Size(141, 13);
			this.lbEtiquetaParamME.TabIndex = 59;
			this.lbEtiquetaParamME.Text = "Etiqueta del parámetro:";
			// 
			// tpGC
			// 
			this.tpGC.Controls.Add(this.containerGC);
			this.tpGC.Location = new System.Drawing.Point(4, 22);
			this.tpGC.Name = "tpGC";
			this.tpGC.Size = new System.Drawing.Size(569, 384);
			this.tpGC.TabIndex = 5;
			this.tpGC.Text = "Grupos comunes";
			this.tpGC.UseVisualStyleBackColor = true;
			// 
			// containerGC
			// 
			this.containerGC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerGC.Location = new System.Drawing.Point(0, 0);
			this.containerGC.Name = "containerGC";
			// 
			// containerGC.Panel1
			// 
			this.containerGC.Panel1.Controls.Add(this.lGC);
			this.containerGC.Panel1.Controls.Add(this.toolsGC);
			// 
			// containerGC.Panel2
			// 
			this.containerGC.Panel2.Controls.Add(this.txComentarioGC);
			this.containerGC.Panel2.Controls.Add(this.lbComentarioGC);
			this.containerGC.Panel2.Controls.Add(this.txEtiquetaGC);
			this.containerGC.Panel2.Controls.Add(this.lbEtiquetaGC);
			this.containerGC.Size = new System.Drawing.Size(569, 384);
			this.containerGC.SplitterDistance = 220;
			this.containerGC.TabIndex = 0;
			// 
			// lGC
			// 
			this.lGC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lGC.FormattingEnabled = true;
			this.lGC.IntegralHeight = false;
			this.lGC.Location = new System.Drawing.Point(0, 25);
			this.lGC.Name = "lGC";
			this.lGC.Size = new System.Drawing.Size(220, 359);
			this.lGC.TabIndex = 1;
			this.lGC.SelectedIndexChanged += new System.EventHandler(this.LGCSelectedIndexChanged);
			// 
			// toolsGC
			// 
			this.toolsGC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsNuevoGC,
									this.tsBorrarGC,
									this.tsSubirGC,
									this.tsBajarGC,
									this.tsGuardarGC});
			this.toolsGC.Location = new System.Drawing.Point(0, 0);
			this.toolsGC.Name = "toolsGC";
			this.toolsGC.Size = new System.Drawing.Size(220, 25);
			this.toolsGC.TabIndex = 0;
			this.toolsGC.Text = "toolStrip5";
			// 
			// tsNuevoGC
			// 
			this.tsNuevoGC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNuevoGC.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevoGC.Image")));
			this.tsNuevoGC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNuevoGC.Name = "tsNuevoGC";
			this.tsNuevoGC.Size = new System.Drawing.Size(23, 22);
			this.tsNuevoGC.Text = "Nuevo";
			this.tsNuevoGC.Click += new System.EventHandler(this.TsNuevoGCClick);
			// 
			// tsBorrarGC
			// 
			this.tsBorrarGC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBorrarGC.Image = ((System.Drawing.Image)(resources.GetObject("tsBorrarGC.Image")));
			this.tsBorrarGC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBorrarGC.Name = "tsBorrarGC";
			this.tsBorrarGC.Size = new System.Drawing.Size(23, 22);
			this.tsBorrarGC.Text = "Borrar";
			this.tsBorrarGC.Click += new System.EventHandler(this.TsBorrarGCClick);
			// 
			// tsSubirGC
			// 
			this.tsSubirGC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsSubirGC.Image = ((System.Drawing.Image)(resources.GetObject("tsSubirGC.Image")));
			this.tsSubirGC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSubirGC.Name = "tsSubirGC";
			this.tsSubirGC.Size = new System.Drawing.Size(23, 22);
			this.tsSubirGC.Text = "Subir";
			this.tsSubirGC.Click += new System.EventHandler(this.TsSubirGCClick);
			// 
			// tsBajarGC
			// 
			this.tsBajarGC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBajarGC.Image = ((System.Drawing.Image)(resources.GetObject("tsBajarGC.Image")));
			this.tsBajarGC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBajarGC.Name = "tsBajarGC";
			this.tsBajarGC.Size = new System.Drawing.Size(23, 22);
			this.tsBajarGC.Text = "Bajar";
			this.tsBajarGC.Click += new System.EventHandler(this.TsBajarGCClick);
			// 
			// tsGuardarGC
			// 
			this.tsGuardarGC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsGuardarGC.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardarGC.Image")));
			this.tsGuardarGC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGuardarGC.Name = "tsGuardarGC";
			this.tsGuardarGC.Size = new System.Drawing.Size(23, 22);
			this.tsGuardarGC.Text = "Guardar";
			this.tsGuardarGC.Click += new System.EventHandler(this.TsGuardarGCClick);
			// 
			// txComentarioGC
			// 
			this.txComentarioGC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioGC.Location = new System.Drawing.Point(0, 46);
			this.txComentarioGC.Multiline = true;
			this.txComentarioGC.Name = "txComentarioGC";
			this.txComentarioGC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioGC.Size = new System.Drawing.Size(345, 338);
			this.txComentarioGC.TabIndex = 3;
			// 
			// lbComentarioGC
			// 
			this.lbComentarioGC.AutoSize = true;
			this.lbComentarioGC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioGC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioGC.Location = new System.Drawing.Point(0, 33);
			this.lbComentarioGC.Name = "lbComentarioGC";
			this.lbComentarioGC.Size = new System.Drawing.Size(76, 13);
			this.lbComentarioGC.TabIndex = 2;
			this.lbComentarioGC.Text = "Comentario:";
			// 
			// txEtiquetaGC
			// 
			this.txEtiquetaGC.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaGC.Location = new System.Drawing.Point(0, 13);
			this.txEtiquetaGC.Name = "txEtiquetaGC";
			this.txEtiquetaGC.Size = new System.Drawing.Size(345, 20);
			this.txEtiquetaGC.TabIndex = 1;
			this.txEtiquetaGC.Validated += new System.EventHandler(this.TxEtiquetaGCValidated);
			// 
			// lbEtiquetaGC
			// 
			this.lbEtiquetaGC.AutoSize = true;
			this.lbEtiquetaGC.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaGC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaGC.Location = new System.Drawing.Point(0, 0);
			this.lbEtiquetaGC.Name = "lbEtiquetaGC";
			this.lbEtiquetaGC.Size = new System.Drawing.Size(57, 13);
			this.lbEtiquetaGC.TabIndex = 0;
			this.lbEtiquetaGC.Text = "Etiqueta:";
			// 
			// tpGE
			// 
			this.tpGE.Controls.Add(this.containerGE);
			this.tpGE.Location = new System.Drawing.Point(4, 22);
			this.tpGE.Name = "tpGE";
			this.tpGE.Size = new System.Drawing.Size(569, 384);
			this.tpGE.TabIndex = 6;
			this.tpGE.Text = "Grupos específicos";
			this.tpGE.UseVisualStyleBackColor = true;
			// 
			// containerGE
			// 
			this.containerGE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.containerGE.Location = new System.Drawing.Point(0, 0);
			this.containerGE.Name = "containerGE";
			// 
			// containerGE.Panel1
			// 
			this.containerGE.Panel1.Controls.Add(this.lGE);
			this.containerGE.Panel1.Controls.Add(this.toolsGE);
			// 
			// containerGE.Panel2
			// 
			this.containerGE.Panel2.Controls.Add(this.txComentarioGE);
			this.containerGE.Panel2.Controls.Add(this.lbComentarioGE);
			this.containerGE.Panel2.Controls.Add(this.txEtiquetaGE);
			this.containerGE.Panel2.Controls.Add(this.lbEtiquetaGE);
			this.containerGE.Size = new System.Drawing.Size(569, 384);
			this.containerGE.SplitterDistance = 189;
			this.containerGE.TabIndex = 0;
			// 
			// lGE
			// 
			this.lGE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lGE.FormattingEnabled = true;
			this.lGE.IntegralHeight = false;
			this.lGE.Location = new System.Drawing.Point(0, 25);
			this.lGE.Name = "lGE";
			this.lGE.Size = new System.Drawing.Size(189, 359);
			this.lGE.TabIndex = 3;
			this.lGE.SelectedIndexChanged += new System.EventHandler(this.LGESelectedIndexChanged);
			// 
			// toolsGE
			// 
			this.toolsGE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsNuevoGE,
									this.tsBorrarGE,
									this.tsSubirGE,
									this.tsBajarGE,
									this.tsGuardarGE});
			this.toolsGE.Location = new System.Drawing.Point(0, 0);
			this.toolsGE.Name = "toolsGE";
			this.toolsGE.Size = new System.Drawing.Size(189, 25);
			this.toolsGE.TabIndex = 1;
			this.toolsGE.Text = "toolStrip6";
			// 
			// tsNuevoGE
			// 
			this.tsNuevoGE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsNuevoGE.Image = ((System.Drawing.Image)(resources.GetObject("tsNuevoGE.Image")));
			this.tsNuevoGE.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNuevoGE.Name = "tsNuevoGE";
			this.tsNuevoGE.Size = new System.Drawing.Size(23, 22);
			this.tsNuevoGE.Text = "Nuevo";
			this.tsNuevoGE.Click += new System.EventHandler(this.TsNuevoGEClick);
			// 
			// tsBorrarGE
			// 
			this.tsBorrarGE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBorrarGE.Image = ((System.Drawing.Image)(resources.GetObject("tsBorrarGE.Image")));
			this.tsBorrarGE.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBorrarGE.Name = "tsBorrarGE";
			this.tsBorrarGE.Size = new System.Drawing.Size(23, 22);
			this.tsBorrarGE.Text = "Borrar";
			this.tsBorrarGE.Click += new System.EventHandler(this.TsBorrarGEClick);
			// 
			// tsSubirGE
			// 
			this.tsSubirGE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsSubirGE.Image = ((System.Drawing.Image)(resources.GetObject("tsSubirGE.Image")));
			this.tsSubirGE.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSubirGE.Name = "tsSubirGE";
			this.tsSubirGE.Size = new System.Drawing.Size(23, 22);
			this.tsSubirGE.Text = "Subir";
			this.tsSubirGE.Click += new System.EventHandler(this.TsSubirGEClick);
			// 
			// tsBajarGE
			// 
			this.tsBajarGE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsBajarGE.Image = ((System.Drawing.Image)(resources.GetObject("tsBajarGE.Image")));
			this.tsBajarGE.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBajarGE.Name = "tsBajarGE";
			this.tsBajarGE.Size = new System.Drawing.Size(23, 22);
			this.tsBajarGE.Text = "Bajar";
			this.tsBajarGE.Click += new System.EventHandler(this.TsBajarGEClick);
			// 
			// tsGuardarGE
			// 
			this.tsGuardarGE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsGuardarGE.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardarGE.Image")));
			this.tsGuardarGE.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsGuardarGE.Name = "tsGuardarGE";
			this.tsGuardarGE.Size = new System.Drawing.Size(23, 22);
			this.tsGuardarGE.Text = "Guardar";
			this.tsGuardarGE.Click += new System.EventHandler(this.TsGuardarGEClick);
			// 
			// txComentarioGE
			// 
			this.txComentarioGE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txComentarioGE.Location = new System.Drawing.Point(0, 46);
			this.txComentarioGE.Multiline = true;
			this.txComentarioGE.Name = "txComentarioGE";
			this.txComentarioGE.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txComentarioGE.Size = new System.Drawing.Size(376, 338);
			this.txComentarioGE.TabIndex = 7;
			// 
			// lbComentarioGE
			// 
			this.lbComentarioGE.AutoSize = true;
			this.lbComentarioGE.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComentarioGE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbComentarioGE.Location = new System.Drawing.Point(0, 33);
			this.lbComentarioGE.Name = "lbComentarioGE";
			this.lbComentarioGE.Size = new System.Drawing.Size(76, 13);
			this.lbComentarioGE.TabIndex = 6;
			this.lbComentarioGE.Text = "Comentario:";
			// 
			// txEtiquetaGE
			// 
			this.txEtiquetaGE.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEtiquetaGE.Location = new System.Drawing.Point(0, 13);
			this.txEtiquetaGE.Name = "txEtiquetaGE";
			this.txEtiquetaGE.Size = new System.Drawing.Size(376, 20);
			this.txEtiquetaGE.TabIndex = 5;
			this.txEtiquetaGE.Validated += new System.EventHandler(this.TxEtiquetaGEValidated);
			// 
			// lbEtiquetaGE
			// 
			this.lbEtiquetaGE.AutoSize = true;
			this.lbEtiquetaGE.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEtiquetaGE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEtiquetaGE.Location = new System.Drawing.Point(0, 0);
			this.lbEtiquetaGE.Name = "lbEtiquetaGE";
			this.lbEtiquetaGE.Size = new System.Drawing.Size(57, 13);
			this.lbEtiquetaGE.TabIndex = 4;
			this.lbEtiquetaGE.Text = "Etiqueta:";
			// 
			// controlSesionSOAP
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "controlSesionSOAP";
			this.Size = new System.Drawing.Size(577, 454);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.tcPrincipal.ResumeLayout(false);
			this.tpComent.ResumeLayout(false);
			this.tpComent.PerformLayout();
			this.tpMI.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tpMV.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tpGeneralMV.ResumeLayout(false);
			this.tpGeneralMV.PerformLayout();
			this.tpParamsMV.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.Panel2.PerformLayout();
			this.splitContainer3.ResumeLayout(false);
			this.tpMC.ResumeLayout(false);
			this.containerMC.Panel1.ResumeLayout(false);
			this.containerMC.Panel1.PerformLayout();
			this.containerMC.Panel2.ResumeLayout(false);
			this.containerMC.ResumeLayout(false);
			this.toolsMC.ResumeLayout(false);
			this.toolsMC.PerformLayout();
			this.tabControl3.ResumeLayout(false);
			this.tpGeneralMC.ResumeLayout(false);
			this.tpGeneralMC.PerformLayout();
			this.tpParamsMC.ResumeLayout(false);
			this.containerParamsMC.Panel1.ResumeLayout(false);
			this.containerParamsMC.Panel2.ResumeLayout(false);
			this.containerParamsMC.Panel2.PerformLayout();
			this.containerParamsMC.ResumeLayout(false);
			this.tpME.ResumeLayout(false);
			this.containerME.Panel1.ResumeLayout(false);
			this.containerME.Panel1.PerformLayout();
			this.containerME.Panel2.ResumeLayout(false);
			this.containerME.ResumeLayout(false);
			this.toolsME.ResumeLayout(false);
			this.toolsME.PerformLayout();
			this.tabControl4.ResumeLayout(false);
			this.tpGeneralME.ResumeLayout(false);
			this.tpGeneralME.PerformLayout();
			this.tpParamsME.ResumeLayout(false);
			this.containerParamsME.Panel1.ResumeLayout(false);
			this.containerParamsME.Panel2.ResumeLayout(false);
			this.containerParamsME.Panel2.PerformLayout();
			this.containerParamsME.ResumeLayout(false);
			this.tpGC.ResumeLayout(false);
			this.containerGC.Panel1.ResumeLayout(false);
			this.containerGC.Panel1.PerformLayout();
			this.containerGC.Panel2.ResumeLayout(false);
			this.containerGC.Panel2.PerformLayout();
			this.containerGC.ResumeLayout(false);
			this.toolsGC.ResumeLayout(false);
			this.toolsGC.PerformLayout();
			this.tpGE.ResumeLayout(false);
			this.containerGE.Panel1.ResumeLayout(false);
			this.containerGE.Panel1.PerformLayout();
			this.containerGE.Panel2.ResumeLayout(false);
			this.containerGE.Panel2.PerformLayout();
			this.containerGE.ResumeLayout(false);
			this.toolsGE.ResumeLayout(false);
			this.toolsGE.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TabControl tcPrincipal;
		private System.Windows.Forms.SplitContainer containerParamsME;
		private System.Windows.Forms.TextBox txComentarioME;
		private System.Windows.Forms.ToolStripButton tsGuardarMC;
		private System.Windows.Forms.SplitContainer containerParamsMC;
		private System.Windows.Forms.SplitContainer containerGE;
		private System.Windows.Forms.ToolStrip toolsGE;
		private System.Windows.Forms.SplitContainer containerGC;
		private System.Windows.Forms.ToolStrip toolsGC;
		private System.Windows.Forms.SplitContainer containerME;
		private System.Windows.Forms.ToolStrip toolsMC;
		private System.Windows.Forms.SplitContainer containerMC;
		private System.Windows.Forms.ToolStrip toolsME;
		private System.Windows.Forms.Label lbEtiquetaParamME;
		private System.Windows.Forms.TextBox txEtiquetaParamME;
		private System.Windows.Forms.Label lbDefaultParamME;
		private System.Windows.Forms.TextBox txDefaultParamME;
		private System.Windows.Forms.CheckBox chNuloParamME;
		private System.Windows.Forms.Label lbOrigenParamME;
		private System.Windows.Forms.TextBox txOrigenParamME;
		private System.Windows.Forms.Label lbMiembroValorParamME;
		private System.Windows.Forms.TextBox txMiembroValorParamME;
		private System.Windows.Forms.Label lbMiembroDisplayParamME;
		private System.Windows.Forms.TextBox txMiembroDisplayParamME;
		private System.Windows.Forms.Label lbComentarioParamME;
		private System.Windows.Forms.TextBox txComentarioParamME;
		private System.Windows.Forms.ListBox lParamsME;
		private System.Windows.Forms.Label lbEtiquetaParamMC;
		private System.Windows.Forms.TextBox txEtiquetaParamMC;
		private System.Windows.Forms.Label lbDefaultParamMC;
		private System.Windows.Forms.TextBox txDefaultParamMC;
		private System.Windows.Forms.CheckBox chNuloParamMC;
		private System.Windows.Forms.Label lbOrigenParamMC;
		private System.Windows.Forms.TextBox txOrigenParamMC;
		private System.Windows.Forms.Label lbMiembroValorParamMC;
		private System.Windows.Forms.TextBox txMiembroValorParamMC;
		private System.Windows.Forms.Label lbMiembroDisplayParamMC;
		private System.Windows.Forms.TextBox txMiembroDisplayParamMC;
		private System.Windows.Forms.Label lbComentarioParamMC;
		private System.Windows.Forms.TextBox txComentarioParamMC;
		private System.Windows.Forms.ListBox lParamsMC;
		private System.Windows.Forms.Label lbEtiquetaGE;
		private System.Windows.Forms.TextBox txEtiquetaGE;
		private System.Windows.Forms.Label lbComentarioGE;
		private System.Windows.Forms.TextBox txComentarioGE;
		private System.Windows.Forms.Label lbEtiquetaGC;
		private System.Windows.Forms.TextBox txEtiquetaGC;
		private System.Windows.Forms.Label lbComentarioGC;
		private System.Windows.Forms.TextBox txComentarioGC;
		private System.Windows.Forms.ToolStripButton tsGuardarGE;
		private System.Windows.Forms.ToolStripButton tsBajarGE;
		private System.Windows.Forms.ToolStripButton tsSubirGE;
		private System.Windows.Forms.ToolStripButton tsBorrarGE;
		private System.Windows.Forms.ToolStripButton tsNuevoGE;
		private System.Windows.Forms.ToolStripButton tsGuardarGC;
		private System.Windows.Forms.ToolStripButton tsBajarGC;
		private System.Windows.Forms.ToolStripButton tsSubirGC;
		private System.Windows.Forms.ToolStripButton tsBorrarGC;
		private System.Windows.Forms.ToolStripButton tsNuevoGC;
		private System.Windows.Forms.Label lbEtiquetaME;
		private System.Windows.Forms.TextBox txEtiquetaME;
		private System.Windows.Forms.Label lbComentarioME;
		private System.Windows.Forms.Label lbEtiquetaMC;
		private System.Windows.Forms.TextBox txEtiquetaMC;
		private System.Windows.Forms.Label lbComentarioMC;
		private System.Windows.Forms.TextBox txComentarioMC;
		private System.Windows.Forms.ToolStripButton tsMoverME;
		private System.Windows.Forms.ToolStripButton tsMoverMC;
		private System.Windows.Forms.Label lbGE;
		private System.Windows.Forms.ComboBox cGE;
		private System.Windows.Forms.Label lbME;
		private System.Windows.Forms.ToolStripButton tsGuardarME;
		private System.Windows.Forms.ToolStripButton tsObsoletoME;
		private System.Windows.Forms.ToolStripButton tsBajarME;
		private System.Windows.Forms.ToolStripButton tsSubirME;
		private System.Windows.Forms.ToolStripButton tsBorrarME;
		private System.Windows.Forms.ToolStripButton tsNuevoME;
		private System.Windows.Forms.ListBox lGE;
		private System.Windows.Forms.ListBox lGC;
		private System.Windows.Forms.ListBox lME;
		private System.Windows.Forms.ToolStripButton tsObsoletoMC;
		private System.Windows.Forms.ToolStripButton tsBajarMC;
		private System.Windows.Forms.ToolStripButton tsSubirMC;
		private System.Windows.Forms.ToolStripButton tsBorrarMC;
		private System.Windows.Forms.ToolStripButton tsNuevoMC;
		private System.Windows.Forms.Label lbGC;
		private System.Windows.Forms.ComboBox cGC;
		private System.Windows.Forms.Label lbMC;
		private System.Windows.Forms.ListBox lMC;
		private System.Windows.Forms.TabPage tpGE;
		private System.Windows.Forms.TabPage tpGC;
		private System.Windows.Forms.TabPage tpParamsME;
		private System.Windows.Forms.TabPage tpGeneralME;
		private System.Windows.Forms.TabControl tabControl4;
		private System.Windows.Forms.TabPage tpParamsMC;
		private System.Windows.Forms.TabPage tpGeneralMC;
		private System.Windows.Forms.TabControl tabControl3;
		private System.Windows.Forms.TabPage tpME;
		private System.Windows.Forms.TabPage tpMC;
		private System.Windows.Forms.CheckBox chAnonimoMV;
		private System.Windows.Forms.CheckBox chAnonimoMI;
		private System.Windows.Forms.CheckBox chNuloParamMV;
		private System.Windows.Forms.ToolStripButton tsObsoletoMV;
		private System.Windows.Forms.ToolStripButton tsObsoletoMI;
		private System.Windows.Forms.Label lbMiembroDisplayParamMV;
		private System.Windows.Forms.TextBox txMiembroDisplayParamMV;
		private System.Windows.Forms.TextBox txMiembroValorParamMV;
		private System.Windows.Forms.Label lbMiembroValorParamMV;
		private System.Windows.Forms.SaveFileDialog dlgGuardarComo;
		private System.Windows.Forms.TextBox txOrigenParamMV;
		private System.Windows.Forms.Label lbDefaultParamMV;
		private System.Windows.Forms.TextBox txDefaultParamMV;
		private System.Windows.Forms.Label lbOrigenParamMV;
		private System.Windows.Forms.Label lbEtiquetaParamMV;
		private System.Windows.Forms.TextBox txEtiquetaParamMV;
		private System.Windows.Forms.Label lbComentarioParamMV;
		private System.Windows.Forms.TextBox txComentarioParamMV;
		private System.Windows.Forms.TabPage tpParamsMV;
		private System.Windows.Forms.TabPage tpGeneralMV;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.Label lbComentarioMI;
		private System.Windows.Forms.TextBox txComentarioMI;
		private System.Windows.Forms.ListBox lParamsMV;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.Label lbComentarioMV;
		private System.Windows.Forms.TextBox txComentarioMV;
		private System.Windows.Forms.Label lbEtiquetaMV;
		private System.Windows.Forms.TextBox txEtiquetaMV;
		private System.Windows.Forms.ListBox lMV;
		private System.Windows.Forms.ToolStripButton tsGuardarMV;
		private System.Windows.Forms.ToolStripButton tsBajarMV;
		private System.Windows.Forms.ToolStripButton tsSubirMV;
		private System.Windows.Forms.ToolStripButton tsBorrarMV;
		private System.Windows.Forms.ToolStripButton tsNuevoMV;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ToolStripButton tsGuardarMI;
		private System.Windows.Forms.Label lbEtiquetaMI;
		private System.Windows.Forms.TextBox txEtiquetaMI;
		private System.Windows.Forms.TabPage tpMV;
		private System.Windows.Forms.ToolStripButton tsBajarMI;
		private System.Windows.Forms.ToolStripButton tsSubirMI;
		private System.Windows.Forms.ToolStripButton tsBorrarMI;
		private System.Windows.Forms.ToolStripButton tsNuevoMI;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ListBox lMI;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabPage tpMI;
		private System.Windows.Forms.TextBox txComent;
		private System.Windows.Forms.TabPage tpComent;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.TextBox txDesc;
		private System.Windows.Forms.Panel panel1;
	}
}
