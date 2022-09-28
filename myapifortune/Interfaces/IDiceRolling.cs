using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPIFortune.Models;

namespace MyAPIFortune.Interfaces
{
    public interface IDiceRolling
    {
        /// <summary>
        /// Simulated role for a list of dice with various sides
        /// </summary>
        /// <param name="DiceList"></param>
        /// <returns></returns>
        public List<Dice> RollDice(List<Dice> DiceList);

 
    }
}
