using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedLord.Dto
{
    public class CharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Ability> AbilityAwards { get; set; }
    }
}
