import { Component, OnInit } from '@angular/core';
import { RecipesService } from 'src/app/services/recipesService/recipes.service';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-recipe-page',
  templateUrl: './recipe-page.component.html',
  styleUrls: ['./recipe-page.component.scss']
})
export class RecipePageComponent implements OnInit {
  recipe;
  imageUrl;
  displayedColumns: string[] = ['name', 'unit', 'quantity'];
  ingredients;
  steps;

  constructor(private route: ActivatedRoute, private recipeService: RecipesService) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    this.recipeService.getRecipeById(id).subscribe((response: any) => {
      this.recipe = response;
      this.imageUrl = `${environment.baseUrl}api/recipes/photo/${response.id}`;
      this.ingredients = this.recipe.ingredients;
      this.steps = this.recipe.steps.map((step, i) => {
        return {
          id: i + 1,
          instruction: step.instruction
        }
      });
    });
  }

  recipeFavoriteClick() {
    var recipeFavorite = document.querySelector('.recipe-favourite');

    if(recipeFavorite.classList.contains('favorite')) {
      this.recipeService.dislikeRecipe(this.recipe.likedRecipeId).subscribe((response: any) => {
      });
      recipeFavorite.classList.remove('favorite');
    } else {
      this.recipeService.likeRecipe(this.recipe.id).subscribe((response: any) => {
      });
      recipeFavorite.classList.add('favorite');
    }
  }
}
