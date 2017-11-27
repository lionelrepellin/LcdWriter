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
        private readonly int _y;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input">Input should contains only numbers</param>
        /// <param name="y">Cursor position (Y axis)</param>
        public LcdWriterService(string input, int y)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input), "The input string should not be null.");

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

            var range = Enumerable.Range(0, 10);
            foreach (var c in input)
            {
                if (int.TryParse(c.ToString(), out int result) && range.Contains(result))
                {
                    switch (result)
                    {
                        case 0:
                            digits.Add(Zero());
                            break;
                        case 1:
                            digits.Add(One());
                            break;
                        case 2:
                            digits.Add(Two());
                            break;
                        case 3:
                            digits.Add(Three());
                            break;
                        case 4:
                            digits.Add(Four());
                            break;
                        case 5:
                            digits.Add(Five());
                            break;
                        case 6:
                            digits.Add(Six());
                            break;
                        case 7:
                            digits.Add(Seven());
                            break;
                        case 8:
                            digits.Add(Eight());
                            break;
                        case 9:
                            digits.Add(Nine());
                            break;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(input), "Only numbers are allowed.");
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
                                // move the cursor to write another digit
                                var x = (3 + Space) * numberToWrite;
                                Console.SetCursorPosition(x, initialPosition);
                            }

                        }
                    }
                }
            }
        }

        #region Digits

        private char[,] Zero()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '_';
            chars[0, 2] = '.';

            chars[1, 0] = '|';
            chars[1, 1] = '.';
            chars[1, 2] = '|';

            chars[2, 0] = '|';
            chars[2, 1] = '_';
            chars[2, 2] = '|';

            return chars;
        }

        private char[,] One()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '.';
            chars[0, 2] = '.';

            chars[1, 0] = '.';
            chars[1, 1] = '.';
            chars[1, 2] = '|';

            chars[2, 0] = '.';
            chars[2, 1] = '.';
            chars[2, 2] = '|';

            return chars;
        }

        private char[,] Two()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '_';
            chars[0, 2] = '.';

            chars[1, 0] = '.';
            chars[1, 1] = '_';
            chars[1, 2] = '|';

            chars[2, 0] = '|';
            chars[2, 1] = '_';
            chars[2, 2] = '.';

            return chars;
        }

        private char[,] Three()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '_';
            chars[0, 2] = '.';

            chars[1, 0] = '.';
            chars[1, 1] = '_';
            chars[1, 2] = '|';

            chars[2, 0] = '.';
            chars[2, 1] = '_';
            chars[2, 2] = '|';

            return chars;
        }

        private char[,] Four()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '.';
            chars[0, 2] = '.';

            chars[1, 0] = '|';
            chars[1, 1] = '_';
            chars[1, 2] = '|';

            chars[2, 0] = '.';
            chars[2, 1] = '.';
            chars[2, 2] = '|';

            return chars;
        }

        private char[,] Five()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '_';
            chars[0, 2] = '.';

            chars[1, 0] = '|';
            chars[1, 1] = '_';
            chars[1, 2] = '.';

            chars[2, 0] = '.';
            chars[2, 1] = '_';
            chars[2, 2] = '|';

            return chars;
        }

        private char[,] Six()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '_';
            chars[0, 2] = '.';

            chars[1, 0] = '|';
            chars[1, 1] = '_';
            chars[1, 2] = '.';

            chars[2, 0] = '|';
            chars[2, 1] = '_';
            chars[2, 2] = '|';

            return chars;
        }

        private char[,] Seven()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '_';
            chars[0, 2] = '.';

            chars[1, 0] = '.';
            chars[1, 1] = '.';
            chars[1, 2] = '|';

            chars[2, 0] = '.';
            chars[2, 1] = '.';
            chars[2, 2] = '|';

            return chars;
        }

        private char[,] Eight()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '_';
            chars[0, 2] = '.';

            chars[1, 0] = '|';
            chars[1, 1] = '_';
            chars[1, 2] = '|';

            chars[2, 0] = '|';
            chars[2, 1] = '_';
            chars[2, 2] = '|';

            return chars;
        }

        private char[,] Nine()
        {
            var chars = new char[3, 3];
            chars[0, 0] = '.';
            chars[0, 1] = '_';
            chars[0, 2] = '.';

            chars[1, 0] = '|';
            chars[1, 1] = '_';
            chars[1, 2] = '|';

            chars[2, 0] = '.';
            chars[2, 1] = '.';
            chars[2, 2] = '|';

            return chars;
        }

        #endregion
    }
}
