using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Models
{
    public class Player
    {
        private string _name;
        private int _point;

        public Player(string name)
        {
            _name = name;
            _point = 0;
        }

        public bool TryAddPoint(int point)
        {
            if (point <= 0)
            {
                return false;
            }

            _point = _point + point;
            return true;
        }

        public bool TryReducePoint(int point)
        {
            if (point >= 0)
            {
                return false;
            }

            _point = _point - point;
            return true;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetPoint()
        {
            return _point;
        }
    }
}