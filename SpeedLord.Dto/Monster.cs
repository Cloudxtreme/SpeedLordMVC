using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedLord.Dto
{
    public class Monster
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string WeaponName { get; set; }
        public int MaxHp { get; set; }

        /// <summary>
        /// Minimum Level a playe rmust be to see this monster
        /// </summary>
        public int MinLevel { get; set; }

        /// <summary>
        /// Maximum level a player must be before he no longer sees this monster
        /// </summary>
        public int MaxLevel { get; set; }
    }
}
