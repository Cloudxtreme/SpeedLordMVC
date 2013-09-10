using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Dto;
using SpeedLord.Interfaces.Repositories;

namespace SpeedLord.Repositories.Fake
{
    public class FakeMonsterRepository : IMonsterRepository
    {
        private List<Monster> _allMonsters;

        public FakeMonsterRepository()
        {
            _allMonsters = new List<Monster>
                {
                    new Monster
                        {
                            Id = Guid.NewGuid(),
                            Name = "Little Goblin",
                            MaxHp = 8,
                            MaxLevel = 3,
                            MinLevel = 1,
                            WeaponName = "Pointy Stick"
                        },
                     new Monster
                        {
                            Id = Guid.NewGuid(),
                            Name = "Normal Sized Goblin",
                            MaxHp = 10,
                            MaxLevel = 3,
                            MinLevel = 1,
                            WeaponName = "Very Pointy Stick"
                        },
                     new Monster
                        {
                            Id = Guid.NewGuid(),
                            Name = "Large Goblin",
                            MaxHp = 15,
                            MaxLevel = 4,
                            MinLevel = 1,
                            WeaponName = "Extremely Pointy Stick"
                        },
                };
        }

        public Dto.Monster GetRandomMonster(int playerLevel)
        {
            throw new NotImplementedException();
        }

        public Dto.Monster GetMonsterByName(string monsterName)
        {
            throw new NotImplementedException();
        }
    }
}
