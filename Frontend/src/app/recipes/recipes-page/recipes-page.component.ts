import { Component, OnInit } from '@angular/core';
import { RecipesService } from 'src/app/services/recipesService/recipes.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-recipes-page',
  templateUrl: './recipes-page.component.html',
  styleUrls: ['./recipes-page.component.scss']
})
export class RecipesPageComponent implements OnInit {
  recipes;

  constructor(private recipeService: RecipesService) {}
  ngOnInit() {
    this.recipeService.getAllRecipes().subscribe((response: any) => {
      this.recipes = response.map((recipe) => {
        recipe.imageUrl = `${environment.baseUrl}api/recipes/photo/${recipe.id}`;

        switch(recipe.complexityLevel) {
          case 1: {
            recipe.complexity = "Easy";
            break;
          }
          case 2: {
            recipe.complexity = "Intermediate";
            break;
          }
          case 3: {
            recipe.complexity = "Advanced";
            break;
          }
        }

        return recipe;
      });
    });
  }
}
