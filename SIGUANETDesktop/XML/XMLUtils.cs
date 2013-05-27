/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/03/2006
 * Time: 17:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Net;

namespace SIGUANETDesktop.XML
{
	/// <summary>
	/// Description of Utilidades.
	/// </summary>
	public static class XMLUtils
	{
		public static object DeserializarDocumento(string buffer, string httpUsr, string httpPwd, System.Type tipo)
		{
			object obj = null;
			XmlSerializer x = new XmlSerializer(tipo);
			x.UnknownAttribute += new XmlAttributeEventHandler(OnUnknownAttribute);
			x.UnknownElement += new XmlElementEventHandler(OnUnknownElement);
			x.UnknownNode += new XmlNodeEventHandler(OnUnknownNode);
			x.UnreferencedObject += new UnreferencedObjectEventHandler(OnUnreferencedObject);
			
			XmlTextReader r;
			switch (buffer.Substring(0, 5))
			{
				case "<?xml":
					//TODO: Organizar este código en bloques using(){}
					MemoryStream ms = new MemoryStream();
					StreamWriter sw = new StreamWriter(ms, System.Text.Encoding.Unicode);
					sw.Write(buffer);
					sw.Flush();
					ms.Position = 0;
					r = new XmlTextReader(ms);
					obj = x.Deserialize(r);
					ms.Close();
					sw.Close();
					r.Close();
					return obj;
				case "http:":
					//TODO: Organizar este código en un bloque try{} catch{} finally{}
					//de forma que el ResponseStream no quede abierto bajo ninguna
					//circunstancia después de abandonar el método
					HttpWebRequest req = (HttpWebRequest) WebRequest.Create(buffer);
					if (httpUsr != null)
					{
						if (httpUsr.Trim() != string.Empty)
						{
							req.Credentials = new NetworkCredential(httpUsr.Trim(), httpPwd);
						}
					}
					HttpWebResponse res = (HttpWebResponse) req.GetResponse();
					r = new XmlTextReader(res.GetResponseStream());
					obj = x.Deserialize(r);
					res.Close();
					return obj;
				default:
					//TODO: Organizar este código en bloques using(){}
					FileStream fs = new FileStream(buffer, FileMode.Open);					
					r = new XmlTextReader(fs);
					obj = x.Deserialize(r);
					fs.Close();
					r.Close();
					return obj;
			}
		}
		
		static void OnUnknownAttribute(object sender, XmlAttributeEventArgs e)
		{
			string msg = string.Format("Linea {0} Carácter {1} - Al deserializar {2} se esperaba {3} pero se encontró {4}", e.LineNumber, e.LinePosition, e.ObjectBeingDeserialized.ToString(), e.ExpectedAttributes, e.Attr.InnerText);
			MessageBox.Show(msg);
		}
		
		static void OnUnknownElement(object sender, XmlElementEventArgs e)
		{
			string msg = string.Format("Linea {0} Carácter {1} - Al deserializar {2} se esperaba {3}  pero se encontró {4}", e.LineNumber, e.LinePosition, e.ObjectBeingDeserialized.ToString(), e.ExpectedElements, e.Element.InnerText);
			MessageBox.Show(msg);
		}
		
		static void OnUnknownNode(object sender, XmlNodeEventArgs e)
		{
			string msg = string.Format("Linea {0} Carácter {1} - Nodo inesperado {2}", e.LineNumber, e.LinePosition, e.Text);
			MessageBox.Show(msg);
		}
		
		static void OnUnreferencedObject(object sender, UnreferencedObjectEventArgs e)
		{
			string msg = string.Format("Objeto {0} no referenciado (id {1})", e.UnreferencedObject.ToString(), e.UnreferencedId);
			MessageBox.Show(msg);			
		}		
		
		
	}
}
