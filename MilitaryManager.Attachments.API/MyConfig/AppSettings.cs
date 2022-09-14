using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.MyConfig
{
    public class AppSettings
    {
        public string StoreMode { get; set; }
        public ClientConfig clientConfig;
        public void ClientConfigBuild()
        {
            clientConfig = new ClientConfig(new ClientConfigOptions()
            {
                StoreMode = this.StoreMode
            });
        }
    }
}
