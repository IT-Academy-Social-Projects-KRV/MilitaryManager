using Ardalis.Specification;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    public class Units
    {
        internal class RootUnitsList : Specification<Unit>
        {
            public RootUnitsList()
            {
                Query
                .Where(x => x.ParentId == null);
            }
        }

        internal class UnitsListByParentId : Specification<Unit>
        {
            public UnitsListByParentId(int id)
            {
                Query
                .Where(x => x.ParentId == id);
            }
        }
    }
}
