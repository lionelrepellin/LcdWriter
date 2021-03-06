﻿using LcdWriter.Digits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcdWriter
{
	public class DigitFactory
	{
		private readonly Dictionary<int, Type> _dictionary;

		public DigitFactory()
		{
			_dictionary = new Dictionary<int, Type>()
			{
				{ 0, typeof(Zero) },
				{ 1, typeof(One) },
				{ 2, typeof(Two) },
				{ 3, typeof(Three) },
				{ 4, typeof(Four) },
				{ 5, typeof(Five) },
				{ 6, typeof(Six) },
				{ 7, typeof(Seven) },
				{ 8, typeof(Eight) },
				{ 9, typeof(Nine) }
			};
		}

		public Digit FindByNumber(int number)
		{
			if (_dictionary.ContainsKey(number))
			{
				return (Digit)Activator.CreateInstance(_dictionary[number]);
			}

			throw new ArgumentOutOfRangeException(nameof(number), "Only numbers between 0 and 9 are allowed.");
		}
	}
}
