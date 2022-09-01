using MilitaryManager.Attachments.API.Interfaces.Repositories;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API.Interfaces
{
    public interface IUnitOfWork
    {
        IDecreeRepository DecreeRepository { get; }
        IStatusRepository StatusRepository { get; }
        IStatusHistoryRepository StatusHistoryRepository { get; }
        ITemplateRepository TemplateRepository { get; }
        ITypeRepository TypeRepository { get; }

        Task SaveChangesAsync();
    }
}
