/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 12/04/2007
 * Time: 11:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using Thinktecture.Tools.Web.Services.DynamicProxy;
using Thinktecture.Tools.Web.Services.Extensions;

namespace SIGUANETDesktop.SOAP
{
	/// <summary>
	/// Description of WSDLProxy.
	/// </summary>
	public class WSDLProxy
	{
		private DynamicWebServiceProxy _proxy = null;
		private Type _type = null;
		
		private string _name = string.Empty;
		internal string Name
		{
			get
			{
				return _name;
			}
		}
		
		private string _endPoint = string.Empty;
		internal string EndPoint
		{
			get
			{
				return _endPoint;
			}
		}
		
		private List<WSDLProxyMethod> _methods = new List<WSDLProxyMethod>();
		internal List<WSDLProxyMethod> Methods
		{
			get
			{
				return _methods;
			}
		}
		
		internal WSDLProxy(string buffer)
		{
			try
			{
				//*********************************************************************************************
				//Para que el ensamblado del proxy se genere corréctamente debemos asegurarnos de que el
				//directorio de trabajo de la aplicación coincida con el directorio del ensamblado principal,
				//es decir, SIGUANETDesktop.exe. Un caso típico en el que puede darse esta discrepancia es si
				//previamente el usuario abre un fichero .sgd que se encuentra en un directorio distinto al del
				//ensamblado principal. Reasignando a Environment.CurrentDirectory dicha ruta evitamos
				//generaciones fallidas del proxy.
				Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				//*********************************************************************************************
				this._proxy = this.CreateProxy(buffer);
				this._proxy.EnableMessageAccess = true;
				
				//Al asignar la propiedad WSDL se enlaza con un ensamblado en cache
				//o se crea un nuevo ensamblado que representa a la clase proxy
				this._proxy.Wsdl = buffer;
				
				this._endPoint = this._proxy.Url.AbsoluteUri;
				Type[] types = this._proxy.ProxyAssembly.GetTypes();
				foreach (Type t in types)
				{
					if (t.BaseType == typeof(SoapHttpClientProtocolExtended))
					{
						this._type = t;
						this._name = t.Name;
						break;
					}
				}
				if (this._type == null) throw new ApplicationException("No se puede enlazar con el proxy");
				MethodInfo[] methods = this._type.GetMethods(BindingFlags.Public |
				                                             BindingFlags.Instance |
				                                             BindingFlags.DeclaredOnly);
				foreach (MethodInfo mi in methods)
				{
					this._methods.Add(new WSDLProxyMethod(mi));
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		private DynamicWebServiceProxy CreateProxy(string source)
		{
			try
			{
				//Intentamos vaciar la cache de ensamblado de clase proxy,
				//es decir borrar el fichero dll que se creó en una sesión
				//anterior, de forma que el ensamblado se genere de nuevo
				//y pueda reflejarse cualquier modificación en el WebService.
				//Normalmente esto sólo lo conseguiremos la primera vez
				//que iniciemos la sesión SOAP con un nuevo WSDL.
				//No se pueden reflejar los cambios hechos en el WebService
				//mientras la sesión SOAP estaba abierta ya que no se puede
				//borrar la dll de un ensamblado que esté cargado en memoria.
				//Por tanto, para reflejar cambios en el WebService en un
				//momento dado siempre habrá que reiniciar la sesión SIGUANETDesktop.
				DynamicWebServiceProxy.ClearCache(source);
				return new DynamicWebServiceProxy();
			}
			catch
			{
				return new DynamicWebServiceProxy();
			}
		}
		
		internal List<WSDLProxyMethod> GetCandidateInitMethods()
		{
			List<WSDLProxyMethod> candidates = new List<WSDLProxyMethod>();
			foreach (WSDLProxyMethod m in this.GetAllMethods())
			{
				if (m.Parameters.Count == 0)
				{
					Type t = m.ReturnType;
					if (t.Equals(typeof(string)))
					{
						candidates.Add(m);
					}
				}
			}
			return candidates;
		}
		
		internal List<WSDLProxyMethod> GetAllMethods()
		{
			List<WSDLProxyMethod> candidates = new List<WSDLProxyMethod>();
			foreach (WSDLProxyMethod m in this._methods)
			{
				if (!m.Name.StartsWith("Begin") && !m.Name.StartsWith("End"))
				{
					candidates.Add(m);
				}
			}
			return candidates;
		}
		
		internal object CallMethod(SOAPMethodInfo m, string user, string password)
		{
			try
			{
				if (this._type == null) throw new ApplicationException("No se puede enlazar con el proxy");

				this._proxy.Url = new Uri(this._endPoint);
				this._proxy.TypeName = this._name;
				this._proxy.MethodName = m.Name;
				if (user != null && user != string.Empty)
				{
					this._proxy.Credentials = new NetworkCredential(user, password);
				}
				MethodInfo[] methods = this._type.GetMethods(BindingFlags.Public |
				                                             BindingFlags.Instance |
				                                             BindingFlags.DeclaredOnly);
				MethodInfo theMethod = null;
				foreach (MethodInfo mi in methods)
				{
					if (mi.Name == m.Name)
					{
						theMethod = mi;
						break;
					}
				}
				if (theMethod == null) throw new ApplicationException("No se puede enlazar con el método del proxy");
				ParameterInfo[] parameters = theMethod.GetParameters();
				if (m.Parameters.Count != parameters.Length) throw new ApplicationException("El método definido en el documento WSUI y el método del proxy no coinciden en cuanto al número de parametros.");
				int i = 0;
				foreach (SOAPParamInfo p in m.Parameters)
				{
					if (p.DataType != parameters[i++].ParameterType.Name) throw new ApplicationException(string.Format("El método definido en el documento WSUI y el método del proxy no coinciden en cuanto al tipo del parametro {0}.", i.ToString()));
				}
				i = 0;
				foreach (SOAPParamInfo p in m.Parameters)
				{
					this._proxy.AddParameter(Convert.ChangeType(p.ParamValue, parameters[i++].ParameterType));
				}
				return this._proxy.InvokeCall();
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		internal object CallLookUpTableMethod(string methodName, bool addEmptyRecord, string user, string password)
		{
			try
			{
				if (this._type == null) throw new ApplicationException("No se puede enlazar con el proxy");

				this._proxy.Url = new Uri(this._endPoint);
				this._proxy.TypeName = this._name;
				this._proxy.MethodName = methodName;
				if (user != null && user != string.Empty)
				{
					this._proxy.Credentials = new NetworkCredential(user, password);
				}
				MethodInfo[] methods = this._type.GetMethods(BindingFlags.Public |
				                                             BindingFlags.Instance |
				                                             BindingFlags.DeclaredOnly);
				MethodInfo theMethod = null;
				foreach (MethodInfo mi in methods)
				{
					if (mi.Name == methodName)
					{
						theMethod = mi;
						break;
					}
				}
				if (theMethod == null) throw new ApplicationException("No se puede enlazar con el método del proxy");
				this._proxy.AddParameter(addEmptyRecord);
				return this._proxy.InvokeCall();
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
