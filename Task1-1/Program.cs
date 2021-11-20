using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1_1
{
	class Program
	{
		public static void Main(string[] args)
		{
			ArrayList animalArrayList = new ArrayList();
			List<Animal> animalList = new List<Animal>();

			Console.WriteLine("Using ArrayList");
			Helper.fillAnimalArrayList(ref animalArrayList);
			Helper.beforeSort(animalArrayList);

			// System.ArgumentException: At least one object must implement IComparable
			animalArrayList.Sort();

			Helper.afterSort(animalArrayList);

			Console.WriteLine("\nUsing List");
			Helper.fillAnimalList(ref animalList);
			Helper.beforeSort(animalList);

			animalList.Sort();

			Helper.afterSort(animalList);

			Console.WriteLine("\nThe same but with IComparable<T>");
			List<Pet> petList = new List<Pet>();

			Console.WriteLine("\nUsing List");
			Helper.fillPetList(ref petList);
			Helper.beforeSort(petList);

			petList.Sort();

			Helper.afterSort(petList);
		}
	}
}