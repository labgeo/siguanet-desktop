/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 27/02/2008
 * Hora: 13:45
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of frmEsquemaBD.
	/// </summary>
	public partial class frmEsquemaBD : Form
	{
		private enum TipoRaiz
		{
			RaizEsquemas,
			RaizTablas,
			RaizVistas,
			RaizColumnas
		}
		
		public frmEsquemaBD()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.Inicializar();
		}
		
		private void Inicializar()
		{
			this.tvEsquemas.Nodes.Clear();
			TreeNode _pgsqlEsquemas = new TreeNode("Esquemas");
			_pgsqlEsquemas.Tag = TipoRaiz.RaizEsquemas;
			TreeNode _pgsql = new TreeNode("PostgreSQL");
			_pgsql.Tag = dbOrigen.PGSQL;
			
			TreeNode _oraEsquemas = new TreeNode("Esquemas");
			_oraEsquemas.Tag = TipoRaiz.RaizEsquemas;
			TreeNode _ora = new TreeNode("ORACLE");
			_ora.Tag = dbOrigen.ORA;

			TreeNode _raiz = new TreeNode("Conexiones disponibles");
			
			if (DBUtils.TestConnection(dbOrigen.PGSQL))
			{
				_pgsql.Nodes.Add(_pgsqlEsquemas);
				_raiz.Nodes.Add(_pgsql);
			}
			if (DBUtils.TestConnection(dbOrigen.ORA))
			{
				_ora.Nodes.Add(_oraEsquemas);
				_raiz.Nodes.Add(_ora);
			}
			this.tvEsquemas.Nodes.Add(_raiz);
			_raiz.ExpandAll();
		}
		
		private void CrearRamaEsquemas(TreeNode raiz)
		{
			if (raiz.GetNodeCount(false) == 0)
			{
				dbOrigen who = (dbOrigen) raiz.Parent.Tag;
				foreach (DBSchemaInfo s in DBUtils.GetTargetSchemas(who))
				{
					TreeNode RT = new TreeNode("Tablas");
					RT.Tag = TipoRaiz.RaizTablas;
					TreeNode RV = new TreeNode("Vistas");
					RV.Tag = TipoRaiz.RaizVistas;
					TreeNode E = new TreeNode(s.Name);
					E.Tag = s;
					E.Nodes.AddRange(new TreeNode[] {RT, RV});
					raiz.Nodes.Add(E);
				}
			}
		}
		
		private void CrearRamaRelaciones(TreeNode raiz)
		{
			if (raiz.GetNodeCount(false) == 0)
			{
				DBSchemaInfo s = (DBSchemaInfo) raiz.Parent.Tag;
				TipoRaiz t = (TipoRaiz) raiz.Tag;
				Collection<DBRelationInfo> relations = new Collection<DBRelationInfo>();
				switch(t)
				{
					case TipoRaiz.RaizTablas:
						relations = DBUtils.QueryTableCatalog(s);
						break;
					case TipoRaiz.RaizVistas:
						relations = DBUtils.QueryViewCatalog(s);
						break;
				}
				foreach (DBRelationInfo r in relations)
				{
					TreeNode RC = new TreeNode("Columnas");
					RC.ContextMenuStrip = this.mColumnas;
					RC.Tag = TipoRaiz.RaizColumnas;
					TreeNode R = new TreeNode(r.Name);
					R.ContextMenuStrip = this.mRelacion;
					R.Tag = r;
					R.Nodes.Add(RC);
					raiz.Nodes.Add(R);
				}
			}
		}
		
		private void CrearRamaColumnas(TreeNode raiz)
		{
			if (raiz.GetNodeCount(false) == 0)
			{
				DBRelationInfo r = (DBRelationInfo) raiz.Parent.Tag;
				foreach(DBColumnInfo c in DBUtils.QueryColumnCatalog(r))
				{
					string coltype = (c.TypeLength == string.Empty) ?  c.TypeName : string.Format("{0}({1})", c.TypeName, c.TypeLength);
					TreeNode pgsqlC = new TreeNode(string.Format("{0}          {1}", c.Name, coltype));
					pgsqlC.ContextMenuStrip = this.mColumna;
					pgsqlC.Tag = c;
					raiz.Nodes.Add(pgsqlC);
				}
			}
		}		
		
		void TvEsquemasNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag is TipoRaiz)
			{
				TipoRaiz t = (TipoRaiz) e.Node.Tag;
				switch (t)
				{
					case TipoRaiz.RaizEsquemas:
						this.CrearRamaEsquemas(e.Node);
						break;
					case TipoRaiz.RaizTablas:
					case TipoRaiz.RaizVistas:
						this.CrearRamaRelaciones(e.Node);
						break;
					case TipoRaiz.RaizColumnas:
						this.CrearRamaColumnas(e.Node);
						this.tvEsquemas.SelectedNode = e.Node;
						break;
				}
			}
			else
			{
				this.tvEsquemas.SelectedNode = e.Node;
			}
		}
		
		void MitemRCopiarNombreClick(object sender, EventArgs e)
		{
			Clipboard.SetText(this.tvEsquemas.SelectedNode.Text);
		}
		
		void MitemCopiarColumnasClick(object sender, EventArgs e)
		{
			TreeNode n = this.tvEsquemas.SelectedNode;
			if (n.GetNodeCount(false) > 0)
			{
				string s = string.Empty;
				foreach (TreeNode c in n.Nodes)
				{
					s += (s == string.Empty) ? c.Text.Split(new char[] {' '})[0] : string.Format(", {0}", c.Text.Split(new char[] {' '})[0]);
				}
				Clipboard.SetText(s);
			}
		}
		
		void MitemCCopiarNombreClick(object sender, EventArgs e)
		{
			Clipboard.SetText(this.tvEsquemas.SelectedNode.Text.Split(new char[] {' '})[0]);
		}
	}
}
