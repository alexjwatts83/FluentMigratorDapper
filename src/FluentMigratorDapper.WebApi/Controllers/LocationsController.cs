using System.Threading.Tasks;
using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using FluentMigratorDapper.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentMigratorDapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : BaseApiController
    {
        private readonly ILocationGenericCrudRepositoryScripts _locationScripts;

        public LocationsController(IUnitOfWork unitOfWork, ILocationGenericCrudRepositoryScripts locationScripts) : base(unitOfWork)
        {
            _locationScripts = locationScripts;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var repo = _unitOfWork.Repository<Location>(_locationScripts);
            var list = await repo.GetAllAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string Id)
        {
            var item = await _unitOfWork.Repository<Location>(_locationScripts).GetByIdAsync(Id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> Insert(Location location)
        //{
        //    var result = await _unitOfWork.Locations.AddAsync(location);
        //    if (result == 0)
        //    {
        //        return BadRequest($"Failed to insert location id of '{location.Id}' with name of {location.Name}");
        //    }
        //    return await GetById(location.Id);
        //}

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> Update(Location location)
        //{
        //    var result = await _unitOfWork.Locations.UpdateAsync(location);
        //    if (result == 0)
        //    {
        //        return BadRequest($"Failed to update location id of '{location.Id}'");
        //    }
        //    return await GetById(location.Id);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var result = await _unitOfWork.Locations.DeleteAsync(id);

        //    if (result == 0)
        //    {
        //        return BadRequest($"Failed to update location id of '{id}'");
        //    }
        //    return Ok($"Deleted location with id of {id}");
        //}
    }
}
