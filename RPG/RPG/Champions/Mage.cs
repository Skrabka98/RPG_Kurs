using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Champions
{
    class Mage : Champion
    {
        public Mage(string name) : base(name)
        {
            Health = 90;
            CurrentHealth = Health;
            MinDmg = 10;
            MaxDmg = 15;
            CanCrit = false;
            MissChance = 0;
        }
        public override List<Skill> GetSkills()
        {
            return new List<Skill>
            {
                
            };
        }

    }
}