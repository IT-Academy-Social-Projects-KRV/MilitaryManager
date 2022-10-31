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
                     .Include(x => x.UnitToEquipment)
                     .ThenInclude(x => x.Warehouseman)
                     .Include(x => x.EntityToAttributes)
                     .ThenInclude(x => x.Attribute)
                     .Where(x => x.Id == id);
            }
        }
        internal class GetEntities : Specification<Entity>
        {
            public GetEntities()
            {
                Query
                    .Include(x => x.UnitToEquipment)
                    .ThenInclude(x => x.Division)
                    .Include(x => x.UnitToEquipment)
                    .ThenInclude(x => x.Unit)
                    .Include(x => x.UnitToEquipment)
                    .ThenInclude(x => x.Warehouseman);
            }
        }
    }
}
