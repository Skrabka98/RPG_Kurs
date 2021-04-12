using System;
using System.Collections.Generic;
using System.Text;
using RPG.Champions;
using RPG.Services.Fight;

namespace RPG
{
    sealed class Game
    {
        
        public List<Champion> Champions { get; set; } = new List<Champion>();
        public Game AddChampion(Champion champion)
        {
            Champions.Add(champion);
            Console.WriteLine(champion.GetName() + " added to game.");

            return this;
        }
        public void Tournament()
        {
            FightService fightService = new FightService(Champions);
            fightService.Fight();
        }

    }
}
