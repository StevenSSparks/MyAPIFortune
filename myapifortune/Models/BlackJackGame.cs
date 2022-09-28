namespace MyAPIFortune.Models
{
    public class BlackJackGame
    {
        public string Id { get; set; } = "";
        public List<Card> Deck { get; set; } = new();
        public List<Card> DiscardDeck { get; set; } = new();
        public int ComputerWins { get; set; } = 0;
        public int PlayerWins { get; set; } = 0;
        public int PlayerPoints { get; set; } = 10000;
        public List<Card> PlayerCards { get; set; } = new();
        public bool PlayerCardsActive { get; set; } = false;
        public List<Card> PlayerSplit { get; set; } = new();
        public bool PlayerSplitActive { get; set; } = false;
        public List<Card> ComputerCards { get; set; } = new();      
        public string PlayerMove { get; set; }

    }
}
