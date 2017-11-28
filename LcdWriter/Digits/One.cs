namespace LcdWriter.Digits
{
	public class One : Digit
	{
		public override char[,] GetDigits()
		{
			Digits[1, 2] = '|';
			Digits[2, 2] = '|';
			return Digits;
		}
	}
}
