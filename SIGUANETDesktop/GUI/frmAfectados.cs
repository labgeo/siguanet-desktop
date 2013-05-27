/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 19/05/2006
 * Time: 9:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmAfectados.
	/// </summary>
	public partial class frmAfectados
	{
		public frmAfectados(DataTable dt, string titulo)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.Text = titulo;
			this.bsDatos.DataSource = dt;
			this.dgvDatos.AutoGenerateColumns = true;
			this.dgvDatos.DataSource = this.bsDatos;
			this.dgvDatos.ReadOnly = true;
			this.tsslMsg.Text = string.Format("Nº de registros recuperados: {0}", dt.Rows.Count.ToString());
		}
		
		void BAceptarClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		void BCancelarClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
