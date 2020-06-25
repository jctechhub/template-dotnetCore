This compares different ways to create new generic class. 

don't use Activator.CreateInstance(); worse performance

the best way is to use the folllowing: 

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
