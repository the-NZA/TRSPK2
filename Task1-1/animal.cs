using System;

namespace Task1_1
{
	class Animal : BasicAnimal, IComparable
	{
		public Animal(string name, ushort age) : base(name, age)
		{
		}

		public int CompareTo(object a)
		{
			Animal firstA = a as Animal;
			if (firstA != null)
				return this.Name.CompareTo(firstA.Name);
			else
				throw new Exception("Objects incomparable");
		}
	}
}