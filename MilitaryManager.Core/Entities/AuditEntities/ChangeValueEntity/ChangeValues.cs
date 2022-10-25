using Ardalis.Specification;

namespace MilitaryManager.Core.Entities.AuditEntities.ChangeValueEntity
{
    public class ChangeValues
    {
        internal class ChangeFullInfoById : Specification<ChangeValue>
        {
            public ChangeFullInfoById(int id)
            {
                Query
                    .Where(x => x.ChangeId == id);
            }
        }
    }
}
