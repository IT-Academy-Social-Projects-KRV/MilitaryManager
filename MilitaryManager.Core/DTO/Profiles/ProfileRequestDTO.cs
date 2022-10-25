namespace MilitaryManager.Core.DTO.Profiles
{
    public class ProfileRequestDTO
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int UnitId { get; set; }
        public string Value { get; set; }
    }
}
