namespace MilitaryManager.Core.DTO.Divisions
{
    public class DivisionRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DivisionNumber { get; set; }
        public string Address { get; set; }
        public int? ParentId { get; set; }
    }
}
