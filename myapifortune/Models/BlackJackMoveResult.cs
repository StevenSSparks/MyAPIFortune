namespace MyAPIFortune.Models
{
    public class BlackJackMoveResult
    {
        public string GameId { get; set; } = string.Empty;
        public string PlayerWins { get; set; } = string.Empty;
        public string ComputerWins { get; set; } = string.Empty;
        public List<Card> PlayerCards { get; set; } = new List<Card>();
        public List<Card> ComputerCards { get; set; } = new List<Card>();
        public string Message { get; set; } = string.Empty;
    }
}
