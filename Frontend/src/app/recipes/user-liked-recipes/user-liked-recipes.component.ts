import { Component, OnInit } from '@angular/core';
import { RecipesService } from 'src/app/services/recipesService/recipes.service';
import { environment } from 'src/environments/environment';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-liked-recipes',
  templateUrl: './user-liked-recipes.component.html',
  styleUrls: ['./user-liked-recipes.component.scss']
})
export class UserLikedRecipesComponent implements OnInit {
  recipes;

  constructor(private recipeService: RecipesService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.recipeService.getAllRecipes().subscribe((response: any) => {
      this.recipes = response.map((recipe) => {
        recipe.imageUrl = `${environment.baseUrl}api/recipes/photo/${recipe.id}`;
        return recipe;
      });

      this.recipes = this.recipes.filter((recipe) => (recipe.likedRecipeId));
    });
  }

  onRecipeClick(id) {
    this.router.navigate(['recipe', id]);
  }
}
