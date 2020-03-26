using Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Entities.DataTransferObjects;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RestApi.ModelBinders;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;

namespace RestApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UsersController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repository.User.GetAllUsersAsync(trackChanges: false);
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _repository.User.GetUserAsync(id, trackChanges: false);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
        }

        [HttpGet("collection/({ids})")]
        public async Task<IActionResult> GetRecipeCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<string> ids)
        {
            if(ids == null)
            {
                return BadRequest("Parameter ids is null");
            }

            var userEntities = await _repository.User.GetUsersByIdsAsync(ids, trackChanges: false);

            if(ids.Count() != userEntities.Count())
            {
                return NotFound();
            }

            var usersToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);
            return Ok(usersToReturn);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateUser(string id, [FromBody] JsonPatchDocument<UserForUpdateDto> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest("patchDoc object is null");
            }

            var userEntity = await _repository.User.GetUserAsync(id, trackChanges: true);
            if(userEntity == null)
            {
                NotFound();
            }

            var userToPatch = _mapper.Map<UserForUpdateDto>(userEntity);

            patchDoc.ApplyTo(userToPatch);
            _mapper.Map(userToPatch, userEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _repository.User.GetUserAsync(id, trackChanges: false);
            if(user == null)
            {
                return NotFound();
            }

            _repository.User.DeleteUser(user);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
