namespace LcdWriter.Digits
{
	public class Five : Digit
	{
		public override char[,] Write()
		{
			Digits[0, 1] = '_';
			Digits[1, 0] = '|';
			Digits[1, 1] = '_';
			Digits[2, 1] = '_';
			Digits[2, 2] = '|';

			return Digits;
		}
	}
}
