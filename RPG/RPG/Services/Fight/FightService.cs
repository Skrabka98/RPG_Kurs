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
        private LeaderService _leaderService;

        public FightService(List<Champion> Champions)
        {
            _Champions = Champions;
            _leaderService = new LeaderService(_Champions.Count);
        }
        public void Fight()
        {
            
            int damage;
            while (_Champions.Count > 1)
            {
                var player1 = _Champions[0];
                var player2 = _Champions[1];
                Console.WriteLine("\nWalka: " + _Champions[0].GetName() + " vs " + _Champions[1].GetName() + "\n");
                player1.RestartHp();
                player2.RestartHp();
                while (player1.CurrentHealth > 0 && (player2.CurrentHealth > 0))
                {
                    if (IsHit(player1.MissChance))
                    {
                        damage = HitDmg(player1.MinDmg, player1.MaxDmg);
                        if (IsCritical(player1.CanCrit))
                        {
                            player2.LifeReduct(CritDmg(damage));
                            Console.WriteLine(player1.GetName() + " Trafił krytycznie " + player2.GetName() + " za " + CritDmg(damage) + " Jego obecny poziom życia wynosi " + player2.CurrentHealth);

                        }
                        else
                        {
                            player2.LifeReduct(damage);
                            Console.WriteLine(player1.GetName() + " Trafił " + player2.GetName() + " za " + damage + " Jego obecny poziom życia wynosi " + player2.CurrentHealth);
                        }
                    }
                    else { Console.WriteLine(player1.GetName() + " nie trafił!"); }
                    if (player2.CurrentHealth <= 0) 
                    {
                        _leaderService.AddToLadder(player2);
                        _Champions.RemoveAt(1);
                        Console.WriteLine("\nZwynięża " + player1.GetName() + "\n");
                        break;
                    }
                    if (IsHit(player2.MissChance))
                    {
                        damage = HitDmg(player2.MinDmg, player2.MaxDmg);
                        if (IsCritical(player2.CanCrit))
                        {
                            player1.LifeReduct(CritDmg(damage));
                            Console.WriteLine(player2.GetName() + " Trafił krytycznie " + player1.GetName() + " za " + CritDmg(damage) + " Jego obecny poziom życia wynosi " + player1.CurrentHealth);
                        }
                        else
                        {
                            player1.LifeReduct(damage);
                            Console.WriteLine(player2.GetName() + " Trafił " + player1.GetName() + " za " + damage + " Jego obecny poziom życia wynosi " + player1.CurrentHealth);
                        }
                    }
                    else { Console.WriteLine(player2.GetName() + " nie trafił!"); }
                    if (player1.CurrentHealth <= 0)
                    {
                        _leaderService.AddToLadder(player1);
                        _Champions.RemoveAt(0);
                        Console.WriteLine("\nZwynięża " + player1.GetName() + "\n");
                        break;
                    }
                }
            }
            _leaderService.AddToLadder(_Champions[0]);
            _leaderService.LadderSystem();

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
        public bool IsHit(int missChance)
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
