/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 21/09/2006
 * Time: 9:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using SIGUANETDesktop.ModeloExplotacion.Utilidades;
using SIGUANETDesktop.ModeloCartografia.Simbologia;
using SharpMap;
using SharpMap.Geometries;
using System.ComponentModel;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloCartografia;
using SIGUANETDesktop.Topologia;
using PdfSharp;
using PdfSharp.Forms;
using SIGUANETDesktop.ModeloCartografia.PDF;
using SIGUANETDesktop.Preferencias;


namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmArbolMapa.
	/// </summary>
	public partial class frmArbolMapa
	{
		private DataSet _ds = null;
		private object _consulta = null;
		private string _tituloForm = string.Empty;
		private IUnidadGeoEstadistica _uge = null;
		
		//Declaración de Grupos
		private ListViewGroup _lvgGeneral = new ListViewGroup("General", HorizontalAlignment.Left);
		private ListViewGroup _lvgLugar = new ListViewGroup("Emplazamiento", HorizontalAlignment.Left);
		private ListViewGroup _lvgAdscripcion = new ListViewGroup("Adscripción", HorizontalAlignment.Left);
		private ListViewGroup _lvgUso = new ListViewGroup("Uso", HorizontalAlignment.Left);
		private ListViewGroup _lvgOcupacion = new ListViewGroup("Ocupacion", HorizontalAlignment.Left);
		private ListViewGroup _lvgPersonal = new ListViewGroup("Personal", HorizontalAlignment.Left);
		
		//Declaración de Items
		private ListViewItem _lviCodEstancia = new ListViewItem(new string[2] {"Código SIGUANET", string.Empty});
		private ListViewItem _lviDenoEstancia = new ListViewItem(new string[2] {"Denominación", string.Empty});
		private ListViewItem _lviSuperficie = new ListViewItem(new string[2] {"Superficie", string.Empty});
		
		private ListViewItem _lviCodZona = new ListViewItem(new string[2] {"Código Campus/Sede", string.Empty});
		private ListViewItem _lviNomZona = new ListViewItem(new string[2] {"Nombre Campus/Sede", string.Empty});
		private ListViewItem _lviCodEdificio = new ListViewItem(new string[2] {"Código Edificio", string.Empty});
		private ListViewItem _lviNomEdificio = new ListViewItem(new string[2] {"Nombre Edificio", string.Empty});
		private ListViewItem _lviPlanta = new ListViewItem(new string[2] {"Planta", string.Empty});
		
		private ListViewItem _lviCodActividad = new ListViewItem(new string[2] {"Codigo actividad", string.Empty});
		private ListViewItem _lviDescriActividad = new ListViewItem(new string[2] {"Descripción Actividad", string.Empty});
		
		private ListViewItem _lviCodDpto = new ListViewItem(new string[2] {"Código Dpto./Unidad", string.Empty});
		private ListViewItem _lviNomDpto = new ListViewItem(new string[2] {"Nombre Dpto./Unidad", string.Empty});
		
		private ListViewItem _lviNumOcupantes = new ListViewItem(new string[2] {"Nº ocupantes", string.Empty});
		
		private TreeNode nodoBaseOrg = new TreeNode(AdministradorPreferencias.Read(PrefsGlobal.OrgAcronym));
		
        private SharpMap.Map Mapa;
        private PDFMap MapaPDF = null;

		private SharpMap.Geometries.Point ultimaPosicion;
		
		private AdminMapas.TipoMapa _tipoMapa = AdminMapas.TipoMapa.Predeterminado;
		private TipoPaleta _tipoPaleta = TipoPaleta.predeterminada;
		
		private bool PDFLeyenda = true;
		
        public DelegadoInicioModuloArbolMapa EventoInicioModulo;
        public DelegadoPasoModuloArbolMapa EventoPasoModulo;
        

        public frmArbolMapa(object consulta, DataSet ds, string tituloForm, IUnidadGeoEstadistica uge)
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

			this.Text = string.Format("SIGUANETDesktop TreeMAP ({0}) - {1}", ambito, this._tituloForm);
			
			this.cbPaletaDinamica.DataSource = Enum.GetNames(typeof(TipoPaleta));
			this.cbPaletaDinamica.SelectedItem = Enum.GetName(typeof(TipoPaleta), TipoPaleta.predeterminada);
			this.cbPaletaDinamica.DropDownStyle = ComboBoxStyle.DropDownList;
			this.tpLeyenda.Enabled = false;
			this.tpPDF.Enabled = false;
			this.tsbPDFLeyenda.Checked = this.PDFLeyenda;
			
			if (this._ds != null)
			{
				if (this._ds.Tables.Count > 0)
				{
					this.dg.DataSource = this._ds.Tables[0];
					this.tslNumFilas.Text = string.Format("{0} registros", this._ds.Tables[0].Rows.Count);
				}
			}
			
			this.listInfo.GridLines = true;
			
			this.listInfo.Groups.Add(this._lvgGeneral);
			this.listInfo.Groups.Add(this._lvgLugar);
			this.listInfo.Groups.Add(this._lvgAdscripcion);
			this.listInfo.Groups.Add(this._lvgUso);
			this.listInfo.Groups.Add(this._lvgOcupacion);
			this.listInfo.Groups.Add(this._lvgPersonal);
			
			this.listInfo.Items.Add(this._lviCodEstancia);
			this.listInfo.Items.Add(this._lviDenoEstancia);
			this.listInfo.Items.Add(this._lviSuperficie);
						
			this.listInfo.Items.Add(this._lviCodZona);
			this.listInfo.Items.Add(this._lviNomZona);
			this.listInfo.Items.Add(this._lviCodEdificio);
			this.listInfo.Items.Add(this._lviNomEdificio);
			this.listInfo.Items.Add(this._lviPlanta);
			
			this.listInfo.Items.Add(this._lviCodDpto);
			this.listInfo.Items.Add(this._lviNomDpto);			
						
			this.listInfo.Items.Add(this._lviCodActividad);
			this.listInfo.Items.Add(this._lviDescriActividad);
			
			this.listInfo.Items.Add(this._lviNumOcupantes);
			
			this._lviCodEstancia.Group = this._lvgGeneral;
			this._lviDenoEstancia.Group = this._lvgGeneral;
			this._lviSuperficie.Group = this._lvgGeneral;
			this._lviCodZona.Group = this._lvgLugar;
			this._lviNomZona.Group = this._lvgLugar;
			this._lviCodEdificio.Group = this._lvgLugar;
			this._lviNomEdificio.Group = this._lvgLugar;
			this._lviPlanta.Group = this._lvgLugar;
			this._lviCodDpto.Group = this._lvgAdscripcion;
			this._lviNomDpto.Group = this._lvgAdscripcion;			
			this._lviCodActividad.Group = this._lvgUso;
			this._lviDescriActividad.Group = this._lvgUso;
			this._lviNumOcupantes.Group = this._lvgOcupacion;
			
			this.toolStrip1.Enabled = false;
			
			this.Mapa = new SharpMap.Map(this.miVMapa.Size);
			this.Mapa.BackColor = Color.White;
			this.Mapa.MapRendered += new SharpMap.Map.MapRenderedEventHandler(MapRender);
			
			this.nodoBaseOrg.Tag = new BaseOrg();
			int i = 0;
			if (this._consulta == null)
			{
				List<PlantaEdificio> lpe = null;
				if (this._uge is BaseOrg)
				{
					lpe = (this._uge as BaseOrg).ObtenerPlantasEdificio();
				}
				else if (this._uge is PlantaBase)
				{
					lpe = (this._uge as PlantaBase).ObtenerPlantasEdificio();
				}
				else if (this._uge is Zona)
				{
					lpe = (this._uge as Zona).ObtenerPlantasEdificio();
				}
				else if (this._uge is Edificio)
				{
					lpe = (this._uge as Edificio).ObtenerPlantas();
				}
				else if (this._uge is PlantaZona)
				{
					lpe = (this._uge as PlantaZona).ObtenerPlantasEdificio();
				}
				else if (this._uge is PlantaEdificio)
				{
					lpe = new List<PlantaEdificio>();
					lpe.Add((PlantaEdificio) this._uge);
				}
				if (lpe != null)
				{
					EventoInicioModulo(lpe.Count);
					foreach (PlantaEdificio pe in lpe)
					{
						TreeNode NodoEdificio = GUIUtils.obtenerNodoEdificio (pe, nodoBaseOrg);
						TreeNode nodoPlanta = new TreeNode(pe.Codigo);
						nodoPlanta.Tag = pe;
						NodoEdificio.Nodes.Add(nodoPlanta);
						EventoPasoModulo(++i);
					}
				}
			}
			else if (this._consulta is List<Estancia>)
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
			this.twNavegador.Nodes.Add(this.nodoBaseOrg);			
		}
		
		private void MapRender(System.Drawing.Graphics g)
		{
			this.toolStrip1.Enabled = true;
			this.panelLeyenda.Refresh();
		}

		public void SeleccionarNodo (object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
		{
			this.twNavegador.SelectedNode = e.Node;
			this.RefrescarDatos(this.twNavegador.SelectedNode);
			this.RefrescarMapa(this.twNavegador.SelectedNode);
		}
	
		void eZoomTodo(object sender, System.EventArgs e)
		{
			this.Mapa.ZoomToExtents();
			this.miVMapa.Refresh();
		}
		
		void eAcercar(object sender, System.EventArgs e)
		{
			this.miVMapa.ActiveTool = controlMapView.Tools.ZoomIn;
			this.tsbAcercar.Checked = true;
			this.tsbAlejar.Checked = false;
			this.tsbPan.Checked = false;
			this.tsbInfo.Checked = false;
		}
		
		void eAlejar(object sender, System.EventArgs e)
		{
			this.miVMapa.ActiveTool = controlMapView.Tools.ZoomOut;
			this.tsbAcercar.Checked = false;
			this.tsbAlejar.Checked = true;
			this.tsbPan.Checked = false;
			this.tsbInfo.Checked = false;			
		}
		
		void ePan(object sender, System.EventArgs e)
		{
			this.miVMapa.ActiveTool = controlMapView.Tools.Pan;
			this.tsbAcercar.Checked = false;
			this.tsbAlejar.Checked = false;
			this.tsbPan.Checked = true;
			this.tsbInfo.Checked = false;		
		}
		
		void eInfo(object sender, System.EventArgs e)
		{
			this.miVMapa.ActiveTool = controlMapView.Tools.Query;
			this.miVMapa.QueryLayerIndex = 0;
			this.miVMapa.Cursor = System.Windows.Forms.Cursors.Help;
			this.tsbAcercar.Checked = false;
			this.tsbAlejar.Checked = false;
			this.tsbPan.Checked = false;	
			this.tsbInfo.Checked = true;
		}
		
		void eConsulta(SharpMap.Data.FeatureDataTable resultado)
		{
			try
			{
				if ((resultado as DataTable).Rows.Count > 0)
				{
					SharpMap.Data.FeatureDataRow fdr = TopoUtils.LocatePolygon2 (this.ultimaPosicion, resultado);
					Estancia est = AdminMapas.RefrescaCapaInfoEst(this.Mapa, fdr[1].ToString());
					this.actualizarPropiedades(est);
					this.tabControl1.SelectedTab = tpInfo;
	                this.miVMapa.Refresh();
				}
			}
			catch (Exception error)
			{
				System.Windows.Forms.MessageBox.Show(error.Message,"Error");
			}
		}
		
		private void actualizarPropiedades(Estancia est)
		{
				this._lviCodEstancia.SubItems[1].Text = est.Codigo;
				this._lviDenoEstancia.SubItems[1].Text = est.Denominacion;
				this._lviSuperficie.SubItems[1].Text = string.Format("{0} m²", est.Geometria.Area.ToString("F"));
				
				this._lviCodZona.SubItems[1].Text = est.PlantaEdificio.Edificio.Zona.Codigo;
				this._lviNomZona.SubItems[1].Text = est.PlantaEdificio.Edificio.Zona.Denominacion;

				this._lviCodEdificio.SubItems[1].Text = est.PlantaEdificio.Edificio.Codigo;
				this._lviNomEdificio.SubItems[1].Text = est.PlantaEdificio.Edificio.Denominacion;

				this._lviPlanta.SubItems[1].Text = est.PlantaEdificio.Planta.ToString();
				
				this._lviCodDpto.SubItems[1].Text = est.Adscripcion.Codigo;
				this._lviNomDpto.SubItems[1].Text = est.Adscripcion.Denominacion;
				
				this._lviCodActividad.SubItems[1].Text = est.Actividad.Codigo.ToString();
				this._lviDescriActividad.SubItems[1].Text = est.Actividad.Denominacion;
				
				this._lviNumOcupantes.SubItems[1].Text = est.NumPersonas().ToString();
				
				if (this._lvgPersonal.Items.Count > 0)
				{
					for (int i = this.listInfo.Items.Count - 1; i >= 0; i--)
					{
						if (this.listInfo.Items[i].Group == this._lvgPersonal) this.listInfo.Items.RemoveAt(i);
					}
				}
				
				foreach (Persona p in est.ObtenerPersonas())
				{
					ListViewItem item = new ListViewItem(new string[2] {string.Empty, p.ToString()});
					this.listInfo.Items.Add(item);
					item.Group = this._lvgPersonal;
				}				
		}
		
		private void limpiarPropiedades()
		{
			foreach (ListViewItem i in this.listInfo.Items)
			{
				i.SubItems[1].Text = string.Empty;
			}			
		}		
		
		void RbPredeterminadoCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.rbPredeterminado.Checked == true)
			{
				this._tipoMapa = AdminMapas.TipoMapa.Predeterminado;
				this._tipoPaleta = TipoPaleta.predeterminada;
	        	this.RefrescarMapa(this.twNavegador.SelectedNode);
	        	this.panelLeyenda.Refresh();
	        
			}
		}
		
		void RbTemaUsoCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.rbTemaUso.Checked == true)
			{
				this._tipoMapa = AdminMapas.TipoMapa.TemaUso;
	        	
	        	// En el caso de que se seleccione trama
				if (this.chTrama.Checked) 
				{
					this._tipoPaleta = TipoPaleta.tramado;
				}
				else
				{
					this._tipoPaleta = TipoPaleta.predeterminada;
				}	        	
				this.RefrescarMapa(this.twNavegador.SelectedNode);
	            this.panelLeyenda.Refresh();
			}
		}
		
		void RbTemaAdscripcionCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.rbTemaAdscripcion.Checked == true)
			{
				this._tipoMapa = AdminMapas.TipoMapa.TemaAdscripcion;
	        	this._tipoPaleta = (TipoPaleta) Enum.Parse(typeof(TipoPaleta), (string) this.cbPaletaDinamica.SelectedItem);
	        	this.RefrescarMapa(this.twNavegador.SelectedNode);
	        	this.panelLeyenda.Refresh();
			}				
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
		
		private void RefrescarMapa(TreeNode nodo)
		{
			//Comprueba el nodo que está seleccionado
			if (nodo.Tag.GetType() == typeof(BaseOrg))
			{
				this.limpiarPropiedades();
				this.tpLeyenda.Enabled = false;
				this.panelLeyenda.Refresh();
				this.tpPDF.Enabled = false;
				this.Preview.SetRenderEvent(null);
				this.tsbPDFGuardar.Enabled = false;
				this.tsbPDFImprimir.Enabled = false;
				this.miVMapa.Visible = false;
				this.toolStrip1.Enabled = false;
				
			}
			
			if (nodo.Tag.GetType() == typeof(Zona))
			{
				this.limpiarPropiedades();
				this.tpLeyenda.Enabled = false;
				this.panelLeyenda.Refresh();
				this.tpPDF.Enabled = false;
				this.Preview.SetRenderEvent(null);
				this.tsbPDFGuardar.Enabled = false;
				this.tsbPDFImprimir.Enabled = false;
				this.miVMapa.Visible = false;
				this.toolStrip1.Enabled = false;
				
			}
			
			if (nodo.Tag.GetType() == typeof(Edificio))
			{
				this.limpiarPropiedades();
				this.tpLeyenda.Enabled = false;
				this.panelLeyenda.Refresh();
				this.tpPDF.Enabled = false;
				this.Preview.SetRenderEvent(null);				
				this.tsbPDFGuardar.Enabled = false;
				this.tsbPDFImprimir.Enabled = false;
				this.miVMapa.Visible = false;
				this.toolStrip1.Enabled = false;
				
			}
			
			// Para la planta del edificio
			if (nodo.Tag.GetType() == typeof(PlantaEdificio) )
			{
				PlantaEdificio pe = (PlantaEdificio) nodo.Tag;
				this.limpiarPropiedades();
				this.tpLeyenda.Enabled = true;
				this.tpPDF.Enabled = true;
				this.Preview.SetRenderEvent(null);
				this.tsbPDFGuardar.Enabled = false;
				this.tsbPDFImprimir.Enabled = false;
				
				this.miVMapa.Visible = true;
                // Crear una lista de geometria a partir de los nodos hijos de PlantaEdificio
                List<Geometry> lp = new List<Geometry>();
                
                foreach(TreeNode n in nodo.Nodes)
                {
                	Estancia estHija;
                	if (n.Tag is Estancia)
                	{
	                	estHija = (Estancia) n.Tag;
	                	lp.Add(estHija.Geometria);
                	}
                	else if (n.Tag is Ubicacion)
                	{
                		estHija = (n.Tag as Ubicacion).Estancia;
                		lp.Add(estHija.Geometria);
                	}
                }

			 	AdminMapas.CrearMapa(this.panelLeyenda.CreateGraphics(), this.Mapa, 
			 	                     (IUnidadGeoEstadistica) pe, lp, null, 
			 	                     this._tipoMapa, this._tipoPaleta);
			 				 	
			 	this.miVMapa.Map = this.Mapa;
			}
			
			// Si es un nodo de estancia
			if (nodo.Tag.GetType() == typeof(Estancia))
			{
				Estancia est = (Estancia) nodo.Tag;
				this.actualizarPropiedades(est);
				this.tpLeyenda.Enabled = true;
				this.tpPDF.Enabled = true;
				this.Preview.SetRenderEvent(null);
				this.tsbPDFGuardar.Enabled = false;
				this.tsbPDFImprimir.Enabled = false;
				this.miVMapa.Visible = true;
                // Selección de elementos de la consulta
                List<Geometry> lp = new List<Geometry>();
                foreach(TreeNode n in nodo.Parent.Nodes)
                {
                	Estancia estHija = (Estancia) n.Tag;
                	lp.Add(estHija.Geometria);
                }
			 	
			 	AdminMapas.CrearMapa(this.panelLeyenda.CreateGraphics(), this.Mapa, 
			 	                     (IUnidadGeoEstadistica) est.PlantaEdificio, lp, est, 
			 	                     this._tipoMapa, this._tipoPaleta);
			 	
               	this.miVMapa.Map = this.Mapa;
			}
			
			// Si es un nodo de ubicacion
			if (nodo.Tag.GetType() == typeof(Ubicacion))
			{
				Estancia est = (nodo.Tag as Ubicacion).Estancia;
				this.actualizarPropiedades(est);
				this.tpLeyenda.Enabled = true;
				this.miVMapa.Visible = true;
                // Selección de elementos de la consulta
                List<Geometry> lp = new List<Geometry>();
                foreach(TreeNode n in nodo.Parent.Nodes)
                {
                	Estancia estHija = (n.Tag as Ubicacion).Estancia;
                	lp.Add(estHija.Geometria);
                }
			 	
			 	AdminMapas.CrearMapa(this.panelLeyenda.CreateGraphics(), this.Mapa, 
			 	                     (IUnidadGeoEstadistica) est.PlantaEdificio, lp, est, 
			 	                     this._tipoMapa, this._tipoPaleta);
			 	
               	this.miVMapa.Map = this.Mapa;
			}			
		}
		
		void pintaLeyenda(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (this.twNavegador.SelectedNode != null)
			{
				if ((this.twNavegador.SelectedNode.Tag is PlantaEdificio) || 
				    (this.twNavegador.SelectedNode.Tag is Estancia) ||
				    (this.twNavegador.SelectedNode.Tag is Ubicacion))
				{
					AdminMapas.Leyenda.Render();
				}				
			}
		}
		
		void ChTramaCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.chTrama.Checked) 
			{
				this._tipoPaleta = TipoPaleta.tramado;
			}
			else
			{
				this._tipoPaleta = TipoPaleta.predeterminada;
			}
			if (this.rbTemaUso.Checked == true)
			{
				this.RefrescarMapa(this.twNavegador.SelectedNode);
		        this.panelLeyenda.Refresh();
			}
		}
		
		void eMouseUp(SharpMap.Geometries.Point WorldPos, System.Windows.Forms.MouseEventArgs ImagePos)
		{
			ultimaPosicion = WorldPos;			
		}
		
		void CambiarPaletaDinamica(object sender, System.EventArgs e)
		{
	        this._tipoPaleta = (TipoPaleta) Enum.Parse(typeof(TipoPaleta), (string) this.cbPaletaDinamica.SelectedItem);
			this.RefrescarMapa(this.twNavegador.SelectedNode);
        	this.panelLeyenda.Refresh();
		}
		
		
		void ePDFZoomTodo(object sender, System.EventArgs e)
		{
			this.Preview.Zoom = Zoom.FullPage;
		}
		
		void ePDFAcercar(object sender, System.EventArgs e)
		{
			this.Preview.ZoomPercent = GetNewZoom(this.Preview.ZoomPercent, true);
		}
		
		void ePDFAlejar(object sender, System.EventArgs e)
		{
			this.Preview.ZoomPercent = GetNewZoom(this.Preview.ZoomPercent, false);
		}
		
        private int GetNewZoom(int currentZoom, bool larger)
        {
        	int[] values = new int[] {10, 20, 30, 40, 50, 60, 70, 80, 90, 
        							  100, 120, 140, 160, 180, 200,
        							  250, 300, 350, 400, 450, 500,
        							  600, 700, 800};
        	if (currentZoom <= (int) Zoom.Mininum && !larger) return (int) Zoom.Mininum;
			if (currentZoom >= (int) Zoom.Maximum && larger) return (int) Zoom.Maximum;
			if (larger)
			{
				foreach (int v in values)
				{
					if (currentZoom < v) return v;
				}
			}
			else
			{
				Array.Reverse(values);
				foreach (int v in values)
				{
					if (currentZoom > v) return v;
				}				
			}
			return (int) Zoom.Percent100;
        }		
		
		void ePDFImprimir(object sender, System.EventArgs e)
		{
            PrintDocument mapPD = new PrintDocument();
            try
            {
            	this.printDialog1.Document = mapPD;
            	switch (this.printDialog1.ShowDialog())
            	{
            		case DialogResult.OK:
            			if (!mapPD.PrinterSettings.IsValid) throw new ApplicationException("La impresora no es válida");
            			mapPD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(MapPD_PrintMapPage);
            			mapPD.DocumentName = "SIGUANETDesktop MAP (Página de Mapa)";
            			mapPD.Print();
            			if (this.PDFLeyenda)
            			{
            				mapPD.PrintPage -= new System.Drawing.Printing.PrintPageEventHandler(MapPD_PrintMapPage);
            				mapPD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(MapPD_PrintLegendPage);
            				mapPD.DocumentName = "SIGUANETDesktop MAP (Página de Leyenda)";
            				mapPD.Print();
            			}
            			break;
            		default:
            			break;
            	}
            }
            catch (Exception ex)
            {
            	MessageBox.Show(ex.Message, "Error al intentar imprimir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}
		
		private void MapPD_PrintMapPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			MapaPDF.Print(e.Graphics);
            e.HasMorePages = false;
		}

		private void MapPD_PrintLegendPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			MapaPDF.PrintLegend(e.Graphics, AdminMapas.Leyenda);
            e.HasMorePages = false;
		}		
		
		void ePDFRefrescar(object sender, System.EventArgs e)
		{
			List<object> info = new List<object>();
			info.Add(this._tituloForm);
            if (this.twNavegador.SelectedNode.Tag is PlantaEdificio)
            {
            	info.Add((this.twNavegador.SelectedNode.Tag as PlantaEdificio).Edificio);
            	info.Add((this.twNavegador.SelectedNode.Tag as PlantaEdificio));
            }
            if (this.twNavegador.SelectedNode.Tag is Estancia)
            {
            	info.Add((this.twNavegador.SelectedNode.Tag as Estancia).PlantaEdificio.Edificio);
            	info.Add((this.twNavegador.SelectedNode.Tag as Estancia).PlantaEdificio);
            }
            if (this.twNavegador.SelectedNode.Tag is Ubicacion)
            {
            	info.Add((this.twNavegador.SelectedNode.Tag as Ubicacion).Estancia.PlantaEdificio.Edificio);
            	info.Add((this.twNavegador.SelectedNode.Tag as Ubicacion).Estancia.PlantaEdificio);
            }
            
            LayoutHelper.RunTimeTemplates plantilla = LayoutHelper.RunTimeTemplates.BuiltInDINA4PortraitLayout;
            BoundingBox rect = this.Mapa.GetExtents();
            if (rect.Width > rect.Height) plantilla = LayoutHelper.RunTimeTemplates.BuiltInDINA4LandscapeLayout;

		    this.MapaPDF = new PDFMap(this.Mapa, info, plantilla);
		    this.Preview.PageSize = PdfSharp.PageSizeConverter.ToSize(this.MapaPDF.Layout.Size);
		    if (rect.Width > rect.Height) 
		    {
		    	//Cambiamos a orientación apaisada
		    	System.Drawing.Size landscapeSize = new System.Drawing.Size(this.Preview.PageSize.Height, this.Preview.PageSize.Width);
		    	this.Preview.PageSize = landscapeSize;
		    }
		    this.Preview.SetRenderEvent(MapaPDF.Render);
		    this.tsbPDFGuardar.Enabled = true;
		    this.tsbPDFImprimir.Enabled = true;
		}
		
		void ePDFGuardar(object sender, System.EventArgs e)
		{
			string nomFichero = "SIGUANETDesktop";
            this.saveFileDialog1.AddExtension = true;
            this.saveFileDialog1.DefaultExt = ".pdf";
            if (this.twNavegador.SelectedNode.Tag is PlantaEdificio)
            {
            	nomFichero = (this.twNavegador.SelectedNode.Tag as PlantaEdificio).Codigo;
            }
            if (this.twNavegador.SelectedNode.Tag is Estancia)
            {
            	nomFichero = (this.twNavegador.SelectedNode.Tag as Estancia).PlantaEdificio.Codigo;
            }
            if (this.twNavegador.SelectedNode.Tag is Ubicacion)
            {
            	nomFichero = (this.twNavegador.SelectedNode.Tag as Ubicacion).Estancia.PlantaEdificio.Codigo;
            }            
            this.saveFileDialog1.FileName = String.Format("{0}.pdf", nomFichero);
            this.saveFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf";
            this.saveFileDialog1.Title = "Guardar como PDF";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
            	if (this.PDFLeyenda) 
            	{
            		this.MapaPDF.Save(this.saveFileDialog1.FileName, AdminMapas.Leyenda);
            	}
            	else
            	{
            		this.MapaPDF.Save(this.saveFileDialog1.FileName);
            	}
            }				
		}
		
		void ePDFLeyenda(object sender, System.EventArgs e)
		{
			this.PDFLeyenda = this.tsbPDFLeyenda.Checked;
		}
	}
	public delegate void DelegadoInicioModuloArbolMapa(int totalPasos);
	public delegate void DelegadoPasoModuloArbolMapa(int numPasos);	
}
