using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ColumnEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity
{
    [Table("ChangeValue", Schema = "audit")]
    public class ChangeValue
    {
        public int ChangeId { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public string ColumnName { get; set; }

        public Change Change { get; set; }
        public Column Column { get; set; }
    }
}
