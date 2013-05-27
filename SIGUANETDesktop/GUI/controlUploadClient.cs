// Copyright 2009 - José Tomás Navarro Carrión (www.gisandchips.org)


using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlHTTPPUTClient.
	/// </summary>
	public partial class controlUploadClient : UserControl
	{
		public controlUploadClient()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		void BOKClick(object sender, EventArgs e)
		{
			WebClient wcli = null;
			try
			{
				string source = txOrigen.Text.Trim();
				
				if (source == string.Empty)
				{
					throw new Exception("No se ha especificado fichero de origen");
				}
				if (!File.Exists(source))
				{
					throw new Exception("No se encuentra el fichero de origen especificado");
				}
				
				string dest = txDestino.Text.Trim();
				
				if (dest != string.Empty)
				{
					string data = string.Empty;
					try
					{
						using (StreamReader r = new StreamReader(source))
						{
							data = r.ReadToEnd();
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}

					NameValueCollection nvc = new NameValueCollection();
					nvc.Add("FILENAME", Path.GetFileName(source));
					nvc.Add("DATA", data);
					wcli = new WebClient();
					wcli.UploadValues(dest, nvc);
					
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
				
		void BBrowseClick(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Seleccionar fichero";
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				txOrigen.Text = openFileDialog1.FileName;
			}
		}
	}
}
