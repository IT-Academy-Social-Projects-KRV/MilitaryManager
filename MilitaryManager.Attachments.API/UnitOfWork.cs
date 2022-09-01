using MilitaryManager.Attachments.API.Data;
using MilitaryManager.Attachments.API.Interfaces;
using MilitaryManager.Attachments.API.Interfaces.Repositories;
using System.Threading.Tasks;

namespace MilitaryManager.Attachments.API
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
                          IDecreeRepository decreeRepository,
                          IStatusRepository statusRepository,
                          IStatusHistoryRepository statusHistoryRepository,
                          ITemplateRepository templateRepository,
                          ITypeRepository typeRepository)
        {
            _context = context;
            DecreeRepository = decreeRepository;
            StatusRepository = statusRepository;
            StatusHistoryRepository = statusHistoryRepository;
            TemplateRepository = templateRepository;
            TypeRepository = typeRepository;

        }

        public IDecreeRepository DecreeRepository { get; }

        public IStatusRepository StatusRepository { get; }

        public IStatusHistoryRepository StatusHistoryRepository { get; }

        public ITemplateRepository TemplateRepository { get; }

        public ITypeRepository TypeRepository { get; }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
