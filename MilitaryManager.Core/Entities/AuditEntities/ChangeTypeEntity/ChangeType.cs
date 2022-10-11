using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity
{
    [Table("ChangeType", Schema = "audit")]
    public class ChangeType
    {
        public char Code { get; set; }
        public string Name { get; set; }

        public ICollection<Change> Changes { get; set; }
    }
}
