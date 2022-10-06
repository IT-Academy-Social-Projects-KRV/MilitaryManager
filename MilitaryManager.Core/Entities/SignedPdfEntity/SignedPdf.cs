using MilitaryManager.Core.Entities.DecreeEntity;
using MilitaryManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.SignedPdfEntity
{
    public class SignedPdf : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public Decree Decree { get; set; }
    }
}
