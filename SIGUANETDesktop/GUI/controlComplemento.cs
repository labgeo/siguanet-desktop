/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 05/04/2006
 * Time: 17:17
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
	public delegate void DelegadoCambiaComplemento(estadoModelo estado);
	/// <summary>
	/// Description of controlComplemento.
	/// </summary>
	public partial class controlComplemento
	{
		private readonly string descInicial;
		private readonly string docInicial;

		private TreeNode _nodo;
		private Complemento _comp;
		
		public controlComplemento(TreeNode n)
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
			_comp = (Complemento) n.Tag;
			this.txDesc.Text = descInicial = _comp.Descripcion;
			this.txComent.Text = docInicial = _comp.Doc;			
		}

		void TxDescTextChanged(object sender, EventArgs e)
		{
			_nodo.Text = _comp.Descripcion = this.txDesc.Text;
		}
		
		void TxComentTextChanged(object sender, EventArgs e)
		{
			_comp.Doc = this.txComent.Text;
		}
		
		void TxDescKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_nodo.Text = _comp.Descripcion = this.txDesc.Text = descInicial;
			}
		}
		
		void TxComentKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_comp.Doc = this.txComent.Text = docInicial;
			}	
		}
		
		public event DelegadoCambiaComplemento EventoCambiaEstado;
		
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
