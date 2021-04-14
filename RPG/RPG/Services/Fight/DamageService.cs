using RPG.Champions;
using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services.Fight
{
    class DamageService
    {
        private MessageService MessageService = new MessageService();
        public void Hit(Champion attacker, Champion defender, int dmg, bool crit, Skill skill)
        {
            defender.LifeReduct(dmg);
            if (skill != null)
            {
                MessageService.Skill(attacker.GetName(), defender.GetName(), defender.CurrentHealth, skill);

            }
            else if (crit)
            {
                MessageService.Crit(attacker.GetName(), defender.GetName(), dmg, defender.CurrentHealth);

            }
            else
            {
                MessageService.Hit(attacker.GetName(), defender.GetName(), dmg, defender.CurrentHealth);
            }
        }


    }
}
