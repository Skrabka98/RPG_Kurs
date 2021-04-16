using System;
using System.Collections.Generic;
using System.Text;
using RPG.Champions;
using RPG.Interfaces;
using RPG.Services.Fight;

namespace RPG
{
     sealed class Game 
    {
        public List<Champion> Champions = new List<Champion>();
        private readonly FightService _fightService;
        private readonly IMessageFactory _messageFactory;
        public Game(FightService fightService, IMessageFactory messageFactory)
        {
            _fightService = fightService;
            _messageFactory = messageFactory;
           
        }
        public Game AddChampion(Champion champion)
        {

            Champions.Add(champion);
            Console.WriteLine(champion.GetName() + " added to game.");
            return this;
        }
        public void Tournament()
        {
            Decision();
            _fightService.Fight(Champions);
        }
        public void Decision()
        {
            string answer;
            Console.WriteLine("Zapisać do pliku? (Yes)");
            answer = Console.ReadLine();
            if (answer.ToLower() == "yes")
            {
                _messageFactory.Create(true);
            }
            else
            {
                _messageFactory.Create();
            }

        }

    }
}
