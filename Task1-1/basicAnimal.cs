using System;

namespace Task1_1
{
	class BasicAnimal
	{
		protected string name;
		protected ushort age;

		public BasicAnimal(string name, ushort age)
		{
			this.name = name;
			this.age = age;
		}

		public string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public ushort Age
		{
			get { return this.age; }
			set { this.age = value; }
		}

		public override string ToString()
		{
			return $"Animal {this.Name} is {this.Age} years old";
		}
	}
}