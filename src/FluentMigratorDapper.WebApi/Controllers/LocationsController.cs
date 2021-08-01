using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using FluentMigratorDapper.Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluentMigratorDapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : BaseApiController<Location, string>
    {
        public LocationsController(IUnitOfWork unitOfWork, ILocationGenericCrudRepositoryScripts locationScripts)
            : base(unitOfWork, locationScripts)
        {
        }
    }
}
