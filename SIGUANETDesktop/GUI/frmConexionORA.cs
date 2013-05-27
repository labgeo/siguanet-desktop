/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 10/04/2006
 * Time: 13:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloSincronizacion;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmConexionORA.
	/// </summary>
	public partial class frmConexionORA
	{
		public frmConexionORA()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.txTNS.Text = DBSettings.ORATNS;
			this.txUsuario.Text = DBSettings.ORAUsr;
			this.txClave.Text = DBSettings.ORAPwd;			
		}
		
		void BAceptarClick(object sender, System.EventArgs e)
		{
			DBSettings.ORATNS = this.txTNS.Text.Trim();
			DBSettings.ORAUsr = this.txUsuario.Text.Trim();
			DBSettings.ORAPwd = this.txClave.Text;
			this.Close();
		}
		
		void BCancelarClick(object sender, System.EventArgs e)
		{
			this.Close();			
		}
	}
}
