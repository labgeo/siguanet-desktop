/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 18/03/2008
 * Hora: 9:44
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlSGDManager
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
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bOK = new System.Windows.Forms.Button();
			this.txOrigen = new System.Windows.Forms.TextBox();
			this.lbOrigen = new System.Windows.Forms.Label();
			this.lbPerfil = new System.Windows.Forms.Label();
			this.cbPerfil = new System.Windows.Forms.ComboBox();
			this.bGuardar = new System.Windows.Forms.Button();
			this.txVersion = new System.Windows.Forms.TextBox();
			this.lbVersion = new System.Windows.Forms.Label();
			this.txAutor = new System.Windows.Forms.TextBox();
			this.lbAutor = new System.Windows.Forms.Label();
			this.lbModulos = new System.Windows.Forms.Label();
			this.tvModulos = new System.Windows.Forms.TreeView();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.lbPerfilPersonalizado = new System.Windows.Forms.Label();
			this.txPerfilPersonalizado = new System.Windows.Forms.TextBox();
			this.lbCaducidad = new System.Windows.Forms.Label();
			this.ckSinCaducidad = new System.Windows.Forms.CheckBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.panel1.SuspendLayout();
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
			this.panel1.Size = new System.Drawing.Size(382, 20);
			this.panel1.TabIndex = 22;
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(304, 15);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Gestor de plantillas de documento SIGUANETDesktop";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.panel2.Controls.Add(this.bOK);
			this.panel2.Controls.Add(this.txOrigen);
			this.panel2.Controls.Add(this.lbOrigen);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 20);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(382, 30);
			this.panel2.TabIndex = 23;
			// 
			// bOK
			// 
			this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bOK.Location = new System.Drawing.Point(311, 3);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(65, 20);
			this.bOK.TabIndex = 2;
			this.bOK.Text = "OK";
			this.bOK.UseVisualStyleBackColor = true;
			this.bOK.Click += new System.EventHandler(this.BOKClick);
			// 
			// txOrigen
			// 
			this.txOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txOrigen.Location = new System.Drawing.Point(88, 4);
			this.txOrigen.Name = "txOrigen";
			this.txOrigen.Size = new System.Drawing.Size(217, 20);
			this.txOrigen.TabIndex = 1;
			this.txOrigen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxOrigenKeyUp);
			// 
			// lbOrigen
			// 
			this.lbOrigen.AutoSize = true;
			this.lbOrigen.Location = new System.Drawing.Point(3, 6);
			this.lbOrigen.Name = "lbOrigen";
			this.lbOrigen.Size = new System.Drawing.Size(41, 13);
			this.lbOrigen.TabIndex = 0;
			this.lbOrigen.Text = "Origen:";
			// 
			// lbPerfil
			// 
			this.lbPerfil.AutoSize = true;
			this.lbPerfil.Location = new System.Drawing.Point(3, 112);
			this.lbPerfil.Name = "lbPerfil";
			this.lbPerfil.Size = new System.Drawing.Size(70, 13);
			this.lbPerfil.TabIndex = 7;
			this.lbPerfil.Text = "Perfil usuario:";
			// 
			// cbPerfil
			// 
			this.cbPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.cbPerfil.FormattingEnabled = true;
			this.cbPerfil.ItemHeight = 13;
			this.cbPerfil.Location = new System.Drawing.Point(88, 108);
			this.cbPerfil.Name = "cbPerfil";
			this.cbPerfil.Size = new System.Drawing.Size(217, 21);
			this.cbPerfil.TabIndex = 8;
			// 
			// bGuardar
			// 
			this.bGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bGuardar.Location = new System.Drawing.Point(311, 362);
			this.bGuardar.Name = "bGuardar";
			this.bGuardar.Size = new System.Drawing.Size(65, 21);
			this.bGuardar.TabIndex = 17;
			this.bGuardar.Text = "Guardar";
			this.bGuardar.UseVisualStyleBackColor = true;
			this.bGuardar.Click += new System.EventHandler(this.BGuardarClick);
			// 
			// txVersion
			// 
			this.txVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txVersion.Location = new System.Drawing.Point(88, 56);
			this.txVersion.Name = "txVersion";
			this.txVersion.Size = new System.Drawing.Size(217, 20);
			this.txVersion.TabIndex = 4;
			// 
			// lbVersion
			// 
			this.lbVersion.AutoSize = true;
			this.lbVersion.Location = new System.Drawing.Point(3, 59);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(45, 13);
			this.lbVersion.TabIndex = 3;
			this.lbVersion.Text = "Versión:";
			// 
			// txAutor
			// 
			this.txAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txAutor.Location = new System.Drawing.Point(88, 82);
			this.txAutor.Name = "txAutor";
			this.txAutor.Size = new System.Drawing.Size(217, 20);
			this.txAutor.TabIndex = 6;
			// 
			// lbAutor
			// 
			this.lbAutor.AutoSize = true;
			this.lbAutor.Location = new System.Drawing.Point(3, 85);
			this.lbAutor.Name = "lbAutor";
			this.lbAutor.Size = new System.Drawing.Size(35, 13);
			this.lbAutor.TabIndex = 5;
			this.lbAutor.Text = "Autor:";
			// 
			// lbModulos
			// 
			this.lbModulos.Location = new System.Drawing.Point(3, 233);
			this.lbModulos.Name = "lbModulos";
			this.lbModulos.Size = new System.Drawing.Size(79, 30);
			this.lbModulos.TabIndex = 15;
			this.lbModulos.Text = "Módulos habilitados:";
			// 
			// tvModulos
			// 
			this.tvModulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tvModulos.CheckBoxes = true;
			this.tvModulos.Location = new System.Drawing.Point(88, 233);
			this.tvModulos.Name = "tvModulos";
			this.tvModulos.Size = new System.Drawing.Size(217, 150);
			this.tvModulos.TabIndex = 16;
			this.tvModulos.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TvModulosAfterCheck);
			this.tvModulos.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvModulosBeforeCheck);
			// 
			// lbPerfilPersonalizado
			// 
			this.lbPerfilPersonalizado.Location = new System.Drawing.Point(3, 137);
			this.lbPerfilPersonalizado.Name = "lbPerfilPersonalizado";
			this.lbPerfilPersonalizado.Size = new System.Drawing.Size(79, 54);
			this.lbPerfilPersonalizado.TabIndex = 9;
			this.lbPerfilPersonalizado.Text = "Perfil personalizado (opcional):";
			// 
			// txPerfilPersonalizado
			// 
			this.txPerfilPersonalizado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txPerfilPersonalizado.Location = new System.Drawing.Point(88, 146);
			this.txPerfilPersonalizado.Name = "txPerfilPersonalizado";
			this.txPerfilPersonalizado.Size = new System.Drawing.Size(217, 20);
			this.txPerfilPersonalizado.TabIndex = 10;
			this.txPerfilPersonalizado.TextChanged += new System.EventHandler(this.TxPerfilPersonalizadoTextChanged);
			// 
			// lbCaducidad
			// 
			this.lbCaducidad.Location = new System.Drawing.Point(3, 191);
			this.lbCaducidad.Name = "lbCaducidad";
			this.lbCaducidad.Size = new System.Drawing.Size(79, 36);
			this.lbCaducidad.TabIndex = 11;
			this.lbCaducidad.Text = "Fecha de caducidad:";
			// 
			// ckSinCaducidad
			// 
			this.ckSinCaducidad.AutoSize = true;
			this.ckSinCaducidad.Location = new System.Drawing.Point(88, 184);
			this.ckSinCaducidad.Name = "ckSinCaducidad";
			this.ckSinCaducidad.Size = new System.Drawing.Size(145, 17);
			this.ckSinCaducidad.TabIndex = 13;
			this.ckSinCaducidad.Text = "El documento no caduca";
			this.ckSinCaducidad.UseVisualStyleBackColor = true;
			this.ckSinCaducidad.CheckedChanged += new System.EventHandler(this.CkSinCaducidadCheckedChanged);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(88, 207);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(217, 20);
			this.dateTimePicker1.TabIndex = 24;
			// 
			// controlSGDManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.ckSinCaducidad);
			this.Controls.Add(this.lbCaducidad);
			this.Controls.Add(this.txPerfilPersonalizado);
			this.Controls.Add(this.lbPerfilPersonalizado);
			this.Controls.Add(this.tvModulos);
			this.Controls.Add(this.lbModulos);
			this.Controls.Add(this.txAutor);
			this.Controls.Add(this.lbAutor);
			this.Controls.Add(this.lbPerfil);
			this.Controls.Add(this.cbPerfil);
			this.Controls.Add(this.bGuardar);
			this.Controls.Add(this.txVersion);
			this.Controls.Add(this.lbVersion);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "controlSGDManager";
			this.Size = new System.Drawing.Size(382, 392);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.CheckBox ckSinCaducidad;
		private System.Windows.Forms.Label lbCaducidad;
		private System.Windows.Forms.TextBox txPerfilPersonalizado;
		private System.Windows.Forms.Label lbPerfilPersonalizado;
		private System.Windows.Forms.TreeView tvModulos;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label lbModulos;
		private System.Windows.Forms.Label lbAutor;
		private System.Windows.Forms.TextBox txAutor;
		private System.Windows.Forms.Label lbVersion;
		private System.Windows.Forms.TextBox txVersion;
		private System.Windows.Forms.Button bGuardar;
		private System.Windows.Forms.ComboBox cbPerfil;
		private System.Windows.Forms.Label lbPerfil;
		private System.Windows.Forms.Label lbOrigen;
		private System.Windows.Forms.TextBox txOrigen;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel1;
	}
}
