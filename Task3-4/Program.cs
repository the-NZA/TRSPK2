using System;
using System.Threading;


namespace Task3_4
{
	class Program
	{
		static void Main(string[] args)
		{
			// создаем новые потоки и запускаем параллельно

			Thread firstThread = new Thread(new ThreadStart(Name));
			firstThread.Name = "1";
			firstThread.Start();

			Thread secondThread = new Thread(new ThreadStart(Name));
			secondThread.Name = "2";
			secondThread.Start();

			Thread thirdThread = new Thread(new ThreadStart(Name));
			thirdThread.Name = "3";
			thirdThread.Start();
		}


		public static void Name()
		{
			for (int i = 1; i < 100; i++)
			{
				if ((i % 4).ToString() == Thread.CurrentThread.Name)
				{
					Console.WriteLine(Thread.CurrentThread.Name);
				}

				Thread.Sleep(600);
			}
		}
	}
}