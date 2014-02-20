using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SpeedLord.App;
using SpeedLord.Models;

namespace SpeedLord.Controllers
{
    public class CombatController : BaseController
    {
        public JsonResult Attack()
        {
            if (StateManager.CurrentCombat == null)
            {
                return NoCombat();
            }

            //there should be some factor that decides who attacks first, weapon damage, critical hit etc, we're just going to go 1-2 at first
            var r = new Random();
            var playerDamage = r.Next(1, 10);
            var monsterDamage = r.Next(1, 5);

            StateManager.CurrentCombat.MonsterCurrentHp -= playerDamage;
            StateManager.CurrentCharacter.HitPoints -= monsterDamage;

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("You did {0} damage", playerDamage));
            stringBuilder.AppendLine(string.Format("{0} did {1} damage", StateManager.CurrentCombat.Monster.Name, monsterDamage));
            stringBuilder.AppendLine(string.Format("Your current HP is: {0}", StateManager.CurrentCharacter.HitPoints));

            //check for victory or defeat
            

            if (StateManager.CurrentCharacter.HitPoints <= 0)
            {
                return Defeat();
            }
            if (StateManager.CurrentCombat.MonsterCurrentHp <= 0)
            {
                return Victory();
            }

            var screenResult = new ScreenResult
            {
                OutputText = stringBuilder.ToString(),
                ScreenOptions = new List<ScreenOption>
                    {
                        new ScreenOption { CommandKey = "A", Description = "[A]ttack", PostUrl = "/Combat/Attack" },
                        new ScreenOption { CommandKey = "R", Description = "[R]un", PostUrl = "/Combat/Run" }
                    }
            };

            return SerializeScreenResult(screenResult);

        }

        public JsonResult NoCombat()
        {
            var screenResult = new ScreenResult
            {
                OutputText = "You are not in combat",
                ScreenOptions = new List<ScreenOption> { new ScreenOption { CommandKey = "S", Description = "Go To the [S]treet", PostUrl = "/Street" } }
            };

            return SerializeScreenResult(screenResult);
        }

        private JsonResult Defeat()
        {
            StateManager.CurrentCharacter.IsDead = true;

            var screenResult = new ScreenResult
            {
                OutputText = "You are dead",
                ScreenOptions = new List<ScreenOption>(),
            };

            return SerializeScreenResult(screenResult);
        }

        private JsonResult Victory()
        {
            StateManager.CurrentCharacter.IsDead = true;

            var screenResult = new ScreenResult
            {
                OutputText = "You have won",
                ScreenOptions = new List<ScreenOption>(),
            };

            StateManager.CurrentCombat = null;

            return SerializeScreenResult(screenResult);
        }

    }
}
