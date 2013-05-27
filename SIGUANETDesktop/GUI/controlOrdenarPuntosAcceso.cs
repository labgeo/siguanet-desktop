/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 11/05/2006
 * Time: 13:12
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
	/// Description of controlOrdenarPuntosAcceso.
	/// </summary>
	public partial class controlOrdenarPuntosAcceso
	{
		private SesionExplotacion _s;
		private TreeNode _n;
		
		public controlOrdenarPuntosAcceso(SesionExplotacion s, TreeNode n)
		{	
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_n = n;
			_s = s;
			this.lPuntosAcceso.DataSource = _s.PuntosAcceso;
			this.lPuntosAcceso.DisplayMember = "Nombre";
			this.lPuntosAcceso.ValueMember = "Nombre";			
		}
		
		public event DelegadoCambiaOrdenPuntoAcceso EventoCambiaEstado;
		
		private void BArribaClick(object sender, System.EventArgs e)
		{
			int i = this.lPuntosAcceso.SelectedIndex;
			if (i > 0)
			{
				ReOrdenar((PuntoAcceso) this.lPuntosAcceso.SelectedItem, i, -1);
				this.lPuntosAcceso.SelectedIndex = i - 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}
		}
		
		private void BAbajoClick(object sender, System.EventArgs e)
		{
			int i = this.lPuntosAcceso.SelectedIndex;
			if ((i > -1) && (i < this.lPuntosAcceso.Items.Count -1))
			{
				ReOrdenar((PuntoAcceso) this.lPuntosAcceso.SelectedItem, i, 1);
				this.lPuntosAcceso.SelectedIndex = i + 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}
		 }
		
		private void ReOrdenar(PuntoAcceso p, int posInicial, int desplazamiento)
		{
			_s.PuntosAcceso.RemoveAt(posInicial);
			_s.PuntosAcceso.Insert(posInicial + desplazamiento, p);
			BindingManagerBase bm = this.lPuntosAcceso.BindingContext[_s.PuntosAcceso];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			TreeNode hijo;
			_n.Nodes.Clear();
			foreach (PuntoAcceso prt in _s.PuntosAcceso)
			{
				hijo = GUIUtils.CrearNodoPuntoAcceso(prt);
				_n.Nodes.Add(hijo);
				_n.Expand();
			}
		}		
	}
	
	public delegate void DelegadoCambiaOrdenPuntoAcceso(estadoModelo estado);
}
