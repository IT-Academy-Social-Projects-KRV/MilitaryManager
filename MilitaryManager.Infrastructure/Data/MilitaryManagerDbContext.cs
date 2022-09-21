using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity;
using MilitaryManager.Core.Entities.AuditEntities.ColumnEntity;
using MilitaryManager.Core.Entities.AuditEntities.TableEntity;
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
            modelBuilder.ApplyConfiguration(new ChangeConfiguration());
            modelBuilder.ApplyConfiguration(new ChangeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChangeValueConfiguration());
            modelBuilder.ApplyConfiguration(new ColumnConfiguration());
            modelBuilder.ApplyConfiguration(new TableConfiguration());

            modelBuilder.Entity<ChangeValue>(entity =>
            {
                entity.Property(x => x.NewValue).HasColumnType("sql_variant");

                entity.Property(x => x.OldValue).HasColumnType("sql_variant");
            });
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<ChangeType> ChangeType { get; set; }
        public DbSet<ChangeValue> ChangeValue { get; set; }
        public DbSet<Column> Column { get; set; }
        public DbSet<Table> Table { get; set; }
    }
}
