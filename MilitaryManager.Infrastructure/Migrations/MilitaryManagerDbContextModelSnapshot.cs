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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Attributes","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.AuditEntities.ChangeEntity.Change", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChangeTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RowId")
                        .HasColumnType("int");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChangeTypeCode");

                    b.HasIndex("TableName");

                    b.ToTable("Change","audit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity.ChangeType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("ChangeType","audit");

                    b.HasData(
                        new
                        {
                            Code = "I",
                            Name = "Insert"
                        },
                        new
                        {
                            Code = "U",
                            Name = "Update"
                        },
                        new
                        {
                            Code = "D",
                            Name = "Delete"
                        });
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity.ChangeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChangeId")
                        .HasColumnType("int");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<object>("NewValue")
                        .HasColumnType("sql_variant");

                    b.Property<object>("OldValue")
                        .HasColumnType("sql_variant");

                    b.HasKey("Id");

                    b.HasIndex("ChangeId");

                    b.HasIndex("ColumnName");

                    b.ToTable("ChangeValue","audit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.AuditEntities.ColumnEntity.Column", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasAlternateKey("Name", "TableName");

                    b.HasIndex("TableName");

                    b.ToTable("Column","audit");

                    b.HasData(
                        new
                        {
                            Name = "UnitParentId",
                            TableName = "Units"
                        },
                        new
                        {
                            Name = "DivisionId",
                            TableName = "Units"
                        },
                        new
                        {
                            Name = "FirstName",
                            TableName = "Units"
                        },
                        new
                        {
                            Name = "LastName",
                            TableName = "Units"
                        },
                        new
                        {
                            Name = "PositionId",
                            TableName = "Units"
                        },
                        new
                        {
                            Name = "RankId",
                            TableName = "Units"
                        },
                        new
                        {
                            Name = "Name",
                            TableName = "Divisions"
                        },
                        new
                        {
                            Name = "Address",
                            TableName = "Divisions"
                        },
                        new
                        {
                            Name = "DivisionParentId",
                            TableName = "Divisions"
                        });
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.AuditEntities.TableEntity.Table", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Table","audit");

                    b.HasData(
                        new
                        {
                            Name = "Attributes",
                            Description = "Attributes for units and divisions"
                        },
                        new
                        {
                            Name = "Divisions",
                            Description = "Information about divisions"
                        },
                        new
                        {
                            Name = "Entities",
                            Description = "List of equipments"
                        },
                        new
                        {
                            Name = "EntityToAttributes",
                            Description = "Decoupling table for the connection between equipment and its attributes"
                        },
                        new
                        {
                            Name = "Positions",
                            Description = "List of unit positions"
                        },
                        new
                        {
                            Name = "Profiles",
                            Description = "Decoupling table for the connection between unit and its attributes"
                        },
                        new
                        {
                            Name = "Ranks",
                            Description = "List of unit ranks"
                        },
                        new
                        {
                            Name = "Units",
                            Description = "Information about unit"
                        },
                        new
                        {
                            Name = "UnitToEquipments",
                            Description = "Decoupling table for the connection between unit and its equipment"
                        });
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.DecreeEntity.Decree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<string>("DecreeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("TemplateId");

                    b.ToTable("Decrees");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.DivisionEntity.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DivisionNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("EntityId");

                    b.ToTable("EntityToAttributes","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.EquipmentToUnitEntity.UnitToEquipment", b =>
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

                    b.ToTable("UnitToEquipments","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.PositionEntity.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Ranks","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.SignedPdfEntity.SignedPdf", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SignedPdfs");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.StatusEntity.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Created"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Downloaded"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Signed"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.StatusHistoryEntity.StatusHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DecreeId")
                        .HasColumnType("int");

                    b.Property<int>("NewStatusId")
                        .HasColumnType("int");

                    b.Property<int>("OldStatusId")
                        .HasColumnType("int");

                    b.Property<string>("PerformedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DecreeId");

                    b.HasIndex("NewStatusId");

                    b.HasIndex("OldStatusId");

                    b.ToTable("StatusHistories");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.TemplateEntity.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Templates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Path = "data/document_templates/template_01.xml",
                            Type = "Протокол"
                        });
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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PositionId");

                    b.HasIndex("RankId");

                    b.ToTable("Units","Unit");
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.AuditEntities.ChangeEntity.Change", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity.ChangeType", "ChangeType")
                        .WithMany("Changes")
                        .HasForeignKey("ChangeTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.AuditEntities.TableEntity.Table", "Table")
                        .WithMany("Changes")
                        .HasForeignKey("TableName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity.ChangeValue", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.AuditEntities.ChangeEntity.Change", "Change")
                        .WithMany("ChangeValues")
                        .HasForeignKey("ChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.AuditEntities.ColumnEntity.Column", "Column")
                        .WithMany("ChangeValues")
                        .HasForeignKey("ColumnName")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.AuditEntities.ColumnEntity.Column", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.AuditEntities.TableEntity.Table", "Table")
                        .WithMany("Columns")
                        .HasForeignKey("TableName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.DecreeEntity.Decree", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.StatusEntity.Status", "Status")
                        .WithMany("Decrees")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.TemplateEntity.Template", "Template")
                        .WithMany("Decrees")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.DivisionEntity.Division", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.DivisionEntity.Division", "Parent")
                        .WithMany("SubDivisions")
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

            modelBuilder.Entity("MilitaryManager.Core.Entities.EquipmentToUnitEntity.UnitToEquipment", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.DivisionEntity.Division", "Division")
                        .WithMany("UnitToEquipments")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.UnitEntity.Unit", "Warehouseman")
                        .WithMany("EquipmentToWarehouseMan")
                        .HasForeignKey("GivenById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.EntityEntity.Entity", "Equipment")
                        .WithOne("UnitToEquipment")
                        .HasForeignKey("MilitaryManager.Core.Entities.EquipmentToUnitEntity.UnitToEquipment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.UnitEntity.Unit", "Unit")
                        .WithMany("UnitToEquipments")
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

            modelBuilder.Entity("MilitaryManager.Core.Entities.SignedPdfEntity.SignedPdf", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.DecreeEntity.Decree", "Decree")
                        .WithOne("SignedPdf")
                        .HasForeignKey("MilitaryManager.Core.Entities.SignedPdfEntity.SignedPdf", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MilitaryManager.Core.Entities.StatusHistoryEntity.StatusHistory", b =>
                {
                    b.HasOne("MilitaryManager.Core.Entities.DecreeEntity.Decree", "Decree")
                        .WithMany("StatusHistories")
                        .HasForeignKey("DecreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.StatusEntity.Status", "NewStatus")
                        .WithMany("NewStatuses")
                        .HasForeignKey("NewStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MilitaryManager.Core.Entities.StatusEntity.Status", "OldStatus")
                        .WithMany("OldStatuses")
                        .HasForeignKey("OldStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
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
