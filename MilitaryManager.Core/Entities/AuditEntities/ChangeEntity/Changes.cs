using Ardalis.Specification;

namespace MilitaryManager.Core.Entities.AuditEntities.ChangeEntity
{
    public class Changes
    {
        internal class ChangeFullInfoById : Specification<Change>
        {
            public ChangeFullInfoById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.ChangeValues);
            }
        }
    }
}
