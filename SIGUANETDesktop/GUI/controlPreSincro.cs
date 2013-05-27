/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 05/04/2006
 * Time: 14:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.ModeloSincronizacion;

namespace SIGUANETDesktop.GUI
{
	public delegate void DelegadoCambiaPreSincro(estadoModelo estado);	
	/// <summary>
	/// Description of controlPreSincro.
	/// </summary>
	public partial class controlPreSincro
	{
		private readonly string descInicial;
		private readonly string docInicial;

		private TreeNode _nodo;
		private PreSincro _pre;
		
		public controlPreSincro(TreeNode n)
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
			tt.SetToolTip(this.txDesc , "Presiona 'Esc' para recuperar la descripción inicial");
			tt.SetToolTip(this.txComent , "Presiona 'Esc' para recuperar el comentario inicial");
			
			_nodo = n;
			_pre = (PreSincro) n.Tag;
			this.txDesc.Text = descInicial = _pre.Descripcion;
			this.txComent.Text = docInicial = _pre.Doc;
		}
		
		void TxDescTextChanged(object sender, EventArgs e)
		{
			_nodo.Text = _pre.Descripcion = this.txDesc.Text;
		}
		
		void TxComentTextChanged(object sender, EventArgs e)
		{
			_pre.Doc = this.txComent.Text;
		}
		
		void TxDescKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_nodo.Text = _pre.Descripcion = this.txDesc.Text = descInicial;
			}
		}
		
		void TxComentKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_pre.Doc = this.txComent.Text = docInicial;
			}	
		}
		
		public event DelegadoCambiaPreSincro EventoCambiaEstado;
		
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
}
