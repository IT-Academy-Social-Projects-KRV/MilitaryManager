using MilitaryManager.Core.Entities.DecreeDataEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services.ExecuteDecreeService
{
    public class DecreeExecutor
    {
        private readonly List<IDecreeExecutor> _decreeExecutors;

        public DecreeExecutor(IRepository<DecreeData, int> decreeDataRepository,
                              IRepository<Division, int> divisionRepository,
                              IRepository<Unit, int> unitRepository)
        {
            _decreeExecutors = new List<IDecreeExecutor>()
            {
                new ProtocolDecreeExecutor(),
                new PayoffDecreeExecutor(),
                new TransferDecreeExecutor(decreeDataRepository, divisionRepository, unitRepository),
            };
        }

        public async Task ExecuteOperation(int templateId, int decreeId)
        {
            var executor = _decreeExecutors.FirstOrDefault(x => x.TemplateId == templateId);
            await executor.ExecuteOperation(decreeId);
        }
    }
}
