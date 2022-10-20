using Ardalis.Specification;
using MilitaryManager.Core.Entities.UnitEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryManager.Core.Entities.UnitUserEntity
{
    public class UnitUsers
    {
        internal class UnitUserByUserId : Specification<UnitUser>
        {
            public UnitUserByUserId(string id)
            {
                Query
                    .Where(x => x.UserId == id);
            }
        }
    }
}
