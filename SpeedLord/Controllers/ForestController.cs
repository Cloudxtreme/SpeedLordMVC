using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SpeedLord.App;
using SpeedLord.Models;

namespace SpeedLord.Controllers
{
    public class ForestController : Controller
    {
        //
        // GET: /Forest/

        public JsonResult Index()
        {
            var screenResult = new ScreenResult
            {
                OutputText = "You are in the Forest",
                ScreenOptions = new List<ScreenOption>
                    {
                        new ScreenOption { CommandKey = "L", Description = "[L]ook for something to kill.", PostUrl = "Forest/Look" },
                        new ScreenOption { CommandKey = "H", Description = "[H]ealers Hut", PostUrl = "Healer" },
                        new ScreenOption { CommandKey = "R", Description = "[R]eturn to Town", PostUrl = "Street" },
                    }
            };
            var data = JsonConvert.SerializeObject(screenResult);

            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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
            }

            var screenResult = new ScreenResult
            {
                OutputText = "You are too tired, perhaps tomorrow",
                ScreenOptions = new List<ScreenOption>
                    {
                        new ScreenOption { CommandKey = "L", Description = "[L]ook for something to kill.", PostUrl = "Forest/Look" },
                        new ScreenOption { CommandKey = "H", Description = "[H]ealers Hut", PostUrl = "Healer" },
                        new ScreenOption { CommandKey = "R", Description = "[R]eturn to Town", PostUrl = "Street" },
                    }
            };

            var data = JsonConvert.SerializeObject(screenResult);

            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
