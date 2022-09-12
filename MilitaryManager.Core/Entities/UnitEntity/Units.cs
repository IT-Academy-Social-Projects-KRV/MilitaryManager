using Ardalis.Specification;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    public class Units
    {
        internal class UnitsList : Specification<Unit>
        {
            public UnitsList()
            {
                Query
                .Include(x => x.SubUnits);
            }
        }
    }
}
