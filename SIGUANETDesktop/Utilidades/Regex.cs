/*
 * Created by SharpDevelop.
 * User: Jose Tomás
 * Date: 31/10/2006
 * Time: 14:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Text.RegularExpressions;

namespace SIGUANETDesktop.Utilidades
{
	/// <summary>
	/// Description of Regex.
	/// </summary>
	public struct Regex
	{
		public enum expType
		{
			unknown,
			stringequals,
			stringnotequals,
			equals,
			notequals,
			greater,
			less,
			greaterequals,
			lessequals,
			istrue,
			isfalse
		}
		
		public static expType getExpType(string s)
		{
			expType r = expType.unknown;
			s = s.ToLower().Replace(" ", string.Empty);
			if (IsMatch(s, "(=[0-9])$")) r = expType.equals;
			if (IsMatch(s, "(!=[0-9])$")) r = expType.notequals;
			if (IsMatch(s, "(<>[0-9])$")) r = expType.notequals;
			if (IsMatch(s, "(=[a-z])$")) r = expType.stringequals;
			if (IsMatch(s, "(!=[a-z])$")) r = expType.stringnotequals;
			if (IsMatch(s, "(<>[a-z])$")) r = expType.stringnotequals;
			if (IsMatch(s, "(>[0-9])$")) r = expType.greater;
			if (IsMatch(s, "(<[0-9])$")) r = expType.less;
			if (IsMatch(s, "(>=[0-9])$")) r = expType.greaterequals;
			if (IsMatch(s, "(<=[0-9])$")) r = expType.lessequals;
			if (IsMatch(s, "(=true)$")) r = expType.istrue;
			if (IsMatch(s, "(!=false)$")) r = expType.istrue;
			if (IsMatch(s, "(<>false)$")) r = expType.istrue;
			if (IsMatch(s, "(=false)$")) r = expType.isfalse;
			if (IsMatch(s, "(!=true)$")) r = expType.isfalse;
			if (IsMatch(s, "(<>true)$"))r = expType.isfalse;
			return r;
		}		
		
		public static bool IsInteger(string s)
		{
			string pattern = "([0-9])$";
			return IsMatch(s, pattern);
		}
		
		public static string FirstUpper(string s)
		{
			string pattern = @"\w+";
			string result = System.Text.RegularExpressions.Regex.Replace(s, pattern, new MatchEvaluator(CapText));
			return result;
		}
		
		private static string CapText(Match m)
		{
			// get the matched string
		    string x = m.ToString();	
			// if the first char is lower case
		    if (char.IsLower(x[0]))	
			// capitalize it
		      return char.ToUpper(x[0]) + x.Substring(1, x.Length-1); 
		    return x;
		}
		
		private static bool IsMatch(string s, string pattern)
		{
			return System.Text.RegularExpressions.Regex.IsMatch(s, pattern);
		}
	}
}
