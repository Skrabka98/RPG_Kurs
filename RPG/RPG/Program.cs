using RPG.Champions;
using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.AddChampion(new Archer("Bonobo"))
                .AddChampion(new Mage("Dudu"))
                .AddChampion(new Warrior("Ciamajda"))
                .AddChampion(new Archer("NoName"))
                .AddChampion(new Mage("Kapucyn"));
            game.Tournament();
        }
    }
}
