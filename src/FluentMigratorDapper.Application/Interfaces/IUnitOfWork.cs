namespace FluentMigratorDapper.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ILocationsRepository Locations { get; }
    }
}
