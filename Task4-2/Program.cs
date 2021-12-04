using System;
using System.Threading;

// Создать "производственную линию". 
//
//	- Продукт А производится со скоростью 0.8 
//	- Продукт Б производится со скоростью 1.5 
//	- Продукт В производится со скоростью 3.3 
//	- Продукт М производится со скоростью 2.5 из продуктов А и Б 
//	- Продукт Н производится со скоростью 4.5 из продуктов В и М
//
// Предусмотреть работу линии с буфером для накопления готовой продукции и без буфера.
// Показать, как "работает" линия включая объем очереди. 

namespace Task4_2
{
	class Product
	{
		public readonly ProductType Type;
		private readonly int _productionTime;

		public Product(ProductType type)
		{
			Type = type;
			_productionTime = Helpers.ProductionTimeByType(type);
		}

		public void Produce()
		{
			Thread.Sleep(_productionTime);
		}
	}

	class ProducerUnbuf
	{
		private int _queueLength;

		private readonly Random _rndm;
		private readonly object _lckr = new();
		private readonly AutoResetEvent _waitA = new(false);
		private readonly AutoResetEvent _waitB = new(false);
		private readonly AutoResetEvent _waitC = new(false);
		private readonly AutoResetEvent _waitM = new(false);

		public ProducerUnbuf()
		{
			_rndm = new Random();
			_queueLength = 0;
		}

		public void Start(int cnt)
		{
			Console.WriteLine("--- Unbuffered producer started ---\n");
			while (cnt >= 0)
			{
				DisplayQueueStatus();

				// Random product type
				ProductType type = (ProductType) _rndm.Next(0, 5);

				// Create new product
				var p = new Product(type);

				// Enqueue it to the production line
				ThreadPool.QueueUserWorkItem(ProduceProduct, p);

				// Wait some time and go further
				Thread.Sleep(500);

				cnt--;
			}

			Console.WriteLine(
				"\n--- Unbuffered producer stopped. Look at number of items are left in queue. ---");
			DisplayQueueStatus();
			Console.WriteLine();
		}

		private void DisplayQueueStatus()
		{
			lock (_lckr)
			{
				Console.WriteLine($"[QUEUE STATUS] Number of items in queue now: {_queueLength}");
			}
		}

		private void Dequeue()
		{
			lock (_lckr)
			{
				_queueLength--;
			}
		}

		private void ProduceProduct(object obj)
		{
			var prod = (Product) obj;

			lock (_lckr)
			{
				_queueLength++;
			}

			switch (prod.Type)
			{
				case ProductType.A:
					prod.Produce();

					_waitA.Set();

					Dequeue();

					Console.WriteLine($"Product {prod.Type} is built");

					break;

				case ProductType.B:
					prod.Produce();

					_waitB.Set();

					Dequeue();

					Console.WriteLine($"Product {prod.Type} is built");

					break;

				case ProductType.C:
					prod.Produce();

					_waitC.Set();

					Dequeue();

					Console.WriteLine($"Product {prod.Type} is built");

					break;

				case ProductType.M:
					Console.WriteLine($"Product {prod.Type} is waiting for A and B...");

					WaitHandle.WaitAll(new WaitHandle[] {_waitA, _waitB});

					prod.Produce();

					_waitM.Set();

					Dequeue();

					Console.WriteLine($"Product {prod.Type} is built");

					break;

				case ProductType.N:
					Console.WriteLine($"Product {prod.Type} is waiting for M and C...");

					WaitHandle.WaitAll(new WaitHandle[] {_waitC, _waitM});

					prod.Produce();

					Dequeue();

					Console.WriteLine($"Product {prod.Type} is built");

					break;
			}
		}
	}

	class Producer
	{
		private int _queueLength;

		private readonly Random _rndm;
		private readonly object _lckr = new();
		private readonly AutoResetEvent _waitA = new(false);
		private readonly AutoResetEvent _waitB = new(false);
		private readonly AutoResetEvent _waitC = new(false);
		private readonly AutoResetEvent _waitM = new(false);

		private int[] _buffer;

		public Producer()
		{
			_rndm = new Random();
			_queueLength = 0;

			_buffer = new[] {0, 0, 0, 0, 0};
		}

		public void Start(int cnt)
		{
			Console.WriteLine("--- Buffered producer started ---\n");
			while (cnt >= 0)
			{
				DisplayQueueStatus();

				// Random product type
				ProductType type = (ProductType) _rndm.Next(0, 5);

				// Create new product
				var p = new Product(type);

				// Enqueue it to the production line
				ThreadPool.QueueUserWorkItem(ProduceProduct, p);

				// Wait some time and go further
				Thread.Sleep(500);

				cnt--;
			}

			Console.WriteLine(
				"\n--- Buffered producer stopped. Look at number of items are left in queue. ---");
			DisplayQueueStatus();
			lock (_buffer)
			{
				Console.WriteLine($"Produced items: {_buffer.FormatedString()}");
			}
		}

		private void SaveProduct(ProductType p)
		{
			lock (_buffer)
			{
				_buffer[(int) p]++;
			}
		}

		private void UseProduct(ProductType p)
		{
			// bool hasItem = false;
			// lock (_buffer)
			// {
			// 	if (_buffer[(int) p] > 0)
			// 	{
			// 		_buffer[(int) p]--;
			// 		return;
			// 	}
			//
			// 	hasItem = false;
			// }

			while (true)
			{
				lock (_buffer)
				{
					if (_buffer[(int) p] > 0)
					{
						_buffer[(int) p]--;
						return;
					}
				}

				Thread.Sleep(50);
			}
		}

		private void DisplayQueueStatus()
		{
			lock (_lckr)
			{
				Console.WriteLine($"[QUEUE STATUS] Number of items in queue now: {_queueLength}");
			}
		}

		private void Dequeue()
		{
			lock (_lckr)
			{
				_queueLength--;
			}
		}

		private void ProduceProduct(object obj)
		{
			var prod = (Product) obj;

			lock (_lckr)
			{
				_queueLength++;
			}

			switch (prod.Type)
			{
				case ProductType.A:
					prod.Produce();
					SaveProduct(prod.Type);

					_waitA.Set();

					break;

				case ProductType.B:
					prod.Produce();
					SaveProduct(prod.Type);

					_waitB.Set();

					break;

				case ProductType.C:
					prod.Produce();
					SaveProduct(prod.Type);

					_waitC.Set();

					break;

				case ProductType.M:
					bool hasA = false, hasB = false;

					lock (_lckr)
					{
						if (_buffer[(int) ProductType.A] > 0)
						{
							hasA = true;
							UseProduct(ProductType.A);
						}
					}

					lock (_lckr)
					{
						if (_buffer[(int) ProductType.B] > 0)
						{
							hasB = true;
							UseProduct(ProductType.B);
						}
					}

					if (!hasA && !hasB)
					{
						Console.WriteLine($"Product {prod.Type} is waiting for A and B...");
						WaitHandle.WaitAll(new WaitHandle[] {_waitA, _waitB});
						UseProduct(ProductType.A);
						UseProduct(ProductType.B);
					}
					else if (!hasA)
					{
						Console.WriteLine($"Product {prod.Type} is waiting for A...");
						_waitA.WaitOne();
						UseProduct(ProductType.A);
					}
					else if (!hasB)
					{
						Console.WriteLine($"Product {prod.Type} is waiting for B...");
						_waitB.WaitOne();
						UseProduct(ProductType.B);
					}


					prod.Produce();

					SaveProduct(prod.Type);

					_waitM.Set();

					break;

				case ProductType.N:
					bool hasM = false, hasC = false;

					lock (_lckr)
					{
						if (_buffer[(int) ProductType.C] > 0)
						{
							hasC = true;
							UseProduct(ProductType.C);
						}
					}

					lock (_lckr)
					{
						if (_buffer[(int) ProductType.M] > 0)
						{
							hasM = true;
							UseProduct(ProductType.M);
						}
					}

					if (!hasC && !hasM)
					{
						Console.WriteLine($"Product {prod.Type} is waiting for M and C...");
						WaitHandle.WaitAll(new WaitHandle[] {_waitC, _waitM});

						UseProduct(ProductType.C);
						UseProduct(ProductType.M);
					}
					else if (!hasC)
					{
						Console.WriteLine($"Product {prod.Type} is waiting for C...");
						_waitA.WaitOne();
						UseProduct(ProductType.C);
					}
					else if (!hasM)
					{
						Console.WriteLine($"Product {prod.Type} is waiting for M...");
						_waitB.WaitOne();
						UseProduct(ProductType.M);
					}

					prod.Produce();

					SaveProduct(prod.Type);

					break;
			}

			Console.WriteLine($"Product {prod.Type} is built");

			Dequeue();
		}
	}

	class Program
	{
		static void Main()
		{
			try
			{
				Console.Write("Choose 0 – for unbuffered option and 1 – for buffered option\n> ");
				var s = Console.ReadLine() ?? string.Empty;
				
				switch (int.Parse(s))
				{
					case 0:
						var producerUnbuf = new ProducerUnbuf();
						producerUnbuf.Start(50);

						break;
					case 1:
						var producer = new Producer();
						producer.Start(50);
						
						break;
					default:
						Console.WriteLine("Entered unsupported option");
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}