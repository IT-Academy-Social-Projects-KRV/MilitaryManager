using MilitaryManager.Core.Entities.DecreeDataEntity;
using MilitaryManager.Core.Entities.DivisionEntity;
using MilitaryManager.Core.Entities.TemplatePlaceholderEntity;
using MilitaryManager.Core.Entities.UnitEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services.ExecuteDecreeService
{
    public class TransferDecreeExecutor : IDecreeExecutor
    {
        private readonly IRepository<DecreeData, int> _decreeDataRepository;
        private readonly IRepository<Division, int> _divisionRepository;
        private readonly IRepository<Unit, int> _unitRepository;
        private readonly IRepository<TemplatePlaceholder, int> _templatePlaceholderRepository;

        public int TemplateId => 3;

        public TransferDecreeExecutor(IRepository<DecreeData, int> decreeDataRepository,
                                      IRepository<Division, int> divisionRepository,
                                      IRepository<Unit, int> unitRepository,
                                      IRepository<TemplatePlaceholder, int> templatePlaceholderRepository)
        {
            _decreeDataRepository = decreeDataRepository;
            _divisionRepository = divisionRepository;
            _unitRepository = unitRepository;
            _templatePlaceholderRepository = templatePlaceholderRepository;
        }

        public async Task ExecuteOperation(int decreeId)
        {
            var templatePlaceholderSpecification = new TemplatePlaceholders.TemplatePlaceholdersByTemplateId(TemplateId);
            var placeholderList = await _templatePlaceholderRepository.GetListBySpecAsync(templatePlaceholderSpecification);

            var firstNameId = placeholderList.FirstOrDefault(x => x.Name == "firstName").Id;
            var lastNameId = placeholderList.FirstOrDefault(x => x.Name == "lastName").Id;
            var secondNameId = placeholderList.FirstOrDefault(x => x.Name == "secondName").Id;
            var newDivisionNumberId = placeholderList.FirstOrDefault(x => x.Name == "newDivisionNumber").Id;

            var decreeDataSpecification = new DecreeDatas.DecreeDataUnitCredDivisionNumber(firstNameId, lastNameId, secondNameId, newDivisionNumberId, decreeId);
            var divisionNumber = await _decreeDataRepository.GetListBySpecAsync(decreeDataSpecification);

            var firstNameValue = (string)divisionNumber.FirstOrDefault(x => x.TemplatePlaceholderId == firstNameId).Value;
            var lastNameValue = (string)divisionNumber.FirstOrDefault(x => x.TemplatePlaceholderId == lastNameId).Value;
            var secondNameValue = (string)divisionNumber.FirstOrDefault(x => x.TemplatePlaceholderId == secondNameId).Value;
            var newDivisionNumberValue = (string)divisionNumber.FirstOrDefault(x => x.TemplatePlaceholderId == newDivisionNumberId).Value;

            var divisionSpecification = new Divisions.DivisionByNumber(newDivisionNumberValue);
            var division = await _divisionRepository.GetFirstBySpecAsync(divisionSpecification);

            var unitSpecification = new Units.UnitByFirstLastSecondNames(firstNameValue, lastNameValue, secondNameValue);
            var unit = await _unitRepository.GetFirstBySpecAsync(unitSpecification);

            unit.DivisionId = division.Id;
            await _unitRepository.SaveChangesAcync();
        }
    }
}
