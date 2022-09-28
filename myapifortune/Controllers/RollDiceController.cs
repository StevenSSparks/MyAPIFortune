using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyAPIFortune.Interfaces;
using MyAPIFortune.Models;

namespace MyAPIFortune.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false)]
    public class RollDiceController : Controller
    {

        private readonly IDiceRolling _diceRolling;
      
        public RollDiceController(IDiceRolling diceRolling)
        {
            _diceRolling = diceRolling;
        }

        [EnableCors("CORSPolicy")]
        [Route("/api/RollDice/DND")]
        [HttpGet]
        public List<Dice> RoleDiceExample()
        {

            List<Dice> dices = new List<Dice> { new Dice { RoleValue = 0, SideCount = 4},
                                                new Dice { RoleValue = 0, SideCount = 6},
                                                new Dice { RoleValue = 0, SideCount = 8},
                                                new Dice { RoleValue = 0, SideCount = 10},
                                                new Dice { RoleValue = 0, SideCount = 12},
                                                new Dice { RoleValue = 0, SideCount = 20}
                                              };

            return _diceRolling.RollDice(dices);
        }

        [EnableCors("CORSPolicy")]
        [Route("/api/RollDice/{sides}")]
        [HttpGet]
        public int RoleNSidedDice(int sides)
        {
            return _diceRolling.RollDice(new List<Dice> { new Dice { RoleValue = 0, SideCount = sides } })[0].RoleValue;
        }


        [EnableCors("CORSPolicy")]
        [Route("/api/RollDice")]
        [HttpPost]
        public List<Dice> RoleDice([FromBody] List<Dice> dices)
        {
            return _diceRolling.RollDice(dices);
        }


    }
}
