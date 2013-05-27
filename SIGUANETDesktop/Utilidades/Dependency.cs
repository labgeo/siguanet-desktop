// Copyright 2009 - Jos� Tom�s Navarro Carri�n (www.gisandchips.org)


using System;

namespace SIGUANETDesktop.Utilidades
{
	/// <summary>
	/// Description of Dependency.
	/// </summary>
	public class Dependency
	{
		string _assembly = string.Empty;
		public string Assembly {
			get { return _assembly; }
		}
		
		string _version = string.Empty;
		public string Version {
			get { return _version; }
		}
		
		public Dependency(string assembly, string version)
		{
			_assembly = assembly;
			_version = version;
		}
	}
}
