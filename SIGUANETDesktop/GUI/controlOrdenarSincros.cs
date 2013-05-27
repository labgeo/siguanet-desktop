/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 05/04/2006
 * Time: 9:26
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
	public delegate void DelegadoCambiaOrdenSincro(estadoModelo estado);	
	/// <summary>
	/// Description of controlOrdenarSincro.
	/// </summary>
	public partial class controlOrdenarSincros
	{
		private Operacion _o;
		private TreeNode _n;
		public controlOrdenarSincros(Operacion o, TreeNode n)
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
			this.lSincro.DataSource = _o.Acciones;
			this.lSincro.DisplayMember = "Descripcion";
			this.lSincro.ValueMember = "Nombre";	
		}
		
		public event DelegadoCambiaOrdenSincro EventoCambiaEstado;
		
		void BArribaClick(object sender, System.EventArgs e)
		{
			int i = this.lSincro.SelectedIndex;
			if (i > 0)
			{
				ReOrdenar((Sincro) this.lSincro.SelectedItem, i, -1);
				this.lSincro.SelectedIndex = i - 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		void BAbajoClick(object sender, System.EventArgs e)
		{
			int i = this.lSincro.SelectedIndex;
			if ((i > -1) && (i < this.lSincro.Items.Count -1))
			{
				ReOrdenar((Sincro) this.lSincro.SelectedItem, i, 1);
				this.lSincro.SelectedIndex = i + 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		private void ReOrdenar(Sincro sinc, int posInicial, int desplazamiento)
		{
			_o.Acciones.RemoveAt(posInicial);
			_o.Acciones.Insert(posInicial + desplazamiento, sinc);
			BindingManagerBase bm = this.lSincro.BindingContext[_o.Acciones];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			TreeNode hijo;
			_n.Nodes.Clear();
			foreach (Sincro sncr in _o.Acciones)
			{
				hijo = GUIUtils.CrearNodoSincro(sncr);
				_n.Nodes.Add(hijo);
				_n.Expand();
			}
		}
	}
}
