using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{   
    [Route("api/diets")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public DietController(IRepositoryManager repository, IMapper mapper, IPhotoService photoService)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost, DisableRequestSizeLimit, Authorize]
        public async Task<IActionResult> CreateDiet([FromBody] DietForCreationDto diet)
        {

            if (diet == null)
            {
                return BadRequest("DietForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dietEntity = _mapper.Map<Diet>(diet);

            _repository.Diet.CreateDiet(dietEntity);
            await _repository.SaveAsync();

            var dietToReturn = _mapper.Map<DietDto>(dietEntity);

            return CreatedAtRoute("DietById", new { id = dietToReturn.Id }, dietToReturn);
        }

         [HttpGet, Authorize]
        public async Task<IActionResult> GetDiets()
        {
            var diets = await _repository.Diet.GetAllDietAsync(trackChanges: false);

            var dietsDto = _mapper.Map<IEnumerable<DietDto>>(diets);

            return Ok(dietsDto);
        }

         [HttpGet("{id}", Name = "DietById"), Authorize]
        public async Task<IActionResult> GetDiet(Guid id)
        {
            var diet = await _repository.Diet.GetDietAsync(id, trackChanges: false);
            if (diet == null)
            {
                return NotFound();
            }
            else
            {
                var recipeDto = _mapper.Map<DietDto>(diet);
                return Ok(recipeDto);
            }
        }
    }
}