/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 07/06/2006
 * Time: 14:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Data;

namespace SIGUANETDesktop.ModeloSincronizacion.AutoSincro
{
	
	public delegate void SeqResetDelegate();
	public delegate void SeqStartDelegate();
	public delegate void SeqEndDelegate();
	public delegate void OpStartDelegate(Operacion o);
	public delegate void OpInfoDelegate(string msg);
	public delegate void TaskStartDelegate(Tarea t);
	public delegate void TaskInfoDelegate(string msg);
	public delegate void CmdStartDelegate(Comando c, string info, SyncroStep step);
	public delegate void CmdDataDelegate(DataTable dt);
	public delegate void CmdCriticalDataDelegate(DataTable dt);
	public delegate void CmdCountDelegate(string msg);
	public delegate void CmdSyncRequestExceptionsDelegate(CmdSincronizar c);
	public delegate bool CmdSyncRequestDelegate(CmdSincronizar c);
	public delegate bool CmdEditRequestDelegate(CmdEditar c);
	
	public enum SeqState
	{
		SeqInProgress,
		SeqDone
	}
	public enum CmdResponse
	{
		Data,
		Count,
		Omit
	}
	
	public enum SyncroStep
	{
		NotSyncro,
		ExceptionsCfg,
		Simulation,
		Transaction
	}
	
	/// <summary>
	/// Description of Secuenciador.
	/// </summary>
	public class Secuenciador
	{

		private SesionSinc _sinc;
		
		private static List<object> SeqList = new List<object>();
		private static int SeqStep = -1;
		private static Operacion ActiveOperation = null;
		private static Tarea ActiveTask = null;
		
		private static SeqState _state = SeqState.SeqDone;
		public SeqState State
		{
			get { return _state; }
		}
		
		public bool CanGoBack
		{
			get { return (SeqStep > 0); }
		}
		
		private static bool _infoOperacion = true;
		public bool InfoOperacion
		{
			get { return _infoOperacion; }
			set { _infoOperacion = value; }
		}
		
		private static bool _infoTarea = true;
		public bool InfoTarea
		{
			get { return _infoTarea; }
			set { _infoTarea = value; }
		}
		
		private static bool _omitPreSincro = false;
		public bool OmitPresincro
		{
			get { return _omitPreSincro; }
			set { _omitPreSincro = value; }
		}		
		
		private static bool _omitPostSincro = false;
		public bool OmitPostSincro
		{
			get { return _omitPostSincro; }
			set { _omitPostSincro = value; }
		}
		
		private static bool _omitComplemento = false;
		public bool OmitComplemento
		{
			get { return _omitComplemento; }
			set { _omitComplemento = value; }
		}
		
		private static CmdResponse _responseCmdSeleccionar = CmdResponse.Data;
		public CmdResponse ResponseCmdSeleccionar
		{
			get { return _responseCmdSeleccionar; }
			set { _responseCmdSeleccionar = value; }
		}
		
		private static CmdResponse _responseCmdComparar = CmdResponse.Data;
		public CmdResponse ResponseCmdComparar
		{
			get { return _responseCmdComparar; }
			set { _responseCmdComparar = value; }
		}		
		
		private static CmdResponse _responseCmdEditar = CmdResponse.Data;
		public CmdResponse ResponseCmdEditar
		{
			get { return _responseCmdEditar; }
			set { _responseCmdEditar = value; }
		}
		
		public Secuenciador(SesionSinc sinc)
		{
			this._sinc = sinc;
			if (SeqList.Count == 0) SeqList = this.BuildSeqList(this._sinc);
		}
		
		public event SeqResetDelegate SecuenciaReinicia;
		public event SeqStartDelegate SecuenciaComienza;
		public event SeqEndDelegate SecuenciaTermina;
		public event OpStartDelegate OperacionComienza;
		public event OpInfoDelegate OperacionInforma;
		public event TaskStartDelegate TareaComienza;
		public event TaskInfoDelegate TareaInforma;
		public event CmdStartDelegate ComandoComienza;
		public event CmdDataDelegate ComandoObtieneDatos;
		public event CmdCriticalDataDelegate ComandoObtieneDatosCriticos;
		public event CmdCountDelegate ComandoInforma;
		public event CmdSyncRequestExceptionsDelegate ComandoSolicitaExcepcionesSincro;
		public event CmdSyncRequestDelegate ComandoSolicitaSincro;
		public event CmdEditRequestDelegate ComandoSolicitaEditar;
		
		public void Ejecutar()
		{
			bool suspend = false;
			if (_state == SeqState.SeqDone)
			{
				_state = SeqState.SeqInProgress;
				this.SecuenciaComienza();
			}
			for (int i = SeqStep + 1; i < SeqList.Count; i++)
			{
				if (SeqList[i].GetType() == typeof(Operacion)) 
				{
					ActiveOperation = (Operacion) SeqList[i];
					suspend = this.Exec((Operacion) SeqList[i]);
				}
				if (SeqList[i].GetType() == typeof(PreSincro))
				{
					ActiveTask = (PreSincro) SeqList[i];
					suspend = this.Exec((PreSincro) SeqList[i]);
				}
				if (SeqList[i].GetType() == typeof(Sincro))
				{
					ActiveTask = (Sincro) SeqList[i];
					suspend = this.Exec((Sincro) SeqList[i]);
				}
				if (SeqList[i].GetType() == typeof(PostSincro))
				{
					ActiveTask = (PostSincro) SeqList[i];
					suspend = this.Exec((PostSincro) SeqList[i]);
				}
				if (SeqList[i].GetType() == typeof(Complemento))
				{
					ActiveTask = (Complemento) SeqList[i];
					suspend = this.Exec((Complemento) SeqList[i]);
				}
				if (SeqList[i].GetType() == typeof(CmdSeleccionar))
				{
					suspend = this.Exec((CmdSeleccionar) SeqList[i]);
				}
				if (SeqList[i].GetType() == typeof(CmdComparar))
				{
					suspend = this.Exec((CmdComparar) SeqList[i]);
				}
				if (SeqList[i].GetType() == typeof(CmdAvisar))
				{
					suspend = this.Exec((CmdAvisar) SeqList[i]);
				}
				if (SeqList[i].GetType() == typeof(CmdSincronizar))
				{
					CmdSincronizar c = (CmdSincronizar) SeqList[i];
					//Fase de configuración de excepciones
					suspend = this.Exec(c, SyncroStep.ExceptionsCfg);
					//Fase de simulación
					suspend = this.Exec(c, SyncroStep.Simulation);
					//Fase de sincronización
					if (!suspend)
					{
						suspend = this.Exec(c, SyncroStep.Transaction);
					}
				}
				if (SeqList[i].GetType() == typeof(CmdEditar))
				{
					suspend = this.Exec((CmdEditar) SeqList[i]);
				}				
				SeqStep = i;
				if (suspend) break;
			}
			if (SeqStep == SeqList.Count -1)
			{
				_state = SeqState.SeqDone;
				SeqStep = -1;
				this.SecuenciaTermina();
			}
		}
		
		private bool Exec(Operacion o)
		{
			bool r = false;
			this.OperacionComienza(o);
			if (_infoOperacion)
			{
				this.OperacionInforma(o.Doc);
				r = true;
			}			
			return r;
		}
		
		private bool Exec(PreSincro t)
		{
			bool r = false;
			this.TareaComienza(t);
			if (!_omitPreSincro)
			{
				if (_infoTarea)
				{
					this.TareaInforma(t.Doc);
					r =true;
				}
			}
			return r;
		}
		
		private bool Exec(Sincro t)
		{
			bool r = false;
			this.TareaComienza(t);
			if (_infoTarea)
			{
				this.TareaInforma(t.Doc);
				r =true;
			}
			return r;
		}
		
		private bool Exec(PostSincro t)
		{
			bool r = false;
			this.TareaComienza(t);
			if (!_omitPostSincro)
			{
				if (_infoTarea)
				{
					this.TareaInforma(t.Doc);
					r =true;
				}
			}
			return r;
		}
		
		private bool Exec(Complemento t)
		{
			bool r = false;
			this.TareaComienza(t);
			if (!_omitComplemento)
			{
				if (_infoTarea)
				{
					this.TareaInforma(t.Doc);
					r =true;
				}
			}
			return r;
		}
		
		private bool Exec(CmdSeleccionar c)
		{
			bool r = false;
			DataTable dt;
			this.ComandoComienza(c, string.Empty, SyncroStep.NotSyncro);
			if (((ActiveTask.GetType() == typeof(PreSincro)) && !_omitPreSincro) ||
			    ((ActiveTask.GetType() == typeof(PostSincro)) && !_omitPostSincro))
			{
				switch(_responseCmdSeleccionar)
				{
					case (CmdResponse.Data):
						dt = c.ObtenerDatos();
						if (dt.TableName == "Excepcion")
						{
							this.ComandoInforma((string)dt.Rows[0]["Mensaje"]);
						}
						else
						{
							this.ComandoObtieneDatos(dt);
						}
						r = true;
						break;
					case (CmdResponse.Count):
						dt = c.ObtenerDatos();
						string msg = string.Empty;
						if (dt.TableName == "Excepcion")
						{
							msg = (string)dt.Rows[0]["Mensaje"];
						}
						else
						{
							msg = string.Format("Nº de registros recuperados: {0}", dt.Rows.Count.ToString());
						}						
						this.ComandoInforma(msg);
						r = true;
						break;
				}
			}			
			return r;
		}
		
		private bool Exec(CmdComparar c)
		{
			bool r = false;
			DataTable dt;
			this.ComandoComienza(c, string.Empty, SyncroStep.NotSyncro);
			if (((ActiveTask.GetType() == typeof(PreSincro)) && !_omitPreSincro) ||
			    ((ActiveTask.GetType() == typeof(PostSincro)) && !_omitPostSincro))
			{
				switch(_responseCmdComparar)
				{
					case (CmdResponse.Data):
						dt = c.ObtenerDatos();
						if (dt.TableName == "Excepcion")
						{
							this.ComandoInforma((string)dt.Rows[0]["Mensaje"]);
						}
						else
						{
							this.ComandoObtieneDatos(dt);
						}
						r = true;
						break;
					case (CmdResponse.Count):
						dt = c.ObtenerDatos();
						string msg = string.Empty;
						if (dt.TableName == "Excepcion")
						{
							msg = (string)dt.Rows[0]["Mensaje"];
						}
						else
						{
							msg = string.Format("Nº de registros recuperados: {0}", dt.Rows.Count.ToString());
						}						
						this.ComandoInforma(msg);
						r = true;
						break;
				}
			}			
			return r;
		}

		private bool Exec(CmdAvisar c)
		{
			bool r = false;
			DataTable dt;
			this.ComandoComienza(c, string.Empty, SyncroStep.NotSyncro);
			dt = c.ObtenerDatos();
			if (dt.TableName == "Excepcion")
			{
				this.ComandoInforma((string)dt.Rows[0]["Mensaje"]);
				r = true;
			}
			else
			{
				if (dt.Rows.Count > 0)
				{
					this.ComandoObtieneDatos(dt);
					r = true;
				}
				else
				{
					this.ComandoInforma("El comando no generó ningún aviso. Puede continuar.");
					r = true;
				}
			}			
			return r;
		}
		
		private bool Exec(CmdEditar c)
		{
			bool r = false;
			DataTable dt;
			string msg = string.Empty;
			this.ComandoComienza(c, string.Empty, SyncroStep.NotSyncro);
			if ((ActiveTask.GetType() == typeof(Complemento)) && !_omitComplemento)
			{
				switch(_responseCmdEditar)
				{
					case (CmdResponse.Data):
						dt = c.ObtenerDatos();
						if (dt.TableName == "Excepcion")
						{
							this.ComandoInforma((string)dt.Rows[0]["Mensaje"]);
							r = true;
						}
						else
						{
							if (this.ComandoSolicitaEditar(c))
							{
								DataTable dt1 = c.Actualizar();
								msg = (string)dt1.Rows[0]["Mensaje"];
								this.ComandoInforma(msg);
								r = true;
							}
							else
							{
								this.ComandoInforma("TRANSACCIÓN CANCELADA");
								r = true;
							}
						}
						break;
					case (CmdResponse.Count):
						dt = c.ObtenerDatos();
						if (dt.TableName == "Excepcion")
						{
							msg = (string)dt.Rows[0]["Mensaje"];
						}
						else
						{
							msg = string.Format("Nº de registros pendientes de edición: {0}", dt.Rows.Count.ToString());
						}						
						this.ComandoInforma(msg);
						r = true;
						break;
				}
			}
			return r;
		}
		
		private bool Exec(CmdSincronizar c, SyncroStep step)
		{
			bool r = false;
			DataTable dt;
			string msg = string.Empty;
			
			switch (step)
			{
				case SyncroStep.ExceptionsCfg:
					this.ComandoComienza(c, " >>> FASE DE CONFIGURACIÓN DE EXCEPCIONES", step);
					if (c.Direccion != TipoComprobacion.ModificacionesPendientesEnSIGUA)
					{
						this.ComandoSolicitaExcepcionesSincro(c);
					}
					break;
				case SyncroStep.Simulation:
					this.ComandoComienza(c, " >>> FASE DE SIMULACIÓN", step);
					dt = c.Simular();
					if (dt.TableName == "Excepcion")
					{
						this.ComandoInforma((string)dt.Rows[0]["Mensaje"]);
						r = true;
					}
					else
					{
						if (dt.Rows.Count > 0)
						{
							this.ComandoObtieneDatosCriticos(dt);
							this.ComandoInforma("¡ATENCIÓN: SE DETECTARON INCIDENCIAS DURANTE LA FASE DE SIMULACIÓN!");
							r = true;
						}
						else
						{
							this.ComandoInforma("NO SE DETECTARON INCIDENCIAS DURANTE LA FASE DE SIMULACIÓN");
						}
					}
					break;
				case SyncroStep.Transaction:
					this.ComandoComienza(c, " >>> FASE DE TRANSACCIÓN", step);
					dt = c.ObtenerDatos();
					if (dt.TableName == "Excepcion")
					{
						this.ComandoInforma((string)dt.Rows[0]["Mensaje"]);
						r = true;
					}
					else
					{
						if (this.ComandoSolicitaSincro(c))
						{
							DataTable dt1 = c.Sincronizar();
							msg = (string)dt1.Rows[0]["Mensaje"];
							this.ComandoInforma(msg);
							r = true;
						}
						else
						{
							this.ComandoInforma("TRANSACCIÓN CANCELADA");
							r = true;
						}
					}
					break;
			}
			return r;
		}
		
		private List<object> BuildSeqList(SesionSinc sinc)
		{
			List<object> l = new List<object>();
			//Construimos la secuencia lineal a partir del modelo de sincronización
			foreach (Operacion o in sinc.Operaciones)
			{
				l.Add(o);
				foreach (Tarea t in o.PreComprobaciones)
				{
					l.Add(t);
					foreach (Comando c in t.Comandos) l.Add(c);
				}
				foreach (Tarea t in o.Acciones)
				{
					l.Add(t);
					foreach (Comando c in t.Comandos) l.Add(c);
				}
				foreach (Tarea t in o.PostComprobaciones)
				{
					l.Add(t);
					foreach (Comando c in t.Comandos) l.Add(c);
				}
				foreach (Tarea t in o.Complementos)
				{
					l.Add(t);
					foreach (Comando c in t.Comandos) l.Add(c);
				}				
			}
			return l;
		}
		
		public void Reset(bool regenSeqList)
		{
			if (regenSeqList) SeqList = this.BuildSeqList(this._sinc);
			SeqStep = -1;
			_state = SeqState.SeqDone;
			this.SecuenciaReinicia();
		}
		
		public bool GoBack()
		{
			bool r = false;
			if (SeqStep > 0) 
			{
				SeqStep -= 2;
				for (int i = SeqStep; i >= 0; i--)
				{
					if (SeqList[i].GetType() == typeof(PreSincro))
					{
						ActiveTask = (PreSincro) SeqList[i];
						break;
					}
					if (SeqList[i].GetType() == typeof(Sincro))
					{
						ActiveTask = (Sincro) SeqList[i];
						break;
					}
					if (SeqList[i].GetType() == typeof(PostSincro))
					{
						ActiveTask = (PostSincro) SeqList[i];
						break;
					}
					if (SeqList[i].GetType() == typeof(Complemento))
					{
						ActiveTask = (Complemento) SeqList[i];
						break;
					}
				}
				for (int i = SeqStep; i >= 0; i--)
				{
					if (SeqList[i].GetType() == typeof(Operacion))
					{
						ActiveOperation = (Operacion) SeqList[i];
						break;
					}
				}				
				r = true;
			}
			return r;
		}
	}
}
