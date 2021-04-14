using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services
{
    class PrintToFileService : IMessageService
    {
        public void Crit(string attacker, string defender, int damage, int defenderHealt)
        {
            throw new NotImplementedException();
        }

        public void Hit(string attacker, string defender, int damage, int defenderHealt)
        {
            Console.WriteLine("Kupaa");
        }

        public void Miss(string player)
        {
            throw new NotImplementedException();
        }

        public void Skill(string attacker, string defender, int defenderHealt, Skill skill)
        {
            throw new NotImplementedException();
        }

        public void StartFight(string player1, string player2)
        {
            throw new NotImplementedException();
        }

        public void Winner(string winner)
        {
            throw new NotImplementedException();
        }
    }
}
