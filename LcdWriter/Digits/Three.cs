namespace LcdWriter.Digits
{
	public class Three : Digit
	{
		public override char[,] Write()
		{
			Digits[0, 1] = '_';
			Digits[1, 1] = '_';
			Digits[1, 2] = '|';
			Digits[2, 1] = '_';
			Digits[2, 2] = '|';

			return Digits;
		}
	}
}
