using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.SignedPdfEntity;
using MilitaryManager.Core.Entities.StatusEntity;
using MilitaryManager.Core.Entities.StatusHistoryEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Entities.UnitEntity;

namespace MilitaryManager.Infrastructure.Data
{
    public class MilitaryManagerDbContext : DbContext
    {
        public MilitaryManagerDbContext(DbContextOptions<MilitaryManagerDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new DecreeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new StatusHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new TemplateConfiguration());
            modelBuilder.ApplyConfiguration(new SignedPdfConfiguration());
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Decree> Decrees { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusHistory> StatusHistories { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<SignedPdf> SignedPdfs { get; set; }
    }
}
