using RPG.Champions;
using RPG.Interfaces;
using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services.Fight
{
    public class DamageService
    {
        private readonly IMessageFactory _messageFactory;

        public DamageService(IMessageFactory messageFactory)
        {
            _messageFactory = messageFactory;
        }
        public void Hit(Champion attacker, Champion defender, int dmg, bool crit, Skill skill)
        {
            var messageService = _messageFactory.Create();
            defender.LifeReduct(dmg);
            if (skill != null)
            {
                messageService.Skill(attacker.GetName(), defender.GetName(), defender.CurrentHealth, skill);

            }
            else if (crit)
            {
                messageService.Crit(attacker.GetName(), defender.GetName(), dmg, defender.CurrentHealth);

            }
            else
            {
                messageService.Hit(attacker.GetName(), defender.GetName(), dmg, defender.CurrentHealth);
            }
        }


    }
}
