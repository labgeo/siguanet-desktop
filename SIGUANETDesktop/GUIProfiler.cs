/*
 * Creado por SharpDevelop.
 * Usuario: Jose Tom�s
 * Fecha: 29/04/2008
 * Hora: 15:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificaci�n | Editar Encabezados Est�ndar
 */

using System;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using SIGUANETDesktop.Perfiles;
using SIGUANETDesktop.ModeloDocumento;

namespace SIGUANETDesktop
{
	/// <summary>
	/// Clase est�tica que define y aplica las reglas de deshabilitaci�n
	/// de componentes del interfaz de usuario (GUIRule)
	/// </summary>
	public static class GUIProfiler
	{
		//Array auxiliar para la predefinici�n m�s c�moda de las reglas
		//Instrucciones de asignaci�n:
		//rules[i,0] = "NombreFormOControlUsuario"
		//rules[i,1] = "NombreComponente"
		//rules[i,2] = new perfilUsuario[] {p1, ..., pn}
		private static object[,] _rules = new object[,]
		{
			{"MainForm", "mitemGuardarComo", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemPerfil", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemORA", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemVEsquemasBD", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevo", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemAbrir", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemGuardar", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemGuardarComo", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoArbEspacial", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoArbUEM", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoArbOrganizativo", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoArbUsos", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoArbUsosG", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoArbUsosGCRUE", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoArbUsosGU21", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoPAccCampus", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoPAccEdificios", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoPAccPlantas", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoPAccEstancias", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoPAccDepartamentos", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoPAccUsos", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemNuevoPAccPersonas", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}},
			{"MainForm", "mitemEliminarPuntoAcceso", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}}
		};
		
		//Array auxiliar para la predefinici�n m�s c�moda de las reglas con excepci�n
		//Instrucciones de asignaci�n:
		//rules[i,0] = "NombreFormOControlUsuario"
		//rules[i,1] = "NombreComponente"
		//rules[i,2] = new perfilUsuario[] {p1, ..., pn}
		//rules[i,3] = delegado an�nimo de tipo BooleanExpressionDelegate que eval�a 
		//una expresi�n booleana. Si la expresion devuelve true entonces hay que hacer
		//una excepci�n a la regla, o para ser m�s exactos, invertirla: 
		//en lugar de deshabilitar hay que habilitar.
		//Ejemplo de regla con excepci�n:
		//Deshabilitar el acceso al cuadro de di�logo de conexi�n a PostgreSQL
		//para los perfiles {p1, ..., pn} excepto cuando no se hayan podido cargar 
		//los ajustes remotos ((Loader.SRS == null) == true).
		//Este es un ejemplo muy pedag�gico de la utilidad de los
		//DELEGADOS AN�NIMOS. �Por qu� empleamos delegados an�nimos en lugar
		//de evaluar las expresiones booleanas dir�ctamente? La clase GUIProfiler es
		//est�tica, lo que significa que empleando expresiones booleanas dir�ctamente
		//en el array _rulesOverridable, dichas expresiones se eval�an una s�la vez
		//(en el momento en que se inicializa el array). Sin embargo,
		//es necesario evaluar dichas expresiones CADA VEZ que se invoque el
		//m�todo GUIProfiler.Apply, precisamente porque asumimos que pueden haber cambiado
		//las condiciones a evaluar. Para poder almacenar los delegados an�nimos en el
		//array de objetos _rulesOverridable deben tener un tipo asignado, por eso se crea
		//el delegado BooleanExpressionDelegate y se hace el casting de cada delegado an�nimo
		//a dicho tipo de delegado
		private static object[,] _rulesOverridable = new object[,]
		{
			{"MainForm", "mitemPGSQL", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador}, (BooleanExpressionDelegate) delegate{return Loader.SRS == null;}},
			{"MainForm", "tstxPerfilCustom", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador, ProfileType.Root}, (BooleanExpressionDelegate) delegate{return Loader.CustomProfile != string.Empty;}},
			{"MainForm", "tssbImpersonacion", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador, ProfileType.Root}, (BooleanExpressionDelegate) delegate{return Loader.IsImpersonated == true;}},
			{"MainForm", "tstxImpersonacionCustom", new ProfileType[] {ProfileType.Publico, ProfileType.Interno, ProfileType.Departamento, ProfileType.Administrador, ProfileType.Root}, (BooleanExpressionDelegate) delegate{return Loader.CustomImpersonation != string.Empty;}}
		};
		
		private static Collection<GUIRule> _guiRules = new Collection<GUIRule>();
			
		public static void Apply(ContainerControl target)
		{
			Type t = target.GetType();
			//Aplicaci�n de reglas
			for (int i = 0; i <= GUIProfiler._rules.GetUpperBound(0); i++)
			{
				if ((GUIProfiler._rules[i,0] as string).ToUpper() == target.Name.ToUpper())
				{
					string component = (string)GUIProfiler._rules[i,1];	
					FieldInfo f = t.GetField(component, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
					if (f != null)
					{
						GUIRule r = new GUIRule(f.GetValue(target), (ProfileType[]) GUIProfiler._rules[i,2]);
						r.Apply();
					}
				}
			}
			//Aplicaci�n de reglas con excepci�n
			for (int i = 0; i <= GUIProfiler._rulesOverridable.GetUpperBound(0); i++)
			{
				if ((GUIProfiler._rulesOverridable[i,0] as string).ToUpper() == target.Name.ToUpper())
				{
					string component = (string)GUIProfiler._rulesOverridable[i,1];	
					FieldInfo f = t.GetField(component, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
					if (f != null)
					{
						GUIRule r = new GUIRule(f.GetValue(target), (ProfileType[]) GUIProfiler._rulesOverridable[i,2], (BooleanExpressionDelegate) GUIProfiler._rulesOverridable[i,3]);
						r.Apply();
					}
				}
			}
		}
	}
	
	public delegate bool BooleanExpressionDelegate();
}
