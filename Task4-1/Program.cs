using System;
using System.Diagnostics;
using System.Threading;

namespace Task4_1
{
	class Program
	{
		static void Main()
		{
			int threadCnt = 10;

			for (threadCnt = 1; threadCnt < 20; threadCnt++)
			{
				// Benchmark standard threads
				CountdownEvent ce1 = new CountdownEvent(threadCnt);
				Stopwatch timer = new Stopwatch();

				timer.Start();
				for (int i = 0; i < threadCnt; i++)
				{
					var t = new Thread(ThreadFunc);
					t.Start(ce1);
				}

				ce1.Wait();
				timer.Stop();

				Console.WriteLine($"Standard threads time is: {timer.ElapsedMilliseconds}");

				// Benchmark thread pool
				ce1 = new CountdownEvent(threadCnt);

				timer.Restart();
				for (int i = 0; i < threadCnt; i++)
				{
					ThreadPool.QueueUserWorkItem(ThreadFunc, ce1);
				}

				ce1.Wait();
				timer.Stop();

				Console.WriteLine($"ThreadPool time is: {timer.ElapsedMilliseconds}");
			}
		}

		static void ThreadFunc(object obj)
		{
			for (int i = 0; i < 1000000; i++)
			{
				
			}
			((CountdownEvent) obj).Signal();
		}
	}
}