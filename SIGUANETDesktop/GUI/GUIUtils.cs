/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 02/04/2006
 * Time: 0:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.ModeloExplotacion;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Usos;
using SIGUANETDesktop.ModeloSincronizacion;
using SIGUANETDesktop.ModeloClienteSOAP;
using SIGUANETDesktop.SOAP;
using SIGUANETDesktop.ModeloClienteSQL;
using SIGUANETDesktop.ModeloAdminTools;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of GUIUtils.
	/// </summary>
	public static class GUIUtils
	{
		public static TreeNode CrearNodoRoot()
		{
			Root doc;
			TreeNode n0;
			doc = new Root();
			n0= new TreeNode();
			n0.Tag = doc;
			n0.Name = doc.Nombre;
			n0.Text = doc.Nombre;
			if (doc.Quest != null && doc.Quest.Enabled) n0.Nodes.Add(CrearNodoSesionExplotacion(doc.Quest));
			if (doc.Sincronizacion != null && doc.Sincronizacion.Enabled) n0.Nodes.Add(CrearNodoSesionSinc(doc.Sincronizacion));
			if (doc.CliSOAP != null && doc.CliSOAP.Enabled) n0.Nodes.Add(CrearNodoSesionSOAP(doc.CliSOAP));
			if (doc.CliSQL != null && doc.CliSQL.Enabled) n0.Nodes.Add(CrearNodoSesionSQL(doc.CliSQL));
			if (doc.ATools != null && doc.ATools.Enabled) n0.Nodes.Add(CrearNodoSesionAT(doc.ATools));
			return n0;
		}

		public static TreeNode CrearNodoRoot(Root doc)
		{
			return CrearNodoRoot(doc, false);
		}
		public static TreeNode CrearNodoRoot(Root doc, bool forceATools)
		{
			TreeNode n0;
			n0= new TreeNode();
			n0.Tag = doc;
			n0.Name = doc.Nombre;
			n0.Text = doc.Nombre;
			if (doc.Quest != null && doc.Quest.Enabled) n0.Nodes.Add(CrearNodoSesionExplotacion(doc.Quest));
			if (doc.Sincronizacion != null && doc.Sincronizacion.Enabled) n0.Nodes.Add(CrearNodoSesionSinc(doc.Sincronizacion));
			if (doc.CliSOAP != null && doc.CliSOAP.Enabled) n0.Nodes.Add(CrearNodoSesionSOAP(doc.CliSOAP));
			if (doc.CliSQL != null && doc.CliSQL.Enabled) n0.Nodes.Add(CrearNodoSesionSQL(doc.CliSQL));
			if (!forceATools)
			{
				if (doc.ATools != null && doc.ATools.Enabled) n0.Nodes.Add(CrearNodoSesionAT(doc.ATools));
			}
			else
			{
				if (doc.ATools != null)
				{
					TreeNode nAT = CrearNodoSesionAT(doc.ATools);
					nAT.ToolTipText = "Herramientas administrativas forzadas para perfil Root";
					n0.Nodes.Add(nAT);
				}
			}
			
			return n0;
		}		
		
		public static TreeNode CrearNodoSesionExplotacion(QuestClient s)
		{
			TreeNode n0;
			TreeNode n00;
			n0 = new TreeNode();
			n0.Tag = s;
			n0.Name = s.Nombre;
			n0.Text = s.Nombre;
			
			n00 = new TreeNode();
			n00.Tag = nodosOrdenacion.puntosAcceso;
			n00.Name = "PACC";
			n00.Text = "Puntos de Acceso";
			
			n0.Nodes.Add(n00);
			
			foreach (PuntoAcceso p in s.PuntosAcceso)
			{
				n00.Nodes.Add(CrearNodoPuntoAcceso(p));
				n00.Expand();
			}
			return n0;
		}
		
		public static TreeNode CrearNodoPuntoAcceso(PuntoAcceso p)
		{		
			TreeNode n0;
			n0 = new TreeNode();
			n0.Tag = p;
			n0.Name = p.Nombre;
			n0.Text = p.Nombre;
			return n0;
		}
		
		public static TreeNode CrearNodoBaseOrg(BaseOrg baseOrg)
		{
			TreeNode n0;
			TreeNode n00;
			TreeNode n01;
			
			n0 = new TreeNode();
			n0.Tag = baseOrg;
			n0.Name = "BASEORG";
			n0.Text = AdministradorPreferencias.Read(PrefsGlobal.OrgAcronym);
						
			n00 = new TreeNode();
			n00.Tag = nodosOrdenacion.zonas;
			n00.Name = "ZONAS";
			n00.Text = "Sedes";

			n01 = new TreeNode();
			n01.Tag = nodosOrdenacion.plantasBase;
			n01.Name = "PLANTASBASE";
			n01.Text = "Plantas";
			
			n0.Nodes.AddRange(new TreeNode[2] {n00, n01});
			
			return n0;
		}
		
		public static TreeNode[] CrearNodosPlantaBase(List<PlantaBase> plantas)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			foreach(PlantaBase p in plantas)
			{
				TreeNode n0;
				n0 = new TreeNode();
				n0.Tag = p;
				n0.Name = string.Format("BASEORG{0}", p.Planta.ToString());
				n0.Text = p.Planta.ToString();
				nodes.Add(n0);
			}
			return nodes.ToArray();
		}		
		
		public static TreeNode[] CrearNodosZona(List<Zona> zonas)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			foreach(Zona z in zonas)
			{
				TreeNode n0;
				n0 = new TreeNode();
				n0.Tag = z;
				n0.Name = z.Codigo;
				n0.Text = z.Denominacion;
				
				TreeNode n00;
				n00 = new TreeNode();
				n00.Tag = nodosOrdenacion.edificios;
				n00.Name = "EDIFICIOS";
				n00.Text = "Edificios";
				n0.Nodes.Add(n00);
				if (z.NumEdificios > 1)
				{
					TreeNode n01;
					n01 = new TreeNode();
					n01.Tag = nodosOrdenacion.plantasZona;
					n01.Name = "PLANTASZONA";
					n01.Text = "Plantas";
					n0.Nodes.Add(n01);
				}
				
				nodes.Add(n0);
			}
			return nodes.ToArray();
		}
		
		public static TreeNode[] CrearNodosPlantaZona(List<PlantaZona> plantas)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			foreach(PlantaZona p in plantas)
			{
				TreeNode n0;
				n0 = new TreeNode();
				n0.Tag = p;
				n0.Name = p.Zona.Codigo + p.Planta.ToString();
				n0.Text = p.Planta.ToString();
				nodes.Add(n0);
			}
			return nodes.ToArray();
		}
		
		public static TreeNode[] CrearNodosEdificio(List<Edificio> edificios)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			foreach(Edificio e in edificios)			
			{
				TreeNode n0;
				n0 = new TreeNode();
				n0.Tag = e;
				n0.Name = e.Codigo;
				n0.Text = string.Format("{0}. {1}", e.Codigo.Substring(2), e.Denominacion);
				TreeNode n00;
				n00 = new TreeNode();
				n00.Tag = nodosOrdenacion.plantasEdificio;
				n00.Name = "PLANTASEDIFICIO";
				n00.Text = "Plantas";
				n0.Nodes.Add(n00);				
				nodes.Add(n0);
			}
			return nodes.ToArray();
		}
		
		public static TreeNode[] CrearNodosPlantaEdificio(List<PlantaEdificio> plantas)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			foreach(PlantaEdificio p in plantas)
			{
				TreeNode n0;
				n0 = new TreeNode();
				n0.Tag = p;
				n0.Name = p.Codigo;
				n0.Text = p.Planta.ToString();
				nodes.Add(n0);
			}
			return nodes.ToArray();
		}
		
		public static TreeNode[] CrearNodosDptoSIGUA(List<DepartamentoSIGUA> deptos)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			foreach(DepartamentoSIGUA d in deptos)
			{
				TreeNode n0;
				n0 = new TreeNode();
				n0.Tag = d;
				n0.Name = d.Codigo;
				n0.Text = d.Denominacion;
				n0.Nodes.Add(CrearNodoBaseOrg(new BaseOrg()));
				nodes.Add(n0);				
			}
			return nodes.ToArray();
		}
		
		public static TreeNode[] CrearNodosActSIGUA(List<ActividadSIGUA> acts)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			foreach(ActividadSIGUA a in acts)
			{
				TreeNode n0;
				n0 = new TreeNode();
				n0.Tag = a;
				n0.Name = a.Codigo.ToString();
				n0.Text = a.Denominacion;
				n0.Nodes.Add(CrearNodoBaseOrg(new BaseOrg()));
				nodes.Add(n0);				
			}
			return nodes.ToArray();
		}
		
		public static TreeNode[] CrearNodosGrupoAct(List<GrupoActividad> grupos)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			foreach(GrupoActividad g in grupos)
			{
				TreeNode n0;
				n0 = new TreeNode();
				n0.Tag = g;
				n0.Name = g.Denominacion;
				n0.Text = g.DenominacionAlt;
				n0.Nodes.Add(CrearNodoBaseOrg(new BaseOrg()));
				nodes.Add(n0);
			}
			return nodes.ToArray();
		}
		
		public static TreeNode CrearNodoSesionSOAP(SesionSOAP s)
		{
			TreeNode n0;
			
			n0 = new TreeNode();
			n0.Tag = s;
			n0.Name = s.Nombre;
			n0.Text = s.Descripcion;
			
			return n0;
		}
		
		public static TreeNode[] CrearNodosSOAPMethodInfo(SOAPServiceInfo soap, bool useGroups)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			if (useGroups)
			{
				TreeNode pub = new TreeNode();
				TreeNode priv = new TreeNode();
				pub.Tag = soap.PublicContainer;
				pub.Name = soap.PublicContainer.Name;
				pub.Text = soap.PublicContainer.Name;
				priv.Tag = soap.PrivateContainer;
				priv.Name = soap.PrivateContainer.Name;
				priv.Text = soap.PrivateContainer.Name;
				foreach(SOAPGroup g in soap.PublicContainer.Groups)
				{
					TreeNode gNode = new TreeNode();
					gNode.Tag = g;
					gNode.Name = g.Label;
					gNode.Text = g.Label;
					foreach(SOAPMethodInfo m in g.Methods)
					{
						if (!m.Obsolete)
						{
							TreeNode mNode = new TreeNode();
							mNode.Tag = m;
							mNode.Name = m.Name;
							mNode.Text = m.Label;
							gNode.Nodes.Add(mNode);
						}
					}
					pub.Nodes.Add(gNode);
				}
				nodes.Add(pub);
				if (!SOAPSettings.UseAnonymousCredentials)
				{
					foreach(SOAPGroup g in soap.PrivateContainer.Groups)
					{
						TreeNode gNode = new TreeNode();
						gNode.Tag = g;
						gNode.Name = g.Label;
						gNode.Text = g.Label;
						foreach(SOAPMethodInfo m in g.Methods)
						{
							if (!m.Obsolete)
							{
								TreeNode mNode = new TreeNode();
								mNode.Tag = m;
								mNode.Name = m.Name;
								mNode.Text = m.Label;
								gNode.Nodes.Add(mNode);
							}
						}
						priv.Nodes.Add(gNode);
					}
					nodes.Add(priv);
				}
			}
			else
			{
				TreeNode pub = new TreeNode("Métodos comunes");
				TreeNode priv = new TreeNode("Métodos específicos");
				pub.Tag = nodosOrdenacion.metodosSOAPPublicos;
				priv.Tag = nodosOrdenacion.metodosSOAPPrivados;
				foreach(SOAPMethodInfo m in soap.VisibleMethods)
				{
					if (!m.Obsolete)
					{
						TreeNode n0;
						n0 = new TreeNode();
						n0.Tag = m;
						n0.Name = m.Name;
						n0.Text = m.Label;
						if (m.Public)
						{
							pub.Nodes.Add(n0);
						}
						else
						{
							if (!SOAPSettings.UseAnonymousCredentials)
							{
								priv.Nodes.Add(n0);
							}
						}
					}
				}
				nodes.Add(pub);
				if (!SOAPSettings.UseAnonymousCredentials)
				{
					nodes.Add(priv);
				}
			}
			return nodes.ToArray();
		}		
		
		public static TreeNode CrearNodoSesionSQL(SesionSQL s)
		{
			TreeNode n0;
			
			n0 = new TreeNode();
			n0.Tag = s;
			n0.Name = s.Nombre;
			n0.Text = s.Nombre;
			
			return n0;
		}

		public static TreeNode CrearNodoSesionAT(SesionAT s)
		{
			TreeNode n0;
			
			n0 = new TreeNode();
			n0.Tag = s;
			n0.Name = s.Nombre;
			n0.Text = s.Nombre;
			
			return n0;
		}
		
		public static TreeNode CrearNodoSesionSinc(SesionSinc s)
		{
			TreeNode n0;
			TreeNode n00;
			
			n0 = new TreeNode();
			n0.Tag = s;
			n0.Name = s.Nombre;
			n0.Text = s.Nombre;
									
			n00 = new TreeNode();
			n00.Tag = nodosOrdenacion.operaciones;
			n00.Name = "OPS";
			n00.Text = "Operaciones";
						
			n0.Nodes.Add(n00);
						
			foreach (Operacion o in s.Operaciones)
			{
				n00.Nodes.Add(CrearNodoOperacion(o));
				n00.Expand();
			}
			return n0;
		}		
		
		public static TreeNode CrearNodoOperacion(Operacion o)
		{
			TreeNode n0;
			TreeNode n00;
			TreeNode n01;
			TreeNode n02;
			TreeNode n03;
			n0 = new TreeNode();
			n0.Tag = o;
			n0.Name = o.Nombre;
			n0.Text = o.Descripcion;
			n00 = new TreeNode();
			n00.Tag = nodosOrdenacion.tareasPre; 
			n00.Name = string.Format("{0}{1}", o.Nombre,"PREV");
			n00.Text = "Tareas de comprobación previa";
			foreach (PreSincro pre in o.PreComprobaciones)
			{
				n00.Nodes.Add(CrearNodoPreSincro(pre));
				n00.Expand();
			}
			n01 = new TreeNode();
			n01.Tag = nodosOrdenacion.tareasSinc;
			n01.Name = string.Format("{0}{1}", o.Nombre,"SINC");
			n01.Text = "Tareas de sincronización";
			foreach (Sincro sinc in o.Acciones)
			{
				n01.Nodes.Add(CrearNodoSincro(sinc));
				n01.Expand();
			}
			n02 = new TreeNode();
			n02.Tag = nodosOrdenacion.tareasPost;
			n02.Name = string.Format("{0}{1}", o.Nombre,"POST");
			n02.Text = "Tareas de comprobación posterior";
			foreach (PostSincro post in o.PostComprobaciones)
			{
				n02.Nodes.Add(CrearNodoPostSincro(post));
				n02.Expand();
			}
			n03 = new TreeNode();
			n03.Tag = nodosOrdenacion.tareasComp;
			n03.Name = string.Format("{0}{1}", o.Nombre,"COMP");
			n03.Text = "Tareas complementarias";
			foreach (Complemento comp in o.Complementos)
			{
				n03.Nodes.Add(CrearNodoComplemento(comp));
				n03.Expand();
			}			
			n0.Nodes.AddRange(new TreeNode[] {n00, n01, n02, n03});
			return n0;
		}
		
		public static TreeNode CrearNodoPreSincro(PreSincro pre)
		{
			TreeNode n0;
			TreeNode n00;
			n0 = new TreeNode();
			n0.Tag = pre;
			n0.Name = pre.Nombre;
			n0.Text = pre.Descripcion;
			n00 = new TreeNode();
			n00.Tag = nodosOrdenacion.comandos; 
			n00.Name = string.Format("{0}{1}", pre.Nombre,"PRECMDS");
			n00.Text = "Comandos";
			foreach (Comando cmd in pre.Comandos)
			{
				n00.Nodes.Add(CrearNodoComando(cmd));
				n00.Expand();
			}
			n0.Nodes.Add(n00);
			return n0;
		}

		public static TreeNode CrearNodoSincro(Sincro sinc)
		{
			TreeNode n0;
			TreeNode n00;
			n0 = new TreeNode();
			n0.Tag = sinc;
			n0.Name = sinc.Nombre;
			n0.Text = sinc.Descripcion;
			n00 = new TreeNode();
			n00.Tag = nodosOrdenacion.comandos; 
			n00.Name = string.Format("{0}{1}", sinc.Nombre,"SINCCMDS");
			n00.Text = "Comandos";
			foreach (Comando cmd in sinc.Comandos)
			{
				n00.Nodes.Add(CrearNodoComando(cmd));
				n00.Expand();
			}			
			n0.Nodes.Add(n00);
			return n0;
		}

		public static TreeNode CrearNodoPostSincro(PostSincro post)
		{
			TreeNode n0;
			TreeNode n00;
			n0 = new TreeNode();
			n0.Tag = post;
			n0.Name = post.Nombre;
			n0.Text = post.Descripcion;
			n00 = new TreeNode();
			n00.Tag = nodosOrdenacion.comandos; 
			n00.Name = string.Format("{0}{1}", post.Nombre,"POSTCMDS");
			n00.Text = "Comandos";
			foreach (Comando cmd in post.Comandos)
			{
				n00.Nodes.Add(CrearNodoComando(cmd));
				n00.Expand();
			}			
			n0.Nodes.Add(n00);
			return n0;
		}
		
		public static TreeNode CrearNodoComplemento(Complemento comp)
		{
			TreeNode n0;
			TreeNode n00;
			n0 = new TreeNode();
			n0.Tag = comp;
			n0.Name = comp.Nombre;
			n0.Text = comp.Descripcion;
			n00 = new TreeNode();
			n00.Tag = nodosOrdenacion.comandos; 
			n00.Name = string.Format("{0}{1}", comp.Nombre,"COMPCMDS");
			n00.Text = "Comandos";
			foreach (Comando cmd in comp.Comandos)
			{
				n00.Nodes.Add(CrearNodoComando(cmd));
				n00.Expand();
			}
			n0.Nodes.Add(n00);
			return n0;
		}
		
		public static TreeNode CrearNodoComando(Comando cmd)
		{
			TreeNode n0;
			n0 = new TreeNode();
			n0.Tag = cmd;
			n0.Name = cmd.Nombre;
			n0.Text = cmd.Descripcion;
			return n0;
		}
		

		private static TreeNode obtenerNodoCampus (Estancia e, TreeNode nodoUA)
		{
			TreeNode nodoCampus = new TreeNode();
			bool existe = false;
			foreach (TreeNode n in nodoUA.Nodes)
			{
				Zona candidato = (Zona) n.Tag; 
				if (candidato.Codigo == e.PlantaEdificio.Edificio.Zona.Codigo)
				{
					nodoCampus = n;
					existe = true;
				}
			}
			if (!existe)
			{
				nodoCampus.Text =e.PlantaEdificio.Edificio.Zona.Denominacion;
				nodoCampus.Tag = e.PlantaEdificio.Edificio.Zona;
				nodoUA.Nodes.Add(nodoCampus);
			}
			return nodoCampus;
		}

		private static TreeNode obtenerNodoEdificio (Estancia e, TreeNode nodoUA)
		{
			TreeNode nodoCampus = obtenerNodoCampus(e, nodoUA);
			TreeNode nodoEdificio = new TreeNode();
			bool existe = false;
			foreach (TreeNode n in nodoCampus.Nodes)
			{
				Edificio candidato = (Edificio) n.Tag;
				if (candidato.Codigo == e.PlantaEdificio.Edificio.Codigo)
				{
					nodoEdificio = n;
					existe = true;
				}
			}
			if (!existe)
			{
				nodoEdificio.Text = string.Format("{0}-{1}",e.PlantaEdificio.Edificio.Codigo,e.PlantaEdificio.Edificio.Denominacion);
				nodoEdificio.Tag = e.PlantaEdificio.Edificio;
				nodoCampus.Nodes.Add(nodoEdificio);
			}
			return nodoEdificio;
		}
		
		public static TreeNode obtenerNodoPlanta (Estancia e, TreeNode nodoUA)
		{
			TreeNode nodoEdificio = obtenerNodoEdificio(e, nodoUA);
			TreeNode nodoPlanta = new TreeNode();
			bool existe = false;
			foreach (TreeNode n in nodoEdificio.Nodes)
			{
				PlantaEdificio candidato = (PlantaEdificio) n.Tag;
				if (candidato.Codigo == e.PlantaEdificio.Codigo)
				{
					nodoPlanta = n;
					existe = true;
				}
			}
			if (!existe)
			{
				nodoPlanta.Text = e.PlantaEdificio.Planta.ToString();
				nodoPlanta.Tag = e.PlantaEdificio;
				nodoEdificio.Nodes.Add(nodoPlanta);
			}
			return nodoPlanta;
		}		
		
		private static TreeNode obtenerNodoCampus (PlantaEdificio p, TreeNode nodoUA)
		{
			TreeNode nodoCampus = new TreeNode();
			bool existe = false;
			foreach (TreeNode n in nodoUA.Nodes)
			{
				Zona candidato = (Zona) n.Tag; 
				if (candidato.Codigo == p.Edificio.Zona.Codigo)
				{
					nodoCampus = n;
					existe = true;
				}
			}
			if (!existe)
			{
				nodoCampus.Text = p.Edificio.Zona.Denominacion;
				nodoCampus.Tag = p.Edificio.Zona;
				nodoUA.Nodes.Add(nodoCampus);
			}
			return nodoCampus;
		}

		public static TreeNode obtenerNodoEdificio (PlantaEdificio p, TreeNode nodoUA)
		{
			TreeNode nodoCampus = obtenerNodoCampus(p, nodoUA);
			TreeNode nodoEdificio = new TreeNode();
			bool existe = false;
			foreach (TreeNode n in nodoCampus.Nodes)
			{
				Edificio candidato = (Edificio) n.Tag;
				if (candidato.Codigo == p.Edificio.Codigo)
				{
					nodoEdificio = n;
					existe = true;
				}
			}
			if (!existe)
			{
				nodoEdificio.Text = string.Format("{0}-{1}", p.Edificio.Codigo, p.Edificio.Denominacion);
				nodoEdificio.Tag = p.Edificio;
				nodoCampus.Nodes.Add(nodoEdificio);
			}
			return nodoEdificio;
		}
	}
}
