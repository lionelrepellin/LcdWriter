using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LcdWriter.Output;
using LcdWriter.Tests.Fake;
using Moq;
using NFluent;
using NUnit.Framework;

namespace LcdWriter.Tests
{
	[TestFixture]
	public class LcdWriterServiceTests
	{
		private DigitFactory _factory;

		[OneTimeSetUp]
		public void Initialize()
		{
			_factory = new DigitFactory();
		}

		[TestCaseSource(typeof(DigitCases))]
		public void VerifyDigitContent(string input, string referenceFileName)
		{
			var referenceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReferenceFiles", referenceFileName);
			var expectedResult = File.ReadAllText(referenceFilePath);

			var testFilePath = WriteFile(input);

			var result = File.ReadAllText(testFilePath);
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		public void ShouldAlwaysWriteNineTimes()
		{
			var outputMock = new Mock<IOutputController>();
			var randomNumber = new Random().Next(0, 10);

			var service = new LcdWriterService($"{randomNumber}", 0, _factory, outputMock.Object);
			service.Write();

			outputMock.Verify(m => m.Write(It.IsAny<char>()), Times.Exactly(9));
		}

		[Test]
		public void WhenSendingNullItThrowsAnException()
		{
			Check.ThatCode(() =>
			{
				new LcdWriterService(null, 0, _factory, new StandardOutput());
			}).Throws<ArgumentNullException>();
		}

		[Test]
		public void WhenSendingLetterThrowsAnException()
		{
			Check.ThatCode(() =>
			{
				new LcdWriterService("a", 0, _factory, new StandardOutput());
			}).Throws<ArgumentException>();
		}

		[Test]
		public void WhenNotStartingAtTopItJumpsALine()
		{
			var outputMock = new Mock<IOutputController>();

			var service = new LcdWriterService("1", 1, _factory, outputMock.Object);
			service.Write();

			outputMock.Verify(m => m.WriteLine(), Times.Once);
		}

		// Write digits into a file and returns the file path
		private string WriteFile(string input)
		{
			using (var outputController = new FileOutput())
			{
				var service = new LcdWriterService(input, 0, _factory, outputController);
				service.Write();
				return outputController.TestFilePath; ;
			}
		}
	}
}