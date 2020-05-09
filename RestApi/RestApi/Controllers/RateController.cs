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
    [Route("api/rates")]
    [ApiController]
    public class RateController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public RateController(IRepositoryManager repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreateRate([FromBody] RateForCreationDto rate)
        {

            if (rate == null)
            {
                return BadRequest("RateForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var rateEntity = _mapper.Map<Rate>(rate);

            _repository.Rate.CreateRate(rateEntity);
            await _repository.SaveAsync();

            var rateToReturn = _mapper.Map<RateDto>(rateEntity);

            return CreatedAtRoute("AllRatesforUser", new { id = rateToReturn.Id }, rateToReturn);
        }

         [HttpGet("{id}", Name = "AllRatesforUser"), Authorize]
        public async Task<IActionResult> GetRatesByUserId(Guid id)
        {
            var rates = await _repository.Rate.GetAllRatesForRecipeAsync(id, trackChanges: false);
           
            var recipeDto = _mapper.Map<IEnumerable<RateDto>>(rates);

            return Ok(recipeDto);
            
        }

    }
}