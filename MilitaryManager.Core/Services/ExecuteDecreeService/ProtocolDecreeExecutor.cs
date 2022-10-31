using System.Threading.Tasks;

namespace MilitaryManager.Core.Services.ExecuteDecreeService
{
    public class ProtocolDecreeExecutor : IDecreeExecutor
    {
        public int TemplateId => 1;

        public async Task ExecuteOperation(int decreeId)
        {

        }
    }
}
