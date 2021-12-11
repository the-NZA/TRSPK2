using System;
using System.IO;
using System.Text;

namespace Task5_4
{
	static class Helpers
	{
		public static readonly string SourcePath =
			"/Users/romankozlov/RiderProjects/TRSPK2/Task5-4/SourceFile.txt";

		public static readonly string DestPath = "/Users/romankozlov/RiderProjects/TRSPK2/Task5-4/DestFile.txt";
	}

	class Copier : IDisposable
	{
		private readonly string _src;
		private readonly string _dst;
		private StreamReader _srcFile;
		private StreamWriter _dstFile;
		private bool _disposed;

		public Copier(string src, string dst)
		{
			if (src.Length < 1 || dst.Length < 1)
			{
				throw new Exception("Filepaths must have at least one character");
			}

			_src = src;
			_dst = dst;
			_srcFile = null;
			_dstFile = null;
			_disposed = false;
		}

		private void Open()
		{
			// open two files	
			_srcFile = new StreamReader(_src, Encoding.UTF8);
			_dstFile = new StreamWriter(_dst, false, Encoding.UTF8);
		}

		private void Close()
		{
			// close both files	
			_srcFile?.Close();
			_dstFile?.Close();
		}

		public void Work()
		{
			// try open both files
			Open();

			if (_srcFile == null || _dstFile == null)
			{
				throw new Exception("Source and destination files can't be null");
			}

			// copy all from one file to anothe
			string line;
			while ((line = _srcFile.ReadLine()) != null)
			{
				_dstFile.WriteLine(line);
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			// exit if already disposed
			if (_disposed)
			{
				return;
			}

			// free resources
			if (disposing)
			{
				Close();
			}

			// set disposed flag
			_disposed = true;

		}
	}

	internal static class Program
	{
		static void Main()
		{
			try
			{
				// init new copier instanse and start doing work
				using (var copier = new Copier(Helpers.SourcePath, Helpers.DestPath))
				{
					copier.Work();
				}
				
				Console.WriteLine("Copier done all work");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}