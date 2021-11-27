using System;
using System.Threading;

namespace Task3_2
{
	class Program
	{
		private static readonly ManualResetEvent Wh = new(false);
		static void ThreadFunc()
		{
			Wh.WaitOne();
			Console.WriteLine($"Thred {Thread.CurrentThread.Name} says hello");
		}

		static void Main()
		{
			int tCnt = 5;
			Thread[] threads = new Thread[tCnt];

			for (int i = 0; i < tCnt; i++)
			{
				threads[i] = new Thread(ThreadFunc)
				{
					Name = (i + 1).ToString(),
				};
			}

			foreach (var thread in threads)
			{
				thread.Start();
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
			
			Wh.Set();

			foreach (var thread in threads)
			{
				thread.Join();
			}

			Console.WriteLine("\nMain done");
		}
	}
}