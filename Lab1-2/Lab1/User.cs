using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; } = "";
        public bool is_blocked { get; set; } = false;
        public string role { get; set; } = "user";
        public bool disable_restrictions { get; set; } = false;
    }
}
