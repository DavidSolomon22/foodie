import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler
} from '@angular/common/http';
import { RegisterService } from '../services/register.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private service: RegisterService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const authToken = this.service.getToken();
    req = req.clone({
      setHeaders: {
        Authorization: 'Bearer ' + authToken
      }
    });
    return next.handle(req);
  }
}
