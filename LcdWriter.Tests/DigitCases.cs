using System.Collections;

namespace LcdWriter.Tests
{
	public class DigitCases : IEnumerable
	{
		public IEnumerator GetEnumerator()
		{
			yield return new object[] { "0", "zero.txt" };
			yield return new object[] { "1", "one.txt" };
			yield return new object[] { "2", "two.txt" };
			yield return new object[] { "3", "three.txt" };
			yield return new object[] { "4", "four.txt" };
			yield return new object[] { "5", "five.txt" };
			yield return new object[] { "6", "six.txt" };
			yield return new object[] { "7", "seven.txt" };
			yield return new object[] { "8", "eight.txt" };
			yield return new object[] { "9", "nine.txt" };			
		}
	}
}
