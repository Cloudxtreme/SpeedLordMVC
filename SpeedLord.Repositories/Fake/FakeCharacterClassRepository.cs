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
        private IAbilityRepository _abilityRepository;
        public FakeCharacterClassRepository(IAbilityRepository abilityRepository)
        {
            _abilityRepository = abilityRepository;

            var mightyBlow = _abilityRepository.GetAbilityByName("Mighty Blow");
            var heal = _abilityRepository.GetAbilityByName("Total Heal");
            var dissapear = _abilityRepository.GetAbilityByName("Dissapear");
            var ironSkin = _abilityRepository.GetAbilityByName("Iron Skin");
            var backstab = _abilityRepository.GetAbilityByName("Backstab");
            var fireball = _abilityRepository.GetAbilityByName("Fireball");

            _allCharacterClasses = new List<CharacterClass>
                {
                    new CharacterClass { 
                        Id = 1,
                        Name = "Death Knight",
                        AbilityAwards = new Dictionary<int, Ability>{ {1, mightyBlow} }
                    },
                    new CharacterClass { 
                        Id = 2,
                        Name = "Thief",
                        AbilityAwards = new Dictionary<int, Ability>{ {1, backstab} }
                    },
                    new CharacterClass { 
                        Id = 3,
                        Name = "Mage",
                        AbilityAwards = new Dictionary<int, Ability>{ {1, fireball} }
                    },
                };
        }

        public CharacterClass GetCharacterClassByName(string className)
        {
            if(_allCharacterClasses.All(cc=> cc.Name!= className))
                throw new ArgumentException("Character Class Name not found: " + className);

            return _allCharacterClasses.First(a => a.Name == className);
        }
    }
}
