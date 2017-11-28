using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcdWriter.Digits
{
	public abstract class Digit
	{
		protected char[,] Digits;

		protected Digit()
		{
			Digits = new char[3, 3];
			Digits[0, 0] = ' ';
			Digits[0, 1] = ' ';
			Digits[0, 2] = ' ';

			Digits[1, 0] = ' ';
			Digits[1, 1] = ' ';
			Digits[1, 2] = ' ';

			Digits[2, 0] = ' ';
			Digits[2, 1] = ' ';
			Digits[2, 2] = ' ';
		}

		public abstract char[,] Write();
	}
}
