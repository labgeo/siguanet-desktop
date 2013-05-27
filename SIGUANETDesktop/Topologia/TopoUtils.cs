/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 10/10/2006
 * Time: 12:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using GisSharpBlog.NetTopologySuite;
using GisSharpBlog.NetTopologySuite.Geometries;
using SharpMap.Geometries;
using SharpMap.Data;
using SharpMap.Converters.NTS;


namespace SIGUANETDesktop.Topologia
{
	/// <summary>
	/// Description of TopoUtils.
	/// </summary>
	public static class TopoUtils
	{
		public static FeatureDataRow LocatePolygon (SharpMap.Geometries.Point punto, SharpMap.Data.FeatureDataTable fdt)
		{
			FeatureDataRow fdr = null;

			if ((fdt as DataTable).Rows.Count == 1)
			{
				fdr  = (FeatureDataRow) (fdt as DataTable).Rows[0];
			}
			else
			{
				GisSharpBlog.NetTopologySuite.Geometries.GeometryFactory f = new GeometryFactory(new PrecisionModel() );
				foreach (DataRow r in (fdt as DataTable).Rows)
				{
					if ((r as  FeatureDataRow).Geometry.GetType() == typeof(SharpMap.Geometries.MultiPolygon))
					{
						// Doble cast: de Geometria a MultiPolygon, y de DataRow a FeatureDataRow.
						SharpMap.Geometries.MultiPolygon SharpMultiPol = (SharpMap.Geometries.MultiPolygon) (r as  FeatureDataRow).Geometry;
						
						foreach (SharpMap.Geometries.Polygon SharpPol in SharpMultiPol.Polygons)
						{
							//Contorno
							int countVExt = SharpPol.ExteriorRing.Vertices.Count;
							int i = 0;
							GisSharpBlog.NetTopologySuite.Geometries.Coordinate[] ListaCoordsExt = new GisSharpBlog.NetTopologySuite.Geometries.Coordinate[countVExt];
							foreach (SharpMap.Geometries.Point p in SharpPol.ExteriorRing.Vertices)
							{
								ListaCoordsExt[i++] = new GisSharpBlog.NetTopologySuite.Geometries.Coordinate(p.X, p.Y);
							}
							
							//Huecos
							int countPolInt = SharpPol.InteriorRings.Count;
							int j = 0;
							GisSharpBlog.NetTopologySuite.Geometries.LinearRing[] ListaPolInt = new GisSharpBlog.NetTopologySuite.Geometries.LinearRing[countPolInt];
							foreach (SharpMap.Geometries.LinearRing ring in SharpPol.InteriorRings)
							{
								int countVInt = ring.Vertices.Count;
								int k = 0;
								GisSharpBlog.NetTopologySuite.Geometries.Coordinate[] ListaCoordsInt = new GisSharpBlog.NetTopologySuite.Geometries.Coordinate[countVInt];
								foreach (SharpMap.Geometries.Point p in ring.Vertices)
								{
									ListaCoordsInt[k++] = new GisSharpBlog.NetTopologySuite.Geometries.Coordinate(p.X, p.Y);
								}
								ListaPolInt[j++] = f.CreateLinearRing(ListaCoordsInt);							
							}
							
							GisSharpBlog.NetTopologySuite.Geometries.Polygon NTSPol =  f.CreatePolygon(f.CreateLinearRing(ListaCoordsExt), ListaPolInt);

							if (NTSPol.Contains(new GisSharpBlog.NetTopologySuite.Geometries.Point(punto.X, punto.Y)) == true)
							{
								fdr = (FeatureDataRow) r;
								break;
							}
						}
						if (fdr != null) break;
						
					}
				}
			}
			return fdr;
		}
		
		public static FeatureDataRow LocatePolygon2 (SharpMap.Geometries.Point punto, SharpMap.Data.FeatureDataTable fdt)
		{
			FeatureDataRow fdr = null;

			if ((fdt as DataTable).Rows.Count == 1)
			{
				fdr  = (FeatureDataRow) (fdt as DataTable).Rows[0];
			}
			else
			{
				GisSharpBlog.NetTopologySuite.Geometries.GeometryFactory f = new GeometryFactory(new PrecisionModel() );
				foreach (DataRow r in (fdt as DataTable).Rows)
				{
					if ((r as  FeatureDataRow).Geometry.GetType() == typeof(SharpMap.Geometries.MultiPolygon))
					{
						// Doble cast: de Geometria a MultiPolygon, y de DataRow a FeatureDataRow.
						SharpMap.Geometries.MultiPolygon SharpMultiPol = (SharpMap.Geometries.MultiPolygon) (r as  FeatureDataRow).Geometry;
						GisSharpBlog.NetTopologySuite.Geometries.Geometry[] NTSGeom = GeometryConverter.ToNTSGeometry(new SharpMap.Geometries.Geometry[1] {SharpMultiPol}, f);
						GisSharpBlog.NetTopologySuite.Geometries.MultiPolygon NTSMultiPol = (GisSharpBlog.NetTopologySuite.Geometries.MultiPolygon) NTSGeom[0];
						if (NTSMultiPol.Contains(new GisSharpBlog.NetTopologySuite.Geometries.Point(punto.X, punto.Y)) == true)
						{
							fdr = (FeatureDataRow) r;
							break;
						}
					}
				}
			}
			return fdr;
		}		
	}
}
