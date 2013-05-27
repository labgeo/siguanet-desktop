/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 01/04/2007
 * Time: 20:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloClienteSOAP;
using SIGUANETDesktop.SOAP;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmMetodosWS.
	/// </summary>
	public partial class frmMetodosSOAP
	{
		private bool cancelarCierre = false;
		
		private List<WSDLProxyMethod> _metodosSeleccionados = new List<WSDLProxyMethod>();
		public List<WSDLProxyMethod> MetodosSeleccionados
		{
			get
			{
				return this._metodosSeleccionados;
			}
		}
		
		public frmMetodosSOAP(SOAPServiceInfo soap, bool cargarAptosInicio)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			try
			{
				List<WSDLProxyMethod> availableMethods = null;
				if (cargarAptosInicio)
				{
					availableMethods = soap.FindCandidateInitMethods();

				}
				else
				{
					availableMethods = soap.FindAllMethods();
				}
				this.lMetodos.DataSource = availableMethods;
				this.lMetodos.DisplayMember = "Name";
				this.lMetodos.ValueMember = "Name";
				if(availableMethods.Count > 0)
				{
					this.lMetodos.SelectedItem = availableMethods[0];
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message, "Error al intentar obtener información del Servicio Web", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void FrmMetodosSOAPFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			if (cancelarCierre)
			{
				cancelarCierre = false;
				e.Cancel = true;
			}
		}
		
		void BAceptarClick(object sender, System.EventArgs e)
		{
			if (this.lMetodos.SelectedItems.Count > 0)
			{
				foreach (object m in this.lMetodos.SelectedItems)
				{
					this._metodosSeleccionados.Add((WSDLProxyMethod) m);
				}
			}
		}
		
		void BCancelarClick(object sender, System.EventArgs e)
		{
			this.cancelarCierre = false;			
		}
	}
}
