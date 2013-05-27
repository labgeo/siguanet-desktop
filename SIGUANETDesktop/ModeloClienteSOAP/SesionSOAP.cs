/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 23/05/2006
 * Time: 12:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SIGUANETDesktop.XML;
using SIGUANETDesktop.SOAP;
using SIGUANETDesktop.ModeloDocumento;

namespace SIGUANETDesktop.ModeloClienteSOAP
{
	/// <summary>
	/// Description of SesionSOAP.
	/// </summary>
	public class SesionSOAP : RootModule
	{
		private string _nombre = "SOAP";
		[XmlAttribute]
		public string Nombre
		{
			get 
			{
				return _nombre;
			}
			set
			{
				_nombre = value;
			}
		}
		
		private string _descripcion = "Servicio Web XML (SOAP)";
		[XmlAttribute]
		public string Descripcion
		{
			get
			{
				return _descripcion;
			}
			set
			{
				_descripcion = value;
			}
		}
		
		private string _doc = string.Empty;
		[XmlAttribute]
		public string Doc
		{
			get
			{
				return _doc;
			}
			set
			{
				_doc = value;
			}
		}
		
		private SOAPServiceInfo _serviceInfo = new SOAPServiceInfo();
		[XmlIgnore]
		public SOAPServiceInfo ServiceInfo
		{
			get
			{
				return _serviceInfo;
			}
		}
		
		private EstadoSesionSOAP _estado = EstadoSesionSOAP.NoIniciada;
		[XmlIgnore]
		public EstadoSesionSOAP Estado
		{
			get
			{
				return this._estado;
			}
		}
		
		public SesionSOAP()
		{
		}
		
		public void IniciarSesion(bool useWSUI)
		{
			if (useWSUI)
			{
				try
				{
					if (SOAPSettings.UseContractCredentials && SOAPSettings.ContractHttpUsr.Trim() != string.Empty)
					{
						this._serviceInfo = (SOAPServiceInfo) XMLUtils.DeserializarDocumento(SOAPSettings.WSUILocation, SOAPSettings.ContractHttpUsr.Trim(), SOAPSettings.ContractHttpPwd.Trim(), typeof(SOAPServiceInfo));
					}
					else
					{
						this._serviceInfo = (SOAPServiceInfo) XMLUtils.DeserializarDocumento(SOAPSettings.WSUILocation, string.Empty, string.Empty, typeof(SOAPServiceInfo));
					}
					
					this._estado = EstadoSesionSOAP.IniciadaConWSUI;
				}
				catch (Exception e)
				{
					this._estado = EstadoSesionSOAP.NoIniciada;
					throw e;
				}
			}
			else
			{
				this._serviceInfo = new SOAPServiceInfo();
				this._estado = EstadoSesionSOAP.IniciadaSinWSUI;
			}
		}
	}
}
