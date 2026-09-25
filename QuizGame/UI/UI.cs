using QuizGame.Models;
using System;
using System.Collections.Generic;

namespace QuizGame.UI
{
    public static class UI
    {
        private const char _windowBorderSymbol = '=';
        private const char _emptySymbol = ' ';

        private static readonly int ColumnCards = 3;
        private static readonly int RowCards = 3;
        private static readonly int CardSizeX = 10;
        private static readonly int CardSizeY = 10;
        private static readonly int Width = 22;
        private static readonly int WidthOffset = 2;

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

        public static void PrintSoloGame(Player player, List<TextCard> textCards)
        {

            string playerName = player.GetName();
            string playerPoint = player.GetPoint().ToString();

            int playerNameLength = playerName.Length;
            int playerPointLength = playerPoint.Length;

            int offsetPlayer = 0;

            if (playerNameLength % 2 == 0 && playerPointLength % 2 == 0)
            {
                offsetPlayer = 0;
            }
            else
            {
                offsetPlayer = 1;
            }

            int firstWindowBorderWidth = Width + playerNameLength + playerPointLength + WidthOffset + (CardSizeX * ColumnCards) + offsetPlayer;
            int secondWindowBorderWidth = Width + playerNameLength + playerPointLength + (CardSizeX * ColumnCards) + offsetPlayer;

            string[] header = GetSoloGameHeader(player, firstWindowBorderWidth);
            List<string> main = GetSoloGameMain(textCards, secondWindowBorderWidth);
            string[] footer = GetSoloGameFooter(firstWindowBorderWidth, secondWindowBorderWidth);

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
        

        private static string[] GetSoloGameHeader(Player player, int windowBorderWidth)
        {
            string playerName = player.GetName();
            int playerNameLenght = playerName.Length;

            string playerScore = player.GetPoint().ToString();
            int playerScoreLenght = playerScore.Length;

            string[] header = new string[]{
                new string(_windowBorderSymbol, windowBorderWidth),
                $"{_windowBorderSymbol} {playerName}" + new string(_emptySymbol, Width - playerNameLenght - playerScoreLenght - WidthOffset - 1 + (CardSizeX * ColumnCards)) + $"очки - {playerScore} {_windowBorderSymbol}",
                new string(_windowBorderSymbol, windowBorderWidth)
            };

            return header;
        }

        private static List<string> GetSoloGameMain(List<TextCard> textCards, int windowBorderWidth)
        {
            const int CardNamePosition = 3;
            const int CardPointPosition = 6;

            List<string> main = new List<string>();

            int cardNameIndex = 0;
            int cardScoreIndex = 0;

            for (int columnCoun = 0; columnCoun < RowCards; columnCoun++)
            {
                main.Add(_windowBorderSymbol + new string(_windowBorderSymbol, windowBorderWidth) + _windowBorderSymbol);

                for (int lineCount = 0; lineCount < CardSizeX; lineCount++)
                {
                    if (lineCount == CardNamePosition)
                    {
                        string tempText = "";

                        for (int columnCount = 0; columnCount < ColumnCards; columnCount++)
                        {
                            int cardNameLenght = textCards[cardNameIndex].GetName().Length;

                            int firstCardNameOffset = (int)Math.Floor((double)cardNameLenght / 2) + 1;
                            int secondCardNameOffset = (int)Math.Ceiling(((double)cardNameLenght / 2)) + 1;

                            if (cardNameLenght % 2 == 0)
                            {
                                tempText += _windowBorderSymbol + new string(_emptySymbol, CardSizeX - firstCardNameOffset) + textCards[cardNameIndex].GetName() + new string(_emptySymbol, CardSizeX - firstCardNameOffset) + _windowBorderSymbol;
                            }
                            else
                            {
                                tempText += _windowBorderSymbol + new string(_emptySymbol, CardSizeX - firstCardNameOffset) + textCards[cardNameIndex].GetName() + new string(_emptySymbol, CardSizeX - secondCardNameOffset) + _windowBorderSymbol;
                            }

                            cardNameIndex++;
                        }

                        main.Add(tempText);
                    }
                    else if (lineCount == CardPointPosition)
                    {
                        string tempText = "";

                        for (int columnCount = 0; columnCount < ColumnCards; columnCount++)
                        {
                            int cardScoreLenght = textCards[cardScoreIndex].GetPoint().ToString().Length;
                            int firstCardScoreOffset = (int)Math.Floor((double)cardScoreLenght / 2) + 1;
                            int secondCardScoreOffset = (int)Math.Ceiling((double)cardScoreLenght / 2) + 1;

                            if (cardScoreLenght % 2 == 0)
                            {
                                tempText += _windowBorderSymbol + new string(_emptySymbol, CardSizeX - firstCardScoreOffset) + textCards[cardScoreIndex].GetPoint().ToString() + new string(_emptySymbol, CardSizeX - firstCardScoreOffset) + _windowBorderSymbol;
                            }
                            else
                            {
                                tempText += _windowBorderSymbol + new string(_emptySymbol, CardSizeX - firstCardScoreOffset) + textCards[cardScoreIndex].GetPoint().ToString() + new string(_emptySymbol, CardSizeX - secondCardScoreOffset) + _windowBorderSymbol;
                            }

                            cardScoreIndex++;
                        }

                        main.Add(tempText);
                    }
                    else
                    {
                        string tempText = "";

                        for (int columnCount = 0; columnCount < ColumnCards; columnCount++)
                        {
                            tempText += _windowBorderSymbol + new string(_emptySymbol, CardSizeX * 2 - WidthOffset) + _windowBorderSymbol;
                        }

                        main.Add(tempText);
                    }
                }

                main.Add(_windowBorderSymbol + new string(_windowBorderSymbol, windowBorderWidth) + _windowBorderSymbol);
            }

            return main;
        }

        private static string[] GetSoloGameFooter(int firstWindowBorderWidth, int secondWindowBorderWidth)
        {
            string[] footer = new string[]{
                new string(_windowBorderSymbol, firstWindowBorderWidth),
                _windowBorderSymbol + new string(_emptySymbol, secondWindowBorderWidth) + _windowBorderSymbol,
                new string(_windowBorderSymbol, firstWindowBorderWidth)
            };

            return footer;
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