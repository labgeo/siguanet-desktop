/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/04/2006
 * Time: 13:05
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

namespace SIGUANETDesktop.GUI
{
	public delegate void DelegadoCambiaCmdComparar(estadoModelo estado);
	/// <summary>
	/// Description of controlCmdComparar.
	/// </summary>
	public partial class controlCmdComparar
	{
		private readonly string descInicial;
		private readonly string tblCPDInicial;
		private readonly string tblSIGUAInicial;
		

		private TreeNode _nodo;
		private CmdComparar _cmd;
		
		public controlCmdComparar(TreeNode n)
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
			_cmd = (CmdComparar) n.Tag;

			switch(_cmd.Direccion)
			{
				case (TipoComprobacion.AltasPendientesEnSIGUA) :
					this.txDireccion.Text = "Recuperar registros de CPD que no tienen coincidentes en SIGUANET";
					break;
				case (TipoComprobacion.BajasPendientesEnSIGUA) :
					this.txDireccion.Text = "Recuperar registros de SIGUANET que no tienen coincidentes en CPD";
					break;
			}
			this.txDesc.Text = descInicial = _cmd.Descripcion;
			this.txTblCPD.Text = tblCPDInicial = _cmd.TablaCPD;
			this.txTblSIGUA.Text = tblSIGUAInicial = _cmd.TablaSIGUA;
			this.grdJoin.DataSource = _cmd.ComplexData.Tables["Joins"];
			_cmd.ComplexData.Tables["Joins"].RowChanged += new DataRowChangeEventHandler(JoinDataChanged);
			_cmd.ComplexData.Tables["Joins"].RowDeleted += new DataRowChangeEventHandler(JoinDataChanged);
			
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
		
		public event DelegadoCambiaCmdComparar EventoCambiaEstado;
		
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
		
		void JoinDataChanged(object sender, DataRowChangeEventArgs e)
		{
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
	}
}
