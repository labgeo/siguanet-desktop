/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 11/05/2006
 * Time: 17:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.ModeloSincronizacion;
using SIGUANETDesktop.GUI;

namespace SIGUANETDesktop.GUI
{
	public delegate void DelegadoCambiaCmdSincronizar(estadoModelo estado);
	/// <summary>
	/// Description of controlCmdSincronizar.
	/// </summary>
	public partial class controlCmdSincronizar
	{
		private readonly string descInicial;
		private readonly string tblCPDInicial;
		private readonly string tblSIGUAInicial;
		

		private TreeNode _nodo;
		private CmdSincronizar _cmd;
		
		public controlCmdSincronizar(TreeNode n)
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
			tt.SetToolTip(this.txTblCPD , "Presiona 'F12' para recuperar la lista de tablas  del CPD. Presiona 'Esc' para recuperar la tabla  CPD inicial");
			tt.SetToolTip(this.txTblSIGUA , "Presiona 'F12' para recuperar la lista de tablas  de SIGUANET. Presiona 'Esc' para recuperar la tabla SIGUANET inicial");
			
			_nodo = n;
			_cmd = (CmdSincronizar) n.Tag;
			
			this.txDesc.Text = descInicial = _cmd.Descripcion;
			this.txTblCPD.Text = tblCPDInicial = _cmd.TablaCPD;
			this.txTblSIGUA.Text = tblSIGUAInicial = _cmd.TablaSIGUA;
			this.grdJoins.DataSource = _cmd.ComplexData.Tables["Joins"];
			_cmd.ComplexData.Tables["Joins"].RowChanged += new DataRowChangeEventHandler(JoinsDataChanged);
			_cmd.ComplexData.Tables["Joins"].RowDeleted += new DataRowChangeEventHandler(JoinsDataChanged);
			this.grdSimulaciones.DataSource = _cmd.ComplexData.Tables["Simulaciones"];
			_cmd.ComplexData.Tables["Simulaciones"].RowChanged += new DataRowChangeEventHandler(SimulacionesDataChanged);
			_cmd.ComplexData.Tables["Simulaciones"].RowDeleted += new DataRowChangeEventHandler(SimulacionesDataChanged);
			this.rbActivarExc.Checked = _cmd.AplicarExcepciones;
			this.rbDesactivarExc.Checked = !_cmd.AplicarExcepciones;

			switch(_cmd.Direccion)
			{
				case (TipoComprobacion.AltasPendientesEnSIGUA) :
					this.txDireccion.Text = "Insertar registros del CPD que no existen en SIGUANET";
					this.grdCorrespondencias.DataSource = _cmd.ComplexData.Tables["Correspondencias"];
					_cmd.ComplexData.Tables["Correspondencias"].RowChanged += new DataRowChangeEventHandler(CorrespondenciasDataChanged);
					_cmd.ComplexData.Tables["Correspondencias"].RowDeleted += new DataRowChangeEventHandler(CorrespondenciasDataChanged);
					this.grdDefaults.DataSource = _cmd.ComplexData.Tables["Defaults"];
					_cmd.ComplexData.Tables["Defaults"].RowChanged += new DataRowChangeEventHandler(DefaultsDataChanged);
					_cmd.ComplexData.Tables["Defaults"].RowDeleted += new DataRowChangeEventHandler(DefaultsDataChanged);
					break;
				case (TipoComprobacion.BajasPendientesEnSIGUA) :
					this.txDireccion.Text = "Borrar registros de SIGUANET que no existen en CPD";
					this.tabControl1.TabPages.Remove(this.tpCorrespondencias);
					this.tabControl1.TabPages.Remove(this.tpDefaults);
					break;
				case (TipoComprobacion.ModificacionesPendientesEnSIGUA) :
					this.txDireccion.Text = "Actualizar registros de SIGUANET según sus correspondientes en CPD";
					this.grdCorrespondencias.DataSource = _cmd.ComplexData.Tables["Correspondencias"];
					_cmd.ComplexData.Tables["Correspondencias"].RowChanged += new DataRowChangeEventHandler(CorrespondenciasDataChanged);
					_cmd.ComplexData.Tables["Correspondencias"].RowDeleted += new DataRowChangeEventHandler(CorrespondenciasDataChanged);
					this.tabControl1.TabPages.Remove(this.tpDefaults);
					_cmd.AplicarExcepciones = false;
					this.rbActivarExc.Enabled = false;
					this.rbDesactivarExc.Enabled = false;
					this.lnkConfigurarExc.Enabled = false;
					break;
			}
		}
		
		void TxDescTextChanged(object sender, EventArgs e)
		{
			_nodo.Text = _cmd.Descripcion = this.txDesc.Text;
		}
		
		void TxTblCPDTextChanged(object sender, EventArgs e)
		{
			_cmd.TablaCPD = this.txTblCPD.Text;
		}
		
		void TxTblSIGUATextChanged(object sender, EventArgs e)
		{
			_cmd.TablaSIGUA = this.txTblSIGUA.Text;
		}		
		
		void TxDescKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_nodo.Text = _cmd.Descripcion = this.txDesc.Text = descInicial;
			}
		}
		
		void TxTblCPDKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_cmd.TablaCPD = this.txTblCPD.Text = tblCPDInicial;
			}
		}

		void TxTblSIGUAKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_cmd.TablaSIGUA = this.txTblSIGUA.Text = tblSIGUAInicial;
			}			
		}
		
		public event DelegadoCambiaCmdSincronizar EventoCambiaEstado;
		
		void TxDescKeyUp(object sender, KeyEventArgs e)
		{
			if (this.txDesc.Text != descInicial)
			{
				EventoCambiaEstado(estadoModelo.Pendiente);
			}
		}
		
		void TxTblCPDKeyUp(object sender, KeyEventArgs e)
		{
			if (this.txTblCPD.Text != tblCPDInicial)
			{
				EventoCambiaEstado(estadoModelo.Pendiente);
			}			
		}

		void TxTblSIGUAKeyUp(object sender, KeyEventArgs e)
		{
			if (this.txTblSIGUA.Text != tblSIGUAInicial)
			{
				EventoCambiaEstado(estadoModelo.Pendiente);
			}			
		}
		
		void JoinsDataChanged(object sender, DataRowChangeEventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void CorrespondenciasDataChanged(object sender, DataRowChangeEventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void DefaultsDataChanged(object sender, DataRowChangeEventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void SimulacionesDataChanged(object sender, DataRowChangeEventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}		
		
		void RbActivarExcCheckedChanged(object sender, System.EventArgs e)
		{
			_cmd.AplicarExcepciones = this.rbActivarExc.Checked;
		}
		
		void RbDesactivarExcCheckedChanged(object sender, System.EventArgs e)
		{
			_cmd.AplicarExcepciones = !this.rbDesactivarExc.Checked;
		}
		
		void RbActivarExcClick(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void RbDesactivarExcClick(object sender, System.EventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void LnkConfigurarExcLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmExcepciones dlg = new frmExcepciones(_cmd);
			dlg.ShowDialog(this);
			if (dlg.DialogResult == DialogResult.OK)
			{
				EventoCambiaEstado(estadoModelo.Pendiente);
			}
		}
	}
}
