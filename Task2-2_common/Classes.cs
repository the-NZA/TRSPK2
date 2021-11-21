using System;
using System.Collections.Generic;

namespace Task2_2_common
{
	public static class DictionaryExtension
	{
		public static Worker[] ToWorkersArray(this Dictionary<string, int> map)
		{
			Worker[] arr = new Worker[map.Count];
			int i = 0;

			foreach (var item in map)
			{
				arr[i] = new Worker(item.Key, item.Value);
				i++;
			}

			return arr;
		}
	}
	
	public class Worker
	{
		public string Name;
		public int Salary;

		public Worker(string name, int salary)
		{
			Name = name;
			Salary = salary;
		}
	}
	public class Solver
	{
		public int FindMax(int[] arr)
		{
			if (arr == null || arr.Length == 0)
			{
				throw new ArgumentException("Array must have at least 1 item", nameof(arr));
			}

			if (arr.Length == 1)
			{
				return arr[0];
			}

			int max = arr[0];
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i] > max)
				{
					max = arr[i];
				}
			}

			return max;
		}

		public int FindMaxIndex(int[] arr)
		{
			if (arr == null || arr.Length == 0)
			{
				throw new ArgumentException("Array must have at least 1 item", nameof(arr));
			}

			if (arr.Length == 1)
			{
				return 0;
			}

			int idx = 0;
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i] > arr[idx])
				{
					idx = i;
				}
			}

			return idx;
		}

		public S FindMaxByY(S[] arr)
		{
			if (arr == null || arr.Length == 0)
			{
				throw new ArgumentException("Array must have at least 1 item", nameof(arr));
			}

			if (arr.Length == 1)
			{
				return arr[0];
			}

			S max = arr[0];
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i].Y > max.Y)
				{
					max = arr[i];
				}
			}

			return max;
		}

		public SThree[] SortByYAndTransform(STwo[] arr)
		{
			Array.Sort(arr, (s1, s2) => s1.CompareTo(s2));

			SThree[] res = new SThree[arr.Length];

			for (int i = 0; i < arr.Length; i++)
			{
				res[i].X = arr[i].Y;
				res[i].Y = arr[i].X;
			}

			return res;
		}

		public bool IsReverseStrings(string s1, string s2)
		{
			if (s1.Length != s2.Length)
			{
				return false;
			}

			for (int i = 0, j = s2.Length - 1; i < j; i++, j--)
			{
				var c1 = Char.ToLower(s1[i]);
				var c2 = Char.ToLower(s2[j]);

				if (c1 != c2)
				{
					return false;
				}
			}


			return true;
		}

		public List<(uint a, uint b)> GetPairsDivisibleByFive(uint[] arr1, uint[] arr2)
		{
			List<(uint a, uint b)> res = new List<(uint a, uint b)>();

			for (int i = 0; i < arr1.Length; i++)
			{
				for (int j = 0; j < arr2.Length; j++)
				{
					if ((arr1[i] + arr2[j]) % 5 == 0)
					{
						res.Add((arr1[i], arr2[j]));
					}
				}
			}

			return res;
		}

		public string[] GetSortedWordsWithOt(string[] arr)
		{
			List<string> res = new List<string>();

			foreach (var s in arr)
			{
				if (s.ToLower().Contains("от"))
				{
					res.Add(s);
				}
			}

			res.Sort((s1, s2) => String.Compare(s1, s2, StringComparison.Ordinal));

			return res.ToArray();
		}

		public void GroupAndSort(int[] arr)
		{
			if (arr == null || arr.Length < 1)
			{
				throw new Exception("Array must contain's at least 1 item");
			}

			if (arr.Length == 1)
			{
				return;
			}

			int oddIdx = -1;

			// Group numbers by evenness
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = i; j < arr.Length; j++)
				{
					if ((1 & arr[i]) == 0) // If number is even than swap i with j
					{
						(arr[i], arr[j]) = (arr[j], arr[i]);
						continue;
					}

					oddIdx = i;
				}
			}

			Array.Sort(arr, 0, oddIdx + 1);
			Array.Sort(arr, oddIdx + 1, arr.Length - oddIdx - 1);
		}

		public (int oddSum, int evenSum) GroupAndSum(int[] arr)
		{
			if (arr == null || arr.Length < 1)
			{
				throw new Exception("Array must contain's at least 1 item");
			}

			if (arr.Length == 1)
			{
				return (1 & arr[0]) == 1 ? (arr[0], 0) : (0, arr[0]);
			}

			int oddIdx = -1;

			// Group numbers by evenness
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = i; j < arr.Length; j++)
				{
					if ((1 & arr[i]) == 0) // If number is even than swap i with j
					{
						(arr[i], arr[j]) = (arr[j], arr[i]);
						continue;
					}

					oddIdx = i;
				}
			}

			int evenSum = 0;
			int oddSum = 0;

			for (int i = 0; i < oddIdx + 1; i++)
			{
				oddSum += arr[i];
			}

			for (int i = oddIdx + 1; i < arr.Length; i++)
			{
				evenSum += arr[i];
			}

			return (oddSum, evenSum);
		}

		public Worker[] CalcSumByName(Worker[] arr)
		{
			Dictionary<string, int> map = new Dictionary<string, int>();

			foreach (var item in arr)
			{
				if (map.TryGetValue(item.Name, out _))
				{
					 map[item.Name] += item.Salary;
				}
				else
				{
					map[item.Name] = item.Salary;
				}
			}

			return map.ToWorkersArray();
		}

		public T[] FilterIfRepeatThreeTimes<T>(T[] arr)
		{
			Dictionary<T, int> map = new Dictionary<T, int>();
			List<T> res = new List<T>();

			foreach (var item in arr)
			{
				if (map.TryGetValue(item, out _))
				{
					map[item] += 1;
				}
				else
				{
					map[item] = 1;
				}
			}

			foreach (var item in map)
			{
				if (item.Value == 3)
				{
					res.Add(item.Key);
				}
			}

			return res.ToArray();
		}

		public void SortPairsByBothFields<T>((T, T)[] arr) where T: IComparable<T>
		{
			Array.Sort(arr, (s1, s2) => s1.Item1.CompareTo(s2.Item1));
			Array.Sort(arr, (s1, s2) => s2.Item2.CompareTo(s1.Item2));
		}
	}
}