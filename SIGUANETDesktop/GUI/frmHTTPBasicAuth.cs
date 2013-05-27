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
	/// Description of frmHTTPBasicAuth.
	/// </summary>
	public partial class frmHTTPBasicAuth
	{
		string _usr = string.Empty;
		
		public string Usr {
			get { return _usr; }
		}
		
		string _pwd = string.Empty;
		
		public string Pwd {
			get { return _pwd; }
		}
		
		public frmHTTPBasicAuth()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BAceptarClick(object sender, System.EventArgs e)
		{
			_usr = txUsuario.Text.Trim();
			_pwd = txClave.Text.Trim();
			this.Close();
		}
		
		void BCancelarClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
