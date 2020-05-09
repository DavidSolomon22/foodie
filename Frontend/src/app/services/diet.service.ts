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
}
