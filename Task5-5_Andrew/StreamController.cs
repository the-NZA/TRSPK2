using System;
using System.IO;

namespace Task5_5_Andrew
{
	class StreamController : IDisposable
	{
		private bool disposed;

		public StreamReader input;
		public StreamWriter output;

		public StreamController(string inputFile, string outputFile)
		{
			this.input = File.OpenText(inputFile);
			this.output = File.CreateText(outputFile);
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
			}

			Console.WriteLine("my streams are dead");

			this.disposed = true;
		}

		~StreamController()
		{
			Dispose(false);
		}
	}
}