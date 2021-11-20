using System;

namespace Task2_1
{
	public class Triangle
	{
		public Triangle(Int32 a, Int32 b, Int32 c)
		{
			if (a <= 0 || b <= 0 || c <= 0)
			{
				throw new TriangleException("Triangle lengths of the sides must be greater than zero",
					a, b, c);
			}

			if (a + b <= c || a + c <= b || b + c <= a)
			{
				throw new QuadrangleException("Can't create triangle with given lenghts of the sides",
					a, b, c);
			}
		}
	}

	public class Quadrangle
	{
		public Quadrangle(Int32 a, Int32 b, Int32 c, Int32 d)
		{
			if (a <= 0 || b <= 0 || c <= 0 || d <= 0)
			{
				throw new QuadrangleException(
					"Quadrangle lengths of the sides must be greater than zero", a, b, c, d);
			}

			if (a + b + c <= d || a + b + d <= c || a + c + d <= b || b + c + d <= a)
			{
				throw new QuadrangleException(
					"Can't create quadrangle with given lengths of the sides", a, b, c, d);
			}
		}
	}

	public class Circle
	{
		public Circle(Int32 r)
		{
			if (r <= 0)
			{
				throw new CircleException("Circle radius must be greater than 0", r);
			}
		}
	}
}