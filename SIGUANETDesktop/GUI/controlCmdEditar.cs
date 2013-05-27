/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 23/05/2006
 * Time: 9:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.ModeloSincronizacion;

namespace SIGUANETDesktop.GUI
{
	public delegate void DelegadoCambiaCmdEditar(estadoModelo estado);	
	/// <summary>
	/// Description of controlCmdEditar.
	/// </summary>
	public partial class controlCmdEditar
	{
		
		private readonly string descInicial;
		private readonly string sqlInicial;

		private TreeNode _nodo;
		private CmdEditar _cmd;
		
		public controlCmdEditar(TreeNode n)
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
			tt.SetToolTip(this.txSQL , "Presiona 'Esc' para recuperar la sentencia SQL inicial");
			
			_nodo = n;
			_cmd = (CmdEditar) n.Tag;
			
			if (_cmd.Origen == dbOrigen.ORA)
			{
				this.opORA.Checked = true;
			}
			else
			{
				this.opPGSQL.Checked = true;
			}
			this.txDesc.Text = descInicial = _cmd.Descripcion;
			this.txSQL.Text = sqlInicial = _cmd.SQL;			
		}

		void TxDescTextChanged(object sender, EventArgs e)
		{
			_nodo.Text = _cmd.Descripcion = this.txDesc.Text;
		}
		
		void TxSQLTextChanged(object sender, EventArgs e)
		{
			_cmd.SQL = this.txSQL.Text;
		}
		
		void TxDescKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_nodo.Text = _cmd.Descripcion = this.txDesc.Text = descInicial;
			}
		}
		
		void TxSQLKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Escape)
			{
				_cmd.SQL = this.txSQL.Text = sqlInicial;
			}	
		}
		
		public event DelegadoCambiaCmdEditar EventoCambiaEstado;
		
		void TxDescKeyUp(object sender, KeyEventArgs e)
		{
			if (this.txDesc.Text != descInicial)
			{
				EventoCambiaEstado(estadoModelo.Pendiente);
			}
		}
		
		void TxSQLKeyUp(object sender, KeyEventArgs e)
		{
			if (this.txSQL.Text != sqlInicial)
			{
				EventoCambiaEstado(estadoModelo.Pendiente);
			}			
		}
		
		void OpORAClick(object sender, System.EventArgs e)
		{
			if (this.opORA.Checked) _cmd.Origen = dbOrigen.ORA;
			EventoCambiaEstado(estadoModelo.Pendiente);
		}
		
		void OpPGSQLClick(object sender, System.EventArgs e)
		{
			if (this.opPGSQL.Checked) _cmd.Origen = dbOrigen.PGSQL;
			EventoCambiaEstado(estadoModelo.Pendiente);
		}		
	}
}
