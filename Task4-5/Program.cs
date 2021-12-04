using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Task4_5
{
	class Program {
		static void Main()
		{
			var rand = new Random();
			List<string> randomNums = new List<string>();
			List<List<string>> listOfLists = new List<List<string>>();
			for (int i=0; i< 100; i++) 
			{
				randomNums.Add(rand.Next(1000).ToString());
			}

			for (int i=0; i<10; i++) {
				List<string> listik = new List<string>();
				for (int j=i*10; j < i*10 + 10; j++) {
					listik.Add(randomNums[j]);
				}
				listOfLists.Add(listik);
			}

			ParallelLoopResult result = Parallel.ForEach<List<string>>(
				listOfLists,
				WriteToFile);  
		}

		static void WriteToFile(List<string> x)
		{
			string path = $"file_{Task.CurrentId}.txt";
			using(var tw = new StreamWriter(path))
			{
				tw.WriteLine(string.Join(", ", x));
			}
			Console.WriteLine($"File {path}");
			Thread.Sleep(7000);
		}
	}
}