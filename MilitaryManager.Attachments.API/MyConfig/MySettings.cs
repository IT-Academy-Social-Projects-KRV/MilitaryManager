using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Configuration;
using System.Dynamic;
using System.IO;


namespace MilitaryManager.Attachments.API.MyConfig
{
    public class MySettings 
    {
        private readonly AppSettings _appSettings;
        public  MySettings(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public enum ModesOfStorage
        {
            Azure,
            Local,
            Docker
        }
        public void DoConfiguration()
        {

            if (Internet.CheckConnection())
            {
                _appSettings.StoreMode = ModesOfStorage.Azure.ToString();
                _appSettings.ClientConfigBuild();
            }
            else
            {
                _appSettings.StoreMode = ModesOfStorage.Local.ToString();
                _appSettings.ClientConfigBuild();
            }
        }
        
    }
}
