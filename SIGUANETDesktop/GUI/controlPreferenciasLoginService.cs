// Copyright 2009 - José Tomás Navarro Carrión (www.gisandchips.org)


using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlPreferenciasLoginService.
	/// </summary>
	public partial class controlPreferenciasLoginService : UserControl
	{
		public controlPreferenciasLoginService()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			string url = AdministradorPreferencias.Read(PrefsGlobal.LoginServiceURL);
			this.txEndPoint.Text = url;
		}
		
		void TxEndPointTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsGlobal.LoginServiceURL, this.txEndPoint.Text.Trim());
		}
	}
}
