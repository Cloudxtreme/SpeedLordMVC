using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedLord.Dto
{
    public class CharacterClass
    {
        public string Name { get; set; }
        public List<Ability> Abilities { get; set; }
    }
}
