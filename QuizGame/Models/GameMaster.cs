using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Models
{
    public static class GameMaster
    {
        private static string _name;
        private static bool _isActive = false;

        public static bool TrySetName(string name)
        {
            if (string.IsNullOrEmpty(_name) == false)
            {
                return false;
            }

            if (string.IsNullOrEmpty(name))
            {
                return false ;
            }

            _name = name;
            return true;
        }

        public static void Activate()
        {
            _isActive = true;
        }

        public static void DeActivate()
        {
            _isActive = false;
        }

        public static string GetName()
        {
            return _name;
        }

        public static bool GetIsActive()
        {
            return _isActive;
        }
    }
}
