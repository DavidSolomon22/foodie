import { Component, OnInit } from '@angular/core';
import { RecipesService } from 'src/app/services/recipesService/recipes.service';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipes-page',
  templateUrl: './recipes-page.component.html',
  styleUrls: ['./recipes-page.component.scss']
})
export class RecipesPageComponent implements OnInit {
  recipes;
  search = {
    value: ""
  }

  constructor(private recipeService: RecipesService, private router: Router) { }

  ngOnInit() {
    this.recipeService.getAllRecipes().subscribe((response: any) => {
      this.recipes = response.map((recipe) => {
        console.log(recipe);

        recipe.imageUrl = `${environment.baseUrl}api/recipes/photo/${recipe.id}`;
        
        return recipe;
      });
    });
  }

  onSearchSubmit() {
    this.router.navigate(['recipesSearch'], {
      queryParams: {
        searchTerm: this.search.value
      }
    });
  }

  onRecipeClick(id) {
    this.router.navigate(['recipe', id]);
  }
}