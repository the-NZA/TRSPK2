using System;
using System.Collections;
using System.Collections.Generic;

namespace Task5_2
{
	class A
	{
		public int Avar;
		public long Bvar;
		public double Cvar;

		public A()
		{
			Avar = int.MaxValue;
			Bvar = long.MaxValue;
			Cvar = Double.MaxValue;
		}
	}

	class B : A
	{
		public string Str;

		public B()
		{
			Str = "Test string";
		}
	}

	class C : B
	{
		public string[] StringArr;

		public C()
		{
			StringArr = new[] {"First", "Second", "Third"};
		}
	}

	struct D
	{
		public int P1;
		public long P2;
		public string P3;

		public D(int p1, long p2, string p3)
		{
			P1 = p1;
			P2 = p2;
			P3 = p3;
		}
	}

	class F
	{
		public D Dvar1;
		public D Dvar2;

		public F()
		{
			Dvar1 = new D();
			Dvar2 = new D();
		}

		public F(D d1, D d2)
		{
			Dvar1 = d1;
			Dvar2 = d2;
		}
	}

	class G
	{
		public D Dvar;
		public F Fvar;
		public C Cvar;

		public G()
		{
			Dvar = new D();
			Fvar = new F();
			Cvar = new C();
		}
	}

	class Solver
	{
		void f()
		{
			Console.WriteLine("F:");
			var a = new F();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)}");

			var b = new F[500];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №2");

			var c = new Queue<D>(5000);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №3");

			var d = new List<long>(200);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №4");

			var e = new C();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №5");

			var f = new double[100];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №6");

			var g = new B();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №7");

			var h = new A();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №8");

			var j = new Dictionary<string, G[]>(1000);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №9");

			var k = new ArrayList(50);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №10");

			var l = new byte[10000];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №11");

			var m = new int[22000];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №12");

			var gg = new G();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №13");

			var a1 = new F[100];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №14");

			var b1 = new List<Queue<D>>(1000);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №14");
		}

		void fgc()
		{
			Console.WriteLine("FGC:");

			var a = new F();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)}");
			GC.Collect();

			var b = new F[500];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №2");
			GC.Collect();

			var c = new Queue<D>(5000);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №3");
			GC.Collect();

			var d = new List<long>(200);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №4");
			GC.Collect();

			var e = new C();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №5");
			GC.Collect();

			var f = new double[100];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №6");
			GC.Collect();

			var g = new B();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №7");
			GC.Collect();

			var h = new A();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №8");
			GC.Collect();

			var j = new Dictionary<string, G[]>(1000);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №9");
			GC.Collect();

			var k = new ArrayList(50);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №10");
			GC.Collect();

			var l = new byte[10000];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №11");
			GC.Collect();

			var m = new int[22000];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №12");
			GC.Collect();

			var gg = new G();
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №13");
			GC.Collect();

			var a1 = new F[100];
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №14");
			GC.Collect();

			var b1 = new List<Queue<D>>(1000);
			Console.WriteLine($"a's gen {GC.GetGeneration(a)} №14");
		}

		void generate(int op)
		{
			switch (op)
			{
				case 0:
					var a = new F();
					break;
				case 1:
					var b = new F[500];
					break;
				case 2:
					var c = new Queue<D>(5000);
					break;
				case 3:
					var d = new List<long>(200);
					break;
				case 4:
					var e = new C();
					break;
				case 5:
					var f = new double[100];
					break;
				case 6:
					var g = new B();
					break;
				case 7:
					var h = new A();
					break;
				case 8:
					var j = new Dictionary<string, G[]>(1000);
					break;
				case 9:
					var k = new ArrayList(50);
					break;
				case 10:
					var l = new byte[10000];
					break;
				case 11:
					var m = new int[22000];
					break;
				default:
					var gg = new G();
					break;
			}
		}

		public void Zero()
		{
			f();
			Console.WriteLine("");

			fgc();
			Console.WriteLine("");
		}

		public void First(bool singleLoop, int iterations)
		{
			var firstObj = new G();
			Console.WriteLine("Generation of firstObj: {0}", GC.GetGeneration(firstObj));

			Random rndm = new Random();
			int upperBound = 13;

			for (int i = 0; i < iterations; ++i)
			{
				var op = rndm.Next(0, upperBound);

				generate(op);

				Console.WriteLine("Generation of firstObj: {0} after iteration № {1}",
					GC.GetGeneration(firstObj), i + 1);
			}

			Console.WriteLine("Generation of firstObj: {0} after all iteratios without GC.Collect()",
				GC.GetGeneration(firstObj));

			GC.Collect();

			Console.WriteLine("Generation of firstObj: {0} after all iteratios with GC.Collect()",
				GC.GetGeneration(firstObj));

			if (singleLoop)
			{
				return;
			}

			for (int i = 0; i < 20; ++i)
			{
				var op = rndm.Next(0, upperBound);
				generate(op);

				Console.WriteLine("Generation of firstObj: {0} after iteration № {1}",
					GC.GetGeneration(firstObj), i + 1);
			}

			Console.WriteLine("Generation of firstObj: {0} after all iteratios №2 without GC.Collect()",
				GC.GetGeneration(firstObj));

			GC.Collect();

			Console.WriteLine("Generation of firstObj: {0} after all iteratios №2 with GC.Collect()",
				GC.GetGeneration(firstObj));

			for (int i = 0; i < 30; ++i)
			{
				var op = rndm.Next(0, upperBound);
				generate(op);

				Console.WriteLine("Generation of firstObj: {0} after iteration № {1}",
					GC.GetGeneration(firstObj), i + 1);
			}

			Console.WriteLine("Generation of firstObj: {0} after all iteratios №3 without GC.Collect()",
				GC.GetGeneration(firstObj));

			GC.Collect();

			Console.WriteLine("Generation of firstObj: {0} after all iteratios №3 with GC.Collect()",
				GC.GetGeneration(firstObj));
		}

		public void Second()
		{
			Console.WriteLine("Max generation is {0}", GC.MaxGeneration);

			var largeByteArr = new byte[85000];
			Console.WriteLine("ByteArr gc gene: {0}", GC.GetGeneration(largeByteArr));

			var largeIntArr = new int[30000];
			Console.WriteLine("ByteArr gen: {0}, IntArr gen: {1}", GC.GetGeneration(largeByteArr),
				GC.GetGeneration(largeIntArr));

			var largeDoubleArr = new double[30000];
			Console.WriteLine("ByteArr gen: {0}, IntArr gen: {1}, DoubleArr: {2}",
				GC.GetGeneration(largeByteArr),
				GC.GetGeneration(largeIntArr), GC.GetGeneration(largeDoubleArr));

			GC.Collect();
			Console.WriteLine("ByteArr gen: {0}, IntArr gen: {1}, DoubleArr: {2} after GC.Collect()",
				GC.GetGeneration(largeByteArr),
				GC.GetGeneration(largeIntArr), GC.GetGeneration(largeDoubleArr));

			GC.Collect();
			Console.WriteLine("ByteArr gen: {0}, IntArr gen: {1}, DoubleArr: {2} after GC.Collect() №2",
				GC.GetGeneration(largeByteArr),
				GC.GetGeneration(largeIntArr), GC.GetGeneration(largeDoubleArr));
		}
	}

	class Program
	{
		static void Main()
		{
			var slvr = new Solver();
			int iterations = 30;
			
			slvr.Zero();
			
			slvr.First(true, iterations);
			Console.WriteLine("\n---");
			slvr.First(false, iterations);

			Console.WriteLine("\n---");
			slvr.Second();
		}
	}
}