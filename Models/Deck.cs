using System.Collections.Generic;

namespace DeckOfCards.Domain.Models
{
    public class Deck 
    {
        private const long NUMCARDS = 52;
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
            string[] suits = {"club", "diamond", "heart", "spade"};
            long currentSuitIndex = 0;
            long currentRank = 1;
            string currentSuit = suits[currentSuitIndex];

            for (int i = 0; i < NUMCARDS; i++)
            {
                if (currentRank > 13) 
                {
                    currentRank = 1;
                    currentSuit = suits[++currentSuitIndex];
                }
                
                Card newCard = new Card
                {
                    Id = i,
                    Rank = currentRank,
                    Suit = currentSuit
                };

                if (currentRank >= 2 && currentRank <= 10) 
                {
                    newCard.RankName = $"{currentRank}";
                }
                else if (currentRank == 1) newCard.RankName = "A";
                else if (currentRank == 11) newCard.RankName = "J";
                else if (currentRank == 12) newCard.RankName = "Q";
                else if (currentRank == 13) newCard.RankName = "K";

                Cards.Add(newCard);
                currentRank++;
            }
        }
    }
}