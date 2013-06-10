/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 22/02/2008
 * Hora: 14:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmPreferencias.
	/// </summary>
	public partial class frmPreferencias : Form
	{
		private enum ActiveNodeNames
		{
			AuthSearch,
			SGDSearch,
			PGSQLSchemaQuery,
			ORASchemaQuery
		}
		
		public frmPreferencias()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
			
		void TvPreferenciasNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			this.panel2.Controls.Clear();
			if (Enum.IsDefined(typeof(ActiveNodeNames), e.Node.Name))
			{
				switch ((ActiveNodeNames) Enum.Parse(typeof(ActiveNodeNames), e.Node.Name))
				{
					case ActiveNodeNames.AuthSearch:
			        	controlPreferenciasAuthSearch cAuthS = new controlPreferenciasAuthSearch();
			        	cAuthS.Dock = DockStyle.Fill;
			        	this.panel2.Controls.Add(cAuthS);
			        	break;
					case ActiveNodeNames.SGDSearch:
			        	controlPreferenciasSGDSearch cSGDS = new controlPreferenciasSGDSearch();
			        	cSGDS.Dock = DockStyle.Fill;
			        	this.panel2.Controls.Add(cSGDS);
			        	break;						
			        case ActiveNodeNames.PGSQLSchemaQuery:
			        	controlPreferenciasPGSQLSchemaQuery cSQPGSQL = new controlPreferenciasPGSQLSchemaQuery();
			        	cSQPGSQL.Dock = DockStyle.Fill;
			        	this.panel2.Controls.Add(cSQPGSQL);
			        	break;
			        case ActiveNodeNames.ORASchemaQuery:
			        	controlPreferenciasORASchemaQuery cSQORA = new controlPreferenciasORASchemaQuery();
			        	cSQORA.Dock = DockStyle.Fill;
			        	this.panel2.Controls.Add(cSQORA);
			        	break;
				}
			}
		}
		
		void BAceptarClick(object sender, EventArgs e)
		{
			AdministradorPreferencias.Save();
			if (this.Owner == null) {
				this.Close ();
			}
		}
		
		void BCancelarClick(object sender, EventArgs e)
		{
			if (this.Owner == null) {
				this.Close ();
			}			
		}
	}
}
