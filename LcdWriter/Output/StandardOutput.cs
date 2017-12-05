using System;

namespace LcdWriter.Output
{
    /// <summary>
    /// Writes digits to the Console
    /// </summary>
    public class StandardOutput : IOutputController
    {
        /// <summary>
        /// Writes the specified Unicode character value to the standard output stream.
        /// </summary>
        /// <param name="c"></param>
        public void Write(char c)
        {
            Console.Write(c);
        }

        /// <summary>
        /// Writes the current line terminator to the standard output stream.
        /// </summary>
        public void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Sets the position of the cursor.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}
