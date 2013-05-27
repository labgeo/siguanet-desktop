/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 27/11/2006
 * Time: 12:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace SIGUANETDesktop.ModeloExplotacion
{
	/// <summary>
	/// Description of PaginaPropiedades.
	/// </summary>
	public class PaginaPropiedades
	{
		private List<PropiedadEscalar> _items = new List<PropiedadEscalar> ();
		[XmlArray]
		public List<PropiedadEscalar> Items 
		{
			get 
			{
				return _items;
			}
			set
			{
				_items = value;
			}
		}
		
		//Buffer de propiedades para implementar el mecanismo de COPIAR/PEGAR
		//conjuntos de propiedades entre diferentes páginas de propiedades
		private static List<PropiedadEscalar> _itemsEnBuffer = new List<PropiedadEscalar> ();
		public static List<PropiedadEscalar> ItemsEnBuffer
		{
			get
			{
				return PaginaPropiedades._itemsEnBuffer;
			}
		}
	
		public void CopiarPropiedades(List<PropiedadEscalar> selection)
		{
			if (selection != null)
			{
				PaginaPropiedades._itemsEnBuffer.Clear();
				PaginaPropiedades._itemsEnBuffer.AddRange(selection);
			}
		}
		
		public void PegarPropiedades()
		{
			//¡IMPORTANTE! Copiamos las referencias del buffer en instancias nuevas de objeto
			//y añadimos los nuevos objetos a la colección de propiedades de la página actual.
			//Para ello usamos el método de clonación de la clase PropiedadEscalar
			foreach (PropiedadEscalar p in PaginaPropiedades._itemsEnBuffer)
			{
				this.Items.Add((PropiedadEscalar) p.Clone());
			}
		}
		
		public void Serializar(string nomFichero)
		{
			XmlSerializer x;
			System.Xml.XmlTextWriter w;
			try
			{
				x = new XmlSerializer(this.GetType());
			    w = new XmlTextWriter(nomFichero, System.Text.Encoding.Unicode);
	        	w.Formatting = Formatting.Indented;
	        	w.Indentation = 2;
	        	x.Serialize(w, this);
	        	w.Close();
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public PaginaPropiedades()
		{
		}
	}
}
