import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';
import { tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  constructor(private http: HttpClient) {}

  addRecipe(form: any) {
    let uri = environment.baseUrl + `api/recipes`;
    return this.http.post<any>(uri, form);
  }

  editRecipe(form: any) {
    let uri = environment.baseUrl + `api/recipes`;
    return this.http.put<any>(uri, form);
  }

  getAllRecipes() {
    let uri = environment.baseUrl + `api/recipes`;
    return this.http.get<any>(uri);
  }

  getRecipeById(id: string) {
    let uri = environment.baseUrl + `api/recipes/${id}`;
    return this.http.get<any>(uri);
  }

  getRecipePhoto(id: string) {
    let uri = environment.baseUrl + `api/recipes/photo/${id}`;
    return this.http.get(uri, {responseType: 'arraybuffer'});
  }
}
