using MyAPIFortune.Models;

namespace MyAPIFortune.Interfaces
{
    public interface IBlackJack
    {
        public BlackJackMoveResult PlayBlackJack(GameMove move);

    }
}
