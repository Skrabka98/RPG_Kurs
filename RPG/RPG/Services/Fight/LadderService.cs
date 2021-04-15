using RPG.Champions;
using RPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services.Fight
{
    class LadderService : ILadderService
    {
       private readonly List<Champion> Ladder = new List<Champion>();

        public void LadderSystem(int count)
        {
            Console.WriteLine("#################");
            foreach (var item in Ladder)
            {
                Console.WriteLine("Miejsce " + count + ". Zajmuje " + item.GetName());
                count--;
            }
            
        }
        public void AddToLadder(Champion champion)
        {
            Ladder.Add(champion);
        }
    }
}
