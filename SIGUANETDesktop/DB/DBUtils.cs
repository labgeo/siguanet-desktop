/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 06/04/2006
 * Time: 14:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using Npgsql;
using SIGUANETDesktop.ModeloSincronizacion;
using SIGUANETDesktop.Preferencias;

namespace SIGUANETDesktop.DB
{
	/// <summary>
	/// Description of DBUtils.
	/// </summary>
	public static class DBUtils
	{
		private static string RemoveSemiColon(string SQL)
		{
			if (SQL.EndsWith(";"))
			{
				SQL = SQL.TrimEnd(new char[] {';'});
			}
			return SQL;
		}
		
		public static string GetPGSQLCnString()
		{
			return string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};SearchPath='public, quest'",
			                     DBSettings.PGSQLHost , DBSettings.PGSQLPort,
			                     DBSettings.PGSQLUsr, DBSettings.PGSQLPwd, DBSettings.PGSQLDb);
		}
				
		public static string GetORACnString()
		{
			OracleConnectionStringBuilder sb = new OracleConnectionStringBuilder();
			sb.DataSource = DBSettings.ORATNS;
			sb.IntegratedSecurity = false;
			sb.UserID = DBSettings.ORAUsr;
			sb.Password =DBSettings.ORAPwd;
			return sb.ConnectionString;
		}
		
		public static void FillExceptionDataSet(DataSet oDs, string sMsg)
		{
			DataTable oTbl = new DataTable("Excepcion");
		   	oTbl.Columns.Add("Mensaje", Type.GetType("System.String"));
		   	oDs.Tables.Add(oTbl);
		   	DataRow oRow = oTbl.NewRow();
		   	oRow["Mensaje"] = sMsg;
		   	oTbl.Rows.Add(oRow);
		}

		public static void FillInfoDataSet(DataSet oDs, string sMsg)
		{
			DataTable oTbl = new DataTable("Info");
		   	oTbl.Columns.Add("Mensaje", Type.GetType("System.String"));
		   	oDs.Tables.Add(oTbl);
		   	DataRow oRow = oTbl.NewRow();
		   	oRow["Mensaje"] = sMsg;
		   	oTbl.Rows.Add(oRow);
		}		
		
		public static bool TestConnection(dbOrigen source)
		{
			bool r = false;
			switch (source)
			{			
				case dbOrigen.Ninguno:
					r = false;
					System.Windows.Forms.MessageBox.Show("No se ha especificado origen de datos.", 
					                                     "Error al conectar a la base de datos", 
					                                     System.Windows.Forms.MessageBoxButtons.OK, 
					                                     System.Windows.Forms.MessageBoxIcon.Error);
					break;
				case dbOrigen.ORA:
					OracleConnection oraCn = new OracleConnection(GetORACnString());
					try
					{
						oraCn.Open();
						oraCn.Close();
						r = true;
					}
					catch(OracleException e)
					{
						r = false;
						System.Windows.Forms.MessageBox.Show(e.Message, 
						                                     "Error al conectar a la base de datos", 
						                                     System.Windows.Forms.MessageBoxButtons.OK, 
						                                     System.Windows.Forms.MessageBoxIcon.Error);
					}
					catch(Exception e)
					{
						r = false;
						System.Windows.Forms.MessageBox.Show(e.Message, 
						                                     "Error al conectar a la base de datos", 
						                                     System.Windows.Forms.MessageBoxButtons.OK, 
						                                     System.Windows.Forms.MessageBoxIcon.Error);
					}					
					finally
					{
						if (oraCn.State != 0) oraCn.Close();
					}					
					break;
				case dbOrigen.PGSQL:
					NpgsqlConnection pgCn = new NpgsqlConnection(GetPGSQLCnString());
					try
					{
						pgCn.Open();
						pgCn.Close();
						r = true;
					}
					catch(NpgsqlException e)
					{
						r = false;
						System.Windows.Forms.MessageBox.Show(e.Message, 
						                                     "Error al conectar a la base de datos", 
						                                     System.Windows.Forms.MessageBoxButtons.OK, 
						                                     System.Windows.Forms.MessageBoxIcon.Error);

					}
					catch(Exception e)
					{
						r = false;
						System.Windows.Forms.MessageBox.Show(e.Message, 
						                                     "Error al conectar a la base de datos", 
						                                     System.Windows.Forms.MessageBoxButtons.OK, 
						                                     System.Windows.Forms.MessageBoxIcon.Error);
					}
					finally
					{
						if (pgCn.State != 0) pgCn.Close();
					}
					break;
			}
			return r;
		}
		
		public static DataSet GetSchemaFromQuery(dbOrigen source, string sSQL, object[] aParam)
		{
			int i = 1;
			DataSet oDs = new DataSet();
			switch (source)
			{
				case dbOrigen.Ninguno:
					FillExceptionDataSet(oDs, "No se ha especificado origen de datos.");
					break;
				case dbOrigen.ORA:
					OracleConnection oraCn = new OracleConnection(GetORACnString());
					try
					{
						oraCn.Open();
						OracleCommand oraCmd = new OracleCommand(RemoveSemiColon(sSQL),oraCn);
						if (aParam != null)
						{
							foreach (object param in aParam)
							{
								oraCmd.Parameters.Add(new OracleParameter(string.Format("param{0}", i.ToString()) , param));
								i+=1;
							}
						}
						OracleDataReader oraReader = oraCmd.ExecuteReader(CommandBehavior.SchemaOnly);
						oDs.Tables.Add(oraReader.GetSchemaTable());
						oraCmd.Dispose();
						oraCn.Close();
					}
					catch(OracleException e)
					{
						FillExceptionDataSet(oDs, e.ToString());
					}
					finally
					{
						if (oraCn.State != 0) oraCn.Close();
					}					
					break;
				case dbOrigen.PGSQL:
					NpgsqlConnection pgCn = new NpgsqlConnection(GetPGSQLCnString());
					try
					{
						pgCn.Open();
						NpgsqlCommand pgCmd = new NpgsqlCommand(sSQL,pgCn);
						if (aParam != null)
						{
							foreach (object param in aParam)
							{
								pgCmd.Parameters.Add(new NpgsqlParameter(string.Format("param{0}", i.ToString()) , param));
								i+=1;
							}
						}
						NpgsqlDataReader pgReader = pgCmd.ExecuteReader(CommandBehavior.SchemaOnly);
						oDs.Tables.Add(pgReader.GetSchemaTable());
						pgCmd.Dispose();
						pgCn.Close();
					}
					catch(NpgsqlException e)
					{
						FillExceptionDataSet(oDs, e.ToString());
					}
					finally
					{
						if (pgCn.State != 0) pgCn.Close();
					}
					break;
			}
			return oDs;
		}
		
		public static DataSet GetDataSet(dbOrigen source, string sSQL, object[] aParam)
		{
			int i = 1;
			DataSet oDs = new DataSet();
			switch (source)
			{
				case dbOrigen.Ninguno:
					FillExceptionDataSet(oDs, "No se ha especificado origen de datos.");
					break;
				case dbOrigen.ORA:
					OracleConnection oraCn = new OracleConnection(GetORACnString());
					try
					{
						oraCn.Open();
						OracleCommand oraCmd = new OracleCommand(RemoveSemiColon(sSQL),oraCn);
						if (aParam != null)
						{
							foreach (object param in aParam)
							{
								oraCmd.Parameters.Add(new OracleParameter(string.Format("param{0}", i.ToString()) , param));
								i+=1;
							}
						}
						OracleDataAdapter oraAdaptador = new OracleDataAdapter(oraCmd);
						oraAdaptador.Fill(oDs);
						oraCmd.Dispose();
						oraCn.Close();
					}
					catch(OracleException e)
					{
						FillExceptionDataSet(oDs, e.ToString());
					}
					finally
					{
						if (oraCn.State != 0) oraCn.Close();
					}
					break;
				case dbOrigen.PGSQL:
					NpgsqlConnection pgCn = new NpgsqlConnection(GetPGSQLCnString());
					try
					{
						pgCn.Open();
						NpgsqlCommand pgCmd = new NpgsqlCommand(sSQL,pgCn);
						pgCmd.CommandTimeout = DBSettings.PGSQLCmdTimeOut;
						if (aParam != null)
						{
							foreach (object param in aParam)
							{
								pgCmd.Parameters.Add(new NpgsqlParameter(string.Format("param{0}", i.ToString()) , param));
								i+=1;
							}
						}						
						NpgsqlDataAdapter pgAdaptador = new NpgsqlDataAdapter(pgCmd);
						pgAdaptador.Fill(oDs);
						pgCmd.Dispose();
						pgCn.Close();
					}
					catch(NpgsqlException e)
					{
						FillExceptionDataSet(oDs, e.ToString());
					}
					finally
					{
						if (pgCn.State != 0) pgCn.Close();
					}
					break;
			}
			return oDs;
		}

		public static List<object[]> GetUnjoined(DataTable TablaPadre, string CampoPadre, DataTable TablaHijo, string CampoHijo, TipoComprobacion direccion)
		{
			List<object[]> r = new List<object[]>();
			DataSet oDs = new DataSet();
			DataRelation join = null;
			try
			{
				oDs.Tables.Add(TablaPadre);
				oDs.Tables.Add(TablaHijo);
				join = oDs.Relations.Add("Join", TablaPadre.Columns[CampoPadre], TablaHijo.Columns[CampoHijo], false);
				
				foreach (DataRow parentRow in TablaPadre.Rows)
				{
					switch (direccion)
					{
						case TipoComprobacion.BajasPendientesEnSIGUA:
							if (parentRow.GetChildRows(join).Length > 0)
							{
								r.Add(parentRow.ItemArray);
							}
							else
							{
								parentRow.Delete();
							}
							break;
						case TipoComprobacion.AltasPendientesEnSIGUA:
							if (parentRow.GetChildRows(join).Length == 0)
							{
								r.Add(parentRow.ItemArray);
							}
							else
							{
								parentRow.Delete();
							}
							break;
						case TipoComprobacion.ModificacionesPendientesEnSIGUA:
							if (parentRow.GetChildRows(join).Length == 0)
							{
								if (parentRow.RowState == DataRowState.Modified)
								{
									r.Add(parentRow.ItemArray);
								}
							}
							else
							{
								parentRow.Delete();
							}							
							break;
					}
				}
				TablaPadre.AcceptChanges();
				oDs.Relations.Clear();
				oDs.Tables.Remove(TablaHijo);
			}
			catch //(Exception e)
			{
				oDs.Relations.Clear();
				oDs.Tables.Clear();
				//FillExceptionDataSet(oDs, e.ToString());
			}
			return r;						
		}
		
		public static DataSet GetRelationDataSet(CmdComparar cmd)
		{
			return BuildRelationDataSet(cmd.TablaCPD, cmd.TablaSIGUA, cmd.ComplexData.Tables["Joins"], null, cmd.Direccion);
		}
		public static DataSet GetRelationDataSet(CmdSincronizar cmd)
		{
			return BuildRelationDataSet(cmd.TablaCPD, cmd.TablaSIGUA, cmd.ComplexData.Tables["Joins"], cmd.ComplexData.Tables["Correspondencias"], cmd.Direccion);
		}
		
		private static DataSet BuildRelationDataSet(string tablaCPD, string tablaSIGUA, DataTable joinData, DataTable fieldMappingData, TipoComprobacion direccion)
		{
			DataSet oDs = new DataSet();
			DataRelation join = null;
			List<DataColumn> parentCols = new List<DataColumn>();
			List<DataColumn> childCols = new List<DataColumn>();
			DataTable TablaPadre = null;
			DataTable Pendientes = null;
			string sqlCPD = tablaCPD.Trim().ToUpper();
			string sqlSIGUA = tablaSIGUA.Trim().ToUpper();
			try
			{
				if (!sqlCPD.StartsWith("SELECT"))
				{
					sqlCPD = string.Format("SELECT * FROM {0}", sqlCPD);
				}
				
				if (!sqlSIGUA.StartsWith("SELECT"))
				{
					sqlSIGUA = string.Format("SELECT * FROM {0}", sqlSIGUA);
				}
				oDs.Tables.Add(GetDataSet(dbOrigen.ORA, sqlCPD, null).Tables[0].Copy());
				if(oDs.Tables[0].TableName == "Excepcion")
				{
					string msg = (string)oDs.Tables[0].Rows[0]["Mensaje"];
					throw new ApplicationException(msg);
				}
				oDs.Tables[0].TableName = "TablaCPD";
				oDs.Tables.Add(GetDataSet(dbOrigen.PGSQL, sqlSIGUA, null).Tables[0].Copy());
				if(oDs.Tables[1].TableName == "Excepcion")
				{
					string msg = (string)oDs.Tables[1].Rows[0]["Mensaje"];
					throw new ApplicationException(msg);
				}
				oDs.Tables[1].TableName = "TablaSIGUA";
				foreach (DataRow joinRow in joinData.Rows)
				{
					string CampoCPD = (string) joinRow["CampoCPD"];
					string CampoSIGUA = (string) joinRow["CampoSIGUA"];
					
					if (oDs.Tables[0].Columns[CampoCPD].DataType == typeof(System.Decimal))
					{
						ConvertDecimalColumn(oDs.Tables[0], CampoCPD, oDs.Tables[1].Columns[CampoSIGUA].DataType);
					}
					switch(direccion)
					{
						case(TipoComprobacion.AltasPendientesEnSIGUA) :
							parentCols.Add(oDs.Tables[0].Columns[CampoCPD]);
							childCols.Add(oDs.Tables[1].Columns[CampoSIGUA]);
							break;
						case(TipoComprobacion.BajasPendientesEnSIGUA) :
							parentCols.Add(oDs.Tables[1].Columns[CampoSIGUA]);
							childCols.Add(oDs.Tables[0].Columns[CampoCPD]);
							break;
						case(TipoComprobacion.ModificacionesPendientesEnSIGUA):
							parentCols.Add(oDs.Tables[1].Columns[CampoSIGUA]);
							childCols.Add(oDs.Tables[0].Columns[CampoCPD]);
							break;
					}
				}
				join = oDs.Relations.Add("Join", parentCols.ToArray(), childCols.ToArray(), false);
				switch(direccion)
				{
					case(TipoComprobacion.AltasPendientesEnSIGUA) :
						TablaPadre = oDs.Tables["TablaCPD"];
						Pendientes = oDs.Tables["TablaCPD"].Clone();
						Pendientes.TableName = "Pendientes";
						break;
					case(TipoComprobacion.BajasPendientesEnSIGUA) :
						TablaPadre = oDs.Tables["TablaSIGUA"];
						Pendientes = oDs.Tables["TablaSIGUA"].Clone();
						Pendientes.TableName = "Pendientes";
						break;
					case(TipoComprobacion.ModificacionesPendientesEnSIGUA) :
						TablaPadre = oDs.Tables["TablaSIGUA"];
						break;							
				}
				
				foreach (DataRow parentRow in TablaPadre.Rows)
				{
					switch(direccion)
					{
						case(TipoComprobacion.AltasPendientesEnSIGUA) :
							if (parentRow.GetChildRows(join).Length == 0)
				         	{
								Pendientes.Rows.Add(parentRow.ItemArray);
				         	}
							break;
						case(TipoComprobacion.BajasPendientesEnSIGUA) :
							if (parentRow.GetChildRows(join).Length == 0)
				         	{
								Pendientes.Rows.Add(parentRow.ItemArray);
				         	}
							break;				
						case(TipoComprobacion.ModificacionesPendientesEnSIGUA) :
							string CampoSIGUA = string.Empty;
							string CampoCPD = string.Empty;
							object newVal;
							if (parentRow.GetChildRows(join).Length > 0)
				         	{
								foreach (DataRow fieldMappingRow in fieldMappingData.Rows)
								{
									CampoSIGUA = (string) fieldMappingRow["CampoSIGUA"];
									CampoCPD = (string) fieldMappingRow["CampoCPD"];
									newVal = null;
									if (parentRow.GetChildRows(join)[0][CampoCPD] == System.DBNull.Value)
									{
											if (parentRow[CampoSIGUA] != System.DBNull.Value)
											{
												newVal = System.DBNull.Value;
											}
									}
									else
									{
										if (TablaPadre.Columns[CampoSIGUA].DataType == typeof(System.Boolean))
										{
											if (parentRow[CampoSIGUA] == System.DBNull.Value)
											{
												newVal = (bool)parentRow.GetChildRows(join)[0][CampoCPD];
											}
											else if ((bool)parentRow[CampoSIGUA] != (bool)parentRow.GetChildRows(join)[0][CampoCPD])
											{
												newVal = (bool)parentRow.GetChildRows(join)[0][CampoCPD];
											}
										}
										if (TablaPadre.Columns[CampoSIGUA].DataType == typeof(System.Int16))
										{
											if (parentRow[CampoSIGUA] == System.DBNull.Value)
											{
												newVal = (System.Int16)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int16));
											}
											else if ((System.Int16)parentRow[CampoSIGUA] != (System.Int16)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int16)))
											{
												newVal = (System.Int16)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int16));
											}
										}
										if (TablaPadre.Columns[CampoSIGUA].DataType == typeof(System.Int32))
										{
											if (parentRow[CampoSIGUA] == System.DBNull.Value)
											{
												newVal = (System.Int32)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int32));
											}
											else if ((System.Int32)parentRow[CampoSIGUA] != (System.Int32)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int32)))
											{
												newVal = (System.Int32)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int32));
											}
										}
										if (TablaPadre.Columns[CampoSIGUA].DataType == typeof(System.Int64))
										{
											if (parentRow[CampoSIGUA] == System.DBNull.Value)
											{
												newVal = (System.Int64)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int64));
											}
											else if ((System.Int64)parentRow[CampoSIGUA] != (System.Int64)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int64)))
											{
												newVal = (System.Int64)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Int64));
											}
										}
										if (TablaPadre.Columns[CampoSIGUA].DataType == typeof(System.Double))
										{
											if (parentRow[CampoSIGUA] == System.DBNull.Value)
											{
												newVal = (System.Double)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Double));
											}
											else if ((System.Double)parentRow[CampoSIGUA] != (System.Double)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Double)))
											{
												newVal = (System.Double)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Double));
											}
										}
										if (TablaPadre.Columns[CampoSIGUA].DataType == typeof(System.Single))
										{
											if (parentRow[CampoSIGUA] == System.DBNull.Value)
											{
												newVal = (System.Single)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Single));
											}
											else if ((System.Single)parentRow[CampoSIGUA] != (System.Single)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Single)))
											{
												newVal = (System.Single)SafeCast(parentRow.GetChildRows(join)[0][CampoCPD], typeof(System.Single));
											}
										}
										if (TablaPadre.Columns[CampoSIGUA].DataType == typeof(System.String))
										{
											if (parentRow[CampoSIGUA] == System.DBNull.Value)
											{
												newVal = (string)parentRow.GetChildRows(join)[0][CampoCPD];
											}
											else if ((string)parentRow[CampoSIGUA] != (string)parentRow.GetChildRows(join)[0][CampoCPD])
											{
												newVal = (string)parentRow.GetChildRows(join)[0][CampoCPD];
											}
										}										
									}
									if (newVal != null)
									{
										parentRow.BeginEdit();
										parentRow[CampoSIGUA] = newVal;
										parentRow.EndEdit();
									}
								}
				         	}
							break;
					}
				}
				switch(direccion)
				{
					case(TipoComprobacion.AltasPendientesEnSIGUA) :
						Pendientes.AcceptChanges();
						oDs.Relations.Clear();
						oDs.Tables.Clear();
						oDs.Tables.Add(Pendientes);
						break;
					case(TipoComprobacion.BajasPendientesEnSIGUA) :
						Pendientes.AcceptChanges();
						oDs.Relations.Clear();
						oDs.Tables.Clear();
						oDs.Tables.Add(Pendientes);
						break;
					case(TipoComprobacion.ModificacionesPendientesEnSIGUA) :
						oDs.Relations.Clear();
						oDs.Tables.Remove("TablaCPD");
						break;
				}				
			}
			catch(Exception e)
			{
				oDs.Relations.Clear();
				oDs.Tables.Clear();
				FillExceptionDataSet(oDs, e.ToString());
			}
			return oDs;
		}
		
		public static DataSet UpdateDB(string sql, IDataParameter[] aParam, DataSet inputDs)
		{
			DataSet outputDs = new DataSet();
			int i = 1;
			int numFilas;
            NpgsqlConnection pgCn = new NpgsqlConnection(GetPGSQLCnString());
            try
            {                
                pgCn.Open();
				NpgsqlCommand pgCmd = new NpgsqlCommand(sql, pgCn);
				if (aParam != null)
				{
					foreach (IDataParameter param in aParam)
					{
						pgCmd.Parameters.Add(new NpgsqlParameter(string.Format("param{0}", i.ToString()) , param));
						i+=1;
					}
				}
				NpgsqlDataAdapter pgAdaptador = new NpgsqlDataAdapter(pgCmd);
				
				NpgsqlCommandBuilder pgCB = new NpgsqlCommandBuilder(pgAdaptador);
				
				numFilas = pgAdaptador.Update(inputDs);
				FillInfoDataSet(outputDs, string.Format("El comando se completó con {0} fila/s afectada/s", numFilas.ToString()));
            }
			catch(NpgsqlException e)
			{
				FillExceptionDataSet(outputDs, e.ToString());
			}
			finally
			{
				if (pgCn.State != 0) pgCn.Close();
			}
			return outputDs;            
		}
		
		public static object GetScalar(dbOrigen source, string sSQL, object[] aParam)
		{
			object r = null;
			int i = 1;
			switch (source)
			{
				case dbOrigen.Ninguno:
					r = new DataSet();
					FillExceptionDataSet((DataSet) r, "No se ha especificado origen de datos.");
					break;
				case dbOrigen.ORA:
					OracleConnection oraCn = new OracleConnection(GetORACnString());
					try
					{
						oraCn.Open();
						OracleCommand oraCmd = new OracleCommand(RemoveSemiColon(sSQL),oraCn);
						if (aParam != null)
						{
							foreach (object param in aParam)
							{
								oraCmd.Parameters.Add(new OracleParameter(string.Format("param{0}", i.ToString()) , param));
								i+=1;
							}
						}
						r= oraCmd.ExecuteScalar();
						oraCmd.Dispose();
						oraCn.Close();
					}
					catch(OracleException e)
					{
						r = new DataSet();
						FillExceptionDataSet((DataSet) r, e.ToString());
					}
					finally
					{
						if (oraCn.State != 0) oraCn.Close();
					}					
					break;
				case dbOrigen.PGSQL:
					NpgsqlConnection pgCn = new NpgsqlConnection(GetPGSQLCnString());
					try
					{
						pgCn.Open();
						NpgsqlCommand pgCmd = new NpgsqlCommand(sSQL,pgCn);
						if (aParam != null)
						{
							foreach (object param in aParam)
							{
								pgCmd.Parameters.Add(new NpgsqlParameter(string.Format("param{0}", i.ToString()) , param));
								i+=1;
							}
						}
						r = pgCmd.ExecuteScalar();
						pgCmd.Dispose();
						pgCn.Close();
					}
					catch(NpgsqlException e)
					{
						r = new DataSet();
						FillExceptionDataSet((DataSet) r, e.ToString());
					}
					finally
					{
						if (pgCn.State != 0) pgCn.Close();
					}
					break;
			}
			return r;
		}

		public static DataSet ExecuteNonQuery(dbOrigen source, string sSQL, object[] aParam)
		{
			int i = 1;
			int numRows = 0;
			DataSet oDs = new DataSet();
			switch (source)
			{
				case dbOrigen.Ninguno:
					FillExceptionDataSet(oDs, "No se ha especificado origen de datos.");
					break;
				case dbOrigen.ORA:
					OracleConnection oraCn = new OracleConnection(GetORACnString());
					try
					{
						oraCn.Open();
						OracleCommand oraCmd = new OracleCommand(RemoveSemiColon(sSQL),oraCn);
						if (aParam != null)
						{
							foreach (object param in aParam)
							{
								oraCmd.Parameters.Add(new OracleParameter(string.Format("param{0}", i.ToString()) , param));
								i+=1;
							}
						}
						numRows = oraCmd.ExecuteNonQuery();
						FillInfoDataSet(oDs, string.Format("El comando se completó con {0} registro/s afectado/s", numRows.ToString()));
						oraCmd.Dispose();
						oraCn.Close();
					}
					catch(OracleException e)
					{
						FillExceptionDataSet(oDs, e.ToString());
					}
					finally
					{
						if (oraCn.State != 0) oraCn.Close();
					}					
					break;
				case dbOrigen.PGSQL:
					NpgsqlConnection pgCn = new NpgsqlConnection(GetPGSQLCnString());
					try
					{
						pgCn.Open();
						NpgsqlCommand pgCmd = new NpgsqlCommand(sSQL,pgCn);
						if (aParam != null)
						{
							foreach (object param in aParam)
							{
								pgCmd.Parameters.Add(new NpgsqlParameter(string.Format("param{0}", i.ToString()) , param));
								i+=1;
							}
						}
						numRows = pgCmd.ExecuteNonQuery();
						FillInfoDataSet(oDs, string.Format("El comando se completó con {0} registro/s afectado/s", numRows.ToString()));
						pgCmd.Dispose();
						pgCn.Close();
					}
					catch(NpgsqlException e)
					{
						FillExceptionDataSet(oDs, e.ToString());
					}
					finally
					{
						if (pgCn.State != 0) pgCn.Close();
					}
					break;
			}
			return oDs;
		}
		
		private static void ConvertDecimalColumn(DataTable dt, string colName, System.Type toType)
		{
			if (toType != typeof(System.Decimal))
			{
				string decColName = colName + "Erase";
				dt.Columns[colName].ColumnName = decColName;
				dt.Columns.Add(new DataColumn(colName, toType));
				foreach (DataRow dr in dt.Rows)
				{
					if (toType == typeof(System.Int16))
					{
						dr.BeginEdit();
						dr[colName] = System.Decimal.ToInt16((System.Decimal) dr[decColName]);
						dr.EndEdit();
					}				
					if (toType == typeof(System.Int32))
					{
						dr.BeginEdit();
						dr[colName] = System.Decimal.ToInt32((System.Decimal) dr[decColName]);
						dr.EndEdit();
					}
					if (toType == typeof(System.Int64))
					{
						dr.BeginEdit();
						dr[colName] = System.Decimal.ToInt64((System.Decimal) dr[decColName]);
						dr.EndEdit();
					}
					if (toType == typeof(System.Double))
					{
						dr.BeginEdit();
						dr[colName] = System.Decimal.ToDouble((System.Decimal) dr[decColName]);
						dr.EndEdit();
					}					
					if (toType == typeof(System.Single))
					{
						dr.BeginEdit();
						dr[colName] = System.Decimal.ToSingle((System.Decimal) dr[decColName]);
						dr.EndEdit();
					}					
				}
				dt.AcceptChanges();
				dt.Columns.Remove(decColName);
			}
		}
		
		private static object SafeCast(object val, System.Type toType)
		{
			if (toType != typeof(System.Decimal) && val is System.Decimal)
			{
				if (toType == typeof(System.Int16))
				{
					return System.Decimal.ToInt16((System.Decimal) val);
				}				
				else if (toType == typeof(System.Int32))
				{
					return System.Decimal.ToInt32((System.Decimal) val);
				}
				else if (toType == typeof(System.Int64))
				{
					return System.Decimal.ToInt64((System.Decimal) val);
				}
				else if (toType == typeof(System.Double))
				{
					return System.Decimal.ToDouble((System.Decimal) val);
				}					
				else if (toType == typeof(System.Single))
				{
					return System.Decimal.ToSingle((System.Decimal) val);
				}
				else
				{
					return System.Convert.ChangeType(val, toType);
				}
			}
			else
			{
				return System.Convert.ChangeType(val, toType);
			}
		}
		
		public static void ExceptionBox(DataTable dt, dbOrigen who)
		{
			if (dt.TableName == "Excepcion")
			{
				string msg = (string) dt.Rows[0]["Mensaje"];
				string caption = "Error";
				switch(who)
				{
					case dbOrigen.ORA:
						caption = "Mensaje de error del servidor ORACLE";
						break;
					case dbOrigen.PGSQL:
						caption = "Mensaje de error del servidor PostgreSQL";
						break;
				}
				System.Windows.Forms.MessageBox.Show(msg, caption, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
		}
		
		public static Collection<DBSchemaInfo> GetTargetSchemas(dbOrigen who)
		{
			string schemas = null;
			string[] aSchemas = {};
			Collection<DBSchemaInfo> schemaList= new Collection<DBSchemaInfo>();
			switch(who)
			{
				case dbOrigen.ORA:
					schemas = AdministradorPreferencias.Read(PrefsBD.ORATargetSchemas);
					break;
				case dbOrigen.PGSQL:
					schemas = AdministradorPreferencias.Read(PrefsBD.PGSQLTargetSchemas);
					break;
			}

			if (schemas != null && schemas.Trim() != string.Empty)
			{
				aSchemas = schemas.Split(new char[] {',', ';'}, StringSplitOptions.RemoveEmptyEntries);
				foreach (string s in aSchemas)
				{
					schemaList.Add(new DBSchemaInfo(who, s.Trim()));
				}
			}
			return schemaList;
		}
		
		public static Collection<DBRelationInfo> QueryTableCatalog(DBSchemaInfo schema)
		{
			string SQL = null;
			object[] aParams = null;
			switch(schema.Source)
			{
				case dbOrigen.ORA:
					SQL = AdministradorPreferencias.Read(PrefsBD.ORACustomTableSchemaQuery);
					if (SQL == null || SQL.Trim() == string.Empty)
					{
						SQL = AdministradorPreferencias.Read(PrefsBD.ORADefaultTableSchemaQuery);
					}
					aParams = new object[] {schema.Name.Trim()};
					break;
				case dbOrigen.PGSQL:
					SQL = AdministradorPreferencias.Read(PrefsBD.PGSQLCustomTableSchemaQuery);
					if (SQL == null || SQL.Trim() == string.Empty)
					{
						SQL = AdministradorPreferencias.Read(PrefsBD.PGSQLDefaultTableSchemaQuery);
					}
					aParams = new object[] {DBSettings.PGSQLDb, schema.Name.Trim()};
					break;
			}
			DataSet ds = GetDataSet(schema.Source, SQL, aParams);
			Collection<DBRelationInfo> tables = new Collection<DBRelationInfo>();
			foreach (DataRow r in ds.Tables[0].Rows)
			{
				tables.Add(new DBRelationInfo(schema,(string) r[0], dbRelationType.Table));
			}
			return tables;
		}
		
		public static Collection<DBRelationInfo> QueryViewCatalog(DBSchemaInfo schema)
		{
			string SQL = null;
			object[] aParams = null;
			switch(schema.Source)
			{
				case dbOrigen.ORA:
					SQL = AdministradorPreferencias.Read(PrefsBD.ORACustomViewSchemaQuery);
					if (SQL == null || SQL.Trim() == string.Empty)
					{
						SQL = AdministradorPreferencias.Read(PrefsBD.ORADefaultViewSchemaQuery);
					}
					aParams = new object[] {schema.Name.Trim()};
					break;
				case dbOrigen.PGSQL:
					SQL = AdministradorPreferencias.Read(PrefsBD.PGSQLCustomViewSchemaQuery);
					if (SQL == null || SQL.Trim() == string.Empty)
					{
						SQL = AdministradorPreferencias.Read(PrefsBD.PGSQLDefaultViewSchemaQuery);
					}
					aParams = new object[] {DBSettings.PGSQLDb, schema.Name.Trim()};
					break;
			}
			DataSet ds = GetDataSet(schema.Source, SQL, aParams);
			Collection<DBRelationInfo> views = new Collection<DBRelationInfo>();

			foreach (DataRow r in ds.Tables[0].Rows)
			{
				views.Add(new DBRelationInfo(schema, (string) r[0], dbRelationType.View));
			}
			return views;
		}
		
		public static Collection<DBColumnInfo> QueryColumnCatalog(DBRelationInfo relation)
		{
			string SQL = null;
			object[] aParams = null;
			switch(relation.Schema.Source)
			{
				case dbOrigen.ORA:
					SQL = AdministradorPreferencias.Read(PrefsBD.ORACustomColumnSchemaQuery);
					if (SQL == null || SQL.Trim() == string.Empty)
					{
						SQL = AdministradorPreferencias.Read(PrefsBD.ORADefaultColumnSchemaQuery);
					}
					aParams = new object[] {relation.Schema.Name.Trim(), relation.Name.Trim()};
					break;
				case dbOrigen.PGSQL:
					SQL = AdministradorPreferencias.Read(PrefsBD.PGSQLCustomColumnSchemaQuery);
					if (SQL == null || SQL.Trim() == string.Empty)
					{
						SQL = AdministradorPreferencias.Read(PrefsBD.PGSQLDefaultColumnSchemaQuery);
					}
					aParams = new object[] {DBSettings.PGSQLDb, relation.Schema.Name.Trim(), relation.Name.Trim()};
					break;
			}
			
			DataSet ds = GetDataSet(relation.Schema.Source, SQL, aParams);
			Collection<DBColumnInfo> columns = new Collection<DBColumnInfo>();
			
			foreach (DataRow r in ds.Tables[0].Rows)
			{
				string length = (r[2] == System.DBNull.Value) ? string.Empty : r[2].ToString();
				columns.Add(new DBColumnInfo(relation, (string) r[0], (string) r[1], length));
			}
			return columns;
		}
		
		private static bool SchemaObjectExists(DBRelationInfo target)
		{
			bool e = false;
			Collection<Collection<DBRelationInfo>> candidates = new Collection<Collection<DBRelationInfo>>();
			switch(target.Type)
			{
				case dbRelationType.Table:
					candidates.Add(QueryTableCatalog(target.Schema));
					break;
				case dbRelationType.View:
					candidates.Add(QueryViewCatalog(target.Schema));
					break;
				case dbRelationType.Unknown:
					candidates.Add(QueryTableCatalog(target.Schema));
					candidates.Add(QueryViewCatalog(target.Schema));
					break;
			}
			foreach (Collection<DBRelationInfo> list in candidates)
			{
				foreach (DBRelationInfo r in list)
				{
					if (r.Name.Trim().ToUpper() == target.Name.Trim().ToUpper())
					{
						e = true;
						break;
					}
				}
				if (e) break;
			}
			return e;
		}
		
		private static bool SchemaObjectExists(DBColumnInfo target)
		{
			bool e = false;
			Collection<DBColumnInfo> candidates = QueryColumnCatalog(target.Relation);
			foreach (DBColumnInfo c in candidates)
			{
				if (c.Name.Trim().ToUpper() == target.Name.Trim().ToUpper())
				{
					e = true;
					break;
				}
			}
			return e;
		}
		
		//TODO: Funciones para crear una estructura DBRelationInfo o DBColumnInfo
		//a partir de una cadena que contenga un nombre de objeto calificado
		//(i.e. [public.]tabla, esquema.tabla, [public.]tabla.columna o esquema.tabla.columna)
		private static DBRelationInfo RelInfoFromName(dbOrigen source, string qualifiedName)
		{
			string[] names = qualifiedName.Split(new char[] {'.'});
			string schemaName = string.Empty;
			string relationName = string.Empty;
			switch (source)
			{
				case dbOrigen.PGSQL:
					//En PostgreSQL el esquema por defecto es 'public'
					schemaName = (names.Length > 1) ? names[0] : "public";
					break;
				case dbOrigen.ORA:
					//En ORACLE el nombre debe ser completamente calificado
					//puesto que no existe el concepto de ESQUEMA como categoría.
					//En ORACLE ESQUEMA = NOMBRE_PROPIETARIO. Por tanto, si no
					//conocemos el nombre del propietario, la estructura DBRelationInfo
					//quedará incompleta.
					schemaName = (names.Length > 1) ? names[0] : string.Empty;
					break;
			}
			relationName = (names.Length > 1) ? names[1] : names[0];
			DBSchemaInfo schema = new DBSchemaInfo(source, schemaName);
			return new DBRelationInfo(schema, relationName, dbRelationType.Unknown);
		}
		
		private static DBColumnInfo ColInfoFromName(dbOrigen source, string qualifiedName)
		{
			string[] names = qualifiedName.Split(new char[] {'.'});
			string schemaName = string.Empty;
			string relationName = string.Empty;
			string columnName = string.Empty;
			switch (source)
			{
				case dbOrigen.PGSQL:
					//En PostgreSQL el esquema por defecto es 'public'
					schemaName = (names.Length > 2) ? names[0] : "public";
					break;
				case dbOrigen.ORA:
					//En ORACLE el nombre debe ser completamente calificado
					//puesto que no existe el concepto de ESQUEMA como categoría.
					//En ORACLE ESQUEMA = NOMBRE_PROPIETARIO. Por tanto, si no
					//conocemos el nombre del propietario, la estructura DBColumnInfo
					//quedará incompleta.
					schemaName = (names.Length > 2) ? names[0] : string.Empty;
					break;
			}
			relationName = (names.Length > 2) ? names[1] : names[0];
			columnName = (names.Length  > 2) ? names[2] : names[1];
			DBSchemaInfo schema = new DBSchemaInfo(source, schemaName);
			DBRelationInfo relation = new DBRelationInfo(schema, relationName, dbRelationType.Unknown);
			return new DBColumnInfo(relation, columnName, string.Empty, string.Empty);
		}
		
		public static bool IsRelation(dbOrigen source, string qualifiedName)
		{
			return SchemaObjectExists(RelInfoFromName(source, qualifiedName));
		}
		
		public static bool IsColumn(dbOrigen source, string qualifiedName)
		{
			return SchemaObjectExists(ColInfoFromName(source, qualifiedName));
		}
	}
}
