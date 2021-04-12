using RPG.Champions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services.Fight
{
    class FightService
    {
        List<Champion> _Champions;
        List<Champion> Ladder = new List<Champion>();
        private readonly int critChance = 20;
        private int numberOfChampion;


        public FightService(List<Champion> Champions)
        {
            _Champions = Champions;
            numberOfChampion = _Champions.Count;
        }
        public void Fight()
        {
            int damage;
            while (_Champions.Count > 1)
            {
                Console.WriteLine("\nWalka: " + _Champions[0].GetName() + " vs " + _Champions[1].GetName() + "\n");
                _Champions[0].CurrentHealth = _Champions[0].Health;
                _Champions[1].CurrentHealth = _Champions[1].Health;
                while (_Champions[0].CurrentHealth > 0 && (_Champions[1].CurrentHealth > 0))
                {
                    if (IsMiss(_Champions[0].MissChance))
                    {
                        damage = HitDmg(_Champions[0].MinDmg, _Champions[0].MaxDmg);
                        if (IsCritical(_Champions[0].CanCrit))
                        {
                            _Champions[1].LifeReduct(CritDmg(damage));
                            Console.WriteLine(_Champions[0].GetName() + " Trafił krytycznie " + _Champions[1].GetName() + " za " + CritDmg(damage) + " Jego obecny poziom życia wynosi " + _Champions[1].CurrentHealth);

                        }
                        else
                        {
                            _Champions[1].LifeReduct(damage);
                            Console.WriteLine(_Champions[0].GetName() + " Trafił " + _Champions[1].GetName() + " za " + damage + " Jego obecny poziom życia wynosi " + _Champions[1].CurrentHealth);
                        }
                    }
                    else { Console.WriteLine(_Champions[0].GetName() + " nie trafił!"); }
                    if (_Champions[1].CurrentHealth <= 0) 
                    {
                        Ladder.Add(_Champions[1]);
                        _Champions.RemoveAt(1);
                        Console.WriteLine("\nZwynięża " + _Champions[0].GetName() + "\n");
                        break;
                    }
                    if (IsMiss(_Champions[1].MissChance))
                    {
                        damage = HitDmg(_Champions[1].MinDmg, _Champions[1].MaxDmg);
                        if (IsCritical(_Champions[1].CanCrit))
                        {
                            _Champions[0].LifeReduct(CritDmg(damage));
                            Console.WriteLine(_Champions[1].GetName() + " Trafił krytycznie " + _Champions[0].GetName() + " za " + CritDmg(damage) + " Jego obecny poziom życia wynosi " + _Champions[0].CurrentHealth);
                        }
                        else
                        {
                            _Champions[0].LifeReduct(damage);
                            Console.WriteLine(_Champions[1].GetName() + " Trafił " + _Champions[0].GetName() + " za " + damage + " Jego obecny poziom życia wynosi " + _Champions[0].CurrentHealth);
                        }
                    }
                    else { Console.WriteLine(_Champions[1].GetName() + " nie trafił!"); }
                    if (_Champions[0].CurrentHealth <= 0)
                    {
                        Ladder.Add(_Champions[0]);
                        _Champions.RemoveAt(0);
                        Console.WriteLine("\nZwynięża " + _Champions[0].GetName() + "\n");
                        break;
                    }
                }
            }
            LadderSystem();

        }
        public void LadderSystem()
        {
            Console.WriteLine("#################");
            foreach (var item in Ladder)
            {
                Console.WriteLine("Miejsce " + numberOfChampion + ". Zajmuje " + item.GetName());
                numberOfChampion--;
            }
            Console.WriteLine("Miejsce 1. Zajmuje " + _Champions[0].GetName());
        }
        public int HitDmg(int minDmg, int maxDmg)
        {
            var rand = new Random();
            int dmg = rand.Next(minDmg, maxDmg);
            return dmg;
        }

        public int CritDmg(int damage)
        {
            int critDamage = 2 * damage ;
            return critDamage;
        }
        public bool IsCritical(bool critical)
        {
            if (critical)
            {
                var rand = new Random();
                int dmg = rand.Next(100);
                if(dmg < critChance)
                {
                    return true;
                }
                
            }
            return false;
        }
        public bool IsMiss(int missChance)
        {
            if(missChance > 0)
            {
                var rand = new Random();
                int chance = rand.Next(100);
                if (chance > missChance)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
    }
}
