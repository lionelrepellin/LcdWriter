namespace LcdWriter.Digits
{
	public class Zero : Digit
	{
		public override char[,] GetDigits()
		{
			Digits[0, 1] = '_';
			Digits[1, 0] = '|';
			Digits[1, 2] = '|';
			Digits[2, 0] = '|';
			Digits[2, 1] = '_';
			Digits[2, 2] = '|';

			return Digits;
		}
	}
}
