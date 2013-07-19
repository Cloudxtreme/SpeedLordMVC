using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedLord.Interfaces.Repositories;

namespace SpeedLord.Repositories.Fake
{
    public class FakeCombatRepository : ICombatRepository
    {
        public Dto.Combat StartCombat()
        {
            throw new NotImplementedException();
        }

        public Dto.Combat EndCombat(Guid combatId, Dto.CombatOutcome outcome)
        {
            throw new NotImplementedException();
        }
    }
}
