using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedLord.Dto
{
    public enum CombatOutcome
    {
        Victory = 1,
        Defeat = 2,
        RanAway =3,
    }

    public class Combat
    {
        public Guid Id { get; set; }
        public int CharacterId { get; set; }
        public int MonsterId { get; set; }
        public int MonsterCurrentHp { get; set; }
        public CombatOutcome Outcome { get; set; }
        public int NumberOfTurns { get; set; }
    }
}
