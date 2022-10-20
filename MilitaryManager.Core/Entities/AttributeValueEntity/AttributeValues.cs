using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.AttributeValueEntity
{
    public class AttributeValues 
    {
        internal class ValuesById : Specification<AttributeValue>
        {
            public ValuesById(int id)
            {
                Query
                    .Where(x => x.AttributeId == id);
            }
        }

    }
}
