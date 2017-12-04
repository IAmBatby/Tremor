using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria.ModLoader;

namespace Tremor
{
	public static class TremorUtils
	{
		// Zero recursion
		public static void NullStaticFields(Mod mod)
		{
			Stack<Type> typesToProcess = new Stack<Type>(mod.Code.GetTypes());
			while (typesToProcess.Count > 0)
			{
				Type type = typesToProcess.Pop();
				foreach (FieldInfo info in type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
				{
					info.SetValue(null, info.FieldType.IsValueType ? Activator.CreateInstance(info.FieldType) : null);
				}
				foreach (Type nestedType in type.GetNestedTypes(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
				{
					typesToProcess.Push(nestedType);
				}
			}
		}
	}
}
