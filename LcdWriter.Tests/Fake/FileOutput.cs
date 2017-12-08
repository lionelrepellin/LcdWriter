using System;
using System.IO;
using System.Linq;
using System.Text;
using LcdWriter.Output;

namespace LcdWriter.Tests.Fake
{
	public class FileOutput : IOutputController, IDisposable
	{
		public string TestFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.txt");

		private StreamWriter _writer;

		public FileOutput()
		{
			_writer = new StreamWriter(TestFilePath, false, Encoding.UTF8);
		}
		
		public void SetCursorPosition(int left, int top)
		{
		}

		public void Write(char c) => _writer.Write(c);

		public void WriteLine()
		{
		}

		#region IDisposable Support
		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_writer.Dispose();
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}
		#endregion
	}
}
