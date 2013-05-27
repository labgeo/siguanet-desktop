/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 25/05/2006
 * Time: 15:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Data;
using SIGUANETDesktop.DB;

namespace SIGUANETDesktop.ModeloClienteSQL
{
	/// <summary>
	/// Description of ClienteSQL.
	/// </summary>
	public static class ClienteSQL
	{
		private const string lcomment1 = "--";
		private const string lcomment2 = "//";
		private const string startcomment = "/*";
		private const string endcomment = "*/";
		private const char lfChar = '\u000A';
		private const char crChar = '\u000D';
		private const char nullChar = '\u0000';
		private const char space = ' ';
		private const char separator = ';';
		
		private static List<string> GetSQL(string text)
		{
			List<string> sqlList = new List<string>();
			string[] sqlLines;
			string comment = string.Empty;
			do
			{
				GetParagraphComment(startcomment, endcomment, text, out comment);
				if (comment != string.Empty) text = text.Replace(comment, string.Empty);
			} while (comment != string.Empty);
			comment = string.Empty;
			do
			{
				GetLineComment(lcomment1, text, out comment);
				if (comment != string.Empty) text = text.Replace(comment, string.Empty);
			} while (comment != string.Empty);
			do
			{
				GetLineComment(lcomment2, text, out comment);
				if (comment != string.Empty) text = text.Replace(comment, string.Empty);
			} while (comment != string.Empty);
			text = text.Replace(lfChar, space);
			text = text.Replace(crChar, space);
			sqlLines = text.Split(separator);
			foreach (string sql in sqlLines)
			{
				sqlList.Add(sql.Trim());
			}
			return sqlList;
		}
		
		private static void GetParagraphComment(string startStr, string endStr, string text, out string comment)
		{
			int start = text.IndexOf(startStr);
			int end = -1;
			comment = string.Empty;
			if (start != -1)
			{
				end = text.IndexOf(endStr, start);
				if (end != -1)
				{
					comment = text.Substring(start, (end - start) + endStr.Length);
				}
				else
				{
					comment = text.Substring(start);
				}
			}
		}
		
		private static void GetLineComment(string startStr, string text, out string comment)
		{
			int start = text.IndexOf(startStr);
			int end = -1;
			comment = string.Empty;
			if (start != -1)
			{
				end = text.IndexOf(lfChar, start);
				if (end != -1)
				{
					comment = text.Substring(start, (end - start));
				}
				else
				{
					comment = text.Substring(start);
				}
			}
		}
		
		private static dbOrigen _source = dbOrigen.PGSQL;
		public static dbOrigen Source
		{
			get { return _source; }
			set { _source = value;}
		}
		
		private static DataSet _output = new DataSet("Output");
		public static DataSet Output
		{
			get { return _output; }
		}
		
		private static int _lastTblCount = -1;
		public static int LastTblCount
		{
			get { return _lastTblCount; }
		}
		
		public struct DataTableInfo
		{
			public string Name;
			public string SQL;
			public int numRows;
		}
		
		public static List<DataTableInfo> Execute(string sqlText)
		{
			DataTable dt;
			List<DataTableInfo> infoList = new List<DataTableInfo>();
			foreach (string sql in GetSQL(sqlText))
			{
				if (sql.Trim() != string.Empty)
				{
					if (sql.Trim().ToUpper().StartsWith("SELECT"))
					{
						dt = DBUtils.GetDataSet(_source, sql, null).Tables[0].Copy();					
					}
					else
					{
						dt = DBUtils.ExecuteNonQuery(_source, sql, null).Tables[0].Copy();
					}
					dt.TableName = Guid.NewGuid().ToString();
					_output.Tables.Add(dt);
					
					DataTableInfo info = new DataTableInfo();
					info.Name = dt.TableName;
					info.SQL = sql.TrimStart(new char[1] {crChar});
					info.numRows = dt.Rows.Count;
					infoList.Add(info);
				}
			}
			return infoList;
		}
		
		public static void ClearOutput()
		{
			_output.Tables.Clear();
		}

		public static void ClearOutput(DataTable dt)
		{
			_output.Tables.Remove(dt);
		}
		
	}
}
