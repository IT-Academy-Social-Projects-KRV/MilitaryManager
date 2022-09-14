namespace MilitaryManager.Core.Interfaces
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
