using System;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;

namespace FastClassFactory
{
	class MainClass
	{
		// constants
		private const int repetitions = 1000000;

		// a delegate to create the object
		private delegate object ClassCreator ();

		// dictionary to cache class creators
		private static Dictionary<string, ClassCreator> ClassCreators = new Dictionary<string, ClassCreator> ();

		public static long MeasureA (string typeName)
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < repetitions; i++)
			{
				switch (typeName)
				{
				case "System.Text.StringBuilder":
					new StringBuilder ();
					break;
				default:
					throw new NotImplementedException ();
				}
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureB (string typeName)
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < repetitions; i++)
			{
				Activator.CreateInstance (Type.GetType (typeName));
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		private static ClassCreator GetClassCreator (string typeName)
		{
			// get delegate from dictionary
			if (ClassCreators.ContainsKey (typeName))
				return ClassCreators [typeName];

			// get the default constructor of the type
			Type t = Type.GetType (typeName);
			ConstructorInfo ctor = t.GetConstructor (new Type[0]);

			// create a new dynamic method that constructs and returns the type
			string methodName = t.Name + "Ctor";
			DynamicMethod dm = new DynamicMethod (methodName, t, new Type[0], typeof(object).Module);
			ILGenerator lgen = dm.GetILGenerator ();
			lgen.Emit (OpCodes.Newobj, ctor);
			lgen.Emit (OpCodes.Ret);

			// add delegate to dictionary and return
			ClassCreator creator = (ClassCreator)dm.CreateDelegate (typeof(ClassCreator));
			ClassCreators.Add (typeName, creator);

			// return a delegate to the method
			return creator;
		}

		public static long MeasureC (string typeName)
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < repetitions; i++)
			{
				ClassCreator classCreator = GetClassCreator (typeName);
				classCreator ();
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static void Main (string[] args)
		{
			// measurement run
			long duration1 = MeasureA ("System.Text.StringBuilder");
			long duration2 = MeasureB ("System.Text.StringBuilder");
			long duration3 = MeasureC ("System.Text.StringBuilder");

			Console.WriteLine ("Compile-time construction: {0}", duration1);
			Console.WriteLine ("Dynamic construction: {0}", duration2);
			Console.WriteLine ("CIL method construction: {0}", duration3);
		}
	}
}
