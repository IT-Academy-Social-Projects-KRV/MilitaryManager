using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToSoldierEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Entities.SoldierEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using System.Collections.Generic;

namespace MilitaryManager.Infrastructure.Data
{
    internal class MilitaryManagerDbContext : DbContext
    {
        public MilitaryManagerDbContext(DbContextOptions<MilitaryManagerDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttributeConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration());
            modelBuilder.ApplyConfiguration(new EntityToAttributeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentToSoldierConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new RankConfiguration());
            modelBuilder.ApplyConfiguration(new SoldierConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());

            modelBuilder.Entity<Unit>()
                .HasData(new List<Unit>()
                {
                    new Unit() {Id = 1, Name = "Charles Montgomery Burns", Address = "Address1"},
                    new Unit() {Id = 2, Name = "Waylon Smithers, Jr.", Address = "Address1", ParentId = 1},
                    new Unit() {Id = 3, Name = "Lenny Leonard", Address = "Address1", ParentId = 2},
                    new Unit() {Id = 4, Name = "Carl Carlson", Address = "Address1", ParentId = 2},
                    new Unit() {Id = 5, Name = "Inanimate Carbon Rod", Address = "Address1", ParentId = 4},
                    new Unit() {Id = 6, Name = "Homer Simpson", Address = "Address1", ParentId = 5}
                });
        }

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<EntityToAttribute> EntityToAttributes { get; set; }
        public DbSet<EquipmentToSoldier> EquipmentToSoldiers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
