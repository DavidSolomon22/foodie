using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using DinkToPdf;
using DinkToPdf.Contracts;
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
        private readonly IConverter _converter;
        private readonly IPdfService _pdfService;

        public DietController(IRepositoryManager repository, IMapper mapper, IPhotoService photoService, IConverter converter, IPdfService pdfService)
        {
            _repository = repository;
            _mapper = mapper;
            _converter = converter;
            _pdfService = pdfService;
        }

        [HttpPost, Authorize]
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
                var dietDto = _mapper.Map<DietDto>(diet);
                return Ok(dietDto);
            }
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteDiet(Guid id)
        {
            var diet = await _repository.Diet.GetDietAsync(id, trackChanges: false);

            if (diet == null)
            {
                return NotFound();
            }

            _repository.Diet.DeleteDiet(diet);

            await _repository.SaveAsync();

            return NoContent();

        }

        [HttpPut("{id}"), Authorize]   
          public async Task<IActionResult> UpdateDiet(Guid id, [FromBody] DietForUpdateDto diet)
        {
            if (diet == null)
            {
                return BadRequest("RecipeForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dietEntity = await _repository.Diet.GetDietAsync(id, trackChanges: true);

            if (dietEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(diet, dietEntity);
            
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet("{dietId}/pdf"), Authorize]
        public async Task<IActionResult> CreateDietPdf(Guid dietId)
        {
            
            if (dietId == null)
            {
                return BadRequest("DietId is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var dietEntity = await _repository.Diet.GetDietAsync(dietId, trackChanges: false);

            if (dietEntity == null)
            {
                return NotFound("Exporting diet to pdf impossible, beacuse diet is null");
            }
 
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = _pdfService.GetGlobalSettings(),
                Objects = { await _pdfService.GetObjectSettings(dietEntity) }
            };
 
            _converter.Convert(pdf);

            return Ok("Pdf created succesfully");
        }

    }
}