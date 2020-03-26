using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.ModelBinders;

namespace RestApi.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    [Authorize]
    public class RecipesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RecipesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody]RecipeForCreationDto recipe)
        {
            if(recipe == null)
            {
                return BadRequest("RecipeForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var recipeEntity = _mapper.Map<Recipe>(recipe);

            _repository.Recipe.CreateRecipe(recipeEntity);
            await _repository.SaveAsync();

            var recipeToReturn = _mapper.Map<RecipeDto>(recipeEntity);

            return CreatedAtRoute("RecipeById", new { id = recipeToReturn.Id }, recipeToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateRecipeCollection([FromBody] IEnumerable<RecipeForCreationDto> recipeCollection)
        {
            if(recipeCollection == null)
            {
                return BadRequest("Recipe collection is null");
            }

            var recipeEntities = _mapper.Map<IEnumerable<Recipe>>(recipeCollection);
            foreach (var recipe in recipeEntities)
            {
                _repository.Recipe.CreateRecipe(recipe);
            }
            await _repository.SaveAsync();

            var recipeCollectionToReturn = _mapper.Map<IEnumerable<RecipeDto>>(recipeEntities);
            var ids = string.Join(",", recipeCollectionToReturn.Select(c => c.Id));

            return CreatedAtRoute("RecipeCollection", new { ids }, recipeCollectionToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await _repository.Recipe.GetAllRecipesAsync(trackChanges: false);

            var recipesDto = _mapper.Map<IEnumerable<RecipeDto>>(recipes);

            return Ok(recipesDto);
        }

        [HttpGet("{id}", Name = "RecipeById")]
        public async Task<IActionResult> GetRecipe(Guid id)
        {
            var recipe = await _repository.Recipe.GetRecipeAsync(id, trackChanges: false);
            if (recipe == null)
            {
                return NotFound();
            }
            else
            {
                var recipeDto = _mapper.Map<RecipeDto>(recipe);
                return Ok(recipeDto);
            }
        }

        [HttpGet("collection/({ids})", Name = "RecipeCollection")]
        public async Task<IActionResult> GetRecipeCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            if(ids == null)
            {
                return BadRequest("Parameter ids is null");
            }

            var recipeEntities = await _repository.Recipe.GetRecipesByIdsAsync(ids, trackChanges: false);

            if(ids.Count() != recipeEntities.Count())
            {
                return NotFound();
            }

            var recipesToReturn = _mapper.Map<IEnumerable<RecipeDto>>(recipeEntities);
            return Ok(recipesToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(Guid id, [FromBody] RecipeForUpdateDto recipe)
        {
            if(recipe == null)
            {
                return BadRequest("RecipeForUpdateDto object is null");
            }

            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var recipeEntity = await _repository.Recipe.GetRecipeAsync(id, trackChanges: true);
            if(recipeEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(recipe, recipeEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            var recipe = await _repository.Recipe.GetRecipeAsync(id, trackChanges: false);
            if(recipe == null)
            {
                return NotFound();
            }

            _repository.Recipe.DeleteRecipe(recipe);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
