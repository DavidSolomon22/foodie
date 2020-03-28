import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';
import { tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  constructor(private http: HttpClient) {}

  register(form: any) {
    let uri = environment.baseUrl + `api/authentication/register`;
    return this.http.post(uri, form);
  }
  login(form: any) {
    let uri = environment.baseUrl + `api/authentication/login`;
    return this.http.post(uri, form);
  }
  users() {
    let uri = environment.baseUrl + `api/users`;
    return this.http.get(uri);
  }
  getToken() {
    return localStorage.getItem('access_token');
  }
  get isLogged(): boolean {
    let token = localStorage.getItem('access_token');
    return token !== null ? true : false;
  }
  updateUser(fo: any) {
    var jsonarray = [];
    var name = {
      op: 'replace',
      path: '/firstname',
      value: fo.firstname
    };
    var surname = {
      op: 'replace',
      path: '/surname',
      value: fo.surname
    };
    jsonarray.push(name);
    jsonarray.push(surname);
    console.log(jsonarray);
    let uri = environment.baseUrl + `api/users/`;
    this.http.patch(uri, jsonarray);
  }
}
