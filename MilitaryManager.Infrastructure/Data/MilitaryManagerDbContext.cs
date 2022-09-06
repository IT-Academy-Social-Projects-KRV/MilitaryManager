﻿using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.AttributeEntity;
using MilitaryManager.Core.Entities.EntityEntity;
using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.EquipmentToSoldierEntity;
using MilitaryManager.Core.Entities.PositionEntity;
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Entities.SoldierEntity;
using MilitaryManager.Core.Entities.UnitEntity;

namespace MilitaryManager.Infrastructure.Data
{
    internal class MilitaryManagerDbContext : DbContext
    {
        public MilitaryManagerDbContext(DbContextOptions<MilitaryManagerDbContext> options) : base(options)
        {
        }

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
