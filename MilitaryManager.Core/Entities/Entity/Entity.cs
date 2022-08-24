using MilitaryManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.Entity
{
    public class Entity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NextId { get; set; }
    }
}