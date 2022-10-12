using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MilitaryManager.Core.Entities.UnitEntity
{
    public class Units
    {
        internal class RootUnitsList : Specification<Unit>
        {
            public RootUnitsList()
            {
                Query
                .Where(x => x.ParentId == null);
            }
        }

        internal class UnitsListByParentId : Specification<Unit>
        {
            public UnitsListByParentId(int id)
            {
                Query
                .Where(x => x.ParentId == id);
            }
        }
        internal class UnitsList : Specification<Unit>
        {
            public UnitsList()
            {
                Query
                    .Include(x => x.SubUnits)
                    .Include(x => x.Rank)
                    .Include(x => x.Position)
                    .Include(x => x.Parent)
                    .Include(x => x.Profiles)
                    .Include(x => x.UnitToEquipments)
                    .Include(x => x.EquipmentToWarehouseMan);
            }
        }
        internal class UnitById : Specification<Unit>
        {
            public UnitById(int id)
            {
                Query
                    .Include(x => x.SubUnits)
                    .Include(x=> x.Rank)
                    .Include(x => x.Position)
                    .Include(x => x.Parent)
                    .Include(x => x.Profiles)
                    .Include(x => x.UnitToEquipments)
                    .Include(x => x.EquipmentToWarehouseMan)
                    .Include(x => x.Division)
                .Where(x => x.Id == id);
            }
        }
    }
}
