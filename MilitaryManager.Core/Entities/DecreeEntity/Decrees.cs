using Ardalis.Specification;

namespace MilitaryManager.Core.Entities.DecreeEntity
{
    public class Decrees
    {
        internal class DecreesByName : Specification<Decree>
        {
            public DecreesByName(string name)
            {
                Query.Where(x => x.Name.Contains(name));
            }
        }

        internal class DetailDecreesList : Specification<Decree>
        {
            public DetailDecreesList()
            {
                Query.Include(x => x.Status)
                     .Include(x => x.Template)
                     .Include(x => x.SignedPdf);
            }
        }

        internal class DetailDecreeById : Specification<Decree>
        {
            public DetailDecreeById(int id)
            {
                Query.Where(x => x.Id == id)
                     .Include(x => x.Status)
                     .Include(x => x.Template)
                     .Include(x => x.SignedPdf);
            }
        }
    }
}
