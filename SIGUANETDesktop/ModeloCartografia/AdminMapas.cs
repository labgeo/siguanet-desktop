/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/10/2006
 * Time: 8:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using SharpMap;
using SharpMap.Geometries;
using SharpMap.Layers;
using SharpMap.Rendering.Thematics;
using SharpMap.Styles;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloExplotacion.Espacios;
using SIGUANETDesktop.ModeloExplotacion.Utilidades;
using SIGUANETDesktop.DB;
using SIGUANETDesktop.ModeloCartografia.Simbologia;

namespace SIGUANETDesktop.ModeloCartografia
{
	/// <summary>
	/// Description of MapManager.
	/// </summary>
	public static class AdminMapas
	{

		public enum TipoMapa
		{
			Predeterminado,
			TemaUso,
			TemaAdscripcion
		}
		
		private const string NOMCAPA_CENTROIDES = "CENTROIDS";
		private const string NOMCAPA_CONSULTA = "QUERY";
		private const string NOMCAPA_INFO = "IDENTIFY";
		private const string NOMCAPA_ETIQUETAS = "LABELS";
		
		private static TipoPaleta _paleta;

		private static VectorLayer _capaTemaUsos;
		private static EntradaLeyendaTematica _entradaTemaUsos;
		private enum ResumActividad
		{
			Accesos,
			Administracion,
			Aseos,
			Biblioteca,
			Comunes,
			Conserjeria,
			Despachos,
			Docencia,
			Seminarios,
			Informatica,
			Laboratorios,
			Salas,
			Varios
		}
		
		private class GrupoActividad
		{
			public ResumActividad Tipo;
			public SimbBase Simbologia;
			public short[] Actividades;
			
			public GrupoActividad(ResumActividad tipo, SimbBase simbologia, short[] actividades)
			{
				Tipo = tipo;
				Simbologia = simbologia;
				Actividades = actividades;
			}
		}
		
		private struct GruposActividad
		{
			public static GrupoActividad[] Items = new GrupoActividad[]
			{
				new GrupoActividad(ResumActividad.Accesos, new SimbAccesos(), new short[] {80, 81, 91, 92, 94, 95, 96, 97, 98}),
				new GrupoActividad(ResumActividad.Administracion, new SimbAdministracion(), new short[] {8, 10}),
				new GrupoActividad(ResumActividad.Aseos, new SimbAseos(), new short[] {20}),
				new GrupoActividad(ResumActividad.Biblioteca, new SimbBiblioteca(), new short[] {9}),
				new GrupoActividad(ResumActividad.Comunes, new SimbComunes(), new short[] {100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114}),
				new GrupoActividad(ResumActividad.Conserjeria, new SimbConserjeria(), new short[] {16}),
				new GrupoActividad(ResumActividad.Despachos, new SimbDespachos(), new short[] {7}),
				new GrupoActividad(ResumActividad.Docencia, new SimbDocencia(), new short[] {1, 2, 3, 26}),
				new GrupoActividad(ResumActividad.Seminarios, new SimbSeminarios(), new short[] {15}),
				new GrupoActividad(ResumActividad.Informatica, new SimbInformatica(), new short[] {6, 22}),
				new GrupoActividad(ResumActividad.Laboratorios, new SimbLaboratorios(), new short[] {4, 5}),
				new GrupoActividad(ResumActividad.Salas, new SimbSalas(), new short[] {12, 13, 14, 27, 28}),
				new GrupoActividad(ResumActividad.Varios, new SimbVarios(), new short[] {0, 11, 17, 18, 19, 21, 50, 99})
			};
		}
		
		private static VectorLayer _capaTemaAdsc;
		private static EntradaLeyendaTematica _entradaTemaAdsc;
		
		private static DataSet _dsTemas;

		
		private static VectorStyle ObtenerEstilo(TipoPaleta paleta, SimbBase simb)
     	{
			VectorStyle vs = new VectorStyle();
	     	switch(paleta)
	     	{
	     		case (TipoPaleta.predeterminada):
	     			vs.EnableOutline = simb.contorno;
					vs.Outline = new Pen(simb.color_ColorContorno, simb.width);

					switch (simb.color_TipoRelleno)
					{
						case (TipoRelleno.solido):
							vs.Fill = new SolidBrush(simb.color_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							vs.Fill = new HatchBrush(simb.color_Trama, simb.color_ColorTrama, simb.color_ColorTramaFondo);
							break;
					}
					break;
				case (TipoPaleta.tramado):
					vs.EnableOutline = simb.contorno;
					vs.Outline = new Pen(simb.print_ColorContorno, simb.width);
					switch (simb.print_TipoRelleno)
					{
						case (TipoRelleno.solido):
							vs.Fill = new SolidBrush(simb.print_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							vs.Fill = new HatchBrush(simb.print_Trama, simb.print_ColorTrama, simb.print_ColorTramaFondo);
							break;
					}
					break;
				default:
	     			vs.EnableOutline = simb.contorno;
					vs.Outline = new Pen(simb.color_ColorContorno, simb.width);

					switch (simb.color_TipoRelleno)
					{
						case (TipoRelleno.solido):
							vs.Fill = new SolidBrush(simb.color_ColorRelleno);
							break;
						case (TipoRelleno.trama):
							vs.Fill = new HatchBrush(simb.color_Trama, simb.color_ColorTrama, simb.color_ColorTramaFondo);
							break;
					}					
					break;
	     	}
	     	return vs;
		}
		
		private static void NuevaEntradaLeyendaBD(string uid, VectorLayer capa, string titulo)
		{
			EntradaLeyendaBD el = new EntradaLeyendaBD(uid, capa, titulo);
			_leyenda.AgregarEntrada(el);
		}
		
		private static void AsignarEntradaLeyendaConsulta(string uid, VectorLayer capa, string titulo)
		{
			EntradaLeyendaConsulta el = new EntradaLeyendaConsulta(uid, capa, titulo);
			_leyenda.EntradaConsulta = el;
		}
		
		private static void AsignarEntradaLeyendaSeleccion(string uid, VectorLayer capa, string titulo)
		{
			EntradaLeyendaSeleccion el = new EntradaLeyendaSeleccion(uid, capa, titulo);
			_leyenda.EntradaSeleccion = el;
		}
		
		private static void AsignarEntradaLeyendaInformacion(string uid, VectorLayer capa, string titulo)
		{
			EntradaLeyendaInformacion el = new EntradaLeyendaInformacion(uid, capa, titulo);
			_leyenda.EntradaInformacion = el;
		}		
		
		private static void NuevaEntradaLeyendaTematica(TipoMapa tipo, string uid, VectorLayer capa, string titulo, EntradaLeyendaTematica.TipoOrdenacion ordenacion)
		{
			switch (tipo)
			{
				case TipoMapa.TemaUso:
					_entradaTemaUsos = new EntradaLeyendaTematica(uid, capa, titulo, ordenacion);
					_leyenda.AgregarEntrada(_entradaTemaUsos);
					break;
				case TipoMapa.TemaAdscripcion:
					_entradaTemaAdsc = new EntradaLeyendaTematica(uid, capa, titulo, ordenacion);
					_leyenda.AgregarEntrada(_entradaTemaAdsc);
					break;
			}
		}
		
		private static void NuevaSubEntradaLeyendaTematica(EntradaLeyendaTematica elt, string uid, VectorStyle simb, object valorTematico, object valorOrdenacion, string titulo)
		{
			SubEntradaLeyendaTematica subEl = new SubEntradaLeyendaTematica(uid, simb, valorTematico, valorOrdenacion, titulo);
			elt.AgregarSubEntrada(subEl);
		}		
		
		
		private static VectorLayer CrearCapaEdificio (IUnidadGeoEstadistica uge)
		{
			if (uge is PlantaEdificio)
			{
				PlantaEdificio pe = (PlantaEdificio) uge;
				VectorLayer capaEdificio = new SharpMap.Layers.VectorLayer(pe.Codigo);
				SharpMap.Data.Providers.PostGIS proveedorPostgis = new SharpMap.Data.Providers.PostGIS(SIGUANETDesktop.DB.DBUtils.GetPGSQLCnString(), "sig" + pe.Planta.ToString().ToLower(), "gid");
				proveedorPostgis.DefinitionQuery = string.Format("codigo like '{0}%' AND codigo <> '{0}000'", pe.Codigo);
            	capaEdificio.DataSource = proveedorPostgis;
            	SimbLayEdificio s = new SimbLayEdificio();
            	capaEdificio.Enabled = s.visible;
            	capaEdificio.Style = ObtenerEstilo(TipoPaleta.predeterminada, s);
            	NuevaEntradaLeyendaBD(capaEdificio.LayerName, capaEdificio, s.titulo);
            	return capaEdificio;
			}
			else
			{
				return null;
			}

		}
		
		private static VectorLayer CrearCapaCentroidesEdificio (IUnidadGeoEstadistica uge)
		{
			if (uge is PlantaEdificio)
			{
				PlantaEdificio pe = (PlantaEdificio) uge;
				VectorLayer capaCentroidesEdificio = new SharpMap.Layers.VectorLayer(NOMCAPA_CENTROIDES);
				SharpMap.Data.Providers.PostGIS proveedorPostgis = new SharpMap.Data.Providers.PostGIS(SIGUANETDesktop.DB.DBUtils.GetPGSQLCnString(), "quest_estancias_label", "codigo");
				proveedorPostgis.DefinitionQuery = string.Format("codigo like '{0}%'", pe.Codigo);
            	capaCentroidesEdificio.DataSource = proveedorPostgis;
            	return capaCentroidesEdificio;
			}
			else
			{
				return null;
			}

		}		
		
		private static VectorLayer CrearCapaEdificioMuro (IUnidadGeoEstadistica uge)
		{
			if (uge is PlantaEdificio)
			{
				PlantaEdificio pe = (PlantaEdificio) uge;
				VectorLayer capaEdificioMuro = new SharpMap.Layers.VectorLayer(pe.Codigo + "000");
				SharpMap.Data.Providers.PostGIS proveedorPostgis = new SharpMap.Data.Providers.PostGIS(SIGUANETDesktop.DB.DBUtils.GetPGSQLCnString(),"sig" + pe.Planta.ToString().ToLower(),"gid");
				proveedorPostgis.DefinitionQuery = string.Format("codigo = '{0}000'", pe.Codigo);
	            capaEdificioMuro.DataSource = proveedorPostgis;
	            SimbLayEdificioMuro s = new SimbLayEdificioMuro();
	            capaEdificioMuro.Enabled = s.visible;
	            capaEdificioMuro.Style = ObtenerEstilo(TipoPaleta.predeterminada, s);
	            NuevaEntradaLeyendaBD(capaEdificioMuro.LayerName, capaEdificioMuro, s.titulo);
			    return capaEdificioMuro;
			}
			else
			{
				return null;
			}
		}
		
		private static VectorLayer CrearCapaSelPlanta (VectorLayer capaBase, List<Geometry> lp)
		{
            VectorLayer capaSelPlanta = new SharpMap.Layers.VectorLayer(NOMCAPA_CONSULTA);
            SharpMap.Data.Providers.GeometryProvider provGeo = new SharpMap.Data.Providers.GeometryProvider(lp);
            provGeo.SRID = capaBase.SRID;
            capaSelPlanta.DataSource = provGeo;
            SimbLaySelPlanta s = new SimbLaySelPlanta();
            capaSelPlanta.Enabled = s.visible;
            capaSelPlanta.Style = ObtenerEstilo(TipoPaleta.predeterminada, s);
            AsignarEntradaLeyendaConsulta(NOMCAPA_CONSULTA, capaSelPlanta, s.titulo);
			return capaSelPlanta;			
		}
			
		private static VectorLayer CrearCapaSelEst(VectorLayer capaBase, Estancia est)
		{
            //Layer de la estancia seleccionada en el arbol de estancias
            VectorLayer capaSelEst = new SharpMap.Layers.VectorLayer(est.Codigo);
            SharpMap.Data.Providers.GeometryProvider provGeo = new SharpMap.Data.Providers.GeometryProvider(est.Geometria);
            provGeo.SRID = capaBase.SRID;
            capaSelEst.DataSource = provGeo;
            SimbLaySelEst s = new SimbLaySelEst();
            capaSelEst.Enabled = s.visible;
            capaSelEst.Style = ObtenerEstilo(TipoPaleta.predeterminada, s);
            AsignarEntradaLeyendaSeleccion(capaSelEst.LayerName, capaSelEst, s.titulo);
			return capaSelEst;		
		}
		
		private static VectorLayer CrearCapaInfoEst (VectorLayer capaBase)
		{
			//Layer reservada para consultas con el botón info (vacia)               
			VectorLayer capaInfoEst = new SharpMap.Layers.VectorLayer(NOMCAPA_INFO);
			//Atención: si Envelope de capaBase es nulo (i.e. no hay geometrías en la capaBase)
			//proporcionar un punto al proveedor para evitar error en tiempo de ejecución
			SharpMap.Data.Providers.GeometryProvider provGeo;
			if (capaBase.Envelope == null)
			{
				provGeo = new SharpMap.Data.Providers.GeometryProvider(new SharpMap.Geometries.Point(0.0, 0.0));
			}
			else
			{
				provGeo = new SharpMap.Data.Providers.GeometryProvider(capaBase.Envelope.GetCentroid());
			}
			
            provGeo.SRID = capaBase.SRID;
            capaInfoEst.DataSource = provGeo;
            SimbLayInfoEst s = new SimbLayInfoEst();
            capaInfoEst.Enabled = s.visible;
            capaInfoEst.Style = ObtenerEstilo(TipoPaleta.predeterminada, s);
            AsignarEntradaLeyendaInformacion(NOMCAPA_INFO, capaInfoEst, s.titulo);
			return capaInfoEst;
		}
		
		public static Estancia RefrescaCapaInfoEst(Map mapa, string codEst)
		{
			object[] parametros = new object[1] {codEst};
			DataSet ds = DBUtils.GetDataSet(DB.dbOrigen.PGSQL,"SELECT * FROM quest_estancias WHERE codigo = :param1", parametros);
			try
			{
				List<Estancia> l = ObjectFactory.generarListaEstancias(ds);
				if (l != null)
				{
					if (l.Count > 0)
					{
						//Resaltar lo seleccionado mediante el botón info en una nueva capa
						VectorLayer capaInfoEst = (SharpMap.Layers.VectorLayer) mapa.GetLayerByName(NOMCAPA_INFO);
						SharpMap.Data.Providers.GeometryProvider provGeo = new SharpMap.Data.Providers.GeometryProvider(l[0].Geometria);
			            capaInfoEst.DataSource = provGeo;
			            capaInfoEst.Enabled = true;
			            return l[0];					
					}
					else
					{
						throw new ApplicationException("No se encontró ninguna estancia");
					}
				}
				else
				{
					throw new ApplicationException("No se encontró ninguna estancia");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}		
		
		private static LabelLayer CrearCapaEtiq (VectorLayer capaBase)
		{
			if (!(capaBase == null))
			{
				LabelLayer capaEtiq = new SharpMap.Layers.LabelLayer(NOMCAPA_ETIQUETAS);
				capaEtiq.DataSource = capaBase.DataSource;
				capaEtiq.LabelStringDelegate = delegate(SharpMap.Data.FeatureDataRow fdr)
				{ return fdr["codigo"].ToString().Substring(6); };
				capaEtiq.Style = new SharpMap.Styles.LabelStyle();
				capaEtiq.Style.CollisionDetection = true;
				capaEtiq.Style.CollisionBuffer = new SizeF(10, 10);
				capaEtiq.Style.ForeColor = Color.Black;
				capaEtiq.Style.Font = new Font(FontFamily.GenericSerif, 8);
				capaEtiq.MaxVisible = 180;
				capaEtiq.Style.HorizontalAlignment = SharpMap.Styles.LabelStyle.HorizontalAlignmentEnum.Center;			
				return capaEtiq;
			}
			else
			{
				return null;
			}
		
		}
		
		private static VectorLayer CrearCapaTemaUsos (IUnidadGeoEstadistica uge)
		{
			if (uge is PlantaEdificio)
			{
				PlantaEdificio pe = (PlantaEdificio) uge;
				_capaTemaUsos = new SharpMap.Layers.VectorLayer(pe.Codigo);
				SharpMap.Data.Providers.PostGIS proveedorPostgis = new SharpMap.Data.Providers.PostGIS(SIGUANETDesktop.DB.DBUtils.GetPGSQLCnString(),"sig" + pe.Planta.ToString().ToLower(),"gid");
				proveedorPostgis.DefinitionQuery = string.Format("codigo like '{0}%' AND actividad <> 93", pe.Codigo);
	            _capaTemaUsos.DataSource = proveedorPostgis;
	            
				CustomTheme generadorEstilos = new SharpMap.Rendering.Thematics.CustomTheme(CrearEstiloPorActividad);
				VectorStyle estiloPorDefecto = SIGUANETDesktop.ModeloCartografia.Simbologia.Paleta.obtenerEstiloPorDefecto(_paleta);
				generadorEstilos.DefaultStyle = estiloPorDefecto;
				
				_capaTemaUsos.Theme = generadorEstilos;
				
			    NuevaEntradaLeyendaTematica(TipoMapa.TemaUso, _capaTemaUsos.LayerName, _capaTemaUsos, "Temático por Uso", EntradaLeyendaTematica.TipoOrdenacion.Ascendente);
				return _capaTemaUsos;
			}
			else
			{
				return null;
			}
		}
		
		private static SharpMap.Styles.VectorStyle CrearEstiloPorActividad(SharpMap.Data.FeatureDataRow row)
		{
			GrupoActividad selGrupo = null;
			foreach (GrupoActividad g in GruposActividad.Items)
			{
				foreach (short actividad in g.Actividades)
				{
					if (actividad == (short) row["actividad"]) 
					{
						selGrupo = g;
						break;
					}
				}
			}
			if (selGrupo != null)
			{
				VectorStyle s = ObtenerEstilo(_paleta, selGrupo.Simbologia);
				NuevaSubEntradaLeyendaTematica(_entradaTemaUsos, selGrupo.Tipo.ToString(), s, selGrupo.Actividades, selGrupo.Tipo.ToString(), selGrupo.Simbologia.titulo);
				return s;
			}
			else
			{
				VectorStyle s = SIGUANETDesktop.ModeloCartografia.Simbologia.Paleta.obtenerEstiloPorDefecto(_paleta);
				NuevaSubEntradaLeyendaTematica(_entradaTemaUsos, "Otros", s, null, "Otros", "Otros");
				return null;
			}
		}
		
		private static VectorLayer CrearCapaTemaAdscripcion (IUnidadGeoEstadistica uge)
		{
			if (uge is PlantaEdificio)
			{
				PlantaEdificio pe = (PlantaEdificio) uge;
				//Montar la consulta de los dptos ordenados por superficie
				_dsTemas = pe.EstadisticaDepartamentosSIGUA();
				_capaTemaAdsc = new SharpMap.Layers.VectorLayer(pe.Codigo);
				SharpMap.Data.Providers.PostGIS proveedorPostgis = new SharpMap.Data.Providers.PostGIS(SIGUANETDesktop.DB.DBUtils.GetPGSQLCnString(),"sig" + pe.Planta.ToString().ToLower(),"gid");
				proveedorPostgis.DefinitionQuery = string.Format("codigo like '{0}%' AND actividad <> 93", pe.Codigo);
	            _capaTemaAdsc.DataSource = proveedorPostgis;
				//Llama a la función delegada para pintar adscripcion
	            CustomTheme generadorEstilos = new SharpMap.Rendering.Thematics.CustomTheme(CrearEstiloPorAdscripcion);
			    VectorStyle estiloPorDefecto = SIGUANETDesktop.ModeloCartografia.Simbologia.Paleta.obtenerEstiloPorDefecto(_paleta);
				generadorEstilos.DefaultStyle = estiloPorDefecto;
				
				_capaTemaAdsc.Theme = generadorEstilos;

				NuevaEntradaLeyendaTematica(TipoMapa.TemaAdscripcion, _capaTemaAdsc.LayerName, _capaTemaAdsc, "Temático por Adscripción", EntradaLeyendaTematica.TipoOrdenacion.Descendente);
				return _capaTemaAdsc;
			}
			else
			{
				return null;
			}
		}
		
		private static SharpMap.Styles.VectorStyle CrearEstiloPorAdscripcion(SharpMap.Data.FeatureDataRow row)
		{
			//Montar bucle para asignar a cada fila su correspondiente orden en la paleta
			int peso = 0;
			string selAdsc = string.Empty;
			double superficie = 0.0;
			string titulo = string.Empty;
			foreach (DataRow dr in _dsTemas.Tables[0].Rows)
			{
				++peso;
				if ( (string) row["coddpto"] == (string) dr["cod"] )
				{
					selAdsc = (string) dr["cod"];
					superficie = (double) dr["superficie"];
					titulo = string.Format("{0} - {1} ({2} m²)", (string) dr["cod"], (string) dr["txt"], superficie.ToString("F"));
					break;
				}
			}
			if (selAdsc != string.Empty)
			{
				VectorStyle s = SIGUANETDesktop.ModeloCartografia.Simbologia.Paleta.obtenerEstilo(peso, _paleta);
				NuevaSubEntradaLeyendaTematica(_entradaTemaAdsc, selAdsc, s, selAdsc, superficie, titulo);
				return s;
			}
			else
			{
				VectorStyle s = SIGUANETDesktop.ModeloCartografia.Simbologia.Paleta.obtenerEstiloPorDefecto(_paleta);
				NuevaSubEntradaLeyendaTematica(_entradaTemaAdsc, "Gestión de Espacios", s, null, superficie, "Gestión de Espacios");
				return null;
			}
			
		}		
		
		private static void CrearMapaPorDefecto(Graphics canvas, Map mapa, IUnidadGeoEstadistica uge, List<Geometry> lp, Estancia est)
		{
			_leyenda.Canvas = canvas;
			_leyenda.Tipo = TipoMapa.Predeterminado;
			_leyenda.Reiniciar();
			mapa.Layers.Clear();
			VectorLayer capaBase = CrearCapaEdificio(uge);
			if (capaBase != null)
			{
				mapa.Layers.Add(capaBase);
				mapa.Layers.Add(CrearCapaEdificioMuro(uge));
				mapa.Layers.Add(CrearCapaSelPlanta(capaBase, lp));
				if (est != null)
				{
					mapa.Layers.Add(CrearCapaSelEst(capaBase, est));
				}
				else
				{
					_leyenda.EntradaSeleccion = null;
				}
				mapa.Layers.Add(CrearCapaInfoEst(capaBase));
				LabelLayer capaEtiq = CrearCapaEtiq(CrearCapaCentroidesEdificio(uge));
				if (capaEtiq != null) mapa.Layers.Add(capaEtiq);
			    mapa.ZoomToExtents();
			}
		}
				
		private static void CrearMapaTematicoUsos(Graphics canvas, Map mapa, IUnidadGeoEstadistica uge, List<Geometry> lp, Estancia est)
		{
			_leyenda.Canvas = canvas;
			_leyenda.Tipo = TipoMapa.TemaUso;
			_leyenda.Reiniciar();
			mapa.Layers.Clear();
			VectorLayer capaBase = CrearCapaTemaUsos(uge);
			if (capaBase != null)
			{
				mapa.Layers.Add(capaBase);
				mapa.Layers.Add(CrearCapaEdificioMuro(uge));
				mapa.Layers.Add(CrearCapaSelPlanta(capaBase, lp));
				if (est != null)
				{
					mapa.Layers.Add(CrearCapaSelEst(capaBase, est));
				}
				else
				{
					_leyenda.EntradaSeleccion = null;
				}				
				mapa.Layers.Add(CrearCapaInfoEst(capaBase));
				LabelLayer capaEtiq = CrearCapaEtiq(CrearCapaCentroidesEdificio(uge));
				if (capaEtiq != null) mapa.Layers.Add(capaEtiq);
			    mapa.ZoomToExtents();
			}
		}
		
		private static void CrearMapaTematicoAdscripcion(Graphics canvas, Map mapa, IUnidadGeoEstadistica uge, List<Geometry> lp, Estancia est)
		{
			_leyenda.Canvas = canvas;
			_leyenda.Tipo = TipoMapa.TemaAdscripcion;
			_leyenda.Reiniciar();
			mapa.Layers.Clear();
			VectorLayer capaBase = CrearCapaTemaAdscripcion(uge);
			if (capaBase != null)
			{
				mapa.Layers.Add(capaBase);
				mapa.Layers.Add(CrearCapaEdificioMuro(uge));
				mapa.Layers.Add(CrearCapaSelPlanta(capaBase, lp));
				if (est != null)
				{
					mapa.Layers.Add(CrearCapaSelEst(capaBase, est));
				}
				else
				{
					_leyenda.EntradaSeleccion = null;
				}				
				mapa.Layers.Add(CrearCapaInfoEst(capaBase));
				LabelLayer capaEtiq = CrearCapaEtiq(CrearCapaCentroidesEdificio(uge));
				if (capaEtiq != null) mapa.Layers.Add(capaEtiq);
			    mapa.ZoomToExtents();
			}
		}
		
		private static Leyenda _leyenda = new Leyenda();
		public static Leyenda Leyenda
		{
			get
			{
				return _leyenda;
			}
		}
		
		public static void CrearMapa(Graphics canvas, Map mapa, IUnidadGeoEstadistica uge, List<Geometry> lp, Estancia est)
		{
			CrearMapaPorDefecto(canvas, mapa, uge, lp, est);
		}		
		
		public static void CrearMapa(Graphics canvas, Map mapa, IUnidadGeoEstadistica uge, List<Geometry> lp, Estancia est, TipoMapa tipo)
		{
			_paleta = TipoPaleta.predeterminada;
			switch (tipo)
			{
				case TipoMapa.Predeterminado:
					CrearMapaPorDefecto(canvas, mapa, uge, lp, est);
					break;
				case TipoMapa.TemaUso:
					CrearMapaTematicoUsos(canvas, mapa, uge, lp, est);
					break;					
				case TipoMapa.TemaAdscripcion:
					CrearMapaTematicoAdscripcion(canvas, mapa, uge, lp, est);
					break;
				default:
					break;
			}
		}
		
		public static void CrearMapa(Graphics canvas, Map mapa, IUnidadGeoEstadistica uge, List<Geometry> lp, Estancia est, TipoMapa tipo, TipoPaleta paleta)
		{
			_paleta = paleta;
			switch (tipo)
			{
				case TipoMapa.Predeterminado:
					CrearMapaPorDefecto(canvas, mapa, uge, lp, est);
					break;
				case TipoMapa.TemaUso:
					CrearMapaTematicoUsos(canvas, mapa, uge, lp, est);
					break;					
				case TipoMapa.TemaAdscripcion:
					CrearMapaTematicoAdscripcion(canvas, mapa, uge, lp, est);
					break;
				default:
					break;
			}
		}				
	}
}
