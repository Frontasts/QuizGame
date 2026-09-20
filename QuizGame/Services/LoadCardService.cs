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
    public class LoadCardService
    {
        private readonly string _cardFilePath;

        public LoadCardService()
        {
            _cardFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Saves\\Card\\TestCard.txt");
        }

        public List<TextCard> CardLoad()
        {
            const int LineSkippedNumber = 1;
            const int NameIndex = 0;
            const int ScoreIndex = 1;
            const int TextIndex = 2;
            const int AnswerIndex = 3;

            List<TextCard> textCards = new List<TextCard>();
            string[] cards = TxTHelper.TxTRead(_cardFilePath);

            foreach (string card in cards.Skip(LineSkippedNumber).ToArray())
            {
                string[] cardDetails = card.Split(' ');

                string cardName = cardDetails[NameIndex];
                int cardScore = int.Parse(cardDetails[ScoreIndex]);
                string cardText = cardDetails[TextIndex];
                string cardAnswer = cardDetails[AnswerIndex];

                TextCard textCard = new TextCard(cardName, cardScore, cardText, cardAnswer);
                textCards.Add(textCard);
            }

            return textCards;
        }
    }
}
