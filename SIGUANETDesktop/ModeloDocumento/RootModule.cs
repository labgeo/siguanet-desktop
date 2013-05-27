/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tomás
 * Fecha: 09/04/2008
 * Hora: 12:27
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace SIGUANETDesktop.ModeloDocumento
{
	/// <summary>
	/// Description of RootModule.
	/// </summary>
	public abstract class RootModule
	{		
		private bool _enabled = true;
		[XmlAttribute]
		public bool Enabled
		{
			get
			{
				return this._enabled;
			}
			set
			{
				this._enabled = value;
				//Al deshabilitar un módulo se asume que sus propiedades Descripcion y Doc
				//deben estar vacías (string.Empty) y que sus colecciones componentes
				//deben ser vaciadas (por ejemplo, la colección de operaciones del 
				//módulo de sincronización). Si además utilizamos código reflexivo
				//esta acción se ejecutará para cualquier futura colección componente
				//que se vaya añadiendo.
				if  (!this._enabled)
				{
					foreach (PropertyInfo p in this.GetType().GetProperties())
					{
						//Todo RootModule tiene, por convención de diseño, las propiedades
						//Descripcion y Doc.
						if (p.Name == "Descripcion" || p.Name == "Doc")
						{
							//Asignamos string.Empty a la propiedad para evitar que en el
							//SGD aparezca información descriptiva de un RootModule
							//que está deshabilitado y, por tanto, no operativo
							p.SetValue(this, string.Empty, null);
						}
						
						//Si el RootModule es un agregado, las propiedades componentes (colecciones)
						//son siempre, por convención de diseño, de tipo genérico (Collection<T> o List<T>).
						if (p.PropertyType.IsGenericType)
						{
							//Invocamos el método Clear() de la lista o colección 
							//de tipo genérico usando Reflection
							object collection = p.GetValue(this, null);
							Type theType = collection.GetType();
							MethodInfo theMethod = theType.GetMethod("Clear");
							theMethod.Invoke(collection, null);
						}
					}
				}
			}
		}
		
		[XmlIgnore]
		public bool HasData
		{
			get
			{
				bool hasData = false;
				foreach (PropertyInfo p in this.GetType().GetProperties())
				{
					if (p.PropertyType.IsGenericType)
					{
						object collection = p.GetValue(this, null);
						Type theType = collection.GetType();
						PropertyInfo theProperty = theType.GetProperty("Count");
						if ((int) theProperty.GetValue(collection, null) > 0)
						{
							hasData = true;
							break;
						}
					}
				}
				return hasData;
			}
		}
	}
}
