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
	partial class controlAutoSincro : System.Windows.Forms.UserControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlAutoSincro));
			this.tcAutoSincro = new System.Windows.Forms.TabControl();
			this.tpAutoSincro = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txProgreso = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslMsg = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbBwd = new System.Windows.Forms.ToolStripButton();
			this.tsbPlay = new System.Windows.Forms.ToolStripButton();
			this.tsbFwd = new System.Windows.Forms.ToolStripButton();
			this.tsbStop = new System.Windows.Forms.ToolStripButton();
			this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
			this.tpOpciones = new System.Windows.Forms.TabPage();
			this.gbCmdEditar = new System.Windows.Forms.GroupBox();
			this.opOmitCmdEditar = new System.Windows.Forms.RadioButton();
			this.opCountCmdEditar = new System.Windows.Forms.RadioButton();
			this.opDataCmdEditar = new System.Windows.Forms.RadioButton();
			this.gbCmdComparar = new System.Windows.Forms.GroupBox();
			this.opOmitCmdComparar = new System.Windows.Forms.RadioButton();
			this.opCountCmdComparar = new System.Windows.Forms.RadioButton();
			this.opDataCmdComparar = new System.Windows.Forms.RadioButton();
			this.gbCmdSel = new System.Windows.Forms.GroupBox();
			this.opOmitCmdSel = new System.Windows.Forms.RadioButton();
			this.opCountCmdSel = new System.Windows.Forms.RadioButton();
			this.opDataCmdSel = new System.Windows.Forms.RadioButton();
			this.gbOpTareas = new System.Windows.Forms.GroupBox();
			this.ckOmitPostSincro = new System.Windows.Forms.CheckBox();
			this.ckOmitPreSincro = new System.Windows.Forms.CheckBox();
			this.ckOmitComplemento = new System.Windows.Forms.CheckBox();
			this.ckInfoTarea = new System.Windows.Forms.CheckBox();
			this.ckInfoOperacion = new System.Windows.Forms.CheckBox();
			this.tcAutoSincro.SuspendLayout();
			this.tpAutoSincro.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tpOpciones.SuspendLayout();
			this.gbCmdEditar.SuspendLayout();
			this.gbCmdComparar.SuspendLayout();
			this.gbCmdSel.SuspendLayout();
			this.gbOpTareas.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcAutoSincro
			// 
			this.tcAutoSincro.Controls.Add(this.tpAutoSincro);
			this.tcAutoSincro.Controls.Add(this.tpOpciones);
			this.tcAutoSincro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcAutoSincro.Location = new System.Drawing.Point(0, 0);
			this.tcAutoSincro.Name = "tcAutoSincro";
			this.tcAutoSincro.SelectedIndex = 0;
			this.tcAutoSincro.Size = new System.Drawing.Size(674, 514);
			this.tcAutoSincro.TabIndex = 0;
			// 
			// tpAutoSincro
			// 
			this.tpAutoSincro.Controls.Add(this.splitContainer1);
			this.tpAutoSincro.Controls.Add(this.statusStrip1);
			this.tpAutoSincro.Controls.Add(this.toolStrip1);
			this.tpAutoSincro.Location = new System.Drawing.Point(4, 22);
			this.tpAutoSincro.Name = "tpAutoSincro";
			this.tpAutoSincro.Padding = new System.Windows.Forms.Padding(3);
			this.tpAutoSincro.Size = new System.Drawing.Size(666, 488);
			this.tpAutoSincro.TabIndex = 0;
			this.tpAutoSincro.Text = "Ejecución automática de la sincronización";
			this.tpAutoSincro.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 28);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.txProgreso);
			this.splitContainer1.Size = new System.Drawing.Size(660, 435);
			this.splitContainer1.SplitterDistance = 220;
			this.splitContainer1.TabIndex = 3;
			// 
			// txProgreso
			// 
			this.txProgreso.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.txProgreso.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txProgreso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txProgreso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txProgreso.Location = new System.Drawing.Point(0, 0);
			this.txProgreso.Multiline = true;
			this.txProgreso.Name = "txProgreso";
			this.txProgreso.ReadOnly = true;
			this.txProgreso.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txProgreso.Size = new System.Drawing.Size(660, 220);
			this.txProgreso.TabIndex = 2;
			this.txProgreso.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxProgresoKeyUp);
			this.txProgreso.TextChanged += new System.EventHandler(this.TxProgresoTextChanged);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsslMsg});
			this.statusStrip1.Location = new System.Drawing.Point(3, 463);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(660, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslMsg
			// 
			this.tsslMsg.Name = "tsslMsg";
			this.tsslMsg.Size = new System.Drawing.Size(29, 17);
			this.tsslMsg.Text = "Listo";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsbBwd,
									this.tsbPlay,
									this.tsbFwd,
									this.tsbStop,
									this.tsbRefresh});
			this.toolStrip1.Location = new System.Drawing.Point(3, 3);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(660, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbBwd
			// 
			this.tsbBwd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbBwd.Image = ((System.Drawing.Image)(resources.GetObject("tsbBwd.Image")));
			this.tsbBwd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbBwd.Name = "tsbBwd";
			this.tsbBwd.Size = new System.Drawing.Size(23, 22);
			this.tsbBwd.Text = "Retroceder";
			this.tsbBwd.ToolTipText = "Retroceder (RePag, Izquierda o Arriba)";
			this.tsbBwd.Click += new System.EventHandler(this.TsbBwdClick);
			// 
			// tsbPlay
			// 
			this.tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPlay.Image = ((System.Drawing.Image)(resources.GetObject("tsbPlay.Image")));
			this.tsbPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPlay.Name = "tsbPlay";
			this.tsbPlay.Size = new System.Drawing.Size(23, 22);
			this.tsbPlay.Text = "Ejecutar";
			this.tsbPlay.ToolTipText = "Ejecutar (F5)";
			this.tsbPlay.Click += new System.EventHandler(this.TsbPlayClick);
			// 
			// tsbFwd
			// 
			this.tsbFwd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbFwd.Image = ((System.Drawing.Image)(resources.GetObject("tsbFwd.Image")));
			this.tsbFwd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbFwd.Name = "tsbFwd";
			this.tsbFwd.Size = new System.Drawing.Size(23, 22);
			this.tsbFwd.Text = "Continuar";
			this.tsbFwd.ToolTipText = "Continuar (AvPag, Derecha o Abajo)";
			this.tsbFwd.Click += new System.EventHandler(this.TsbFwdClick);
			// 
			// tsbStop
			// 
			this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
			this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbStop.Name = "tsbStop";
			this.tsbStop.Size = new System.Drawing.Size(23, 22);
			this.tsbStop.Text = "Detener";
			this.tsbStop.Click += new System.EventHandler(this.TsbStopClick);
			// 
			// tsbRefresh
			// 
			this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
			this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRefresh.Name = "tsbRefresh";
			this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
			this.tsbRefresh.Text = "Incorporar cambios en el modelo de sincronización";
			this.tsbRefresh.Click += new System.EventHandler(this.TsbRefreshClick);
			// 
			// tpOpciones
			// 
			this.tpOpciones.Controls.Add(this.gbCmdEditar);
			this.tpOpciones.Controls.Add(this.gbCmdComparar);
			this.tpOpciones.Controls.Add(this.gbCmdSel);
			this.tpOpciones.Controls.Add(this.gbOpTareas);
			this.tpOpciones.Location = new System.Drawing.Point(4, 22);
			this.tpOpciones.Name = "tpOpciones";
			this.tpOpciones.Padding = new System.Windows.Forms.Padding(3);
			this.tpOpciones.Size = new System.Drawing.Size(666, 488);
			this.tpOpciones.TabIndex = 1;
			this.tpOpciones.Text = "Opciones de ejecución automática";
			this.tpOpciones.UseVisualStyleBackColor = true;
			// 
			// gbCmdEditar
			// 
			this.gbCmdEditar.Controls.Add(this.opOmitCmdEditar);
			this.gbCmdEditar.Controls.Add(this.opCountCmdEditar);
			this.gbCmdEditar.Controls.Add(this.opDataCmdEditar);
			this.gbCmdEditar.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbCmdEditar.Location = new System.Drawing.Point(3, 245);
			this.gbCmdEditar.Name = "gbCmdEditar";
			this.gbCmdEditar.Size = new System.Drawing.Size(660, 69);
			this.gbCmdEditar.TabIndex = 14;
			this.gbCmdEditar.TabStop = false;
			this.gbCmdEditar.Text = "Comandos de edición manual";
			// 
			// opOmitCmdEditar
			// 
			this.opOmitCmdEditar.AutoSize = true;
			this.opOmitCmdEditar.Location = new System.Drawing.Point(6, 43);
			this.opOmitCmdEditar.Name = "opOmitCmdEditar";
			this.opOmitCmdEditar.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opOmitCmdEditar.Size = new System.Drawing.Size(157, 17);
			this.opOmitCmdEditar.TabIndex = 12;
			this.opOmitCmdEditar.TabStop = true;
			this.opOmitCmdEditar.Text = "No realizar ninguna acción";
			this.opOmitCmdEditar.UseVisualStyleBackColor = true;
			this.opOmitCmdEditar.CheckedChanged += new System.EventHandler(this.OpOmitCmdEditarCheckedChanged);
			// 
			// opCountCmdEditar
			// 
			this.opCountCmdEditar.AutoSize = true;
			this.opCountCmdEditar.Location = new System.Drawing.Point(243, 20);
			this.opCountCmdEditar.Name = "opCountCmdEditar";
			this.opCountCmdEditar.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opCountCmdEditar.Size = new System.Drawing.Size(253, 17);
			this.opCountCmdEditar.TabIndex = 11;
			this.opCountCmdEditar.TabStop = true;
			this.opCountCmdEditar.Text = "Informar del número de registros recuperados";
			this.opCountCmdEditar.UseVisualStyleBackColor = true;
			this.opCountCmdEditar.CheckedChanged += new System.EventHandler(this.OpCountCmdEditarCheckedChanged);
			// 
			// opDataCmdEditar
			// 
			this.opDataCmdEditar.AutoSize = true;
			this.opDataCmdEditar.Location = new System.Drawing.Point(6, 20);
			this.opDataCmdEditar.Name = "opDataCmdEditar";
			this.opDataCmdEditar.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opDataCmdEditar.Size = new System.Drawing.Size(185, 17);
			this.opDataCmdEditar.TabIndex = 10;
			this.opDataCmdEditar.TabStop = true;
			this.opDataCmdEditar.Text = "Mostrar el conjunto de registros";
			this.opDataCmdEditar.UseVisualStyleBackColor = true;
			this.opDataCmdEditar.CheckedChanged += new System.EventHandler(this.OpDataCmdEditarCheckedChanged);
			// 
			// gbCmdComparar
			// 
			this.gbCmdComparar.Controls.Add(this.opOmitCmdComparar);
			this.gbCmdComparar.Controls.Add(this.opCountCmdComparar);
			this.gbCmdComparar.Controls.Add(this.opDataCmdComparar);
			this.gbCmdComparar.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbCmdComparar.Location = new System.Drawing.Point(3, 176);
			this.gbCmdComparar.Name = "gbCmdComparar";
			this.gbCmdComparar.Size = new System.Drawing.Size(660, 69);
			this.gbCmdComparar.TabIndex = 13;
			this.gbCmdComparar.TabStop = false;
			this.gbCmdComparar.Text = "Comandos de comprobación";
			// 
			// opOmitCmdComparar
			// 
			this.opOmitCmdComparar.AutoSize = true;
			this.opOmitCmdComparar.Location = new System.Drawing.Point(6, 43);
			this.opOmitCmdComparar.Name = "opOmitCmdComparar";
			this.opOmitCmdComparar.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opOmitCmdComparar.Size = new System.Drawing.Size(157, 17);
			this.opOmitCmdComparar.TabIndex = 9;
			this.opOmitCmdComparar.TabStop = true;
			this.opOmitCmdComparar.Text = "No realizar ninguna acción";
			this.opOmitCmdComparar.UseVisualStyleBackColor = true;
			this.opOmitCmdComparar.CheckedChanged += new System.EventHandler(this.OpOmitCmdCompararCheckedChanged);
			// 
			// opCountCmdComparar
			// 
			this.opCountCmdComparar.AutoSize = true;
			this.opCountCmdComparar.Location = new System.Drawing.Point(243, 20);
			this.opCountCmdComparar.Name = "opCountCmdComparar";
			this.opCountCmdComparar.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opCountCmdComparar.Size = new System.Drawing.Size(253, 17);
			this.opCountCmdComparar.TabIndex = 8;
			this.opCountCmdComparar.TabStop = true;
			this.opCountCmdComparar.Text = "Informar del número de registros recuperados";
			this.opCountCmdComparar.UseVisualStyleBackColor = true;
			this.opCountCmdComparar.CheckedChanged += new System.EventHandler(this.OpCountCmdCompararCheckedChanged);
			// 
			// opDataCmdComparar
			// 
			this.opDataCmdComparar.AutoSize = true;
			this.opDataCmdComparar.Location = new System.Drawing.Point(6, 20);
			this.opDataCmdComparar.Name = "opDataCmdComparar";
			this.opDataCmdComparar.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opDataCmdComparar.Size = new System.Drawing.Size(185, 17);
			this.opDataCmdComparar.TabIndex = 7;
			this.opDataCmdComparar.TabStop = true;
			this.opDataCmdComparar.Text = "Mostrar el conjunto de registros";
			this.opDataCmdComparar.UseVisualStyleBackColor = true;
			this.opDataCmdComparar.CheckedChanged += new System.EventHandler(this.OpDataCmdCompararCheckedChanged);
			// 
			// gbCmdSel
			// 
			this.gbCmdSel.Controls.Add(this.opOmitCmdSel);
			this.gbCmdSel.Controls.Add(this.opCountCmdSel);
			this.gbCmdSel.Controls.Add(this.opDataCmdSel);
			this.gbCmdSel.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbCmdSel.Location = new System.Drawing.Point(3, 107);
			this.gbCmdSel.Name = "gbCmdSel";
			this.gbCmdSel.Size = new System.Drawing.Size(660, 69);
			this.gbCmdSel.TabIndex = 12;
			this.gbCmdSel.TabStop = false;
			this.gbCmdSel.Text = "Comandos de selección";
			// 
			// opOmitCmdSel
			// 
			this.opOmitCmdSel.AutoSize = true;
			this.opOmitCmdSel.Location = new System.Drawing.Point(6, 43);
			this.opOmitCmdSel.Name = "opOmitCmdSel";
			this.opOmitCmdSel.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opOmitCmdSel.Size = new System.Drawing.Size(157, 17);
			this.opOmitCmdSel.TabIndex = 6;
			this.opOmitCmdSel.TabStop = true;
			this.opOmitCmdSel.Text = "No realizar ninguna acción";
			this.opOmitCmdSel.UseVisualStyleBackColor = true;
			this.opOmitCmdSel.CheckedChanged += new System.EventHandler(this.OpOmitCmdSelCheckedChanged);
			// 
			// opCountCmdSel
			// 
			this.opCountCmdSel.AutoSize = true;
			this.opCountCmdSel.Location = new System.Drawing.Point(243, 20);
			this.opCountCmdSel.Name = "opCountCmdSel";
			this.opCountCmdSel.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opCountCmdSel.Size = new System.Drawing.Size(253, 17);
			this.opCountCmdSel.TabIndex = 5;
			this.opCountCmdSel.TabStop = true;
			this.opCountCmdSel.Text = "Informar del número de registros recuperados";
			this.opCountCmdSel.UseVisualStyleBackColor = true;
			this.opCountCmdSel.CheckedChanged += new System.EventHandler(this.OpCountCmdSelCheckedChanged);
			// 
			// opDataCmdSel
			// 
			this.opDataCmdSel.AutoSize = true;
			this.opDataCmdSel.Location = new System.Drawing.Point(6, 20);
			this.opDataCmdSel.Name = "opDataCmdSel";
			this.opDataCmdSel.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.opDataCmdSel.Size = new System.Drawing.Size(185, 17);
			this.opDataCmdSel.TabIndex = 4;
			this.opDataCmdSel.TabStop = true;
			this.opDataCmdSel.Text = "Mostrar el conjunto de registros";
			this.opDataCmdSel.UseVisualStyleBackColor = true;
			this.opDataCmdSel.CheckedChanged += new System.EventHandler(this.OpDataCmdSelCheckedChanged);
			// 
			// gbOpTareas
			// 
			this.gbOpTareas.Controls.Add(this.ckOmitPostSincro);
			this.gbOpTareas.Controls.Add(this.ckOmitPreSincro);
			this.gbOpTareas.Controls.Add(this.ckOmitComplemento);
			this.gbOpTareas.Controls.Add(this.ckInfoTarea);
			this.gbOpTareas.Controls.Add(this.ckInfoOperacion);
			this.gbOpTareas.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbOpTareas.Location = new System.Drawing.Point(3, 3);
			this.gbOpTareas.Name = "gbOpTareas";
			this.gbOpTareas.Size = new System.Drawing.Size(660, 104);
			this.gbOpTareas.TabIndex = 7;
			this.gbOpTareas.TabStop = false;
			this.gbOpTareas.Text = "Operaciones y Tareas";
			// 
			// ckOmitPostSincro
			// 
			this.ckOmitPostSincro.AutoSize = true;
			this.ckOmitPostSincro.Location = new System.Drawing.Point(243, 43);
			this.ckOmitPostSincro.Name = "ckOmitPostSincro";
			this.ckOmitPostSincro.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.ckOmitPostSincro.Size = new System.Drawing.Size(225, 17);
			this.ckOmitPostSincro.TabIndex = 6;
			this.ckOmitPostSincro.Text = "Omitir tareas de comprobación posterior";
			this.ckOmitPostSincro.UseVisualStyleBackColor = true;
			this.ckOmitPostSincro.CheckedChanged += new System.EventHandler(this.CkOmitPostSincroCheckedChanged);
			// 
			// ckOmitPreSincro
			// 
			this.ckOmitPreSincro.AutoSize = true;
			this.ckOmitPreSincro.Location = new System.Drawing.Point(6, 43);
			this.ckOmitPreSincro.Name = "ckOmitPreSincro";
			this.ckOmitPreSincro.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.ckOmitPreSincro.Size = new System.Drawing.Size(212, 17);
			this.ckOmitPreSincro.TabIndex = 5;
			this.ckOmitPreSincro.Text = "Omitir tareas de comprobación previa";
			this.ckOmitPreSincro.UseVisualStyleBackColor = true;
			this.ckOmitPreSincro.CheckedChanged += new System.EventHandler(this.CkOmitPreSincroCheckedChanged);
			// 
			// ckOmitComplemento
			// 
			this.ckOmitComplemento.AutoSize = true;
			this.ckOmitComplemento.Location = new System.Drawing.Point(6, 66);
			this.ckOmitComplemento.Name = "ckOmitComplemento";
			this.ckOmitComplemento.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.ckOmitComplemento.Size = new System.Drawing.Size(178, 17);
			this.ckOmitComplemento.TabIndex = 4;
			this.ckOmitComplemento.Text = "Omitir tareas complementarias";
			this.ckOmitComplemento.UseVisualStyleBackColor = true;
			this.ckOmitComplemento.CheckedChanged += new System.EventHandler(this.CkOmitComplementoCheckedChanged);
			// 
			// ckInfoTarea
			// 
			this.ckInfoTarea.AutoSize = true;
			this.ckInfoTarea.Location = new System.Drawing.Point(243, 20);
			this.ckInfoTarea.Name = "ckInfoTarea";
			this.ckInfoTarea.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.ckInfoTarea.Size = new System.Drawing.Size(210, 17);
			this.ckInfoTarea.TabIndex = 3;
			this.ckInfoTarea.Text = "Informar cuando comience una tarea";
			this.ckInfoTarea.UseVisualStyleBackColor = true;
			this.ckInfoTarea.CheckedChanged += new System.EventHandler(this.CkInfoTareaCheckedChanged);
			// 
			// ckInfoOperacion
			// 
			this.ckInfoOperacion.AutoSize = true;
			this.ckInfoOperacion.Location = new System.Drawing.Point(6, 20);
			this.ckInfoOperacion.Name = "ckInfoOperacion";
			this.ckInfoOperacion.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.ckInfoOperacion.Size = new System.Drawing.Size(231, 17);
			this.ckInfoOperacion.TabIndex = 1;
			this.ckInfoOperacion.Text = "Informar cuando comience una operación";
			this.ckInfoOperacion.UseVisualStyleBackColor = true;
			this.ckInfoOperacion.CheckedChanged += new System.EventHandler(this.CkInfoOperacionCheckedChanged);
			// 
			// controlAutoSincro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tcAutoSincro);
			this.Name = "controlAutoSincro";
			this.Size = new System.Drawing.Size(674, 514);
			this.tcAutoSincro.ResumeLayout(false);
			this.tpAutoSincro.ResumeLayout(false);
			this.tpAutoSincro.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tpOpciones.ResumeLayout(false);
			this.gbCmdEditar.ResumeLayout(false);
			this.gbCmdEditar.PerformLayout();
			this.gbCmdComparar.ResumeLayout(false);
			this.gbCmdComparar.PerformLayout();
			this.gbCmdSel.ResumeLayout(false);
			this.gbCmdSel.PerformLayout();
			this.gbOpTareas.ResumeLayout(false);
			this.gbOpTareas.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripButton tsbBwd;
		private System.Windows.Forms.ToolStripButton tsbRefresh;
		private System.Windows.Forms.ToolStripButton tsbFwd;
		private System.Windows.Forms.ToolStripStatusLabel tsslMsg;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TextBox txProgreso;
		private System.Windows.Forms.RadioButton opOmitCmdSel;
		private System.Windows.Forms.RadioButton opOmitCmdEditar;
		private System.Windows.Forms.RadioButton opOmitCmdComparar;
		private System.Windows.Forms.CheckBox ckOmitPreSincro;
		private System.Windows.Forms.CheckBox ckOmitPostSincro;
		private System.Windows.Forms.GroupBox gbOpTareas;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripButton tsbStop;
		private System.Windows.Forms.ToolStripButton tsbPlay;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.RadioButton opCountCmdEditar;
		private System.Windows.Forms.RadioButton opDataCmdComparar;
		private System.Windows.Forms.RadioButton opCountCmdComparar;
		private System.Windows.Forms.RadioButton opDataCmdEditar;
		private System.Windows.Forms.GroupBox gbCmdEditar;
		private System.Windows.Forms.CheckBox ckOmitComplemento;
		private System.Windows.Forms.GroupBox gbCmdComparar;
		private System.Windows.Forms.CheckBox ckInfoTarea;
		private System.Windows.Forms.RadioButton opDataCmdSel;
		private System.Windows.Forms.RadioButton opCountCmdSel;
		private System.Windows.Forms.GroupBox gbCmdSel;
		private System.Windows.Forms.CheckBox ckInfoOperacion;
		private System.Windows.Forms.TabPage tpOpciones;
		private System.Windows.Forms.TabPage tpAutoSincro;
		private System.Windows.Forms.TabControl tcAutoSincro;
	}
}
