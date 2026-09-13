using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Game
    {
        public void Run()
        {
            const char SoloGameCommand = '1';
            const char LocalGameCommand = '2';
            const char MultiplayerCommand = '3';
            const char OptionsCommand = '4';
            const char ExitCommand = '0';

            UI.UI.PrintMenu();

            bool isRunGame = true;
            
            while (isRunGame)
            {
                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case SoloGameCommand:
                        break;

                    case LocalGameCommand:
                        break;

                    case MultiplayerCommand:
                        break;

                    case OptionsCommand:
                        break;

                    case ExitCommand:
                        isRunGame = false;
                        break;

                }
            }
        }
    }
}
