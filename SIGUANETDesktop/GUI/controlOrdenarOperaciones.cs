/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 16/03/2006
 * Time: 14:00
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
	public delegate void DelegadoCambiaOrdenOperacion(estadoModelo estado);
	
	/// <summary>
	/// Description of controlOrdenarOperaciones.
	/// </summary>
	public partial class controlOrdenarOperaciones
	{
		private DbSyncClient _s;
		private TreeNode _n;

		public controlOrdenarOperaciones(DbSyncClient s, TreeNode n)
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
			this.lOperaciones.DataSource = _s.Operaciones;
			this.lOperaciones.DisplayMember = "Descripcion";
			this.lOperaciones.ValueMember = "Nombre";
		}
		
		public event DelegadoCambiaOrdenOperacion EventoCambiaEstado;
		
		private void BArribaClick(object sender, System.EventArgs e)
		{
			int i = this.lOperaciones.SelectedIndex;
			if (i > 0)
			{
				ReOrdenar((Operacion) this.lOperaciones.SelectedItem, i, -1);
				this.lOperaciones.SelectedIndex = i - 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}
		}
		
		private void BAbajoClick(object sender, System.EventArgs e)
		{
			int i = this.lOperaciones.SelectedIndex;
			if ((i > -1) && (i < this.lOperaciones.Items.Count -1))
			{
				ReOrdenar((Operacion) this.lOperaciones.SelectedItem, i, 1);
				this.lOperaciones.SelectedIndex = i + 1;
				EventoCambiaEstado(estadoModelo.Pendiente);				
			}
		 }
		
		private void ReOrdenar(Operacion o, int posInicial, int desplazamiento)
		{
			_s.Operaciones.RemoveAt(posInicial);
			_s.Operaciones.Insert(posInicial + desplazamiento, o);
			BindingManagerBase bm = this.lOperaciones.BindingContext[_s.Operaciones];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			TreeNode hijo;
			_n.Nodes.Clear();
			foreach (Operacion op in _s.Operaciones)
			{
				hijo = GUIUtils.CrearNodoOperacion(op);
				_n.Nodes.Add(hijo);
				_n.Expand();
			}
		}
	}
}
