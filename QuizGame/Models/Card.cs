namespace QuizGame.Models
{
    public abstract class Card
    {
        private string _name;
        private int _point;
        private string _answer;
        private bool _isPassed;

        public Card(string name, int point, string answer)
        {
            _name = name;
            _point = point;
            _isPassed = false;
            _answer = answer;
        }

        public bool TrySetIsPassed(bool isPassed)
        {
            _isPassed = isPassed;

            return _isPassed;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetPoint()
        {
            return _point;
        }

        public string GetAnswer()
        {
            return _answer;
        }

        public bool GetIsPassed()
        {
            return _isPassed;
        }
    }
}