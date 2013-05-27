/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 11/04/2006
 * Time: 10:12
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
	public delegate void DelegadoCambiaOrdenComando(estadoModelo estado);	
	/// <summary>
	/// Description of controlOrdenarComandos.
	/// </summary>
	public partial class controlOrdenarComandos
	{
		private Tarea _t;
		private TreeNode _n;		
		public controlOrdenarComandos(Tarea t, TreeNode n)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_n = n;
			_t = t;
			this.lComando.DataSource = _t.Comandos;
			this.lComando.DisplayMember = "Descripcion";
			this.lComando.ValueMember = "Nombre";			
		}
		
		public event DelegadoCambiaOrdenSincro EventoCambiaEstado;
		
		void BArribaClick(object sender, System.EventArgs e)
		{
			int i = this.lComando.SelectedIndex;
			if (i > 0)
			{
				ReOrdenar((Comando) this.lComando.SelectedItem, i, -1);
				this.lComando.SelectedIndex = i - 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		void BAbajoClick(object sender, System.EventArgs e)
		{
			int i = this.lComando.SelectedIndex;
			if ((i > -1) && (i < this.lComando.Items.Count -1))
			{
				ReOrdenar((Comando) this.lComando.SelectedItem, i, 1);
				this.lComando.SelectedIndex = i + 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		private void ReOrdenar(Comando cmd, int posInicial, int desplazamiento)
		{
			_t.Comandos.RemoveAt(posInicial);
			_t.Comandos.Insert(posInicial + desplazamiento, cmd);
			BindingManagerBase bm = this.lComando.BindingContext[_t.Comandos];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			TreeNode hijo;
			_n.Nodes.Clear();
			foreach (Comando cmdo in _t.Comandos)
			{
				hijo = GUIUtils.CrearNodoComando(cmdo);
				_n.Nodes.Add(hijo);
				_n.Expand();
			}
		}		
	}
}
