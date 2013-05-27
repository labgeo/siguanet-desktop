/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 26/03/2007
 * Time: 19:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.ModeloClienteSOAP;
using SIGUANETDesktop.SOAP;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlSesionSOAP.
	/// </summary>
	public partial class controlSesionSOAP
	{
		private readonly string descInicial;
		private readonly string docInicial;
		
		private TreeNode _nodo;
		private bool _usarGrupos;
		private SesionSOAP _sesion;
		
		public controlSesionSOAP(TreeNode n, bool usarGrupos)
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
			
			_nodo = n;
			_sesion = (SesionSOAP) n.Tag;
			this.txDesc.Text = descInicial = _sesion.Descripcion;
			this.txComent.Text = docInicial = _sesion.Doc;

			this.lMI.DataSource = this._sesion.ServiceInfo.InitMethods;
			this.lMI.DisplayMember = "Name";
			this.lMI.ValueMember = "Name";
			if(this._sesion.ServiceInfo.InitMethods.Count == 0)
			{
				this.splitContainer1.Panel2.Enabled = false;
			}
			else
			{
				this.lMI.SelectedItem = this._sesion.ServiceInfo.InitMethods[0];
			}
			
			this.lMV.DataSource = this._sesion.ServiceInfo.VisibleMethods;
			this.lMV.DisplayMember = "Name";
			this.lMV.ValueMember = "Name";
			if(this._sesion.ServiceInfo.VisibleMethods.Count == 0)
			{
				this.splitContainer2.Panel2.Enabled = false;
			}
			else
			{
				this.lMV.SelectedItem = this._sesion.ServiceInfo.VisibleMethods[0];
			}
			
			//Lista de grupos comunes
			this.lGC.DataSource = this._sesion.ServiceInfo.PublicContainer.Groups;
			this.lGC.DisplayMember = "Label";
			this.lGC.ValueMember = "Label";
			if(this._sesion.ServiceInfo.PublicContainer.Groups.Count == 0)
			{
				this.containerGC.Panel2.Enabled = false;
			}
			else
			{
				this.lGC.SelectedItem = this._sesion.ServiceInfo.PublicContainer.Groups[0];
			}			
			
			//Lista de grupos específicos
			this.lGE.DataSource = this._sesion.ServiceInfo.PrivateContainer.Groups;
			this.lGE.DisplayMember = "Label";
			this.lGE.ValueMember = "Label";
			if(this._sesion.ServiceInfo.PrivateContainer.Groups.Count == 0)
			{
				this.containerGE.Panel2.Enabled = false;
			}
			else
			{
				this.lGE.SelectedItem = this._sesion.ServiceInfo.PrivateContainer.Groups[0];
			}
			
			//Combo de grupos comunes
			this.cGC.DataSource = this._sesion.ServiceInfo.PublicContainer.Groups;
			this.cGC.DisplayMember = "Label";
			this.cGC.ValueMember = "Label";
			if(this._sesion.ServiceInfo.PublicContainer.Groups.Count == 0)
			{
				this.toolsMC.Enabled = false;
				this.lbMC.Enabled = false;
				this.lMC.Enabled = false;
				this.containerMC.Panel2.Enabled = false;
			}
			else
			{
				this.toolsMC.Enabled = true;
				this.lbMC.Enabled = true;
				this.lMC.Enabled = true;
				this.cGC.SelectedItem = this._sesion.ServiceInfo.PublicContainer.Groups[0];
				if (this._sesion.ServiceInfo.PublicContainer.Groups[0].Methods.Count == 0)
				{
					this.containerMC.Panel2.Enabled = false;
				}
				else
				{
					this.containerMC.Panel2.Enabled = true;
				}
			}
			
			//Combo de grupos específicos
			this.cGE.DataSource = this._sesion.ServiceInfo.PrivateContainer.Groups;
			this.cGE.DisplayMember = "Label";
			this.cGE.ValueMember = "Label";
			if(this._sesion.ServiceInfo.PrivateContainer.Groups.Count == 0)
			{
				this.toolsME.Enabled = false;
				this.lbME.Enabled = false;
				this.lME.Enabled = false;
				this.containerME.Panel2.Enabled = false;
			}
			else
			{
				this.toolsME.Enabled = true;
				this.lbME.Enabled = true;
				this.lME.Enabled = true;
				this.containerME.Panel2.Enabled = true;
				this.cGE.SelectedItem = this._sesion.ServiceInfo.PrivateContainer.Groups[0];
				if (this._sesion.ServiceInfo.PrivateContainer.Groups[0].Methods.Count == 0)
				{
					this.containerME.Panel2.Enabled = false;
				}
				else
				{
					this.containerME.Panel2.Enabled = true;
				}
			}
			
			//¡IMPORTANTE! Al final del constructor
			//nos deshacemos de los TabPage en función de usarGrupos
			this._usarGrupos = usarGrupos;
			if (this._usarGrupos)
			{
				this.tcPrincipal.TabPages.Remove(this.tpMV);
			}
			else
			{
				this.tcPrincipal.TabPages.Remove(this.tpMC);
				this.tcPrincipal.TabPages.Remove(this.tpME);
				this.tcPrincipal.TabPages.Remove(this.tpGC);
				this.tcPrincipal.TabPages.Remove(this.tpGE);
			}
		}
		
		void TxDescTextChanged(object sender, EventArgs e)
		{
			_sesion.Descripcion = this.txDesc.Text;
		}
		
		void TxComentTextChanged(object sender, EventArgs e)
		{
			_sesion.Doc = this.txComent.Text;
		}
		
		void TxDescKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_sesion.Descripcion = this.txDesc.Text = descInicial;
			}
		}
		
		void TxComentKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_sesion.Doc = this.txComent.Text = docInicial;
			}	
		}
		
		public DelegadoCambiaSesionSOAP EventoCambiaEstado;
		
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
		
		void TsNuevoMIClick(object sender, System.EventArgs e)
		{
			frmMetodosSOAP frm = new frmMetodosSOAP(this._sesion.ServiceInfo, true);
			DialogResult r = frm.ShowDialog();
			if (r == DialogResult.OK && frm.MetodosSeleccionados.Count > 0)
			{
				foreach (WSDLProxyMethod m in frm.MetodosSeleccionados)
				{
					try
					{
						this._sesion.ServiceInfo.AddInitMethod(m);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error al agregar el método", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}					

				}
				SOAPMethodInfo lastM = this._sesion.ServiceInfo.InitMethods[this._sesion.ServiceInfo.InitMethods.Count - 1];
				this.splitContainer1.Panel2.Enabled = true;
				this.BindInitialMethod(lastM);
				this.RefrescarListaMI();
				this.lMI.SelectedItem = lastM;
			}
		}
		
		void TsBorrarMIClick(object sender, System.EventArgs e)
		{
			if (this.lMI.SelectedItem != null)
			{
				SOAPMethodInfo m = (SOAPMethodInfo) this.lMI.SelectedItem;
				this._sesion.ServiceInfo.InitMethods.Remove(m);
				
				if (this._sesion.ServiceInfo.InitMethods.Count > 0)
				{
					SOAPMethodInfo nextm = this._sesion.ServiceInfo.InitMethods[0];
					this.splitContainer1.Panel2.Enabled = true;
					this.BindInitialMethod(nextm);
					this.RefrescarListaMI();
					this.lMI.SelectedItem = nextm;
				}
				else
				{
					this.splitContainer1.Panel2.Enabled = false;
					this.RefrescarListaMI();
				}
			}
		}
		
		void TsSubirMIClick(object sender, System.EventArgs e)
		{
			if (this.lMI.SelectedItem != null)
			{
				int i = this.lMI.SelectedIndex;
				if (i > 0)
				{
					SOAPMethodInfo m = (SOAPMethodInfo) this.lMI.SelectedItem;
					this.ReOrdenarListaMI(m, i, -1);
					this.lMI.SelectedItem = m;
				}
			}
		}
		
		void TsBajarMIClick(object sender, System.EventArgs e)
		{
			if (this.lMI.SelectedItem != null)
			{
				int i = this.lMI.SelectedIndex;
				if ((i > -1) && (i < this.lMI.Items.Count -1))
				{
					SOAPMethodInfo m = (SOAPMethodInfo) this.lMI.SelectedItem;
					this.ReOrdenarListaMI(m, i, 1);
					this.lMI.SelectedItem = m;
				}
			}
		}
		
		void TsGuardarMIClick(object sender, System.EventArgs e)
		{
			this.GuardarWSUI();
		}
		
		void TsNuevoMVClick(object sender, System.EventArgs e)
		{
			frmMetodosSOAP frm = new frmMetodosSOAP(this._sesion.ServiceInfo, false);
			DialogResult r = frm.ShowDialog();
			if (r == DialogResult.OK && frm.MetodosSeleccionados.Count > 0)
			{
				foreach (WSDLProxyMethod m in frm.MetodosSeleccionados)
				{
					try
					{
						this._sesion.ServiceInfo.AddVisibleMethod(m);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error al agregar el método", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					
				}
				SOAPMethodInfo lastM = this._sesion.ServiceInfo.VisibleMethods[this._sesion.ServiceInfo.VisibleMethods.Count - 1];
				this.splitContainer2.Panel2.Enabled = true;
				this.BindVisibleMethod(lastM);
				this.RefrescarListaMV();
				this.lMV.SelectedItem = lastM;
			}
		}
		
		void TsBorrarMVClick(object sender, System.EventArgs e)
		{
			if (this.lMV.SelectedItem != null)
			{
				SOAPMethodInfo m = (SOAPMethodInfo) this.lMV.SelectedItem;
				this._sesion.ServiceInfo.VisibleMethods.Remove(m);
				
				if (this._sesion.ServiceInfo.VisibleMethods.Count > 0)
				{
					SOAPMethodInfo nextm = this._sesion.ServiceInfo.VisibleMethods[0];
					this.splitContainer2.Panel2.Enabled = true;
					this.BindVisibleMethod(nextm);
					this.RefrescarListaMV();
					this.lMV.SelectedItem = nextm;
				}
				else
				{
					this.splitContainer2.Panel2.Enabled = false;
					this.RefrescarListaMV();
				}
			}
		}
		
		void TsSubirMVClick(object sender, System.EventArgs e)
		{
			if (this.lMV.SelectedItem != null)
			{
				int i = this.lMV.SelectedIndex;
				if (i > 0)
				{
					SOAPMethodInfo m = (SOAPMethodInfo) this.lMV.SelectedItem;
					this.ReOrdenarListaMV(m, i, -1);
					this.lMV.SelectedItem = m;
				}
			}
		}
		
		void TsBajarMVClick(object sender, System.EventArgs e)
		{
			if (this.lMV.SelectedItem != null)
			{
				int i = this.lMV.SelectedIndex;
				if ((i > -1) && (i < this.lMV.Items.Count -1))
				{
					SOAPMethodInfo m = (SOAPMethodInfo) this.lMV.SelectedItem;
					this.ReOrdenarListaMV(m, i, 1);
					this.lMV.SelectedItem = m;
				}
			}
		}
		
		void TsGuardarMVClick(object sender, System.EventArgs e)
		{
			this.GuardarWSUI();
		}
		
		private void RefrescarListaMI()
		{
			BindingManagerBase bm = this.lMI.BindingContext[this._sesion.ServiceInfo.InitMethods];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
		}
		
		private void RefrescarListaMV()
		{
			BindingManagerBase bm = this.lMV.BindingContext[this._sesion.ServiceInfo.VisibleMethods];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			this.ActualizarArbol();
		}
		
		private void ReOrdenarListaMI(SOAPMethodInfo m, int posInicial, int desplazamiento)
		{
			this._sesion.ServiceInfo.InitMethods.RemoveAt(posInicial);
			this._sesion.ServiceInfo.InitMethods.Insert(posInicial + desplazamiento, m);
			this.RefrescarListaMI();	
		}
		
		private void ReOrdenarListaMV(SOAPMethodInfo m, int posInicial, int desplazamiento)
		{
			this._sesion.ServiceInfo.VisibleMethods.RemoveAt(posInicial);
			this._sesion.ServiceInfo.VisibleMethods.Insert(posInicial + desplazamiento, m);
			this.RefrescarListaMV();
		}
		
		private void ActualizarArbol()
		{
			this._nodo.Nodes.Clear();
			this._nodo.Nodes.AddRange(GUIUtils.CrearNodosSOAPMethodInfo(this._sesion.ServiceInfo, this._usarGrupos));
			this._nodo.Expand();
		}
		
		private void GuardarWSUI()
		{
			this.dlgGuardarComo.Title = "Guardar configuración de interfaz de usuario del Servicio Web";
			this.dlgGuardarComo.AddExtension = true;
			this.dlgGuardarComo.DefaultExt = "wsui";
			this.dlgGuardarComo.Filter = "Documentos de configuración de interfaz de usuario WSUI (*.wsui)|*.wsui";
			if ((this.dlgGuardarComo.ShowDialog() == DialogResult.OK) && (this.dlgGuardarComo.FileName != string.Empty))
			{
				try
				{
					this._sesion.ServiceInfo.Serializar(this.dlgGuardarComo.FileName);
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message, "Error al guardar documento WSUI", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}			
			}			
		}
		
		void LMISelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lMI.SelectedIndex >= 0)
			{
				SOAPMethodInfo m = (SOAPMethodInfo) this.lMI.Items[this.lMI.SelectedIndex];
				if (this.txEtiquetaMI.DataBindings.Count == 0)
				{
					this.splitContainer1.Panel2.Enabled = true;
					this.BindInitialMethod(m);
				}
				else
				{
					if (!this.txEtiquetaMI.DataBindings[0].DataSource.Equals(m))
					{
						this.splitContainer1.Panel2.Enabled = true;
						this.BindInitialMethod(m);
					}					
				}
			}
			else
			{
				this.splitContainer1.Panel2.Enabled = false;
			}
		}
		
		void LMVSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lMV.SelectedIndex >= 0)
			{
				SOAPMethodInfo m = (SOAPMethodInfo) this.lMV.Items[this.lMV.SelectedIndex];
				if (this.txEtiquetaMV.DataBindings.Count == 0)
				{
					this.splitContainer2.Panel2.Enabled = true;
					this.BindVisibleMethod(m);
				}
				else
				{
					if (!this.txEtiquetaMV.DataBindings[0].DataSource.Equals(m))
					{
						this.splitContainer2.Panel2.Enabled = true;
						this.BindVisibleMethod(m);
					}					
				}
			}
			else
			{
				this.splitContainer2.Panel2.Enabled = false;
			}
		}
		
		void LParamsMVSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lParamsMV.SelectedIndex >= 0)
			{
				SOAPParamInfo p = (SOAPParamInfo) this.lParamsMV.Items[this.lParamsMV.SelectedIndex];
				if (this.txEtiquetaParamMV.DataBindings.Count == 0)
				{
					this.splitContainer3.Panel2.Enabled = true;
					this.BindParam(p);
				}
				else
				{
					if (!this.txEtiquetaParamMV.DataBindings[0].DataSource.Equals(p))
					{
						this.splitContainer3.Panel2.Enabled = true;
						this.BindParam(p);
					}
				}
			}
			else
			{
				this.splitContainer3.Panel2.Enabled = false;
			}
		}
		
		private void BindInitialMethod(SOAPMethodInfo m)
		{
			this.txEtiquetaMI.DataBindings.Clear();
			this.chAnonimoMI.DataBindings.Clear();
			this.txComentarioMI.DataBindings.Clear();
			this.tsObsoletoMI.Checked = m.Obsolete;
			this.txEtiquetaMI.DataBindings.Add("Text", m, "Label");
			this.chAnonimoMI.DataBindings.Add("Checked", m, "Public");
			this.txComentarioMI.DataBindings.Add("Text", m, "Comment");
		}
		
		private void BindVisibleMethod(SOAPMethodInfo m)
		{
			this.txEtiquetaMV.DataBindings.Clear();
			this.chAnonimoMV.DataBindings.Clear();
			this.txComentarioMV.DataBindings.Clear();
			this.lParamsMV.DataBindings.Clear();
			this.txEtiquetaParamMV.DataBindings.Clear();
			this.txDefaultParamMV.DataBindings.Clear();
			this.chNuloParamMV.DataBindings.Clear();
			this.txOrigenParamMV.DataBindings.Clear();
			this.txMiembroValorParamMV.DataBindings.Clear();
			this.txMiembroDisplayParamMV.DataBindings.Clear();
			this.txComentarioParamMV.DataBindings.Clear();
			this.tsObsoletoMV.Checked = m.Obsolete;
			this.txEtiquetaMV.DataBindings.Add("Text", m, "Label");
			this.chAnonimoMV.DataBindings.Add("Checked", m, "Public");
			this.txComentarioMV.DataBindings.Add("Text", m, "Comment");
			if (m.Parameters.Count == 0)
			{
				this.lParamsMV.DataSource = null;
				this.lParamsMV.Items.Clear();
				this.txEtiquetaParamMV.Clear();
				this.txDefaultParamMV.Clear();
				this.chNuloParamMV.Checked = false;
				this.txOrigenParamMV.Clear();
				this.txMiembroValorParamMV.Clear();
				this.txMiembroDisplayParamMV.Clear();
				this.txComentarioParamMV.Clear();
				this.splitContainer3.Enabled = false;
			}
			else
			{
				this.lParamsMV.DataSource = m.Parameters;
				this.lParamsMV.DisplayMember = "Name";
				this.lParamsMV.ValueMember = "Name";
				this.BindParam(m.Parameters[0]);
				this.lParamsMV.SelectedItem = m.Parameters[0];
				this.splitContainer3.Enabled = true;
			}
		}
		
		private void BindParam(SOAPParamInfo p)
		{
			this.txEtiquetaParamMV.DataBindings.Clear();
			this.txDefaultParamMV.DataBindings.Clear();
			this.chNuloParamMV.DataBindings.Clear();
			this.txOrigenParamMV.DataBindings.Clear();
			this.txMiembroValorParamMV.DataBindings.Clear();
			this.txMiembroDisplayParamMV.DataBindings.Clear();
			this.txComentarioParamMV.DataBindings.Clear();
			this.txEtiquetaParamMV.DataBindings.Add("Text", p, "Label");
			this.txDefaultParamMV.DataBindings.Add("Text", p, "DefaultValue");
			this.chNuloParamMV.DataBindings.Add("Checked", p, "AllowEmpty");
			this.txOrigenParamMV.DataBindings.Add("Text", p, "DataSource");
			this.txMiembroValorParamMV.DataBindings.Add("Text", p, "ValueMember");
			this.txMiembroDisplayParamMV.DataBindings.Add("Text", p, "DisplayMember");
			this.txComentarioParamMV.DataBindings.Add("Text", p, "Comment");
		}
		
		void TxEtiquetaMVValidated(object sender, System.EventArgs e)
		{
			this.ActualizarArbol();
		}
		
		void TsObsoletoMICheckedChanged(object sender, System.EventArgs e)
		{
			if (this.lMI.SelectedIndex >= 0)
			{
				(this.lMI.SelectedItem as SOAPMethodInfo).Obsolete = this.tsObsoletoMI.Checked;
			}
		}
		
		void TsObsoletoMVCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.lMV.SelectedIndex >= 0)
			{
				(this.lMV.SelectedItem as SOAPMethodInfo).Obsolete = this.tsObsoletoMV.Checked;
				this.ActualizarArbol();
			}
		}
		
		void TsNuevoGCClick(object sender, System.EventArgs e)
		{
			this._sesion.ServiceInfo.AddPublicGroup();
			SOAPGroup lastG = this._sesion.ServiceInfo.PublicContainer.Groups[this._sesion.ServiceInfo.PublicContainer.Groups.Count - 1];
			this.containerGC.Panel2.Enabled = true;
			this.BindPublicGroup(lastG);
			this.RefrescarListaGC();
			this.lGC.SelectedItem = lastG;
		}
		
		void TsBorrarGCClick(object sender, System.EventArgs e)
		{
			if (this.lGC.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.lGC.SelectedItem;
				if (g.Methods.Count > 0)
				{
					MessageBox.Show("Este grupo tiene métodos asociados. Primero debe mover estos métodos a otro grupo o borrarlos.", "Imposible borrar el grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				this._sesion.ServiceInfo.PublicContainer.Groups.Remove(g);
				
				if (this._sesion.ServiceInfo.PublicContainer.Groups.Count > 0)
				{
					SOAPGroup nextg = this._sesion.ServiceInfo.PublicContainer.Groups[0];
					this.containerGC.Panel2.Enabled = true;
					this.BindPublicGroup(nextg);
					this.RefrescarListaGC();
					this.lGC.SelectedItem = nextg;
				}
				else
				{
					this.txEtiquetaGC.Clear();
					this.txComentarioGC.Clear();					
					this.containerGC.Panel2.Enabled = false;
					this.RefrescarListaGC();
				}
			}
		}
		
		void TsSubirGCClick(object sender, System.EventArgs e)
		{
			if (this.lGC.SelectedItem != null)
			{
				int i = this.lGC.SelectedIndex;
				if (i > 0)
				{
					SOAPGroup g = (SOAPGroup) this.lGC.SelectedItem;
					this.ReOrdenarListaGC(g, i, -1);
					this.lGC.SelectedItem = g;
				}
			}
		}
		
		void TsBajarGCClick(object sender, System.EventArgs e)
		{
			if (this.lGC.SelectedItem != null)
			{
				int i = this.lGC.SelectedIndex;
				if ((i > -1) && (i < this.lGC.Items.Count -1))
				{
					SOAPGroup g = (SOAPGroup) this.lGC.SelectedItem;
					this.ReOrdenarListaGC(g, i, 1);
					this.lGC.SelectedItem = g;
				}
			}			
		}
		
		void TsGuardarGCClick(object sender, System.EventArgs e)
		{
			this.GuardarWSUI();
		}		
		
		void LGCSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lGC.SelectedIndex >= 0)
			{
				SOAPGroup g = (SOAPGroup) this.lGC.Items[this.lGC.SelectedIndex];
				if (this.txEtiquetaGC.DataBindings.Count == 0)
				{
					this.containerGC.Panel2.Enabled = true;
					this.BindPublicGroup(g);
				}
				else
				{
					if (!this.txEtiquetaGC.DataBindings[0].DataSource.Equals(g))
					{
						this.containerGC.Panel2.Enabled = true;
						this.BindPublicGroup(g);
					}					
				}
			}
			else
			{
				this.txEtiquetaGC.Clear();
				this.txComentarioGC.Clear();
				this.containerGC.Panel2.Enabled = false;
			}
		}
		
		void TxEtiquetaGCValidated(object sender, System.EventArgs e)
		{
			this.RefrescarListaGC();
			this.ActualizarArbol();
		}
		
		private void RefrescarListaGC()
		{
			BindingManagerBase bm = this.lGC.BindingContext[this._sesion.ServiceInfo.PublicContainer.Groups];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			if (this.cGC.SelectedItem != null)
			{
				this.toolsMC.Enabled = true;
				this.lbMC.Enabled = true;
				this.lMC.Enabled = true;
				this.lMC.DataSource = (this.cGC.SelectedItem as SOAPGroup).Methods;
				this.lMC.DisplayMember = "Name";
				this.lMC.ValueMember = "Name";
			}
			else
			{
				this.toolsMC.Enabled = false;
				this.lbMC.Enabled = false;
				this.lMC.DataSource = null;
				this.lMC.Enabled = false;
			}
			this.ActualizarArbol();
		}
		
		private void BindPublicGroup(SOAPGroup g)
		{
			this.txEtiquetaGC.DataBindings.Clear();
			this.txComentarioGC.DataBindings.Clear();
			this.txEtiquetaGC.DataBindings.Add("Text", g, "Label");
			this.txComentarioGC.DataBindings.Add("Text", g, "Comment");
		}
		
		private void ReOrdenarListaGC(SOAPGroup g, int posInicial, int desplazamiento)
		{
			this._sesion.ServiceInfo.PublicContainer.Groups.RemoveAt(posInicial);
			this._sesion.ServiceInfo.PublicContainer.Groups.Insert(posInicial + desplazamiento, g);
			this.RefrescarListaGC();
		}
		
		void TsNuevoGEClick(object sender, System.EventArgs e)
		{
			this._sesion.ServiceInfo.AddPrivateGroup();
			SOAPGroup lastG = this._sesion.ServiceInfo.PrivateContainer.Groups[this._sesion.ServiceInfo.PrivateContainer.Groups.Count - 1];
			this.containerGE.Panel2.Enabled = true;
			this.BindPrivateGroup(lastG);
			this.RefrescarListaGE();
			this.lGE.SelectedItem = lastG;
		}
		
		void TsBorrarGEClick(object sender, System.EventArgs e)
		{
			if (this.lGE.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.lGE.SelectedItem;
				if (g.Methods.Count > 0)
				{
					MessageBox.Show("Este grupo tiene métodos asociados. Primero debe mover estos métodos a otro grupo o borrarlos.", "Imposible borrar el grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				this._sesion.ServiceInfo.PrivateContainer.Groups.Remove(g);
				
				if (this._sesion.ServiceInfo.PrivateContainer.Groups.Count > 0)
				{
					SOAPGroup nextg = this._sesion.ServiceInfo.PrivateContainer.Groups[0];
					this.containerGE.Panel2.Enabled = true;
					this.BindPrivateGroup(nextg);
					this.RefrescarListaGE();
					this.lGE.SelectedItem = nextg;
				}
				else
				{
					this.txEtiquetaGE.Clear();
					this.txComentarioGE.Clear();					
					this.containerGE.Panel2.Enabled = false;
					this.RefrescarListaGE();
				}
			}
		}
		
		void TsSubirGEClick(object sender, System.EventArgs e)
		{
			if (this.lGE.SelectedItem != null)
			{
				int i = this.lGE.SelectedIndex;
				if (i > 0)
				{
					SOAPGroup g = (SOAPGroup) this.lGE.SelectedItem;
					this.ReOrdenarListaGE(g, i, -1);
					this.lGE.SelectedItem = g;
				}
			}
		}
		
		void TsBajarGEClick(object sender, System.EventArgs e)
		{
			if (this.lGE.SelectedItem != null)
			{
				int i = this.lGE.SelectedIndex;
				if ((i > -1) && (i < this.lGE.Items.Count -1))
				{
					SOAPGroup g = (SOAPGroup) this.lGE.SelectedItem;
					this.ReOrdenarListaGE(g, i, 1);
					this.lGE.SelectedItem = g;
				}
			}			
		}
		
		void TsGuardarGEClick(object sender, System.EventArgs e)
		{
			this.GuardarWSUI();
		}
		
		void LGESelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lGE.SelectedIndex >= 0)
			{
				SOAPGroup g = (SOAPGroup) this.lGE.Items[this.lGE.SelectedIndex];
				if (this.txEtiquetaGE.DataBindings.Count == 0)
				{
					this.containerGE.Panel2.Enabled = true;
					this.BindPrivateGroup(g);
				}
				else
				{
					if (!this.txEtiquetaGE.DataBindings[0].DataSource.Equals(g))
					{
						this.containerGE.Panel2.Enabled = true;
						this.BindPrivateGroup(g);
					}
				}
			}
			else
			{
				this.txEtiquetaGE.Clear();
				this.txComentarioGE.Clear();
				this.containerGE.Panel2.Enabled = false;
			}
		}
		
		void TxEtiquetaGEValidated(object sender, System.EventArgs e)
		{
			this.RefrescarListaGE();
			this.ActualizarArbol();
		}
		
		private void RefrescarListaGE()
		{
			BindingManagerBase bm = this.lGE.BindingContext[this._sesion.ServiceInfo.PrivateContainer.Groups];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			if (this.cGE.SelectedItem != null)
			{
				this.toolsME.Enabled = true;
				this.lbME.Enabled = true;
				this.lME.Enabled = true;
				this.lME.DataSource = (this.cGE.SelectedItem as SOAPGroup).Methods;
				this.lME.DisplayMember = "Name";
				this.lME.ValueMember = "Name";				
			}
			else
			{
				this.toolsME.Enabled = false;
				this.lbME.Enabled = false;
				this.lME.DataSource = null;
				this.lME.Enabled = false;
			}
			this.ActualizarArbol();
		}
		
		private void BindPrivateGroup(SOAPGroup g)
		{
			this.txEtiquetaGE.DataBindings.Clear();
			this.txComentarioGE.DataBindings.Clear();
			this.txEtiquetaGE.DataBindings.Add("Text", g, "Label");
			this.txComentarioGE.DataBindings.Add("Text", g, "Comment");
		}
		
		private void ReOrdenarListaGE(SOAPGroup g, int posInicial, int desplazamiento)
		{
			this._sesion.ServiceInfo.PrivateContainer.Groups.RemoveAt(posInicial);
			this._sesion.ServiceInfo.PrivateContainer.Groups.Insert(posInicial + desplazamiento, g);
			this.RefrescarListaGE();
		}
		
		void TsNuevoMCClick(object sender, System.EventArgs e)
		{
			if (this.cGC.SelectedItem != null)
			{
				frmMetodosSOAP frm = new frmMetodosSOAP(this._sesion.ServiceInfo, false);
				DialogResult r = frm.ShowDialog();
				if (r == DialogResult.OK && frm.MetodosSeleccionados.Count > 0)
				{
					SOAPGroup g = (SOAPGroup) this.cGC.SelectedItem;
					foreach (WSDLProxyMethod m in frm.MetodosSeleccionados)
					{
						try
						{
							g.AddMethod(m);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Error al agregar el método", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					SOAPMethodInfo lastM = g.Methods[g.Methods.Count - 1];
					this.containerMC.Panel2.Enabled = true;
					this.BindPublicMethod(lastM);
					this.RefrescarListaMC(g);
					this.lMC.SelectedItem = lastM;
				}
			}
		}
		
		void TsBorrarMCClick(object sender, System.EventArgs e)
		{
			if (this.cGC.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.cGC.SelectedItem;
				if (this.lMC.SelectedItem != null)
				{
					SOAPMethodInfo m = (SOAPMethodInfo) this.lMC.SelectedItem;
					g.Methods.Remove(m);
					if (g.Methods.Count > 0)
					{
						SOAPMethodInfo nextm = g.Methods[0];
						this.containerMC.Panel2.Enabled = true;
						this.BindPublicMethod(nextm);
						this.RefrescarListaMC(g);
						this.lMC.SelectedItem = nextm;
					}
					else
					{
						this.containerMC.Panel2.Enabled = false;
						this.RefrescarListaMC(g);
						this.LMCSelectedIndexChanged(null , null);
					}
				}
			}
		}
		
		void TsSubirMCClick(object sender, System.EventArgs e)
		{
			if (this.cGC.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.cGC.SelectedItem;
				if (this.lMC.SelectedItem != null)
				{
					int i = this.lMC.SelectedIndex;
					if (i > 0)
					{
						SOAPMethodInfo m = (SOAPMethodInfo) this.lMC.SelectedItem;
						this.ReOrdenarListaMC(g, m, i, -1);
						this.lMC.SelectedItem = m;
					}
				}
			}
		}
		
		void TsBajarMCClick(object sender, System.EventArgs e)
		{
			if (this.cGC.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.cGC.SelectedItem;
				if (this.lMC.SelectedItem != null)
				{
					int i = this.lMC.SelectedIndex;
					if ((i > -1) && (i < this.lMC.Items.Count -1))
					{
						SOAPMethodInfo m = (SOAPMethodInfo) this.lMC.SelectedItem;
						this.ReOrdenarListaMC(g, m, i, 1);
						this.lMC.SelectedItem = m;
					}
				}
			}
		}
		
		void TsMoverMCClick(object sender, System.EventArgs e)
		{
			if (this.cGC.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.cGC.SelectedItem;
				if (this.lMC.SelectedItem != null)
				{
					SOAPMethodInfo m = (SOAPMethodInfo) this.lMC.SelectedItem;
					frmGruposSOAP dlg = new frmGruposSOAP(this._sesion.ServiceInfo);
					DialogResult r = dlg.ShowDialog(this);
					if (r == DialogResult.OK && dlg.Grupo != null)
					{
						try
						{
							dlg.Grupo.AddMethod(m);
							if (!dlg.ConservarCopia)
							{
								g.Methods.Remove(m);
								if (g.Methods.Count > 0)
								{
									SOAPMethodInfo nextm = g.Methods[0];
									this.containerMC.Panel2.Enabled = true;
									this.BindPublicMethod(nextm);
									this.RefrescarListaMC(g);
									this.lMC.SelectedItem = nextm;
								}
								else
								{
									this.containerMC.Panel2.Enabled = false;
									this.RefrescarListaMC(g);
									this.LMCSelectedIndexChanged(null, null);
								}
							}
							if (dlg.Grupo.Equals(this.cGE.SelectedItem))
							{
								this.containerME.Panel2.Enabled = true;
								this.BindPrivateMethod(m);
								this.RefrescarListaME(dlg.Grupo);
								this.lME.SelectedItem = m;
							}
							this.ActualizarArbol();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Error al mover el método", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
		}
		
		void TsObsoletoMCCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.cGC.SelectedItem != null)
			{
				if (this.lMC.SelectedIndex >= 0)
				{
					(this.lMC.SelectedItem as SOAPMethodInfo).Obsolete = this.tsObsoletoMC.Checked;
					this.ActualizarArbol();
				}
			}
		}
		
		void TsGuardarMCClick(object sender, System.EventArgs e)
		{
			this.GuardarWSUI();
		}
		
		void CGCSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.cGC.SelectedItem != null)
			{
				this.toolsMC.Enabled = true;
				this.lbMC.Enabled = true;
				this.lMC.Enabled = true;
				this.lMC.DataSource = (this.cGC.SelectedItem as SOAPGroup).Methods;
				this.lMC.DisplayMember = "Name";
				this.lMC.ValueMember = "Name";
				if ((this.cGC.SelectedItem as SOAPGroup).Methods.Count > 0)
				{
					this.lMC.SelectedItem = (this.cGC.SelectedItem as SOAPGroup).Methods[0];
					this.LMCSelectedIndexChanged(null , null);
				}
				else
				{
					this.LMCSelectedIndexChanged(null , null);
				}
			}
			else
			{
				this.toolsMC.Enabled = false;
				this.lbMC.Enabled = false;
				this.lMC.DataSource = null;
				this.lMC.Enabled = false;
				this.LMCSelectedIndexChanged(null , null);
			}
		}
		
		void LMCSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lMC.SelectedIndex >= 0)
			{
				SOAPMethodInfo m = (SOAPMethodInfo) this.lMC.Items[this.lMC.SelectedIndex];
				if (this.txEtiquetaMC.DataBindings.Count == 0)
				{
					this.containerMC.Panel2.Enabled = true;
					this.BindPublicMethod(m);
				}
				else
				{
					if (!this.txEtiquetaMC.DataBindings[0].DataSource.Equals(m))
					{
						this.containerMC.Panel2.Enabled = true;
						this.BindPublicMethod(m);
					}
				}
			}
			else
			{
				this.txEtiquetaMC.DataBindings.Clear();
				this.txComentarioMC.DataBindings.Clear();
				this.lParamsMC.DataBindings.Clear();
				this.txEtiquetaParamMC.DataBindings.Clear();
				this.txDefaultParamMC.DataBindings.Clear();
				this.chNuloParamMC.DataBindings.Clear();
				this.txOrigenParamMC.DataBindings.Clear();
				this.txMiembroValorParamMC.DataBindings.Clear();
				this.txMiembroDisplayParamMC.DataBindings.Clear();
				this.txComentarioParamMC.DataBindings.Clear();
				this.txEtiquetaMC.Clear();
				this.txComentarioMC.Clear();
				this.lParamsMC.DataSource = null;
				this.lParamsMC.Items.Clear();
				this.txEtiquetaParamMC.Clear();
				this.txDefaultParamMC.Clear();
				this.chNuloParamMC.Checked = false;
				this.txOrigenParamMC.Clear();
				this.txMiembroValorParamMC.Clear();
				this.txMiembroDisplayParamMC.Clear();
				this.txComentarioParamMC.Clear();				
				this.containerMC.Panel2.Enabled = false;
			}
		}
		
		void TxEtiquetaMCValidated(object sender, System.EventArgs e)
		{
			this.ActualizarArbol();
		}		
		
		void LParamsMCSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lParamsMC.SelectedIndex >= 0)
			{
				SOAPParamInfo p = (SOAPParamInfo) this.lParamsMC.Items[this.lParamsMC.SelectedIndex];
				if (this.txEtiquetaParamMC.DataBindings.Count == 0)
				{
					this.containerParamsMC.Panel2.Enabled = true;
					this.BindPublicParam(p);
				}
				else
				{
					if (!this.txEtiquetaParamMC.DataBindings[0].DataSource.Equals(p))
					{
						this.containerParamsMC.Panel2.Enabled = true;
						this.BindPublicParam(p);
					}
				}
			}
			else
			{
				this.containerParamsMC.Panel2.Enabled = false;
			}			
		}

		private void RefrescarListaMC(SOAPGroup g)
		{
			BindingManagerBase bm = this.lMC.BindingContext[g.Methods];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			this.ActualizarArbol();
		}
		
		private void ReOrdenarListaMC(SOAPGroup g, SOAPMethodInfo m, int posInicial, int desplazamiento)
		{
			g.Methods.RemoveAt(posInicial);
			g.Methods.Insert(posInicial + desplazamiento, m);
			this.RefrescarListaMC(g);
		}		
		
		private void BindPublicMethod(SOAPMethodInfo m)
		{
			this.txEtiquetaMC.DataBindings.Clear();
			this.txComentarioMC.DataBindings.Clear();
			this.lParamsMC.DataBindings.Clear();
			this.txEtiquetaParamMC.DataBindings.Clear();
			this.txDefaultParamMC.DataBindings.Clear();
			this.chNuloParamMC.DataBindings.Clear();
			this.txOrigenParamMC.DataBindings.Clear();
			this.txMiembroValorParamMC.DataBindings.Clear();
			this.txMiembroDisplayParamMC.DataBindings.Clear();
			this.txComentarioParamMC.DataBindings.Clear();
			this.tsObsoletoMC.Checked = m.Obsolete;
			this.txEtiquetaMC.DataBindings.Add("Text", m, "Label");
			this.txComentarioMC.DataBindings.Add("Text", m, "Comment");
			if (m.Parameters.Count == 0)
			{
				this.lParamsMC.DataSource = null;
				this.lParamsMC.Items.Clear();
				this.txEtiquetaParamMC.Clear();
				this.txDefaultParamMC.Clear();
				this.chNuloParamMC.Checked = false;
				this.txOrigenParamMC.Clear();
				this.txMiembroValorParamMC.Clear();
				this.txMiembroDisplayParamMC.Clear();
				this.txComentarioParamMC.Clear();
				this.containerParamsMC.Enabled = false;
			}
			else
			{
				this.lParamsMC.DataSource = m.Parameters;
				this.lParamsMC.DisplayMember = "Name";
				this.lParamsMC.ValueMember = "Name";
				this.BindPublicParam(m.Parameters[0]);
				this.lParamsMC.SelectedItem = m.Parameters[0];
				this.containerParamsMC.Enabled = true;
			}
		}
		
		private void BindPublicParam(SOAPParamInfo p)
		{
			this.txEtiquetaParamMC.DataBindings.Clear();
			this.txDefaultParamMC.DataBindings.Clear();
			this.chNuloParamMC.DataBindings.Clear();
			this.txOrigenParamMC.DataBindings.Clear();
			this.txMiembroValorParamMC.DataBindings.Clear();
			this.txMiembroDisplayParamMC.DataBindings.Clear();
			this.txComentarioParamMC.DataBindings.Clear();
			this.txEtiquetaParamMC.DataBindings.Add("Text", p, "Label");
			this.txDefaultParamMC.DataBindings.Add("Text", p, "DefaultValue");
			this.chNuloParamMC.DataBindings.Add("Checked", p, "AllowEmpty");
			this.txOrigenParamMC.DataBindings.Add("Text", p, "DataSource");
			this.txMiembroValorParamMC.DataBindings.Add("Text", p, "ValueMember");
			this.txMiembroDisplayParamMC.DataBindings.Add("Text", p, "DisplayMember");
			this.txComentarioParamMC.DataBindings.Add("Text", p, "Comment");
		}
		
		void TsNuevoMEClick(object sender, System.EventArgs e)
		{
			if (this.cGE.SelectedItem != null)
			{
				frmMetodosSOAP frm = new frmMetodosSOAP(this._sesion.ServiceInfo, false);
				DialogResult r = frm.ShowDialog();
				if (r == DialogResult.OK && frm.MetodosSeleccionados.Count > 0)
				{
					SOAPGroup g = (SOAPGroup) this.cGE.SelectedItem;
					foreach (WSDLProxyMethod m in frm.MetodosSeleccionados)
					{
						try
						{
							g.AddMethod(m);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Error al agregar el método", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					SOAPMethodInfo lastM = g.Methods[g.Methods.Count - 1];
					this.containerME.Panel2.Enabled = true;
					this.BindPrivateMethod(lastM);
					this.RefrescarListaME(g);
					this.lME.SelectedItem = lastM;
				}
			}
		}
		
		void TsBorrarMEClick(object sender, System.EventArgs e)
		{
			if (this.cGE.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.cGE.SelectedItem;
				if (this.lME.SelectedItem != null)
				{
					SOAPMethodInfo m = (SOAPMethodInfo) this.lME.SelectedItem;
					g.Methods.Remove(m);
					if (g.Methods.Count > 0)
					{
						SOAPMethodInfo nextm = g.Methods[0];
						this.containerME.Panel2.Enabled = true;
						this.BindPrivateMethod(nextm);
						this.RefrescarListaME(g);
						this.lME.SelectedItem = nextm;
					}
					else
					{
						this.containerME.Panel2.Enabled = false;
						this.RefrescarListaME(g);
						this.LMESelectedIndexChanged(null , null);
					}
				}
			}
		}
		
		void TsSubirMEClick(object sender, System.EventArgs e)
		{
			if (this.cGE.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.cGE.SelectedItem;
				if (this.lME.SelectedItem != null)
				{
					int i = this.lME.SelectedIndex;
					if (i > 0)
					{
						SOAPMethodInfo m = (SOAPMethodInfo) this.lME.SelectedItem;
						this.ReOrdenarListaME(g, m, i, -1);
						this.lME.SelectedItem = m;
					}
				}
			}			
		}
		
		void TsBajarMEClick(object sender, System.EventArgs e)
		{
			if (this.cGE.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.cGE.SelectedItem;
				if (this.lME.SelectedItem != null)
				{
					int i = this.lME.SelectedIndex;
					if ((i > -1) && (i < this.lME.Items.Count -1))
					{
						SOAPMethodInfo m = (SOAPMethodInfo) this.lME.SelectedItem;
						this.ReOrdenarListaME(g, m, i, 1);
						this.lME.SelectedItem = m;
					}
				}
			}	
		}
		
		void TsMoverMEClick(object sender, System.EventArgs e)
		{
			if (this.cGE.SelectedItem != null)
			{
				SOAPGroup g = (SOAPGroup) this.cGE.SelectedItem;
				if (this.lME.SelectedItem != null)
				{
					SOAPMethodInfo m = (SOAPMethodInfo) this.lME.SelectedItem;
					frmGruposSOAP dlg = new frmGruposSOAP(this._sesion.ServiceInfo);
					DialogResult r = dlg.ShowDialog(this);
					if (r == DialogResult.OK && dlg.Grupo != null)
					{
						try
						{
							dlg.Grupo.AddMethod(m);
							if (!dlg.ConservarCopia)
							{
								g.Methods.Remove(m);
								if (g.Methods.Count > 0)
								{
									SOAPMethodInfo nextm = g.Methods[0];
									this.containerME.Panel2.Enabled = true;
									this.BindPrivateMethod(nextm);
									this.RefrescarListaME(g);
									this.lME.SelectedItem = nextm;
								}
								else
								{
									this.containerME.Panel2.Enabled = false;
									this.RefrescarListaME(g);
									this.LMESelectedIndexChanged(null, null);
								}								
							}
							if (dlg.Grupo.Equals(this.cGC.SelectedItem))
							{
								this.containerMC.Panel2.Enabled = true;
								this.BindPublicMethod(m);
								this.RefrescarListaMC(dlg.Grupo);
								this.lMC.SelectedItem = m;
							}
							this.ActualizarArbol();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Error al mover el método", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}			
		}
		
		void TsObsoletoMECheckedChanged(object sender, System.EventArgs e)
		{
			if (this.cGE.SelectedItem != null)
			{
				if (this.lME.SelectedIndex >= 0)
				{
					(this.lME.SelectedItem as SOAPMethodInfo).Obsolete = this.tsObsoletoME.Checked;
					this.ActualizarArbol();
				}
			}			
		}
		
		void TsGuardarMEClick(object sender, System.EventArgs e)
		{
			this.GuardarWSUI();
		}
		
		void CGESelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.cGE.SelectedItem != null)
			{
				this.toolsME.Enabled = true;
				this.lbME.Enabled = true;
				this.lME.Enabled = true;
				this.lME.DataSource = (this.cGE.SelectedItem as SOAPGroup).Methods;
				this.lME.DisplayMember = "Name";
				this.lME.ValueMember = "Name";
				if ((this.cGE.SelectedItem as SOAPGroup).Methods.Count > 0)
				{
					this.lME.SelectedItem = (this.cGE.SelectedItem as SOAPGroup).Methods[0];
					this.LMESelectedIndexChanged(null , null);
				}
				else
				{
					this.LMESelectedIndexChanged(null , null);
				}
			}
			else
			{
				this.toolsME.Enabled = false;
				this.lbME.Enabled = false;
				this.lME.DataSource = null;
				this.lME.Enabled = false;
				this.LMESelectedIndexChanged(null , null);
			}
		}
		
		void LMESelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lME.SelectedIndex >= 0)
			{
				SOAPMethodInfo m = (SOAPMethodInfo) this.lME.Items[this.lME.SelectedIndex];
				if (this.txEtiquetaME.DataBindings.Count == 0)
				{
					this.containerME.Panel2.Enabled = true;
					this.BindPrivateMethod(m);
				}
				else
				{
					if (!this.txEtiquetaME.DataBindings[0].DataSource.Equals(m))
					{
						this.containerME.Panel2.Enabled = true;
						this.BindPrivateMethod(m);
					}
				}
			}
			else
			{
				this.txEtiquetaME.DataBindings.Clear();
				this.txComentarioME.DataBindings.Clear();
				this.lParamsME.DataBindings.Clear();
				this.txEtiquetaParamME.DataBindings.Clear();
				this.txDefaultParamME.DataBindings.Clear();
				this.chNuloParamME.DataBindings.Clear();
				this.txOrigenParamME.DataBindings.Clear();
				this.txMiembroValorParamME.DataBindings.Clear();
				this.txMiembroDisplayParamME.DataBindings.Clear();
				this.txComentarioParamME.DataBindings.Clear();
				this.txEtiquetaME.Clear();
				this.txComentarioME.Clear();
				this.lParamsME.DataSource = null;
				this.lParamsME.Items.Clear();
				this.txEtiquetaParamME.Clear();
				this.txDefaultParamME.Clear();
				this.chNuloParamME.Checked = false;
				this.txOrigenParamME.Clear();
				this.txMiembroValorParamME.Clear();
				this.txMiembroDisplayParamME.Clear();
				this.txComentarioParamME.Clear();				
				this.containerME.Panel2.Enabled = false;
			}
		}
		
		void TxEtiquetaMEValidated(object sender, System.EventArgs e)
		{
			this.ActualizarArbol();
		}
		
		void LParamsMESelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lParamsME.SelectedIndex >= 0)
			{
				SOAPParamInfo p = (SOAPParamInfo) this.lParamsME.Items[this.lParamsME.SelectedIndex];
				if (this.txEtiquetaParamME.DataBindings.Count == 0)
				{
					this.containerParamsME.Panel2.Enabled = true;
					this.BindPrivateParam(p);
				}
				else
				{
					if (!this.txEtiquetaParamME.DataBindings[0].DataSource.Equals(p))
					{
						this.containerParamsME.Panel2.Enabled = true;
						this.BindPrivateParam(p);
					}
				}
			}
			else
			{
				this.containerParamsME.Panel2.Enabled = false;
			}			
		}
		
		private void RefrescarListaME(SOAPGroup g)
		{
			BindingManagerBase bm = this.lME.BindingContext[g.Methods];
			CurrencyManager cm = (CurrencyManager) bm;
			if (cm != null) cm.Refresh();
			this.ActualizarArbol();
		}
		
		private void ReOrdenarListaME(SOAPGroup g, SOAPMethodInfo m, int posInicial, int desplazamiento)
		{
			g.Methods.RemoveAt(posInicial);
			g.Methods.Insert(posInicial + desplazamiento, m);
			this.RefrescarListaME(g);
		}		
		
		private void BindPrivateMethod(SOAPMethodInfo m)
		{
			this.txEtiquetaME.DataBindings.Clear();
			this.txComentarioME.DataBindings.Clear();
			this.lParamsME.DataBindings.Clear();
			this.txEtiquetaParamME.DataBindings.Clear();
			this.txDefaultParamME.DataBindings.Clear();
			this.chNuloParamME.DataBindings.Clear();
			this.txOrigenParamME.DataBindings.Clear();
			this.txMiembroValorParamME.DataBindings.Clear();
			this.txMiembroDisplayParamME.DataBindings.Clear();
			this.txComentarioParamME.DataBindings.Clear();
			this.tsObsoletoME.Checked = m.Obsolete;
			this.txEtiquetaME.DataBindings.Add("Text", m, "Label");
			this.txComentarioME.DataBindings.Add("Text", m, "Comment");
			if (m.Parameters.Count == 0)
			{
				this.lParamsME.DataSource = null;
				this.lParamsME.Items.Clear();
				this.txEtiquetaParamME.Clear();
				this.txDefaultParamME.Clear();
				this.chNuloParamME.Checked = false;
				this.txOrigenParamME.Clear();
				this.txMiembroValorParamME.Clear();
				this.txMiembroDisplayParamME.Clear();
				this.txComentarioParamME.Clear();
				this.containerParamsME.Enabled = false;
			}
			else
			{
				this.lParamsME.DataSource = m.Parameters;
				this.lParamsME.DisplayMember = "Name";
				this.lParamsME.ValueMember = "Name";
				this.BindPrivateParam(m.Parameters[0]);
				this.lParamsME.SelectedItem = m.Parameters[0];
				this.containerParamsME.Enabled = true;
			}
		}
		
		private void BindPrivateParam(SOAPParamInfo p)
		{
			this.txEtiquetaParamME.DataBindings.Clear();
			this.txDefaultParamME.DataBindings.Clear();
			this.chNuloParamME.DataBindings.Clear();
			this.txOrigenParamME.DataBindings.Clear();
			this.txMiembroValorParamME.DataBindings.Clear();
			this.txMiembroDisplayParamME.DataBindings.Clear();
			this.txComentarioParamME.DataBindings.Clear();
			this.txEtiquetaParamME.DataBindings.Add("Text", p, "Label");
			this.txDefaultParamME.DataBindings.Add("Text", p, "DefaultValue");
			this.chNuloParamME.DataBindings.Add("Checked", p, "AllowEmpty");
			this.txOrigenParamME.DataBindings.Add("Text", p, "DataSource");
			this.txMiembroValorParamME.DataBindings.Add("Text", p, "ValueMember");
			this.txMiembroDisplayParamME.DataBindings.Add("Text", p, "DisplayMember");
			this.txComentarioParamME.DataBindings.Add("Text", p, "Comment");
		}		
	}
	
	public delegate void DelegadoCambiaSesionSOAP(estadoModelo estado);
}
