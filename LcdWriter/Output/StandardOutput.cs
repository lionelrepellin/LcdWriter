using System;

namespace LcdWriter.Output
{
    public class StandardOutput : IOutputController
    {        
        public void Write(char c)
        {
            Console.Write(c);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}
