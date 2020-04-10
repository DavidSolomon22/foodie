import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import * as moment from 'moment';
import { tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  constructor(private http: HttpClient) {}

  register(form: any) {
    console.log(form);
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
  logOut() {
    localStorage.clear();
  }
  updateUser(fo: any) {
    var jsonarray = [];
    var name = {
      op: 'replace',
      path: '/firstname',
      value: fo.firstname,
    };
    var surname = {
      op: 'replace',
      path: '/surname',
      value: fo.surname,
    };
    jsonarray.push(name);
    jsonarray.push(surname);
    console.log(jsonarray);
    var user = localStorage.getItem('user_id');
    let uri = environment.baseUrl + `api/users/` + user;
    return this.http.patch(uri, jsonarray);
  }
  postUserPhoto(file: File) {
    var user = localStorage.getItem('user_id');
    let uri = environment.baseUrl + `api/users/` + user;
    return this.http.post(uri, file);
  }
  getUser() {
    var user = localStorage.getItem('user_id');
    var uri = environment.baseUrl + `api/users/` + user;
    return this.http.get(uri);
  }
  newPassword(fo: any) {
    var user = localStorage.getItem('user_id');
    let uri = environment.baseUrl + `ap/user/password/` + user;
    return this.http.post(uri, fo);
  }
}
