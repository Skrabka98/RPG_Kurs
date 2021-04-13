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
        public List<Champion> Champions;
        public Game(FightService fightService, List<Champion> _Champions)
        {
            Champions = _Champions;
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
