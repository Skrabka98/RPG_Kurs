using RPG.Skills;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RPG.Services
{
    class PrintToFileService : IMessageService
    {
        public void Crit(string attacker, string defender, int damage, int defenderHealt)
        {
            string text = attacker + " Trafił krytycznie " + defender + " za " + damage + " Jego obecny poziom życia wynosi " + defenderHealt + Environment.NewLine;
            File.AppendAllText("fight.txt", text);
        }

        public void Hit(string attacker, string defender, int damage, int defenderHealt)
        {
            string text = attacker + " Trafił " + defender + " za " + damage + " Jego obecny poziom życia wynosi " + defenderHealt + Environment.NewLine;
            File.AppendAllText("fight.txt", text);
        }

        public void Miss(string player)
        {
            string text = player + " nie trafił!" + Environment.NewLine;
            File.AppendAllText("fight.txt", text);
        }

        public void Skill(string attacker, string defender, int defenderHealt, Skill skill)
        {
            string text = attacker + " Trafił umiejętnością " + skill.GetName() + " " + defender + " za " + skill.Damage + " Jego obecny poziom życia wynosi " + defenderHealt + Environment.NewLine;
            File.AppendAllText("fight.txt", text);
        }

        public void StartFight(string player1, string player2)
        {
            string text = "Walka: " + player1 + " vs " + player2 + Environment.NewLine + Environment.NewLine;
            File.AppendAllText("fight.txt", text);
        }

        public void Winner(string winner)
        {
            string text = "Zwynięża " + winner + Environment.NewLine + Environment.NewLine;
            File.AppendAllText("fight.txt", text); ;
        }
    }
}
