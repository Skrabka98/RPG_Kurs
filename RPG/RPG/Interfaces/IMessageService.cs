using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services
{
    public interface IMessageService
    {
        public void Winner(string winner);

        public void StartFight(string player1, string player2);

        public void Miss(string player);

        public void Hit(string attacker, string defender, int damage, int defenderHealt);


        public void Crit(string attacker, string defender, int damage, int defenderHealt);

        public void Skill(string attacker, string defender, int defenderHealt, Skill skill);

    }
}
