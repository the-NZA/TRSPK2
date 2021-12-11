using System;

namespace Task5_5
{
	class First : IDisposable
	{
		public void Dispose()
		{
			Console.WriteLine("First class disposed");
		}

		~First()
		{
			Console.WriteLine("First class finalized");
		}
	}

	class Second : IDisposable
	{
		private First First { get; set; }

		public Second()
		{
			First = new First();
		}

		public void Dispose()
		{
			First.Dispose();
			Console.WriteLine("Second class disposed");
		}

		~Second()
		{
			Console.WriteLine("Second class finalized");
		}
	}

	internal static class Program
	{
		static void Run()
		{
			using Second _ = new Second();
			Console.WriteLine("Doing some job");
		}

		private static void Main()
		{
			Run();
			
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}