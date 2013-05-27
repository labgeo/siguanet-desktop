/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 07/04/2006
 * Time: 11:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloSincronizacion;
using SIGUANETDesktop.Utilidades;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmConexionPGSQL.
	/// </summary>
	public partial class frmConexionPGSQL
	{
		private bool cancelarCierre = false;
		public frmConexionPGSQL()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.txServidor.Text = DBSettings.PGSQLHost;
			this.txPuerto.Text = DBSettings.PGSQLPort.ToString();
			this.txBD.Text = DBSettings.PGSQLDb;
			this.txUsuario.Text = DBSettings.PGSQLUsr;
			this.txClave.Text = DBSettings.PGSQLPwd;
		}
		
		void BCancelarClick(object sender, System.EventArgs e)
		{
			this.cancelarCierre = false;
		}
		
		void BAceptarClick(object sender, System.EventArgs e)
		{
			try
			{
				DBSettings.PGSQLHost = this.txServidor.Text.Trim();
				if (EsPuerto(this.txPuerto.Text.Trim()))
				{
					DBSettings.PGSQLPort = System.Convert.ToInt32(this.txPuerto.Text);
				}
				else
				{
					throw new ApplicationException("Introduzca un número válido de puerto");
				}
				DBSettings.PGSQLDb = this.txBD.Text.Trim();
				DBSettings.PGSQLUsr = this.txUsuario.Text.Trim();
				DBSettings.PGSQLPwd = this.txClave.Text;
				//this.Close();				
			}
			catch (Exception ex)
			{
				cancelarCierre = true;
				MessageBox.Show(ex.Message, "Conexión PostgreSQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		bool EsPuerto(string s)
		{
			return Regex.IsInteger(s);
		}
				
		void FrmConexionPGSQLFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			if (cancelarCierre)
			{
				cancelarCierre = false;
				e.Cancel =true;
			}
		}
	}
}
