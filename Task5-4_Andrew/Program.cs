namespace Task5_4_Andrew
{
	class Program
	{
		public static void Main(string[] args)
		{
			using (StringMover worker = new StringMover("input.txt", "output.txt"))
			{
				worker.Open();
				worker.Move();
			}
		}
	}
}