using System;
using System.Threading;

// Показать, как работают параллельные потоки. 
// Создать три потока, показать попеременный вывод  на консоль из них. 
// Сделать потоки бэкграунд-потоками и посмотреть, что будет теперь. 
// Сделать поток (или несколько потоков), которые не заканчивают выполнение (сделать в 
// функции потока while(true). Посмотреть на 
// загрузку процессора и показать, как можно снизить на него нагрузку. 

namespace Task3_1
{
	class Program
	{
		static void Print()
		{
			Console.WriteLine("Print{0}() running on {0} Thread", Thread.CurrentThread.Name);
			for (int i = 1; i < 10; i++)
			{
				Console.WriteLine("Executing Print{0}.... ", Thread.CurrentThread.Name);
				Thread.Sleep(1000);
			}
		}

		static void Delay()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"Running {i + 1}...");
				Thread.Sleep(500);
			}
		}

		static void RunningForegroundThread()
		{
			Thread foreground = new Thread(Delay);
			foreground.Start();
		}

		static void RunningBackgroundThread()
		{
			Thread background = new Thread(Delay);
			background.IsBackground = true;
			background.Start();
		}

		static void RunningInfiniteLoop()
		{
			Thread t = new Thread(() =>
			{
				while (true)
				{
					Console.WriteLine("Infinite loop...");
					Thread.Sleep(100);
				}
			});
			t.Start();

			t.Join();
		}

		static void RunningInfiniteWithWaitLoop()
		{
			AutoResetEvent wh = new AutoResetEvent(false);

			Thread t = new Thread(() =>
			{
				while (true)
				{
					wh.WaitOne();
					Console.WriteLine("Infinite loop...");
				}
			});
			t.Start();

			for (int i = 0; i < 5; i++)
			{
				wh.Set();
				Thread.Sleep(150);
			}

			t.Join();
		}

		static void Main()
		{
			Thread t1 = new Thread(Print);
			Thread t2 = new Thread(Print);
			Thread t3 = new Thread(Print);

			t1.Name = "First";
			t2.Name = "Second";
			t3.Name = "Third";

			Console.WriteLine("Select option: \n");
			Console.WriteLine("1. To Run 3 Threads Parrelly");
			Console.WriteLine("2. Foreground Vs Background");
			Console.WriteLine("3. With infinite loop");

			Console.Write("\nEnter number: ");
			int choice = int.Parse(Console.ReadLine() ?? string.Empty);
			Console.WriteLine();

			int number;
			switch (choice)
			{
				case 1:
					t1.Start();
					t2.Start();
					t3.Start();

					break;
				case 2:
					Console.WriteLine("=========== Foreground Vs Background ==========\n");
					Console.WriteLine("Enter 1 to start foreground and 2 to start background: ");

					number = int.Parse(Console.ReadLine() ?? string.Empty);
					Console.WriteLine();

					switch (number)
					{
						case 1:
							RunningForegroundThread();
							break;
						case 2:
							RunningBackgroundThread();
							break;
						default:
							Console.WriteLine("Wrong number");
							break;
					}

					break;

				case 3:
					Console.WriteLine(
						"=========== Infinite loop Vs Fixed infinite loop ==========\n");
					Console.WriteLine("Enter 1 to start thread with infinite loop" +
					                  " and 2 to start fixed thread: ");

					number = int.Parse(Console.ReadLine() ?? string.Empty);
					Console.WriteLine();

					switch (number)
					{
						case 1:
							RunningInfiniteLoop();
							break;
						case 2:
							RunningInfiniteWithWaitLoop();
							break;
						default:
							Console.WriteLine("Wrong number");
							break;
					}

					break;
			}


			Console.WriteLine("Main done");
		}
	}
}