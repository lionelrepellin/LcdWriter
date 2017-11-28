using System;
using System.Collections.Generic;
using System.Linq;

namespace LcdWriter
{
	public class LcdWriterService
	{
		// number of spaces between two numbers
		private const int Space = 1;

		private readonly List<char[,]> _digits;		
		private readonly DigitFactory _digitFactory;
		private readonly int _y;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="input">Input should contains only numbers</param>
		/// <param name="y">Cursor position (Y axis)</param>
		/// <param name="digitFactory"></param>
		public LcdWriterService(string input, int y, DigitFactory digitFactory)
		{
			if (string.IsNullOrWhiteSpace(input))
				throw new ArgumentNullException(nameof(input), "The input string should not be null.");

			_digitFactory = digitFactory;
			_digits = ConvertStringToDigits(input);
			_y = y;
		}

		/// <summary>
		/// Parse each character from the input string and convert each into a list of digits
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		private List<char[,]> ConvertStringToDigits(string input)
		{
			var digits = new List<char[,]>();

			foreach (var c in input)
			{
				if (int.TryParse(c.ToString(), out int result))
				{
					var number = _digitFactory.FindByNumber(result);
					var digit = number.GetDigits();
					digits.Add(digit);
				}
				else
				{
					throw new ArgumentException("Can't parse string to int.");
				}
			}

			return digits;
		}

		private int InitializeStartPosition()
		{
			// numbers were entered in command line arguments 
			var initialPosition = 0;

			// user was prompted to enter numbers
			if (_y > 0)
			{
				Console.WriteLine();
				initialPosition = _y + 1;
			}

			return initialPosition;
		}

		/// <summary>
		/// Write digits into the console
		/// </summary>
		public void Write()
		{
			var initialPosition = InitializeStartPosition();

			for (var i = 0; i < _digits.Count; i++)
			{
				var numberToWrite = i + 1;

				for (var row = 0; row < 3; row++)
				{
					for (var column = 0; column < 3; column++)
					{
						Console.Write(_digits[i][row, column]);

						// carrier return
						if (column == 2)
						{
							if (row < 2)
							{
								// move cursor to the next line to write the digit
								var x = (3 + Space) * (numberToWrite - 1);
								var y = row + 1 + initialPosition;
								Console.SetCursorPosition(x, y);
							}
							else
							{
								// move the cursor to write another number
								var x = (3 + Space) * numberToWrite;
								Console.SetCursorPosition(x, initialPosition);
							}

						}
					}
				}
			}
		}
	}
}
