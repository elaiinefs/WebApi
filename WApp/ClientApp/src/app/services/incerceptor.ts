import { Component, OnInit, Injector, Injectable } from '@angular/core';
import {
  HttpClient, HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
@Injectable()
export class Interceptor implements HttpInterceptor {
  constructor(private inj: Injector, private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let authService = this.inj.get(AuthService); //authservice is an angular service  

    // Get the auth header from the service.
    const Authorization = authService.getToken();

    // Clone the request to add the new header.
    console.log(Authorization);
    const authReq = req.clone({ headers: req.headers.set('authorization', 'Bearer ' + localStorage.getItem('token')) });
    // Pass on the cloned request instead of the original request.
    return next.handle(authReq).pipe(map(event => {
      if (event instanceof HttpResponse && ~~(event.status / 100) > 3) {
        //console.info('HttpResponse::event =', event, ';');
      }
      else //console.info('event =', event, ';');
      return event;
    })
      );
  }
}
