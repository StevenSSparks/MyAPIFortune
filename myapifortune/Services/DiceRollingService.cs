using MyAPIFortune.Interfaces;
using MyAPIFortune.Models;


namespace MyAPIFortune.Services
{
    public class DiceRollingService : IDiceRolling
    {
        public List<Dice> RollDice(List<Dice> DiceList)
        {

            foreach (var item in DiceList)
            {
                if (item.SideCount == 0) item.SideCount = 0;
                else item.RoleValue = Roll(item.SideCount);
            }
            return DiceList;
        }


        private int Roll(int side)
        {
            var R = new Random();
            var roll = R.Next(1, side + 1);
            return roll;
        }

    }
}
