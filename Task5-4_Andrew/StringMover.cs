using System;
using System.IO;

namespace Task5_4_Andrew
{
	public class StringMover: IDisposable
	{
		private bool disposed;

		private string inputFile;
		private string outputFile;
		private StreamReader input;
		private StreamWriter output;

		public StringMover(string inputFile, string outputFile)
		{
			this.inputFile = inputFile;
			this.outputFile = outputFile;
		}

		public void Open()
		{
			this.input = File.OpenText(this.inputFile);
			this.output = File.CreateText(this.outputFile);
		}

		public void Move()
		{
			string moved = null;

			while ((moved = this.input.ReadLine()) != null)
			{
				this.output.WriteLine(moved);
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			// guard 
			if (this.disposed)
			{
				return;
			}

			this.input.Dispose();
			this.output.Dispose();

			if (disposing)
			{
				this.input = null;
				this.output = null;
				this.inputFile = null;
				this.outputFile = null;
			}

			this.disposed = true;
		}

		~StringMover()
		{
			Dispose(false);
		}
	}
}