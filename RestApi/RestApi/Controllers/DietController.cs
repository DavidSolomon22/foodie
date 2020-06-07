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

            var dietEntity = await _repository.Diet.GetDietAsync(dietId, trackChanges: true);

            var recipes = new List<Recipe>();

            foreach (DailyDiet dailyDiet in dietEntity.DailyDiets) 
            {
                foreach (Meal meal in dailyDiet.Meals)
                {
                    recipes.Add(meal.Recipe);
                }
            }

            if (dietEntity == null)
            {
                return NotFound("Exporting diet to pdf impossible, beacuse diet is null");
            }

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"C:\Users\Jacek\Downloads\Diet.pdf"
            };
 
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                // HtmlContent = _pdfService.GenerateDietPdf(dietId),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "Resources", "PdfStyling", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
 
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
 
            _converter.Convert(pdf);

            return Ok("success");

        }

    }
}