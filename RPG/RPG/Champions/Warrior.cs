using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Champions
{
    class Warrior : Champion
    {
        public Warrior(string name) : base(name)
        {
            Health = 200;
            CurrentHealth = Health;
            MinDmg = 5;
            MaxDmg = 7;
            CanCrit = true;
            MissChance = 40;
        }
        public override List<Skill> GetSkills()
        {
            return new List<Skill>
            {
                new HeavenlySword(),
                new EnergyBlade()
            };
        }
    }
}
