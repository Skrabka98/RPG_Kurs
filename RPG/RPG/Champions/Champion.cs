using RPG.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Champions
{
    abstract class Champion
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int CurrentHealth { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public bool CanCrit { get; set; }
        public int MissChance { get; set; }
        public Champion(string name)
        {
            Name = name;
        }
        public abstract List<Skill> GetSkills();
        public string GetName()
        {
            return GetSpecies() + " " + Name;
        }

        private string GetSpecies()
        {
            return GetType().Name;
        }
        public void LifeReduct(int damage)
        {
            CurrentHealth -= damage;
        }
        public void RestartHp()
        {
            CurrentHealth = Health;
        }

    }
}
