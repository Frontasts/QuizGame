using QuizGame.Helpers;
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
    }
}
