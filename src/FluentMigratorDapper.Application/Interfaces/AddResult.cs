namespace FluentMigratorDapper.Application.Interfaces
{
    public class AddResult<TKey, TEntity>
    {
        public TKey Id { get; set; }
        public TEntity Entity { get; set; }
        public int Result { get; set; }
    }
}