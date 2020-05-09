import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';
import { tap } from 'rxjs/operators';
import { Rate } from 'src/app/shared/models';
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

  getAllRecipes() {
    const uri = environment.baseUrl + `api/recipes`;
    return this.http.get<any>(uri);
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
}
