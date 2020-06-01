using System;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/liked-recipes")]
    [ApiController]
    [Authorize]
    public class LikedRecipesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public LikedRecipesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLikedRecipe([FromBody]LikedRecipeForCreationDto likedRecipe)
        {
            if (likedRecipe == null)
            {
                return BadRequest("LikedRecipeForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var likedRecipeEntity = _mapper.Map<LikedRecipe>(likedRecipe);

            _repository.LikedRecipe.CreateLikedRecipe(likedRecipeEntity);
            await _repository.SaveAsync();

            var likedRecipeToReturn = _mapper.Map<LikedRecipeDto>(likedRecipeEntity);

            return Created("", likedRecipeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLikedRecipe(Guid id)
        {
            var likedRecipe = await _repository.LikedRecipe.GetLikedRecipeAsync(id, trackChanges: false);
            if (likedRecipe == null)
            {
                return NotFound();
            }

            _repository.LikedRecipe.DeleteLikedRecipe(likedRecipe);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}