using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SpeedLord.App;
using SpeedLord.Dto;
using SpeedLord.Models;
using SpeedLord.Interfaces.Repositories;

namespace SpeedLord.Controllers
{
    public class ForestController : BaseController
    {
        private readonly ICombatRepository _combatRepository;
        private readonly IMonsterRepository _monsterRepository;

        public ForestController(ICombatRepository combatRepository, IMonsterRepository monsterRepository)
        {
            _combatRepository = combatRepository;
            _monsterRepository = monsterRepository;
        }

        //
        // GET: /Forest/


        public JsonResult Index()
        {
            var screenResult = new ScreenResult
            {
                OutputText = "You are in the Forest",
                ScreenOptions = new List<ScreenOption>
                    {
                        new ScreenOption { CommandKey = "L", Description = "[L]ook for something to kill.", PostUrl = "/Forest/Look" },
                        new ScreenOption { CommandKey = "H", Description = "[H]ealers Hut", PostUrl = "/Healer" },
                        new ScreenOption { CommandKey = "R", Description = "[R]eturn to Town", PostUrl = "/Street" },
                    }
            };

            return SerializeScreenResult(screenResult);
        }


        public JsonResult Look()
        {
            if (StateManager.CurrentCharacter.EncountersLeft > 0)
            {
                /*
                Random r = new Random();
                var val = r.Next(1, 10);

                if (val < 8)
                {
                    //combat
                }
                else if (val == 8)
                {
                    //pixies
                }
                else if (val == 9)
                {
                    //story event (horse/olivia/castle etc)
                }
                else if (val == 10)
                {
                    //class event
                }*/

                //for now we'll always assume combat

                if (StateManager.CurrentCombat == null)
                {
                    Monster monster = _monsterRepository.GetRandomMonster(StateManager.CurrentCharacter.Level);
                    Combat cb = _combatRepository.StartCombat(StateManager.CurrentCharacter.Id, monster);


                    StateManager.CurrentCombat = cb;

                    var combatResult = new ScreenResult
                    {
                        OutputText = string.Format("You see a dangerous looking {0} wielding a {1}.", monster.Name,
                                                   monster.WeaponName),
                        ScreenOptions = new List<ScreenOption>
                        {
                            new ScreenOption { CommandKey = "A", Description = "[A]ttack", PostUrl = "/Combat/Attack" },
                            new ScreenOption { CommandKey = "R", Description = "[R]un Away", PostUrl = "/Street" },
                        }
                    };

                    var jsonCombatData = JsonConvert.SerializeObject(combatResult);

                    return new JsonResult { Data = jsonCombatData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                }


            }

            var screenResult = new ScreenResult
            {
                OutputText = "You are too tired, perhaps tomorrow",
                ScreenOptions = new List<ScreenOption>
                    {
                        new ScreenOption { CommandKey = "L", Description = "[L]ook for something to kill.", PostUrl = "/Forest/Look" },
                        new ScreenOption { CommandKey = "H", Description = "[H]ealers Hut", PostUrl = "/Healer" },
                        new ScreenOption { CommandKey = "R", Description = "[R]eturn to Town", PostUrl = "/Street" },
                    }
            };

            return SerializeScreenResult(screenResult);
        }

    }
}
