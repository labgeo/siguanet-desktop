/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 24/04/2008
 * Hora: 9:37
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.Log;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmVisorSucesos.
	/// </summary>
	public partial class frmVisorSucesos : Form
	{
		private AppLog al = AppLog.Instance;
		public frmVisorSucesos()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			al.ExceptionLoggedEvent += this.Refrescar;
		}
		
		private void Refrescar(SIGUANETDesktopException e)
		{
			ListViewItem lvi = new ListViewItem(Enum.GetName(typeof(ExceptionCategory), e.Category));
			lvi.SubItems.Add(e.TimeStamp.ToShortDateString());
			lvi.SubItems.Add(e.TimeStamp.ToShortTimeString());
			lvi.SubItems.Add(e.SourceMethod);
			lvi.SubItems.Add(e.Message);
			lvi.Tag = e;
			this.lvSucesos.Items.Add(lvi);
		}
		
		void LvSucesosItemActivate(object sender, EventArgs e)
		{
			this.tvInnerExceptions.Nodes.Clear();
			this.txIEDescription.Clear();
			SIGUANETDesktopException parentEx = (SIGUANETDesktopException) this.lvSucesos.SelectedItems[0].Tag;
			TreeNode n = new TreeNode(Enum.GetName(typeof(ExceptionCategory), parentEx.Category));
			n.Tag = parentEx;
			this.tvInnerExceptions.Nodes.Add(n);
			this.AddInnerException(parentEx);
		}
		
		private void AddInnerException(Exception e)
		{
			if (e.InnerException != null)
			{
				string name = string.Empty;
				if (e.InnerException is SIGUANETDesktopException)
				{
					name = Enum.GetName(typeof(ExceptionCategory), (e.InnerException as SIGUANETDesktopException).Category);
				}
				else
				{
					name = e.InnerException.GetType().Name;
				}
				TreeNode n = new TreeNode(name);
				n.Tag = e.InnerException;
				this.tvInnerExceptions.Nodes.Add(n);
				this.AddInnerException(e.InnerException);
			}
		}
		
		void TvInnerExceptionsAfterSelect(object sender, TreeViewEventArgs e)
		{
			this.txIEDescription.Text = (e.Node.Tag as Exception).Message;
		}
		
		void FrmVisorSucesosFormClosing(object sender, FormClosingEventArgs e)
		{
			//Existe una instancia única del visor de sucesos
			//y es MainForm el encargado de cerrarla y liberar recursos
			e.Cancel = true;
			this.Hide();
		}
	}
}
