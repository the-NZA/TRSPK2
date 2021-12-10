using System;
using System.Threading;

namespace Task5_3
{
	class MyClass
	{
		private readonly int _a; 
		public MyClass(int a)
		{
			Console.WriteLine($"{a} MyClass's constructor is called.");
			this._a = a;
		}

		public int GetA()
		{
			Console.WriteLine($"{_a} MyClass's method A is called.");
			return _a;
		}

		~MyClass()
		{
			Console.WriteLine($"{_a} MyClass's finalizer is called.");
		}
	}

	class Program
	{
		static void Method()
		{
			Console.WriteLine("Hello World!");

			const int n = 10;
			var m = new MyClass[n];

			for (var i = 0; i < n; i++)
				m[i] = new MyClass(i);

			var j = m[0].GetA();

			m = new MyClass[2];

			//System.GC.Collect();
			//System.GC.WaitForPendingFinalizers();

			Console.WriteLine("Bye World!");
		}

		static void Main()
		{
			Method();

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}