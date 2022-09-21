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
                .Include(x => x.SubUnits)
                .Where(x => x.ParentId == null);
            }
        }
        
        internal class UnitsListById : Specification<Unit>
        {
            public UnitsListById(int id)
            {
                Query
                .Include(x => x.SubUnits)
                .Where(x => x.Id == id);
            }
        }
    }
}
