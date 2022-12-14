using Ardalis.Specification;

namespace MilitaryManager.Core.Entities.DivisionEntity
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

        internal class DivisionByNumber : Specification<Division>
        {
            public DivisionByNumber(string divisionNumber)
            {
                Query.Where(x => x.DivisionNumber == divisionNumber);
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
