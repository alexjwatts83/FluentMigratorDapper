namespace FluentMigratorDapper.Domain.Entities
{
    public class BaseEntity
    {

    }
    public class Location : BaseEntity
    {
        public Location()
        {

        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
