// Copyright 2009 - José Tomás Navarro Carrión (www.gisandchips.org)


using System;

namespace SIGUANETDesktop.Utilidades
{
	/// <summary>
	/// Description of Geek.
	/// </summary>
	public class Geek : IComparable
	{
		string _name = string.Empty;
		string _surname = string.Empty;
		
		public Geek(string name, string surname)
		{
			_name = name;
			_surname = surname;
		}
		
		public int CompareTo(object obj)
		{
			Geek anotherGeek = obj as Geek;
			if (anotherGeek != null)
			{
				return this._surname.CompareTo(anotherGeek._surname);
			}
			else
			{
				return 1;
			}
		}
		
		public override string ToString()
		{
			return string.Format("{0} {1}", _name, _surname);
		}
	}
}
