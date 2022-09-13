using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Configuration;
using System.Dynamic;
using System.IO;


namespace MilitaryManager.Attachments.API.MyConfig
{
    public static class MySettings
    {
        public enum ModesOfStorage
        {
            Azure,
            Local,
            Docker
        }
        public static void DoConfiguration()
        {
            var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json");
            var json = File.ReadAllText(appSettingsPath);

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new ExpandoObjectConverter());
            jsonSettings.Converters.Add(new StringEnumConverter());

            dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);

            if (Internet.CheckConnection())
            {
                config.StoreMode.Choosen = ModesOfStorage.Azure;
            }
            else
            {
                config.StoreMode.Choosen = ModesOfStorage.Local; 
            }

            var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);

            File.WriteAllText(appSettingsPath, newJson);
        }
        
    }
}
