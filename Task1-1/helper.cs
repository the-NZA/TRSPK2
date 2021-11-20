using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1_1
{
	class Helper
	{
		const ushort OBJ_NUMBER = 3;
		const ushort LIMITATION = 0;

		public static void fillAnimalArrayList(ref ArrayList collection)
		{
			for (ushort i = OBJ_NUMBER; i > LIMITATION; i--)
			{
				collection.Add(new Animal($"Beast {i}", i));
			}
		}

		public static void fillAnimalList(ref List<Animal> collection)
		{
			for (ushort i = OBJ_NUMBER; i > LIMITATION; i--)
			{
				collection.Add(new Animal($"Beast {i}", i));
			}
		}

		public static void fillPetArrayList(ref ArrayList collection)
		{
			for (ushort i = OBJ_NUMBER; i > LIMITATION; i--)
			{
				collection.Add(new Pet($"Beast {i}", i));
			}
		}

		public static void fillPetList(ref List<Pet> collection)
		{
			for (ushort i = OBJ_NUMBER; i > LIMITATION; i--)
			{
				collection.Add(new Pet($"Beast {i}", i));
			}
		}

		public static void beforeSort(IEnumerable collection)
		{
			Console.WriteLine("Before sorting\n");
			displayCollection(collection);
		}

		public static void afterSort(IEnumerable collection)
		{
			Console.WriteLine("\nAfter sorting by name\n");
			displayCollection(collection);
		}

		public static void displayCollection(IEnumerable collection)
		{
			foreach (object o in collection)
			{
				Console.WriteLine(o);
			}
		}
	}
}