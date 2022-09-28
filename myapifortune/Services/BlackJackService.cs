using Microsoft.Extensions.Caching.Memory;
using MyAPIFortune.Interfaces;
using MyAPIFortune.Models;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace MyAPIFortune.Services
{
    public class BlackJackService : IBlackJack
    {
        // storage for the each blackjack game
        private readonly IMemoryCache _gameCache;
        
        public BlackJackService(IMemoryCache GameCache)
        {
            _gameCache = GameCache;
        }

        private void Cache_AddGame(BlackJackGame g)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
              // Keep in cache for this time, reset time if accessed.
              .SetSlidingExpiration(TimeSpan.FromMinutes(8 * 60)); //  8 hours
            _ = _gameCache.Set(g.Id, g, cacheEntryOptions);
        }

        private void Cache_UpdateGame(BlackJackGame g)
        {
            _gameCache.Remove(g.Id);
            Cache_AddGame(g);
        }

        private BlackJackGame Cache_GetGame(string key)
        {
            var cacheEntry = _gameCache.Get<BlackJackGame>(key);

            return cacheEntry;
        }

        private void Cache_RemoveGame(string key)
        {
            _gameCache.Remove(key);

        }

        private BlackJackGame Cache_PlayGame(BlackJackGame game)
        {

            BlackJackGame g = Cache_GetGame(game.Id);

            if (g == null)
            {
                string tempId = Guid.NewGuid().ToString();

                g = new BlackJackGame();
                g.Id = tempId;
                g.PlayerWins = 0;
                g.ComputerWins = 0;
                g.Deck = InitCards();
                g.DiscardDeck = new List<Card>();

                Cache_AddGame(g);
            }

            return g;
        }





    public BlackJackMoveResult PlayBlackJack(GameMove move)
        {
            BlackJackGame game = new();

            if (move.InstanceID == null) move.InstanceID = "";
            game.Id = move.InstanceID;
            game = Cache_PlayGame(game); // if the instance does not exist a new game will be started. 
            game.PlayerMove = move.Move.ToLower().Trim(); 

           return  ProcessMove(game);


        }

        // Process Move Commands 
        // HELP = Provides these commands
        // BET # = bets 1 or # of points and starts a hand
        // HIT = Deal a card for main hand
        // HITSP = Deal card for Split Hand
        // STAND = Player lets computer finish the game on main hand
        // STANDSP = Player lets computer finish the game on hand
        // RULES = Displays = Deck is 52 cards w/o Jokers and shuffles when last card is used. House draws on 16 or less and stands on 17. Splits are equal bets or points remaining. BlackJack pays 2x Bet. Game ends when player has 0 points or reaches 50000 points.
        // SPLIT = Can Split when player gets 2 of the same card. Splits are equal bets or points remaining.
        // QUIT or RESET = Ends the game session and starts the game over. 
        //
        // Note - When you deal the next card if you run out of cards the deck reset needs to remove the cards in the players and computers hands from the deck
        // Get the new deck and then use linq to remove the card by Id. 

        private BlackJackMoveResult ProcessMove(BlackJackGame game)
        {
            BlackJackMoveResult bmr = new();

            return bmr; 
        }






























   

        private List<Card> InitCards()
        {
            List<Card> Deck = new()
            {
                new Card { Id=1, Name = "Ace of Dimonds", Value = 0 },
                new Card { Id=2, Name = "King of Diamonds", Value = 10},
                new Card { Id=3, Name = "Queen of Diamonds", Value = 10},
                new Card { Id=4, Name = "Jack of Diamonds", Value = 10},
                new Card { Id=5, Name = "10 of Diamonds", Value = 10},
                new Card { Id=6, Name = "9 of Diamonds", Value = 10},
                new Card { Id=7, Name = "8 of Diamonds", Value = 10},
                new Card { Id=8, Name = "7 of Diamonds", Value = 10},
                new Card { Id=9, Name = "6 of Diamonds", Value = 10},
                new Card { Id=10, Name = "5 of Diamonds", Value = 10},
                new Card { Id=11, Name = "4 of Diamonds", Value = 10},
                new Card { Id=12, Name = "3 of Diamonds", Value = 10},
                new Card { Id=13, Name = "2 of Diamonds", Value = 10},
                new Card { Id=14, Name = "Ace of Hearts", Value = 0 },
                new Card { Id=15, Name = "King of Hearts", Value = 10},
                new Card { Id=16, Name = "Queen of Hearts", Value = 10},
                new Card { Id=17, Name = "Jack of Hearts", Value = 10},
                new Card { Id=18, Name = "10 of Hearts", Value = 10},
                new Card { Id=19, Name = "9 of Hearts", Value = 10},
                new Card { Id=20, Name = "8 of Hearts", Value = 10},
                new Card { Id=21, Name = "7 of Hearts", Value = 10},
                new Card { Id=22, Name = "6 of Hearts", Value = 10},
                new Card { Id=23, Name = "5 of Hearts", Value = 10},
                new Card { Id=24, Name = "4 of Hearts", Value = 10},
                new Card { Id=25, Name = "3 of Hearts", Value = 10},
                new Card { Id=26, Name = "2 of Hearts", Value = 10},
                new Card { Id=27, Name = "Ace of Spades", Value = 0 },
                new Card { Id=28, Name = "King of Spades", Value = 10},
                new Card { Id=29, Name = "Queen of Spades", Value = 10},
                new Card { Id=30, Name = "Jack of Spades", Value = 10},
                new Card { Id=31, Name = "10 of Spades", Value = 10},
                new Card { Id=32, Name = "9 of Spades", Value = 10},
                new Card { Id=33, Name = "8 of Spades", Value = 10},
                new Card { Id=34, Name = "7 of Spades", Value = 10},
                new Card { Id=35, Name = "6 of Spades", Value = 10},
                new Card { Id=36, Name = "5 of Spades", Value = 10},
                new Card { Id=37, Name = "4 of Spades", Value = 10},
                new Card { Id=38, Name = "3 of Spades", Value = 10},
                new Card { Id=39, Name = "2 of Spades", Value = 10},
                new Card { Id=40, Name = "Ace of Clubs", Value = 0 },
                new Card { Id=41, Name = "King of Clubs", Value = 10},
                new Card { Id=42, Name = "Queen of Clubs", Value = 10},
                new Card { Id=43, Name = "Jack of Clubs", Value = 10},
                new Card { Id=44, Name = "10 of Clubs", Value = 10},
                new Card { Id=45, Name = "9 of Clubs", Value = 10},
                new Card { Id=46, Name = "8 of Clubs", Value = 10},
                new Card { Id=47, Name = "7 of Clubs", Value = 10},
                new Card { Id=48, Name = "6 of Clubs", Value = 10},
                new Card { Id=49, Name = "5 of Clubs", Value = 10},
                new Card { Id=50, Name = "4 of Clubs", Value = 10},
                new Card { Id=51, Name = "3 of Clubs", Value = 10},
                new Card { Id=52, Name = "2 of Clubs", Value = 10}
            };

            List<Card> ShuffeledDeck = new();

            while (Deck.Count > 0)
            {
                var R = new Random();
                var CardSelection = R.Next(Deck.Count);
                Card Selection = Deck[CardSelection];
                ShuffeledDeck.Add(Selection);
                Deck.RemoveAt(CardSelection);

            }

            return ShuffeledDeck;

        }




    }
}
