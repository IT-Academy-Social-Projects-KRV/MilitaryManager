using Ardalis.Specification;
using MilitaryManager.Core.Entities.UnitEntity;

namespace MilitaryManager.Core.Entities.UnitUserEntity
{
    public class UnitUsers
    {
        internal class UnitUserByUserId : Specification<UnitUser>
        {
            public UnitUserByUserId(string id)
            {
                Query
                    .Include(x => x.Unit)
                    .Where(x => x.UserId == id);
            }
        }
    }
}
