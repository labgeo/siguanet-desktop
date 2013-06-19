/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/03/2006
 * Time: 14:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SIGUANETDesktop
{
	partial class MainForm : System.Windows.Forms.Form
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mPrincipal = new System.Windows.Forms.MenuStrip();
			this.mitemArchivo = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevo = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemAbrir = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemGuardar = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemGuardarComo = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemSalir = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemEditar = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemPerfil = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemPGSQL = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemORA = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemSOAP = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemHerramientas = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemVEsquemasBD = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemVSucesos = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemOpciones = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemAyuda = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.mOperaciones = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemNuevaOp = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvDoc = new System.Windows.Forms.TreeView();
			this.dlgGuardarComo = new System.Windows.Forms.SaveFileDialog();
			this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
			this.mOperacion = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemEliminarOp = new System.Windows.Forms.ToolStripMenuItem();
			this.mPreSincros = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemNuevaPreSincro = new System.Windows.Forms.ToolStripMenuItem();
			this.mSincros = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemNuevaSincro = new System.Windows.Forms.ToolStripMenuItem();
			this.mPostSincros = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemNuevaPostSincro = new System.Windows.Forms.ToolStripMenuItem();
			this.mComplementos = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mNuevoComplemento = new System.Windows.Forms.ToolStripMenuItem();
			this.mPreSincro = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemEliminarPreSincro = new System.Windows.Forms.ToolStripMenuItem();
			this.mSincro = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemEliminarSincro = new System.Windows.Forms.ToolStripMenuItem();
			this.mPostSincro = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemEliminarPostSincro = new System.Windows.Forms.ToolStripMenuItem();
			this.mComplemento = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemEliminarComplemento = new System.Windows.Forms.ToolStripMenuItem();
			this.mComandos = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemNuevoCmdSel = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoCmdAviso = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoCmdAltas = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoCmdBajas = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoCmdDarAltas = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoCmdDarBajas = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoCmdModificar = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoCmdEdicion = new System.Windows.Forms.ToolStripMenuItem();
			this.mComando = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemEjecutarComando = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemSimularComando = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemEliminarComando = new System.Windows.Forms.ToolStripMenuItem();
			this.mPuntosAcceso = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemNuevoArbEspacial = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoArbOrganizativo = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoArbUsos = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoArbUsosG = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoArbUsosGCRUE = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNuevoArbUsosGU21 = new System.Windows.Forms.ToolStripMenuItem();
			this.mSesionSincro = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemAutoSincro = new System.Windows.Forms.ToolStripMenuItem();
			this.mSesionSOAP = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemIniciarSOAP = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemTestSOAP = new System.Windows.Forms.ToolStripMenuItem();
			this.mPuntoAcceso = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mitemEliminarPuntoAcceso = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssbPerfil = new System.Windows.Forms.ToolStripSplitButton();
			this.tstxPerfil = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tstxPerfilCustom = new System.Windows.Forms.ToolStripTextBox();
			this.tssbImpersonacion = new System.Windows.Forms.ToolStripSplitButton();
			this.tstxImpersonacion = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tstxImpersonacionCustom = new System.Windows.Forms.ToolStripTextBox();
			this.tssbIncidencias = new System.Windows.Forms.ToolStripSplitButton();
			this.tstxIncidencias = new System.Windows.Forms.ToolStripTextBox();
			this.mPrincipal.SuspendLayout();
			this.mOperaciones.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.mOperacion.SuspendLayout();
			this.mPreSincros.SuspendLayout();
			this.mSincros.SuspendLayout();
			this.mPostSincros.SuspendLayout();
			this.mComplementos.SuspendLayout();
			this.mPreSincro.SuspendLayout();
			this.mSincro.SuspendLayout();
			this.mPostSincro.SuspendLayout();
			this.mComplemento.SuspendLayout();
			this.mComandos.SuspendLayout();
			this.mComando.SuspendLayout();
			this.mPuntosAcceso.SuspendLayout();
			this.mSesionSincro.SuspendLayout();
			this.mSesionSOAP.SuspendLayout();
			this.mPuntoAcceso.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mPrincipal
			// 
			this.mPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemArchivo,
									this.mitemEditar,
									this.mitemHerramientas,
									this.mitemAyuda});
			this.mPrincipal.Location = new System.Drawing.Point(0, 0);
			this.mPrincipal.Name = "mPrincipal";
			this.mPrincipal.Size = new System.Drawing.Size(774, 24);
			this.mPrincipal.TabIndex = 2;
			this.mPrincipal.Text = "menuStrip1";
			// 
			// mitemArchivo
			// 
			this.mitemArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemNuevo,
									this.mitemAbrir,
									this.mitemGuardar,
									this.mitemGuardarComo,
									this.mitemSalir});
			this.mitemArchivo.Name = "mitemArchivo";
			this.mitemArchivo.Size = new System.Drawing.Size(55, 20);
			this.mitemArchivo.Text = "Archivo";
			// 
			// mitemNuevo
			// 
			this.mitemNuevo.Name = "mitemNuevo";
			this.mitemNuevo.Size = new System.Drawing.Size(167, 22);
			this.mitemNuevo.Text = "Nuevo";
			this.mitemNuevo.Click += new System.EventHandler(this.MitemNuevoClick);
			// 
			// mitemAbrir
			// 
			this.mitemAbrir.Name = "mitemAbrir";
			this.mitemAbrir.Size = new System.Drawing.Size(167, 22);
			this.mitemAbrir.Text = "Abrir";
			this.mitemAbrir.Click += new System.EventHandler(this.MitemAbrirClick);
			// 
			// mitemGuardar
			// 
			this.mitemGuardar.Name = "mitemGuardar";
			this.mitemGuardar.Size = new System.Drawing.Size(167, 22);
			this.mitemGuardar.Text = "Guardar";
			this.mitemGuardar.Click += new System.EventHandler(this.MitemGuardarClick);
			// 
			// mitemGuardarComo
			// 
			this.mitemGuardarComo.Name = "mitemGuardarComo";
			this.mitemGuardarComo.Size = new System.Drawing.Size(167, 22);
			this.mitemGuardarComo.Text = "Guardar como ...";
			this.mitemGuardarComo.Click += new System.EventHandler(this.MitemGuardarComoClick);
			// 
			// mitemSalir
			// 
			this.mitemSalir.Name = "mitemSalir";
			this.mitemSalir.Size = new System.Drawing.Size(167, 22);
			this.mitemSalir.Text = "Salir";
			this.mitemSalir.Click += new System.EventHandler(this.MitemSalirClick);
			// 
			// mitemEditar
			// 
			this.mitemEditar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemPerfil,
									this.mitemPGSQL,
									this.mitemORA,
									this.mitemSOAP});
			this.mitemEditar.Name = "mitemEditar";
			this.mitemEditar.Size = new System.Drawing.Size(47, 20);
			this.mitemEditar.Text = "Editar";
			// 
			// mitemPerfil
			// 
			this.mitemPerfil.Name = "mitemPerfil";
			this.mitemPerfil.Size = new System.Drawing.Size(250, 22);
			this.mitemPerfil.Text = "Perfil de usuario";
			this.mitemPerfil.Click += new System.EventHandler(this.MitemPerfilClick);
			// 
			// mitemPGSQL
			// 
			this.mitemPGSQL.Name = "mitemPGSQL";
			this.mitemPGSQL.Size = new System.Drawing.Size(250, 22);
			this.mitemPGSQL.Text = "Conexión SIGUANET (PostgreSQL)";
			this.mitemPGSQL.Click += new System.EventHandler(this.MitemPGSQLClick);
			// 
			// mitemORA
			// 
			this.mitemORA.Name = "mitemORA";
			this.mitemORA.Size = new System.Drawing.Size(250, 22);
			this.mitemORA.Text = "Conexión CPD (Oracle)";
			this.mitemORA.Click += new System.EventHandler(this.MitemORAClick);
			// 
			// mitemSOAP
			// 
			this.mitemSOAP.Name = "mitemSOAP";
			this.mitemSOAP.Size = new System.Drawing.Size(250, 22);
			this.mitemSOAP.Text = "Conexión SOAP";
			this.mitemSOAP.Click += new System.EventHandler(this.MitemSOAPClick);
			// 
			// mitemHerramientas
			// 
			this.mitemHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemVEsquemasBD,
									this.mitemVSucesos,
									this.mitemOpciones});
			this.mitemHerramientas.Name = "mitemHerramientas";
			this.mitemHerramientas.Size = new System.Drawing.Size(83, 20);
			this.mitemHerramientas.Text = "Herramientas";
			// 
			// mitemVEsquemasBD
			// 
			this.mitemVEsquemasBD.Name = "mitemVEsquemasBD";
			this.mitemVEsquemasBD.Size = new System.Drawing.Size(261, 22);
			this.mitemVEsquemasBD.Text = "Visor de esquemas de Base de Datos";
			this.mitemVEsquemasBD.Click += new System.EventHandler(this.MitemVEsquemasBDClick);
			// 
			// mitemVSucesos
			// 
			this.mitemVSucesos.Name = "mitemVSucesos";
			this.mitemVSucesos.Size = new System.Drawing.Size(261, 22);
			this.mitemVSucesos.Text = "Visor de sucesos";
			this.mitemVSucesos.Click += new System.EventHandler(this.MitemVSucesosClick);
			// 
			// mitemOpciones
			// 
			this.mitemOpciones.Name = "mitemOpciones";
			this.mitemOpciones.Size = new System.Drawing.Size(261, 22);
			this.mitemOpciones.Text = "Opciones";
			this.mitemOpciones.Click += new System.EventHandler(this.MitemOpcionesClick);
			// 
			// mitemAyuda
			// 
			this.mitemAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemAbout});
			this.mitemAyuda.Name = "mitemAyuda";
			this.mitemAyuda.Size = new System.Drawing.Size(50, 20);
			this.mitemAyuda.Text = "Ayuda";
			// 
			// mitemAbout
			// 
			this.mitemAbout.Name = "mitemAbout";
			this.mitemAbout.Size = new System.Drawing.Size(145, 22);
			this.mitemAbout.Text = "Acerca de...";
			this.mitemAbout.Click += new System.EventHandler(this.MitemAboutClick);
			// 
			// mOperaciones
			// 
			this.mOperaciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemNuevaOp});
			this.mOperaciones.Name = "mSesion";
			this.mOperaciones.Size = new System.Drawing.Size(169, 26);
			// 
			// mitemNuevaOp
			// 
			this.mitemNuevaOp.Name = "mitemNuevaOp";
			this.mitemNuevaOp.Size = new System.Drawing.Size(168, 22);
			this.mitemNuevaOp.Text = "Nueva Operación";
			this.mitemNuevaOp.Click += new System.EventHandler(this.MitemNuevaOpClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvDoc);
			this.splitContainer1.Size = new System.Drawing.Size(774, 456);
			this.splitContainer1.SplitterDistance = 257;
			this.splitContainer1.TabIndex = 3;
			// 
			// tvDoc
			// 
			this.tvDoc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvDoc.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
			this.tvDoc.HideSelection = false;
			this.tvDoc.Location = new System.Drawing.Point(0, 0);
			this.tvDoc.Name = "tvDoc";
			this.tvDoc.ShowNodeToolTips = true;
			this.tvDoc.Size = new System.Drawing.Size(257, 456);
			this.tvDoc.TabIndex = 0;
			this.tvDoc.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TvDoc_DrawNode);
			this.tvDoc.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvDoc_BeforeCollapse);
			this.tvDoc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvDoc_AfterSelect);
			this.tvDoc.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TvDoc_NodeMouseClick);
			// 
			// dlgAbrir
			// 
			this.dlgAbrir.FileName = "openFileDialog1";
			// 
			// mOperacion
			// 
			this.mOperacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemEliminarOp});
			this.mOperacion.Name = "mOperacion";
			this.mOperacion.Size = new System.Drawing.Size(122, 26);
			// 
			// mitemEliminarOp
			// 
			this.mitemEliminarOp.Name = "mitemEliminarOp";
			this.mitemEliminarOp.Size = new System.Drawing.Size(121, 22);
			this.mitemEliminarOp.Text = "Eliminar";
			this.mitemEliminarOp.Click += new System.EventHandler(this.MitemEliminarOpClick);
			// 
			// mPreSincros
			// 
			this.mPreSincros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemNuevaPreSincro});
			this.mPreSincros.Name = "mPreSincro";
			this.mPreSincros.Size = new System.Drawing.Size(263, 26);
			// 
			// mitemNuevaPreSincro
			// 
			this.mitemNuevaPreSincro.Name = "mitemNuevaPreSincro";
			this.mitemNuevaPreSincro.Size = new System.Drawing.Size(262, 22);
			this.mitemNuevaPreSincro.Text = "Nueva tarea de comprobación previa";
			this.mitemNuevaPreSincro.Click += new System.EventHandler(this.MitemNuevaPreSincroClick);
			// 
			// mSincros
			// 
			this.mSincros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemNuevaSincro});
			this.mSincros.Name = "mSincro";
			this.mSincros.Size = new System.Drawing.Size(230, 26);
			// 
			// mitemNuevaSincro
			// 
			this.mitemNuevaSincro.Name = "mitemNuevaSincro";
			this.mitemNuevaSincro.Size = new System.Drawing.Size(229, 22);
			this.mitemNuevaSincro.Text = "Nueva tarea de sincronización";
			this.mitemNuevaSincro.Click += new System.EventHandler(this.MitemNuevaSincroClick);
			// 
			// mPostSincros
			// 
			this.mPostSincros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemNuevaPostSincro});
			this.mPostSincros.Name = "mPostSincro";
			this.mPostSincros.Size = new System.Drawing.Size(276, 26);
			// 
			// mitemNuevaPostSincro
			// 
			this.mitemNuevaPostSincro.Name = "mitemNuevaPostSincro";
			this.mitemNuevaPostSincro.Size = new System.Drawing.Size(275, 22);
			this.mitemNuevaPostSincro.Text = "Nueva tarea de comprobación posterior";
			this.mitemNuevaPostSincro.Click += new System.EventHandler(this.MitemNuevaPostSincroClick);
			// 
			// mComplementos
			// 
			this.mComplementos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mNuevoComplemento});
			this.mComplementos.Name = "mComplemento";
			this.mComplementos.Size = new System.Drawing.Size(224, 26);
			// 
			// mNuevoComplemento
			// 
			this.mNuevoComplemento.Name = "mNuevoComplemento";
			this.mNuevoComplemento.Size = new System.Drawing.Size(223, 22);
			this.mNuevoComplemento.Text = "Nueva tarea complementaria";
			this.mNuevoComplemento.Click += new System.EventHandler(this.MNuevoComplementoClick);
			// 
			// mPreSincro
			// 
			this.mPreSincro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemEliminarPreSincro});
			this.mPreSincro.Name = "mOperacion";
			this.mPreSincro.Size = new System.Drawing.Size(122, 26);
			// 
			// mitemEliminarPreSincro
			// 
			this.mitemEliminarPreSincro.Name = "mitemEliminarPreSincro";
			this.mitemEliminarPreSincro.Size = new System.Drawing.Size(121, 22);
			this.mitemEliminarPreSincro.Text = "Eliminar";
			this.mitemEliminarPreSincro.Click += new System.EventHandler(this.MitemEliminarPreSincroClick);
			// 
			// mSincro
			// 
			this.mSincro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemEliminarSincro});
			this.mSincro.Name = "mOperacion";
			this.mSincro.Size = new System.Drawing.Size(122, 26);
			// 
			// mitemEliminarSincro
			// 
			this.mitemEliminarSincro.Name = "mitemEliminarSincro";
			this.mitemEliminarSincro.Size = new System.Drawing.Size(121, 22);
			this.mitemEliminarSincro.Text = "Eliminar";
			this.mitemEliminarSincro.Click += new System.EventHandler(this.MitemEliminarSincroClick);
			// 
			// mPostSincro
			// 
			this.mPostSincro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemEliminarPostSincro});
			this.mPostSincro.Name = "mOperacion";
			this.mPostSincro.Size = new System.Drawing.Size(122, 26);
			// 
			// mitemEliminarPostSincro
			// 
			this.mitemEliminarPostSincro.Name = "mitemEliminarPostSincro";
			this.mitemEliminarPostSincro.Size = new System.Drawing.Size(121, 22);
			this.mitemEliminarPostSincro.Text = "Eliminar";
			this.mitemEliminarPostSincro.Click += new System.EventHandler(this.MitemEliminarPostSincroClick);
			// 
			// mComplemento
			// 
			this.mComplemento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemEliminarComplemento});
			this.mComplemento.Name = "mOperacion";
			this.mComplemento.Size = new System.Drawing.Size(122, 26);
			// 
			// mitemEliminarComplemento
			// 
			this.mitemEliminarComplemento.Name = "mitemEliminarComplemento";
			this.mitemEliminarComplemento.Size = new System.Drawing.Size(121, 22);
			this.mitemEliminarComplemento.Text = "Eliminar";
			this.mitemEliminarComplemento.Click += new System.EventHandler(this.MitemEliminarComplementoClick);
			// 
			// mComandos
			// 
			this.mComandos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemNuevoCmdSel,
									this.mitemNuevoCmdAviso,
									this.mitemNuevoCmdAltas,
									this.mitemNuevoCmdBajas,
									this.mitemNuevoCmdDarAltas,
									this.mitemNuevoCmdDarBajas,
									this.mitemNuevoCmdModificar,
									this.mitemNuevoCmdEdicion});
			this.mComandos.Name = "mOperacion";
			this.mComandos.Size = new System.Drawing.Size(291, 180);
			this.mComandos.Opening += new System.ComponentModel.CancelEventHandler(this.MComandosOpening);
			// 
			// mitemNuevoCmdSel
			// 
			this.mitemNuevoCmdSel.Name = "mitemNuevoCmdSel";
			this.mitemNuevoCmdSel.Size = new System.Drawing.Size(290, 22);
			this.mitemNuevoCmdSel.Text = "Nuevo comando de selección";
			this.mitemNuevoCmdSel.Click += new System.EventHandler(this.MitemNuevoCmdSelClick);
			// 
			// mitemNuevoCmdAviso
			// 
			this.mitemNuevoCmdAviso.Name = "mitemNuevoCmdAviso";
			this.mitemNuevoCmdAviso.Size = new System.Drawing.Size(290, 22);
			this.mitemNuevoCmdAviso.Text = "Nuevo comando de aviso";
			this.mitemNuevoCmdAviso.Click += new System.EventHandler(this.MitemNuevoCmdAvisoClick);
			// 
			// mitemNuevoCmdAltas
			// 
			this.mitemNuevoCmdAltas.Name = "mitemNuevoCmdAltas";
			this.mitemNuevoCmdAltas.Size = new System.Drawing.Size(290, 22);
			this.mitemNuevoCmdAltas.Text = "Nuevo comando de comprobación de altas";
			this.mitemNuevoCmdAltas.Click += new System.EventHandler(this.MitemNuevoCmdAltasClick);
			// 
			// mitemNuevoCmdBajas
			// 
			this.mitemNuevoCmdBajas.Name = "mitemNuevoCmdBajas";
			this.mitemNuevoCmdBajas.Size = new System.Drawing.Size(290, 22);
			this.mitemNuevoCmdBajas.Text = "Nuevo comando de comprobación de bajas";
			this.mitemNuevoCmdBajas.Click += new System.EventHandler(this.MitemNuevoCmdBajasClick);
			// 
			// mitemNuevoCmdDarAltas
			// 
			this.mitemNuevoCmdDarAltas.Name = "mitemNuevoCmdDarAltas";
			this.mitemNuevoCmdDarAltas.Size = new System.Drawing.Size(290, 22);
			this.mitemNuevoCmdDarAltas.Text = "Nuevo comando de altas";
			this.mitemNuevoCmdDarAltas.Click += new System.EventHandler(this.MitemNuevoCmdDarAltasClick);
			// 
			// mitemNuevoCmdDarBajas
			// 
			this.mitemNuevoCmdDarBajas.Name = "mitemNuevoCmdDarBajas";
			this.mitemNuevoCmdDarBajas.Size = new System.Drawing.Size(290, 22);
			this.mitemNuevoCmdDarBajas.Text = "Nuevo comando de bajas";
			this.mitemNuevoCmdDarBajas.Click += new System.EventHandler(this.MitemNuevoCmdDarBajasClick);
			// 
			// mitemNuevoCmdModificar
			// 
			this.mitemNuevoCmdModificar.Name = "mitemNuevoCmdModificar";
			this.mitemNuevoCmdModificar.Size = new System.Drawing.Size(290, 22);
			this.mitemNuevoCmdModificar.Text = "Nuevo comando de modificación";
			this.mitemNuevoCmdModificar.Click += new System.EventHandler(this.MitemNuevoCmdModificarClick);
			// 
			// mitemNuevoCmdEdicion
			// 
			this.mitemNuevoCmdEdicion.Name = "mitemNuevoCmdEdicion";
			this.mitemNuevoCmdEdicion.Size = new System.Drawing.Size(290, 22);
			this.mitemNuevoCmdEdicion.Text = "Nuevo comando de edición manual";
			this.mitemNuevoCmdEdicion.Click += new System.EventHandler(this.MitemNuevoCmdEdicionClick);
			// 
			// mComando
			// 
			this.mComando.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemEjecutarComando,
									this.mitemSimularComando,
									this.mitemEliminarComando});
			this.mComando.Name = "mOperacion";
			this.mComando.Size = new System.Drawing.Size(126, 70);
			this.mComando.Opening += new System.ComponentModel.CancelEventHandler(this.MComandoOpening);
			// 
			// mitemEjecutarComando
			// 
			this.mitemEjecutarComando.Name = "mitemEjecutarComando";
			this.mitemEjecutarComando.Size = new System.Drawing.Size(125, 22);
			this.mitemEjecutarComando.Text = "Ejecutar";
			this.mitemEjecutarComando.Click += new System.EventHandler(this.MitemEjecutarComandoClick);
			// 
			// mitemSimularComando
			// 
			this.mitemSimularComando.Name = "mitemSimularComando";
			this.mitemSimularComando.Size = new System.Drawing.Size(125, 22);
			this.mitemSimularComando.Text = "Simular";
			this.mitemSimularComando.Click += new System.EventHandler(this.MitemSimularComandoClick);
			// 
			// mitemEliminarComando
			// 
			this.mitemEliminarComando.Name = "mitemEliminarComando";
			this.mitemEliminarComando.Size = new System.Drawing.Size(125, 22);
			this.mitemEliminarComando.Text = "Eliminar";
			this.mitemEliminarComando.Click += new System.EventHandler(this.MitemEliminarComandoClick);
			// 
			// mPuntosAcceso
			// 
			this.mPuntosAcceso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemNuevoArbEspacial,
									this.mitemNuevoArbOrganizativo,
									this.mitemNuevoArbUsos,
									this.mitemNuevoArbUsosG,
									this.mitemNuevoArbUsosGCRUE,
									this.mitemNuevoArbUsosGU21});
			this.mPuntosAcceso.Name = "mSesion";
			this.mPuntosAcceso.Size = new System.Drawing.Size(267, 158);
			this.mPuntosAcceso.Opening += new System.ComponentModel.CancelEventHandler(this.MPuntosAccesoOpening);
			// 
			// mitemNuevoArbEspacial
			// 
			this.mitemNuevoArbEspacial.Name = "mitemNuevoArbEspacial";
			this.mitemNuevoArbEspacial.Size = new System.Drawing.Size(266, 22);
			this.mitemNuevoArbEspacial.Text = "Nuevo Árbol de Espacios ";
			this.mitemNuevoArbEspacial.Click += new System.EventHandler(this.MitemNuevoArbEspacialClick);
			// 
			// mitemNuevoArbOrganizativo
			// 
			this.mitemNuevoArbOrganizativo.Name = "mitemNuevoArbOrganizativo";
			this.mitemNuevoArbOrganizativo.Size = new System.Drawing.Size(266, 22);
			this.mitemNuevoArbOrganizativo.Text = "Nuevo Árbol de Organización";
			this.mitemNuevoArbOrganizativo.Click += new System.EventHandler(this.MitemNuevoArbOrganizativoClick);
			// 
			// mitemNuevoArbUsos
			// 
			this.mitemNuevoArbUsos.Name = "mitemNuevoArbUsos";
			this.mitemNuevoArbUsos.Size = new System.Drawing.Size(266, 22);
			this.mitemNuevoArbUsos.Text = "Nuevo Árbol de Usos";
			this.mitemNuevoArbUsos.Click += new System.EventHandler(this.MitemNuevoArbUsosClick);
			// 
			// mitemNuevoArbUsosG
			// 
			this.mitemNuevoArbUsosG.Name = "mitemNuevoArbUsosG";
			this.mitemNuevoArbUsosG.Size = new System.Drawing.Size(266, 22);
			this.mitemNuevoArbUsosG.Text = "Nuevo árbol de Usos (grupos propios)";
			this.mitemNuevoArbUsosG.Click += new System.EventHandler(this.MitemNuevoArbUsosGClick);
			// 
			// mitemNuevoArbUsosGCRUE
			// 
			this.mitemNuevoArbUsosGCRUE.Name = "mitemNuevoArbUsosGCRUE";
			this.mitemNuevoArbUsosGCRUE.Size = new System.Drawing.Size(266, 22);
			this.mitemNuevoArbUsosGCRUE.Text = "Nuevo árbol de Usos (grupos CRUE)";
			this.mitemNuevoArbUsosGCRUE.Click += new System.EventHandler(this.MitemNuevoArbUsosGCRUEClick);
			// 
			// mitemNuevoArbUsosGU21
			// 
			this.mitemNuevoArbUsosGU21.Name = "mitemNuevoArbUsosGU21";
			this.mitemNuevoArbUsosGU21.Size = new System.Drawing.Size(266, 22);
			this.mitemNuevoArbUsosGU21.Text = "Nuevo árbol de Usos (grupos UXXI)";
			this.mitemNuevoArbUsosGU21.Click += new System.EventHandler(this.MitemNuevoArbUsosGU21Click);
			// 
			// mSesionSincro
			// 
			this.mSesionSincro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemAutoSincro});
			this.mSesionSincro.Name = "mSesionSincro";
			this.mSesionSincro.Size = new System.Drawing.Size(209, 26);
			// 
			// mitemAutoSincro
			// 
			this.mitemAutoSincro.Name = "mitemAutoSincro";
			this.mitemAutoSincro.Size = new System.Drawing.Size(208, 22);
			this.mitemAutoSincro.Text = "Sincronización automática";
			this.mitemAutoSincro.Click += new System.EventHandler(this.MitemAutoSincroClick);
			// 
			// mSesionSOAP
			// 
			this.mSesionSOAP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemIniciarSOAP,
									this.mitemTestSOAP});
			this.mSesionSOAP.Name = "mSesionSOAP";
			this.mSesionSOAP.Size = new System.Drawing.Size(354, 48);
			// 
			// mitemIniciarSOAP
			// 
			this.mitemIniciarSOAP.Name = "mitemIniciarSOAP";
			this.mitemIniciarSOAP.Size = new System.Drawing.Size(353, 22);
			this.mitemIniciarSOAP.Text = "Reiniciar con los parámetros de conexión SOAP actuales";
			this.mitemIniciarSOAP.Click += new System.EventHandler(this.MitemIniciarSOAPClick);
			// 
			// mitemTestSOAP
			// 
			this.mitemTestSOAP.Name = "mitemTestSOAP";
			this.mitemTestSOAP.Size = new System.Drawing.Size(353, 22);
			this.mitemTestSOAP.Text = "Realizar prueba de funcionamiento del servicio";
			this.mitemTestSOAP.Click += new System.EventHandler(this.MitemTestSOAPClick);
			// 
			// mPuntoAcceso
			// 
			this.mPuntoAcceso.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mitemEliminarPuntoAcceso});
			this.mPuntoAcceso.Name = "mPuntoAcceso";
			this.mPuntoAcceso.Size = new System.Drawing.Size(122, 26);
			// 
			// mitemEliminarPuntoAcceso
			// 
			this.mitemEliminarPuntoAcceso.Name = "mitemEliminarPuntoAcceso";
			this.mitemEliminarPuntoAcceso.Size = new System.Drawing.Size(121, 22);
			this.mitemEliminarPuntoAcceso.Text = "Eliminar";
			this.mitemEliminarPuntoAcceso.Click += new System.EventHandler(this.MitemEliminarPuntoAccesoClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tssbPerfil,
									this.tssbImpersonacion,
									this.tssbIncidencias});
			this.statusStrip1.Location = new System.Drawing.Point(0, 480);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(774, 22);
			this.statusStrip1.TabIndex = 18;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tssbPerfil
			// 
			this.tssbPerfil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tssbPerfil.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tstxPerfil,
									this.toolStripSeparator2,
									this.tstxPerfilCustom});
			this.tssbPerfil.Image = ((System.Drawing.Image)(resources.GetObject("tssbPerfil.Image")));
			this.tssbPerfil.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tssbPerfil.Name = "tssbPerfil";
			this.tssbPerfil.Size = new System.Drawing.Size(32, 20);
			this.tssbPerfil.ToolTipText = "Información del perfil de usuario";
			// 
			// tstxPerfil
			// 
			this.tstxPerfil.BackColor = System.Drawing.SystemColors.Window;
			this.tstxPerfil.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tstxPerfil.Name = "tstxPerfil";
			this.tstxPerfil.ReadOnly = true;
			this.tstxPerfil.Size = new System.Drawing.Size(300, 14);
			this.tstxPerfil.Text = "Está conectado con perfil {0}";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(357, 6);
			// 
			// tstxPerfilCustom
			// 
			this.tstxPerfilCustom.BackColor = System.Drawing.SystemColors.Window;
			this.tstxPerfilCustom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tstxPerfilCustom.Name = "tstxPerfilCustom";
			this.tstxPerfilCustom.ReadOnly = true;
			this.tstxPerfilCustom.Size = new System.Drawing.Size(300, 14);
			this.tstxPerfilCustom.Text = "Está utilizando el perfil personalizado {0}";
			// 
			// tssbImpersonacion
			// 
			this.tssbImpersonacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tssbImpersonacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tstxImpersonacion,
									this.toolStripSeparator1,
									this.tstxImpersonacionCustom});
			this.tssbImpersonacion.Image = ((System.Drawing.Image)(resources.GetObject("tssbImpersonacion.Image")));
			this.tssbImpersonacion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tssbImpersonacion.Name = "tssbImpersonacion";
			this.tssbImpersonacion.Size = new System.Drawing.Size(32, 20);
			this.tssbImpersonacion.ToolTipText = "Información de impersonación";
			// 
			// tstxImpersonacion
			// 
			this.tstxImpersonacion.BackColor = System.Drawing.SystemColors.Window;
			this.tstxImpersonacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tstxImpersonacion.Name = "tstxImpersonacion";
			this.tstxImpersonacion.ReadOnly = true;
			this.tstxImpersonacion.Size = new System.Drawing.Size(300, 14);
			this.tstxImpersonacion.Text = "Estás impersonando al perfil {0}";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(357, 6);
			// 
			// tstxImpersonacionCustom
			// 
			this.tstxImpersonacionCustom.BackColor = System.Drawing.SystemColors.Window;
			this.tstxImpersonacionCustom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tstxImpersonacionCustom.Name = "tstxImpersonacionCustom";
			this.tstxImpersonacionCustom.ReadOnly = true;
			this.tstxImpersonacionCustom.Size = new System.Drawing.Size(300, 14);
			this.tstxImpersonacionCustom.Text = "Estás utilizando la impersonación personalizada {0}";
			// 
			// tssbIncidencias
			// 
			this.tssbIncidencias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tssbIncidencias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tstxIncidencias});
			this.tssbIncidencias.Image = ((System.Drawing.Image)(resources.GetObject("tssbIncidencias.Image")));
			this.tssbIncidencias.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tssbIncidencias.Name = "tssbIncidencias";
			this.tssbIncidencias.Size = new System.Drawing.Size(32, 20);
			this.tssbIncidencias.Text = "Alerta de incidencias";
			// 
			// tstxIncidencias
			// 
			this.tstxIncidencias.BackColor = System.Drawing.SystemColors.Window;
			this.tstxIncidencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tstxIncidencias.Name = "tstxIncidencias";
			this.tstxIncidencias.ReadOnly = true;
			this.tstxIncidencias.Size = new System.Drawing.Size(300, 14);
			this.tstxIncidencias.Text = "Se produjeron incidencias. Consulte el visor de sucesos.";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 502);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.mPrincipal);
			this.Controls.Add(this.statusStrip1);
			this.MainMenuStrip = this.mPrincipal;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SIGUANETDesktop";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainFormClosing);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.mPrincipal.ResumeLayout(false);
			this.mPrincipal.PerformLayout();
			this.mOperaciones.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.mOperacion.ResumeLayout(false);
			this.mPreSincros.ResumeLayout(false);
			this.mSincros.ResumeLayout(false);
			this.mPostSincros.ResumeLayout(false);
			this.mComplementos.ResumeLayout(false);
			this.mPreSincro.ResumeLayout(false);
			this.mSincro.ResumeLayout(false);
			this.mPostSincro.ResumeLayout(false);
			this.mComplemento.ResumeLayout(false);
			this.mComandos.ResumeLayout(false);
			this.mComando.ResumeLayout(false);
			this.mPuntosAcceso.ResumeLayout(false);
			this.mSesionSincro.ResumeLayout(false);
			this.mSesionSOAP.ResumeLayout(false);
			this.mPuntoAcceso.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem mitemAbout;
		private System.Windows.Forms.ToolStripMenuItem mitemAyuda;
		private System.Windows.Forms.ToolStripMenuItem mitemPerfil;
		private System.Windows.Forms.ToolStripSplitButton tssbPerfil;
		private System.Windows.Forms.ToolStripTextBox tstxIncidencias;
		private System.Windows.Forms.ToolStripSplitButton tssbIncidencias;
		private System.Windows.Forms.ToolStripTextBox tstxImpersonacionCustom;
		private System.Windows.Forms.ToolStripTextBox tstxImpersonacion;
		private System.Windows.Forms.ToolStripSplitButton tssbImpersonacion;
		private System.Windows.Forms.ToolStripTextBox tstxPerfilCustom;
		private System.Windows.Forms.ToolStripTextBox tstxPerfil;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem mitemVSucesos;
		private System.Windows.Forms.ToolStripMenuItem mitemVEsquemasBD;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoArbUsosG;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoArbUsosGU21;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoArbUsosGCRUE;
		private System.Windows.Forms.ToolStripMenuItem mitemEliminarPuntoAcceso;
		private System.Windows.Forms.ContextMenuStrip mPuntoAcceso;
		private System.Windows.Forms.ToolStripMenuItem mitemIniciarSOAP;
		private System.Windows.Forms.ToolStripMenuItem mitemTestSOAP;
		private System.Windows.Forms.ContextMenuStrip mSesionSOAP;
		private System.Windows.Forms.ToolStripMenuItem mitemSOAP;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoArbEspacial;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoArbUsos;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoArbOrganizativo;
		private System.Windows.Forms.ToolStripMenuItem mitemSimularComando;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoCmdModificar;
		private System.Windows.Forms.ToolStripMenuItem mitemAutoSincro;
		private System.Windows.Forms.ContextMenuStrip mSesionSincro;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoCmdAviso;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoCmdEdicion;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoCmdDarBajas;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoCmdDarAltas;
		private System.Windows.Forms.ContextMenuStrip mPuntosAcceso;
		private System.Windows.Forms.TreeView tvDoc;
		private System.Windows.Forms.ToolStripMenuItem mitemEliminarComando;
		private System.Windows.Forms.ToolStripMenuItem mitemEjecutarComando;
		private System.Windows.Forms.ContextMenuStrip mComando;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoCmdBajas;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoCmdAltas;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevoCmdSel;
		private System.Windows.Forms.ContextMenuStrip mComandos;
		private System.Windows.Forms.ToolStripMenuItem mitemEliminarComplemento;
		private System.Windows.Forms.ContextMenuStrip mComplemento;
		private System.Windows.Forms.ToolStripMenuItem mitemEliminarPostSincro;
		private System.Windows.Forms.ContextMenuStrip mPostSincro;
		private System.Windows.Forms.ToolStripMenuItem mitemEliminarSincro;
		private System.Windows.Forms.ContextMenuStrip mSincro;
		private System.Windows.Forms.ToolStripMenuItem mitemEliminarPreSincro;
		private System.Windows.Forms.ContextMenuStrip mPreSincro;
		private System.Windows.Forms.ContextMenuStrip mComplementos;
		private System.Windows.Forms.ContextMenuStrip mPreSincros;
		private System.Windows.Forms.ContextMenuStrip mSincros;
		private System.Windows.Forms.ContextMenuStrip mPostSincros;
		private System.Windows.Forms.ContextMenuStrip mOperaciones;
		private System.Windows.Forms.ToolStripMenuItem mNuevoComplemento;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevaPostSincro;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevaSincro;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevaPreSincro;
		private System.Windows.Forms.ToolStripMenuItem mitemEliminarOp;
		private System.Windows.Forms.ContextMenuStrip mOperacion;
		private System.Windows.Forms.ToolStripMenuItem mitemOpciones;
		private System.Windows.Forms.ToolStripMenuItem mitemHerramientas;
		private System.Windows.Forms.OpenFileDialog dlgAbrir;
		private System.Windows.Forms.SaveFileDialog dlgGuardarComo;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevaOp;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem mitemPGSQL;
		private System.Windows.Forms.ToolStripMenuItem mitemORA;
		private System.Windows.Forms.ToolStripMenuItem mitemEditar;
		private System.Windows.Forms.ToolStripMenuItem mitemSalir;
		private System.Windows.Forms.ToolStripMenuItem mitemGuardarComo;
		private System.Windows.Forms.ToolStripMenuItem mitemGuardar;
		private System.Windows.Forms.ToolStripMenuItem mitemAbrir;
		private System.Windows.Forms.ToolStripMenuItem mitemNuevo;
		private System.Windows.Forms.ToolStripMenuItem mitemArchivo;
		private System.Windows.Forms.MenuStrip mPrincipal;
	}
}
