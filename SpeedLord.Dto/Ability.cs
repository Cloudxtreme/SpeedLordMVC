using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Enums;

namespace SpeedLord.Dto
{
    public class Ability
    {
        public string Name { get; set; }
        public AbilityType AbilityType { get; set; }
        public int Modifier { get; set; }
        public int Cost { get; set; }
    }
}
