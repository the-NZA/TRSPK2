using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Task1_4
{
	// Сделать массив двумя способами:
	// ArrayList и List<>
	// Проверить скорость вставки и получения элемента для случая хранения типов int и string.
	// Используйте миллион или 10 миллионов операций.
	// Сделать проверку в виде generic-метода с параметрами: тип хранилища и тип проверки

	// Helpers just store constants
	static class Helpers
	{
		public static uint Mil = 1000000;
		public static uint TenMil = 10000000;
	}

	// ITester interface requires Test method to perform given test on passed collection
	// with passed item and count
	interface ITester
	{
		public long Test<TList, TItem>(TList list, TItem type, uint count) where TList : IList, new();
	}

	// AddTester testing add operation to passed collection
	class AddTester : ITester
	{
		public long Test<TList, TItem>(TList list, TItem item, uint count) where TList : IList, new()
		{
			var watch = Stopwatch.StartNew();
			for (int i = 0; i < count; i++)
			{
				list.Add(item);
			}

			watch.Stop();

			return watch.ElapsedMilliseconds;
		}
	}

	// AddTester testing get operation to passed collection
	class GetTester : ITester
	{
		public long Test<TList, TItem>(TList list, TItem item, uint count) where TList : IList, new()
		{
			var watch = Stopwatch.StartNew();
			for (int i = 0; i < count; i++)
			{
				_ = list[i];
			}

			watch.Stop();

			return watch.ElapsedMilliseconds;
		}
	}

	class Program
	{
		static long TestPerformance<TList, TTester, TItem>(TList list, TTester tester, TItem item, uint count)
			where TList : IList, new()
			where TTester : ITester
		{
			return tester.Test(list, item, count);
		}

		[SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Int32")]
		[SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.Object[]")]
		[SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.Int32[]")]
		[SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.String[]")]
		static void Main()
		{
			/* Test ints */
			ArrayList intArr = new ArrayList(0);
			List<int> intList = new List<int>(0);
			int testedInt = 1;

			// Created testers
			AddTester add = new AddTester();
			GetTester get = new GetTester();

			// One million
			Console.WriteLine("Test int lists with 1 million items");

			long res = TestPerformance(intArr, add, testedInt, Helpers.Mil);
			Console.WriteLine("Array list with int add with {0} items {1}", Helpers.Mil, res);

			res = TestPerformance(intArr, get, testedInt, Helpers.Mil);
			Console.WriteLine("Array list with int get with {0} items {1}", Helpers.Mil, res);

			res = TestPerformance(intList, add, testedInt, Helpers.Mil);
			Console.WriteLine("List with int add with {0} items {1}", Helpers.Mil, res);

			res = TestPerformance(intList, get, testedInt, Helpers.Mil);
			Console.WriteLine("List with int get with {0} items {1}", Helpers.Mil, res);

			// Clear array and list
			intArr.Clear();
			intList.Clear();
			GC.Collect();

			// Ten million
			Console.WriteLine("\nTest int lists with 10 million items");

			res = TestPerformance(intArr, add, testedInt, Helpers.TenMil);
			Console.WriteLine("Array list with int add with {0} items {1}", Helpers.TenMil, res);

			res = TestPerformance(intArr, get, testedInt, Helpers.TenMil);
			Console.WriteLine("Array list with int get with {0} items {1}", Helpers.TenMil, res);

			res = TestPerformance(intList, add, testedInt, Helpers.TenMil);
			Console.WriteLine("List with int add with {0} items {1}", Helpers.TenMil, res);

			res = TestPerformance(intList, get, testedInt, Helpers.TenMil);
			Console.WriteLine("List with int get with {0} items {1}", Helpers.TenMil, res);

			// Clear array and list
			intArr.Clear();
			intList.Clear();
			GC.Collect();
			/* Test ints END */

			/* Test strings */
			ArrayList stringArr = new ArrayList(0);
			List<string> stringList = new List<string>(0);
			string testedString = "test";

			// One million
			Console.WriteLine("\nTest string lists with 1 million items");

			res = TestPerformance(stringArr, add, testedString, Helpers.Mil);
			Console.WriteLine("Array list with string add with {0} items {1}", Helpers.Mil, res);

			res = TestPerformance(stringArr, get, testedString, Helpers.Mil);
			Console.WriteLine("Array list with string get with {0} items {1}", Helpers.Mil, res);

			res = TestPerformance(stringList, add, testedString, Helpers.Mil);
			Console.WriteLine("List with string add with {0} items {1}", Helpers.Mil, res);

			res = TestPerformance(stringList, get, testedString, Helpers.Mil);
			Console.WriteLine("List with string get with {0} items {1}", Helpers.Mil, res);
			
			// Clear array and list
			stringArr.Clear();
			stringList.Clear();
			GC.Collect();
			
			// Ten million
			Console.WriteLine("\nTest string lists with 10 million items");

			res = TestPerformance(stringArr, add, testedString, Helpers.TenMil);
			Console.WriteLine("Array list with string add with {0} items {1}", Helpers.TenMil, res);

			res = TestPerformance(stringArr, get, testedString, Helpers.TenMil);
			Console.WriteLine("Array list with string get with {0} items {1}", Helpers.TenMil, res);

			res = TestPerformance(stringList, add, testedString, Helpers.TenMil);
			Console.WriteLine("List with string add with {0} items {1}", Helpers.TenMil, res);

			res = TestPerformance(stringList, get, testedString, Helpers.TenMil);
			Console.WriteLine("List with string get with {0} items {1}", Helpers.TenMil, res);
			
			// Clear array and list
			stringArr.Clear();
			stringList.Clear();
			GC.Collect();
			/* Test strings END */
		}
	}
}