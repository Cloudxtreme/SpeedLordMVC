using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
=======
using SpeedLord.Dto;
>>>>>>> adding monster repo
using SpeedLord.Interfaces.Repositories;

namespace SpeedLord.Repositories.Fake
{
    public class FakeCombatRepository : ICombatRepository
    {
<<<<<<< HEAD
        public Dto.Combat StartCombat()
        {
            throw new NotImplementedException();
=======
        public Dto.Combat StartCombat(int characterId)
        {
            return new Combat
                {
                    CharacterId = characterId,
                    Id = Guid.NewGuid(),
                };
>>>>>>> adding monster repo
        }

        public Dto.Combat EndCombat(Guid combatId, Dto.CombatOutcome outcome)
        {
            throw new NotImplementedException();
        }
    }
}
