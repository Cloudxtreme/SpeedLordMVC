using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedLord.Dto
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public List<Ability> CurrentAbilities { get; set; }
        public List<Ability> AvailableAbilities { get; set; }
        public int AbilityPoints { get; set; }
        public int CharmPoints { get; set; }
        public int XP { get; set; }
        public int AbilityXP { get; set; }

    }
}
