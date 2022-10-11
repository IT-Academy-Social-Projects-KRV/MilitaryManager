using System;

namespace MilitaryManager.Core.DTO.Attachments
{
    public class DecreeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string PathSigned { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public int TemplateId { get; set; }
        public string Template { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
    }
}
