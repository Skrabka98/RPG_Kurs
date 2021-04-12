using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Champions
{
     class Archer : Champion
    {
        public Archer(string name) : base(name)
        {
            Health = 150;
            CurrentHealth = Health;
            MinDmg = 7;
            MaxDmg = 10;
            CanCrit = true;
            MissChance = 20;
        }
        public override List<Skill> GetSkills()
        {
            return new List<Skill>
            {
                new HeadShot()
            };
        }
    }
}
