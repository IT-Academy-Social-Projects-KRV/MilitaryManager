using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services.ExecuteDecreeService
{
    public class PayoffDecreeExecutor : IDecreeExecutor
    {
        public int TemplateId => 2;

        public async Task ExecuteOperation(int decreeId)
        {

        }
    }
}
