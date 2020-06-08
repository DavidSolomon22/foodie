import { Component, OnInit } from '@angular/core';
import { RecipesService } from 'src/app/services/recipesService/recipes.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-user-recipes',
  templateUrl: './user-recipes.component.html',
  styleUrls: ['./user-recipes.component.scss']
})
export class UserRecipesComponent implements OnInit {
  recipes;

  constructor(private recipeService: RecipesService) { }

  ngOnInit() {
    this._downloadRecipes();
  }

  recipeDelete(recipeId) {
    if(confirm("Are you sure you want to delete this recipe?")) {
      this.recipeService.deleteRecipe(recipeId).subscribe((response: any) => {
        this._downloadRecipes();
      });
    }
  }

  _downloadRecipes() {
    this.recipeService.getMyRecipes().subscribe((response: any) => {
      this.recipes = response.map((recipe) => {
        recipe.imageUrl = `${environment.baseUrl}api/recipes/photo/${recipe.id}`;
        
        return recipe;
      });
    });
  }

}
