using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LcdWriter.Digits;
using NFluent;
using NUnit.Framework;

namespace LcdWriter.Tests
{
	[TestFixture]
	public class DigitFactoryTests
	{
		private DigitFactory _factory;

		[OneTimeSetUp]
		public void Initialize()
		{
			_factory = new DigitFactory();
		}

		[Test]
		public void ReturnsInstanceOfDigit()
		{
			Enumerable.Range(0, 10).Select(number =>
			{
				var digit = _factory.FindByNumber(number);
				Assert.That(digit, Is.InstanceOf<Digit>());
				return true;
			}).ToList();
		}

		[Test]
		public void OutOfRangeException()
		{
			Check.ThatCode(() =>
			{
				_factory.FindByNumber(11);
			}).Throws<ArgumentOutOfRangeException>();
		}
	}
}
