using Microsoft.EntityFrameworkCore;
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
        }

        public DbSet<Unit> Units { get; set; }
    }
}
