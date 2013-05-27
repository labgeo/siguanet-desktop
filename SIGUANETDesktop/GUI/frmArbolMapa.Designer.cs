/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 21/09/2006
 * Time: 9:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop.GUI
{
	partial class frmArbolMapa : System.Windows.Forms.Form
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
			SharpMap.Map map1 = new SharpMap.Map();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArbolMapa));
			System.Drawing.Drawing2D.Matrix matrix1 = new System.Drawing.Drawing2D.Matrix();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpNavegador = new System.Windows.Forms.TabPage();
			this.twNavegador = new System.Windows.Forms.TreeView();
			this.tpInfo = new System.Windows.Forms.TabPage();
			this.listInfo = new System.Windows.Forms.ListView();
			this.cPropiedad = new System.Windows.Forms.ColumnHeader();
			this.cValor = new System.Windows.Forms.ColumnHeader();
			this.tabPanelMDL = new System.Windows.Forms.TabControl();
			this.tpMapa = new System.Windows.Forms.TabPage();
			this.miVMapa = new SIGUANETDesktop.GUI.controlMapView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbZoomTodo = new System.Windows.Forms.ToolStripButton();
			this.tsbAcercar = new System.Windows.Forms.ToolStripButton();
			this.tsbAlejar = new System.Windows.Forms.ToolStripButton();
			this.tsbPan = new System.Windows.Forms.ToolStripButton();
			this.tsbInfo = new System.Windows.Forms.ToolStripButton();
			this.tpLeyenda = new System.Windows.Forms.TabPage();
			this.panelLeyenda = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lPaletaDinamica = new System.Windows.Forms.Label();
			this.cbPaletaDinamica = new System.Windows.Forms.ComboBox();
			this.chTrama = new System.Windows.Forms.CheckBox();
			this.rbTemaAdscripcion = new System.Windows.Forms.RadioButton();
			this.rbTemaUso = new System.Windows.Forms.RadioButton();
			this.rbPredeterminado = new System.Windows.Forms.RadioButton();
			this.tpPDF = new System.Windows.Forms.TabPage();
			this.Preview = new PdfSharp.Forms.PagePreview();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tsbPDFRefrescar = new System.Windows.Forms.ToolStripButton();
			this.tsbPDFGuardar = new System.Windows.Forms.ToolStripButton();
			this.tsbPDFZoomTodo = new System.Windows.Forms.ToolStripButton();
			this.tsbPDFAcercar = new System.Windows.Forms.ToolStripButton();
			this.tsbPDFAlejar = new System.Windows.Forms.ToolStripButton();
			this.tsbPDFImprimir = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbPDFLeyenda = new System.Windows.Forms.ToolStripButton();
			this.tpDatos = new System.Windows.Forms.TabPage();
			this.dg = new System.Windows.Forms.DataGridView();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslNumFilas = new System.Windows.Forms.ToolStripStatusLabel();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpNavegador.SuspendLayout();
			this.tpInfo.SuspendLayout();
			this.tabPanelMDL.SuspendLayout();
			this.tpMapa.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tpLeyenda.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tpPDF.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.tpDatos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
			this.statusStrip1.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabPanelMDL);
			this.splitContainer1.Size = new System.Drawing.Size(661, 539);
			this.splitContainer1.SplitterDistance = 220;
			this.splitContainer1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpNavegador);
			this.tabControl1.Controls.Add(this.tpInfo);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(220, 539);
			this.tabControl1.TabIndex = 0;
			// 
			// tpNavegador
			// 
			this.tpNavegador.Controls.Add(this.twNavegador);
			this.tpNavegador.Location = new System.Drawing.Point(4, 22);
			this.tpNavegador.Name = "tpNavegador";
			this.tpNavegador.Padding = new System.Windows.Forms.Padding(3);
			this.tpNavegador.Size = new System.Drawing.Size(212, 513);
			this.tpNavegador.TabIndex = 0;
			this.tpNavegador.Text = "Navegador";
			this.tpNavegador.UseVisualStyleBackColor = true;
			// 
			// twNavegador
			// 
			this.twNavegador.Dock = System.Windows.Forms.DockStyle.Fill;
			this.twNavegador.HideSelection = false;
			this.twNavegador.Location = new System.Drawing.Point(3, 3);
			this.twNavegador.Name = "twNavegador";
			this.twNavegador.Size = new System.Drawing.Size(206, 507);
			this.twNavegador.TabIndex = 0;
			this.twNavegador.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SeleccionarNodo);
			// 
			// tpInfo
			// 
			this.tpInfo.Controls.Add(this.listInfo);
			this.tpInfo.Location = new System.Drawing.Point(4, 22);
			this.tpInfo.Name = "tpInfo";
			this.tpInfo.Padding = new System.Windows.Forms.Padding(3);
			this.tpInfo.Size = new System.Drawing.Size(212, 513);
			this.tpInfo.TabIndex = 1;
			this.tpInfo.Text = "Información";
			this.tpInfo.UseVisualStyleBackColor = true;
			// 
			// listInfo
			// 
			this.listInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.cPropiedad,
									this.cValor});
			this.listInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listInfo.Location = new System.Drawing.Point(3, 3);
			this.listInfo.Name = "listInfo";
			this.listInfo.Size = new System.Drawing.Size(206, 507);
			this.listInfo.TabIndex = 0;
			this.listInfo.UseCompatibleStateImageBehavior = false;
			this.listInfo.View = System.Windows.Forms.View.Details;
			// 
			// cPropiedad
			// 
			this.cPropiedad.Text = "Propiedad";
			this.cPropiedad.Width = 98;
			// 
			// cValor
			// 
			this.cValor.Text = "Valor";
			this.cValor.Width = 103;
			// 
			// tabPanelMDL
			// 
			this.tabPanelMDL.Controls.Add(this.tpMapa);
			this.tabPanelMDL.Controls.Add(this.tpLeyenda);
			this.tabPanelMDL.Controls.Add(this.tpPDF);
			this.tabPanelMDL.Controls.Add(this.tpDatos);
			this.tabPanelMDL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPanelMDL.Location = new System.Drawing.Point(0, 0);
			this.tabPanelMDL.Name = "tabPanelMDL";
			this.tabPanelMDL.SelectedIndex = 0;
			this.tabPanelMDL.Size = new System.Drawing.Size(437, 539);
			this.tabPanelMDL.TabIndex = 0;
			// 
			// tpMapa
			// 
			this.tpMapa.Controls.Add(this.miVMapa);
			this.tpMapa.Controls.Add(this.toolStrip1);
			this.tpMapa.Location = new System.Drawing.Point(4, 22);
			this.tpMapa.Name = "tpMapa";
			this.tpMapa.Padding = new System.Windows.Forms.Padding(3);
			this.tpMapa.Size = new System.Drawing.Size(429, 513);
			this.tpMapa.TabIndex = 0;
			this.tpMapa.Text = "Mapa";
			this.tpMapa.UseVisualStyleBackColor = true;
			// 
			// miVMapa
			// 
			this.miVMapa.ActiveTool = SIGUANETDesktop.GUI.controlMapView.Tools.None;
			this.miVMapa.Dock = System.Windows.Forms.DockStyle.Fill;
			this.miVMapa.Location = new System.Drawing.Point(3, 35);
			map1.BackColor = System.Drawing.Color.Transparent;
			map1.Center = ((SharpMap.Geometries.Point)(resources.GetObject("map1.Center")));
			map1.Layers = ((System.Collections.Generic.List<SharpMap.Layers.ILayer>)(resources.GetObject("map1.Layers")));
			map1.MapTransform = matrix1;
			map1.MaximumZoom = 1.7976931348623157E+308;
			map1.MinimumZoom = 0;
			map1.PixelAspectRatio = 1;
			map1.Size = new System.Drawing.Size(150, 150);
			map1.Zoom = 1;
			this.miVMapa.Map = map1;
			this.miVMapa.Name = "miVMapa";
			this.miVMapa.QueryLayerIndex = 0;
			this.miVMapa.Size = new System.Drawing.Size(423, 475);
			this.miVMapa.TabIndex = 5;
			this.miVMapa.MouseUp += new SIGUANETDesktop.GUI.controlMapView.MouseEventHandler(this.eMouseUp);
			this.miVMapa.MapQueried += new SIGUANETDesktop.GUI.controlMapView.MapQueryHandler(this.eConsulta);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsbZoomTodo,
									this.tsbAcercar,
									this.tsbAlejar,
									this.tsbPan,
									this.tsbInfo});
			this.toolStrip1.Location = new System.Drawing.Point(3, 3);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(423, 32);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbZoomTodo
			// 
			this.tsbZoomTodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbZoomTodo.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomTodo.Image")));
			this.tsbZoomTodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbZoomTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbZoomTodo.Name = "tsbZoomTodo";
			this.tsbZoomTodo.Size = new System.Drawing.Size(29, 29);
			this.tsbZoomTodo.Text = "Zoom a todo";
			this.tsbZoomTodo.ToolTipText = "Zoom a todo";
			this.tsbZoomTodo.Click += new System.EventHandler(this.eZoomTodo);
			// 
			// tsbAcercar
			// 
			this.tsbAcercar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAcercar.Image = ((System.Drawing.Image)(resources.GetObject("tsbAcercar.Image")));
			this.tsbAcercar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbAcercar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAcercar.Name = "tsbAcercar";
			this.tsbAcercar.Size = new System.Drawing.Size(29, 29);
			this.tsbAcercar.Text = "Acercar";
			this.tsbAcercar.ToolTipText = "Acercar";
			this.tsbAcercar.Click += new System.EventHandler(this.eAcercar);
			// 
			// tsbAlejar
			// 
			this.tsbAlejar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAlejar.Image = ((System.Drawing.Image)(resources.GetObject("tsbAlejar.Image")));
			this.tsbAlejar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbAlejar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAlejar.Name = "tsbAlejar";
			this.tsbAlejar.Size = new System.Drawing.Size(29, 29);
			this.tsbAlejar.Text = "Alejar";
			this.tsbAlejar.ToolTipText = "Alejar";
			this.tsbAlejar.Click += new System.EventHandler(this.eAlejar);
			// 
			// tsbPan
			// 
			this.tsbPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPan.Image = ((System.Drawing.Image)(resources.GetObject("tsbPan.Image")));
			this.tsbPan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbPan.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPan.Name = "tsbPan";
			this.tsbPan.Size = new System.Drawing.Size(29, 29);
			this.tsbPan.Text = "Desplazar";
			this.tsbPan.ToolTipText = "Desplazar";
			this.tsbPan.Click += new System.EventHandler(this.ePan);
			// 
			// tsbInfo
			// 
			this.tsbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbInfo.Image")));
			this.tsbInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbInfo.Name = "tsbInfo";
			this.tsbInfo.Size = new System.Drawing.Size(29, 29);
			this.tsbInfo.Text = "Información";
			this.tsbInfo.ToolTipText = "Información";
			this.tsbInfo.Click += new System.EventHandler(this.eInfo);
			// 
			// tpLeyenda
			// 
			this.tpLeyenda.Controls.Add(this.panelLeyenda);
			this.tpLeyenda.Controls.Add(this.groupBox1);
			this.tpLeyenda.Location = new System.Drawing.Point(4, 22);
			this.tpLeyenda.Name = "tpLeyenda";
			this.tpLeyenda.Size = new System.Drawing.Size(429, 513);
			this.tpLeyenda.TabIndex = 2;
			this.tpLeyenda.Text = "Leyenda";
			this.tpLeyenda.UseVisualStyleBackColor = true;
			// 
			// panelLeyenda
			// 
			this.panelLeyenda.BackColor = System.Drawing.Color.White;
			this.panelLeyenda.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelLeyenda.Location = new System.Drawing.Point(0, 102);
			this.panelLeyenda.Name = "panelLeyenda";
			this.panelLeyenda.Size = new System.Drawing.Size(429, 411);
			this.panelLeyenda.TabIndex = 1;
			this.panelLeyenda.Paint += new System.Windows.Forms.PaintEventHandler(this.pintaLeyenda);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lPaletaDinamica);
			this.groupBox1.Controls.Add(this.cbPaletaDinamica);
			this.groupBox1.Controls.Add(this.chTrama);
			this.groupBox1.Controls.Add(this.rbTemaAdscripcion);
			this.groupBox1.Controls.Add(this.rbTemaUso);
			this.groupBox1.Controls.Add(this.rbPredeterminado);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(429, 102);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tipos de Leyenda";
			// 
			// lPaletaDinamica
			// 
			this.lPaletaDinamica.Location = new System.Drawing.Point(167, 68);
			this.lPaletaDinamica.Name = "lPaletaDinamica";
			this.lPaletaDinamica.Size = new System.Drawing.Size(106, 16);
			this.lPaletaDinamica.TabIndex = 5;
			this.lPaletaDinamica.Text = "Seleccione paleta:";
			// 
			// cbPaletaDinamica
			// 
			this.cbPaletaDinamica.FormattingEnabled = true;
			this.cbPaletaDinamica.Location = new System.Drawing.Point(279, 65);
			this.cbPaletaDinamica.Name = "cbPaletaDinamica";
			this.cbPaletaDinamica.Size = new System.Drawing.Size(102, 21);
			this.cbPaletaDinamica.TabIndex = 4;
			this.cbPaletaDinamica.SelectedIndexChanged += new System.EventHandler(this.CambiarPaletaDinamica);
			// 
			// chTrama
			// 
			this.chTrama.Location = new System.Drawing.Point(171, 45);
			this.chTrama.Name = "chTrama";
			this.chTrama.Size = new System.Drawing.Size(102, 15);
			this.chTrama.TabIndex = 3;
			this.chTrama.Text = "Usar tramas";
			this.chTrama.UseVisualStyleBackColor = true;
			this.chTrama.CheckedChanged += new System.EventHandler(this.ChTramaCheckedChanged);
			// 
			// rbTemaAdscripcion
			// 
			this.rbTemaAdscripcion.AutoSize = true;
			this.rbTemaAdscripcion.Location = new System.Drawing.Point(17, 66);
			this.rbTemaAdscripcion.Name = "rbTemaAdscripcion";
			this.rbTemaAdscripcion.Size = new System.Drawing.Size(144, 17);
			this.rbTemaAdscripcion.TabIndex = 2;
			this.rbTemaAdscripcion.Text = "Temático por Adscripción";
			this.rbTemaAdscripcion.UseVisualStyleBackColor = true;
			this.rbTemaAdscripcion.CheckedChanged += new System.EventHandler(this.RbTemaAdscripcionCheckedChanged);
			// 
			// rbTemaUso
			// 
			this.rbTemaUso.AutoSize = true;
			this.rbTemaUso.Location = new System.Drawing.Point(17, 43);
			this.rbTemaUso.Name = "rbTemaUso";
			this.rbTemaUso.Size = new System.Drawing.Size(108, 17);
			this.rbTemaUso.TabIndex = 1;
			this.rbTemaUso.Text = "Temático por Uso";
			this.rbTemaUso.UseVisualStyleBackColor = true;
			this.rbTemaUso.CheckedChanged += new System.EventHandler(this.RbTemaUsoCheckedChanged);
			// 
			// rbPredeterminado
			// 
			this.rbPredeterminado.AutoSize = true;
			this.rbPredeterminado.Checked = true;
			this.rbPredeterminado.Location = new System.Drawing.Point(17, 20);
			this.rbPredeterminado.Name = "rbPredeterminado";
			this.rbPredeterminado.Size = new System.Drawing.Size(101, 17);
			this.rbPredeterminado.TabIndex = 0;
			this.rbPredeterminado.TabStop = true;
			this.rbPredeterminado.Text = "Predeterminada";
			this.rbPredeterminado.UseVisualStyleBackColor = true;
			this.rbPredeterminado.CheckedChanged += new System.EventHandler(this.RbPredeterminadoCheckedChanged);
			// 
			// tpPDF
			// 
			this.tpPDF.Controls.Add(this.Preview);
			this.tpPDF.Controls.Add(this.toolStrip2);
			this.tpPDF.Location = new System.Drawing.Point(4, 22);
			this.tpPDF.Name = "tpPDF";
			this.tpPDF.Size = new System.Drawing.Size(429, 513);
			this.tpPDF.TabIndex = 3;
			this.tpPDF.Text = "PDF";
			this.tpPDF.UseVisualStyleBackColor = true;
			// 
			// Preview
			// 
			this.Preview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Preview.DesktopColor = System.Drawing.SystemColors.ControlDark;
			this.Preview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Preview.Location = new System.Drawing.Point(0, 32);
			this.Preview.Name = "Preview";
			this.Preview.PageColor = System.Drawing.Color.GhostWhite;
			this.Preview.PageSize = new System.Drawing.Size(595, 842);
			this.Preview.Size = new System.Drawing.Size(429, 481);
			this.Preview.TabIndex = 3;
			this.Preview.Zoom = PdfSharp.Forms.Zoom.FullPage;
			this.Preview.ZoomPercent = 40;
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsbPDFRefrescar,
									this.tsbPDFGuardar,
									this.tsbPDFZoomTodo,
									this.tsbPDFAcercar,
									this.tsbPDFAlejar,
									this.tsbPDFImprimir,
									this.toolStripSeparator1,
									this.tsbPDFLeyenda});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(429, 32);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// tsbPDFRefrescar
			// 
			this.tsbPDFRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPDFRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("tsbPDFRefrescar.Image")));
			this.tsbPDFRefrescar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbPDFRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPDFRefrescar.Name = "tsbPDFRefrescar";
			this.tsbPDFRefrescar.Size = new System.Drawing.Size(26, 29);
			this.tsbPDFRefrescar.Text = "Refrescar";
			this.tsbPDFRefrescar.Click += new System.EventHandler(this.ePDFRefrescar);
			// 
			// tsbPDFGuardar
			// 
			this.tsbPDFGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPDFGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbPDFGuardar.Image")));
			this.tsbPDFGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbPDFGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPDFGuardar.Name = "tsbPDFGuardar";
			this.tsbPDFGuardar.Size = new System.Drawing.Size(28, 29);
			this.tsbPDFGuardar.Text = "Guardar";
			this.tsbPDFGuardar.Click += new System.EventHandler(this.ePDFGuardar);
			// 
			// tsbPDFZoomTodo
			// 
			this.tsbPDFZoomTodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPDFZoomTodo.Image = ((System.Drawing.Image)(resources.GetObject("tsbPDFZoomTodo.Image")));
			this.tsbPDFZoomTodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbPDFZoomTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPDFZoomTodo.Name = "tsbPDFZoomTodo";
			this.tsbPDFZoomTodo.Size = new System.Drawing.Size(29, 29);
			this.tsbPDFZoomTodo.Text = "Zoom a todo";
			this.tsbPDFZoomTodo.Click += new System.EventHandler(this.ePDFZoomTodo);
			// 
			// tsbPDFAcercar
			// 
			this.tsbPDFAcercar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPDFAcercar.Image = ((System.Drawing.Image)(resources.GetObject("tsbPDFAcercar.Image")));
			this.tsbPDFAcercar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbPDFAcercar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPDFAcercar.Name = "tsbPDFAcercar";
			this.tsbPDFAcercar.Size = new System.Drawing.Size(29, 29);
			this.tsbPDFAcercar.Text = "Acercar";
			this.tsbPDFAcercar.Click += new System.EventHandler(this.ePDFAcercar);
			// 
			// tsbPDFAlejar
			// 
			this.tsbPDFAlejar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPDFAlejar.Image = ((System.Drawing.Image)(resources.GetObject("tsbPDFAlejar.Image")));
			this.tsbPDFAlejar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbPDFAlejar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPDFAlejar.Name = "tsbPDFAlejar";
			this.tsbPDFAlejar.Size = new System.Drawing.Size(29, 29);
			this.tsbPDFAlejar.Text = "Alejar";
			this.tsbPDFAlejar.Click += new System.EventHandler(this.ePDFAlejar);
			// 
			// tsbPDFImprimir
			// 
			this.tsbPDFImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPDFImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsbPDFImprimir.Image")));
			this.tsbPDFImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbPDFImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPDFImprimir.Name = "tsbPDFImprimir";
			this.tsbPDFImprimir.Size = new System.Drawing.Size(29, 29);
			this.tsbPDFImprimir.Text = "Imprimir";
			this.tsbPDFImprimir.Click += new System.EventHandler(this.ePDFImprimir);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
			// 
			// tsbPDFLeyenda
			// 
			this.tsbPDFLeyenda.Checked = true;
			this.tsbPDFLeyenda.CheckOnClick = true;
			this.tsbPDFLeyenda.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tsbPDFLeyenda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPDFLeyenda.Image = ((System.Drawing.Image)(resources.GetObject("tsbPDFLeyenda.Image")));
			this.tsbPDFLeyenda.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPDFLeyenda.Name = "tsbPDFLeyenda";
			this.tsbPDFLeyenda.Size = new System.Drawing.Size(23, 29);
			this.tsbPDFLeyenda.Text = "Incluir leyenda";
			this.tsbPDFLeyenda.ToolTipText = "Incluir leyenda al imprimir o guardar";
			this.tsbPDFLeyenda.CheckedChanged += new System.EventHandler(this.ePDFLeyenda);
			// 
			// tpDatos
			// 
			this.tpDatos.Controls.Add(this.dg);
			this.tpDatos.Controls.Add(this.statusStrip1);
			this.tpDatos.Location = new System.Drawing.Point(4, 22);
			this.tpDatos.Name = "tpDatos";
			this.tpDatos.Padding = new System.Windows.Forms.Padding(3);
			this.tpDatos.Size = new System.Drawing.Size(429, 513);
			this.tpDatos.TabIndex = 1;
			this.tpDatos.Text = "Datos";
			this.tpDatos.UseVisualStyleBackColor = true;
			// 
			// dg
			// 
			this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dg.Location = new System.Drawing.Point(3, 3);
			this.dg.Name = "dg";
			this.dg.Size = new System.Drawing.Size(423, 485);
			this.dg.TabIndex = 2;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tslNumFilas});
			this.statusStrip1.Location = new System.Drawing.Point(3, 488);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(423, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tslNumFilas
			// 
			this.tslNumFilas.Name = "tslNumFilas";
			this.tslNumFilas.Size = new System.Drawing.Size(86, 17);
			this.tslNumFilas.Text = "No hay registros";
			// 
			// printDialog1
			// 
			this.printDialog1.UseEXDialog = true;
			// 
			// frmArbolMapa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 539);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmArbolMapa";
			this.Text = "SIGUANETDesktop TreeMAP - Visor Cartografico de datos SIGUANET";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tpNavegador.ResumeLayout(false);
			this.tpInfo.ResumeLayout(false);
			this.tabPanelMDL.ResumeLayout(false);
			this.tpMapa.ResumeLayout(false);
			this.tpMapa.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tpLeyenda.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tpPDF.ResumeLayout(false);
			this.tpPDF.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.tpDatos.ResumeLayout(false);
			this.tpDatos.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripStatusLabel tslNumFilas;
		private System.Windows.Forms.DataGridView dg;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripButton tsbPDFLeyenda;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripButton tsbPDFGuardar;
		private System.Windows.Forms.ToolStripButton tsbPDFRefrescar;
		private System.Windows.Forms.ToolStripButton tsbPDFZoomTodo;
		private System.Windows.Forms.ToolStripButton tsbPDFAcercar;
		private System.Windows.Forms.ToolStripButton tsbPDFAlejar;
		private System.Windows.Forms.ToolStripButton tsbPDFImprimir;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private PdfSharp.Forms.PagePreview Preview;
		private System.Windows.Forms.TabPage tpPDF;
		private System.Windows.Forms.ComboBox cbPaletaDinamica;
		private System.Windows.Forms.Label lPaletaDinamica;
		private System.Windows.Forms.CheckBox chTrama;
		private System.Windows.Forms.Panel panelLeyenda;
		private System.Windows.Forms.RadioButton rbPredeterminado;
		private System.Windows.Forms.RadioButton rbTemaUso;
		private System.Windows.Forms.RadioButton rbTemaAdscripcion;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolStripButton tsbInfo;
		private System.Windows.Forms.ToolStripButton tsbPan;
		private System.Windows.Forms.ToolStripButton tsbAlejar;
		private System.Windows.Forms.ToolStripButton tsbAcercar;
		private System.Windows.Forms.ToolStripButton tsbZoomTodo;
		private SIGUANETDesktop.GUI.controlMapView miVMapa;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.TabPage tpLeyenda;
		private System.Windows.Forms.TabPage tpDatos;
		private System.Windows.Forms.TabPage tpMapa;
		private System.Windows.Forms.TabControl tabPanelMDL;
		private System.Windows.Forms.ListView listInfo;
		private System.Windows.Forms.ColumnHeader cValor;
		private System.Windows.Forms.ColumnHeader cPropiedad;
		private System.Windows.Forms.TreeView twNavegador;
		private System.Windows.Forms.TabPage tpInfo;
		private System.Windows.Forms.TabPage tpNavegador;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
