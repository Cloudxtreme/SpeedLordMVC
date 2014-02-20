using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Dto;
using SpeedLord.Interfaces.Repositories;

namespace SpeedLord.Repositories.Fake
{
    public class FakeCombatRepository : ICombatRepository
    {
        public Dto.Combat StartCombat(int characterId, Monster monster)
        {
            return new Combat
                {
                    CharacterId = characterId,
                    Id = Guid.NewGuid(),
                    Monster = monster,
                    MonsterCurrentHp = monster.MaxHp,
                };
        }

        public Dto.Combat EndCombat(Guid combatId, Dto.CombatOutcome outcome)
        {
            throw new NotImplementedException();
        }
    }
}
