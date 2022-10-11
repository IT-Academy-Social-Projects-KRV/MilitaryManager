using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Audit
{
    public class ChangeValuesDTO
    {
        public int Id { get; set; }
        public int ChangeId { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public string ColumnName { get; set; }
    }
}
