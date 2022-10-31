using Ardalis.Specification;
using MilitaryManager.Core.Entities.DivisionEntity;

namespace MilitaryManager.Core.Entities.DivivsionEntity
{
    public class Divisions
    {
        internal class DivisionsList : Specification<Division>
        {
            public DivisionsList()
            {
                Query.Include(x => x.SubDivisions);
            }
        }
        internal class DivisionById : Specification<Division>
        {
            public DivisionById(int id)
            {
                Query.Include(x => x.Id == id);
            }
        }
    }
}
