using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SpeedLord.Models;

namespace SpeedLord.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Play()
        {
            return new JsonResult {Data = string.Empty };
        }

        
        public JsonResult Initialize()
        {
            var screenResult = new ScreenResult
                {
                    OutputText = "You have been initialized. Go to the street.",
                   ScreenOptions = new List<ScreenOption>{ new ScreenOption{ CommandKey = "S", Description = "Go To the [S]treet", PostUrl = "~/Street"}}
                };
            var data = JsonConvert.SerializeObject(screenResult);

            return new JsonResult{ Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}
