namespace FluentMigratorDapper.Domain.Entities
{
    public class Movies : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
