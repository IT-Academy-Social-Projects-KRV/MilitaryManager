using MilitaryManager.Core.Entities.AuditEntities.ChangeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ColumnEntity;
using MilitaryManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.TableEntity
{
    [Table("Table", Schema = "audit")]
    public class Table
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Column> Columns { get; set; }
        public ICollection<Change> Changes { get; set; }
    }
}
