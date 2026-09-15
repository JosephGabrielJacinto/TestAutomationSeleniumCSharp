using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.DataModel
{
    public class Account
    {
        public string ValidUsername { get; set; }
        public string ValidPassword { get; set; }

        public string InvalidUsername { get; set; }

        public string InvalidPassword { get; set; }
    }
}
