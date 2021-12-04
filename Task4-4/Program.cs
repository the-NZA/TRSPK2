using System;
using System.Diagnostics;
using System.Linq;

namespace Task4_4
{
	class Program
	{
		static int Calc(int x) => x + (x % 10 / 10);
        
		static void Main()
		{
			var n = 200;
			var data = new int[n];
			var degreeValyes = new int[] {1, 2, 3, 4, 5, 8, 10, 20};
			var stopWatch = new Stopwatch();

			var rand = new Random();
			for (var i = 0; i < n; i++)
				data[i] = rand.Next(100);
			Console.WriteLine(string.Join(", ", data));

			// WithDegreeOfParallelism(2)
			foreach (var degree in degreeValyes)
			{
				Console.WriteLine();
                
				stopWatch.Restart();
				var query = data.AsParallel().WithDegreeOfParallelism(degree).
					Select( x => Calc(x)).
					GroupBy(x => x%10).
					Select( g => g.Sum()).
					OrderBy(x => x).
					Skip(4).Take(3);
				/*
				stopWatch.Stop();
				TimeSpan ts = stopWatch.Elapsed;
				string elapsedTime = String.Format("{0:00}.{1:000}", ts.Seconds, ts.Milliseconds);
				*/
				Console.Write("Result: ");
				foreach (var i in query)
					Console.Write(i.ToString()+" ");
				Console.WriteLine();
				stopWatch.Stop();
				
				TimeSpan ts = stopWatch.Elapsed;
				string elapsedTime = string.Format("{0:00}.{1:000}", ts.Seconds, ts.Milliseconds);
				
				Console.WriteLine("Time  : " + elapsedTime);
				Console.WriteLine("Degree: " + degree.ToString());
			}


		}
	}
}