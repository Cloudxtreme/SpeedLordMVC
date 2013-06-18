using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SpeedLord.Models;

namespace SpeedLord.Controllers
{
    public class StreetController : Controller
    {
        //
        // GET: /Street/

        public JsonResult Index()
        {
            var screenResult = new ScreenResult
            {
                OutputText = "You are in the street",
                ScreenOptions = new List<ScreenOption> { new ScreenOption { CommandKey = "F", Description = "Go To the [F]orest", PostUrl = "Forest" } }
            };
            var data = JsonConvert.SerializeObject(screenResult);

            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
