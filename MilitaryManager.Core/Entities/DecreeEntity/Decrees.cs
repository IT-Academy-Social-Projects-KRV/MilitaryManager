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
    }
}
