using System;

namespace Task1_1
{
	class Animal : BasicAnimal, IComparable, IComparable<Animal>
	{
		public Animal(string name, ushort age) : base(name, age)
		{
		}

		public int CompareTo(object a)
		{
			Animal firstA = a as Animal;
			if (firstA != null)
				return String.Compare(Name, firstA.Name, StringComparison.Ordinal);
			else
				throw new Exception("Objects incomparable");
		}

		public int CompareTo(Animal? other)
		{
			if (other != null)
				return String.Compare(Name, other.Name, StringComparison.Ordinal);
			else
				throw new Exception("Objects incomparable");
		}
	}
}