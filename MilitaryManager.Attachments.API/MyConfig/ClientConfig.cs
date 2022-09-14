using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.MyConfig
{
    public class ClientConfig
    {
        private string _storeMode;
        public string Value => _storeMode;
        public ClientConfig(ClientConfigOptions configOptions)
        {
            _storeMode = configOptions.StoreMode;
        }
    }
}
