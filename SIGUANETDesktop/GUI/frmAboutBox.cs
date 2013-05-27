// Copyright 2009 - José Tomás Navarro Carrión (www.gisandchips.org)


using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.Utilidades;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmAboutBox.
	/// </summary>
	public partial class frmAboutBox : Form
	{
		public frmAboutBox()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			lVersion.Text = string.Format("{0} ({1})", Loader.Title, Loader.FullVersion);
			lCopyright.Text = Loader.Copyright;
			lbGeeks.DataSource = Loader.Geeks;
			foreach (Dependency d in Loader.Dependencies)
			{
				lvDependencies.Items.Add(new ListViewItem(new string[] {d.Assembly, d.Version}));
			}
		}
	}
}
