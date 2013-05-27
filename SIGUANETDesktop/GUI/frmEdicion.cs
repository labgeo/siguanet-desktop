/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 23/05/2006
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmEdicion.
	/// </summary>
	public partial class frmEdicion
	{
		public frmEdicion(DataTable dt, string titulo)
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
