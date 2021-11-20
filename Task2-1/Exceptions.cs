using System;

namespace Task2_1
{
	public class GeometryException : ArgumentException
	{
		public Int32[] Parameters { get; private set; }
		
		public GeometryException(string messaga, Int32[] arg) : base(messaga)
		{
			Parameters = arg;
		}
	}

	public class TriangleException : GeometryException
	{
		public TriangleException(string messaga, params Int32[] arg) : base(messaga, arg)
		{
		}
	}

	public class QuadrangleException : GeometryException
	{
		public QuadrangleException(string messaga, params Int32[] arg) : base(messaga, arg)
		{
		}
	}

	public class CircleException : GeometryException
	{
		public CircleException(string message, params Int32[] arg) : base(message, arg)
		{
			
		}
	}
}