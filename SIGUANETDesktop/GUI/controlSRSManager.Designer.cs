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
	partial class controlSRSManager
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
			this.lbVersion = new System.Windows.Forms.Label();
			this.txVersion = new System.Windows.Forms.TextBox();
			this.txClave = new System.Windows.Forms.TextBox();
			this.txUsuario = new System.Windows.Forms.TextBox();
			this.txPuerto = new System.Windows.Forms.TextBox();
			this.txBD = new System.Windows.Forms.TextBox();
			this.txServidor = new System.Windows.Forms.TextBox();
			this.lbBD = new System.Windows.Forms.Label();
			this.lbPuerto = new System.Windows.Forms.Label();
			this.lbServidor = new System.Windows.Forms.Label();
			this.lbClave = new System.Windows.Forms.Label();
			this.lbUsuario = new System.Windows.Forms.Label();
			this.bGuardar = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.bOK = new System.Windows.Forms.Button();
			this.txOrigen = new System.Windows.Forms.TextBox();
			this.lbOrigen = new System.Windows.Forms.Label();
			this.txTimeout = new System.Windows.Forms.TextBox();
			this.lbTimeout = new System.Windows.Forms.Label();
			this.cbPerfil = new System.Windows.Forms.ComboBox();
			this.lbPerfil = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbUpload = new System.Windows.Forms.Label();
			this.bUpload = new System.Windows.Forms.Button();
			this.txDestino = new System.Windows.Forms.TextBox();
			this.lbDestino = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbVersion
			// 
			this.lbVersion.AutoSize = true;
			this.lbVersion.Location = new System.Drawing.Point(3, 59);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(45, 13);
			this.lbVersion.TabIndex = 2;
			this.lbVersion.Text = "Versión:";
			// 
			// txVersion
			// 
			this.txVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txVersion.Location = new System.Drawing.Point(88, 56);
			this.txVersion.Name = "txVersion";
			this.txVersion.Size = new System.Drawing.Size(217, 20);
			this.txVersion.TabIndex = 3;
			// 
			// txClave
			// 
			this.txClave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txClave.Location = new System.Drawing.Point(88, 190);
			this.txClave.MaxLength = 50;
			this.txClave.Name = "txClave";
			this.txClave.PasswordChar = '*';
			this.txClave.Size = new System.Drawing.Size(217, 20);
			this.txClave.TabIndex = 8;
			// 
			// txUsuario
			// 
			this.txUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txUsuario.Location = new System.Drawing.Point(88, 163);
			this.txUsuario.MaxLength = 50;
			this.txUsuario.Name = "txUsuario";
			this.txUsuario.Size = new System.Drawing.Size(217, 20);
			this.txUsuario.TabIndex = 7;
			// 
			// txPuerto
			// 
			this.txPuerto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txPuerto.Location = new System.Drawing.Point(88, 109);
			this.txPuerto.MaxLength = 4;
			this.txPuerto.Name = "txPuerto";
			this.txPuerto.Size = new System.Drawing.Size(217, 20);
			this.txPuerto.TabIndex = 5;
			// 
			// txBD
			// 
			this.txBD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txBD.Location = new System.Drawing.Point(88, 136);
			this.txBD.MaxLength = 50;
			this.txBD.Name = "txBD";
			this.txBD.Size = new System.Drawing.Size(217, 20);
			this.txBD.TabIndex = 6;
			// 
			// txServidor
			// 
			this.txServidor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txServidor.Location = new System.Drawing.Point(88, 82);
			this.txServidor.MaxLength = 50;
			this.txServidor.Name = "txServidor";
			this.txServidor.Size = new System.Drawing.Size(217, 20);
			this.txServidor.TabIndex = 4;
			// 
			// lbBD
			// 
			this.lbBD.AutoSize = true;
			this.lbBD.Location = new System.Drawing.Point(3, 139);
			this.lbBD.Name = "lbBD";
			this.lbBD.Size = new System.Drawing.Size(78, 13);
			this.lbBD.TabIndex = 19;
			this.lbBD.Text = "Base de datos:";
			// 
			// lbPuerto
			// 
			this.lbPuerto.AutoSize = true;
			this.lbPuerto.Location = new System.Drawing.Point(3, 112);
			this.lbPuerto.Name = "lbPuerto";
			this.lbPuerto.Size = new System.Drawing.Size(41, 13);
			this.lbPuerto.TabIndex = 18;
			this.lbPuerto.Text = "Puerto:";
			// 
			// lbServidor
			// 
			this.lbServidor.AutoSize = true;
			this.lbServidor.Location = new System.Drawing.Point(3, 85);
			this.lbServidor.Name = "lbServidor";
			this.lbServidor.Size = new System.Drawing.Size(49, 13);
			this.lbServidor.TabIndex = 17;
			this.lbServidor.Text = "Servidor:";
			// 
			// lbClave
			// 
			this.lbClave.AutoSize = true;
			this.lbClave.Location = new System.Drawing.Point(3, 193);
			this.lbClave.Name = "lbClave";
			this.lbClave.Size = new System.Drawing.Size(37, 13);
			this.lbClave.TabIndex = 16;
			this.lbClave.Text = "Clave:";
			// 
			// lbUsuario
			// 
			this.lbUsuario.AutoSize = true;
			this.lbUsuario.Location = new System.Drawing.Point(3, 166);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(46, 13);
			this.lbUsuario.TabIndex = 15;
			this.lbUsuario.Text = "Usuario:";
			// 
			// bGuardar
			// 
			this.bGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bGuardar.Location = new System.Drawing.Point(311, 242);
			this.bGuardar.Name = "bGuardar";
			this.bGuardar.Size = new System.Drawing.Size(65, 21);
			this.bGuardar.TabIndex = 11;
			this.bGuardar.Text = "Guardar";
			this.bGuardar.UseVisualStyleBackColor = true;
			this.bGuardar.Click += new System.EventHandler(this.BGuardarClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(382, 20);
			this.panel1.TabIndex = 21;
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(299, 15);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Gestor de ajustes remotos SIGUANETDesktop";
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
			this.panel2.TabIndex = 22;
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
			// txTimeout
			// 
			this.txTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txTimeout.Location = new System.Drawing.Point(88, 216);
			this.txTimeout.MaxLength = 50;
			this.txTimeout.Name = "txTimeout";
			this.txTimeout.Size = new System.Drawing.Size(217, 20);
			this.txTimeout.TabIndex = 9;
			// 
			// lbTimeout
			// 
			this.lbTimeout.AutoSize = true;
			this.lbTimeout.Location = new System.Drawing.Point(3, 219);
			this.lbTimeout.Name = "lbTimeout";
			this.lbTimeout.Size = new System.Drawing.Size(51, 13);
			this.lbTimeout.TabIndex = 24;
			this.lbTimeout.Text = "Timeout: ";
			// 
			// cbPerfil
			// 
			this.cbPerfil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.cbPerfil.FormattingEnabled = true;
			this.cbPerfil.Location = new System.Drawing.Point(88, 242);
			this.cbPerfil.Name = "cbPerfil";
			this.cbPerfil.Size = new System.Drawing.Size(217, 21);
			this.cbPerfil.TabIndex = 10;
			// 
			// lbPerfil
			// 
			this.lbPerfil.AutoSize = true;
			this.lbPerfil.Location = new System.Drawing.Point(3, 246);
			this.lbPerfil.Name = "lbPerfil";
			this.lbPerfil.Size = new System.Drawing.Size(70, 13);
			this.lbPerfil.TabIndex = 26;
			this.lbPerfil.Text = "Perfil usuario:";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.panel3.Controls.Add(this.lbUpload);
			this.panel3.Controls.Add(this.bUpload);
			this.panel3.Controls.Add(this.txDestino);
			this.panel3.Controls.Add(this.lbDestino);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 271);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(382, 42);
			this.panel3.TabIndex = 27;
			// 
			// lbUpload
			// 
			this.lbUpload.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbUpload.Location = new System.Drawing.Point(0, 0);
			this.lbUpload.Name = "lbUpload";
			this.lbUpload.Size = new System.Drawing.Size(382, 13);
			this.lbUpload.TabIndex = 3;
			this.lbUpload.Text = "Uploading de los ajustes remotos actuales al servidor web";
			this.lbUpload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// bUpload
			// 
			this.bUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bUpload.Location = new System.Drawing.Point(311, 15);
			this.bUpload.Name = "bUpload";
			this.bUpload.Size = new System.Drawing.Size(65, 22);
			this.bUpload.TabIndex = 2;
			this.bUpload.Text = "Upload";
			this.bUpload.UseVisualStyleBackColor = true;
			this.bUpload.Click += new System.EventHandler(this.BUploadClick);
			// 
			// txDestino
			// 
			this.txDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txDestino.Location = new System.Drawing.Point(88, 16);
			this.txDestino.Name = "txDestino";
			this.txDestino.Size = new System.Drawing.Size(217, 20);
			this.txDestino.TabIndex = 1;
			// 
			// lbDestino
			// 
			this.lbDestino.AutoSize = true;
			this.lbDestino.Location = new System.Drawing.Point(3, 18);
			this.lbDestino.Name = "lbDestino";
			this.lbDestino.Size = new System.Drawing.Size(46, 13);
			this.lbDestino.TabIndex = 0;
			this.lbDestino.Text = "Destino:";
			// 
			// controlSRSManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.lbPerfil);
			this.Controls.Add(this.cbPerfil);
			this.Controls.Add(this.txTimeout);
			this.Controls.Add(this.lbTimeout);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.bGuardar);
			this.Controls.Add(this.txClave);
			this.Controls.Add(this.txUsuario);
			this.Controls.Add(this.txPuerto);
			this.Controls.Add(this.txBD);
			this.Controls.Add(this.txServidor);
			this.Controls.Add(this.lbBD);
			this.Controls.Add(this.lbPuerto);
			this.Controls.Add(this.lbServidor);
			this.Controls.Add(this.lbClave);
			this.Controls.Add(this.lbUsuario);
			this.Controls.Add(this.txVersion);
			this.Controls.Add(this.lbVersion);
			this.Name = "controlSRSManager";
			this.Size = new System.Drawing.Size(382, 313);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txDestino;
		private System.Windows.Forms.Label lbUpload;
		private System.Windows.Forms.Label lbDestino;
		private System.Windows.Forms.Button bUpload;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label lbPerfil;
		private System.Windows.Forms.ComboBox cbPerfil;
		private System.Windows.Forms.TextBox txOrigen;
		private System.Windows.Forms.Label lbOrigen;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Label lbTimeout;
		private System.Windows.Forms.TextBox txTimeout;
		private System.Windows.Forms.TextBox txVersion;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Button bGuardar;
		private System.Windows.Forms.Label lbUsuario;
		private System.Windows.Forms.Label lbClave;
		private System.Windows.Forms.Label lbServidor;
		private System.Windows.Forms.Label lbPuerto;
		private System.Windows.Forms.Label lbBD;
		private System.Windows.Forms.TextBox txServidor;
		private System.Windows.Forms.TextBox txBD;
		private System.Windows.Forms.TextBox txPuerto;
		private System.Windows.Forms.TextBox txUsuario;
		private System.Windows.Forms.TextBox txClave;
		private System.Windows.Forms.Label lbVersion;
		private System.Windows.Forms.Panel panel1;
	}
}
