using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Interfaces.Repositories;

namespace SpeedLord.Repositories.Fake
{
    class FakeCharacterClassRepository : ICharacterClassRepository
    {
        public Dto.CharacterClass GetCharacterClassByName(string className)
        {
            throw new NotImplementedException();
        }
    }
}
