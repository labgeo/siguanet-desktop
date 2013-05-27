/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/07/2006
 * Time: 13:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using SIGUANETDesktop.ModeloExplotacion;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Organizacion;
using SIGUANETDesktop.ModeloExplotacion.Usos;
using SIGUANETDesktop.ModeloExplotacion.Personas;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Utilidades;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlPropiedadesUGE.
	/// </summary>
	public partial class controlPropiedadesUGE
	{
		protected ListViewItem _lviWait = new ListViewItem(new string[2] {"Procesando. Espere, por favor...", ""}, null,
		                                                   System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.InactiveCaptionText),
														   System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.InactiveCaption),
														   new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Bold));
		
		private PuntoAcceso _puntoAcceso = null;
		private IUnidadGeoEstadistica _uge = null;
		private object _restriccion = null;
		
		public controlPropiedadesUGE(PuntoAcceso puntoAcceso, IUnidadGeoEstadistica uge, object restriccion)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this._puntoAcceso = puntoAcceso;
			this._uge = uge;
			this._restriccion = restriccion;
			this.lstPropiedades.SmallImageList = this.lstPropiedades.LargeImageList = this.imageList1;
			this.lstPropiedades.ShowItemToolTips = true;
			this.lstPropiedades.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.InactiveCaption);
			this.lstPropiedades.Items.Add(_lviWait);
		}
		// TODO: Debemos extraer todo el código relacionado con reflexión de tipos
		// a una clase específica o integrarlo en las clases PropiedadEscalar y PaginaPropiedades
		// para que quede separado del interfaz de usuario
		public void MostrarPaginaPropiedades()
		{
			this.pgPropiedades.Value = 0;
			this.pgPropiedades.Maximum = this._puntoAcceso.Propiedades.Items.Count;
			foreach (string g in Enum.GetNames(typeof(PropiedadEscalar.TipoGrupo)))
			{
				ListViewGroup lvg = new ListViewGroup(g, HorizontalAlignment.Left);
				lvg.Name = g;
				this.lstPropiedades.Groups.Add(lvg);
			}			
			foreach (PropiedadEscalar prop in this._puntoAcceso.Propiedades.Items)
			{
				if (prop.Accion != PropiedadEscalar.TipoComportamiento.Deshabilitado)
				{
					object oVal = null;
					string sVal = prop.ValorDefectoEscalar;
					bool classMatch = false;
					bool methodFound = false;
					try
					{
						Type tipo = Type.GetType(prop.Clase, true, true);
						//IsInstanceOfType permite comprobar la compatibilidad 
						//(pertenencia o herencia) del
						//objeto _uge con el tipo (interfaz o clase) especificado
						if (tipo.IsInstanceOfType(this._uge))
						{
							classMatch = true;
							MethodInfo[] methods = tipo.GetMethods();
							foreach (MethodInfo m in methods)
							{
								if (m.Name.ToUpper() == prop.MetodoEscalar.Trim().ToUpper())
								{
									int nparams = m.GetParameters().Length;
									if (this._restriccion == null)
									{
										if (nparams == 0)
										{
											oVal = m.Invoke(this._uge, null);
											methodFound = true;
											break;
										}
									}
									else
									{
										if (nparams == 1)
										{
											ParameterInfo p = m.GetParameters()[0];
											//¡IMPORTANTE! Comparar con el tipo principal y con el tipo base
											//puesto que pueden existir métodos donde la restricción haga referencia
											//a una clase abstracta (i.e. GrupoActividad)
											if (p.ParameterType == this._restriccion.GetType()
											    || p.ParameterType == this._restriccion.GetType().BaseType)
											{
												oVal = m.Invoke(this._uge, new object[] {this._restriccion});
												methodFound = true;
												break;
											}
										}
									}
								}
							}
							if (!methodFound)
							{
								throw new Exception(string.Format("No se encontró el método {0}() en la clase {1}", prop.MetodoEscalar, prop.Clase));
							}
							else if (oVal is Int16)
							{
								Int16 shortVal = (Int16) oVal;
								sVal = shortVal.ToString(prop.FormatoEscalar);
							}
							else if (oVal is Int32)
							{
								Int32 intVal = (Int32) oVal;
								sVal = intVal.ToString(prop.FormatoEscalar);
							}
							else if (oVal is Int64)
							{
								Int64 longVal = (Int64) oVal;
								sVal = longVal.ToString(prop.FormatoEscalar);
							}
							else if (oVal is Single)
							{
								Single singleVal = (Single) oVal;
								sVal = singleVal.ToString(prop.FormatoEscalar);
							}							
							else if (oVal is Double)
							{
								Double doubleVal = (Double) oVal;
								sVal = doubleVal.ToString(prop.FormatoEscalar);
							}
							else
							{
								sVal = Convert.ToString(oVal);
							}
						}
						if (prop.FormatoCadena != string.Empty)
						{
							sVal = string.Format(prop.FormatoCadena, sVal);
						}
					}
					catch (Exception e)
					{
						sVal = e.Message;
					}
					finally
					{
						if (classMatch)
						{
							ListViewItem lvi = new ListViewItem(new string[2] {prop.Titulo, sVal});
							lvi.Tag = prop;
							switch (prop.Accion)
							{
								case PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_y_Datos:
									lvi.ImageKey = "Tabla.gif";
									lvi.ToolTipText = string.Format("{0}. Pulse para ver datos.", prop.Descripcion);
									break;
								case PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_Cartografia_y_Datos:
									lvi.ImageKey = "Layers.gif";
									lvi.ToolTipText = string.Format("{0}. Pulse para ver cartografía y datos.", prop.Descripcion);
									break;
								case PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_y_Cartografia:
									lvi.ImageKey = "Layers.gif";
									lvi.ToolTipText = string.Format("{0}. Pulse para ver cartografía.", prop.Descripcion);
									break;									
								default:
									lvi.ToolTipText = prop.Descripcion;
									break;
							}
							this.lstPropiedades.Items.Add(lvi);
							
							lvi.Group = this.lstPropiedades.Groups[Enum.GetName(typeof(PropiedadEscalar.TipoGrupo), prop.Grupo)];
						}
					}
				}
				this.pgPropiedades.Value += 1;
			}
			this.lstPropiedades.Items.Remove(_lviWait);
			this.lstPropiedades.BackColor =	System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Window);
		}

 		public void itemSeleccionado (object sender, EventArgs e)
		{
 			try
 			{
 				this.Cursor = Cursors.WaitCursor;
	 			PropiedadEscalar prop = (PropiedadEscalar) this.lstPropiedades.SelectedItems[0].Tag;
	 			object[] args = null;
	 			object result = null;
	 			bool methodFound = false;
	 			frmArbolMapa formM = null;
	 			frmArbolDatos formD = null;
	 			
	 			Type tipo = Type.GetType(prop.Clase, true, true);
	 			//IsInstanceOfType permite comprobar la compatibilidad 
				//(pertenencia o herencia) del
				//objeto _uge con el tipo (interfaz o clase) especificado
				if (tipo.IsInstanceOfType(this._uge))
				{
		 			switch (prop.Accion)
		 			{
		 				case PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_y_Cartografia:
		 					formM = new frmArbolMapa(null, null, prop.TituloDataSet, this._uge);
		 					break;
		 				case PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_y_Datos:
		 				case PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_Cartografia_y_Datos:
							MethodInfo[] methods = tipo.GetMethods();
							foreach (MethodInfo m in methods)
							{
								if (m.Name.ToUpper() == prop.MetodoDataSet.Trim().ToUpper())
								{
									int nparams = m.GetParameters().Length;
									if (this._restriccion == null)
									{
										if (nparams == 1)
										{
											ParameterInfo p = m.GetParameters()[0];
											if ((p.IsOut) && (p.ParameterType.Name == "DataSet&"))
											{
												args = new object[] {null};
												result = m.Invoke(this._uge, args);
												methodFound = true;
												break;
											}
										}
									}
									else
									{
										if (nparams == 2)
										{
											ParameterInfo pDataSet = m.GetParameters()[0];
											ParameterInfo pRestriccion = m.GetParameters()[1];
											if ((pDataSet.IsOut) && (pDataSet.ParameterType.Name == "DataSet&"))
											{
												//¡IMPORTANTE! Comparar con el tipo principal y con el tipo base
												//puesto que pueden existir métodos donde la restricción haga referencia
												//a una clase abstracta (i.e. GrupoActividad)												
												if (pRestriccion.ParameterType == this._restriccion.GetType()
												    || pRestriccion.ParameterType == this._restriccion.GetType().BaseType)
												{
													args = new object[] {null, this._restriccion};
													result = m.Invoke(this._uge, args);
													methodFound = true;
													break;
												}
											}
										}
									}
								}
							}
							if (!methodFound)
							{
								throw new Exception(string.Format("No se encontró el método {0}(out DataSet ds) en la clase {1}", prop.MetodoDataSet, prop.Clase));
							}
							else
							{
								string titulo = prop.TituloDataSet;
								if (this._restriccion != null)
								{
									if (this._restriccion is DepartamentoSIGUA)
									{
										titulo = string.Format(prop.TituloDataSet, (this._restriccion as DepartamentoSIGUA).Denominacion);
									}
									if (this._restriccion is ActividadSIGUA)
									{
										titulo = string.Format(prop.TituloDataSet, (this._restriccion as ActividadSIGUA).Denominacion);
									}
									if (this._restriccion is GrupoActividad)
									{
										titulo = string.Format(prop.TituloDataSet, (this._restriccion as GrupoActividad).DenominacionAlt);
									}									
								}
								if (result is List<Estancia>)
								{
									if (prop.Accion == PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_y_Datos)
									{
										formD = new frmArbolDatos((List<Estancia>) result, (DataSet) args[0], titulo, this._uge);
									}
									else if (prop.Accion == PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_Cartografia_y_Datos)
									{
										formM = new frmArbolMapa((List<Estancia>) result, (DataSet) args[0], titulo, this._uge);
									}
								}
								else if (result is List<Ubicacion>)
								{
									if (prop.Accion == PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_y_Datos)
									{
										formD = new frmArbolDatos((List<Ubicacion>) result, (DataSet) args[0], titulo, this._uge);
									}
									else if (prop.Accion == PropiedadEscalar.TipoComportamiento.Mostrar_Escalar_Cartografia_y_Datos)
									{
										formM = new frmArbolMapa((List<Ubicacion>) result, (DataSet) args[0], titulo, this._uge);
									}
								}
								else
								{
									throw new Exception(string.Format("El método {0}(out DataSet ds) de la clase {1} no devolvió un resultado compatible con el módulo de destino. El tipo devuelto es {2}", prop.MetodoDataSet, prop.Clase, result.GetType().Name));
								}
							}
		 					break;
		 				default:
		 					break;
		 			}
					if (formD != null)
					{
						formD.EventoInicioModulo += this.IndicarInicioModulo;
						formD.EventoPasoModulo += this.IndicarProgresoModulo;
						formD.CargarDatos();
						formD.Show();								
					}		 			
					if (formM != null)
					{
						formM.EventoInicioModulo += this.IndicarInicioModulo;
						formM.EventoPasoModulo += this.IndicarProgresoModulo;
						formM.CargarDatos();
						formM.Show();								
					}		 			
				}
				else
				{
					throw new Exception(string.Format("La clase {0} no es compatible con la clase {1}", prop.Clase, this._uge.GetType().FullName));
				}
 			}
 			catch (Exception ex)
 			{
 				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 			}
 			finally
 			{
 				this.Cursor = Cursors.Default;
 			}
 		}
 		
 		private void IndicarInicioModulo(int totalPasos)
 		{
 			this.pgPropiedades.Value = 0;
 			this.pgPropiedades.Maximum = totalPasos;
 		}
 		
 		private void IndicarProgresoModulo(int numPasos)
 		{
 			this.pgPropiedades.Value += 1;
 		} 		
	}
}
