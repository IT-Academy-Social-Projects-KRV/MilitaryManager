using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.Entity
{
    public class Entities
    {
        internal class EntitiesList : Specification<Entity>
        {
            public EntitiesList(int id)
            {
                Query
                    .Where(x => x.NextId == id || x.Id == id);
            }
        }
    }
}
