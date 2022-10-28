namespace MilitaryManager.Core.Services.ExecuteDecreeService
{
    public interface IDecreeExecutor
    {
        public int TemplateId { get; }
        public void ExecuteOperation(int decreeId);
    }
}
