using QuizGame.Models;
using System;

namespace QuizGame.UI
{
    public static class UI
    {
        private const char WindowBorderSymbol = '=';
        private const char EmptySymbol = ' ';

        public static void PrintMenu()
        {
            string[] menuTexts = new string[]{
                "====== Quiz Game ======",
                "                     ",
                "=====================",
                "=   Одиночная игра  =",
                "=====================",
                "=        WIP        =",
                "=====================",
                "=        WIP        =",
                "=====================",
                "=     Настройки     =",
                "=====================",
                "=       Выход       =", 
                "=====================" 
            };

            int rowOffset = -10;

            foreach (string text in menuTexts)
            {
                PrintCenter(text, rowOffset);
                rowOffset ++;
            }
        }

        public static void PrintSoloGame(Player player)
        {
            const int Width = 22;
            const int WidthOffset = 2;

            string playerName = player.GetName();
            string playerPoint = player.GetPoint().ToString();

            int playerNameLength = playerName.Length;
            int playerPointLength = playerPoint.Length;

            int firstWindowBorderWidth = Width + playerNameLength + playerPointLength + WidthOffset;
            int secondWindowBorderWidth = Width + playerNameLength + playerPointLength;

            string[] header = new string[]{
                new string(WindowBorderSymbol, firstWindowBorderWidth),
                $"{WindowBorderSymbol} {playerName}             очки - {playerPoint} {WindowBorderSymbol}",
                new string(WindowBorderSymbol, firstWindowBorderWidth)
            };

            string[] main = new string[]{
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol,
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol,
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol,
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol,
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol,
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol,
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol,
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol
            };


            string[] footer = new string[]{
                new string(WindowBorderSymbol, firstWindowBorderWidth),
                WindowBorderSymbol + new string(EmptySymbol, secondWindowBorderWidth) + WindowBorderSymbol,
                new string(WindowBorderSymbol, firstWindowBorderWidth)
            };

            int rowOffset = -15;

            foreach (string text in header)
            {
                PrintCenter(text, rowOffset);
                rowOffset++;
            }

            foreach (string text in main)
            {
                PrintCenter(text, rowOffset);
                rowOffset++;
            }

            foreach (string text in footer)
            {
                PrintCenter(text, rowOffset);
                rowOffset++;
            }
        }

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