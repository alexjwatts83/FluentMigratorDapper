using System.Threading.Tasks;
using FluentMigratorDapper.Application.Interfaces;
using FluentMigratorDapper.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentMigratorDapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController<TEntity, TKey> : ControllerBase where TEntity : BaseEntity<TKey>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericCrudRepositoryScripts _scripts;
        public BaseApiController(IUnitOfWork unitOfWork, IGenericCrudRepositoryScripts scripts)
        {
            _unitOfWork = unitOfWork;
            _scripts = scripts;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Get()
        {
            var repo = _unitOfWork.Repository<TEntity, TKey>(_scripts);
            var list = await repo.GetAllAsync();
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(TKey Id)
        {
            var item = await _unitOfWork.Repository<TEntity, TKey>(_scripts).GetByIdAsync(Id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert(TEntity entity)
        {
            var result = await _unitOfWork.Repository<TEntity, TKey>(_scripts).AddAsync(entity);

            if (result.Result == 0)
            {
                return BadRequest($"Failed to insert {typeof(TEntity).Name} id of '{entity.Id}'");
            }
            return await GetById(entity.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(TEntity entity)
        {
            var result = await _unitOfWork.Repository<TEntity, TKey>(_scripts).UpdateAsync(entity);
            if (result == 0)
            {
                return BadRequest($"Failed to update {typeof(TEntity).Name} id of '{entity.Id}'");
            }
            return await GetById(entity.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(TKey id)
        {
            var result = await _unitOfWork.Repository<TEntity, TKey>(_scripts).DeleteAsync(id);

            if (result == 0)
            {
                return BadRequest($"Failed to update {typeof(TEntity).Name} id of '{id}'");
            }
            return Ok($"Deleted {typeof(TEntity).Name} with id of {id}");
        }
    }
}
