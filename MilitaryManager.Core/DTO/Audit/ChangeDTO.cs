using System.Collections.Generic;

namespace MilitaryManager.Core.DTO.Audit
{
    public class ChangeDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string TableName { get; set; }
        public int RowId { get; set; }
        public string Date { get; set; }
        public char ChangeTypeCode { get; set; }

        public List<ChangeValuesDTO> ChangeValues { get; set; }
    }
}
