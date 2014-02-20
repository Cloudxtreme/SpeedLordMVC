using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Dto;
using SpeedLord.Interfaces.Repositories;

namespace SpeedLord.Repositories.Fake
{
    public class FakeCharacterRepository : ICharacterRepository
    {
        private IEnumerable<Character> _allCharacters;
        private IAbilityRepository _abilityRepository;
        public FakeCharacterRepository(IAbilityRepository abilityRepository)
        {
            _abilityRepository = abilityRepository;

            var mightyBlow = _abilityRepository.GetAbilityByName("Mighty Blow");
            var heal = _abilityRepository.GetAbilityByName("Total Heal");
            var dissapear = _abilityRepository.GetAbilityByName("Dissapear");
            var ironSkin = _abilityRepository.GetAbilityByName("Iron Skin");

            _allCharacters = new List<Character>
                                 {
                                     new Character { 
                                         Id = 1, Level = 3, Name = "Frodo", MagicPoints = 2, AbilityXP = 4, CharmPoints = 10, HitPoints = 30, XP = 3000, 
                                         AvailableAbilities = new List<Ability>{ mightyBlow, mightyBlow, mightyBlow}, 
                                         CurrentAbilities = new List<Ability>{ mightyBlow},
                                         OwnerAccountId = 1, EncountersLeft = 10,
                                     },
                                     new Character { 
                                         Id = 2, Level = 3, Name = "Samwise", MagicPoints = 3, AbilityXP = 6, CharmPoints = 20, HitPoints = 30, XP = 3000, 
                                         AvailableAbilities = new List<Ability>{ mightyBlow, mightyBlow, mightyBlow, heal}, 
                                         CurrentAbilities = new List<Ability>{ mightyBlow, heal},
                                         OwnerAccountId = 2,
                                     },
                                     new Character { 
                                         Id = 3, Level = 3, Name = "Gandalf", MagicPoints = 10, AbilityXP = 8, CharmPoints = 30, HitPoints = 30, XP = 3000, 
                                         AvailableAbilities = new List<Ability>{ mightyBlow, mightyBlow, mightyBlow, heal}, 
                                         CurrentAbilities = new List<Ability>{ mightyBlow, heal},
                                         OwnerAccountId = 3,
                                     },

                                 };
        }

        public Character GetCharacterById(int id)
        {
            if(_allCharacters.All(a=> a.Id != id))
                throw new ArgumentException("Invalid Character Id:" + id.ToString());

            return _allCharacters.First(c => c.Id == id);
        }

        public Character GetCharacterForAccount(int ownerAccountId)
        {
            if(_allCharacters.All(a=> a.OwnerAccountId != ownerAccountId))
                throw new ArgumentException("Invalid owner Account Id:" + ownerAccountId.ToString());

            return _allCharacters.First(c => c.OwnerAccountId == ownerAccountId);
        }
    }
}
