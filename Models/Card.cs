namespace DeckOfCards.Domain.Models
{
    public class Card 
    {
        public long Id { get; set; }
        public long Rank { get; set; }
        public string RankName { get; set; }
        public string Suit { get; set; }
    }
}