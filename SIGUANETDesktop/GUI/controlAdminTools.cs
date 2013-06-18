/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 17/03/2008
 * Hora: 14:36
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloDocumento;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlAdminTools.
	/// </summary>
	public partial class controlAdminTools : UserControl
	{
		Root _doc = null;
		public controlAdminTools(Root doc)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			_doc = doc;
		}
		
		void BSGDClick(object sender, EventArgs e)
		{
			this.splitContainer1.Panel2.Controls.Clear();
			controlSGDManager dlgSGD = new controlSGDManager();
			dlgSGD.Dock = DockStyle.Fill;
			this.splitContainer1.Panel2.Controls.Add(dlgSGD);
		}
		
		void BSGDUploadClick(object sender, EventArgs e)
		{
			this.splitContainer1.Panel2.Controls.Clear();
			controlSGDUploadManager dlgUpSGD = new controlSGDUploadManager(_doc);
			dlgUpSGD.Dock = DockStyle.Fill;
			this.splitContainer1.Panel2.Controls.Add(dlgUpSGD);
		}		
		
		void BSRSClick(object sender, EventArgs e)
		{
			this.splitContainer1.Panel2.Controls.Clear();
			controlSRSManager dlgSRS = new controlSRSManager(false);
			dlgSRS.Dock = DockStyle.Fill;
			this.splitContainer1.Panel2.Controls.Add(dlgSRS);
		}
		
		void BHTTPPUTClick(object sender, EventArgs e)
		{
			this.splitContainer1.Panel2.Controls.Clear();
			controlUploadClient dlgPUT = new controlUploadClient();
			dlgPUT.Dock = DockStyle.Fill;
			this.splitContainer1.Panel2.Controls.Add(dlgPUT);			
		}
	}
}
