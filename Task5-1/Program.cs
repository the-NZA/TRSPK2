using System;
using System.Collections;
using System.Collections.Generic;

//Сделать программу. Создать переменную. Посмотреть на ее поколение.
//Собрать мусор. Посмотреть на поколение этой переменной. Повторить несколько раз.
//Показать, как переменная будет перемещаться между поколениями.
//Сделать программу, которая будет создавать в цикле множество локальных объектов, которые сразу-же освобождаются.
//Перед циклом создать отдельную переменную. Продемонстрировать, как при сборке мусора эта отдельная переменная уходит в первое поколение.
//Модифицировать программу. Переменные, которые создаются в цикле не уничтожаются, а сохраняются, например, в список.
//Показать, что первая переменная уходит дальше, во второе поколение. 
namespace Task5_1
{
	class Program
	{
		static void First()
		{
			var firstVar = new Object();
			Console.WriteLine("Just created first var: {0}", GC.GetGeneration(firstVar));

			GC.Collect();
			Console.WriteLine("After 1 GC.Collect: {0}", GC.GetGeneration(firstVar));

			for (int i = 2; i < 5; i++)
			{
				GC.Collect();
				Console.WriteLine("After {0} GC.Collect: {1}", i, GC.GetGeneration(firstVar));
			}
			
			Console.WriteLine("");
		}

		static void Second()
		{
			var secondVar = new object();
			Console.WriteLine("Just created second var: {0}",GC.GetGeneration(secondVar));

			for (int i = 0; i < 10; i++)
			{
				var a = new object();
				var b = new object();
				var c = new object();
				var d = new object();
				var e = new object();
				var f = new object();
				var g = new object();
				var h = new ArrayList();
				var i2 = new List<string>();
				
				GC.Collect();
				Console.WriteLine("{0} iteration: {1}", i, GC.GetGeneration(secondVar));
			}
			
			Console.WriteLine("");
		}
		
		static void Third()
		{
			var thirdVar = new object();
			var list = new ArrayList();
			Console.WriteLine("Just created third var: {0}",GC.GetGeneration(thirdVar));

			for (int i = 0; i < 10; i++)
			{
				var a = new object();
				var b = new object();
				var c = new object();
				var d = new object();
				var e = new object();
				var f = new object();

				list.Add(a);
				list.Add(b);
				list.Add(c);
				list.Add(d);
				list.Add(e);
				list.Add(f);
				
				GC.Collect();
				Console.WriteLine("{0} iteration: {1}", i, GC.GetGeneration(thirdVar));
			}
			
			Console.WriteLine("");
		}

		static void Main()
		{
			First();
			
			Second();
			
			Third();
		}
	}
}