/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 26/02/2008
 * Hora: 10:52
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlPreferenciasORASchemaQuery.
	/// </summary>
	public partial class controlPreferenciasORASchemaQuery : UserControl
	{
		public controlPreferenciasORASchemaQuery()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			string esquemas = AdministradorPreferencias.Read(PrefsBD.ORATargetSchemas);
			string tablas = AdministradorPreferencias.Read(PrefsBD.ORACustomTableSchemaQuery);
			string vistas = AdministradorPreferencias.Read(PrefsBD.ORACustomViewSchemaQuery);
			string columnas = AdministradorPreferencias.Read(PrefsBD.ORACustomColumnSchemaQuery);

			this.txEsquemas.Text = esquemas;
			if (tablas == string.Empty || tablas == null)
			{
				this.rbCatalogoTablasDefault.Checked = true;
				this.txCatalogoTablasCustom.Enabled = false;
			}
			else
			{
				this.rbCatalogoTablasCustom.Checked = true;
				this.txCatalogoTablasCustom.Enabled = true;
				this.txCatalogoTablasCustom.Text = tablas;
				
			}
			if (vistas == string.Empty || vistas == null)
			{
				this.rbCatalogoVistasDefault.Checked = true;
				this.txCatalogoVistasCustom.Enabled = false;
			}
			else
			{
				this.rbCatalogoVistasCustom.Checked = true;
				this.txCatalogoVistasCustom.Enabled = true;
				this.txCatalogoVistasCustom.Text = vistas;
			}
			if (columnas == string.Empty || columnas == null)
			{
				this.rbCatalogoColumnasDefault.Checked = true;
				this.txCatalogoColumnasCustom.Enabled = false;
			}
			else
			{
				this.rbCatalogoColumnasCustom.Checked = true;
				this.txCatalogoColumnasCustom.Enabled = true;
				this.txCatalogoColumnasCustom.Text = columnas;
			}
		}

		void RbCatalogoTablasCustomCheckedChanged(object sender, EventArgs e)
		{
			this.txCatalogoTablasCustom.Enabled = this.rbCatalogoTablasCustom.Checked;
			if (!this.rbCatalogoTablasCustom.Checked)
			{
				this.txCatalogoTablasCustom.Clear();
				AdministradorPreferencias.Update(PrefsBD.ORACustomTableSchemaQuery, null);
			}
		}
				
		void RbCatalogoVistasCustomCheckedChanged(object sender, EventArgs e)
		{
			this.txCatalogoVistasCustom.Enabled = this.rbCatalogoVistasCustom.Checked;
			if (!this.rbCatalogoVistasCustom.Checked)
			{
				this.txCatalogoVistasCustom.Clear();
				AdministradorPreferencias.Update(PrefsBD.ORACustomViewSchemaQuery, null);
			}
		}
				
		void RbCatalogoColumnasCustomCheckedChanged(object sender, EventArgs e)
		{
			this.txCatalogoColumnasCustom.Enabled = this.rbCatalogoColumnasCustom.Checked;
			if (!this.rbCatalogoColumnasCustom.Checked)
			{
				this.txCatalogoColumnasCustom.Clear();
				AdministradorPreferencias.Update(PrefsBD.ORACustomColumnSchemaQuery, null);
			}			
		}
		
		void TxEsquemasTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsBD.ORATargetSchemas, this.txEsquemas.Text.Trim());
		}
		
		void TxCatalogoTablasCustomTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsBD.ORACustomTableSchemaQuery, this.txCatalogoTablasCustom.Text.Trim());
		}
		
		void TxCatalogoVistasCustomTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsBD.ORACustomViewSchemaQuery, this.txCatalogoVistasCustom.Text.Trim());
		}
		
		void TxCatalogoColumnasCustomTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsBD.ORACustomColumnSchemaQuery, this.txCatalogoColumnasCustom.Text.Trim());
		}		
	}
}
