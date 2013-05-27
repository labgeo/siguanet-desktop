/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 26/05/2006
 * Time: 13:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloClienteSQL;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlClienteSQL.
	/// </summary>
	public partial class controlClienteSQL
	{
				
		public controlClienteSQL()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			this.tscbOrigen.ComboBox.DataSource = Enum.GetNames(typeof(dbOrigen));
			this.tscbOrigen.SelectedItem = Enum.GetName(typeof(dbOrigen), dbOrigen.PGSQL);
			this.tscbOrigen.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.tcOutput.ContextMenuStrip = this.mTab;
		}
		
		void TxSQLKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
			{
				this.tsbEjecutar.PerformClick();
			}
		}
		
		void TsbEjecutarClick(object sender, System.EventArgs e)
		{
			ClienteSQL.Source = (dbOrigen) Enum.Parse(typeof(dbOrigen), (string) this.tscbOrigen.SelectedItem);
			List<ClienteSQL.DataTableInfo> infoList = ClienteSQL.Execute(this.txSQL.Text);
			foreach (ClienteSQL.DataTableInfo info in infoList)
			{
				TabPage tp;
				DataTable dt = ClienteSQL.Output.Tables[info.Name];
				DataGridView grd = new DataGridView();
				grd.AllowUserToAddRows = false;
				grd.ReadOnly = true;
				grd.Dock = DockStyle.Fill;
				grd.DataSource = dt;
				grd.AutoGenerateColumns = true;
				if (this.tcOutput.TabPages[0].Controls.Count == 0)
				{
					tp = this.tcOutput.TabPages[0];
				}
				else
				{
					tp = new TabPage();
					this.tcOutput.TabPages.Add(tp);
				}
				tp.Text = info.SQL;
				tp.Controls.Add(grd);
				this.tcOutput.SelectedTab = tp;
				this.tsslMsg.Text = string.Format("Nº de filas en el resultado: {0}", dt.Rows.Count.ToString());
			}
		}
		
		void TcOutputSelectedIndexChanged(object sender, System.EventArgs e)
		{
			int i = this.tcOutput.SelectedIndex;
			
			if (tcOutput.TabPages[i].Controls.Count == 0)
			{
				this.tsslMsg.Text = "Cliente SQL Unidad de Geomática";
			}
			else
			{
				try
				{
					DataGridView grd= (DataGridView) this.tcOutput.TabPages[i].Controls[0];
					DataTable dt = (DataTable) grd.DataSource;
					this.tsslMsg.Text = string.Format("Nº de filas en el resultado: {0}", dt.Rows.Count.ToString());
				}
				catch (Exception ex)
				{
					this.tsslMsg.Text = ex.Message;
				}				
			}
		}
		
		void TsbBorrarSQLClick(object sender, System.EventArgs e)
		{
			this.txSQL.Text = string.Empty;
		}
		
		void MiBorrarOutputActivoClick(object sender, System.EventArgs e)
		{
			int i = this.tcOutput.SelectedIndex;
			DataTable dt = null;
			if (this.tcOutput.TabPages[i].Controls.Count > 0)
			{
				DataGridView grd= (DataGridView) this.tcOutput.TabPages[i].Controls[0];
				dt = (DataTable) grd.DataSource;
			}
			if (this.tcOutput.TabPages.Count == 1)
			{
				this.tcOutput.TabPages[i].Controls.Clear();
				this.tcOutput.TabPages[i].Text = "No hay resultados";
				this.tsslMsg.Text = "Cliente SQL Unidad de Geomática";
			}
			else
			{
				this.tcOutput.TabPages.RemoveAt(i);
			}
			if (dt != null) ClienteSQL.ClearOutput(dt);
		}
		
		void MiBorrarOutputTodosClick(object sender, System.EventArgs e)
		{
			this.tcOutput.SelectedIndexChanged -= new System.EventHandler(this.TcOutputSelectedIndexChanged);
			for (int i = this.tcOutput.TabPages.Count -1; i > 0; i--)
			{
				this.tcOutput.TabPages.RemoveAt(i);
			}
			this.tcOutput.TabPages[0].Controls.Clear();
			this.tcOutput.TabPages[0].Text = "No hay resultados";
			this.tsslMsg.Text = "Cliente SQL Unidad de Geomática";			
			ClienteSQL.ClearOutput();
			this.tcOutput.SelectedIndexChanged += new System.EventHandler(this.TcOutputSelectedIndexChanged);
		}
		
		void MitemCerrarClick(object sender, System.EventArgs e)
		{
			this.miBorrarOutputActivo.PerformClick();
		}
		
		void MitemCerrarTodosClick(object sender, System.EventArgs e)
		{
			this.miBorrarOutputTodos.PerformClick();
		}		
	}
}
