using QuizGame.Helpers;
using QuizGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Services
{
    public class OptionsService
    {
        private readonly string _optionsGameFilePath;

        public OptionsService()
        {
            _optionsGameFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves\\Options\\OptionsGame.txt");
        }

        public GameOption LoadOptions()
        {
            const int LineSkippedNumber = 1;

            const int ColorBackgroundIndex = 1;
            const int ColorForegroundIndex = 3;
            const int MonitorResolutionXIndex = 5;
            const int MonitorResolutionYIndex = 7;
            const int LanguageIndex = 9;

            string[] optionsText = TxTHandler.TxTRead(_optionsGameFilePath).Skip(LineSkippedNumber).ToArray();

            string colorBackground = optionsText[ColorBackgroundIndex];
            string colorForeground = optionsText[ColorForegroundIndex];
            string monitorResolutionX = optionsText[MonitorResolutionXIndex];
            string monitorResolutionY = optionsText[MonitorResolutionYIndex];
            string language = optionsText[LanguageIndex];

            GameOption gameOption = new GameOption(
                colorBackground,
                colorForeground,
                monitorResolutionX,
                monitorResolutionY,
                language
            );

            return gameOption;
        }
    }
}
