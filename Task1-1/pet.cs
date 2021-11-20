using System;

namespace Task1_1
{
	class Pet : BasicAnimal, IComparable<Pet>
	{
		public Pet(string name, ushort age) : base(name, age)
		{
		}

		public override string ToString()
		{
			return $"Pet {this.Name} is {this.Age} years old";
		}

		public int CompareTo(Pet other)
		{
			if (other == null) return 1;
			return Name.CompareTo(other.Name);
		}
	}
}