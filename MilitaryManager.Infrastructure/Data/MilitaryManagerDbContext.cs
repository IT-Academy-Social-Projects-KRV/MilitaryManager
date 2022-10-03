using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Entities.RankEntity;
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
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());
            modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration());
            modelBuilder.ApplyConfiguration(new EntityToAttributeConfiguration());
            modelBuilder.ApplyConfiguration(new UnitToEquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new RankConfiguration());
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

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityToAttribute> EntityToAttributes { get; set; }
        public DbSet<UnitToEquipment> UnitToEquipments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<ChangeType> ChangeType { get; set; }
        public DbSet<ChangeValue> ChangeValue { get; set; }
        public DbSet<Column> Column { get; set; }
        public DbSet<Table> Table { get; set; }
    }
}
