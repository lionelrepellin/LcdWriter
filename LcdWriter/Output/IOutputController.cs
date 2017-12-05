using System;

namespace LcdWriter.Output
{
    public interface IOutputController
    {
        void Write(char c);

        void WriteLine();

        void SetCursorPosition(int left, int top);
    }
}