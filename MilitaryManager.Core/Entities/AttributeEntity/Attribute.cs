﻿using MilitaryManager.Core.Entities.EntityToAttributeEntity;
using MilitaryManager.Core.Entities.ProfileEntity;
using MilitaryManager.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryManager.Core.Entities.AttributeEntity
{
    [Table("Attribute", Schema = "Unit")]
    public class Attribute : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
        public ICollection<EntityToAttribute> EntityToAttributes { get; set; } = new HashSet<EntityToAttribute>();
    }
}
