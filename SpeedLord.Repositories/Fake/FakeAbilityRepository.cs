using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Enums;
using SpeedLord.Interfaces.Repositories;
using SpeedLord.Dto;

namespace SpeedLord.Repositories.Fake
{
    public class FakeAbilityRepository : IAbilityRepository
    {
        private IEnumerable<Ability> _allAbilities;

        public FakeAbilityRepository()
        {
            _allAbilities = new List<Ability>
                                {
                                    new Ability
                                        {
                                            AbilityType = AbilityType.Attack,
                                            Name = "Mighty Blow",
                                            Cost = 1,
                                            Modifier = 120
                                        },
                                    new Ability
                                        {
                                            AbilityType = AbilityType.Heal,
                                            Name = "Total Heal",
                                            Cost = 4,
                                            Modifier = 999
                                        },
                                    new Ability
                                        {
                                            AbilityType = AbilityType.Heal,
                                            Name = "Iron Skin",
                                            Cost = 2,
                                            Modifier = 30
                                        },
                                    new Ability
                                        {
                                            AbilityType = AbilityType.RunAway,
                                            Name = "Dissapear",
                                            Cost = 2,
                                            Modifier = 100
                                        },
                                   new Ability
                                        {
                                            AbilityType = AbilityType.Attack,
                                            Name = "Backstab",
                                            Cost = 1,
                                            Modifier = 100
                                        },
                                    new Ability
                                        {
                                            AbilityType = AbilityType.Attack,
                                            Name = "Fireball",
                                            Cost = 1,
                                            Modifier = 80
                                        },
                                };
        }

        public Ability GetAbilityByName(string name)
        {
            if(_allAbilities.All(a => a.Name != name))
                throw new ArgumentException("Ability Name not Found:" + name);

            return _allAbilities.First(a => a.Name == name);
        }
    }
}
