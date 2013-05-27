/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 04/12/2006
 * Time: 9:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.GUI
{
	public delegate void DelegadoInicioModuloArbolDatos(int totalPasos);
	public delegate void DelegadoPasoModuloArbolDatos(int numPasos);
	/// <summary>
	/// Description of frmArbolDatos.
	/// </summary>
	public partial class frmArbolDatos
	{
		private DataSet _ds = null;
		private object _consulta = null;
		private string _tituloForm = string.Empty;
		private IUnidadGeoEstadistica _uge = null;
		
		private TreeNode nodoBaseOrg = new TreeNode(AdministradorPreferencias.Read(PrefsGlobal.OrgAcronym));
		
		public DelegadoInicioModuloArbolDatos EventoInicioModulo;
        public DelegadoPasoModuloArbolDatos EventoPasoModulo;
        
		public frmArbolDatos(object consulta, DataSet ds, string tituloForm, IUnidadGeoEstadistica uge)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this._consulta = consulta;
			this._ds = ds;
			this._tituloForm = tituloForm;
			this._uge = uge;			
		}
		
		public void CargarDatos()
		{
			string ambito = string.Empty;
			if (this._uge.GetType() == typeof (BaseOrg))
			    {
			    	ambito = AdministradorPreferencias.Read(PrefsGlobal.OrgName);
			    }
			else if (this._uge.GetType() == typeof (Zona))
			    {
				ambito = (this._uge as Zona).Denominacion;
			    }
			else if (this._uge.GetType() == typeof (Edificio))
			    {
				ambito = (this._uge as Edificio).Denominacion;
			    }
			else if (this._uge.GetType() == typeof (PlantaBase))
			    {
				ambito = string.Format("{0} en {1}", (this._uge as PlantaBase).Planta.ToString(), 
				                       AdministradorPreferencias.Read(PrefsGlobal.OrgName));
			    }
			else if (this._uge.GetType() == typeof (PlantaZona))
			    {
				ambito = (this._uge as PlantaZona).Planta.ToString() + " en " + (this._uge as PlantaZona).Zona.Denominacion;
			    }						
			else if (this._uge.GetType() == typeof (PlantaEdificio))
			    {
				ambito = (this._uge as PlantaEdificio).Denominacion;
			    }			

			this.Text = string.Format("SIGUANETDesktop TreeDATA ({0}) - {1}", ambito, this._tituloForm);
						
			this.nodoBaseOrg.Tag = new BaseOrg();
			int i = 0;
			if (this._consulta != null)
			{
				if (this._consulta is List<Estancia>)
				{
					EventoInicioModulo((this._consulta as List<Estancia>).Count);
					foreach (Estancia e in (List<Estancia>) this._consulta)
					{
						TreeNode NodoPlanta = GUIUtils.obtenerNodoPlanta (e, nodoBaseOrg);
						TreeNode nodoEstancia = new TreeNode(e.Codigo);
						nodoEstancia.Tag = e;
						NodoPlanta.Nodes.Add(nodoEstancia);
						EventoPasoModulo(++i);
					}				
				}
				else if (this._consulta is List<Ubicacion>)
				{
					EventoInicioModulo((this._consulta as List<Ubicacion>).Count);
					foreach (Ubicacion u in (List<Ubicacion>) this._consulta)
					{
						TreeNode NodoPlanta = GUIUtils.obtenerNodoPlanta (u.Estancia, nodoBaseOrg);
						TreeNode nodoUbicacion = new TreeNode(u.Persona.ToString());
						nodoUbicacion.Tag = u;
						NodoPlanta.Nodes.Add(nodoUbicacion);
						EventoPasoModulo(++i);
					}
				}
			}

			this.twNavegador.Nodes.Add(this.nodoBaseOrg);
			if (this._ds != null)
			{
				if (this._ds.Tables.Count > 0)
				{
					this.dg.DataSource = this._ds.Tables[0];
					this.tslNumFilas.Text = string.Format("{0} registros", this._ds.Tables[0].Rows.Count);
				}
			}
		}
		
		void SeleccionarNodo(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
		{
			this.twNavegador.SelectedNode = e.Node;
			this.RefrescarDatos(this.twNavegador.SelectedNode);
		}
		
		private void RefrescarDatos(TreeNode nodo)
		{
			
			if (this._ds != null)
			{
				if (this._ds.Tables.Count > 0)
				{
					DataView dv = new DataView();

					dv.Table = this._ds.Tables[0];
					dv.AllowDelete = false;
					dv.AllowEdit = false;
					dv.AllowNew = false;
					//Comprueba el nodo que está seleccionado
					if (nodo.Tag.GetType() == typeof(BaseOrg))
					{
						dv.RowFilter = string.Empty;
					}
					if (nodo.Tag.GetType() == typeof(Zona))
					{
		    			dv.RowFilter = string.Format("codzona = '{0}'", (nodo.Tag as Zona).Codigo);
					}			
					if (nodo.Tag.GetType() == typeof(Edificio))
					{
		    			dv.RowFilter = string.Format("codedificio = '{0}'", (nodo.Tag as Edificio).Codigo);
					}
					if (nodo.Tag.GetType() == typeof(PlantaEdificio) )
					{
		    			dv.RowFilter = string.Format("codplantaedif = '{0}'", (nodo.Tag as PlantaEdificio).Codigo);
					}
					if (nodo.Tag.GetType() == typeof(Estancia))
					{
		    			dv.RowFilter = string.Format("codigo = '{0}'", (nodo.Tag as Estancia).Codigo);
					}
					if (nodo.Tag.GetType() == typeof(Ubicacion))
					{
		    			dv.RowFilter = string.Format("nif = '{0}'", (nodo.Tag as Ubicacion).Persona.NIF);
					}					
					this.dg.DataSource = dv;
					this.tslNumFilas.Text = string.Format("{0} registros", dv.Count);
				}
			}			
		}		
	}
}
