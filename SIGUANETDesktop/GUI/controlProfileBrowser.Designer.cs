/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 15/05/2008
 * Hora: 8:37
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlProfileBrowser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlProfileBrowser));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpPersona = new System.Windows.Forms.TabPage();
			this.txPersona = new System.Windows.Forms.TextBox();
			this.lbPersona = new System.Windows.Forms.Label();
			this.tpDepartamento = new System.Windows.Forms.TabPage();
			this.txDepartamento = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tpPerfilPersonalizado = new System.Windows.Forms.TabPage();
			this.rbPublico = new System.Windows.Forms.RadioButton();
			this.rbUsuarios = new System.Windows.Forms.RadioButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lvUsuarios = new System.Windows.Forms.ListView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbWarning = new System.Windows.Forms.Label();
			this.txCaducidad = new System.Windows.Forms.TextBox();
			this.lbCaducidad = new System.Windows.Forms.Label();
			this.txDescripcion = new System.Windows.Forms.TextBox();
			this.lbDescripcion = new System.Windows.Forms.Label();
			this.txLocalizacion = new System.Windows.Forms.TextBox();
			this.lbLocalizacion = new System.Windows.Forms.Label();
			this.txPersonalizado = new System.Windows.Forms.TextBox();
			this.lbPersonalizado = new System.Windows.Forms.Label();
			this.txGenerico = new System.Windows.Forms.TextBox();
			this.lbGenerico = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lvPerfiles = new System.Windows.Forms.ListView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lbPerfiles = new System.Windows.Forms.Label();
			this.txNombreDpto = new System.Windows.Forms.TextBox();
			this.lbNombreDpto = new System.Windows.Forms.Label();
			this.txIdDpto = new System.Windows.Forms.TextBox();
			this.lbIdDpto = new System.Windows.Forms.Label();
			this.txNIF = new System.Windows.Forms.TextBox();
			this.lbNIF = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tpPersona.SuspendLayout();
			this.tpDepartamento.SuspendLayout();
			this.tpPerfilPersonalizado.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(647, 20);
			this.panel1.TabIndex = 23;
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(338, 15);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Buscador de perfiles de los usuarios de SIGUANETDesktop";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpPersona);
			this.tabControl1.Controls.Add(this.tpDepartamento);
			this.tabControl1.Controls.Add(this.tpPerfilPersonalizado);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 20);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(647, 68);
			this.tabControl1.TabIndex = 24;
			// 
			// tpPersona
			// 
			this.tpPersona.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.tpPersona.Controls.Add(this.txPersona);
			this.tpPersona.Controls.Add(this.lbPersona);
			this.tpPersona.Location = new System.Drawing.Point(4, 22);
			this.tpPersona.Name = "tpPersona";
			this.tpPersona.Padding = new System.Windows.Forms.Padding(3);
			this.tpPersona.Size = new System.Drawing.Size(639, 42);
			this.tpPersona.TabIndex = 0;
			this.tpPersona.Text = "Buscar persona";
			// 
			// txPersona
			// 
			this.txPersona.Dock = System.Windows.Forms.DockStyle.Top;
			this.txPersona.Location = new System.Drawing.Point(3, 16);
			this.txPersona.Name = "txPersona";
			this.txPersona.Size = new System.Drawing.Size(633, 20);
			this.txPersona.TabIndex = 1;
			this.txPersona.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxPersonaKeyUp);
			// 
			// lbPersona
			// 
			this.lbPersona.AutoSize = true;
			this.lbPersona.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbPersona.Location = new System.Drawing.Point(3, 3);
			this.lbPersona.Name = "lbPersona";
			this.lbPersona.Size = new System.Drawing.Size(195, 13);
			this.lbPersona.TabIndex = 0;
			this.lbPersona.Text = "Introduce nombre o apellidos + ENTER:";
			// 
			// tpDepartamento
			// 
			this.tpDepartamento.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.tpDepartamento.Controls.Add(this.txDepartamento);
			this.tpDepartamento.Controls.Add(this.label1);
			this.tpDepartamento.Location = new System.Drawing.Point(4, 22);
			this.tpDepartamento.Name = "tpDepartamento";
			this.tpDepartamento.Padding = new System.Windows.Forms.Padding(3);
			this.tpDepartamento.Size = new System.Drawing.Size(639, 42);
			this.tpDepartamento.TabIndex = 1;
			this.tpDepartamento.Text = "Buscar responsable de departamento";
			// 
			// txDepartamento
			// 
			this.txDepartamento.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDepartamento.Location = new System.Drawing.Point(3, 16);
			this.txDepartamento.Name = "txDepartamento";
			this.txDepartamento.Size = new System.Drawing.Size(633, 20);
			this.txDepartamento.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Introduce el nombre de unidad o departamento + ENTER:";
			// 
			// tpPerfilPersonalizado
			// 
			this.tpPerfilPersonalizado.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.tpPerfilPersonalizado.Controls.Add(this.rbPublico);
			this.tpPerfilPersonalizado.Controls.Add(this.rbUsuarios);
			this.tpPerfilPersonalizado.Location = new System.Drawing.Point(4, 22);
			this.tpPerfilPersonalizado.Name = "tpPerfilPersonalizado";
			this.tpPerfilPersonalizado.Padding = new System.Windows.Forms.Padding(3);
			this.tpPerfilPersonalizado.Size = new System.Drawing.Size(639, 42);
			this.tpPerfilPersonalizado.TabIndex = 2;
			this.tpPerfilPersonalizado.Text = "Buscar perfiles personalizados";
			// 
			// rbPublico
			// 
			this.rbPublico.AutoSize = true;
			this.rbPublico.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbPublico.Location = new System.Drawing.Point(3, 20);
			this.rbPublico.Name = "rbPublico";
			this.rbPublico.Size = new System.Drawing.Size(633, 17);
			this.rbPublico.TabIndex = 2;
			this.rbPublico.TabStop = true;
			this.rbPublico.Text = "Buscar perfiles personalizados asociados al perfil público";
			this.rbPublico.UseVisualStyleBackColor = true;
			// 
			// rbUsuarios
			// 
			this.rbUsuarios.AutoSize = true;
			this.rbUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbUsuarios.Location = new System.Drawing.Point(3, 3);
			this.rbUsuarios.Name = "rbUsuarios";
			this.rbUsuarios.Size = new System.Drawing.Size(633, 17);
			this.rbUsuarios.TabIndex = 1;
			this.rbUsuarios.TabStop = true;
			this.rbUsuarios.Text = "Buscar perfiles personalizados asociados a perfiles no públicos";
			this.rbUsuarios.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 88);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lvUsuarios);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Panel2.Controls.Add(this.panel2);
			this.splitContainer1.Panel2.Controls.Add(this.txNombreDpto);
			this.splitContainer1.Panel2.Controls.Add(this.lbNombreDpto);
			this.splitContainer1.Panel2.Controls.Add(this.txIdDpto);
			this.splitContainer1.Panel2.Controls.Add(this.lbIdDpto);
			this.splitContainer1.Panel2.Controls.Add(this.txNIF);
			this.splitContainer1.Panel2.Controls.Add(this.lbNIF);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
			this.splitContainer1.Size = new System.Drawing.Size(647, 401);
			this.splitContainer1.SplitterDistance = 313;
			this.splitContainer1.TabIndex = 25;
			// 
			// lvUsuarios
			// 
			this.lvUsuarios.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvUsuarios.HideSelection = false;
			this.lvUsuarios.Location = new System.Drawing.Point(0, 0);
			this.lvUsuarios.MultiSelect = false;
			this.lvUsuarios.Name = "lvUsuarios";
			this.lvUsuarios.Size = new System.Drawing.Size(313, 401);
			this.lvUsuarios.TabIndex = 0;
			this.lvUsuarios.UseCompatibleStateImageBehavior = false;
			this.lvUsuarios.View = System.Windows.Forms.View.List;
			this.lvUsuarios.SelectedIndexChanged += new System.EventHandler(this.LvUsuariosSelectedIndexChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbWarning);
			this.panel3.Controls.Add(this.txCaducidad);
			this.panel3.Controls.Add(this.lbCaducidad);
			this.panel3.Controls.Add(this.txDescripcion);
			this.panel3.Controls.Add(this.lbDescripcion);
			this.panel3.Controls.Add(this.txLocalizacion);
			this.panel3.Controls.Add(this.lbLocalizacion);
			this.panel3.Controls.Add(this.txPersonalizado);
			this.panel3.Controls.Add(this.lbPersonalizado);
			this.panel3.Controls.Add(this.txGenerico);
			this.panel3.Controls.Add(this.lbGenerico);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(142, 104);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3);
			this.panel3.Size = new System.Drawing.Size(183, 292);
			this.panel3.TabIndex = 12;
			// 
			// lbWarning
			// 
			this.lbWarning.BackColor = System.Drawing.Color.Sienna;
			this.lbWarning.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbWarning.ForeColor = System.Drawing.Color.White;
			this.lbWarning.Image = ((System.Drawing.Image)(resources.GetObject("lbWarning.Image")));
			this.lbWarning.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lbWarning.Location = new System.Drawing.Point(3, 231);
			this.lbWarning.Name = "lbWarning";
			this.lbWarning.Size = new System.Drawing.Size(177, 44);
			this.lbWarning.TabIndex = 28;
			this.lbWarning.Text = "No se puede deserializar el documento";
			this.lbWarning.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// txCaducidad
			// 
			this.txCaducidad.BackColor = System.Drawing.SystemColors.Info;
			this.txCaducidad.Dock = System.Windows.Forms.DockStyle.Top;
			this.txCaducidad.Location = new System.Drawing.Point(3, 211);
			this.txCaducidad.Name = "txCaducidad";
			this.txCaducidad.ReadOnly = true;
			this.txCaducidad.Size = new System.Drawing.Size(177, 20);
			this.txCaducidad.TabIndex = 26;
			// 
			// lbCaducidad
			// 
			this.lbCaducidad.AutoSize = true;
			this.lbCaducidad.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbCaducidad.Location = new System.Drawing.Point(3, 198);
			this.lbCaducidad.Name = "lbCaducidad";
			this.lbCaducidad.Size = new System.Drawing.Size(61, 13);
			this.lbCaducidad.TabIndex = 25;
			this.lbCaducidad.Text = "Caducidad:";
			// 
			// txDescripcion
			// 
			this.txDescripcion.BackColor = System.Drawing.SystemColors.Info;
			this.txDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
			this.txDescripcion.Location = new System.Drawing.Point(3, 115);
			this.txDescripcion.Multiline = true;
			this.txDescripcion.Name = "txDescripcion";
			this.txDescripcion.ReadOnly = true;
			this.txDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txDescripcion.Size = new System.Drawing.Size(177, 83);
			this.txDescripcion.TabIndex = 24;
			// 
			// lbDescripcion
			// 
			this.lbDescripcion.AutoSize = true;
			this.lbDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDescripcion.Location = new System.Drawing.Point(3, 102);
			this.lbDescripcion.Name = "lbDescripcion";
			this.lbDescripcion.Size = new System.Drawing.Size(66, 13);
			this.lbDescripcion.TabIndex = 23;
			this.lbDescripcion.Text = "Descripcion:";
			// 
			// txLocalizacion
			// 
			this.txLocalizacion.BackColor = System.Drawing.SystemColors.Info;
			this.txLocalizacion.Dock = System.Windows.Forms.DockStyle.Top;
			this.txLocalizacion.Location = new System.Drawing.Point(3, 82);
			this.txLocalizacion.Name = "txLocalizacion";
			this.txLocalizacion.ReadOnly = true;
			this.txLocalizacion.Size = new System.Drawing.Size(177, 20);
			this.txLocalizacion.TabIndex = 22;
			// 
			// lbLocalizacion
			// 
			this.lbLocalizacion.AutoSize = true;
			this.lbLocalizacion.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbLocalizacion.Location = new System.Drawing.Point(3, 69);
			this.lbLocalizacion.Name = "lbLocalizacion";
			this.lbLocalizacion.Size = new System.Drawing.Size(142, 13);
			this.lbLocalizacion.TabIndex = 21;
			this.lbLocalizacion.Text = "Localización del documento:";
			// 
			// txPersonalizado
			// 
			this.txPersonalizado.BackColor = System.Drawing.SystemColors.Info;
			this.txPersonalizado.Dock = System.Windows.Forms.DockStyle.Top;
			this.txPersonalizado.Location = new System.Drawing.Point(3, 49);
			this.txPersonalizado.Name = "txPersonalizado";
			this.txPersonalizado.ReadOnly = true;
			this.txPersonalizado.Size = new System.Drawing.Size(177, 20);
			this.txPersonalizado.TabIndex = 20;
			// 
			// lbPersonalizado
			// 
			this.lbPersonalizado.AutoSize = true;
			this.lbPersonalizado.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbPersonalizado.Location = new System.Drawing.Point(3, 36);
			this.lbPersonalizado.Name = "lbPersonalizado";
			this.lbPersonalizado.Size = new System.Drawing.Size(101, 13);
			this.lbPersonalizado.TabIndex = 19;
			this.lbPersonalizado.Text = "Perfil personalizado:";
			// 
			// txGenerico
			// 
			this.txGenerico.BackColor = System.Drawing.SystemColors.Info;
			this.txGenerico.Dock = System.Windows.Forms.DockStyle.Top;
			this.txGenerico.Location = new System.Drawing.Point(3, 16);
			this.txGenerico.Name = "txGenerico";
			this.txGenerico.ReadOnly = true;
			this.txGenerico.Size = new System.Drawing.Size(177, 20);
			this.txGenerico.TabIndex = 18;
			// 
			// lbGenerico
			// 
			this.lbGenerico.AutoSize = true;
			this.lbGenerico.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbGenerico.Location = new System.Drawing.Point(3, 3);
			this.lbGenerico.Name = "lbGenerico";
			this.lbGenerico.Size = new System.Drawing.Size(77, 13);
			this.lbGenerico.TabIndex = 14;
			this.lbGenerico.Text = "Perfil genérico:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lvPerfiles);
			this.panel2.Controls.Add(this.lbPerfiles);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(5, 104);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(137, 292);
			this.panel2.TabIndex = 11;
			// 
			// lvPerfiles
			// 
			this.lvPerfiles.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lvPerfiles.BackColor = System.Drawing.SystemColors.Info;
			this.lvPerfiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvPerfiles.HideSelection = false;
			this.lvPerfiles.LargeImageList = this.imageList1;
			this.lvPerfiles.Location = new System.Drawing.Point(0, 13);
			this.lvPerfiles.MultiSelect = false;
			this.lvPerfiles.Name = "lvPerfiles";
			this.lvPerfiles.Size = new System.Drawing.Size(137, 279);
			this.lvPerfiles.TabIndex = 16;
			this.lvPerfiles.UseCompatibleStateImageBehavior = false;
			this.lvPerfiles.SelectedIndexChanged += new System.EventHandler(this.LvPerfilesSelectedIndexChanged);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "personal.png");
			// 
			// lbPerfiles
			// 
			this.lbPerfiles.AutoSize = true;
			this.lbPerfiles.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbPerfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbPerfiles.Location = new System.Drawing.Point(0, 0);
			this.lbPerfiles.Name = "lbPerfiles";
			this.lbPerfiles.Size = new System.Drawing.Size(53, 13);
			this.lbPerfiles.TabIndex = 15;
			this.lbPerfiles.Text = "Perfiles:";
			// 
			// txNombreDpto
			// 
			this.txNombreDpto.BackColor = System.Drawing.SystemColors.Info;
			this.txNombreDpto.Dock = System.Windows.Forms.DockStyle.Top;
			this.txNombreDpto.Location = new System.Drawing.Point(5, 84);
			this.txNombreDpto.Name = "txNombreDpto";
			this.txNombreDpto.ReadOnly = true;
			this.txNombreDpto.Size = new System.Drawing.Size(320, 20);
			this.txNombreDpto.TabIndex = 5;
			// 
			// lbNombreDpto
			// 
			this.lbNombreDpto.AutoSize = true;
			this.lbNombreDpto.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbNombreDpto.Location = new System.Drawing.Point(5, 71);
			this.lbNombreDpto.Name = "lbNombreDpto";
			this.lbNombreDpto.Size = new System.Drawing.Size(196, 13);
			this.lbNombreDpto.TabIndex = 4;
			this.lbNombreDpto.Text = "Nombre del departamento que gestiona:";
			// 
			// txIdDpto
			// 
			this.txIdDpto.BackColor = System.Drawing.SystemColors.Info;
			this.txIdDpto.Dock = System.Windows.Forms.DockStyle.Top;
			this.txIdDpto.Location = new System.Drawing.Point(5, 51);
			this.txIdDpto.Name = "txIdDpto";
			this.txIdDpto.ReadOnly = true;
			this.txIdDpto.Size = new System.Drawing.Size(320, 20);
			this.txIdDpto.TabIndex = 3;
			// 
			// lbIdDpto
			// 
			this.lbIdDpto.AutoSize = true;
			this.lbIdDpto.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbIdDpto.Location = new System.Drawing.Point(5, 38);
			this.lbIdDpto.Name = "lbIdDpto";
			this.lbIdDpto.Size = new System.Drawing.Size(192, 13);
			this.lbIdDpto.TabIndex = 2;
			this.lbIdDpto.Text = "Código del departamento que gestiona:";
			// 
			// txNIF
			// 
			this.txNIF.BackColor = System.Drawing.SystemColors.Info;
			this.txNIF.Dock = System.Windows.Forms.DockStyle.Top;
			this.txNIF.Location = new System.Drawing.Point(5, 18);
			this.txNIF.Name = "txNIF";
			this.txNIF.ReadOnly = true;
			this.txNIF.Size = new System.Drawing.Size(320, 20);
			this.txNIF.TabIndex = 1;
			// 
			// lbNIF
			// 
			this.lbNIF.AutoSize = true;
			this.lbNIF.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbNIF.Location = new System.Drawing.Point(5, 5);
			this.lbNIF.Name = "lbNIF";
			this.lbNIF.Size = new System.Drawing.Size(27, 13);
			this.lbNIF.TabIndex = 0;
			this.lbNIF.Text = "NIF:";
			// 
			// controlProfileBrowser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Name = "controlProfileBrowser";
			this.Size = new System.Drawing.Size(647, 489);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tpPersona.ResumeLayout(false);
			this.tpPersona.PerformLayout();
			this.tpDepartamento.ResumeLayout(false);
			this.tpDepartamento.PerformLayout();
			this.tpPerfilPersonalizado.ResumeLayout(false);
			this.tpPerfilPersonalizado.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label lbPerfiles;
		private System.Windows.Forms.ListView lvUsuarios;
		private System.Windows.Forms.Label lbWarning;
		private System.Windows.Forms.ListView lvPerfiles;
		private System.Windows.Forms.Label lbGenerico;
		private System.Windows.Forms.TextBox txGenerico;
		private System.Windows.Forms.Label lbPersonalizado;
		private System.Windows.Forms.TextBox txPersonalizado;
		private System.Windows.Forms.Label lbLocalizacion;
		private System.Windows.Forms.TextBox txLocalizacion;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txNombreDpto;
		private System.Windows.Forms.Label lbNombreDpto;
		private System.Windows.Forms.TextBox txIdDpto;
		private System.Windows.Forms.Label lbIdDpto;
		private System.Windows.Forms.Label lbDescripcion;
		private System.Windows.Forms.TextBox txDescripcion;
		private System.Windows.Forms.Label lbCaducidad;
		private System.Windows.Forms.TextBox txCaducidad;
		private System.Windows.Forms.Label lbNIF;
		private System.Windows.Forms.TextBox txNIF;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.RadioButton rbUsuarios;
		private System.Windows.Forms.RadioButton rbPublico;
		private System.Windows.Forms.TextBox txDepartamento;
		private System.Windows.Forms.TextBox txPersona;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbPersona;
		private System.Windows.Forms.TabPage tpPerfilPersonalizado;
		private System.Windows.Forms.TabPage tpDepartamento;
		private System.Windows.Forms.TabPage tpPersona;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel1;
	}
}
