using System;
using System.Collections.Generic;
using System.Text;
using RPG.Champions;
using RPG.Services.Fight;

namespace RPG
{
     sealed class Game 
    {
        private readonly FightService _fightService;
        public List<Champion> Champions = new List<Champion>();
        public Game(FightService fightService)
        {
            _fightService = fightService;
        }
        public Game AddChampion(Champion champion)
        {
            Champions.Add(champion);
            Console.WriteLine(champion.GetName() + " added to game.");

            return this;
        }
        public void Tournament()
        {
            _fightService.Fight();
        }

    }
}
