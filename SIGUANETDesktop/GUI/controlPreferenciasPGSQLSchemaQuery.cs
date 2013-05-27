/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 26/02/2008
 * Hora: 9:35
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
	/// Description of controlPreferenciasPGSQLSchemaQuery.
	/// </summary>
	public partial class controlPreferenciasPGSQLSchemaQuery : UserControl
	{
		public controlPreferenciasPGSQLSchemaQuery()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			string esquemas = AdministradorPreferencias.Read(PrefsBD.PGSQLTargetSchemas);
			string tablas = AdministradorPreferencias.Read(PrefsBD.PGSQLCustomTableSchemaQuery);
			string vistas = AdministradorPreferencias.Read(PrefsBD.PGSQLCustomViewSchemaQuery);
			string columnas = AdministradorPreferencias.Read(PrefsBD.PGSQLCustomColumnSchemaQuery);

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
				AdministradorPreferencias.Update(PrefsBD.PGSQLCustomTableSchemaQuery, null);
			}
		}
				
		void RbCatalogoVistasCustomCheckedChanged(object sender, EventArgs e)
		{
			this.txCatalogoVistasCustom.Enabled = this.rbCatalogoVistasCustom.Checked;
			if (!this.rbCatalogoVistasCustom.Checked)
			{
				this.txCatalogoVistasCustom.Clear();
				AdministradorPreferencias.Update(PrefsBD.PGSQLCustomViewSchemaQuery, null);
			}
		}
				
		void RbCatalogoColumnasCustomCheckedChanged(object sender, EventArgs e)
		{
			this.txCatalogoColumnasCustom.Enabled = this.rbCatalogoColumnasCustom.Checked;
			if (!this.rbCatalogoColumnasCustom.Checked)
			{
				this.txCatalogoColumnasCustom.Clear();
				AdministradorPreferencias.Update(PrefsBD.PGSQLCustomColumnSchemaQuery, null);
			}			
		}
		
		void TxEsquemasTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsBD.PGSQLTargetSchemas, this.txEsquemas.Text.Trim());
		}
		
		void TxCatalogoTablasCustomTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsBD.PGSQLCustomTableSchemaQuery, this.txCatalogoTablasCustom.Text.Trim());
		}
		
		void TxCatalogoVistasCustomTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsBD.PGSQLCustomViewSchemaQuery, this.txCatalogoVistasCustom.Text.Trim());
		}
		
		void TxCatalogoColumnasCustomTextChanged(object sender, EventArgs e)
		{
			AdministradorPreferencias.Update(PrefsBD.PGSQLCustomColumnSchemaQuery, this.txCatalogoColumnasCustom.Text.Trim());
		}
	}
}
