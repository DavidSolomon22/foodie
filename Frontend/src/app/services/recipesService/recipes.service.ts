import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';
import { tap } from 'rxjs/operators';
import { Rate } from 'src/app/shared/models';

interface RecipeParameters {
  cuisine: string[],
  category: string[],
  complexityLevel: number,
  searchTerm: string
}

@Injectable({
  providedIn: 'root'
})

export class RecipesService {
  constructor(private http: HttpClient) {}

  addRecipe(form: any) {
    const uri = environment.baseUrl + `api/recipes`;
    return this.http.post<any>(uri, form);
  }

  editRecipe(form: any) {
    const uri = environment.baseUrl + `api/recipes`;
    return this.http.put<any>(uri, form);
  }

  getAllRecipes(recipeParameters?: RecipeParameters) {
    const uri = environment.baseUrl + `api/recipes`;

    if(recipeParameters) {
      let url = new URL(uri);
      if(recipeParameters.cuisine.length > 0) {
        url.searchParams.set("Cuisine", recipeParameters.cuisine.join(","));
      }

      if(recipeParameters.category.length > 0) {
        url.searchParams.set("Category", recipeParameters.category.join(","));
      }

      if(recipeParameters.complexityLevel) {
        url.searchParams.set("ComplexityLevel", recipeParameters.complexityLevel.toString());
      }
      
      console.log(recipeParameters);

      if(recipeParameters.searchTerm) {
        url.searchParams.set("SearchTerm", recipeParameters.searchTerm);
      }

      console.log(url.toString());

      return this.http.get<any>(url.toString());
    } else {
      return this.http.get<any>(uri);
    }
  }

  getRecipeById(id: string) {
    const uri = environment.baseUrl + `api/recipes/${id}`;
    return this.http.get<any>(uri);
  }

  getRecipePhoto(id: string) {
    const uri = environment.baseUrl + `api/recipes/photo/${id}`;
    return this.http.get(uri, {responseType: 'arraybuffer'});
  }

  getRecipeRates(recipeId: string) {
    const uri = environment.baseUrl + `api/rates/${recipeId}`;
    return this.http.get<any>(uri);
  }

  addRecipeRate(form: Rate){
    const uri = environment.baseUrl + `api/rates`;
    return this.http.post<any>(uri, form);
  }

  getMyRecipes() {
    const uri = environment.baseUrl + `api/users/${localStorage.getItem('user_id')}/recipes`;
    return this.http.get<any>(uri);
  }
}
