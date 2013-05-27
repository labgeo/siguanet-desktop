/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tom�s
 * Fecha: 09/04/2008
 * Hora: 12:27
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
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
				//Al deshabilitar un m�dulo se asume que sus propiedades Descripcion y Doc
				//deben estar vac�as (string.Empty) y que sus colecciones componentes
				//deben ser vaciadas (por ejemplo, la colecci�n de operaciones del 
				//m�dulo de sincronizaci�n). Si adem�s utilizamos c�digo reflexivo
				//esta acci�n se ejecutar� para cualquier futura colecci�n componente
				//que se vaya a�adiendo.
				if  (!this._enabled)
				{
					foreach (PropertyInfo p in this.GetType().GetProperties())
					{
						//Todo RootModule tiene, por convenci�n de dise�o, las propiedades
						//Descripcion y Doc.
						if (p.Name == "Descripcion" || p.Name == "Doc")
						{
							//Asignamos string.Empty a la propiedad para evitar que en el
							//SGD aparezca informaci�n descriptiva de un RootModule
							//que est� deshabilitado y, por tanto, no operativo
							p.SetValue(this, string.Empty, null);
						}
						
						//Si el RootModule es un agregado, las propiedades componentes (colecciones)
						//son siempre, por convenci�n de dise�o, de tipo gen�rico (Collection<T> o List<T>).
						if (p.PropertyType.IsGenericType)
						{
							//Invocamos el m�todo Clear() de la lista o colecci�n 
							//de tipo gen�rico usando Reflection
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
