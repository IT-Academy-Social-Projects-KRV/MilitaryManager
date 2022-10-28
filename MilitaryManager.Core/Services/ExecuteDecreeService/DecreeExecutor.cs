using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryManager.Core.Services.ExecuteDecreeService
{
    public class DecreeExecutor
    {
        private readonly List<IDecreeExecutor> _decreeExecutors;

        public DecreeExecutor()
        {
            _decreeExecutors = new List<IDecreeExecutor>()
            {
                new ProtocolDecreeExecutor(),
                new PayoffDecreeExecutor(),
                new TransferDecreeExecutor(),
            };
        }

        public void ExecuteOperation(int templateId, int decreeId)
        {
            var executor = _decreeExecutors.FirstOrDefault(x => x.TemplateId == templateId);
            executor.ExecuteOperation(decreeId);
        }
    }
}
