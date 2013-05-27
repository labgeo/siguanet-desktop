/*
 * Created by SharpDevelop.
 * User: Jose Tom�s
 * Date: 11/05/2006
 * Time: 12:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.ModeloExplotacion;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlSesionExplotacion.
	/// </summary>
	public partial class controlSesionExplotacion
	{
		private readonly string descInicial;
		private readonly string docInicial;
		
		private TreeNode _nodo;
		private SesionExplotacion _sesion;
		
		public controlSesionExplotacion(TreeNode n)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			ToolTip tt = new ToolTip();
		    tt.AutoPopDelay = 5000;
		    tt.InitialDelay = 1000;
		    tt.ReshowDelay = 500;
   			tt.ShowAlways = true;
			tt.SetToolTip(this.txDesc , "Presiona 'Esc' para recuperar la descripci�n inicial");
			tt.SetToolTip(this.txComent , "Presiona 'Esc' para recuperar el comentario inicial");
			
			_nodo = n;
			_sesion = (SesionExplotacion) n.Tag;
			this.txDesc.Text = descInicial = _sesion.Descripcion;
			this.txComent.Text = docInicial = _sesion.Doc;			
		}
		
		void TxDescTextChanged(object sender, EventArgs e)
		{
			_sesion.Descripcion = this.txDesc.Text;
		}
		
		void TxComentTextChanged(object sender, EventArgs e)
		{
			_sesion.Doc = this.txComent.Text;
		}
		
		void TxDescKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_sesion.Descripcion = this.txDesc.Text = descInicial;
			}
		}
		
		void TxComentKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_sesion.Doc = this.txComent.Text = docInicial;
			}	
		}
		
		public DelegadoCambiaSesionExplotacion EventoCambiaEstado;
		
		void TxDescKeyUp(object sender, KeyEventArgs e)
		{
			if (this.txDesc.Text != descInicial)
			{
				EventoCambiaEstado(estadoModelo.Pendiente);
			}
		}
		
		void TxComentKeyUp(object sender, KeyEventArgs e)
		{
			if (this.txComent.Text != docInicial)
			{
				EventoCambiaEstado(estadoModelo.Pendiente);
			}			
		}		
	}
	
	public delegate void DelegadoCambiaSesionExplotacion(estadoModelo estado);
}
