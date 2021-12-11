using System;

namespace Task5_5_Andrew
{
	class StringMover : IDisposable
	{
		private bool disposed;

		private string inputFile;
		private string outputFile;
		private StreamController inOutStreams;

		public StringMover(string inputFile, string outputFile)
		{
			this.inputFile = inputFile;
			this.outputFile = outputFile;
		}

		public void Open()
		{
			this.inOutStreams = new StreamController(this.inputFile, this.outputFile);
		}

		public void Move()
		{
			string moved = null;

			while ((moved = this.inOutStreams.input.ReadLine()) != null)
			{
				this.inOutStreams.output.WriteLine(moved);
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

			this.inOutStreams.Dispose();

			if (disposing)
			{
				this.inOutStreams = null;
				this.inputFile = null;
				this.outputFile = null;
			}

			Console.WriteLine("stream controller is dead and now it is my turn");

			this.disposed = true;
		}

		~StringMover()
		{
			Dispose(false);
		}
	}
}