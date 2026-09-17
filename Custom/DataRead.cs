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

        private static string _path = @"C:\Users\joseph jacinto\source\repos\MyTestAutomationSeleniumCSharp\data\";

        public static Account GetUserAccount()
        {
            string dataFromJson = File.ReadAllText($"{DataRead._path}Account.json");

            return JsonSerializer.Deserialize<Account>(dataFromJson);
        }


        public static Employee GetEmployee()
        {
            string dataFromJson = File.ReadAllText($"{DataRead._path}Employee.json");

            return JsonSerializer.Deserialize<Employee>(dataFromJson);
        }

    }
}
