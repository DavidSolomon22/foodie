using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DinkToPdf;
using Entities.Models;

namespace RestApi.Utility
{
    public class PdfService: IPdfService
    {
        private readonly IRepositoryManager _repository;

        public PdfService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public GlobalSettings GetGlobalSettings()
        {
            string userNameWithComputerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            var userName =  userNameWithComputerName.Split(@"\");
            

             var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "Diet",
                Out = $@"C:\Users\{userName[1]}\Downloads\Diet.pdf"
            };

            return globalSettings;
        }

        public async Task<ObjectSettings> GetObjectSettings(Diet dietEntity)
        {
             var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent =  await GenerateDietPdf(dietEntity),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "Resources", "PdfStyling", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Created by Foodie" }
            };

            return objectSettings;
        }

        public async Task<string> GenerateDietPdf(Diet dietEntity)
        {
            var recipes = new List<Recipe>();

            var sb = new StringBuilder();

            sb.Append($@"
                    <html>
                    <head>
                    </head>
                    <body>
                        <div class='header'><h1>{dietEntity.Name}</h1></div>
                        <table align='center' class='table-margin'>
                            <tr>
                                <th style='width:30%'>Creation Date</th>
                                <th style='width:70%'>Description</th>
                            </tr>
                            <tr>
                                <td>{dietEntity.DateCreated}</td>
                                <td>{dietEntity.Description}</td>
                            </tr>
                        </table>
                        ");

             sb.Append($@" 
                 <table align='center' class='table-margin'>
                    <tr>
                        <th style='width:15%'>Day</th>
                        <th style='width:15%'>Breakfast</th>
                        <th style='width:15%'>Dinner</th>
                        <th style='width:15%'>Supper</th>
                    </tr>
                ");

            foreach (DailyDiet dailyDiet in dietEntity.DailyDiets) 
            {
                sb.Append($@"
                    <tr>
                        <td>{dailyDiet.Day}</td>
                ");

                foreach (Meal meal in dailyDiet.Meals)
                {
                    var recipe = await _repository.Recipe.GetRecipeAsync(meal.RecipeId, trackChanges: false);

                    if (recipe == null)
                    {
                        continue;
                    }

                    if (!recipes.Exists(x => x.Id == recipe.Id))
                    {
                        recipes.Add(recipe);
                    }

                    sb.Append($@"
                            <td>{recipe.Name}</td>
                    ");
                }
                 sb.Append($@"
                           </tr>
                    ");
            }

            sb.Append($@"
                           </table>
                    ");
            
            foreach (Recipe recipe in recipes)
            {
               sb.Append($@"
               <div class='recipe-name'><h2>{recipe.Name}</h2></div>
               <table align='center'>
                    <tr>
                        <th style='width:30%'>Category</th>
                        <th style='width:30%'>Cuisine</th>
                        <th style='width:30%'>Estimated Time (Minutes)</th>
                    </tr>
                     <tr>
                        <td>{recipe.Category}</td>
                        <td>{recipe.Cuisine}</td>
                        <td>{recipe.EstimatedTime}</td>
                    </tr>
                </table>
                <table align='center'>
                    <tr>
                        <th class='other-color'>Ingredients</th>
                    </tr>
                </table>
                <table align='center'>
                    <tr>
                        <th style='width:30%'>Name</th>
                        <th style='width:30%'>Quantity</th>
                        <th style='width:30%'>Unit</th>
                    </tr>
               ");

               foreach (Ingredient ingredient in recipe.Ingredients)
               {
                   sb.Append($@"
                        <tr>
                            <td>{ingredient.Name}</td>
                            <td>{ingredient.Quantity}</td>
                            <td>{ingredient.Unit}</td>
                        </tr>
                   ");
               }

               sb.Append($@"
               </table>
               <table align='center'>
                    <tr>
                        <th class='other-color'>Steps</th>
                    </tr>
                </table>
                <table align='center' class='table-margin'>
               ");

                var i = 1;
               
                foreach (Step step in recipe.Steps)
                {
                     sb.Append($@"
                        <tr>
                            <td style='width:5%'>{i}</td>
                            <td style='width:90%'>{step.Instruction}</td>
                        </tr>
                    
                   ");
                    i++;
                }

                sb.Append($@"
                 </table>
                ");

            }
    
            sb.Append($@" 
                    </body>
                </html>
                ");

            return sb.ToString();
        }
    }
}