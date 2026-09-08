using System;

namespace QuizGame.UI
{
    public static class UI
    {
        private static void PrintCenter(string text, int rowOffset = 0)
        {
            const int Modifier = 2;

            int left = Math.Max(0, (Console.WindowWidth - text.Length) / Modifier);
            int top = Math.Max(0, Console.WindowHeight / Modifier + rowOffset);

            Console.SetCursorPosition(left, top);
            Console.WriteLine(text);

            Console.SetCursorPosition(left, top + 1);
        }
    }
}