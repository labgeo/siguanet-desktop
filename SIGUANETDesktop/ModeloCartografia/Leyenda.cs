/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 24/10/2006
 * Time: 13:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using SIGUANETDesktop.ModeloCartografia.Simbologia;

namespace SIGUANETDesktop.ModeloCartografia
{
	/// <summary>
	/// Description of Leyenda.
	/// </summary>
	public class Leyenda
	{
		private AdminMapas.TipoMapa _tipo = AdminMapas.TipoMapa.Predeterminado;
		public AdminMapas.TipoMapa Tipo
		{
			get
			{
				return _tipo;
			}
			set
			{
				_tipo = value;
			}
		}
		
		private Point _origen = new Point(0, 0);
		public Point Origen
		{
			get
			{
				return _origen;
			}
			set
			{
				if ( value!= null) _origen = value;
			}
		}
		
		private Graphics _canvas = null;
		public Graphics Canvas
		{
			get
			{
				return _canvas;
			}
			set
			{
				_canvas = value;
			}
		}
		
		private List<EntradaLeyenda> _items = new List<EntradaLeyenda>();
		public List<EntradaLeyenda> Items
		{
			get
			{
				return _items;
			}
		}
		
		private EntradaLeyendaConsulta _entradaConsulta = null;
		public EntradaLeyendaConsulta EntradaConsulta
		{
			get
			{
				return _entradaConsulta;
			}
			set
			{
				_entradaConsulta = value;
			}
		}
		
		private EntradaLeyendaSeleccion _entradaSeleccion = null;
		public EntradaLeyendaSeleccion EntradaSeleccion
		{
			get
			{
				return _entradaSeleccion;
			}
			set
			{
				_entradaSeleccion = value;
			}
		}
		
		private EntradaLeyendaInformacion _entradaInformacion = null;
		public EntradaLeyendaInformacion EntradaInformacion
		{
			get
			{
				return _entradaInformacion;
			}
			set
			{
				_entradaInformacion = value;
			}
		}		
		
		public Leyenda()
		{
			
		}
		
		public Leyenda(Graphics canvas)
		{
			_canvas = canvas;
		}
		
		public void AgregarEntrada(EntradaLeyenda entrada)
		{
			bool cancel = false;
			foreach (EntradaLeyenda el in _items)
			{
				if (el.UID == entrada.UID) 
				{
					cancel = true;
					break;
				}
			}
			if (!cancel) _items.Add(entrada);
		}
		
		public void Reiniciar()
		{
			_items.Clear();
		}
		
		public void Render()
		{
			if (_canvas != null)
			{
				int posX = 0;
				int posY = _origen.Y;
				Font fuente = new Font(Constantes.familiaFuente, Constantes.sizeFuente, Constantes.estiloFuente, Constantes.unidadFuente);
				posX = _origen.X + Constantes.distPanelLeyenda;
				
				_items.Sort();
				foreach (EntradaLeyenda el in _items)
				{
				    posY += Constantes.distCuadroV;
				    posY = el.Render(_canvas, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro, fuente, Constantes.colorFuente, posX + Constantes.distCuadroLabel, posY);
				}
				
				if (this._entradaConsulta != null)
				{
					posY += Constantes.distCuadroV;
					this._entradaConsulta.Render(_canvas, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro, fuente, Constantes.colorFuente, posX + Constantes.distCuadroLabel, posY);
				}
				
				if (this._entradaSeleccion != null)
				{
					posY += Constantes.distCuadroV;
					this._entradaSeleccion.Render(_canvas, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro, fuente, Constantes.colorFuente, posX + Constantes.distCuadroLabel, posY);
				}
				
				if (this._entradaInformacion != null)
				{
					posY += Constantes.distCuadroV;
					this._entradaInformacion.Render(_canvas, posX, posY, Constantes.anchoCuadro, Constantes.altoCuadro, fuente, Constantes.colorFuente, posX + Constantes.distCuadroLabel, posY);
				}				
			}
		}
	}
}
