using Microsoft.EntityFrameworkCore;
using MilitaryManager.Core.Entities.StatusEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Infrastructure.Data.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedDecreeStatuses(builder);
            SeedTemplates(builder);
        }

        public static void SeedDecreeStatuses(ModelBuilder builder)
        {
            builder.Entity<Status>().HasData(
                new Status()
                {
                    Id = (int)DecreeStatus.CREATED,
                    Name = "Created"
                },
                new Status()
                {
                    Id = (int)DecreeStatus.DOWNLOADED,
                    Name = "Downloaded"
                },
                new Status()
                {
                    Id = (int)DecreeStatus.SIGNED,
                    Name = "Signed"
                },
                new Status()
                {
                    Id = (int)DecreeStatus.COMPLETED,
                    Name = "Completed"
                });
        }

        public static void SeedTemplates(ModelBuilder builder)
        {
            builder.Entity<Template>().HasData(
                new Template()
                {
                    Id = 1,
                    Type = "Протокол",
                    Path = "data/document_templates/template_01.xml"
                }
                );
        }
    }
}
