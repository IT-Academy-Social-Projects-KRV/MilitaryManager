namespace MilitaryManager.Core.Interfaces.Services
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDTO>> GetUnitsTreeAsync(int? id);
        Task<UnitDTO> CreateUnitAsync(UnitDTO query);
        Task<UnitDTO> UpdateUnitAsync(UnitDTO query);
        Task<UnitDTO> DeleteUnitAsync(int id);
    }
}
