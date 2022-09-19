using Ardalis.Specification;
using MilitaryManager.Core.Entities.UnitEntity;

namespace MilitaryManager.Core.Helpers
{
    internal static class GetUnitSpecification
    {
        public static Specification<Unit> GetSpecification(int? id)
        {
            if (id.HasValue)
            {
                return new Units.UnitsListById(id.Value);
            }
            else
            {
                return new Units.RootUnitsList();
            }
        }
    }
}
