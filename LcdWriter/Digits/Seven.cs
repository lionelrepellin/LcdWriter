namespace LcdWriter.Digits
{
	public class Seven : Digit
	{
		public override char[,] Write()
		{
			Digits[0, 1] = '_';
			Digits[1, 2] = '|';
			Digits[2, 2] = '|';

			return Digits;
		}
	}
}
