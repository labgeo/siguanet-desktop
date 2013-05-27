/*
 * Created by SharpDevelop.
 * User: Jose Tom�s
 * Date: 10/04/2007
 * Time: 17:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using SIGUANETDesktop.ModeloClienteSOAP;
using SIGUANETDesktop.SOAP;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmTestSOAP.
	/// </summary>
	public partial class frmTestSOAP
	{
		private SOAPServiceInfo _soap = null;
		
		public frmTestSOAP(SOAPServiceInfo soap)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this._soap = soap;
		}
				
		void FrmTestSOAPShown(object sender, System.EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			if (this._soap.InitMethods.Count == 0)
			{
				sb.AppendLine("El documento de configuraci�n de interfaz de usuario (WSUI) no define m�todos iniciales de prueba.");
				sb.AppendLine();
				sb.AppendLine("No se puede realizar el test de funcionamiento del servicio.");
				this.txTestSOAP.AppendText(sb.ToString());
			}
			else
			{
				try
				{
					int i = 1;
					sb.AppendFormat("Se ejecutar�n {0} m�todos de prueba", this._soap.InitMethods.Count.ToString());
					sb.AppendLine();
					sb.AppendLine("==============================================");
					this.txTestSOAP.AppendText(sb.ToString());
					sb.Length = 0;
					foreach (SOAPMethodInfo m in this._soap.InitMethods)
					{
						sb.AppendFormat("{0}.- {1}", i.ToString(), m.Label);
						sb.AppendLine();
						this.txTestSOAP.AppendText(sb.ToString());
						sb.Length = 0;
						try
						{
							object result = this._soap.CallMethod(m);
							sb.AppendFormat("Respuesta del Servidor: {0}", result.ToString());
							sb.AppendLine();
							this.txTestSOAP.AppendText(sb.ToString());
							sb.Length = 0;
						}
						catch (Exception ex)
						{
							sb.AppendFormat("Error: {0}", ex.Message);
							sb.AppendLine();
							this.txTestSOAP.AppendText(sb.ToString());
							sb.Length = 0;
						}
						sb.AppendLine();
						this.txTestSOAP.AppendText(sb.ToString());
						sb.Length = 0;				
						i++;
					}
					sb.AppendLine("==============================================");
					sb.AppendLine("Termin� la ejecuci�n de los m�todos de prueba.");
					sb.AppendLine("Si observa cualquier mensaje de error, revise sus credenciales y la direcci�n de los puntos de acceso. Si esta informaci�n es correcta es posible que el servicio no responda provisionalmente o haya ca�do.");
					this.txTestSOAP.AppendText(sb.ToString());
				}
				catch (Exception ex)
				{
					sb.AppendLine("==============================================");
					sb.AppendFormat("Error: {0}", ex.Message);
					sb.AppendLine("El servicio no responde o no est� funcionando correctamente.");
					this.txTestSOAP.AppendText(sb.ToString());
				}				
			}
		}
	}
}
