using QuizGame.Models;
using System;

namespace QuizGame.UI
{
    public static class UI
    {
        private const char _windowBorderSymbol = '=';
        private const char _emptySymbol = ' ';

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
                new string(_windowBorderSymbol, firstWindowBorderWidth),
                $"{_windowBorderSymbol} {playerName}             очки - {playerPoint} {_windowBorderSymbol}",
                new string(_windowBorderSymbol, firstWindowBorderWidth)
            };

            string[] main = new string[]{
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol
            };


            string[] footer = new string[]{
                new string(_windowBorderSymbol, firstWindowBorderWidth),
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                new string(_windowBorderSymbol, firstWindowBorderWidth)
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

        public static void PrintSoloGameOptions()
        {
            string[] optionsTexts = new string[]{
                "====== Настройки одиночной ссесии ======",
                "                                        ",
                "========================================",
                "=    1: Название сетапа карточек       =",
                "========================================",
                "=            2: Ник игрока             =",
                "========================================",
                "=              3: Таймер               =",
                "========================================",
                "=                 Выход                =",
                "========================================"
            };

            int rowOffset = -10;

            foreach (string text in optionsTexts)
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