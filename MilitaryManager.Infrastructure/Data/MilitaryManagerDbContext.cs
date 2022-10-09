using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Entities.SignedPdfEntity;
using MilitaryManager.Core.Entities.StatusEntity;
using MilitaryManager.Core.Entities.StatusHistoryEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity;
using MilitaryManager.Core.Entities.AuditEntities.ColumnEntity;
using MilitaryManager.Core.Entities.AuditEntities.TableEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToUnitEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Infrastructure.Data.SeedData;

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
            modelBuilder.ApplyConfiguration(new DecreeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new StatusHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new TemplateConfiguration());
            modelBuilder.ApplyConfiguration(new SignedPdfConfiguration());
            modelBuilder.Seed();
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
            
            modelBuilder.Entity<ChangeType>().HasData(
                new ChangeType[]
                {
                    new ChangeType { Code = 'I', Name = "Insert"},
                    new ChangeType { Code = 'U', Name = "Update"},
                    new ChangeType { Code = 'D', Name = "Delete"}
                });

            modelBuilder.Entity<Table>().HasData(
                new Table[]
                {
                    new Table { Name = "Attributes", Description = "Attributes for units and divisions"},
                    new Table { Name = "Divisions", Description = "Information about divisions"},
                    new Table { Name = "Entities", Description = "List of equipments"},
                    new Table { Name = "EntityToAttributes", Description = "Decoupling table for the connection between equipment and its attributes"},
                    new Table { Name = "Positions", Description = "List of unit positions"},
                    new Table { Name = "Profiles", Description = "Decoupling table for the connection between unit and its attributes"},
                    new Table { Name = "Ranks", Description = "List of unit ranks"},
                    new Table { Name = "Units", Description = "Information about unit"},
                    new Table { Name = "UnitToEquipments", Description = "Decoupling table for the connection between unit and its equipment"}
                });
            modelBuilder.Entity<Column>().HasData(
                new Column[]
                {
                    new Column { Name = "UnitParentId", TableName = "Units"},
                    new Column { Name = "DivisionsId", TableName = "Units"},
                    new Column { Name = "FirstName", TableName = "Units"},
                    new Column { Name = "LastName", TableName = "Units"},
                    new Column { Name = "PositionsId", TableName = "Units"},
                    new Column { Name = "RankId", TableName = "Units"},
                    new Column { Name = "Name", TableName = "Divisions"},
                    new Column { Name = "Address", TableName = "Divisions"},
                    new Column { Name = "DivisionParentId", TableName = "Divisions"}
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
        public DbSet<Decree> Decrees { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusHistory> StatusHistories { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<SignedPdf> SignedPdfs { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<ChangeType> ChangeType { get; set; }
        public DbSet<ChangeValue> ChangeValue { get; set; }
        public DbSet<Column> Column { get; set; }
        public DbSet<Table> Table { get; set; }
    }
}
