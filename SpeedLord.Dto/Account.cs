using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedLord.Dto
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}
