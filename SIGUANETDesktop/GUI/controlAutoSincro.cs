/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 07/06/2006
 * Time: 13:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using SIGUANETDesktop.ModeloSincronizacion;
using SIGUANETDesktop.ModeloSincronizacion.AutoSincro;
namespace SIGUANETDesktop.GUI
{
	/// <summary>
	/// Description of controlAutoSincro.
	/// </summary>
	public partial class controlAutoSincro
	{
		private TextBox tx = new TextBox();
		private static string strBuffer = string.Empty;
				
		private static Control dlg = null;
		
		private static string strStatusBuffer = "Listo";
		
		private Secuenciador seq;
		private static StringBuilder sb = new StringBuilder();
		
		public controlAutoSincro(Secuenciador s)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.seq = s;
			this.seq.SecuenciaReinicia += new SeqResetDelegate(this.AlReiniciarSecuencia);
			this.seq.SecuenciaComienza += new SeqStartDelegate(this.AlComenzarSecuencia);
			this.seq.SecuenciaTermina += new SeqEndDelegate(this.AlTerminarSecuencia);
			this.seq.OperacionComienza += new OpStartDelegate(this.AlComenzarOperacion);
			this.seq.OperacionInforma += new OpInfoDelegate(this.AlRecibirMensaje);
			this.seq.TareaComienza += new TaskStartDelegate(this.AlComenzarTarea);
			this.seq.TareaInforma += new TaskInfoDelegate(this.AlRecibirMensaje);
			this.seq.ComandoComienza += new CmdStartDelegate(this.AlComenzarComando);
			this.seq.ComandoObtieneDatos += new CmdDataDelegate(this.AlRecibirDatos);
			this.seq.ComandoObtieneDatosCriticos += new CmdCriticalDataDelegate(this.AlRecibirDatosCriticos);
			this.seq.ComandoInforma += new CmdCountDelegate(this.AlRecibirMensaje);
			this.seq.ComandoSolicitaExcepcionesSincro += new CmdSyncRequestExceptionsDelegate(this.AlSolicitarExcepcionesSincro);
			this.seq.ComandoSolicitaSincro += new CmdSyncRequestDelegate(this.AlSolicitarSincro);
			this.seq.ComandoSolicitaEditar += new CmdEditRequestDelegate(this.AlSolicitarEdicion);
			this.tsbBwd.Enabled = (this.seq.State == SeqState.SeqInProgress);
			this.tsbPlay.Enabled = (this.seq.State == SeqState.SeqDone);
			this.tsbStop.Enabled = (this.seq.State == SeqState.SeqInProgress);
			this.tsbFwd.Enabled = (this.seq.State == SeqState.SeqInProgress);
			this.tsbRefresh.Enabled = (this.seq.State == SeqState.SeqDone);
			this.txProgreso.Text = sb.ToString();
			
			tx.ReadOnly = true;
			tx.Multiline = true;
			tx.ScrollBars = ScrollBars.Both;
			tx.Dock = DockStyle.Fill;
			if (strBuffer!= string.Empty)
			{
				tx.Text = strBuffer;
				this.splitContainer1.Panel2.Controls.Add(tx);
			}
			
			if (dlg != null)
			{
				dlg.Dock = DockStyle.Fill;
				this.splitContainer1.Panel2.Controls.Add(dlg);
			}
			
			this.tsslMsg.Text = strStatusBuffer;
			
			this.ckInfoOperacion.Checked = this.seq.InfoOperacion;
			this.ckInfoTarea.Checked = this.seq.InfoTarea;
			this.ckOmitPreSincro.Checked = this.seq.OmitPresincro;
			this.ckOmitPostSincro.Checked = this.seq.OmitPostSincro;
			this.ckOmitComplemento.Checked = this.seq.OmitComplemento;
			switch (this.seq.ResponseCmdSeleccionar)
			{
				case CmdResponse.Data: 
					this.opDataCmdSel.Checked = true;
					break;
				case CmdResponse.Count: 
					this.opCountCmdSel.Checked = true;
					break;
				case CmdResponse.Omit:
					this.opOmitCmdSel.Checked = true;
					break;			
			}
			switch (this.seq.ResponseCmdComparar)
			{
				case CmdResponse.Data: 
					this.opDataCmdComparar.Checked = true;
					break;
				case CmdResponse.Count: 
					this.opCountCmdComparar.Checked = true;
					break;
				case CmdResponse.Omit:
					this.opOmitCmdComparar.Checked = true;
					break;
			}
			switch (this.seq.ResponseCmdEditar)
			{
				case CmdResponse.Data: 
					this.opDataCmdEditar.Checked = true;
					break;
				case CmdResponse.Count: 
					this.opCountCmdEditar.Checked = true;
					break;
				case CmdResponse.Omit:
					this.opOmitCmdEditar.Checked = true;
					break;
			}
		}

		void AlReiniciarSecuencia()
		{
			sb.Remove(0, sb.ToString().Length);
			strBuffer = string.Empty;
			dlg = null;
			this.tsbBwd.Enabled = false;
			this.tsbPlay.Enabled = true;
			this.tsbFwd.Enabled = false;
			this.tsbStop.Enabled = false;
			this.tsbRefresh.Enabled = true;
			if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);
			this.tsslMsg.Text = strStatusBuffer = "Listo";
			this.txProgreso.Text = sb.ToString();
		}
		void AlComenzarSecuencia()
		{
			sb.Remove(0, sb.ToString().Length);
			strBuffer = string.Empty;
			dlg = null;
			this.tsbBwd.Enabled = true;
			this.tsbPlay.Enabled = false;
			this.tsbFwd.Enabled = true;
			this.tsbStop.Enabled = true;
			this.tsbRefresh.Enabled = false;
			if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);
			this.tsslMsg.Text = strStatusBuffer = "Inicio de secuencia";
			sb.AppendLine(string.Format("[{0}] BEGIN", DateTime.Now.ToString()));
			this.txProgreso.Text = sb.ToString();
		}
		
		void AlTerminarSecuencia()
		{
			strBuffer = string.Empty;
			dlg = null;
			this.tsbBwd.Enabled = false;
			this.tsbPlay.Enabled = true;
			this.tsbFwd.Enabled = false;
			this.tsbStop.Enabled = false;
			this.tsbRefresh.Enabled = true;
			if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);
			this.tsslMsg.Text = strStatusBuffer = "Fin de secuencia";
			sb.AppendLine(string.Format("[{0}] END", DateTime.Now.ToString()));
			this.txProgreso.Text = sb.ToString();
		}
		
		void AlComenzarOperacion(Operacion o)
		{
			strBuffer = string.Empty;
			dlg = null;
			if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);
			this.tsslMsg.Text = strStatusBuffer = o.Descripcion;
			sb.AppendLine(string.Format(" [{1}] OPERACION: {0}", o.Descripcion, DateTime.Now.ToString()));
			this.txProgreso.Text = sb.ToString();
		}
		
		void AlComenzarTarea(Tarea t)
		{
			strBuffer = string.Empty;
			dlg = null;
			if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);
			this.tsslMsg.Text = strStatusBuffer = t.Descripcion;
			sb.AppendLine(string.Format("    [{1}] TAREA: {0}", t.Descripcion, DateTime.Now.ToString()));
			this.txProgreso.Text = sb.ToString();
		}

		void AlComenzarComando(Comando c, string info, SyncroStep step)
		{
			string msg = string.Empty;
			int len = 0;
			int start = 0;
			strBuffer = string.Empty;
			dlg = null;
			if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);
			this.tsslMsg.Text = strStatusBuffer = c.Descripcion;
			switch (step)
			{
				case SyncroStep.NotSyncro:
					msg = string.Format("        [{1}] COMANDO: {0} {2}", c.Descripcion, DateTime.Now.ToString(), info);
					break;
				case SyncroStep.ExceptionsCfg:
					msg = string.Format("        [{1}] COMANDO: {0} {2}", c.Descripcion, DateTime.Now.ToString(), info);
					break;
				case SyncroStep.Simulation:
					len = this.txProgreso.Lines[this.txProgreso.Lines.GetUpperBound(0) - 1].Length;
					start = sb.ToString().Length - len;
					sb.Remove(start, len);					
					msg = string.Format("        [{1}] COMANDO: {0} {2}", c.Descripcion, DateTime.Now.ToString(), info);
					break;
				case SyncroStep.Transaction:
					len = this.txProgreso.Lines[this.txProgreso.Lines.GetUpperBound(0) - 1].Length;
					start = sb.ToString().Length - len;
					sb.Remove(start, len);					
					msg = string.Format("        [{1}] COMANDO: {0} {2}", c.Descripcion, DateTime.Now.ToString(), info);
					break;					
			}
			sb.AppendLine(msg);
			this.txProgreso.Text = sb.ToString();
		}
		
		void AlRecibirDatos(DataTable dt)
		{
			strBuffer = string.Empty;
			dlg = null;
			if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);
			dlg = new controlDatos(dt);
			dlg.Dock = DockStyle.Fill;
			this.splitContainer1.Panel2.Controls.Add(dlg);
		}
		
		void AlRecibirDatosCriticos(DataTable dt)
		{
			//Diálogo modal para mostrar incidencias
			frmDatos w = new frmDatos(dt, "Incidencias");
			w.StartPosition = FormStartPosition.CenterParent;
			w.ShowDialog(this);
		}
		
		void AlRecibirMensaje(string msg)
		{
			strBuffer = msg;
			dlg = null;
			if (this.splitContainer1.Panel2.Controls.Count > 0) this.splitContainer1.Panel2.Controls.RemoveAt(0);
			tx.Text = strBuffer;
			this.splitContainer1.Panel2.Controls.Add(tx);
		}

		void AlSolicitarExcepcionesSincro(CmdSincronizar c)
		{
			//Diálogo modal para confirmar actualización de excepciones
			frmExcepciones w = new frmExcepciones(c);
			w.StartPosition = FormStartPosition.CenterParent;
			w.ShowDialog(this);
		}
		
		bool AlSolicitarSincro(CmdSincronizar c)
		{
			//Diálogo modal para confirmar sincronización
			frmAfectados w = new frmAfectados(c.ObtenerDatos(), string.Format("Registros que serán afectados al {0}", c.Descripcion));
			w.StartPosition = FormStartPosition.CenterParent;
			w.ShowDialog(this);
			return (w.DialogResult == DialogResult.OK);
		}
		
		bool AlSolicitarEdicion(CmdEditar c)
		{
			//Diálogo modal para confirmar actualización
			frmEdicion w = new frmEdicion(c.ObtenerDatos(), c.Descripcion);
			w.StartPosition = FormStartPosition.CenterParent;
			w.ShowDialog(this);
			return (w.DialogResult == DialogResult.OK);
		}
		
		void TsbBwdClick(object sender, System.EventArgs e)
		{
			if (this.seq.CanGoBack)
			{
				int i = this.txProgreso.Lines.GetUpperBound(0);
				string preLastLine = this.txProgreso.Lines[i-2];
				string lastLine = this.txProgreso.Lines[i-1];
				int len = preLastLine.Length + lastLine.Length + 4;
				int start = sb.ToString().Length - len;
				sb.Remove(start, len);
				this.seq.GoBack();
				this.seq.Ejecutar();
			}

		}		
		
		void TsbPlayClick(object sender, System.EventArgs e)
		{
			this.seq.Ejecutar();
		}
		
		void TsbFwdClick(object sender, System.EventArgs e)
		{
			this.seq.Ejecutar();
		}

		void TsbStopClick(object sender, System.EventArgs e)
		{
			this.seq.Reset(false);
		}
		
		void TsbRefreshClick(object sender, System.EventArgs e)
		{
			this.seq.Reset(true);
		}		

		void TxProgresoTextChanged(object sender, System.EventArgs e)
		{
			int l = this.txProgreso.Text.Length;
			if (l > 0) this.txProgreso.Select(l -1, 1);
			this.txProgreso.ScrollToCaret();
		}
		
		void TxProgresoKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					this.tsbPlay.PerformClick();
					break;
				case Keys.PageDown:
					this.tsbFwd.PerformClick();
					break;
				case Keys.Down:
					this.tsbFwd.PerformClick();
					break;
				case Keys.Right:
					this.tsbFwd.PerformClick();
					break;
				case Keys.PageUp:
					this.tsbBwd.PerformClick();
					break;
				case Keys.Up:
					this.tsbBwd.PerformClick();
					break;
				case Keys.Left:
					this.tsbBwd.PerformClick();
					break;
			}
		}		
		
		void CkInfoOperacionCheckedChanged(object sender, System.EventArgs e)
		{
			this.seq.InfoOperacion = this.ckInfoOperacion.Checked;
		}
		
		void CkInfoTareaCheckedChanged(object sender, System.EventArgs e)
		{

			this.seq.InfoTarea = this.ckInfoTarea.Checked;
		}
		
		void CkOmitPreSincroCheckedChanged(object sender, System.EventArgs e)
		{
			this.seq.OmitPresincro = this.ckOmitPreSincro.Checked;
		}
		
		void CkOmitPostSincroCheckedChanged(object sender, System.EventArgs e)
		{
			this.seq.OmitPostSincro = this.ckOmitPostSincro.Checked;
		}
		
		void CkOmitComplementoCheckedChanged(object sender, System.EventArgs e)
		{
			this.seq.OmitComplemento = this.ckOmitComplemento.Checked;
		}
		
		void OpDataCmdSelCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opDataCmdSel.Checked) this.seq.ResponseCmdSeleccionar = CmdResponse.Data;
		}
		
		void OpCountCmdSelCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opCountCmdSel.Checked) this.seq.ResponseCmdSeleccionar = CmdResponse.Count;
		}
		
		void OpOmitCmdSelCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opOmitCmdSel.Checked) this.seq.ResponseCmdSeleccionar = CmdResponse.Omit;
		}
		
		void OpDataCmdCompararCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opDataCmdComparar.Checked) this.seq.ResponseCmdComparar = CmdResponse.Data;
		}
		
		void OpCountCmdCompararCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opOmitCmdComparar.Checked) this.seq.ResponseCmdComparar = CmdResponse.Count;
		}
		
		void OpOmitCmdCompararCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opOmitCmdComparar.Checked) this.seq.ResponseCmdComparar = CmdResponse.Omit;
		}
		
		void OpDataCmdEditarCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opDataCmdEditar.Checked) this.seq.ResponseCmdEditar = CmdResponse.Data;
		}
		
		void OpCountCmdEditarCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opCountCmdEditar.Checked) this.seq.ResponseCmdEditar = CmdResponse.Count;
		}
		
		void OpOmitCmdEditarCheckedChanged(object sender, System.EventArgs e)
		{
			if (this.opOmitCmdEditar.Checked) this.seq.ResponseCmdEditar = CmdResponse.Omit;
		}
	}
}
