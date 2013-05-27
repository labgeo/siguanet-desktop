/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 20/07/2006
 * Time: 9:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.ModeloExplotacion;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlArbolEspacios.
	/// </summary>
	public partial class controlArbolEspacios
	{
		private readonly string descInicial;
		private readonly string docInicial;
		
		private TreeNode _nodo;
		private PuntoAcceso _puntoAcceso;
		
		public controlArbolEspacios(TreeNode n)
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
			
			this._nodo = n;
			this._puntoAcceso = (PuntoAcceso) n.Tag;
			this.txDesc.Text = descInicial = _puntoAcceso.Descripcion;
			this.txComent.Text = docInicial = _puntoAcceso.Doc;

			this.lProps.DataSource = this._puntoAcceso.Propiedades.Items;
			this.lProps.DisplayMember = "Titulo";
			this.lProps.ValueMember = "Titulo";

			if(this._puntoAcceso.Propiedades.Items.Count == 0)
			{
				this.splitContainer1.Panel2.Enabled = false;
			}
			else
			{
				this.BindProperty(this._puntoAcceso.Propiedades.Items[0]);
				this.lProps.SelectedItem = this._puntoAcceso.Propiedades.Items[0];
			}
			
			//=============================================================
			this.tsbCopiarProp.Enabled = false;
			this.tsbPegarProp.Enabled = (PaginaPropiedades.ItemsEnBuffer.Count > 0);
			//=============================================================
		}
		
		void TxDescTextChanged(object sender, EventArgs e)
		{
			_puntoAcceso.Descripcion = this.txDesc.Text;
		}
		
		void TxComentTextChanged(object sender, EventArgs e)
		{
			_puntoAcceso.Doc = this.txComent.Text;
		}
		
		void TxDescKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_puntoAcceso.Descripcion = this.txDesc.Text = descInicial;
			}
		}
		
		void TxComentKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_puntoAcceso.Doc = this.txComent.Text = docInicial;
			}	
		}
		
		public DelegadoCambiaArbolEspacios EventoCambiaEstado;
		
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
		
		void TsbNuevaPropClick(object sender, System.EventArgs e)
		{
			PropiedadEscalar prop = new PropiedadEscalar();
			prop.Titulo = "Nueva propiedad";
			prop.Clase = "SIGUANETDesktop.ModeloExplotacion.Espacios.IUnidadGeoEstadistica";			
			this._puntoAcceso.Propiedades.Items.Add(prop);
			this.splitContainer1.Panel2.Enabled = true;
			this.BindProperty(prop);
			this.RefrescarLista();
			this.lProps.SelectedItem = prop;
		}
		
		void TsbBorrarPropClick(object sender, System.EventArgs e)
		{
			if (this.lProps.SelectedItem != null)
			{
				PropiedadEscalar prop = (PropiedadEscalar) this.lProps.SelectedItem;
				this._puntoAcceso.Propiedades.Items.Remove(prop);
				
				if (this._puntoAcceso.Propiedades.Items.Count > 0)
				{
					PropiedadEscalar nextprop = this._puntoAcceso.Propiedades.Items[0];
					this.splitContainer1.Panel2.Enabled = true;
					this.BindProperty(nextprop);
					this.RefrescarLista();
					this.lProps.SelectedItem = nextprop;
				}
				else
				{
					this.splitContainer1.Panel2.Enabled = false;
					this.RefrescarLista();
				}
			}
		}
		
		void TsbSubirPropClick(object sender, System.EventArgs e)
		{
			if (this.lProps.SelectedItem != null)
			{
				int i = this.lProps.SelectedIndex;
				if (i > 0)
				{
					PropiedadEscalar prop = (PropiedadEscalar) this.lProps.SelectedItem;
					this.ReOrdenar((PropiedadEscalar) prop, i, -1);
					this.lProps.SelectedItem = prop;					
				}
			}
		}
		
		void TsbBajarPropClick(object sender, System.EventArgs e)
		{
			if (this.lProps.SelectedItem != null)
			{
				int i = this.lProps.SelectedIndex;
				if ((i > -1) && (i < this.lProps.Items.Count -1))
				{
					PropiedadEscalar prop = (PropiedadEscalar) this.lProps.SelectedItem;
					this.ReOrdenar((PropiedadEscalar) this.lProps.SelectedItem, i, 1);
					this.lProps.SelectedItem = prop;
				}
			}			
		}
		
		private void ReOrdenar(PropiedadEscalar prop, int posInicial, int desplazamiento)
		{
			this._puntoAcceso.Propiedades.Items.RemoveAt(posInicial);
			this._puntoAcceso.Propiedades.Items.Insert(posInicial + desplazamiento, prop);
			this.RefrescarLista();
	
		}
		
		private void RefrescarLista()
		{
			BindingManagerBase bm = this.lProps.BindingContext[this._puntoAcceso.Propiedades.Items];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		

		void LPropsSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lProps.SelectedIndex >= 0)
			{
				PropiedadEscalar prop = (PropiedadEscalar) this.lProps.Items[this.lProps.SelectedIndex];
				if (this.txTituloProp.DataBindings.Count == 0)
				{
					this.splitContainer1.Panel2.Enabled = true;
					this.BindProperty(prop);
				}
				else
				{
					if (!this.txTituloProp.DataBindings[0].DataSource.Equals(prop))
					{
						this.splitContainer1.Panel2.Enabled = true;
						this.BindProperty(prop);
					}					
				}
			}
			else
			{
				this.splitContainer1.Panel2.Enabled = false;
			}
		}
		
		private void BindProperty(PropiedadEscalar prop)
		{
			this.txTituloProp.DataBindings.Clear();
			this.txDescProp.DataBindings.Clear();
			this.txClaseProp.DataBindings.Clear();
			this.txMetodoEscalarProp.DataBindings.Clear();
			this.txMetodoDataSetProp.DataBindings.Clear();
			this.txTituloDataSetProp.DataBindings.Clear();
			this.txValorDefEscalarProp.DataBindings.Clear();
			this.txFormatoEscalarProp.DataBindings.Clear();
			this.txFormatoPresentacionProp.DataBindings.Clear();
			this.cbGrupoProp.DataBindings.Clear();
			this.cbComportamientoProp.DataBindings.Clear();
			this.txTituloProp.DataBindings.Add("Text", prop, "Titulo");
			this.txDescProp.DataBindings.Add("Text", prop, "Descripcion");
			this.txClaseProp.DataBindings.Add("Text", prop, "Clase");
			this.txMetodoEscalarProp.DataBindings.Add("Text", prop, "MetodoEscalar");
			this.txMetodoDataSetProp.DataBindings.Add("Text", prop, "MetodoDataSet");
			this.txTituloDataSetProp.DataBindings.Add("Text", prop, "TituloDataSet");
			this.txValorDefEscalarProp.DataBindings.Add("Text", prop, "ValorDefectoEscalar");
			this.txFormatoEscalarProp.DataBindings.Add("Text", prop, "FormatoEscalar");
			this.txFormatoPresentacionProp.DataBindings.Add("Text", prop, "FormatoCadena");
			this.cbGrupoProp.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbGrupoProp.DataSource = Enum.GetValues(typeof(PropiedadEscalar.TipoGrupo));
			this.cbGrupoProp.DataBindings.Add("SelectedItem", prop, "Grupo");
			this.cbComportamientoProp.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbComportamientoProp.DataSource = Enum.GetValues(typeof(PropiedadEscalar.TipoComportamiento));
			this.cbComportamientoProp.DataBindings.Add("SelectedItem", prop, "Accion");
		}
		
		void TxTituloPropValidated(object sender, System.EventArgs e)
		{
			this.RefrescarLista();
		}
		
		void TxClasePropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void TxMetodoEscalarPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void TxMetodoDataSetPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void TxFormatoEscalarPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void TxFormatoPresentacionPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void CbComportamientoPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void TxDescPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void TxValorDefEscalarPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void CbGrupoPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void TxTituloDataSetPropValidated(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}

		void TsbCopiarPropClick(object sender, EventArgs e)
		{
			List<PropiedadEscalar> sel = new List<PropiedadEscalar>();
			foreach (PropiedadEscalar p in this.lProps.CheckedItems)
			{
				sel.Add(p);
			}
			this._puntoAcceso.Propiedades.CopiarPropiedades(sel);
			this.tsbPegarProp.Enabled = true;
		}
		
		void TsbPegarPropClick(object sender, EventArgs e)
		{
			this._puntoAcceso.Propiedades.PegarPropiedades();
			this.RefrescarLista();
		}
		
		void LPropsItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.NewValue == CheckState.Checked)
			{
				this.tsbCopiarProp.Enabled = true;
				if (this.lProps.CheckedItems.Count == this.lProps.Items.Count -1)
				{
					this.tsbSelector.Checked = true;
				}
			}
			else
			{
				this.tsbCopiarProp.Enabled = (this.lProps.CheckedItems.Count > 1);
				this.tsbSelector.Checked = false;
			}
		}

		void TsbSelectorClick(object sender, EventArgs e)
		{
			CheckState cs = (this.tsbSelector.Checked ? CheckState.Checked : CheckState.Unchecked);
			for (int i = 0; i < this.lProps.Items.Count; i++)
			{
				this.lProps.SetItemCheckState(i, cs);
			}
		}
	}
	
	public delegate void DelegadoCambiaArbolEspacios(estadoModelo estado);		
}
