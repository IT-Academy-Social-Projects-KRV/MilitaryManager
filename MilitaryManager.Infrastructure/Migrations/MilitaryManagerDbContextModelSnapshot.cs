﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilitaryManager.Infrastructure.Data;

namespace MilitaryManager.Infrastructure.Migrations
{
    [DbContext(typeof(MilitaryManagerDbContext))]
    partial class MilitaryManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MilitaryManager.Core.Entities.AttributeEntity.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Attributes","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.DivisionEntity.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Divisions","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.EntityEntity.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RegNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entities","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.EntityToAttributeEntity.EntityToAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("EntityId");

                    b.ToTable("EntityToAttributes","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.EquipmentToSoldierEntity.EquipmentToSoldier", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DivisionId")
                        .HasColumnType("int");

                    b.Property<int>("GivenById")
                        .HasColumnType("int");

                    b.Property<DateTime>("GivenDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("GivenById");

                    b.HasIndex("UnitId");

                    b.ToTable("EquipmentToSoldiers","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.PositionEntity.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.ProfileEntity.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Profiles","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.RankEntity.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ranks","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.UnitEntity.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DivisionId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PositionId");

                    b.HasIndex("RankId");

                    b.ToTable("Units","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.DivisionEntity.Division", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.DivisionEntity.Division", "Parent")
                        .WithMany("SubDivision")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.EntityToAttributeEntity.EntityToAttribute", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.AttributeEntity.Attribute", "Attribute")
                        .WithMany("EntityToAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.EntityEntity.Entity", "Entity")
                        .WithMany("EntityToAttributes")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.EquipmentToSoldierEntity.EquipmentToSoldier", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.DivisionEntity.Division", "Division")
                        .WithMany("EquipmentToSoldiers")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.UnitEntity.Unit", "Warehouseman")
                        .WithMany("EquipmentToWarehouseMan")
                        .HasForeignKey("GivenById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.EntityEntity.Entity", "Equipment")
                        .WithOne("EquipmentToSoldiers")
                        .HasForeignKey("MilitaryManager.Core.Entities.EquipmentToSoldierEntity.EquipmentToSoldier", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.UnitEntity.Unit", "Unit")
                        .WithMany("EquipmentToSoldiers")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.ProfileEntity.Profile", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.AttributeEntity.Attribute", "Attribute")
                        .WithMany("Profiles")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.UnitEntity.Unit", "Unit")
                        .WithMany("Profiles")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.UnitEntity.Unit", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.DivisionEntity.Division", "Division")
                        .WithMany("Units")
                        .HasForeignKey("DivisionId");

                    b.HasOne("MilitaryManager.Core.Entities.UnitEntity.Unit", "Parent")
                        .WithMany("SubUnits")
                        .HasForeignKey("ParentId");

                    b.HasOne("MilitaryManager.Core.Entities.PositionEntity.Position", "Position")
                        .WithMany("Units")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.RankEntity.Rank", "Rank")
                        .WithMany("Units")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
