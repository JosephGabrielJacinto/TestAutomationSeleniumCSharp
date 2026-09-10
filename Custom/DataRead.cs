using Microsoft.Testing.Platform.Configurations;
using MyTestAutomationSeleniumCSharp.DataModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MyTestAutomationSeleniumCSharp.Custom
{
    public class DataRead
    {
        public static Account GetUserAccount()
        {
            string dataFromJson = File.ReadAllText(@"C:\Users\joseph jacinto\source\repos\MyTestAutomationSeleniumCSharp\data\Account.json");

            var userAccount = JsonSerializer.Deserialize<Account>(dataFromJson);

            return userAccount;
        }


    }
}
