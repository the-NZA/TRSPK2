using System;
using System.Threading;

/*
Одновременный финиш потоков. Сделать потоки,
которые запускаются и ждут какого-то события,
приходящего извне. После события, потоки
печатают на экран факт того, что они завершаются
и рандомно "задерживаются" на время от 1 до 10
секунд. Основная программа должна подождать
окончания выполнения всех потоков для своего
завершения.
*/

namespace Task3_6
{
	class Program
	{
		private static EventWaitHandle ewh;
		private static long threadCount = 0;

		public static void Finish()
		{
			Interlocked.Increment(ref threadCount);

			// wait signal
			ewh.WaitOne();
			// print name
			Console.WriteLine($"Finish of {Thread.CurrentThread.Name}");
			// pause
			var rand = new Random();
			var pause = rand.Next(1, 10) * 1000;
			Console.WriteLine($"Pause  of {Thread.CurrentThread.Name} is {pause}");
			Thread.Sleep(pause);
			// finish
			Interlocked.Decrement(ref threadCount);
			//clearCount.Set();
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!\n");

			var n = 10;

			ewh = new ManualResetEvent(false);

			// create thread
			for (int i = 0; i < n; i++)
			{
				Thread myThread = new Thread(new ThreadStart(Finish));
				myThread.Name = "Thread_" + i;
				myThread.Start();
			}

			// wait of start of thread
			while (Interlocked.Read(ref threadCount) < n)
			{
				Thread.Sleep(500);
			}

			// finish thread
			ewh.Set();

			// wait of finish of thread
			while (Interlocked.Read(ref threadCount) > 0)
			{
				Thread.Sleep(500);
			}

			Console.WriteLine("Bye World!");
		}
	}
}