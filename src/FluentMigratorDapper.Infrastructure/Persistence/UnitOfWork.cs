using FluentMigratorDapper.Application.Interfaces;

namespace FluentMigratorDapper.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ILocationsRepository locationsRepository)
        {
            Locations = locationsRepository;
        }
        public ILocationsRepository Locations { get; }
    }
}
