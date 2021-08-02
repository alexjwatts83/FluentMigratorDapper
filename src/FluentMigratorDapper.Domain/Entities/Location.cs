namespace FluentMigratorDapper.Domain.Entities
{
    public class Location : BaseEntity<string>
    {       
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
