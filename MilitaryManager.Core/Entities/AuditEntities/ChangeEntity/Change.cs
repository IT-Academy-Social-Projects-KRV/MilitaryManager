using MilitaryManager.Core.Entities.AuditEntities.ChangeTypeEntity;
using MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity;
using MilitaryManager.Core.Entities.AuditEntities.TableEntity;
using MilitaryManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilitaryManager.Core.Entities.AuditEntities.ChangeEntity
{
    [Table("Change", Schema = "audit")]
    public class Change : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string TableName { get; set; }
        public int RowId { get; set; }
        public DateTime Date { get; set; }
        public char ChangeTypeCode { get; set; }

        public ChangeValue ChangeValue { get; set; }
        public Table Table { get; set; }
        public ChangeType ChangeType { get; set; }
    }
}
