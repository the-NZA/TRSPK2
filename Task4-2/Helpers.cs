using System;
using System.Text;

namespace Task4_2
{
	public enum ProductType
	{
		A = 0,
		B = 1,
		C = 2,
		M = 3,
		N = 4
	}
	
	public static class Helpers
	{
		public static int ProductionTimeByType(ProductType type)
		{
			switch (type)
			{
				case ProductType.A:
					return 800;

				case ProductType.B:
					return 1500;

				case ProductType.C:
					return 3300;

				case ProductType.M:
					return 2500;

				case ProductType.N:
					return 4500;

				default:
					throw new Exception("Unsupported product type");
			}
		}
		
		public static string FormatedString(this int[] arr)
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < arr.Length; i++)
			{
				sb.AppendFormat((i + 1) == arr.Length ? "{0}" : "{0}, ", arr[i]);
			}

			return sb.ToString();
		}
	}
}