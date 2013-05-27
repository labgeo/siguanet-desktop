/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 05/04/2006
 * Time: 12:15
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
	public delegate void DelegadoCambiaOrdenComplementos(estadoModelo estado);		
	/// <summary>
	/// Description of controlOrdenarComplemento.
	/// </summary>
	public partial class controlOrdenarComplementos
	{
		private Operacion _o;
		private TreeNode _n;		
		public controlOrdenarComplementos(Operacion o, TreeNode n)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_n = n;
			_o = o;
			this.lComplementos.DataSource = _o.Complementos;
			this.lComplementos.DisplayMember = "Descripcion";
			this.lComplementos.ValueMember = "Nombre";			
		}
		
		public event DelegadoCambiaOrdenComplementos EventoCambiaEstado;
		
		void BArribaClick(object sender, System.EventArgs e)
		{
			int i = this.lComplementos.SelectedIndex;
			if (i > 0)
			{
				ReOrdenar((Complemento) this.lComplementos.SelectedItem, i, -1);
				this.lComplementos.SelectedIndex = i - 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		void BAbajoClick(object sender, System.EventArgs e)
		{
			int i = this.lComplementos.SelectedIndex;
			if ((i > -1) && (i < this.lComplementos.Items.Count -1))
			{
				ReOrdenar((Complemento) this.lComplementos.SelectedItem, i, 1);
				this.lComplementos.SelectedIndex = i + 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		private void ReOrdenar(Complemento comp, int posInicial, int desplazamiento)
		{
			_o.Complementos.RemoveAt(posInicial);
			_o.Complementos.Insert(posInicial + desplazamiento, comp);
			BindingManagerBase bm = this.lComplementos.BindingContext[_o.Complementos];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			TreeNode hijo;
			_n.Nodes.Clear();
			foreach (Complemento complem in _o.Complementos)
			{
				hijo = GUIUtils.CrearNodoComplemento(complem);
				_n.Nodes.Add(hijo);
				_n.Expand();
			}
		}		
	}
}
