using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using FluentMigratorDapper.Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluentMigratorDapper.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : BaseApiController<Tags, string>
    {
        public TagsController(IUnitOfWork unitOfWork, IMoviesGenericCrudRepositoryScripts locationScripts)
            : base(unitOfWork, locationScripts)
        {
        }
    }
}
