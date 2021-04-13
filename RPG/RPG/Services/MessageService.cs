using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services
{
    class MessageService
    {
        public void Winner(string winner)
        {
            Console.WriteLine("\nZwynięża " + winner + "\n");
        }
        public void StartFight(string player1, string player2)
        {
            Console.WriteLine("\nWalka: " + player1 + " vs " + player2 + "\n");
        }
        public void Miss(string player)
        {
            Console.WriteLine(player + " nie trafił!");
        }
        public void Hit(string attacker, string defender, int damage, int defenderHealt)
        {
            Console.WriteLine(attacker + " Trafił " + defender + " za " + damage + " Jego obecny poziom życia wynosi " + defenderHealt);
        }
        public void Crit(string attacker, string defender, int damage, int defenderHealt)
        {
            Console.WriteLine(attacker + " Trafił krytycznie " + defender + " za " + damage + " Jego obecny poziom życia wynosi " + defenderHealt);
        }
        public void Skill(string attacker, string defender, int defenderHealt, Skill skill)
        {
            Console.WriteLine(attacker + " Trafił umiejętnością " + skill.GetName() + " " + defender + " za " + skill.Damage + " Jego obecny poziom życia wynosi " + defenderHealt);
        }
    }
}
