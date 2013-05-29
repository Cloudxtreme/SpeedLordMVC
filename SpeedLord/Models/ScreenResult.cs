using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedLord.Models
{
    public class ScreenResult
    {
        public string OutputText { get; set; }
        public IEnumerable<ScreenOption> ScreenOptions { get; set; }
    }
}