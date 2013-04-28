using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Interfaces.Repositories;
using SpeedLord.Dto;

namespace SpeedLord.Repositories.Fake
{
    public class FakeCharacterClassRepository : ICharacterClassRepository
    {
        private IEnumerable<CharacterClass> _allCharacterClasses; 
        public FakeCharacterClassRepository()
        {
        }

        public CharacterClass GetCharacterClassByName(string className)
        {
            throw new NotImplementedException();
        }
    }
}
