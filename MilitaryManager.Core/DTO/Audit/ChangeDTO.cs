using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Audit
{
    public class ChangeDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string TableName { get; set; }
        public int RowId { get; set; }
        public DateTime Date { get; set; }
        public char ChangeTypeCode { get; set; }

        public List<ChangeValuesDTO> ChangeValues { get; set; }
    }
}
