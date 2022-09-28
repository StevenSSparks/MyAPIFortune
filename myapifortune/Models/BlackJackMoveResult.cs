namespace MyAPIFortune.Models
{
    public class BlackJackMoveResult
    {
        public string GameId { get; set; } = string.Empty;
        public string PlayerWins { get; set; } = string.Empty;
        public string ComputerWins { get; set; } = string.Empty;
        public string PlayerPoints { get; set; } = string.Empty;
        public List<Card> ComputerCards { get; set; } = new();
        public List<Card> PlayerCards { get; set; } = new();
        public List<Card> PlayerSplitCards { get; set; } = new();
        public bool PlayerCardsActive { get; set; } = false;
        public bool PlayerSplitActive { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
