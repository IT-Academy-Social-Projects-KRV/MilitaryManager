using Microsoft.AspNetCore.Http;
using MilitaryManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Infrastructure
{
    // Test class
    public class TestStore : IStoreService
    {
        public async Task<string> StoreDataAsync(IFormFile uploadedFile)
        {
            var docName = $"{DateTime.Now.Ticks}.pdf";
            var exportPath = Path.Combine("documents", docName).Replace("\\", "/");
            using (var stream = new FileStream(Path.Combine("wwwroot", exportPath), FileMode.Create))
            {
                await uploadedFile.CopyToAsync(stream);
            }
            return exportPath;
        }

        public async Task<FileStream> RetrieveDataAsync(string path)
        {
            return new FileStream($"wwwroot/{path}", FileMode.Open);
        }
    }
}
