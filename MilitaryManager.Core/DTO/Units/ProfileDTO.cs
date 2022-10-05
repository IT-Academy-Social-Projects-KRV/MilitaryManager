﻿using MilitaryManager.Core.Entities.UnitEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.DTO.Units
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int UnitId { get; set; }
        public string Value { get; set; }

        public AttributeDTO Attribute { get; set; }
        public UnitDTO Unit { get; set; }
    }
}