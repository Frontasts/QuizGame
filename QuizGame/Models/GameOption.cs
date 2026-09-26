using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Models
{
    public struct GameOption
    {
        private string ColorBackground;
        private string ColorForeground;
        private string MonitorResolutionX;
        private string MonitorResolutionY;
        private string Language;

        public string GetColorBackground()
        {
            return ColorBackground;
        }

        public string GetColorForeground()
        {
            return ColorForeground;
        }

        public string GetMonitorResolutionX()
        {
            return MonitorResolutionX;
        }

        public string GetMonitorResolutionY()
        {
            return MonitorResolutionY;
        }

        public string GetLanguage()
        {
            return Language;
        }

        public override string ToString()
        {
            return $"{ColorBackground} {ColorForeground} {MonitorResolutionX} {MonitorResolutionY} {Language}";
        }

    }
}
