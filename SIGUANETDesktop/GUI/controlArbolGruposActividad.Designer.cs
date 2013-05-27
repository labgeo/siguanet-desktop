/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 09/01/2008
 * Hora: 10:46
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlArbolGruposActividad
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlArbolGruposActividad));
			this.panel1 = new System.Windows.Forms.Panel();
			this.txDesc = new System.Windows.Forms.TextBox();
			this.lbDesc = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpComent = new System.Windows.Forms.TabPage();
			this.txComent = new System.Windows.Forms.TextBox();
			this.tpProps = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lProps = new System.Windows.Forms.CheckedListBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbNuevaProp = new System.Windows.Forms.ToolStripButton();
			this.tsbBorrarProp = new System.Windows.Forms.ToolStripButton();
			this.tsbSubirProp = new System.Windows.Forms.ToolStripButton();
			this.tsbBajarProp = new System.Windows.Forms.ToolStripButton();
			this.tsbCopiarProp = new System.Windows.Forms.ToolStripButton();
			this.tsbPegarProp = new System.Windows.Forms.ToolStripButton();
			this.tsbSelector = new System.Windows.Forms.ToolStripButton();
			this.txDescProp = new System.Windows.Forms.TextBox();
			this.lbDescProp = new System.Windows.Forms.Label();
			this.cbComportamientoProp = new System.Windows.Forms.ComboBox();
			this.lbComportamientoProp = new System.Windows.Forms.Label();
			this.cbGrupoProp = new System.Windows.Forms.ComboBox();
			this.lbGrupoProp = new System.Windows.Forms.Label();
			this.txFormatoPresentacionProp = new System.Windows.Forms.TextBox();
			this.lbFormatoPresentacionProp = new System.Windows.Forms.Label();
			this.txFormatoEscalarProp = new System.Windows.Forms.TextBox();
			this.lbFormatoEscalarProp = new System.Windows.Forms.Label();
			this.txValorDefEscalarProp = new System.Windows.Forms.TextBox();
			this.lbValorDefEscalarProp = new System.Windows.Forms.Label();
			this.txTituloDataSetProp = new System.Windows.Forms.TextBox();
			this.lbTituloDataSetProp = new System.Windows.Forms.Label();
			this.txMetodoDataSetProp = new System.Windows.Forms.TextBox();
			this.lbMetodoDataSetProp = new System.Windows.Forms.Label();
			this.txMetodoEscalarProp = new System.Windows.Forms.TextBox();
			this.lbMetodoEscalarProp = new System.Windows.Forms.Label();
			this.txClaseProp = new System.Windows.Forms.TextBox();
			this.lbClaseProp = new System.Windows.Forms.Label();
			this.txTituloProp = new System.Windows.Forms.TextBox();
			this.lbTitulo = new System.Windows.Forms.Label();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpComent.SuspendLayout();
			this.tpProps.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
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
			this.panel1.TabIndex = 6;
			// 
			// txDesc
			// 
			this.txDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDesc.Location = new System.Drawing.Point(0, 13);
			this.txDesc.Name = "txDesc";
			this.txDesc.Size = new System.Drawing.Size(577, 20);
			this.txDesc.TabIndex = 1;
			this.txDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyUp);
			this.txDesc.TextChanged += new System.EventHandler(this.TxDescTextChanged);
			this.txDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxDescKeyDown);
			// 
			// lbDesc
			// 
			this.lbDesc.AutoSize = true;
			this.lbDesc.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDesc.Location = new System.Drawing.Point(0, 0);
			this.lbDesc.Name = "lbDesc";
			this.lbDesc.Size = new System.Drawing.Size(66, 13);
			this.lbDesc.TabIndex = 0;
			this.lbDesc.Text = "Descripción:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 44);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(577, 410);
			this.panel2.TabIndex = 8;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpComent);
			this.tabControl1.Controls.Add(this.tpProps);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(577, 410);
			this.tabControl1.TabIndex = 1;
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
			this.txComent.Size = new System.Drawing.Size(563, 378);
			this.txComent.TabIndex = 0;
			this.txComent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxComentKeyUp);
			this.txComent.TextChanged += new System.EventHandler(this.TxComentTextChanged);
			this.txComent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxComentKeyDown);
			// 
			// tpProps
			// 
			this.tpProps.Controls.Add(this.splitContainer1);
			this.tpProps.Location = new System.Drawing.Point(4, 22);
			this.tpProps.Name = "tpProps";
			this.tpProps.Padding = new System.Windows.Forms.Padding(3);
			this.tpProps.Size = new System.Drawing.Size(569, 384);
			this.tpProps.TabIndex = 1;
			this.tpProps.Text = "Configuración de propiedades";
			this.tpProps.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lProps);
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer1.Panel2.Controls.Add(this.txDescProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbDescProp);
			this.splitContainer1.Panel2.Controls.Add(this.cbComportamientoProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbComportamientoProp);
			this.splitContainer1.Panel2.Controls.Add(this.cbGrupoProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbGrupoProp);
			this.splitContainer1.Panel2.Controls.Add(this.txFormatoPresentacionProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbFormatoPresentacionProp);
			this.splitContainer1.Panel2.Controls.Add(this.txFormatoEscalarProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbFormatoEscalarProp);
			this.splitContainer1.Panel2.Controls.Add(this.txValorDefEscalarProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbValorDefEscalarProp);
			this.splitContainer1.Panel2.Controls.Add(this.txTituloDataSetProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbTituloDataSetProp);
			this.splitContainer1.Panel2.Controls.Add(this.txMetodoDataSetProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbMetodoDataSetProp);
			this.splitContainer1.Panel2.Controls.Add(this.txMetodoEscalarProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbMetodoEscalarProp);
			this.splitContainer1.Panel2.Controls.Add(this.txClaseProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbClaseProp);
			this.splitContainer1.Panel2.Controls.Add(this.txTituloProp);
			this.splitContainer1.Panel2.Controls.Add(this.lbTitulo);
			this.splitContainer1.Size = new System.Drawing.Size(563, 378);
			this.splitContainer1.SplitterDistance = 187;
			this.splitContainer1.TabIndex = 2;
			// 
			// lProps
			// 
			this.lProps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lProps.FormattingEnabled = true;
			this.lProps.IntegralHeight = false;
			this.lProps.Location = new System.Drawing.Point(0, 25);
			this.lProps.Name = "lProps";
			this.lProps.Size = new System.Drawing.Size(187, 353);
			this.lProps.TabIndex = 2;
			this.lProps.SelectedIndexChanged += new System.EventHandler(this.LPropsSelectedIndexChanged);
			this.lProps.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LPropsItemCheck);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsbNuevaProp,
									this.tsbBorrarProp,
									this.tsbSubirProp,
									this.tsbBajarProp,
									this.toolStripSeparator1,
									this.tsbCopiarProp,
									this.tsbPegarProp,
									this.tsbSelector});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(187, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbNuevaProp
			// 
			this.tsbNuevaProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbNuevaProp.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevaProp.Image")));
			this.tsbNuevaProp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbNuevaProp.Name = "tsbNuevaProp";
			this.tsbNuevaProp.Size = new System.Drawing.Size(23, 22);
			this.tsbNuevaProp.Text = "Nueva propiedad";
			this.tsbNuevaProp.Click += new System.EventHandler(this.TsbNuevaPropClick);
			// 
			// tsbBorrarProp
			// 
			this.tsbBorrarProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbBorrarProp.Image = ((System.Drawing.Image)(resources.GetObject("tsbBorrarProp.Image")));
			this.tsbBorrarProp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbBorrarProp.Name = "tsbBorrarProp";
			this.tsbBorrarProp.Size = new System.Drawing.Size(23, 22);
			this.tsbBorrarProp.Text = "Borrar propiedad";
			this.tsbBorrarProp.Click += new System.EventHandler(this.TsbBorrarPropClick);
			// 
			// tsbSubirProp
			// 
			this.tsbSubirProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSubirProp.Image = ((System.Drawing.Image)(resources.GetObject("tsbSubirProp.Image")));
			this.tsbSubirProp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSubirProp.Name = "tsbSubirProp";
			this.tsbSubirProp.Size = new System.Drawing.Size(23, 22);
			this.tsbSubirProp.Text = "Desplazar abajo";
			this.tsbSubirProp.Click += new System.EventHandler(this.TsbSubirPropClick);
			// 
			// tsbBajarProp
			// 
			this.tsbBajarProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbBajarProp.Image = ((System.Drawing.Image)(resources.GetObject("tsbBajarProp.Image")));
			this.tsbBajarProp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbBajarProp.Name = "tsbBajarProp";
			this.tsbBajarProp.Size = new System.Drawing.Size(23, 22);
			this.tsbBajarProp.Text = "Desplazar arriba";
			this.tsbBajarProp.Click += new System.EventHandler(this.TsbBajarPropClick);
			// 
			// tsbCopiarProp
			// 
			this.tsbCopiarProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCopiarProp.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopiarProp.Image")));
			this.tsbCopiarProp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCopiarProp.Name = "tsbCopiarProp";
			this.tsbCopiarProp.Size = new System.Drawing.Size(23, 22);
			this.tsbCopiarProp.Text = "Copiar propiedades seleccionadas";
			this.tsbCopiarProp.Click += new System.EventHandler(this.TsbCopiarPropClick);
			// 
			// tsbPegarProp
			// 
			this.tsbPegarProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPegarProp.Image = ((System.Drawing.Image)(resources.GetObject("tsbPegarProp.Image")));
			this.tsbPegarProp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPegarProp.Name = "tsbPegarProp";
			this.tsbPegarProp.Size = new System.Drawing.Size(23, 22);
			this.tsbPegarProp.Text = "Pegar propiedades";
			this.tsbPegarProp.Click += new System.EventHandler(this.TsbPegarPropClick);
			// 
			// tsbSelector
			// 
			this.tsbSelector.CheckOnClick = true;
			this.tsbSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSelector.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelector.Image")));
			this.tsbSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSelector.Name = "tsbSelector";
			this.tsbSelector.Size = new System.Drawing.Size(23, 20);
			this.tsbSelector.Text = "Seleccionar/Deseleccionar todo";
			this.tsbSelector.Click += new System.EventHandler(this.TsbSelectorClick);
			// 
			// txDescProp
			// 
			this.txDescProp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txDescProp.Location = new System.Drawing.Point(0, 345);
			this.txDescProp.Multiline = true;
			this.txDescProp.Name = "txDescProp";
			this.txDescProp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txDescProp.Size = new System.Drawing.Size(372, 33);
			this.txDescProp.TabIndex = 45;
			this.txDescProp.Validated += new System.EventHandler(this.TxDescPropValidated);
			// 
			// lbDescProp
			// 
			this.lbDescProp.AutoSize = true;
			this.lbDescProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDescProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbDescProp.Location = new System.Drawing.Point(0, 332);
			this.lbDescProp.Name = "lbDescProp";
			this.lbDescProp.Size = new System.Drawing.Size(75, 13);
			this.lbDescProp.TabIndex = 44;
			this.lbDescProp.Text = "Descripción:";
			// 
			// cbComportamientoProp
			// 
			this.cbComportamientoProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbComportamientoProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbComportamientoProp.FormattingEnabled = true;
			this.cbComportamientoProp.Location = new System.Drawing.Point(0, 311);
			this.cbComportamientoProp.Name = "cbComportamientoProp";
			this.cbComportamientoProp.Size = new System.Drawing.Size(372, 21);
			this.cbComportamientoProp.TabIndex = 43;
			this.cbComportamientoProp.Validated += new System.EventHandler(this.CbComportamientoPropValidated);
			// 
			// lbComportamientoProp
			// 
			this.lbComportamientoProp.AutoSize = true;
			this.lbComportamientoProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbComportamientoProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbComportamientoProp.Location = new System.Drawing.Point(0, 298);
			this.lbComportamientoProp.Name = "lbComportamientoProp";
			this.lbComportamientoProp.Size = new System.Drawing.Size(106, 13);
			this.lbComportamientoProp.TabIndex = 42;
			this.lbComportamientoProp.Text = "Comportamiento:";
			// 
			// cbGrupoProp
			// 
			this.cbGrupoProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbGrupoProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGrupoProp.FormattingEnabled = true;
			this.cbGrupoProp.Location = new System.Drawing.Point(0, 277);
			this.cbGrupoProp.Name = "cbGrupoProp";
			this.cbGrupoProp.Size = new System.Drawing.Size(372, 21);
			this.cbGrupoProp.TabIndex = 41;
			this.cbGrupoProp.Validated += new System.EventHandler(this.CbGrupoPropValidated);
			// 
			// lbGrupoProp
			// 
			this.lbGrupoProp.AutoSize = true;
			this.lbGrupoProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbGrupoProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbGrupoProp.Location = new System.Drawing.Point(0, 264);
			this.lbGrupoProp.Name = "lbGrupoProp";
			this.lbGrupoProp.Size = new System.Drawing.Size(44, 13);
			this.lbGrupoProp.TabIndex = 40;
			this.lbGrupoProp.Text = "Grupo:";
			// 
			// txFormatoPresentacionProp
			// 
			this.txFormatoPresentacionProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.txFormatoPresentacionProp.Location = new System.Drawing.Point(0, 244);
			this.txFormatoPresentacionProp.Name = "txFormatoPresentacionProp";
			this.txFormatoPresentacionProp.Size = new System.Drawing.Size(372, 20);
			this.txFormatoPresentacionProp.TabIndex = 39;
			this.txFormatoPresentacionProp.Validated += new System.EventHandler(this.TxFormatoPresentacionPropValidated);
			// 
			// lbFormatoPresentacionProp
			// 
			this.lbFormatoPresentacionProp.AutoSize = true;
			this.lbFormatoPresentacionProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbFormatoPresentacionProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbFormatoPresentacionProp.Location = new System.Drawing.Point(0, 231);
			this.lbFormatoPresentacionProp.Name = "lbFormatoPresentacionProp";
			this.lbFormatoPresentacionProp.Size = new System.Drawing.Size(152, 13);
			this.lbFormatoPresentacionProp.TabIndex = 38;
			this.lbFormatoPresentacionProp.Text = "Formato de presentación:";
			// 
			// txFormatoEscalarProp
			// 
			this.txFormatoEscalarProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.txFormatoEscalarProp.Location = new System.Drawing.Point(0, 211);
			this.txFormatoEscalarProp.Name = "txFormatoEscalarProp";
			this.txFormatoEscalarProp.Size = new System.Drawing.Size(372, 20);
			this.txFormatoEscalarProp.TabIndex = 37;
			this.txFormatoEscalarProp.Validated += new System.EventHandler(this.TxFormatoEscalarPropValidated);
			// 
			// lbFormatoEscalarProp
			// 
			this.lbFormatoEscalarProp.AutoSize = true;
			this.lbFormatoEscalarProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbFormatoEscalarProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbFormatoEscalarProp.Location = new System.Drawing.Point(0, 198);
			this.lbFormatoEscalarProp.Name = "lbFormatoEscalarProp";
			this.lbFormatoEscalarProp.Size = new System.Drawing.Size(122, 13);
			this.lbFormatoEscalarProp.TabIndex = 36;
			this.lbFormatoEscalarProp.Text = "Formato del escalar:";
			// 
			// txValorDefEscalarProp
			// 
			this.txValorDefEscalarProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.txValorDefEscalarProp.Location = new System.Drawing.Point(0, 178);
			this.txValorDefEscalarProp.Name = "txValorDefEscalarProp";
			this.txValorDefEscalarProp.Size = new System.Drawing.Size(372, 20);
			this.txValorDefEscalarProp.TabIndex = 35;
			this.txValorDefEscalarProp.Validated += new System.EventHandler(this.TxValorDefEscalarPropValidated);
			// 
			// lbValorDefEscalarProp
			// 
			this.lbValorDefEscalarProp.AutoSize = true;
			this.lbValorDefEscalarProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbValorDefEscalarProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbValorDefEscalarProp.Location = new System.Drawing.Point(0, 165);
			this.lbValorDefEscalarProp.Name = "lbValorDefEscalarProp";
			this.lbValorDefEscalarProp.Size = new System.Drawing.Size(171, 13);
			this.lbValorDefEscalarProp.TabIndex = 34;
			this.lbValorDefEscalarProp.Text = "Valor por defecto del escalar:";
			// 
			// txTituloDataSetProp
			// 
			this.txTituloDataSetProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.txTituloDataSetProp.Location = new System.Drawing.Point(0, 145);
			this.txTituloDataSetProp.Name = "txTituloDataSetProp";
			this.txTituloDataSetProp.Size = new System.Drawing.Size(372, 20);
			this.txTituloDataSetProp.TabIndex = 21;
			this.txTituloDataSetProp.Validated += new System.EventHandler(this.TxTituloDataSetPropValidated);
			// 
			// lbTituloDataSetProp
			// 
			this.lbTituloDataSetProp.AutoSize = true;
			this.lbTituloDataSetProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTituloDataSetProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbTituloDataSetProp.Location = new System.Drawing.Point(0, 132);
			this.lbTituloDataSetProp.Name = "lbTituloDataSetProp";
			this.lbTituloDataSetProp.Size = new System.Drawing.Size(206, 13);
			this.lbTituloDataSetProp.TabIndex = 20;
			this.lbTituloDataSetProp.Text = "Descripción del DataSet resultante:";
			// 
			// txMetodoDataSetProp
			// 
			this.txMetodoDataSetProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.txMetodoDataSetProp.Location = new System.Drawing.Point(0, 112);
			this.txMetodoDataSetProp.Name = "txMetodoDataSetProp";
			this.txMetodoDataSetProp.Size = new System.Drawing.Size(372, 20);
			this.txMetodoDataSetProp.TabIndex = 19;
			this.txMetodoDataSetProp.Validated += new System.EventHandler(this.TxMetodoDataSetPropValidated);
			// 
			// lbMetodoDataSetProp
			// 
			this.lbMetodoDataSetProp.AutoSize = true;
			this.lbMetodoDataSetProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMetodoDataSetProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbMetodoDataSetProp.Location = new System.Drawing.Point(0, 99);
			this.lbMetodoDataSetProp.Name = "lbMetodoDataSetProp";
			this.lbMetodoDataSetProp.Size = new System.Drawing.Size(157, 13);
			this.lbMetodoDataSetProp.TabIndex = 18;
			this.lbMetodoDataSetProp.Text = "Método DataSet a invocar:";
			// 
			// txMetodoEscalarProp
			// 
			this.txMetodoEscalarProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.txMetodoEscalarProp.Location = new System.Drawing.Point(0, 79);
			this.txMetodoEscalarProp.Name = "txMetodoEscalarProp";
			this.txMetodoEscalarProp.Size = new System.Drawing.Size(372, 20);
			this.txMetodoEscalarProp.TabIndex = 17;
			this.txMetodoEscalarProp.Validated += new System.EventHandler(this.TxMetodoEscalarPropValidated);
			// 
			// lbMetodoEscalarProp
			// 
			this.lbMetodoEscalarProp.AutoSize = true;
			this.lbMetodoEscalarProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMetodoEscalarProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbMetodoEscalarProp.Location = new System.Drawing.Point(0, 66);
			this.lbMetodoEscalarProp.Name = "lbMetodoEscalarProp";
			this.lbMetodoEscalarProp.Size = new System.Drawing.Size(152, 13);
			this.lbMetodoEscalarProp.TabIndex = 16;
			this.lbMetodoEscalarProp.Text = "Método escalar a invocar:";
			// 
			// txClaseProp
			// 
			this.txClaseProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.txClaseProp.Location = new System.Drawing.Point(0, 46);
			this.txClaseProp.Name = "txClaseProp";
			this.txClaseProp.Size = new System.Drawing.Size(372, 20);
			this.txClaseProp.TabIndex = 15;
			this.txClaseProp.Validated += new System.EventHandler(this.TxClasePropValidated);
			// 
			// lbClaseProp
			// 
			this.lbClaseProp.AutoSize = true;
			this.lbClaseProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbClaseProp.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbClaseProp.Location = new System.Drawing.Point(0, 33);
			this.lbClaseProp.Name = "lbClaseProp";
			this.lbClaseProp.Size = new System.Drawing.Size(95, 13);
			this.lbClaseProp.TabIndex = 14;
			this.lbClaseProp.Text = "Clase a invocar:";
			// 
			// txTituloProp
			// 
			this.txTituloProp.Dock = System.Windows.Forms.DockStyle.Top;
			this.txTituloProp.Location = new System.Drawing.Point(0, 13);
			this.txTituloProp.Name = "txTituloProp";
			this.txTituloProp.Size = new System.Drawing.Size(372, 20);
			this.txTituloProp.TabIndex = 13;
			this.txTituloProp.Validated += new System.EventHandler(this.TxTituloPropValidated);
			// 
			// lbTitulo
			// 
			this.lbTitulo.AutoSize = true;
			this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitulo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
			this.lbTitulo.Location = new System.Drawing.Point(0, 0);
			this.lbTitulo.Name = "lbTitulo";
			this.lbTitulo.Size = new System.Drawing.Size(42, 13);
			this.lbTitulo.TabIndex = 10;
			this.lbTitulo.Text = "Título:";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// controlArbolGruposActividad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "controlArbolGruposActividad";
			this.Size = new System.Drawing.Size(577, 454);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tpComent.ResumeLayout(false);
			this.tpComent.PerformLayout();
			this.tpProps.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbSelector;
		private System.Windows.Forms.ToolStripButton tsbPegarProp;
		private System.Windows.Forms.ToolStripButton tsbCopiarProp;
		private System.Windows.Forms.Label lbTitulo;
		private System.Windows.Forms.TextBox txTituloProp;
		private System.Windows.Forms.Label lbClaseProp;
		private System.Windows.Forms.TextBox txClaseProp;
		private System.Windows.Forms.Label lbMetodoEscalarProp;
		private System.Windows.Forms.TextBox txMetodoEscalarProp;
		private System.Windows.Forms.Label lbMetodoDataSetProp;
		private System.Windows.Forms.TextBox txMetodoDataSetProp;
		private System.Windows.Forms.Label lbTituloDataSetProp;
		private System.Windows.Forms.TextBox txTituloDataSetProp;
		private System.Windows.Forms.Label lbValorDefEscalarProp;
		private System.Windows.Forms.TextBox txValorDefEscalarProp;
		private System.Windows.Forms.Label lbFormatoEscalarProp;
		private System.Windows.Forms.TextBox txFormatoEscalarProp;
		private System.Windows.Forms.Label lbFormatoPresentacionProp;
		private System.Windows.Forms.TextBox txFormatoPresentacionProp;
		private System.Windows.Forms.Label lbGrupoProp;
		private System.Windows.Forms.ComboBox cbGrupoProp;
		private System.Windows.Forms.Label lbComportamientoProp;
		private System.Windows.Forms.ComboBox cbComportamientoProp;
		private System.Windows.Forms.Label lbDescProp;
		private System.Windows.Forms.TextBox txDescProp;
		private System.Windows.Forms.ToolStripButton tsbBajarProp;
		private System.Windows.Forms.ToolStripButton tsbSubirProp;
		private System.Windows.Forms.ToolStripButton tsbBorrarProp;
		private System.Windows.Forms.ToolStripButton tsbNuevaProp;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.CheckedListBox lProps;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabPage tpProps;
		private System.Windows.Forms.TextBox txComent;
		private System.Windows.Forms.TabPage tpComent;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbDesc;
		private System.Windows.Forms.TextBox txDesc;
		private System.Windows.Forms.Panel panel1;
	}
}
