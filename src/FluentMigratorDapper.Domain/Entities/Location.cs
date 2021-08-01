namespace FluentMigratorDapper.Domain.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey  Id{ get; set; }
    }
    public class Location : BaseEntity<string>
    {
        public Location()
        {

        }
        
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
