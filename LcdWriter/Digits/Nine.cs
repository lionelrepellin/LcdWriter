namespace LcdWriter.Digits
{
	public class Nine : Digit
	{
		public override char[,] GetDigits()
		{
			Digits[0, 1] = '_';
			Digits[1, 0] = '|';
			Digits[1, 1] = '_';
			Digits[1, 2] = '|';
			Digits[2, 2] = '|';

			return Digits;
		}
	}
}
