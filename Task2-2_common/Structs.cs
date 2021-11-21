using System;

namespace Task2_2_common
{
	public struct S
	{
		public int X;
		public int Y;

		public S(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"X:{X}, Y:{Y}";
		}
	}

	public struct STwo : IComparable
	{
		public int X;
		public double Y;

		public STwo(int x, double y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"X:{X}, Y:{Y}";
		}

		public int CompareTo(object obj)
		{
			STwo s = (STwo) obj;
			return Y.CompareTo(s.Y);
		}
	}

	public struct SThree
	{
		public double X;
		public int Y;

		public SThree(double x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"X:{X}, Y:{Y}";
		}
	}
}