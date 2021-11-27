using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

// Посчитать сумму чисел от 1 до 1000000 
// используя от 1 до 100 потоков - показать
// скорость счета для каждого случая 

namespace Task3_5
{
	public sealed class Solver : IDisposable
	{
		private readonly Thread[] _threads; // Threads pool
		private readonly Queue<int> _tsks; // Tasks queue

		private bool _disableAdding; // set to true when disposing queue but there are still tasks pending
		private bool _disposed; // set to true when disposing queue and no more tasks are pending

		private long _sum; // sum of numbers from 1 up to 1000000

		private readonly object _locker = new(); // locker object for summarising 
		private readonly Stopwatch _timer; // simple timer

		public Solver(int size)
		{
			_timer = new Stopwatch();
			_timer.Start();

			_threads = new Thread[size];
			_tsks = new Queue<int>();
			_sum = 0;

			// init threads pool
			for (var i = 0; i < _threads.Length; ++i)
			{
				var worker = new Thread(Worker);
				worker.Start();

				_threads[i] = worker;
			}
		}

		public void Dispose()
		{
			var waitForThreads = false;
			lock (_tsks)
			{
				if (!_disposed)
				{
					// wait for all current tasks finishes 
					// disable adding for this moment
					_disableAdding = true;
					while (_tsks.Count > 0)
					{
						Monitor.Wait(_tsks);
					}

					// notify all threads
					_disposed = true;
					Monitor.PulseAll(_tsks);

					waitForThreads = true;
				}
			}

			_timer.Stop();

			Console.WriteLine(
				$"Sum is {_sum} with {_threads.Length} threads and time spent {_timer.Elapsed:m\\:ss\\.fff}"
			);
			if (waitForThreads)
			{
				foreach (var t in _threads)
				{
					t.Join();
				}
			}
		}

		public void QueueTask(int task)
		{
			lock (_tsks)
			{
				if (_disableAdding)
				{
					throw new InvalidOperationException(
						"This instance is in the process of being disposed, can't add anymore"
					);
				}

				if (_disposed)
				{
					throw new ObjectDisposedException("This instance has already been disposed");
				}


				_tsks.Enqueue(task); // Add new task to queue 
				Monitor.PulseAll(_tsks); // notify all threads
			}
		}

		private void Worker()
		{
			while (true) // loop until disposed
			{
				int task; // current task
				
				lock (_tsks) // finding new task
				{
					while (true) // wait for our turn in _threads and an available task
					{
						// get end event
						if (_disposed)
						{
							return;
						}

						if (_tsks.Count > 0)
						{
							task = _tsks.Dequeue(); // get new task from queue

							// notify threads about change
							Monitor.PulseAll(_tsks);

							break;
						}

						// wait until new task or current thread turn
						Monitor.Wait(_tsks);
					}
				}

				AddToSum(task); // process found task
			}
		}

		private void AddToSum(int num)
		{
			lock (_locker)
			{
				_sum += num;
			}
		}
	}


	public static class Program
	{
		static void Main()
		{
			try
			{
				Random rndm = new Random();
				using (var slvr = new Solver(rndm.Next(1, 101)))
				{
					for (var i = 1; i <= 1000000; ++i)
					{
						slvr.QueueTask(i);
					}
				}

				using (var slvr = new Solver(rndm.Next(1, 101)))
				{
					for (var i = 1; i <= 1000000; ++i)
					{
						slvr.QueueTask(i);
					}
				}

				using (var slvr = new Solver(rndm.Next(1, 101)))
				{
					for (var i = 1; i <= 1000000; ++i)
					{
						slvr.QueueTask(i);
					}
				}

				using (var slvr = new Solver(rndm.Next(1, 101)))
				{
					for (var i = 1; i <= 1000000; ++i)
					{
						slvr.QueueTask(i);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}