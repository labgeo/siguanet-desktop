/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 24/02/2007
 * Time: 20:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SIGUANETDesktop.SOAP;

namespace SIGUANETDesktop.ModeloClienteSOAP
{
	/// <summary>
	/// Description of SOAPServiceUI.
	/// </summary>
	public class SOAPServiceInfo
	{
		private WSDLProxy _wsdl = null;
		[XmlIgnore]
		public WSDLProxy WSDL
		{
			get
			{
				if (this._wsdl == null)
				{
					try
					{
						this._wsdl = new WSDLProxy(SOAPSettings.WSDLLocation);
						return this._wsdl;
					}
					catch (Exception e)
					{
						throw e;
					}
				}
				else
				{
					return this._wsdl;
				}
			}
		}

		private List<SOAPMethodInfo> _initMethods = new List<SOAPMethodInfo>();
		[XmlArray]
		public List<SOAPMethodInfo> InitMethods
		{
			get
			{
				return this._initMethods;
			}
			set
			{
				this._initMethods = value;
			}
		}
		
		private List<SOAPMethodInfo> _visibleMethods = new List<SOAPMethodInfo>();
		[XmlArray]
		public List<SOAPMethodInfo> VisibleMethods
		{
			get
			{
				return this._visibleMethods;
			}
			set
			{
				this._visibleMethods = value;
			}
		}
		
		private SOAPPublicContainer _publicContainer = new SOAPPublicContainer();
		[XmlElement]
		public SOAPPublicContainer PublicContainer 
		{
			get 
			{
				return this._publicContainer;
			}
			set 
			{
				this._publicContainer = value;
			}
		}
		
		private SOAPPrivateContainer _privateContainer = new SOAPPrivateContainer();
		[XmlElement]
		public SOAPPrivateContainer PrivateContainer 
		{
			get 
			{
				return this._privateContainer;
			}
			set 
			{
				this._privateContainer = value;
			}
		}		
		
		public SOAPServiceInfo()
		{
		}
				
		public void Serializar(string nomFichero)
		{
			XmlSerializer x;
			System.Xml.XmlTextWriter w;
			try
			{
				x = new XmlSerializer(this.GetType());
				
				try
				{
					if (File.Exists(nomFichero))
					{
						string nomCopiaRespaldo = string.Format("{0}.{1}", Path.GetFileNameWithoutExtension(nomFichero), "wsui.backup");
						File.Copy(nomFichero, nomCopiaRespaldo, true);
					}
				}
				catch (Exception e)
				{
					throw(e);
				}
			    w = new XmlTextWriter(nomFichero, System.Text.Encoding.Unicode);
	        	w.Formatting = Formatting.Indented;
	        	w.Indentation = 2;
	        	x.Serialize(w, this);
	        	w.Close();
			}
			catch (Exception e)
			{
				throw(e);
			}
		}		
		
		public void AddVisibleMethod(string name)
		{
			if (this.MethodExists(name, this.VisibleMethods) && !this.MethodIsObsolete(name, this.VisibleMethods))
			{
				throw new ApplicationException(string.Format("El método {0} ya está incluido en la lista de métodos visibles. Bórrelo o márquelo como obsoleto.", name));
			}
			if (this._wsdl != null)
			{
				foreach(WSDLProxyMethod m in this._wsdl.Methods)
				{
					if (m.Name == name)
					{
						SOAPMethodInfo smi = new SOAPMethodInfo();
						smi.Name = m.Name;
						smi.Label = m.Name;
						smi.ReturnType = m.ReturnType.Name;
						foreach(WSDLProxyParam p in m.Parameters)
						{
							SOAPParamInfo spi = new SOAPParamInfo();
							spi.Name = p.Name;
							spi.Label = p.Name;
							spi.DataType = p.DataType.Name;
							smi.Parameters.Add(spi);
						}
						this._visibleMethods.Add(smi);
						break;
					}
				}
			}
		}

		public void AddVisibleMethod(WSDLProxyMethod m)
		{
			if (this.MethodExists(m.Name, this.VisibleMethods) && !this.MethodIsObsolete(m.Name, this.VisibleMethods))
			{
				throw new ApplicationException(string.Format("El método {0} ya está incluido en la lista de métodos visibles. Bórrelo o márquelo como obsoleto.", m.Name));
			}			
			SOAPMethodInfo smi = new SOAPMethodInfo();
			smi.Name = m.Name;
			smi.Label = m.Name;
			smi.ReturnType = m.ReturnType.Name;
			foreach(WSDLProxyParam p in m.Parameters)
			{
				SOAPParamInfo spi = new SOAPParamInfo();
				spi.Name = p.Name;
				spi.Label = p.Name;
				spi.DataType = p.DataType.Name;
				smi.Parameters.Add(spi);
			}
			this._visibleMethods.Add(smi);
		}
		
		public void AddInitMethod(string name)
		{
			if (this.MethodExists(name, this.InitMethods) && !this.MethodIsObsolete(name, this.InitMethods))
			{
				throw new ApplicationException(string.Format("El método {0} ya está incluido en la lista de métodos de inicio. Bórrelo o márquelo como obsoleto.", name));
			}
			if (this._wsdl != null)
			{
				foreach(WSDLProxyMethod m in this._wsdl.Methods)
				{
					if (m.Name == name)
					{
						if (m.Parameters.Count == 0)
						{
							SOAPMethodInfo smi = new SOAPMethodInfo();
							smi.Name = m.Name;
							smi.Label = m.Name;
							smi.ReturnType = m.ReturnType.Name;							
							this._initMethods.Add(smi);
							break;
						}
						else
						{
							throw new ApplicationException("Un método con parámetros no puede ser método de inicio");
						}
					}
				}
			}
		}
		
		public void AddInitMethod(WSDLProxyMethod m)
		{
			if (this.MethodExists(m.Name, this.InitMethods) && !this.MethodIsObsolete(m.Name, this.InitMethods))
			{
				throw new ApplicationException(string.Format("El método {0} ya está incluido en la lista de métodos de inicio. Bórrelo o márquelo como obsoleto.", m.Name));
			}			
			if (m.Parameters.Count == 0)
			{
				SOAPMethodInfo smi = new SOAPMethodInfo();
				smi.Name = m.Name;
				smi.Label = m.Name;
				smi.ReturnType = m.ReturnType.Name;							
				this._initMethods.Add(smi);
			}
			else
			{
				throw new ApplicationException("Un método con parámetros no puede ser método de inicio");
			}
		}
		
		private bool MethodExists(string name, List<SOAPMethodInfo> target)
		{
			foreach (SOAPMethodInfo m in target)
			{
				if (m.Name == name) return true;				
			}
			return false;
		}
		
		private bool MethodIsObsolete(string name, List<SOAPMethodInfo> target)
		{
			foreach (SOAPMethodInfo m in target)
			{
				if (m.Name == name && m.Obsolete) return true;				
			}
			return false;
		}		
		
		public List<WSDLProxyMethod> FindCandidateInitMethods()
		{
			try
			{
				if (this._wsdl == null)	this._wsdl = new WSDLProxy(SOAPSettings.WSDLLocation);
				return this._wsdl.GetCandidateInitMethods();
			}
			catch (Exception e)
			{
				throw e;
			}			
		}
		
		public List<WSDLProxyMethod> FindAllMethods()
		{
			try
			{
				if (this._wsdl == null)	this._wsdl = new WSDLProxy(SOAPSettings.WSDLLocation);
				return this._wsdl.GetAllMethods();
			}
			catch (Exception e)
			{
				throw e;
			}			
		}		
		
		public object CallMethod(SOAPMethodInfo m)
		{
			try
			{
				if (m.Obsolete) throw new ApplicationException("No se puede ejecutar un método marcado como obsoleto.");
				if (this._wsdl == null)	this._wsdl = new WSDLProxy(SOAPSettings.WSDLLocation);
				return this._wsdl.CallMethod(m, SOAPSettings.HTTPUsr, SOAPSettings.HTTPPwd);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public object CallLookUpTableMethod(string methodName, bool addEmptyRecord)
		{
			try
			{
				if (this._wsdl == null)	this._wsdl = new WSDLProxy(SOAPSettings.WSDLLocation);
				return this._wsdl.CallLookUpTableMethod(methodName, addEmptyRecord, SOAPSettings.HTTPUsr, SOAPSettings.HTTPPwd);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public void AddPublicGroup()
		{
			this.PublicContainer.Groups.Add(new SOAPGroup());
		}
		
		public void AddPrivateGroup()
		{
			this.PrivateContainer.Groups.Add(new SOAPGroup());
		}
	}
}
