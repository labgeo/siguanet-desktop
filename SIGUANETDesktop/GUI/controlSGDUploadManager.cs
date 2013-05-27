// Copyright 2009 - José Tomás Navarro Carrión (www.gisandchips.org)


using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.XML;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlSGDUploadManager.
	/// </summary>
	public partial class controlSGDUploadManager : UserControl
	{
		Root _doc = null;
		
		public controlSGDUploadManager(Root doc)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			_doc = doc;
		}
		
		void BOKClick(object sender, EventArgs e)
		{
			
			WebClient wcli = new WebClient();
			try
			{
				string dest = txDestino.Text.Trim();
				
				if (dest != string.Empty)
				{
					_doc.UpdateVersion();
					NameValueCollection nvc = new NameValueCollection();
					nvc.Add("FILENAME", _doc.BuildFormalFileName());
					nvc.Add("DATA", _doc.Serializar());
					wcli.UploadValues(txDestino.Text.Trim(), nvc);
					
					if (wcli.ResponseHeaders["Status"] != null)
					{
						if (wcli.ResponseHeaders["Status"] == "401") 
						{
							frmHTTPBasicAuth w = new frmHTTPBasicAuth();
							w.ShowDialog();
							if (w.DialogResult == DialogResult.OK)
							{
								NetworkCredential c = new NetworkCredential(w.Usr, w.Pwd);
								wcli.Credentials = c;
								wcli.UploadValues(dest, nvc);
							}
							else
							{
								return;
							}
						}
					}
					
					if (wcli.ResponseHeaders["Status"] != null)
					{
						switch (wcli.ResponseHeaders["Status"])
						{
							case "200":
								MessageBox.Show("El servidor de destino respondió: 200 (OK)", "Upload", MessageBoxButtons.OK, MessageBoxIcon.Information);
								break;
							case "404":
								throw new Exception("El servidor de destino respondió: 404 (Not found)");
							default:
								throw new Exception(string.Format("El servidor de destino respondió: {0}", wcli.ResponseHeaders["Status"]));
						}
					}
					else
					{
						throw new Exception("El destino no es válido");
					}
				}
				else
				{
					throw new Exception("No se ha especificado URI de destino");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}			
		}
	}
}
