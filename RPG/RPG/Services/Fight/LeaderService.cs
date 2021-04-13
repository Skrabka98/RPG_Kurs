using RPG.Champions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services.Fight
{
    class LeaderService
    {
        private int _numberOfChampion;
        List<Champion> Ladder = new List<Champion>();
        public LeaderService(int numberOfChampion)
        {
            _numberOfChampion = numberOfChampion;
        }
        public void LadderSystem()
        {
            
            
            Console.WriteLine("#################");
            foreach (var item in Ladder)
            {
                Console.WriteLine("Miejsce " + _numberOfChampion + ". Zajmuje " + item.GetName());
                _numberOfChampion--;
            }
            
        }
        public void AddToLadder(Champion champion)
        {
            Ladder.Add(champion);
        }
    }
}
