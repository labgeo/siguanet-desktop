/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 09/05/2008
 * Hora: 13:46
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmPerfilMultiple.
	/// </summary>
	public partial class frmPerfilMultiple : Form
	{
				
		private string _perfilSeleccionado = string.Empty;
		public string PerfilSeleccionado
		{
			get
			{
				return _perfilSeleccionado;
			}
			set
			{
				_perfilSeleccionado = value;
			}
		}
		
		public frmPerfilMultiple(string[] perfiles)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.cbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbPerfil.DataSource = perfiles;
			this.cbPerfil.DataBindings.Clear();
			this.cbPerfil.DataBindings.Add("SelectedItem", this, "PerfilSeleccionado");
			this.cbPerfil.SelectedIndex = 0;
		}
	}
}
