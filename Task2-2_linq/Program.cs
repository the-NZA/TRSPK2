using System;
using System.Linq;
using System.Collections.Generic;

namespace Task2_2_linq
{
/*
*/
	class Program
	{
		static void A(int n)
		{
			Console.WriteLine("\nа");
			var rnd = new Random();
			// a) Дан массив целых чисел, отобразить максимальный элемент.
			var aData = new int[n];
			for (var i = 0; i < n; i++)
				aData[i] = rnd.Next(-n, n);
			Console.WriteLine("Array: " + string.Join(", ", aData));
			Console.WriteLine("Max: " + aData.Max());
		}

		static void B(int n)
		{
			Console.WriteLine("\nб");
			var rnd = new Random();
			// b) Дан массив целых чисел, отобразить индекс максимального элемента.
			var bData = new int[n];
			for (var i = 0; i < n; i++)
				bData[i] = rnd.Next(-n, n);
			Console.WriteLine("Array: " + string.Join(", ", bData));
			Console.WriteLine("Ind of max: " + bData.ToList().IndexOf(bData.ToList().Max()));
		}

		struct Struct<T1, T2>
		{
			public T1 X;
			public T2 Y;

			public Struct(T1 x, T2 y)
			{
				this.X = x;
				this.Y = y;
			}

			public override string ToString()
			{
				var x = this.X.GetType().Equals(typeof(double))
					? String.Format("{0:F2}", this.X)
					: this.X.ToString();
				var y = this.Y.GetType().Equals(typeof(double))
					? String.Format("{0:F2}", this.Y)
					: this.Y.ToString();
				return String.Format("{{X:{0}, Y:{1}}}", x, y);
			}
		}

		static void C(int n)
		{
			Console.WriteLine("\nв");
			var rnd = new Random();
			// c) Дан массив структур {X:int, Y:int} - отобразить максимальный по Y элемент.
			var cData = new Struct<int, int>[n];
			for (var i = 0; i < n; i++)
			{
				cData[i].X = rnd.Next(-n, n);
				cData[i].Y = rnd.Next(-n, n);
			}

			Console.WriteLine("Array: " + string.Join(", ", cData));
			var cQuery = from s in cData
				where s.Y == cData.ToList().Max(o => o.Y)
				select s;
			foreach (var res in cQuery)
				Console.WriteLine("Max Y: " + res.ToString());
		}

		static void D(int n)
		{
			Console.WriteLine("\nг");
			var rnd = new Random();
			// d) Дан массив структур {X:int, Y:double} - отсортировать его в порядке
			// возрастания Y и преобразовать в массив элементов {X:double, Y:int}
			var dData = new Struct<int, double>[n];
			for (var i = 0; i < n; i++)
			{
				dData[i].X = rnd.Next(-n, n);
				dData[i].Y = rnd.NextDouble() * 2 * n - n;
			}

			Console.WriteLine("Array: " + string.Join(", ", dData));
			var dQuery = from s in dData
				orderby s.Y
				select new Struct<double, int>((double) s.X, (int) s.Y);
			var dData2 = new Struct<double, int>[n];
			var ind = 0;
			foreach (var res in dQuery)
			{
				dData2[ind] = res;
				ind++;
			}

			Console.WriteLine("New array: " + string.Join(", ", dData2));
		}

		static void F(int n)
		{
			Console.WriteLine("\nд");
			// f) Отсортировать слова по алфавиту из предложенного строкового массива,
			// содержащих слог "il". Не забыть про сравнение в любом регистре!
			var fData = new string[]
			{
				"scratch", "Coincidence", "paLm", "biLL", "chalk",
				"mastermind", "SILK", "user", "agile", "revival"
			};
			Console.WriteLine("Array: " + string.Join(", ", fData));
			var fQuery = fData.Where(s => s.ToUpper().Contains("IL")).OrderBy(s => s);
			Console.Write("Answer:");
			foreach (var res in fQuery)
				Console.Write(" " + res.ToString());
			Console.WriteLine();
		}

		static void E(int n)
		{
			Console.WriteLine("\nе");
			var rnd = new Random();
			// e) Дано два целочислельных массива положительных чисел, определить все
			// возможные пары из элементов массивов (первая цифра - число из первого
			// массива, вторая цифра - число из второго массива) кратные 5.
			var eData1 = new int[n];
			var eData2 = new int[n];
			for (var i = 0; i < n; i++)
			{
				eData1[i] = rnd.Next(1, n);
				eData2[i] = rnd.Next(1, n);
			}

			Console.WriteLine("Array 1: " + string.Join(", ", eData1));
			Console.WriteLine("Array 2: " + string.Join(", ", eData2));
			var eQuery = from i1 in eData1
				from i2 in eData2
				where i2 % 5 == 0
				select i1 * 10 + i2;
			Console.Write("Answer:");
			foreach (var res in eQuery)
				Console.Write(" " + res.ToString());
			Console.WriteLine();
		}

		static void G(int n)
		{
			Console.WriteLine("\nж");
			var rnd = new Random();
			// g) Даны 2 строки s1 и s2. Из каждой можно читать по одному символу.
			// Выяснить, является ли строка s2 обратной s1.
			var eData1 = new int[n];
			var eData2 = new int[n];
			for (var i = 0; i < n; i++)
			{
				eData1[i] = rnd.Next(1, n);
				eData2[i] = rnd.Next(1, n);
			}

			Console.WriteLine("Array 1: " + string.Join(", ", eData1));
			Console.WriteLine("Array 2: " + string.Join(", ", eData2));
			var eQuery = from i1 in eData1
				from i2 in eData2
				where i2 % 5 == 0
				select i1 * 10 + i2;
			Console.Write("Answer:");
			foreach (var res in eQuery)
				Console.Write(" " + res.ToString());
			Console.WriteLine();
		}

		static void H(int n)
		{
			Console.WriteLine("\nз");
			var rnd = new Random();
			// h) Дан массив целых чисел. Сгруппировать их по четности и
			// отсортировать по возрастанию.
			var hData = new int[n];
			for (var i = 0; i < n; i++)
				hData[i] = rnd.Next(-n, n);
			Console.WriteLine("Array 1: " + string.Join(", ", hData));
			var hQuery = hData.ToList().OrderBy(n => (n % 2) * (n % 2)).ThenBy(n => n);
			var groupRes = hData.GroupBy(item => Math.Abs(item % 2));
			Console.Write("Answer:");
			foreach (var res in hQuery)
				Console.Write(" " + res.ToString());
			Console.WriteLine();
		}

		static void I(int n)
		{
			Console.WriteLine("\nи");
			var rnd = new Random();
			// i) Дан массив целых чисел. Сгруппировать их по четности. Для каждой
			// группы посчитать сумму входящих в нее элементов. Итоговая коллекция
			// должна содержать для каждой группы поле, с суммой группы.
			var iData = new int[n];
			for (var j = 0; j < n; j++)
				iData[j] = rnd.Next(-n, n);
			Console.WriteLine("Array: " + string.Join(", ", iData));
			var hQuery = from i in iData
				group i by (i % 2) * (i % 2)
				into parity
				select new {Parity = parity.Key, Numbers = parity.ToList(), Sum = parity.Sum()};
			foreach (var parity in hQuery)
			{
				Console.WriteLine(String.Format("Answer {0}: S : {1}, L : {2}",
					parity.Parity, parity.Sum, string.Join(", ", parity.Numbers)));
			}
		}

		class Worker
		{
			public string Name;
			public int Salary;

			public override string ToString()
			{
				return this.Name + " - " + this.Salary.ToString();
			}
		}

		static void K(int n)
		{
			Console.WriteLine("\nк");
			// k) Дана коллекция пар {Фамилия, Сумма} - Фамилия не ключевое поле
			// (т.е. значения в поле Фамилия повторяются в коллекции. Необходимо
			// составить итоговую коллекцию пар: {Фамилия, Сумма всех Сумм для
			// данной фамилии}
			var iData = new List<Worker>()
			{
				new Worker {Name = "Петров", Salary = 100},
				new Worker {Name = "Сидоров", Salary = 200},
				new Worker {Name = "Петров", Salary = 130}
			};
			Console.WriteLine("Array: " + string.Join(", ", iData));
			var iQuery = from p in iData
				group p by p.Name
				into g
				select new Worker {Name = g.Key, Salary = g.Sum(p => p.Salary)};
			foreach (var group in iQuery)
			{
				Console.WriteLine(String.Format("For {0}: Salary = {1}",
					group.Name, group.Salary));
			}
		}

		static void L(int n)
		{
			Console.WriteLine("\nл");
			var rnd = new Random();
			// l) Дана коллекция повторяющихя элементов. Необходимо составить
			// новую коллекцию, в которую попадут в одном экземпляре только элементы,
			// встречающиеся ровно три раза в исходной коллекции.
			var lData = new List<int>();
			for (var j = 0; j < 3 * n; j++)
				lData.Add(rnd.Next(-n, n));
			Console.WriteLine("Array: " + string.Join(", ", lData));
			var hQuery = from i in lData
				group i by i
				into g
				where g.Count() == 3
				select g.Key;
			Console.WriteLine("Answer: " + string.Join(", ", hQuery));
		}

		static void M(int n)
		{
			Console.WriteLine("\nм");
			var rnd = new Random();
			// m) Отсортировать коллекцию пар значений сначала по-первому элементу
			// по возрастанию, затем по-второму элементу по убыванию
			var mData = new List<Worker>()
			{
				new Worker {Name = "Петров", Salary = 100},
				new Worker {Name = "Иванов", Salary = 140},
				new Worker {Name = "Сидоров", Salary = 200},
				new Worker {Name = "Иванов", Salary = 180},
				new Worker {Name = "Петров", Salary = 130},
				new Worker {Name = "Петров", Salary = 110}
			};
			Console.WriteLine("Array: " + string.Join(", ", mData));
			var mQuery = mData.OrderBy(p => p.Name).ThenBy(p => -p.Salary);
			Console.WriteLine("Answer: " + string.Join(", ", mQuery));
		}

		class Triple
		{
			private int A;
			private int B;
			private int C;

			public Triple(int a, int b, int c)
			{
				this.A = a;
				this.B = b;
				this.C = c;
			}

			public override string ToString()
			{
				return String.Format("({0}, {1}, {2})", this.A, this.B, this.C);
			}
		}

		static void N(int n)
		{
			Console.WriteLine("\nн");
			var rnd = new Random();
			// n) Есть три коллекции arr1, arr2, arr3.
			// - Необходимо создать коллекцию, состоящую из всех возможных троек
			// элементов. Каждый элемент тройки представляет собой один элемент
			// из соответствующе коллекции.
			// - Преобразовать итоговую коллекцию в строку типа: (a1, b1, c1), (a2, b1, c1), ...
			var lData1 = new List<int>();
			var lData2 = new List<int>();
			var lData3 = new List<int>();
			for (var j = 0; j < (int) n / 3; j++)
			{
				lData1.Add(rnd.Next(-n, n));
				lData2.Add(rnd.Next(-n, n));
				lData3.Add(rnd.Next(-n, n));
			}

			Console.WriteLine("Array1: " + string.Join(", ", lData1));
			Console.WriteLine("Array2: " + string.Join(", ", lData2));
			Console.WriteLine("Array3: " + string.Join(", ", lData3));
			var hQuery = from i1 in lData1
				from i2 in lData2
				from i3 in lData3
				select new Triple(i1, i2, i3);
			Console.WriteLine("Answer: " + string.Join(", ", hQuery.ToList()));
		}

		static void Main(string[] args)
		{
			const int n = 10;

			A(n);
			B(n);
			C(n);
			D(n);
			E(n);
			F(n);
			H(n);
			I(n);
			K(n);
			L(n);
			M(n);
			N(n);
		}
	}
}