using RPG.Champions;
using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Services.Fight
{
    class SkillService
    {
        MessageService MessageService = new MessageService();
        public Skill SkillHandler(Champion attacker, Champion defender)
        {

            for(int i = 0; i < attacker.GetSkills().Count; i++)
            {
                Skill skill = attacker.GetSkills()[i];
                if (UseSkill(skill.UseChance))
                {   
                    return skill;
                }
            }
            return null;
        }

        public bool UseSkill(int chance)
        {
            var rand = new Random();
            int skillChance = rand.Next(100);
            if (skillChance < chance)
            {
                return true;
            }
            return false;
        }
    }
}
