/*
 * Created by SharpDevelop.
 * User: ana
 * Date: 06/04/2007
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SIGUANETDesktop.ModeloClienteSOAP;
using SIGUANETDesktop.SOAP;

namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlSOAPMethodInfo.
	/// </summary>
	public partial class controlClienteSOAP
	{
		private SOAPServiceInfo _soap = null;
		private SOAPMethodInfo _m = null;
		
		public controlClienteSOAP(SOAPServiceInfo soap, SOAPMethodInfo m)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this._soap = soap;
			this._m = m;
			int i = 0;
			foreach(SOAPParamInfo p in this._m.Parameters)
			{
				if (p.DataSource == string.Empty || p.ValueMember == string.Empty)
				{
					if (p.DataType == typeof(bool).Name)
					{
						ToolStripButton b = new ToolStripButton();
						b.Text = p.Label;
						b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
						b.CheckOnClick = true;
						b.Tag = p;
						bool defVal = false;
						if (bool.TryParse(p.DefaultValue, out defVal))
						{
						    b.Checked = defVal;
						}
						else
						{
							b.Checked = false;
						}
						b.ToolTipText = p.Comment;
						this.toolStrip1.Items.Insert(i++, b);
					}
					else
					{
						ToolStripLabel l = new ToolStripLabel(p.Label);
						l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
						this.toolStrip1.Items.Insert(i++, l);
						ToolStripTextBox t = new ToolStripTextBox();
						t.Tag = p;
						t.Text = p.DefaultValue;
						t.ToolTipText = p.Comment;
						this.toolStrip1.Items.Insert(i++, t);
					}
				}
				else
				{
					ToolStripLabel l = new ToolStripLabel(p.Label);
					l.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
					this.toolStrip1.Items.Insert(i++, l);
					ToolStripComboBox c = new ToolStripComboBox();
					c.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
					ApplicationException ex = this.EnlazarCombo(c.ComboBox, p);
					if (ex != null)
					{
						MessageBox.Show(ex.Message + ex.InnerException.Message, "Error Cliente SOAP", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					c.Tag = p;
					c.ToolTipText = p.Comment;
					this.toolStrip1.Items.Insert(i++, c);
				}
			}
			this.txAyuda.Text = this._m.Comment;
		}
		
		private ApplicationException EnlazarCombo(ComboBox c, SOAPParamInfo p)
		{
			ApplicationException r = null;
			try
			{
				object obj = this._soap.CallLookUpTableMethod(p.DataSource, p.AllowEmpty);
				if (obj is DataSet)
				{
					c.DataSource = (obj as DataSet).Tables[0];
					c.DisplayMember = p.DisplayMember;
					c.ValueMember = p.ValueMember;
				}
			}
			catch(Exception e)
			{
				r = new ApplicationException(string.Format("No se pudo enlazar el desplegable con el método {0}.", p.DataSource), e);
			}
			return r;
		}
		
		void TsbOKClick(object sender, System.EventArgs e)
		{
			this.tsslMsg.Text = "Cliente SOAP";
			try
			{
				foreach (ToolStripItem i in this.toolStrip1.Items)
				{
					if (i.Tag != null)
					{
						if (i is ToolStripButton)
						{
							(i.Tag as SOAPParamInfo).ParamValue = (i as ToolStripButton).Checked;
						}
						if (i is ToolStripTextBox)
						{
							(i.Tag as SOAPParamInfo).ParamValue = (i as ToolStripTextBox).Text;
						}
						if (i is ToolStripComboBox)
						{
							if ((i as ToolStripComboBox).SelectedIndex >= 0)
							{
								string fieldName = (i.Tag as SOAPParamInfo).ValueMember;
								(i.Tag as SOAPParamInfo).ParamValue = ((i as ToolStripComboBox).SelectedItem as DataRowView)[fieldName];
							}
						}
					}
				}
				object result = this._soap.CallMethod(this._m);
				if (result is DataSet)
				{
					this.dgResultado.DataSource = (result as DataSet).Tables[0];
					this.tsslMsg.Text = string.Format("{0} registro/s recuperado/s", (result as DataSet).Tables[0].Rows.Count);
				}
				else
				{
					DataTable dt = new DataTable();
					dt.Columns.Add("Resultado", typeof(string));
					dt.Rows.Add(new object[] {result.ToString()});
					this.dgResultado.DataSource = dt;
					this.tsslMsg.Text = "1 registro recuperado";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error Cliente SOAP", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
		
		void ToolStrip1SizeChanged(object sender, System.EventArgs e)
		{
			this.toolStrip1.Refresh();
		}
	}
}
