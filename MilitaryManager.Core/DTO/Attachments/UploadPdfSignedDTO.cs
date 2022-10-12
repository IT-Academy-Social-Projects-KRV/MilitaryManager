using Microsoft.AspNetCore.Http;

namespace MilitaryManager.Core.DTO.Attachments
{
    public class UploadPdfSignedDTO
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
    }
}
