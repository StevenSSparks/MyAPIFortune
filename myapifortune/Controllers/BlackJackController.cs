using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyAPIFortune.Interfaces;
using MyAPIFortune.Models;

namespace MyAPIFortune.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    public class BlackJackController : Controller
    {

        private readonly IBlackJack _blackjackgame;
      
        public BlackJackController(IBlackJack blackJack)
        {
            _blackjackgame = blackJack;
        }

        [EnableCors("CORSPolicy")]
        [Route("/api/BlackJack/Play")]
        [HttpPost]
        public BlackJackMoveResult PlayBlackJack([FromBody] GameMove move)
        {
            return _blackjackgame.PlayBlackJack(move);
        }


    }
}
