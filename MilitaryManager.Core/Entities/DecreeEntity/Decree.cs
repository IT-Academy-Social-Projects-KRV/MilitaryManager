using MilitaryManager.Core.Entities.SignedPdfEntity;
using MilitaryManager.Core.Entities.StatusEntity;
using MilitaryManager.Core.Entities.StatusHistoryEntity;
using MilitaryManager.Core.Entities.TemplateEntity;
using MilitaryManager.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace MilitaryManager.Core.Entities.DecreeEntity
{
    public class Decree : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string CreatedBy { get; set; }
        public DateTime TimeStamp { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public SignedPdf SignedPdf { get; set; }
        public ICollection<StatusHistory> StatusHistories { get; set; }
    }
}
