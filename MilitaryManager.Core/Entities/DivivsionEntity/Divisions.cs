using Ardalis.Specification;
using MilitaryManager.Core.Entities.DivisionEntity;

namespace MilitaryManager.Core.Entities.DivivsionEntity
{
    public class Divisions
    {
        internal class DivisionsListById : Specification<Division>
        {
            public DivisionsListById(int id)
            {
                Query
                .Include(x => x.SubDivisions)
                .Where(x => x.Id == id);
            }
        }

        internal class RootDivisionList : Specification<Division>
        {
            public RootDivisionList()
            {
                Query
                .Include(x => x.SubDivisions)
                .Where(x => x.ParentId == null);
            }
        }
    }
}
