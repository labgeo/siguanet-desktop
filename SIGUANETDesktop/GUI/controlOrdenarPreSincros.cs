/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 05/04/2006
 * Time: 9:19
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
	public delegate void DelegadoCambiaOrdenPreSincro(estadoModelo estado);	
	/// <summary>
	/// Description of controlOrdenarPreSincro.
	/// </summary>
	public partial class controlOrdenarPreSincros
	{
		private Operacion _o;
		private TreeNode _n;
		public controlOrdenarPreSincros(Operacion o, TreeNode n)
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
			this.lPreSincro.DataSource = _o.PreComprobaciones;
			this.lPreSincro.DisplayMember = "Descripcion";
			this.lPreSincro.ValueMember = "Nombre";			
		}

		public event DelegadoCambiaOrdenPreSincro EventoCambiaEstado;
		
		void BArribaClick(object sender, System.EventArgs e)
		{
			int i = this.lPreSincro.SelectedIndex;
			if (i > 0)
			{
				ReOrdenar((PreSincro) this.lPreSincro.SelectedItem, i, -1);
				this.lPreSincro.SelectedIndex = i - 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		void BAbajoClick(object sender, System.EventArgs e)
		{
			int i = this.lPreSincro.SelectedIndex;
			if ((i > -1) && (i < this.lPreSincro.Items.Count -1))
			{
				ReOrdenar((PreSincro) this.lPreSincro.SelectedItem, i, 1);
				this.lPreSincro.SelectedIndex = i + 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		private void ReOrdenar(PreSincro pre, int posInicial, int desplazamiento)
		{
			_o.PreComprobaciones.RemoveAt(posInicial);
			_o.PreComprobaciones.Insert(posInicial + desplazamiento, pre);
			BindingManagerBase bm = this.lPreSincro.BindingContext[_o.PreComprobaciones];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			TreeNode hijo;
			_n.Nodes.Clear();
			foreach (PreSincro presinc in _o.PreComprobaciones)
			{
				hijo = GUIUtils.CrearNodoPreSincro(presinc);
				_n.Nodes.Add(hijo);
				_n.Expand();
			}
		}
	}
}
