using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Models
{
    public struct GameOption
    {
        private string _colorBackground;
        private string _colorForeground;
        private string _monitorResolutionX;
        private string _monitorResolutionY;
        private string _language;

        public GameOption(string colorBackground, string colorForeground, string monitorResolutionX, string monitorResolutionY, string language)
        {
            _colorBackground = colorBackground;
            _colorForeground = colorForeground;
            _monitorResolutionX = monitorResolutionX;
            _monitorResolutionY = monitorResolutionY;
            _language = language;
        }
        public string GetColorBackground()
        {
            return _colorBackground;
        }

        public string GetColorForeground()
        {
            return _colorForeground;
        }

        public string GetMonitorResolutionX()
        {
            return _monitorResolutionX;
        }

        public string GetMonitorResolutionY()
        {
            return _monitorResolutionY;
        }

        public string GetLanguage()
        {
            return _language;
        }

        public override string ToString()
        {
            return $"{_colorBackground} {_colorForeground} {_monitorResolutionX} {_monitorResolutionY} {_language}";
        }

    }
}
