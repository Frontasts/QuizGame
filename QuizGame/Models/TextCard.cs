namespace QuizGame.Models
{
    public class TextCard : Card
    {
        private string _text;

        public TextCard(string name, int point, string answer, string text) : base(name, point, answer)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
    }
}