using MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity;
using MilitaryManager.Core.Entities.AuditEntities.TableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.ColumnEntity
{
    [Table("Column", Schema = "audit")]
    public class Column
    {
        public string Name { get; set; }
        public string TableName { get; set; }

        public Table Table { get; set; }

        public ICollection<ChangeValue> ChangeValues { get; set; }
    }
}
