/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 05/04/2006
 * Time: 9:29
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
	public delegate void DelegadoCambiaOrdenPostSincro(estadoModelo estado);	
	/// <summary>
	/// Description of controlOrdenarPostSincro.
	/// </summary>
	public partial class controlOrdenarPostSincros
	{
		private Operacion _o;
		private TreeNode _n;		
		public controlOrdenarPostSincros(Operacion o, TreeNode n)
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
			this.lPostSincro.DataSource = _o.PostComprobaciones;
			this.lPostSincro.DisplayMember = "Descripcion";
			this.lPostSincro.ValueMember = "Nombre";			
		}
		
		public event DelegadoCambiaOrdenPostSincro EventoCambiaEstado;
		
		void BArribaClick(object sender, System.EventArgs e)
		{
			int i = this.lPostSincro.SelectedIndex;
			if (i > 0)
			{
				ReOrdenar((PostSincro) this.lPostSincro.SelectedItem, i, -1);
				this.lPostSincro.SelectedIndex = i - 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		void BAbajoClick(object sender, System.EventArgs e)
		{
			int i = this.lPostSincro.SelectedIndex;
			if ((i > -1) && (i < this.lPostSincro.Items.Count -1))
			{
				ReOrdenar((PostSincro) this.lPostSincro.SelectedItem, i, 1);
				this.lPostSincro.SelectedIndex = i + 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}			
		}
		
		private void ReOrdenar(PostSincro post, int posInicial, int desplazamiento)
		{
			_o.PostComprobaciones.RemoveAt(posInicial);
			_o.PostComprobaciones.Insert(posInicial + desplazamiento, post);
			BindingManagerBase bm = this.lPostSincro.BindingContext[_o.PostComprobaciones];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			TreeNode hijo;
			_n.Nodes.Clear();
			foreach (PostSincro postsinc in _o.PostComprobaciones)
			{
				hijo = GUIUtils.CrearNodoPostSincro(postsinc);
				_n.Nodes.Add(hijo);
				_n.Expand();
			}
		}
	}
}
