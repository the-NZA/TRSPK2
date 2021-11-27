using System;
using System.Threading;
using System.Collections.Generic;

namespace Task3_3
{
	class Program
	{
		static int global = 0;
		private static object locker = new();

		static Dictionary<string, int> threads = new Dictionary<string, int>
		{
			{"Main", 305},
			{"Second", 310},
			{"Third", 315}
		};

		static void Main(string[] args)
		{
			// создаем новые потоки и запускаем параллельно

			Thread secondThread = new Thread(new ThreadStart(Count));
			secondThread.Name = "Second";
			secondThread.Start();

			Thread thirdThread = new Thread(new ThreadStart(Count));
			thirdThread.Name = "Third";
			thirdThread.Start();

			for (int i = 0; i < 9; i++)
			{
				lock (locker)
				{
					global++;
					Console.WriteLine($"Main - {global}");
					Thread.Sleep(threads["Main"]);
				}
			}
		}

		public static void Count()
		{
			for (int i = 0; i < 9; i++)
			{
				lock (locker)
				{
					global++;
					string threadName = Thread.CurrentThread.Name;
					Console.WriteLine($"{threadName} - {global}");
					Thread.Sleep(threads[threadName]);
				}
			}
		}
	}
}