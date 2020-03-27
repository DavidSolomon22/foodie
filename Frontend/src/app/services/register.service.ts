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
}
