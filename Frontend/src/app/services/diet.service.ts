import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DietService {
  constructor(private http: HttpClient) {}

  getAllRecipes() {
    let uri = environment.baseUrl + `api/recipes`;
    return this.http.get<any>(uri);
  }
  getRecipe(id: any) {
    let uri = environment.baseUrl + `api/recipes/` + id;
    return this.http.get<any>(uri);
  }
  getDiet(id: any) {
    let uri = environment.baseUrl + `api/diets/` + id;
    return this.http.get<any>(uri);
  }
  getAllDiets() {
    let uri = environment.baseUrl + `api/diets`;
    return this.http.get<any>(uri);
  }
  postDiet(diet: any) {
    let uri = environment.baseUrl + `api/diets`;
    return this.http.post(uri, diet);
  }
  deleteDiet(dietId: any) {
    let uri = environment.baseUrl + `api/diets/` + dietId;
    return this.http.delete(uri);
  }
}
