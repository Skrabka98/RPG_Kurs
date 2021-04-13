using System;
using System.Collections.Generic;
using System.Text;

namespace RPG.Skills
{
    public abstract class Skill
    {
        public int Damage { get; set; }
        public int UseChance { get; set; }



        public string GetName()
        {
            return GetSpecies() + " ";
        }

        private string GetSpecies()
        {
            return GetType().Name;
        }


    }
}
