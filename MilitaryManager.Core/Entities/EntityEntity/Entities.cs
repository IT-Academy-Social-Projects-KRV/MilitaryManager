using Ardalis.Specification;

namespace MilitaryManager.Core.Entities.EntityEntity
{
    internal class EntitiesSpec
    {
        internal class EntityById : Specification<Entity>
        {
            public EntityById(int id)
            {
                Query
                    .Include(x => x.EntityToAttributes)
                    .Where(x => x.Id == id);
            }
        }
        internal class GetEntities : Specification<Entity>
        {
            public GetEntities()
            {
                Query
                    .Include(x => x.EntityToAttributes);
            }
        }
    }
}
