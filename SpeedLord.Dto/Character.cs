using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedLord.Dto
{
    public class Character
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID of the owning account
        /// </summary>
        public int OwnerAccountId { get; set; }

        /// <summary>
        /// Character Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Character Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Hit/Life Points
        /// </summary>
        public int HitPoints { get; set; }

        /// <summary>
        /// What abailities this character has access to
        /// </summary>
        public List<Ability> CurrentAbilities { get; set; }

        /// <summary>
        /// how many abilities this person has left today
        /// </summary>
        public List<Ability> AvailableAbilities { get; set; }

        /// <summary>
        /// Number of Magic points left today
        /// </summary>
        public int MagicPoints { get; set; }

        /// <summary>
        /// Charm level 0-100
        /// </summary>
        public int CharmPoints { get; set; }
        
        /// <summary>
        /// Experience Points
        /// </summary>
        public int XP { get; set; }

        /// <summary>
        /// Points towards a new ability
        /// </summary>
        public int AbilityXP { get; set; }

        /// <summary>
        /// What Realm this character belongs to
        /// </summary>
        public int RealmId { get; set; }
    }
}
