import { Component, OnInit } from '@angular/core';
import { RecipesService } from 'src/app/services/recipesService/recipes.service';
import { RegisterService } from 'src/app/services/register.service';
import { environment } from 'src/environments/environment';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-recipes-search',
  templateUrl: './recipes-search.component.html',
  styleUrls: ['./recipes-search.component.scss']
})
export class RecipesSearchComponent implements OnInit {
  recipes;
  search = {
    searchTerm: "",
    cuisine: [],
    category: [],
    complexityLevel: 0 
  }

  users;

  complexityLevels = [
    {
      key: 0,
      text: "All"
    },
    {
      key: 1,
      text: "Beginer"
    },
    {
      key: 2,
      text: "Intermediate"
    },
    {
      key: 3,
      text: "Advanced"
    }
   ]


  constructor(private recipeService: RecipesService, private registerService: RegisterService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.registerService.users().subscribe((response: any) => {
      console.log(response);
    });

    this.activatedRoute.queryParams.subscribe(params => {
      if(params.searchTerm) {
        this.search.searchTerm = params.searchTerm;
      }

      if(params.cuisine) {
        this.search.cuisine = params.cuisine.split(',').map((cuisine) => {
          return {
            value: cuisine
          }
        });
      }

      if(params.category) {
        this.search.category = params.category.split(',').map((category) => {
          return {
            value: category
          }
        });
      }

      if(params.complexityLevel) {
        this.search.complexityLevel = parseInt(params.complexityLevel);
      }
    });

    

    const recipeParameters = {
      searchTerm: this.search.searchTerm,
      cuisine: this.search.cuisine.map((cuisine) => {
        return cuisine.value;
      }),
      category: this.search.category.map((category) => {
        return category.value;
      }),
      complexityLevel: (this.search.complexityLevel === 0)? undefined: this.search.complexityLevel
    }

    this.recipeService.getAllRecipes(recipeParameters).subscribe((response: any) => {
      this.recipes = response.map((recipe) => {
        recipe.imageUrl = `${environment.baseUrl}api/recipes/photo/${recipe.id}`;
        
        return recipe;
      });
    });
  }

  onCategoryInputChange(event) {
    var value = event.target.value;
    if (event.keyCode === 13 && value.trim() !== "") {
      this.search.category.push({
        value: value.trim()
      });
    
      event.target.value = "";
    }
  }

  deleteCategory(key) {
    this.search.category.splice(key, 1);
  }

  onCuisineInputChange(event) {
    var value = event.target.value;
    if (event.keyCode === 13 && value.trim() !== "") {
      this.search.cuisine.push({
        value: value.trim()
      });
    
      event.target.value = "";
    }
  }

  deleteCuisine(key) {
    this.search.cuisine.splice(key, 1);
  }

  onSearchSubmit() {
    const recipeParameters = {
      searchTerm: this.search.searchTerm,
      cuisine: this.search.cuisine.map((cuisine) => {
        return cuisine.value;
      }),
      category: this.search.category.map((category) => {
        return category.value;
      }),
      complexityLevel: (this.search.complexityLevel === 0)? undefined: this.search.complexityLevel
    }

    const queryParams = {};

    if(recipeParameters.searchTerm.trim() !== "") {
      queryParams["searchTerm"] = recipeParameters.searchTerm;
    }

    if(recipeParameters.cuisine.length > 0) {
      queryParams["cuisine"] = recipeParameters.cuisine.join(",");
    }

    if(recipeParameters.category.length > 0) {
      queryParams["category"] = recipeParameters.category.join(",");
    }

    if(recipeParameters.complexityLevel) {
      queryParams["complexityLevel"] = recipeParameters.complexityLevel;
    }

    this.router.navigate(['recipesSearch'], {
      queryParams
    });

    this.recipeService.getAllRecipes(recipeParameters).subscribe((response: any) => {
      this.recipes = response.map((recipe) => {
        recipe.imageUrl = `${environment.baseUrl}api/recipes/photo/${recipe.id}`;
        
        return recipe;
      });
    });
  }

  onRecipeClick(id) {
    this.router.navigate(['recipe', id]);
  }
}
