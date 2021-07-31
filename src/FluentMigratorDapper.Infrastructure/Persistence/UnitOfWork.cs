using FluentMigratorDapper.Application.Interfaces;

namespace FluentMigratorDapper.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ILocationsRepository locationsRepository, IMoviesRepository movies, ITagsRepository tags)
        {
            Locations = locationsRepository;
            Movies = movies;
            Tags = tags;
        }
        public ILocationsRepository Locations { get; }
        public IMoviesRepository Movies { get; }
        public ITagsRepository Tags { get; }
    }
}
