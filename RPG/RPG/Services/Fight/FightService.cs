using RPG.Champions;
using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services.Fight
{
    class FightService
    {
        List<Champion> _Champions;
        private readonly int critChance = 20;
        private LeaderService _leaderService;
        private DamageService DamageService = new DamageService();
        private MessageService _MessageService;
        private SkillService SkillService = new SkillService();
        public FightService(List<Champion> Champions, MessageService MessageService)
        {
            _Champions = Champions;
            _leaderService = new LeaderService(_Champions.Count);
            _MessageService = MessageService;
        }
        public void Fight()
        {
            int damage;
            while (_Champions.Count > 1)
            {
                var player1 = _Champions[0];
                var player2 = _Champions[1];
                _MessageService.StartFight(player1.GetName(), _Champions[1].GetName());
                _Champions[0].RestartHp();
                _Champions[1].RestartHp();
                while (player1.CurrentHealth > 0 && (player2.CurrentHealth > 0))
                {
                    
                    for (int i = 0; i < 2; i++)
                    {
                        if (IsHit(_Champions[i].MissChance))
                        {
                            damage = HitDmg(_Champions[i].MinDmg, _Champions[i].MaxDmg);
                            bool criticalHit = false;
                            Skill skill = SkillService.SkillHandler(_Champions[i], _Champions[i == 0 ? 1 : 0]);
                            if (skill != null)
                            {
                                damage = skill.Damage;
                            }
                            else if (IsCritical(_Champions[i].CanCrit))
                            {
                                criticalHit = true;
                                damage = CritDmg(damage);
                            }
                            DamageService.Hit(_Champions[i], _Champions[i == 0 ? 1 : 0], damage, criticalHit, skill);

                        }
                        else
                        {
                            _MessageService.Miss(_Champions[i].GetName());
                        }
                        if (_Champions[i == 0 ? 1 : 0].CurrentHealth <= 0)
                        {
                            _leaderService.AddToLadder(_Champions[i == 0 ? 1 : 0]);
                            _Champions.RemoveAt(i == 0 ? 1 : 0);
                            _MessageService.Winner(_Champions[0].GetName());
                            break;
                        }
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
