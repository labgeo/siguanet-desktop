/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 02/01/2007
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlMapView.
	/// </summary>
	public partial class controlMapView
	{
		
		/// <summary>
		/// Map tools enumeration
		/// </summary>
		public enum Tools
		{
			/// <summary>
			/// Pan
			/// </summary>
			Pan,
			/// <summary>
			/// Zoom in
			/// </summary>
			ZoomIn,
			/// <summary>
			/// Zoom out
			/// </summary>
			ZoomOut,
			/// <summary>
			/// Query tool
			/// </summary>
			Query,
			/// <summary>
			/// No active tool
			/// </summary>
			None
		}
		
		private SharpMap.Map _Map;
		/// <summary>
		/// Map reference
		/// </summary>
		public SharpMap.Map Map
		{
			get { return _Map; }
			set
			{
				_Map = value;
				if (_Map != null)
					this.Refresh();
			}
		}

		private int _queryLayerIndex;
		/// <summary>
		/// Gets or sets the index of the active query layer 
		/// </summary>
		public int QueryLayerIndex
		{
			get { return _queryLayerIndex; }
			set { _queryLayerIndex = value; }
		}
	

		private Tools _Activetool;
		/// <summary>
		/// Sets the active map tool
		/// </summary>
		public Tools ActiveTool
		{
			get { return _Activetool; }
			set { 
					bool fireevent = (value != _Activetool);
					_Activetool = value;
					if (value == Tools.Pan)
						this.MapBox.Cursor = Cursors.Hand;
					else
						this.MapBox.Cursor = Cursors.Cross;
					if(fireevent)
						if(ActiveToolChanged != null)
							this.ActiveToolChanged(value);
				}
		}
	
		/// <summary>
		/// Refreshes the map
		/// </summary>
		public override void Refresh()
		{
			if (_Map != null)
			{
				_Map.Size = this.MapBox.Size;
				if (_Map.Layers == null || _Map.Layers.Count == 0)
					this.MapBox.Image = null;
				else
					this.MapBox.Image = _Map.GetMap();
				this.MapBox.Refresh();
				if (MapRefreshed != null)
					this.MapRefreshed(this, null);
			}
		}
		
		public controlMapView()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_Map = new SharpMap.Map(this.MapBox.Size);
			_Activetool = Tools.None;
			this.MapBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseMove);
			this.MapBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseUp);
			this.MapBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseDown);
			this.MapBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MapBox_Wheel);
			this.MapBox.Cursor = Cursors.Cross;
			this.DoubleBuffered = true;			
		}
		
		/// <summary>
		/// MouseEventtype fired from the controlMapView control
		/// </summary>
		/// <param name="WorldPos"></param>
		/// <param name="ImagePos"></param>
		public delegate void MouseEventHandler(SharpMap.Geometries.Point WorldPos, System.Windows.Forms.MouseEventArgs ImagePos);
		/// <summary>
		/// Fires when mouse moves over the map
		/// </summary>
		public new event MouseEventHandler MouseMove;
		/// <summary>
		/// Fires when map received a mouseclick
		/// </summary>
		public new event MouseEventHandler MouseDown;
		/// <summary>
		/// Fires when mouse is released
		/// </summary>		
		public new event MouseEventHandler MouseUp;
		/// <summary>
		/// Fired when mouse is dragging
		/// </summary>
		public event MouseEventHandler MouseDrag;

		/// <summary>
		/// Fired when the map has been refreshed
		/// </summary>
		public event System.EventHandler MapRefreshed;

		/// <summary>
		/// Eventtype fired when the zoom was or are being changed
		/// </summary>
		/// <param name="zoom"></param>
		public delegate void MapZoomHandler(double zoom);
		/// <summary>
		/// Fired when the zoom value has changed
		/// </summary>
		public event MapZoomHandler MapZoomChanged;
		/// <summary>
		/// Fired when the map is being zoomed
		/// </summary>
		public event MapZoomHandler MapZooming;

		/// <summary>
		/// Eventtype fired when the map is queried
		/// </summary>
		/// <param name="data"></param>
		public delegate void MapQueryHandler(SharpMap.Data.FeatureDataTable data);
		/// <summary>
		/// Fired when the map is queried
		/// </summary>
		public event MapQueryHandler MapQueried;


		/// <summary>
		/// Eventtype fired when the center has changed
		/// </summary>
		/// <param name="center"></param>
		public delegate void MapCenterChangedHandler(SharpMap.Geometries.Point center);
		/// <summary>
		/// Fired when the center of the map has changed
		/// </summary>
		public event MapCenterChangedHandler MapCenterChanged;

		/// <summary>
		/// Eventtype fired when the map tool is changed
		/// </summary>
		/// <param name="tool"></param>
		public delegate void ActiveToolChangedHandler(Tools tool);
		/// <summary>
		/// Fired when the active map tool has changed
		/// </summary>
		public event ActiveToolChangedHandler ActiveToolChanged;
		
		private System.Drawing.Point mousedrag;
		private System.Drawing.Image mousedragImg;
		private bool mousedragging = false;

		private void MapBox_Wheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (_Map != null)
			{
				double scale = 0.5 * e.Delta;
				_Map.Zoom *= 1 / scale;
				if (this.MapZoomChanged != null)
					this.MapZoomChanged(_Map.Zoom);
				this.Refresh();
			}
		}

		private void MapBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (_Map != null)
			{
				if (e.Button == MouseButtons.Left) //dragging
				mousedrag = e.Location;
				if (this.MouseDown != null)
					this.MouseDown(this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y)), e);
			}
		}


		private void MapBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (_Map != null && this.MapBox.Image != null)
			{

				SharpMap.Geometries.Point p = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y));

				if (this.MouseMove != null)
					this.MouseMove(p, e);

				if (e.Location != mousedrag && !mousedragging && e.Button == MouseButtons.Left)
				{
					mousedragImg = (Image)this.MapBox.Image.Clone();
					mousedragging = true;
				}

				if (mousedragging)
				{
					if (this.MouseDrag != null)
						this.MouseDrag(p, e);

					if (this.ActiveTool == Tools.Pan)
					{
						System.Drawing.Image img = new System.Drawing.Bitmap(this.MapBox.Size.Width, this.MapBox.Size.Height);
						System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);
						g.Clear(Color.Transparent);
						g.DrawImageUnscaled(mousedragImg, new System.Drawing.Point(e.Location.X - mousedrag.X, e.Location.Y - mousedrag.Y));
						g.Dispose();
						this.MapBox.Image = img;
					}
					else if (this.ActiveTool == Tools.ZoomIn || this.ActiveTool == Tools.ZoomOut)
					{
						System.Drawing.Image img = new System.Drawing.Bitmap(this.MapBox.Size.Width, this.MapBox.Size.Height);
						System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);
						g.Clear(Color.Transparent);
						float scale = 0;
						if (e.Y - mousedrag.Y < 0) //Zoom out
							scale = (float)Math.Pow(1 / (float)(mousedrag.Y - e.Y), 0.5);
						else //Zoom in
							scale = 1 + (e.Y - mousedrag.Y) * 0.1f;
						RectangleF rect = new RectangleF(0, 0, this.MapBox.Width, this.MapBox.Height);
						if (_Map.Zoom / scale < _Map.MinimumZoom)
							scale = (float)Math.Round(_Map.Zoom / _Map.MinimumZoom, 4);
						rect.Width *= scale;
						rect.Height *= scale;
						rect.Offset(this.MapBox.Width / 2 - rect.Width / 2, this.MapBox.Height / 2 - rect.Height / 2);
						g.DrawImage(mousedragImg, rect);
						g.Dispose();
						this.MapBox.Image = img;
						if (this.MapZooming != null)
							this.MapZooming(scale);
					}
				}
			}
		}

		private void MapBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (_Map != null)
			{

				if (this.MouseUp != null)
					this.MouseUp(this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y)), e);

				if (e.Button == MouseButtons.Left)
				{
					if (this.ActiveTool == Tools.ZoomOut)
					{
						double scale = 0.5;
						if (!mousedragging)
						{
							_Map.Center = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y));
							if (this.MapCenterChanged != null)
								this.MapCenterChanged(_Map.Center);
						}
						else
						{
							if (e.Y - mousedrag.Y < 0) //Zoom out
								scale = (float)Math.Pow(1 / (float)(mousedrag.Y - e.Y), 0.5);
							else //Zoom in
								scale = 1 + (e.Y - mousedrag.Y) * 0.1;
						}
						_Map.Zoom *= 1 / scale;
						if (this.MapZoomChanged != null)
							this.MapZoomChanged(_Map.Zoom);
						this.Refresh();
					}
					else if (this.ActiveTool == Tools.ZoomIn)
					{
						double scale = 2;
						if (!mousedragging)
						{
							_Map.Center = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y));
							if (this.MapCenterChanged != null)
								this.MapCenterChanged(_Map.Center);
						}
						else
						{
							if (e.Y - mousedrag.Y < 0) //Zoom out
								scale = (float)Math.Pow(1 / (float)(mousedrag.Y - e.Y), 0.5);
							else //Zoom in
								scale = 1 + (e.Y - mousedrag.Y) * 0.1;
						}
						_Map.Zoom *= 1 / scale;
						if (this.MapZoomChanged != null)
							this.MapZoomChanged(_Map.Zoom);
						this.Refresh();
					}
					else if (this.ActiveTool == Tools.Pan)
					{
						if (mousedragging)
						{
							System.Drawing.Point pnt = new System.Drawing.Point(this.MapBox.Width / 2 + (mousedrag.X - e.Location.X), this.MapBox.Height / 2 + (mousedrag.Y - e.Location.Y));
							_Map.Center = this._Map.ImageToWorld(pnt);
							if (this.MapCenterChanged != null)
								this.MapCenterChanged(_Map.Center);
						}
						else
						{
							_Map.Center = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y));
							if (this.MapCenterChanged != null)
								this.MapCenterChanged(_Map.Center);
						}
						Refresh();
					}
					else if (this.ActiveTool == Tools.Query)
					{
						if (_Map.Layers.Count > _queryLayerIndex && _queryLayerIndex > -1)
						{
							if (_Map.Layers[_queryLayerIndex].GetType() == typeof(SharpMap.Layers.VectorLayer))
							{
								SharpMap.Layers.VectorLayer layer = _Map.Layers[_queryLayerIndex] as SharpMap.Layers.VectorLayer;
								SharpMap.Geometries.BoundingBox bbox = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y)).GetBoundingBox().Grow(_Map.PixelSize * 5);
								SharpMap.Data.FeatureDataSet ds = new SharpMap.Data.FeatureDataSet();
								layer.DataSource.Open();
								layer.DataSource.ExecuteIntersectionQuery(bbox, ds);
								layer.DataSource.Close();
								if (ds.Tables.Count > 0)
									if(this.MapQueried != null) this.MapQueried(ds.Tables[0]);
								else
									if (this.MapQueried != null) this.MapQueried(new SharpMap.Data.FeatureDataTable());
							}
						}
						else
							MessageBox.Show("No active layer to query");
					}
				}
				if (mousedragImg != null)
				{
					mousedragImg.Dispose();
					mousedragImg = null;
				}
				mousedragging = false;
			}
		}
	}
}
