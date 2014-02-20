using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SpeedLord.Models;

namespace SpeedLord.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected JsonResult SerializeScreenResult(ScreenResult screenResult)
        {
            var data = JsonConvert.SerializeObject(screenResult);
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
