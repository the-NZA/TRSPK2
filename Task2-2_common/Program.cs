using System;
using System.Text;

namespace Task2_2_common
{
	class Program
	{
		static void Main()
		{
			Solver slv = new Solver();
			int[] intArr = new int[] {234, 1, 23, 98, 83, 255, 5, 10, 36};
			S[] sArr =
			{
				new S(1, 2),
				new S(4, 1),
				new S(23, 12),
				new S(51, 92),
				new S(123, 0)
			};
			STwo[] sTwoArr =
			{
				new STwo(1, 2.23),
				new STwo(4, 1.87),
				new STwo(23, 12.01),
				new STwo(51, 62.00),
				new STwo(123, -123.2)
			};

			// а)
			Console.WriteLine($"Max num in intArr: {slv.FindMax(intArr)}\n---");

			// б)
			Console.WriteLine($"Max num index in intArr: {slv.FindMaxIndex(intArr)}\n---");

			// в)
			Console.WriteLine($"Max item by field Y: {slv.FindMaxByY(sArr)}\n---");

			// г)
			var sThreeArr = slv.SortByYAndTransform(sTwoArr);
			foreach (var s in sThreeArr)
			{
				Console.WriteLine(s);
			}

			Console.WriteLine("---");

			// д)
			uint[] uintArr1 = {234, 2, 1, 5, 9, 3, 8};
			uint[] uintArr2 = {8, 9, 3, 7, 2, 1, 0};
			var resD = slv.GetPairsDivisibleByFive(uintArr1, uintArr2);
			if (resD == null || resD.Count < 1)
			{
				Console.WriteLine("There is no pairs divisible by 5\n---");
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendJoin(",", resD);
				sb.Append("\n---");
				Console.Write("Pairs divisible by 5: {0}\n", sb);
			}

			// е)
			string[] stringArr =
			{
				"Оттепель", "вода",
				"маторный", "открытый",
				"антибиотик", "домашний",
				"ковид", "бегемот"
			};

			var resS = slv.GetSortedWordsWithOt(stringArr);
			if (resS == null || resS.Length < 1)
			{
				Console.WriteLine("There is no words with 'от'\n---");
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendJoin(",", resS);
				sb.Append("\n---");
				Console.Write("There are words with 'от': {0}\n", sb);
			}

			// ж)
			string s1 = "asdf";
			string s2 = "fdsa";
			string s3 = "sdfg";
			string s4 = "fDsA";
			Console.WriteLine($"Are s1 and s2 reversly equal? {slv.IsReverseStrings(s1, s2)}");
			Console.WriteLine($"Are s1 and s3 reversly equal? {slv.IsReverseStrings(s1, s3)}");
			Console.WriteLine($"Are s1 and s4 reversly equal? {slv.IsReverseStrings(s1, s4)}\n---");

			// з)
			int[] intArr2 = {2, 12, -2, 3, 0, 24, 1, 13, 5, 7, 4, 8, 22};
			StringBuilder sbb = new StringBuilder();
			Console.WriteLine(sbb.AppendJoin(",", intArr2));
			slv.GroupAndSort(intArr2);
			sbb.Clear().AppendJoin(",", intArr2).Append("\n---");
			Console.WriteLine(sbb);

			// и)
			int[] intArr3 = {2, 12, -2, 3, 0, 24, 1, 13, 5, 7, 4, 8, 22};
			var resI = slv.GroupAndSum(intArr3);
			Console.WriteLine("{0}\n---", resI);

			// к)
			Worker[] workers = new Worker[]
			{
				new Worker("Петров", 100),
				new Worker("Иванов", 200),
				new Worker("Сидоров", 130),
				new Worker("Петров", 110),
				new Worker("Сидоров", 100),
				new Worker("Петров", 150),
			};
			var resW = slv.CalcSumByName(workers);
			foreach (var worker in resW)
			{
				Console.WriteLine($"Name {worker.Name} with summarized Salary {worker.Salary}");
			}

			// л)
			double[] doubleArr = new[]
			{
				234.01, 1.11, 2.53, 8.25, 9.12,
				1.11, 9.12, 1.11, 234.02, 65.2,
				9.12, 34.2, 34.2, 34.2, 34.2
			};
			var resDbl = slv.FilterIfRepeatThreeTimes(doubleArr);
			Console.WriteLine("---\nRepeated straight three times: {0}\n---",
				sbb.Clear().AppendJoin(",", resDbl));

			// м)
			(int, int)[] pairsArr =
			{
				(23, 1), (2, 5), (3, 9), (4, 99), (1, 2), (0, -1), (13, 22), (4, 5), (6, 6)
			};
			slv.SortPairsByBothFields(pairsArr);
			Console.WriteLine("Sorted by first field ASC and then by second field DESC");
			foreach (var pair in pairsArr)
			{
				Console.WriteLine(pair);
			}
			
			// н)
			var resTriples = slv.GetTripples(10);
			Console.WriteLine("Triples:");
			Console.WriteLine(String.Join(",", resTriples));
		}
	}
}