/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 09/03/2006
 * Time: 14:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using SIGUANETDesktop.Extension;
using SIGUANETDesktop.Preferencias;
using SIGUANETDesktop.Log;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.GUI;
using SIGUANETDesktop.XML;
using SIGUANETDesktop.ModeloDocumento;
using SIGUANETDesktop.Perfiles;
using SIGUANETDesktop.ModeloExplotacion;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Usos;
using SIGUANETDesktop.ModeloSincronizacion;
using SIGUANETDesktop.ModeloSincronizacion.AutoSincro;
using SIGUANETDesktop.ModeloClienteSOAP;
using SIGUANETDesktop.SOAP;
using SIGUANETDesktop.Utilidades;


namespace SIGUANETDesktop
{
		
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm
	{
		private static string _minserveUrlBase = string.Empty;
		private ExtensionLocator extLocator;
		private static string _txPerfil;
		private static string _txPerfilCustom;
		private static string _txImpersonacion;
		private static string _txImpersonacionCustom;
		private AppLog al = AppLog.Instance;
		private string ficheroActivo = string.Empty;
		private estadoModelo estado = estadoModelo.Ninguno;
		private TreeNode nodoActivo;
		private MouseButtons btMouse;
		//Instancia única del visor de sucesos
		private frmVisorSucesos _visorSucesos = new frmVisorSucesos();
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			AdministradorPreferencias.Load();
			if (args.Length > 0) {
				if (args[0] == "--configure") {
					Application.Run (new frmPreferencias ());
				}
				else if (args[0] == "--srs") {
					Form w = new Form ();
					w.StartPosition = FormStartPosition.CenterScreen;
					w.FormBorderStyle = FormBorderStyle.FixedDialog;
					w.MaximizeBox = false;
					w.MinimizeBox = false;
					w.Text = "Crear fichero SRS";
					controlSRSManager dlg = new controlSRSManager (true);
					w.Controls.Add (dlg);
					int dlgHeight = dlg.GetCreateOnlyModeHeight ();
					int dlgWidth = dlg.GetCreateOnlyModeWidth ();
					w.Height = dlgHeight + ((dlgHeight * 17) / 100);
					w.Width = dlgWidth + ((dlgWidth * 5) / 100);
					Application.Run (w);
				}
				else {
					if (args[0] == "--minserve") {
						//Start embedded HTTP server
						int port = -1;
						if (args.GetLength(0) > 1)
						    int.TryParse(args[1], out port);
						MinServe minserve = new MinServe(port);
						_minserveUrlBase = minserve.UrlBase;
						minserve.Start();
						Application.Run(new MainForm());
						minserve.Stop();
					}
				}
			}
			else {
				Application.Run(new MainForm());
			}
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//=======================================================================
			//Cargamos las extensiones que haya disponibles
			extLocator = new ExtensionLocator ();
			extLocator.LocateAll ();
			//=======================================================================
			
			//=======================================================================
			//Almacenamos en variables estáticas las cadenas con formato del interfaz
			//que son susceptibles de variar a lo largo de la ejecución
			MainForm._txPerfil = this.tstxPerfil.Text;
			MainForm._txPerfilCustom = this.tstxPerfilCustom.Text;
			MainForm._txImpersonacion = this.tstxImpersonacion.Text;
			MainForm._txImpersonacionCustom = this.tstxImpersonacionCustom.Text;
			//========================================================================
			
			this.Text = string.Format("{0} - {1}", Loader.Title, Loader.Description);
			this.tssbIncidencias.Visible = false;
			al.ExceptionsExistEvent += delegate {this.tssbIncidencias.Visible = true;};
			Loader.Initialize (MainForm._minserveUrlBase);
			Loader.MultipleProfileEvent += this.OnMultipleProfile;
			Loader.ProfileSetEvent += this.OnProfileChanged;
			Loader.ImpersonationChangedEvent += this.OnProfileChanged;
			Loader.CustomProfileChangedEvent += this.OnProfileChanged;
			
		}
		
		void MainFormShown(object sender, EventArgs e)
		{
			this.Opacity = 0.8;
			this.Authenticate();
			this.Opacity = 1.0;
			this.Open();
		}
		
		private void Authenticate()
		{
			IUserLoginView userLoginView = extLocator.GetExtension<IUserLoginView> ();
			if (userLoginView == null) {
				userLoginView = new frmAutentificacion();
			}
			userLoginView.ShowView();
			this.Cursor = Cursors.WaitCursor;
			if (!userLoginView.IsAnonymous)
			{
				if (userLoginView.SRSByPass)
				{
					frmConexionPGSQL dlgPG = new frmConexionPGSQL();
										
					if (dlgPG.ShowDialog() == DialogResult.OK)
					{
						Loader.Authenticate (extLocator, DBUtils.TestConnection(dbOrigen.PGSQL), userLoginView.GetAuthInfo ());
						//Loader.Authenticate(userLoginView.Usr, userLoginView.Clave, DBUtils.TestConnection(dbOrigen.PGSQL));
					}
					else
					{
						Loader.Authenticate (extLocator, false, userLoginView.GetAuthInfo ());
						//Loader.Authenticate(userLoginView.Usr, userLoginView.Clave, false);
					}
				}
				else
				{
					Loader.Authenticate (extLocator, false, userLoginView.GetAuthInfo ());
					//Loader.Authenticate(userLoginView.Usr, userLoginView.Clave, false);
				}				
			}
			else
			{
				if (userLoginView.PerfilPersonalizado.Trim().Length > 0)
				{
					Loader.SetCustomProfile(userLoginView.PerfilPersonalizado.Trim());
				}
			}
			if (Loader.CanImpersonate)
			{
				frmSuplantacion dlgImpers = new frmSuplantacion();
				dlgImpers.ShowDialog();
				if (!dlgImpers.UsarDefault)
				{
					Loader.Impersonate(dlgImpers.Perfil, dlgImpers.PerfilPersonalizado);
				}
			}
			this.Cursor = Cursors.Default;
		}
		
		private void OnMultipleProfile(string[] profiles)
		{
			frmPerfilMultiple dlgPMultiple = new frmPerfilMultiple(profiles);
			dlgPMultiple.ShowDialog();
			Loader.ResumeAuthentication(dlgPMultiple.PerfilSeleccionado);
		}
		
		private void OnProfileChanged()
		{
			this.tstxPerfil.Text = string.Format(MainForm._txPerfil, Loader.Profile.ToString());
			this.tstxPerfilCustom.Text = string.Format(MainForm._txPerfilCustom, Loader.CustomProfile.ToString());
			this.tstxImpersonacion.Text = string.Format(MainForm._txImpersonacion, Loader.Impersonation.ToString());
			this.tstxImpersonacionCustom.Text = string.Format(MainForm._txImpersonacionCustom, Loader.CustomImpersonation.ToString());
		}
		
		private void Open()
		{
			this.Cursor = Cursors.WaitCursor;
			Root doc = null;
			doc = Loader.LoadSGD();
			Loader.LoadSRS();
			
			if (doc != null)
			{
				this.ficheroActivo = doc.DefaultLocation;
				this.tvDoc.Nodes.Clear();
				this.tvDoc.Nodes.Add(GUIUtils.CrearNodoRoot(doc, (Loader.Profile == ProfileType.Root && doc.Perfil != ProfileType.Root)));
				this.estado = estadoModelo.Actualizado;
				this.MostrarDialogo(null);
			}
			else
			{
				this.tvDoc.Nodes.Clear();
				this.tvDoc.Nodes.Add(GUIUtils.CrearNodoRoot());
				estado = estadoModelo.Nuevo;				
			}
			GUIProfiler.Apply(this);
			this.Cursor = Cursors.Default;
		}
			
		private void MostrarDialogo(UserControl d)
		{
			this.splitContainer1.Panel2.Controls.Clear();
			if (d != null)
			{
				d.Dock = DockStyle.Fill;
				this.splitContainer1.Panel2.Controls.Add(d);
			}
		}
		
		private void CambiarEstadoDocumento(estadoModelo e)
		{
			estado = e;
		}

		private void TvDoc_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			this.btMouse = e.Button;
			switch(e.Node.Tag.GetType().Name)
			{
				case "BaseOrg":
				{
					nodoActivo = e.Node;
					break;
				}
				case "PlantaBase":
				{
					nodoActivo = e.Node;
					break;						
				}
				case "Zona":
				{
					nodoActivo = e.Node;
					break;
				}
				case "PlantaZona":
				{
					nodoActivo = e.Node;
					break;
				}
				case "Edificio":
				{
					nodoActivo = e.Node;
					break;
				}
				case "PlantaEdificio":
				{
					nodoActivo = e.Node;
					break;
				}
				default:
				{
					this.tvDoc.SelectedNode = nodoActivo = e.Node;
					break;
				}
			}
		}
		
		private void TvDoc_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
		{
			switch(e.Node.Tag.GetType().Name)
			{
				case "BaseOrg":
				{
					this.tvDoc.SelectedNode = nodoActivo = e.Node.Parent;
					break;
				}
				case "Zona":
				{
					this.tvDoc.SelectedNode = nodoActivo = e.Node.Parent;
					break;
				}
				case "Edificio":
				{
					this.tvDoc.SelectedNode = nodoActivo = e.Node.Parent;
					break;
				}
				default:
				{
					break;
				}
			}
		}
		
		private void TvDoc_AfterSelect(object sender, TreeViewEventArgs e)
		{
			nodoActivo = e.Node;

			if (nodoActivo.Tag != null)
			{
				switch(nodoActivo.Tag.GetType().Name)
				{
					case "QuestClient":
						controlSesionExplotacion dlgexp = new controlSesionExplotacion(nodoActivo);
						dlgexp.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgexp);
						break;
					case "PuntoAcceso":
						switch ((nodoActivo.Tag as PuntoAcceso).Tipo)
						{
							case tipoPuntoAcceso.ArbolEspacial:

								controlArbolEspacios dlgaes = new controlArbolEspacios(nodoActivo);
								dlgaes.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgaes);
								if (btMouse == MouseButtons.Left)
								{									
									if (nodoActivo.Nodes.Count == 0)
									{
										if (!DBSettings.PGSQLSettingsOK)
										{
											frmConexionPGSQL w = new frmConexionPGSQL();
											DialogResult r = w.ShowDialog();
											if (r == DialogResult.OK)
											{
												if (DBUtils.TestConnection(dbOrigen.PGSQL))
												{
													BaseOrg baseOrg = new BaseOrg();
													nodoActivo.Nodes.Add(GUIUtils.CrearNodoBaseOrg(baseOrg));
												}
											}								
										}
										else
										{
											if (DBUtils.TestConnection(dbOrigen.PGSQL))
											{
												BaseOrg baseOrg = new BaseOrg();
												nodoActivo.Nodes.Add(GUIUtils.CrearNodoBaseOrg(baseOrg));
											}
										}
									}									
								}
								break;
							case tipoPuntoAcceso.ArbolOrganizativo:
								controlArbolOrganizacion dlgaor = new controlArbolOrganizacion(nodoActivo);
								dlgaor.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgaor);
								if (btMouse == MouseButtons.Left)
								{
									if (nodoActivo.Nodes.Count == 0)
									{
										if (!DBSettings.PGSQLSettingsOK)
										{
											frmConexionPGSQL w = new frmConexionPGSQL();
											DialogResult r = w.ShowDialog();
											if (r == DialogResult.OK)
											{
												if (DBUtils.TestConnection(dbOrigen.PGSQL))
												{
													BaseOrg baseOrg = new BaseOrg();
													List<DepartamentoSIGUA> departamentos = baseOrg.ObtenerDepartamentosSIGUA();
													nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosDptoSIGUA(departamentos));
												}
											}								
										}
										else
										{
											if (DBUtils.TestConnection(dbOrigen.PGSQL))
											{
												BaseOrg baseOrg = new BaseOrg();
												List<DepartamentoSIGUA> departamentos = baseOrg.ObtenerDepartamentosSIGUA();
												nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosDptoSIGUA(departamentos));
											}
										}
									}
								}
								break;
							case tipoPuntoAcceso.ArbolActividades:
								controlArbolActividades dlgaac = new controlArbolActividades(nodoActivo);
								dlgaac.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgaac);
								if (btMouse == MouseButtons.Left)
								{
									if (nodoActivo.Nodes.Count == 0)
									{
										if (!DBSettings.PGSQLSettingsOK)
										{
											frmConexionPGSQL w = new frmConexionPGSQL();
											DialogResult r = w.ShowDialog();
											if (r == DialogResult.OK)
											{
												if (DBUtils.TestConnection(dbOrigen.PGSQL))
												{
													BaseOrg baseOrg = new BaseOrg();
													List<ActividadSIGUA> actividades = baseOrg.ObtenerActividadesSIGUA();
													nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosActSIGUA(actividades));
												}
											}
										}
										else
										{
											if (DBUtils.TestConnection(dbOrigen.PGSQL))
											{
												BaseOrg baseOrg = new BaseOrg();
												List<ActividadSIGUA> actividades = baseOrg.ObtenerActividadesSIGUA();
												nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosActSIGUA(actividades));
											}
										}
									}
								}
								break;
							case tipoPuntoAcceso.ArbolGruposActividad:
							case tipoPuntoAcceso.ArbolGruposActividadCRUE:
							case tipoPuntoAcceso.ArbolGruposActividadU21:
								TipoGrupo tg = TipoGrupo.ACTIVRESUM;
								if ((nodoActivo.Tag as PuntoAcceso).Tipo == tipoPuntoAcceso.ArbolGruposActividad) tg = TipoGrupo.ACTIVRESUM;
									else if ((nodoActivo.Tag as PuntoAcceso).Tipo == tipoPuntoAcceso.ArbolGruposActividadCRUE) tg = TipoGrupo.CRUE;
										else if ((nodoActivo.Tag as PuntoAcceso).Tipo == tipoPuntoAcceso.ArbolGruposActividadU21) tg = TipoGrupo.U21;
								controlArbolGruposActividad dlggac = new controlArbolGruposActividad(nodoActivo);
								dlggac.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlggac);
								if (btMouse == MouseButtons.Left)
								{
									if (nodoActivo.Nodes.Count == 0)
									{
										if (!DBSettings.PGSQLSettingsOK)
										{
											frmConexionPGSQL w = new frmConexionPGSQL();
											DialogResult r = w.ShowDialog();
											if (r == DialogResult.OK)
											{
												if (DBUtils.TestConnection(dbOrigen.PGSQL))
												{
													BaseOrg baseOrg = new BaseOrg();
													List<GrupoActividad> gruposact = baseOrg.ObtenerGruposActividad(tg);
													nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosGrupoAct(gruposact));
												}
											}
										}
										else
										{
											if (DBUtils.TestConnection(dbOrigen.PGSQL))
											{
												BaseOrg baseOrg = new BaseOrg();
													List<GrupoActividad> gruposact = baseOrg.ObtenerGruposActividad(tg);
													nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosGrupoAct(gruposact));
											}
										}
									}
								}
								break;
							default:
								this.MostrarDialogo(null);
								break;
						}
						break;
					case "BaseOrg":
						controlPropiedadesUGE dlgpropua = null;
						if (nodoActivo.Parent.Tag is PuntoAcceso) //Árbol de espacios
						{
							dlgpropua = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Tag, (BaseOrg) nodoActivo.Tag, null);
						}
						else if (nodoActivo.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
						{
							dlgpropua = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Tag, (BaseOrg) nodoActivo.Tag, nodoActivo.Parent.Tag);
						}
						else if (nodoActivo.Parent.Tag is ActividadSIGUA) //Árbol de actividades
						{
							dlgpropua = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Tag, (BaseOrg) nodoActivo.Tag, nodoActivo.Parent.Tag);
						}
						else if (nodoActivo.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad (propios, CRUE o UXXI)
						{
							dlgpropua = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Tag, (BaseOrg) nodoActivo.Tag, nodoActivo.Parent.Tag);
						}						
						if (dlgpropua != null)
						{
							this.MostrarDialogo(dlgpropua);
							dlgpropua.Refresh();
							dlgpropua.MostrarPaginaPropiedades();
						}
						else
						{
							this.MostrarDialogo(null);
						}
						break;
					case "PlantaBase":
						controlPropiedadesUGE dlgproppua = null;
						if (nodoActivo.Parent.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
						{
							dlgproppua = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Tag, (PlantaBase) nodoActivo.Tag, null);
						}
						else if (nodoActivo.Parent.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
						{
							dlgproppua = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Tag, (PlantaBase) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
						{
							dlgproppua = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Tag, (PlantaBase) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
						{
							dlgproppua = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Tag, (PlantaBase) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Tag);
						}						
						if (dlgproppua != null)
						{
							this.MostrarDialogo(dlgproppua);
							dlgproppua.Refresh();
							dlgproppua.MostrarPaginaPropiedades();
						}
						else
						{
							this.MostrarDialogo(null);
						}
						break;
					case "Zona":
						controlPropiedadesUGE dlgpropzona = null;
						if (nodoActivo.Parent.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
						{
							dlgpropzona = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Tag, (Zona) nodoActivo.Tag, null);
						}
						else if (nodoActivo.Parent.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
						{
							dlgpropzona = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Tag, (Zona) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
						{
							dlgpropzona = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Tag, (Zona) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
						{
							dlgpropzona = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Tag, (Zona) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Tag);
						}
						if (dlgpropzona != null)
						{
							this.MostrarDialogo(dlgpropzona);
							dlgpropzona.Refresh();
							dlgpropzona.MostrarPaginaPropiedades();
						}
						else
						{
							this.MostrarDialogo(null);
						}						
						break;
					case "PlantaZona":
						controlPropiedadesUGE dlgproppzona = null;
						if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
						{
							dlgproppzona = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag, (PlantaZona) nodoActivo.Tag, null);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
						{
							dlgproppzona = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (PlantaZona) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
						{
							dlgproppzona = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (PlantaZona) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
						{
							dlgproppzona = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (PlantaZona) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag);
						}
						if (dlgproppzona != null)
						{
							this.MostrarDialogo(dlgproppzona);
							dlgproppzona.Refresh();
							dlgproppzona.MostrarPaginaPropiedades();
						}
						else
						{
							this.MostrarDialogo(null);
						}
						break;
					case "Edificio":
						controlPropiedadesUGE dlgpropedificio = null;
						if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
						{
							dlgpropedificio = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag, (Edificio) nodoActivo.Tag, null);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
						{
							dlgpropedificio = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (Edificio) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
						{
							dlgpropedificio = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (Edificio) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
						{
							dlgpropedificio = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (Edificio) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Tag);
						}						
						if (dlgpropedificio != null)
						{
							this.MostrarDialogo(dlgpropedificio);
							dlgpropedificio.Refresh();
							dlgpropedificio.MostrarPaginaPropiedades();
						}
						else
						{
							this.MostrarDialogo(null);
						}
						break;
					case "PlantaEdificio":
						controlPropiedadesUGE dlgproppedificio = null;
						if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
						{
							dlgproppedificio = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (PlantaEdificio) nodoActivo.Tag, null);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
						{
							dlgproppedificio = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (PlantaEdificio) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
						{
							dlgproppedificio = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (PlantaEdificio) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag);
						}
						else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
						{
							dlgproppedificio = new controlPropiedadesUGE((PuntoAcceso) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag, (PlantaEdificio) nodoActivo.Tag, nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag);
						}
						if (dlgproppedificio != null)
						{
							this.MostrarDialogo(dlgproppedificio);
							dlgproppedificio.Refresh();
							dlgproppedificio.MostrarPaginaPropiedades();
						}
						else
						{
							this.MostrarDialogo(null);
						}
						break;
					case "DbSyncClient":
						controlSesionSinc dlgses = new controlSesionSinc(nodoActivo);
						dlgses.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgses);
						break;
					case "SoapClient":
						SoapClient sesSOAP = (SoapClient) nodoActivo.Tag;
						if (sesSOAP.Estado == EstadoSesionSOAP.NoIniciada)
						{
							try
							{
								sesSOAP.IniciarSesion(true);
							}
							catch
							{
								sesSOAP.IniciarSesion(false);
								MessageBox.Show("No pudo iniciarse la sesión con el documento de configuración de interfaz de usuario (WSUI) especificado", "Inicio de sesión SOAP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
						controlSesionSOAP dlgsep = new controlSesionSOAP(nodoActivo, GUISettings.UseSOAPGroups);
						dlgsep.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgsep);
						if (nodoActivo.Nodes.Count == 0)
						{
							this.nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosSOAPMethodInfo(sesSOAP.ServiceInfo, true));
						}
						break;
					case "SOAPPublicContainer":
					case "SOAPPrivateContainer":
						controlSOAPContainer dlgsoc = new controlSOAPContainer(nodoActivo);
						this.MostrarDialogo(dlgsoc);
						break;
					case "SOAPGroup":
						controlSOAPGroup dlgsog = new controlSOAPGroup(nodoActivo);
						this.MostrarDialogo(dlgsog);
						break;						
					case "SOAPMethodInfo":
						SOAPServiceInfo soap;
						if (!GUISettings.UseSOAPGroups)
						{
							soap = (nodoActivo.Parent.Parent.Tag as SoapClient).ServiceInfo;
						}
						else
						{
							soap = (nodoActivo.Parent.Parent.Parent.Tag as SoapClient).ServiceInfo;
						}
						
						SOAPMethodInfo m = (SOAPMethodInfo) nodoActivo.Tag;
						controlClienteSOAP dlgSOAP = new controlClienteSOAP(soap, m);
						this.MostrarDialogo(dlgSOAP);
						break;
					case "SesionSQL":
						controlClienteSQL dlgSQL = new controlClienteSQL();
						this.MostrarDialogo(dlgSQL);
						break;
					case "SesionAT":
						controlAdminTools dlgAT = new controlAdminTools((Root) nodoActivo.Parent.Tag);
						this.MostrarDialogo(dlgAT);
						break;						
					case "Operacion":
						controlOperacion dlgo = new controlOperacion(nodoActivo);
						dlgo.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgo);
						break;
					case "PreSincro":
						controlPreSincro dlgpre = new controlPreSincro(nodoActivo);
						dlgpre.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgpre);
						break;
					case "Sincro":
						controlSincro dlgsinc = new controlSincro(nodoActivo);
						dlgsinc.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgsinc);
						break;
					case "PostSincro":
						controlPostSincro dlgpost = new controlPostSincro(nodoActivo);
						dlgpost.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgpost);
						break;
					case "Complemento":
						controlComplemento dlgcpl = new controlComplemento(nodoActivo);
						dlgcpl.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgcpl);						
						break;
					case "CmdSeleccionar":
						controlCmdSeleccionar dlgcsel = new controlCmdSeleccionar(nodoActivo);
						dlgcsel.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgcsel);
						break;
					case "CmdAvisar":
						controlCmdAvisar dlgcavi = new controlCmdAvisar(nodoActivo);
						dlgcavi.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgcavi);
						break;
					case "CmdComparar":
						controlCmdComparar dlgcomp = new controlCmdComparar(nodoActivo);
						dlgcomp.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgcomp);
						break;
					case "CmdSincronizar":
						controlCmdSincronizar dlgcsinc = new controlCmdSincronizar(nodoActivo);
						dlgcsinc.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgcsinc);
						break;
					case "CmdEditar":
						controlCmdEditar dlgcedit = new controlCmdEditar(nodoActivo);
						dlgcedit.EventoCambiaEstado += CambiarEstadoDocumento;
						this.MostrarDialogo(dlgcedit);
						break;						
					case "nodosOrdenacion":
						switch((int) nodoActivo.Tag)
						{
							case (int) nodosOrdenacion.puntosAcceso:
								controlOrdenarPuntosAcceso dlgop = new controlOrdenarPuntosAcceso((QuestClient) nodoActivo.Parent.Tag, nodoActivo);
								dlgop.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgop);
								break;
							case (int) nodosOrdenacion.zonas:
								this.MostrarDialogo(null);
								if (nodoActivo.Nodes.Count == 0)
								{
									BaseOrg baseOrg = (BaseOrg) nodoActivo.Parent.Tag;
									List<Zona> zonas = new List<Zona>();
									if (nodoActivo.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
									{
										zonas = baseOrg.ObtenerZonas();
									}
									else if (nodoActivo.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
									{
										DepartamentoSIGUA depto = (DepartamentoSIGUA) nodoActivo.Parent.Parent.Tag;
										zonas = baseOrg.ObtenerZonas(depto);
									}
									else if (nodoActivo.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
									{
										ActividadSIGUA act = (ActividadSIGUA) nodoActivo.Parent.Parent.Tag;
										zonas = baseOrg.ObtenerZonas(act);
									}
									else if (nodoActivo.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
									{
										GrupoActividad gact = (GrupoActividad) nodoActivo.Parent.Parent.Tag;
										zonas = baseOrg.ObtenerZonas(gact);
									}									
									nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosZona(zonas));
								}
								break;
							case (int) nodosOrdenacion.plantasBase:
								this.MostrarDialogo(null);
								if (nodoActivo.Nodes.Count == 0)
								{
									BaseOrg baseOrg = (BaseOrg) nodoActivo.Parent.Tag;
									List<PlantaBase> plantas = new List<PlantaBase>();
									if (nodoActivo.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
									{
										plantas = baseOrg.ObtenerPlantas();
									}
									else if (nodoActivo.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
									{
										DepartamentoSIGUA depto = (DepartamentoSIGUA) nodoActivo.Parent.Parent.Tag;
										plantas = baseOrg.ObtenerPlantas(depto);
									}
									else if (nodoActivo.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
									{
										ActividadSIGUA act = (ActividadSIGUA) nodoActivo.Parent.Parent.Tag;
										plantas = baseOrg.ObtenerPlantas(act);
									}
									else if (nodoActivo.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
									{
										GrupoActividad gact = (GrupoActividad) nodoActivo.Parent.Parent.Tag;
										plantas = baseOrg.ObtenerPlantas(gact);
									}									
									nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosPlantaBase(plantas));
								}
								break;
							case (int) nodosOrdenacion.edificios:
								this.MostrarDialogo(null);
								if (nodoActivo.Nodes.Count == 0)
								{
									Zona z = (Zona) nodoActivo.Parent.Tag;
									List<Edificio> edificios = new List<Edificio>();
									if (nodoActivo.Parent.Parent.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
									{										
										edificios = z.ObtenerEdificios();
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
									{
										DepartamentoSIGUA depto = (DepartamentoSIGUA) nodoActivo.Parent.Parent.Parent.Parent.Tag;
										edificios = z.ObtenerEdificios(depto);
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
									{
										ActividadSIGUA act = (ActividadSIGUA) nodoActivo.Parent.Parent.Parent.Parent.Tag;
										edificios = z.ObtenerEdificios(act);
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
									{
										GrupoActividad gact = (GrupoActividad) nodoActivo.Parent.Parent.Parent.Parent.Tag;
										edificios = z.ObtenerEdificios(gact);
									}
									nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosEdificio(edificios));
								}
								break;
							case (int) nodosOrdenacion.plantasZona:
								this.MostrarDialogo(null);
								if (nodoActivo.Nodes.Count == 0)
								{
									Zona z = (Zona) nodoActivo.Parent.Tag;
									List<PlantaZona> plantas = new List<PlantaZona>();
									
									if (nodoActivo.Parent.Parent.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
									{
										plantas = z.ObtenerPlantas();
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
									{
										DepartamentoSIGUA depto = (DepartamentoSIGUA) nodoActivo.Parent.Parent.Parent.Parent.Tag;
										plantas = z.ObtenerPlantas(depto);
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
									{
										ActividadSIGUA act = (ActividadSIGUA) nodoActivo.Parent.Parent.Parent.Parent.Tag;
										plantas = z.ObtenerPlantas(act);
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
									{
										GrupoActividad gact = (GrupoActividad) nodoActivo.Parent.Parent.Parent.Parent.Tag;
										plantas = z.ObtenerPlantas(gact);
									}
									nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosPlantaZona(plantas));
								}								
								break;
							case (int) nodosOrdenacion.plantasEdificio:
								this.MostrarDialogo(null);
								if (nodoActivo.Nodes.Count == 0)
								{
									Edificio edif = (Edificio) nodoActivo.Parent.Tag;
									List<PlantaEdificio> plantas = new List<PlantaEdificio>();
									if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag is PuntoAcceso) //Árbol de espacios
									{
										plantas = edif.ObtenerPlantas();
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag is DepartamentoSIGUA) //Árbol de organización
									{
										DepartamentoSIGUA depto = (DepartamentoSIGUA) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag;
										plantas = edif.ObtenerPlantas(depto);
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag is ActividadSIGUA) //Árbol de actividades
									{
										ActividadSIGUA act = (ActividadSIGUA) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag;
										plantas = edif.ObtenerPlantas(act);
									}
									else if (nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag is GrupoActividad) //Árbol de grupos de actividad
									{
										GrupoActividad gact = (GrupoActividad) nodoActivo.Parent.Parent.Parent.Parent.Parent.Parent.Tag;
										plantas = edif.ObtenerPlantas(gact);
									}									
									nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosPlantaEdificio(plantas));
								}
								break;
							case (int) nodosOrdenacion.operaciones:
								controlOrdenarOperaciones dlgoo = new controlOrdenarOperaciones((DbSyncClient) nodoActivo.Parent.Tag, nodoActivo);
								dlgoo.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgoo);
								break;
							case (int) nodosOrdenacion.tareasPre:
								controlOrdenarPreSincros dlgopre = new controlOrdenarPreSincros((Operacion) nodoActivo.Parent.Tag, nodoActivo);
								dlgopre.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgopre);
								break;
							case (int) nodosOrdenacion.tareasSinc:
								controlOrdenarSincros dlgosinc = new controlOrdenarSincros((Operacion) nodoActivo.Parent.Tag, nodoActivo);
								dlgosinc.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgosinc);
								break;
							case (int) nodosOrdenacion.tareasPost:
								controlOrdenarPostSincros dlgopost = new controlOrdenarPostSincros((Operacion) nodoActivo.Parent.Tag, nodoActivo);
								dlgopost.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgopost);
								break;
							case (int) nodosOrdenacion.tareasComp:
								controlOrdenarComplementos dlgocomp = new controlOrdenarComplementos((Operacion) nodoActivo.Parent.Tag, nodoActivo);
								dlgocomp.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgocomp);
								break;
							case (int) nodosOrdenacion.comandos:
								controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
								dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
								this.MostrarDialogo(dlgocmd);
								break;
							default:
								this.MostrarDialogo(null);
								break;
						}
						break;
					default:
						this.MostrarDialogo(null);
						break;
				}
			}
			else
			{
				this.MostrarDialogo(null);
			}
		}
		
		private void TvDoc_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			e.DrawDefault = true;
			switch(e.Node.Tag.GetType().Name)
			{
				case "PuntoAcceso":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
					e.Node.ContextMenuStrip = this.mPuntoAcceso;
					break;
				case "DbSyncClient":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
					e.Node.ContextMenuStrip = this.mSesionSincro;
					break;
				case "Operacion":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Blue;
					e.Node.ContextMenuStrip = this.mOperacion;
					break;
				case "PreSincro":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Green;
					e.Node.ContextMenuStrip = this.mPreSincro;
					break;
				case "Sincro":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Red;
					e.Node.ContextMenuStrip = this.mSincro;	
					break;
				case "PostSincro":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Green;
					e.Node.ContextMenuStrip = this.mPostSincro;
					break;
				case "Complemento":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Red;
					e.Node.ContextMenuStrip = this.mComplemento;
					break;
				case "CmdSeleccionar":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Green;
					e.Node.ContextMenuStrip = this.mComando;
					break;
				case "CmdAvisar":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Green;
					e.Node.ContextMenuStrip = this.mComando;
					break;					
				case "CmdComparar":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Green;
					e.Node.ContextMenuStrip = this.mComando;
					break;
				case "CmdSincronizar":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Red;
					e.Node.ContextMenuStrip = this.mComando;
					break;
				case "CmdEditar":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Red;
					e.Node.ContextMenuStrip = this.mComando;
					break;
				case "SoapClient":
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
					e.Node.ContextMenuStrip = this.mSesionSOAP;
					break;
				case "SesionAT":
					if (Loader.Profile == ProfileType.Root && (e.Node.Parent.Tag as Root).Perfil != ProfileType.Root)
					{
						e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Red;
						e.Node.ToolTipText = "Herramientas administrativas forzadas para perfil Root";
					}
					else
					{
						e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
					}
					break;
				case "nodosOrdenacion":
					switch((int) e.Node.Tag)
					{
						case (int) nodosOrdenacion.puntosAcceso:
							e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
							e.Node.ContextMenuStrip = this.mPuntosAcceso;
							break;
						case (int) nodosOrdenacion.operaciones:
							e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
							e.Node.ContextMenuStrip = this.mOperaciones;
							break;
						case (int) nodosOrdenacion.tareasPre:
							e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Green;
							e.Node.ContextMenuStrip = this.mPreSincros;
							break;
						case (int) nodosOrdenacion.tareasSinc:
							e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Red;
							e.Node.ContextMenuStrip = this.mSincros;
							break;
						case (int) nodosOrdenacion.tareasPost:
							e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Green;
							e.Node.ContextMenuStrip = this.mPostSincros;
							break;
						case (int) nodosOrdenacion.tareasComp:
							e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Red;
							e.Node.ContextMenuStrip = this.mComplementos;
							break;
						case (int) nodosOrdenacion.comandos:
							e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
							e.Node.ContextMenuStrip = this.mComandos;
							break;
						default:
							e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
							break;
					}
					break;
				default:
					e.Node.ForeColor = e.Node.IsSelected ? Color.White : Color.Black;
					break;
			}
		}

		void MComandosOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			switch(nodoActivo.Parent.Tag.GetType().Name)
			{
				case ("PreSincro"):
					this.mitemNuevoCmdSel.Enabled=true;
					this.mitemNuevoCmdAviso.Enabled=true;
					this.mitemNuevoCmdAltas.Enabled = true;
					this.mitemNuevoCmdBajas.Enabled = true;
					this.mitemNuevoCmdDarAltas.Enabled = false;
					this.mitemNuevoCmdDarBajas.Enabled = false;
					this.mitemNuevoCmdModificar.Enabled = false;
					this.mitemNuevoCmdEdicion.Enabled = false;
					break;
				case ("Sincro"):
					this.mitemNuevoCmdSel.Enabled=false;
					this.mitemNuevoCmdAviso.Enabled=false;
					this.mitemNuevoCmdAltas.Enabled = false;
					this.mitemNuevoCmdBajas.Enabled = false;
					this.mitemNuevoCmdDarAltas.Enabled = true;
					this.mitemNuevoCmdDarBajas.Enabled = true;
					this.mitemNuevoCmdModificar.Enabled = true;
					this.mitemNuevoCmdEdicion.Enabled = false;					
					break;
				case "PostSincro":
					this.mitemNuevoCmdSel.Enabled=true;
					this.mitemNuevoCmdAviso.Enabled=true;
					this.mitemNuevoCmdAltas.Enabled = true;
					this.mitemNuevoCmdBajas.Enabled = true;
					this.mitemNuevoCmdDarAltas.Enabled = false;
					this.mitemNuevoCmdDarBajas.Enabled = false;
					this.mitemNuevoCmdModificar.Enabled = false;
					this.mitemNuevoCmdEdicion.Enabled = false;
					break;
				case "Complemento":
					this.mitemNuevoCmdSel.Enabled=false;
					this.mitemNuevoCmdAviso.Enabled=false;
					this.mitemNuevoCmdAltas.Enabled = false;
					this.mitemNuevoCmdBajas.Enabled = false;
					this.mitemNuevoCmdDarAltas.Enabled = false;
					this.mitemNuevoCmdDarBajas.Enabled = false;
					this.mitemNuevoCmdModificar.Enabled = false;
					this.mitemNuevoCmdEdicion.Enabled = true;
					break;
			}
		}
		
		void MComandoOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.mitemSimularComando.Enabled = (nodoActivo.Tag.GetType().Name == "CmdSincronizar");
		}		
		
		private bool ExistePuntoAcceso(tipoPuntoAcceso t)
		{
			bool r = false;
			QuestClient s = (QuestClient) nodoActivo.Parent.Tag;
			foreach (PuntoAcceso p in s.PuntosAcceso)
			{
				if (p.Tipo == t) r = true;
			}
			return r;
		}
		
		private void NuevoNodoPuntoAcceso(tipoPuntoAcceso t)
		{
			if (!ExistePuntoAcceso(t))
			{
				QuestClient s;
				PuntoAcceso p;
				TreeNode n;
				s = (QuestClient) nodoActivo.Parent.Tag;
				p = new PuntoAcceso();
				p.Tipo = t;
				s.PuntosAcceso.Add(p);
				n = GUIUtils.CrearNodoPuntoAcceso(p);
				nodoActivo.Nodes.Add(n);
				nodoActivo.Expand();
				estado = estadoModelo.Pendiente; 
				controlOrdenarPuntosAcceso dlgop = new controlOrdenarPuntosAcceso((QuestClient) nodoActivo.Parent.Tag, nodoActivo);
				dlgop.EventoCambiaEstado += CambiarEstadoDocumento;
				this.MostrarDialogo(dlgop);
			}
		}
		
		void MPuntosAccesoOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			foreach (tipoPuntoAcceso t in Enum.GetValues(typeof(tipoPuntoAcceso)))
			{
				if (ExistePuntoAcceso(t))
				{
					switch (t)
					{
						case (tipoPuntoAcceso.ArbolEspacial):
							this.mitemNuevoArbEspacial.Enabled = false;
							break;
						case (tipoPuntoAcceso.ArbolOrganizativo):
							this.mitemNuevoArbOrganizativo.Enabled = false;
							break;
						case (tipoPuntoAcceso.ArbolActividades):
							this.mitemNuevoArbUsos.Enabled = false;
							break;
						case (tipoPuntoAcceso.ArbolGruposActividad):
							this.mitemNuevoArbUsosG.Enabled = false;
							break;
						case (tipoPuntoAcceso.ArbolGruposActividadCRUE):
							this.mitemNuevoArbUsosGCRUE.Enabled = false;
							break;
						case (tipoPuntoAcceso.ArbolGruposActividadU21):
							this.mitemNuevoArbUsosGU21.Enabled = false;
							break;
					}
				}
			}
		}
		
		void MitemNuevoArbEspacialClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.ArbolEspacial);
		}
		
		void MitemNuevoArbUEMClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.ArbolUEM);
		}
		
		void MitemNuevoArbOrganizativoClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.ArbolOrganizativo);
		}
		
		void MitemNuevoArbUsosClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.ArbolActividades);
		}
		
		void MitemNuevoArbUsosGClick(object sender, EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.ArbolGruposActividad);
		}
		
		void MitemNuevoArbUsosGCRUEClick(object sender, EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.ArbolGruposActividadCRUE);
		}
		
		void MitemNuevoArbUsosGU21Click(object sender, EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.ArbolGruposActividadU21);
		}
		
		void MitemNuevoPAccCampusClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.Campus);
		}
		
		void MitemNuevoPAccEdificiosClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.Edificios);
		}
		
		void MitemNuevoPAccPlantasClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.Plantas);
		}
		
		void MitemNuevoPAccEstanciasClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.Estancias);
		}
		
		void MitemNuevoPAccDepartamentosClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.Departamentos);
		}		
		
		void MitemNuevoPAccUsosClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.Usos);
		}
		
		void MitemNuevoPAccPersonasClick(object sender, System.EventArgs e)
		{
			this.NuevoNodoPuntoAcceso(tipoPuntoAcceso.Personas);
		}
		
		void MitemEliminarPuntoAccesoClick(object sender, EventArgs e)
		{
			QuestClient s = (QuestClient) nodoActivo.Parent.Parent.Tag;
			PuntoAcceso p = (PuntoAcceso) nodoActivo.Tag;
			s.PuntosAcceso.Remove(p);
			this.MostrarDialogo(null);
			this.tvDoc.Nodes.Remove(nodoActivo);
		}
		
		void MitemAutoSincroClick(object sender, System.EventArgs e)
		{
			DbSyncClient modSinc;
			Secuenciador autoSinc;
			modSinc = (DbSyncClient) nodoActivo.Tag;
			autoSinc = new Secuenciador(modSinc);
			controlAutoSincro dlgas = new controlAutoSincro(autoSinc);
			this.MostrarDialogo(dlgas);
		}
		
		private void MitemNuevaOpClick(object sender, System.EventArgs e)
		{
			DbSyncClient s;
			Operacion o;
			TreeNode n;
			s = (DbSyncClient) nodoActivo.Parent.Tag;
			o = new Operacion();
			o.Nombre = s.SiguienteNombreOperacion();
			s.Operaciones.Add(o);
			n = GUIUtils.CrearNodoOperacion(o);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente; 
			controlOrdenarOperaciones dlgoo = new controlOrdenarOperaciones((DbSyncClient) nodoActivo.Parent.Tag, nodoActivo);
			dlgoo.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgoo);
		}

		void MitemEliminarOpClick(object sender, System.EventArgs e)
		{
			DbSyncClient s = (DbSyncClient) nodoActivo.Parent.Parent.Tag;
			Operacion o = (Operacion) nodoActivo.Tag;
			s.Operaciones.Remove(o);
			this.MostrarDialogo(null);
			this.tvDoc.Nodes.Remove(nodoActivo);
		}

		void MitemNuevaPreSincroClick(object sender, System.EventArgs e)
		{
			Operacion o;
			PreSincro pre;
			TreeNode n;
			o = (Operacion) nodoActivo.Parent.Tag;
			pre = new PreSincro();
			pre.Nombre = o.SiguienteNombrePreSincro();
			o.PreComprobaciones.Add(pre);
			n = GUIUtils.CrearNodoPreSincro(pre);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarPreSincros dlgopre = new controlOrdenarPreSincros((Operacion) nodoActivo.Parent.Tag, nodoActivo);
			dlgopre.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgopre);
		}
		
		void MitemEliminarPreSincroClick(object sender, System.EventArgs e)
		{
			Operacion o = (Operacion) nodoActivo.Parent.Parent.Tag;
			PreSincro pre = (PreSincro) nodoActivo.Tag;
			o.PreComprobaciones.Remove(pre);
			this.MostrarDialogo(null);
			this.tvDoc.Nodes.Remove(nodoActivo);
		}
				
		void MitemNuevaSincroClick(object sender, System.EventArgs e)
		{
			Operacion o;
			Sincro sinc;
			TreeNode n;
			o = (Operacion) nodoActivo.Parent.Tag;
			sinc = new Sincro();
			sinc.Nombre = o.SiguienteNombreSincro();
			o.Acciones.Add(sinc);
			n = GUIUtils.CrearNodoSincro(sinc);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarSincros dlgosinc = new controlOrdenarSincros((Operacion) nodoActivo.Parent.Tag, nodoActivo);
			dlgosinc.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgosinc);
		}
		
		void MitemEliminarSincroClick(object sender, System.EventArgs e)
		{
			Operacion o = (Operacion) nodoActivo.Parent.Parent.Tag;
			Sincro sinc = (Sincro) nodoActivo.Tag;
			o.Acciones.Remove(sinc);
			this.MostrarDialogo(null);
			this.tvDoc.Nodes.Remove(nodoActivo);
		}		
		
		void MitemNuevaPostSincroClick(object sender, System.EventArgs e)
		{
			Operacion o;
			PostSincro post;
			TreeNode n;
			o = (Operacion) nodoActivo.Parent.Tag;
			post = new PostSincro();
			post.Nombre = o.SiguienteNombrePostSincro();
			o.PostComprobaciones.Add(post);
			n = GUIUtils.CrearNodoPostSincro(post);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarPostSincros dlgopost = new controlOrdenarPostSincros((Operacion) nodoActivo.Parent.Tag, nodoActivo);
			dlgopost.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgopost);
		}
		
		void MitemEliminarPostSincroClick(object sender, System.EventArgs e)
		{
			Operacion o = (Operacion) nodoActivo.Parent.Parent.Tag;
			PostSincro post = (PostSincro) nodoActivo.Tag;
			o.PostComprobaciones.Remove(post);
			this.MostrarDialogo(null);
			this.tvDoc.Nodes.Remove(nodoActivo);
		}		
		
		void MNuevoComplementoClick(object sender, System.EventArgs e)
		{
			Operacion o;
			Complemento comp;
			TreeNode n;
			o = (Operacion) nodoActivo.Parent.Tag;
			comp = new Complemento();
			comp.Nombre = o.SiguienteNombreComplemento();
			o.Complementos.Add(comp);
			n = GUIUtils.CrearNodoComplemento(comp);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComplementos dlgocomp = new controlOrdenarComplementos((Operacion) nodoActivo.Parent.Tag, nodoActivo);
			dlgocomp.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocomp);
		}
		
		void MitemEliminarComplementoClick(object sender, System.EventArgs e)
		{
			Operacion o = (Operacion) nodoActivo.Parent.Parent.Tag;
			Complemento comp = (Complemento) nodoActivo.Tag;
			o.Complementos.Remove(comp);
			this.MostrarDialogo(null);
			this.tvDoc.Nodes.Remove(nodoActivo);
		}

		void MitemNuevoCmdSelClick(object sender, System.EventArgs e)
		{
			Tarea t;
			CmdSeleccionar cmdsel;
			TreeNode n;
			t = (Tarea) nodoActivo.Parent.Tag;
			cmdsel = new CmdSeleccionar();
			cmdsel.Nombre = t.SiguienteNombreComando();
			cmdsel.Tipo = tipoComando.Seleccion;
			t.Comandos.Add(cmdsel);
			n = GUIUtils.CrearNodoComando(cmdsel);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
			dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocmd);
		}
		
		void MitemNuevoCmdAvisoClick(object sender, System.EventArgs e)
		{
			Tarea t;
			CmdAvisar cmdavi;
			TreeNode n;
			t = (Tarea) nodoActivo.Parent.Tag;
			cmdavi = new CmdAvisar();
			cmdavi.Nombre = t.SiguienteNombreComando();
			cmdavi.Tipo = tipoComando.Aviso;
			t.Comandos.Add(cmdavi);
			n = GUIUtils.CrearNodoComando(cmdavi);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
			dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocmd);
		}
		
		void MitemNuevoCmdAltasClick(object sender, System.EventArgs e)
		{
			Tarea t;
			CmdComparar cmdalt;
			TreeNode n;
			t = (Tarea) nodoActivo.Parent.Tag;
			cmdalt = new CmdComparar();
			cmdalt.Nombre = t.SiguienteNombreComando();
			cmdalt.Tipo = tipoComando.VerAltas;
			cmdalt.Direccion = TipoComprobacion.AltasPendientesEnSIGUA;
			t.Comandos.Add(cmdalt);
			n = GUIUtils.CrearNodoComando(cmdalt);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
			dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocmd);			
		}
		
		void MitemNuevoCmdBajasClick(object sender, System.EventArgs e)
		{
			Tarea t;
			CmdComparar cmdbaj;
			TreeNode n;
			t = (Tarea) nodoActivo.Parent.Tag;
			cmdbaj = new CmdComparar();
			cmdbaj.Nombre = t.SiguienteNombreComando();
			cmdbaj.Tipo = tipoComando.VerBajas;
			cmdbaj.Direccion = TipoComprobacion.BajasPendientesEnSIGUA;
			t.Comandos.Add(cmdbaj);
			n = GUIUtils.CrearNodoComando(cmdbaj);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
			dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocmd);
		}
		
		void MitemNuevoCmdDarAltasClick(object sender, System.EventArgs e)
		{
			Tarea t;
			CmdSincronizar cmdsincalt;
			TreeNode n;
			t = (Tarea) nodoActivo.Parent.Tag;
			cmdsincalt = new CmdSincronizar();
			cmdsincalt.Nombre = t.SiguienteNombreComando();
			cmdsincalt.Tipo = tipoComando.DarAltas;
			cmdsincalt.Direccion = TipoComprobacion.AltasPendientesEnSIGUA;
			t.Comandos.Add(cmdsincalt);
			n = GUIUtils.CrearNodoComando(cmdsincalt);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
			dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocmd);			
		}
		
		void MitemNuevoCmdDarBajasClick(object sender, System.EventArgs e)
		{
			Tarea t;
			CmdSincronizar cmdsincbaj;
			TreeNode n;
			t = (Tarea) nodoActivo.Parent.Tag;
			cmdsincbaj = new CmdSincronizar();
			cmdsincbaj.Nombre = t.SiguienteNombreComando();
			cmdsincbaj.Tipo = tipoComando.DarBajas;
			cmdsincbaj.Direccion = TipoComprobacion.BajasPendientesEnSIGUA;
			t.Comandos.Add(cmdsincbaj);
			n = GUIUtils.CrearNodoComando(cmdsincbaj);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
			dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocmd);			
		}
		
		void MitemNuevoCmdModificarClick(object sender, System.EventArgs e)
		{
			Tarea t;
			CmdSincronizar cmdsincmodif;
			TreeNode n;
			t = (Tarea) nodoActivo.Parent.Tag;
			cmdsincmodif = new CmdSincronizar();
			cmdsincmodif.Nombre = t.SiguienteNombreComando();
			cmdsincmodif.Tipo = tipoComando.Modificar;
			cmdsincmodif.Direccion = TipoComprobacion.ModificacionesPendientesEnSIGUA;
			t.Comandos.Add(cmdsincmodif);
			n = GUIUtils.CrearNodoComando(cmdsincmodif);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
			dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocmd);			
		}		

		void MitemNuevoCmdEdicionClick(object sender, System.EventArgs e)
		{
			Tarea t;
			CmdEditar cmdedit;
			TreeNode n;
			t = (Tarea) nodoActivo.Parent.Tag;
			cmdedit = new CmdEditar();
			cmdedit.Nombre = t.SiguienteNombreComando();
			cmdedit.Tipo = tipoComando.Editar;
			t.Comandos.Add(cmdedit);
			n = GUIUtils.CrearNodoComando(cmdedit);
			nodoActivo.Nodes.Add(n);
			nodoActivo.Expand();
			estado = estadoModelo.Pendiente;
			controlOrdenarComandos dlgocmd = new controlOrdenarComandos((Tarea) nodoActivo.Parent.Tag, nodoActivo);
			dlgocmd.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgocmd);			
		}
		
		void MitemEliminarComandoClick(object sender, System.EventArgs e)
		{
			Tarea t = (Tarea) nodoActivo.Parent.Parent.Tag;
			Comando cmd = (Comando) nodoActivo.Tag;
			t.Comandos.Remove(cmd);
			this.MostrarDialogo(null);
			this.tvDoc.Nodes.Remove(nodoActivo);
		}
		
		void MitemSimularComandoClick(object sender, System.EventArgs e)
		{
			Form w;
			switch(nodoActivo.Tag.GetType().Name)
			{
				case "CmdSeleccionar":
					//Do nothing
					break;
				case "CmdAvisar":
					//Do nothing
					break;
				case "CmdComparar":
					//Do nothing
					break;
				case "CmdSincronizar":
					CmdSincronizar csinc = (CmdSincronizar) nodoActivo.Tag;
					w = new frmDatos(csinc.Simular(), string.Format("Incidencias que se producirán al {0}", csinc.Descripcion));
					w.Show(this);
					break;
				case "CmdEditar":
					//Do nothing
					break;					
				default:
					break;
			}
		}			
				

		void MitemEjecutarComandoClick(object sender, System.EventArgs e)
		{
			Form w;
			Form w2;
			switch(nodoActivo.Tag.GetType().Name)
			{
				case "CmdSeleccionar":
					CmdSeleccionar csel = (CmdSeleccionar) nodoActivo.Tag;
					w = new frmDatos(csel.ObtenerDatos(), csel.Descripcion);
					w.Show(this);
					break;
				case "CmdAvisar":
					CmdAvisar cavi = (CmdAvisar) nodoActivo.Tag;
					w = new frmDatos(cavi.ObtenerDatos(), cavi.Descripcion);
					w.Show(this);
					break;
				case "CmdComparar":
					CmdComparar ccomp = (CmdComparar) nodoActivo.Tag;
					w = new frmDatos(ccomp.ObtenerDatos(), ccomp.Descripcion);
					w.Show(this);
					break;
				case "CmdSincronizar":
					CmdSincronizar csinc = (CmdSincronizar) nodoActivo.Tag;
					w = new frmAfectados(csinc.ObtenerDatos(), string.Format("Registros que serán afectados al {0}", csinc.Descripcion));
					//Diálogo modal para confirmar sincronización
					w.ShowDialog(this);
					if (w.DialogResult == DialogResult.OK)
					{
						w2 = new frmDatos(csinc.Sincronizar(), string.Format("Resultado del comando {0}", csinc.Descripcion));
						w2.ShowDialog(this);
					}
					break;
				case "CmdEditar":
					CmdEditar cedit = (CmdEditar) nodoActivo.Tag;
					w = new frmEdicion(cedit.ObtenerDatos(), cedit.Descripcion);
					//Diálogo modal para confirmar actualización
					w.ShowDialog(this);
					if (w.DialogResult == DialogResult.OK)
					{
						w2 = new frmDatos(cedit.Actualizar(), string.Format("Resultado del comando {0}", cedit.Descripcion));
						w2.ShowDialog(this);
					}
					break;					
				default:
					break;
			}
		}
		
		void MitemIniciarSOAPClick(object sender, System.EventArgs e)
		{
			nodoActivo.Nodes.Clear();
			this.MostrarDialogo(null);
			SoapClient sesSOAP = (SoapClient) nodoActivo.Tag;
			try
			{
				sesSOAP.IniciarSesion(true);
			}
			catch
			{
				sesSOAP.IniciarSesion(false);
				MessageBox.Show("No pudo iniciarse la sesión con el documento de configuración de interfaz de usuario (WSUI) especificado", "Inicio de sesión SOAP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
			controlSesionSOAP dlgsep = new controlSesionSOAP(nodoActivo, GUISettings.UseSOAPGroups);
			dlgsep.EventoCambiaEstado += CambiarEstadoDocumento;
			this.MostrarDialogo(dlgsep);
			this.nodoActivo.Nodes.AddRange(GUIUtils.CrearNodosSOAPMethodInfo(sesSOAP.ServiceInfo, true));
		}
		
		void MitemTestSOAPClick(object sender, System.EventArgs e)
		{
			Form w = new frmTestSOAP((nodoActivo.Tag as SoapClient).ServiceInfo);
			w.ShowDialog(this);
		}
		
		private void MitemNuevoClick(object sender, System.EventArgs e)
		{
			DialogResult r;
			if (estado == estadoModelo.Pendiente)
			{
				r = MessageBox.Show("¿Guardar la configuración actual de SIGUANETDesktop?", 
				                    "Guardar cambios", 
	                                MessageBoxButtons.YesNoCancel, 
	                                MessageBoxIcon.Question, 
	                                MessageBoxDefaultButton.Button1);
				switch (r)
				{
				case DialogResult.Yes:
					if (this.Guardar() == true)
					{
						this.tvDoc.Nodes.Clear();
						this.tvDoc.Nodes.Add(GUIUtils.CrearNodoRoot());
						estado = estadoModelo.Nuevo;
						this.MostrarDialogo(null);
						ficheroActivo = string.Empty;
					}
					break;
				case DialogResult.No:
					this.tvDoc.Nodes.Clear();
					this.tvDoc.Nodes.Add(GUIUtils.CrearNodoRoot());
					estado = estadoModelo.Nuevo;
					this.MostrarDialogo(null);
					ficheroActivo = string.Empty;
					break;
				case DialogResult.Cancel:
					break;
				}
			}	
			else
			{
				this.tvDoc.Nodes.Clear();
				this.tvDoc.Nodes.Add(GUIUtils.CrearNodoRoot());
				estado = estadoModelo.Nuevo;
				this.MostrarDialogo(null);
				ficheroActivo = string.Empty;
			}
		}
		
		private void MitemAbrirClick(object sender, System.EventArgs e)
		{
			DialogResult r;
			bool abrir = true;
			this.dlgAbrir.Title = "Abrir documento SIGUANETDesktop";
			this.dlgAbrir.AddExtension = true;
			this.dlgAbrir.DefaultExt = "sgd";
			this.dlgAbrir.Filter = "Documentos SIGUANETDesktop SGD (*.sgd)|*.sgd";
			this.dlgAbrir.FileName = string.Empty;
			
			if (estado == estadoModelo.Pendiente)
			{
				r = MessageBox.Show("¿Guardar el documento SIGUANETDesktop actual?", 
				                    "Guardar cambios", 
	                                MessageBoxButtons.YesNoCancel, 
	                                MessageBoxIcon.Question, 
	                                MessageBoxDefaultButton.Button1);
				switch (r)
				{
				case DialogResult.Yes:
					abrir = this.Guardar();
					break;
				case DialogResult.No:
					break;
				case DialogResult.Cancel:
					abrir = false;
					break;
				}
			}
			
			if (abrir)
			{
				if ((this.dlgAbrir.ShowDialog() == DialogResult.OK) && (this.dlgAbrir.FileName != string.Empty))
				{
					Root doc = (Root) XMLUtils.DeserializarDocumento(this.dlgAbrir.FileName, string.Empty, string.Empty, typeof(Root));
					this.tvDoc.Nodes.Clear();
					this.tvDoc.Nodes.Add(GUIUtils.CrearNodoRoot(doc, (Loader.Profile == ProfileType.Root && doc.Perfil != ProfileType.Root)));
					this.estado = estadoModelo.Actualizado;
					this.MostrarDialogo(null);
					this.ficheroActivo = this.dlgAbrir.FileName;
				}				
			}
		}
		
		private void MitemGuardarClick(object sender, System.EventArgs e)
		{
			if (this.Guardar() == true) estado = estadoModelo.Actualizado;
		}
		
		private void MitemGuardarComoClick(object sender, System.EventArgs e)
		{
			if (this.GuardarComo() == true) estado = estadoModelo.Actualizado;
		}
		
		private bool Guardar()
		{
			if (this.ficheroActivo != string.Empty)
			{
				Root r = (Root) this.tvDoc.Nodes.Find("SIGUANETDesktop", false)[0].Tag;
				r.Serializar(this.ficheroActivo);
				return true;
			}
			else
			{
				return this.GuardarComo();
			}
		}
		
		private bool GuardarComo()
		{
			this.dlgGuardarComo.Title = "Guardar documento SIGUANETDesktop";
			this.dlgGuardarComo.AddExtension = true;
			this.dlgGuardarComo.DefaultExt = "sgd";
			this.dlgGuardarComo.Filter = "Documentos SIGUANETDesktop SGD (*.sgd)|*.sgd";
			if ((this.dlgGuardarComo.ShowDialog() == DialogResult.OK) && (this.dlgGuardarComo.FileName != string.Empty))
			{
				Root r = (Root) this.tvDoc.Nodes.Find("SIGUANETDesktop", false)[0].Tag;
				string destino = this.dlgGuardarComo.FileName;
				r.Serializar(destino);
				if (this.ficheroActivo == string.Empty)
				{
					ficheroActivo = destino;
				}
				return true;
			}
			else
			{
				return false;
			}
		}
		
		private void MitemSalirClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		private void MainFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DialogResult r;
			e.Cancel = false;
			if (estado == estadoModelo.Pendiente)
			{
				r = MessageBox.Show("¿Guardar la configuración actual de SIGUANETDesktop?", 
				                    "Guardar cambios", 
	                                MessageBoxButtons.YesNoCancel, 
	                                MessageBoxIcon.Question, 
	                                MessageBoxDefaultButton.Button1);
				switch (r)
				{
					case (DialogResult.Yes) :
						if (this.Guardar() == false) e.Cancel = true;
						break;
					case (DialogResult.No) :
						break;
					case (DialogResult.Cancel) :
						e.Cancel = true;
						break;
				}
			}
		}
		
		void MitemPerfilClick(object sender, EventArgs e)
		{
			this.Opacity = 0.8;
			if (Loader.CanImpersonate)
			{
				frmSuplantacion dlgImpers = new frmSuplantacion();
				dlgImpers.ShowDialog();
				if (dlgImpers.UsarDefault)
				{
					Loader.Unimpersonate();
				}
				else
					
				{
					Loader.Impersonate(dlgImpers.Perfil, dlgImpers.PerfilPersonalizado);
				}
			}
			this.Open();
			this.Opacity = 1.0;
		}
		
		void MitemPGSQLClick(object sender, System.EventArgs e)
		{
			frmConexionPGSQL w = new frmConexionPGSQL();
			DialogResult r = w.ShowDialog();
			if (r == DialogResult.OK)
			{
				DBUtils.TestConnection(dbOrigen.PGSQL);
			}
		}
		
		void MitemORAClick(object sender, System.EventArgs e)
		{
			frmConexionORA w = new frmConexionORA();
			DialogResult r = w.ShowDialog();
			if (r == DialogResult.OK)
			{
				DBUtils.TestConnection(dbOrigen.ORA);
			}
		}
		
		void MitemSOAPClick(object sender, System.EventArgs e)
		{
			frmConexionSOAP w = new frmConexionSOAP();
			DialogResult r = w.ShowDialog();
		}
		
		void MitemVEsquemasBDClick(object sender, EventArgs e)
		{
			frmEsquemaBD w = new frmEsquemaBD();
			w.Show(this);
		}
		
		void MitemOpcionesClick(object sender, System.EventArgs e)
		{
			frmPreferencias w = new frmPreferencias();
			w.ShowDialog(this);
		}
		
		void MitemVSucesosClick(object sender, EventArgs e)
		{
			this._visorSucesos.Show(this);
		}
		
		void MitemAboutClick(object sender, EventArgs e)
		{
			frmAboutBox w = new frmAboutBox();
			w.ShowDialog(this);
		}		
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			//Liberamos los recursos de la instancia única del visor de sucesos
			this._visorSucesos.Close();
			this._visorSucesos.Dispose();
		}
	}
}
