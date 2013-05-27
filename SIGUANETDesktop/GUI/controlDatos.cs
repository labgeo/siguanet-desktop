/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 15/06/2006
 * Time: 10:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlDatos.
	/// </summary>
	public partial class controlDatos
	{
		public controlDatos(DataTable dt)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.bsDatos.DataSource = dt;
			this.dgvDatos.AutoGenerateColumns = true;
			this.dgvDatos.DataSource = this.bsDatos;
			this.tsslMsg.Text = string.Format("Nº de registros recuperados: {0}", dt.Rows.Count.ToString());
		}
	}
}
