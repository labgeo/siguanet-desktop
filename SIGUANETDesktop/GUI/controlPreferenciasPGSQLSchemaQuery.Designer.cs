/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 26/02/2008
 * Hora: 9:35
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace SIGUANETDesktop.GUI
{
	partial class controlPreferenciasPGSQLSchemaQuery
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
			this.gbCatalogoColumnas = new System.Windows.Forms.GroupBox();
			this.txCatalogoColumnasCustom = new System.Windows.Forms.TextBox();
			this.rbCatalogoColumnasCustom = new System.Windows.Forms.RadioButton();
			this.rbCatalogoColumnasDefault = new System.Windows.Forms.RadioButton();
			this.gbCatalogoVistas = new System.Windows.Forms.GroupBox();
			this.txCatalogoVistasCustom = new System.Windows.Forms.TextBox();
			this.rbCatalogoVistasCustom = new System.Windows.Forms.RadioButton();
			this.rbCatalogoVistasDefault = new System.Windows.Forms.RadioButton();
			this.gbCatalogoTablas = new System.Windows.Forms.GroupBox();
			this.txCatalogoTablasCustom = new System.Windows.Forms.TextBox();
			this.rbCatalogoTablasCustom = new System.Windows.Forms.RadioButton();
			this.rbCatalogoTablasDefault = new System.Windows.Forms.RadioButton();
			this.txEsquemas = new System.Windows.Forms.TextBox();
			this.lbEsquemas = new System.Windows.Forms.Label();
			this.gbCatalogoColumnas.SuspendLayout();
			this.gbCatalogoVistas.SuspendLayout();
			this.gbCatalogoTablas.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbCatalogoColumnas
			// 
			this.gbCatalogoColumnas.Controls.Add(this.txCatalogoColumnasCustom);
			this.gbCatalogoColumnas.Controls.Add(this.rbCatalogoColumnasCustom);
			this.gbCatalogoColumnas.Controls.Add(this.rbCatalogoColumnasDefault);
			this.gbCatalogoColumnas.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbCatalogoColumnas.Location = new System.Drawing.Point(3, 276);
			this.gbCatalogoColumnas.Name = "gbCatalogoColumnas";
			this.gbCatalogoColumnas.Size = new System.Drawing.Size(500, 120);
			this.gbCatalogoColumnas.TabIndex = 9;
			this.gbCatalogoColumnas.TabStop = false;
			this.gbCatalogoColumnas.Text = "Consulta del catálogo de columnas";
			// 
			// txCatalogoColumnasCustom
			// 
			this.txCatalogoColumnasCustom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txCatalogoColumnasCustom.Location = new System.Drawing.Point(3, 50);
			this.txCatalogoColumnasCustom.Multiline = true;
			this.txCatalogoColumnasCustom.Name = "txCatalogoColumnasCustom";
			this.txCatalogoColumnasCustom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txCatalogoColumnasCustom.Size = new System.Drawing.Size(494, 67);
			this.txCatalogoColumnasCustom.TabIndex = 5;
			this.txCatalogoColumnasCustom.TextChanged += new System.EventHandler(this.TxCatalogoColumnasCustomTextChanged);
			// 
			// rbCatalogoColumnasCustom
			// 
			this.rbCatalogoColumnasCustom.AutoSize = true;
			this.rbCatalogoColumnasCustom.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbCatalogoColumnasCustom.Location = new System.Drawing.Point(3, 33);
			this.rbCatalogoColumnasCustom.Name = "rbCatalogoColumnasCustom";
			this.rbCatalogoColumnasCustom.Size = new System.Drawing.Size(494, 17);
			this.rbCatalogoColumnasCustom.TabIndex = 4;
			this.rbCatalogoColumnasCustom.Text = "Usar mi propia consulta";
			this.rbCatalogoColumnasCustom.UseVisualStyleBackColor = true;
			this.rbCatalogoColumnasCustom.CheckedChanged += new System.EventHandler(this.RbCatalogoColumnasCustomCheckedChanged);
			// 
			// rbCatalogoColumnasDefault
			// 
			this.rbCatalogoColumnasDefault.AutoSize = true;
			this.rbCatalogoColumnasDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbCatalogoColumnasDefault.Location = new System.Drawing.Point(3, 16);
			this.rbCatalogoColumnasDefault.Name = "rbCatalogoColumnasDefault";
			this.rbCatalogoColumnasDefault.Size = new System.Drawing.Size(494, 17);
			this.rbCatalogoColumnasDefault.TabIndex = 3;
			this.rbCatalogoColumnasDefault.Text = "Usar la consulta por defecto";
			this.rbCatalogoColumnasDefault.UseVisualStyleBackColor = true;
			// 
			// gbCatalogoVistas
			// 
			this.gbCatalogoVistas.Controls.Add(this.txCatalogoVistasCustom);
			this.gbCatalogoVistas.Controls.Add(this.rbCatalogoVistasCustom);
			this.gbCatalogoVistas.Controls.Add(this.rbCatalogoVistasDefault);
			this.gbCatalogoVistas.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbCatalogoVistas.Location = new System.Drawing.Point(3, 156);
			this.gbCatalogoVistas.Name = "gbCatalogoVistas";
			this.gbCatalogoVistas.Size = new System.Drawing.Size(500, 120);
			this.gbCatalogoVistas.TabIndex = 8;
			this.gbCatalogoVistas.TabStop = false;
			this.gbCatalogoVistas.Text = "Consulta del catálogo de vistas";
			// 
			// txCatalogoVistasCustom
			// 
			this.txCatalogoVistasCustom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txCatalogoVistasCustom.Location = new System.Drawing.Point(3, 50);
			this.txCatalogoVistasCustom.Multiline = true;
			this.txCatalogoVistasCustom.Name = "txCatalogoVistasCustom";
			this.txCatalogoVistasCustom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txCatalogoVistasCustom.Size = new System.Drawing.Size(494, 67);
			this.txCatalogoVistasCustom.TabIndex = 5;
			this.txCatalogoVistasCustom.TextChanged += new System.EventHandler(this.TxCatalogoVistasCustomTextChanged);
			// 
			// rbCatalogoVistasCustom
			// 
			this.rbCatalogoVistasCustom.AutoSize = true;
			this.rbCatalogoVistasCustom.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbCatalogoVistasCustom.Location = new System.Drawing.Point(3, 33);
			this.rbCatalogoVistasCustom.Name = "rbCatalogoVistasCustom";
			this.rbCatalogoVistasCustom.Size = new System.Drawing.Size(494, 17);
			this.rbCatalogoVistasCustom.TabIndex = 4;
			this.rbCatalogoVistasCustom.Text = "Usar mi propia consulta";
			this.rbCatalogoVistasCustom.UseVisualStyleBackColor = true;
			this.rbCatalogoVistasCustom.CheckedChanged += new System.EventHandler(this.RbCatalogoVistasCustomCheckedChanged);
			// 
			// rbCatalogoVistasDefault
			// 
			this.rbCatalogoVistasDefault.AutoSize = true;
			this.rbCatalogoVistasDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbCatalogoVistasDefault.Location = new System.Drawing.Point(3, 16);
			this.rbCatalogoVistasDefault.Name = "rbCatalogoVistasDefault";
			this.rbCatalogoVistasDefault.Size = new System.Drawing.Size(494, 17);
			this.rbCatalogoVistasDefault.TabIndex = 3;
			this.rbCatalogoVistasDefault.Text = "Usar la consulta por defecto";
			this.rbCatalogoVistasDefault.UseVisualStyleBackColor = true;
			// 
			// gbCatalogoTablas
			// 
			this.gbCatalogoTablas.Controls.Add(this.txCatalogoTablasCustom);
			this.gbCatalogoTablas.Controls.Add(this.rbCatalogoTablasCustom);
			this.gbCatalogoTablas.Controls.Add(this.rbCatalogoTablasDefault);
			this.gbCatalogoTablas.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbCatalogoTablas.Location = new System.Drawing.Point(3, 36);
			this.gbCatalogoTablas.Name = "gbCatalogoTablas";
			this.gbCatalogoTablas.Size = new System.Drawing.Size(500, 120);
			this.gbCatalogoTablas.TabIndex = 7;
			this.gbCatalogoTablas.TabStop = false;
			this.gbCatalogoTablas.Text = "Consulta del catálogo de tablas";
			// 
			// txCatalogoTablasCustom
			// 
			this.txCatalogoTablasCustom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txCatalogoTablasCustom.Location = new System.Drawing.Point(3, 50);
			this.txCatalogoTablasCustom.Multiline = true;
			this.txCatalogoTablasCustom.Name = "txCatalogoTablasCustom";
			this.txCatalogoTablasCustom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txCatalogoTablasCustom.Size = new System.Drawing.Size(494, 67);
			this.txCatalogoTablasCustom.TabIndex = 2;
			this.txCatalogoTablasCustom.TextChanged += new System.EventHandler(this.TxCatalogoTablasCustomTextChanged);
			// 
			// rbCatalogoTablasCustom
			// 
			this.rbCatalogoTablasCustom.AutoSize = true;
			this.rbCatalogoTablasCustom.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbCatalogoTablasCustom.Location = new System.Drawing.Point(3, 33);
			this.rbCatalogoTablasCustom.Name = "rbCatalogoTablasCustom";
			this.rbCatalogoTablasCustom.Size = new System.Drawing.Size(494, 17);
			this.rbCatalogoTablasCustom.TabIndex = 1;
			this.rbCatalogoTablasCustom.Text = "Usar mi propia consulta";
			this.rbCatalogoTablasCustom.UseVisualStyleBackColor = true;
			this.rbCatalogoTablasCustom.CheckedChanged += new System.EventHandler(this.RbCatalogoTablasCustomCheckedChanged);
			// 
			// rbCatalogoTablasDefault
			// 
			this.rbCatalogoTablasDefault.AutoSize = true;
			this.rbCatalogoTablasDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbCatalogoTablasDefault.Location = new System.Drawing.Point(3, 16);
			this.rbCatalogoTablasDefault.Name = "rbCatalogoTablasDefault";
			this.rbCatalogoTablasDefault.Size = new System.Drawing.Size(494, 17);
			this.rbCatalogoTablasDefault.TabIndex = 0;
			this.rbCatalogoTablasDefault.Text = "Usar la consulta por defecto";
			this.rbCatalogoTablasDefault.UseVisualStyleBackColor = true;
			// 
			// txEsquemas
			// 
			this.txEsquemas.Dock = System.Windows.Forms.DockStyle.Top;
			this.txEsquemas.Location = new System.Drawing.Point(3, 16);
			this.txEsquemas.Name = "txEsquemas";
			this.txEsquemas.Size = new System.Drawing.Size(500, 20);
			this.txEsquemas.TabIndex = 6;
			this.txEsquemas.TextChanged += new System.EventHandler(this.TxEsquemasTextChanged);
			// 
			// lbEsquemas
			// 
			this.lbEsquemas.AutoSize = true;
			this.lbEsquemas.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbEsquemas.Location = new System.Drawing.Point(3, 3);
			this.lbEsquemas.Name = "lbEsquemas";
			this.lbEsquemas.Size = new System.Drawing.Size(240, 13);
			this.lbEsquemas.TabIndex = 5;
			this.lbEsquemas.Text = "Esquemas a consultar (lista separada por comas):";
			// 
			// controlPreferenciasPGSQLSchemaQuery
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbCatalogoColumnas);
			this.Controls.Add(this.gbCatalogoVistas);
			this.Controls.Add(this.gbCatalogoTablas);
			this.Controls.Add(this.txEsquemas);
			this.Controls.Add(this.lbEsquemas);
			this.Name = "controlPreferenciasPGSQLSchemaQuery";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(506, 399);
			this.gbCatalogoColumnas.ResumeLayout(false);
			this.gbCatalogoColumnas.PerformLayout();
			this.gbCatalogoVistas.ResumeLayout(false);
			this.gbCatalogoVistas.PerformLayout();
			this.gbCatalogoTablas.ResumeLayout(false);
			this.gbCatalogoTablas.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lbEsquemas;
		private System.Windows.Forms.TextBox txEsquemas;
		private System.Windows.Forms.RadioButton rbCatalogoTablasDefault;
		private System.Windows.Forms.RadioButton rbCatalogoTablasCustom;
		private System.Windows.Forms.TextBox txCatalogoTablasCustom;
		private System.Windows.Forms.GroupBox gbCatalogoTablas;
		private System.Windows.Forms.RadioButton rbCatalogoVistasDefault;
		private System.Windows.Forms.RadioButton rbCatalogoVistasCustom;
		private System.Windows.Forms.TextBox txCatalogoVistasCustom;
		private System.Windows.Forms.GroupBox gbCatalogoVistas;
		private System.Windows.Forms.RadioButton rbCatalogoColumnasDefault;
		private System.Windows.Forms.RadioButton rbCatalogoColumnasCustom;
		private System.Windows.Forms.TextBox txCatalogoColumnasCustom;
		private System.Windows.Forms.GroupBox gbCatalogoColumnas;
	}
}
