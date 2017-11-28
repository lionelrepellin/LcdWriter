namespace LcdWriter.Digits
{
	public class Two : Digit
	{
		public override char[,] Write()
		{
			Digits[0, 1] = '_';
			Digits[1, 2] = '|';
			Digits[2, 0] = '|';
			Digits[2, 1] = '_';

			return Digits;
		}
	}
}
