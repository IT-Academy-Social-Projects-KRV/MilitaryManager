using System.Threading.Tasks;

namespace MilitaryManager.Core.Services.ExecuteDecreeService
{
    public interface IDecreeExecutor
    {
        public int TemplateId { get; }
        public Task ExecuteOperation(int decreeId);
    }
}
