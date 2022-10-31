using Ardalis.Specification;

namespace MilitaryManager.Core.Entities.DecreeDataEntity
{
    public class DecreeDatas
    {
        internal class DecreeDataByPlaceholderId : Specification<DecreeData>
        {
            public DecreeDataByPlaceholderId(int placeholderId, int decreeId)
            {
                Query.Where(x => x.TemplatePlaceholderId == placeholderId && x.DecreeId == decreeId);
            }
        }

        internal class DecreeDataUnitCredDivisionNumber : Specification<DecreeData>
        {
            public DecreeDataUnitCredDivisionNumber(int firstNameId, int lastNameId, int secondNameId, int divisionNumberId, int decreeId)
            {
                Query.Where(x => (x.TemplatePlaceholderId == firstNameId ||
                                 x.TemplatePlaceholderId == lastNameId ||
                                 x.TemplatePlaceholderId == secondNameId ||
                                 x.TemplatePlaceholderId == divisionNumberId) && 
                                 x.DecreeId == decreeId);
            }
        }
    }
}
