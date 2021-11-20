using System;
using System.IO;
using System.Text;

namespace Task2_1
{
	class Program
	{
		static string GeometryLog = "/Users/romankozlov/RiderProjects/TRSPK2/Task2-1/GeometryLog.txt";

		static string TriAndQuadLog =
			"/Users/romankozlov/RiderProjects/TRSPK2/Task2-1/TriAndQuadLog.txt";

		static Circle CreateCircle(Random rndm)
		{
			return new Circle(rndm.Next(-20, 20));
		}

		static Triangle CreateTriangle(Random rndm)
		{
			Int32 a = rndm.Next(-20, 20);
			Int32 b = rndm.Next(-20, 20);
			Int32 c = rndm.Next(-20, 20);

			return new Triangle(a, b, c);
		}

		static Quadrangle CreateQuadrangle(Random rndm)
		{
			Int32 a = rndm.Next(-20, 20);
			Int32 b = rndm.Next(-20, 20);
			Int32 c = rndm.Next(-20, 20);
			Int32 d = rndm.Next(-20, 20);

			return new Quadrangle(a, b, c, d);
		}

		static void Main()
		{
			File.AppendAllText(GeometryLog, "---\n", Encoding.UTF8);
			File.AppendAllText(TriAndQuadLog, "---\n", Encoding.UTF8);
			
			Random rndm = new Random();

			for (int i = 0; i < 20; i++)
			{
				try
				{
					var op = rndm.Next(0, 3);
					switch (op)
					{
						case 0:
							_ = CreateCircle(rndm);
							Console.WriteLine("Circle created");
							break;
						case 1:
							_ = CreateTriangle(rndm);
							Console.WriteLine("Triangle created");
							break;
						case 2:
							_ = CreateQuadrangle(rndm);
							Console.WriteLine("Quadrangle created");
							break;
					}
				}
				catch (GeometryException ex)
				{
					DateTime dt = DateTime.Now;
					StringBuilder sb = new StringBuilder();
					sb.Append(
						$"Date: {dt:dd.MM.yyyy : hh:mm}, Message: {ex.Message}, Parameters: {sb}");
					sb.AppendJoin(",", ex.Parameters);
					sb.Append('\n');

					var type = ex.GetType();
					if (type == typeof(TriangleException) || type == typeof(QuadrangleException))
					{
						File.AppendAllText(TriAndQuadLog, sb.ToString(), Encoding.UTF8);
					}

					File.AppendAllText(GeometryLog, sb.ToString(), Encoding.UTF8);
				}
			}
		}
	}
}