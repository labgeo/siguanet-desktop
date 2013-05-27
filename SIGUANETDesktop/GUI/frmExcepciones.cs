/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 15/05/2006
 * Time: 14:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloSincronizacion;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmExcepciones.
	/// </summary>
	public partial class frmExcepciones
	{

		private CfgExcepciones helper;
		

		public frmExcepciones(CmdSincronizar cmd)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.Text = string.Format("Descartes a la hora de {0}", cmd.Descripcion);
			helper = new CfgExcepciones(cmd);
			this.bsDatos.DataSource = helper.Data;
			this.dgvDatos.AutoGenerateColumns = true;
			this.dgvDatos.DataSource = this.bsDatos;
			this.tsslMsg.Text = string.Format("Nº de registros recuperados: {0}", helper.Data.Rows.Count.ToString());
			this.dgvDatos.ColumnAdded += new DataGridViewColumnEventHandler(this.OnColumnAdded);
		}
		
		void OnColumnAdded(object sender, DataGridViewColumnEventArgs e)
		{
			if (e.Column.Name != "Descartar")
			{
				e.Column.ReadOnly = true;
				e.Column.DefaultCellStyle.BackColor = Color.Yellow;
			}
			else
			{
				e.Column.DisplayIndex = 0;
			}
		}
		
		void BAceptarClick(object sender, System.EventArgs e)
		{
			if (helper.IsValid) helper.GuardarExcepciones();
			this.Close();
		}
		
		void BCancelarClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
