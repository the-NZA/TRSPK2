using System;
using System.Collections.Generic;

namespace Task1_5
{
	// Есть интерфейс IToolKit c методом string[]
	// GetTools()
	// Есть интерфейс IParts с методом string[]
	// GetParts()

	// Есть классы мебели не generic!, которые наследуются от вышеприведенных интерфейсов
	// и хранят внутри себя список инструментов и составных элементов (Стул, Стол и т.п.)

	// Создать generic класс FurnitureKit<T>, T - может быть одним из классов мебели
	// и дополнять его названием, цветом и методом для вывода на экран списка инструментов и составных частей.
	// public abstract class IkeaKit<TContents> where TContents : IToolKit, IParts, new()

	interface ITookKit
	{
		string[] GetTools();
	}

	interface IParts
	{
		string[] GetParts();
	}

	class FurnitureKit<T> where T : IParts, ITookKit, new()
	{
		private T _furniture;
		public string Name { get; }
		public string Color { get; }

		public FurnitureKit(string name, string color, T furniture)
		{
			_furniture = furniture;
			Name = name;
			Color = color;
		}

		public void DisplayInfo()
		{
			Console.WriteLine($"Name: {Name}, Color: {Color}");

			Console.Write("Parts: ");
			Console.WriteLine(string.Join(", ", _furniture.GetParts()));

			Console.Write("Tools: ");
			Console.WriteLine(string.Join(", ", _furniture.GetTools()));
		}
	}

	class Program
	{
		static void Main()
		{
			FurnitureKit<Table> tableUno = new FurnitureKit<Table>(
				"TableUno",
				"White",
				new Table(
					new List<string> {"legs", "surface"},
					new List<string> {"shurups", "otvertka"}
				)
			);
			tableUno.DisplayInfo();

			FurnitureKit<Chair> chairUno = new FurnitureKit<Chair>(
				"ChairUno",
				"Brown",
				new Chair(
					new List<string> {"legs", "surface", "spinka"},
					new List<string> {"gvozdi", "tester"}
				)
			);
			chairUno.DisplayInfo();
		}
	}
}