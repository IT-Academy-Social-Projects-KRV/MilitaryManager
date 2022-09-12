namespace MilitaryManager.Core.Interfaces
{
    public interface IBaseEntity<TType>
    {
        public TType Id { get; set; }
    }
}
