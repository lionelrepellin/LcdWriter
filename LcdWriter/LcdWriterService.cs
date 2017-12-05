using LcdWriter.Output;
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
        private readonly IOutputController _outputController;
        private readonly int _yPosition;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input">Input should contains only numbers</param>
        /// <param name="yPosition">Cursor position (Y axis)</param>
        /// <param name="digitFactory"></param>
        /// <param name="outputController">redirect the program output</param> 
        public LcdWriterService(string input, int yPosition, DigitFactory digitFactory, IOutputController outputController)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input), "The input string should not be null.");

            _yPosition = yPosition;
            _digitFactory = digitFactory;
            _outputController = outputController;
            _digits = ConvertStringToDigits(input);
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
                    throw new ArgumentException("Can't parse string to int.", nameof(input));
                }
            }

            return digits;
        }

        private int InitializeStartPosition()
        {
            // numbers were entered in command line arguments 
            var initialPosition = 0;

            // user was prompted to enter numbers
            if (_yPosition > 0)
            {
                _outputController.WriteLine();
                initialPosition = _yPosition + 1;
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
                var digits = _digits[i];

                WriteOne(digits, initialPosition, numberToWrite);
            }
        }

        private void WriteOne(char[,] digit, int initialPosition, int numberToWrite)
        {
            var rowCount = digit.GetLength(0);
            var columnCount = digit.GetLength(1);

            for (var row = 0; row < rowCount; row++)
            {
                for (var column = 0; column < columnCount; column++)
                {
                    _outputController.Write(digit[row, column]);

                    // carrier return
                    if (column == columnCount - 1)
                    {
                        if (row < rowCount - 1)
                        {
                            // move cursor to the next line to write the digit
                            var x = (rowCount + Space) * (numberToWrite - 1);
                            var y = row + 1 + initialPosition;
                            _outputController.SetCursorPosition(x, y);
                        }
                        else
                        {
                            // move the cursor to write another number
                            var x = (rowCount + Space) * numberToWrite;
                            _outputController.SetCursorPosition(x, initialPosition);
                        }
                    }
                }
            }
        }
    }
}
