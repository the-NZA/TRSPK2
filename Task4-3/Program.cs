using System;
using System.Diagnostics;
using System.Threading;

namespace Task4_3
{
	class Program
	{
		static readonly object PiLock = new object();
		static decimal _pi = 0.0M;
		private static long _threadCount = 0;

		private static void Сalculation(object o)
		{
			var iMin = ((int[]) o)[0];
			var iMax = ((int[]) o)[1];

			var delta = 0.0M;

			for (var i = iMin; i < iMax; i++)
			{
				var dx = 1.0M / (2 * i + 1);

				if (i % 2 == 0)
					delta += dx;
				else
					delta -= dx;
			}

			lock (PiLock)
			{
				_pi += delta;
			}

			Interlocked.Increment(ref _threadCount);
			//Console.WriteLine("End of " + iMin.ToString() + " - " + iMax.ToString() + " iterations");
		}

		static void Main(string[] args)
		{
			while (true)
			{
				_threadCount = 0;

				Console.Write("Enter number of threads: ");
				var countOfThread = int.Parse(Console.ReadLine() ?? string.Empty);

				Console.Write("Enter number of iterations: ");
				var countOfIterat = int.Parse(Console.ReadLine() ?? string.Empty);

				var delta = (double) countOfIterat / (double) countOfThread;

				Stopwatch stopWatch = new Stopwatch();
				stopWatch.Start();

				for (var i = 0; i < countOfThread; i++)
				{
					var iMin = (int) (delta * i);
					var iMax = (int) (delta * (i + 1));
					;

					ThreadPool.QueueUserWorkItem(Сalculation, new int[] {iMin, iMax});
				}

				while (Interlocked.Read(ref _threadCount) < countOfThread)
					Thread.Sleep(500);

				stopWatch.Stop();
				TimeSpan ts = stopWatch.Elapsed;
				string elapsedTime = String.Format("{0:00}.{1:000}", ts.Seconds, ts.Milliseconds);

				Console.WriteLine("Pi     = " + (_pi * 4));
				Console.WriteLine("Thread = " + countOfThread.ToString());
				Console.WriteLine("Iterat = " + countOfIterat.ToString());
				Console.WriteLine("Time   = " + elapsedTime);

				Console.WriteLine();
				_pi = 0.0M;
			}
		}
	}
}