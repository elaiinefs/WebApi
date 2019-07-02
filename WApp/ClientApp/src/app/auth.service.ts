
import { Injectable, Inject, InjectionToken  } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpResponse, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { filter, share, map } from 'rxjs/operators';
import Auth0Lock from 'auth0-lock';
import { environment } from '../environments/environment';
import * as auth0 from 'auth0-js';
import { Observable, of } from 'rxjs';
import { JwtHelperService } from 'auth0-js';

(window as any).global = window;
@Injectable()
export class AuthService {
  public currentUrl: string;
  public paymentInfo: any;
  private decoder: JwtHelperService;
  auth0 = new auth0.WebAuth({
    clientID: 'KN4t97RHiydBMKRlQEMj3QMyacyAB3XH',
    domain: 'zaraiipay.auth0.com',
    responseType: 'token id_token',
    redirectUri: environment.apiEndpoint,
    scope: 'openid email profile'
  });

  constructor(public router: Router, @Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.currentUrl = baseUrl;
  }

  public login(): void {
    this.auth0.authorize();
  }
  // ...
  public handleAuthentication(): void {
    this.auth0.parseHash((err: any, authResult: any) => {
      if (authResult && authResult.accessToken && authResult.idToken) {
        window.location.hash = '';
        this.setSession(authResult);
        this.router.navigate(['']);
      } else if (err) {
        this.router.navigate(['']);
      }
    });
  }

  private setSession(authResult: any): void {
    // Set the time that the Access Token will expire at
    const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
    localStorage.setItem('access_token', authResult.accessToken);
    localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('expires_at', expiresAt);
    localStorage.setItem("user_email", authResult.idTokenPayload.email);
    this.paymentInfo = {
      Buyer_Email: authResult.idTokenPayload.email
    }
    this.authenticate(this.paymentInfo);
  }
  public authenticate(paymentInfo: any) {
    return this.http.post<Object>(this.currentUrl + 'api/v1/Authorize', paymentInfo).subscribe(result => {
      localStorage.setItem('token', result["token"]);
    }, error => console.error(error));
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    localStorage.removeItem('access_token');
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
    localStorage.removeItem("user_email");
    // Go back to the home route
    this.auth0.logout({
      return_to: window.location.origin
    });
    this.router.navigateByUrl('/logout');
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // Access Token's expiry time
    const expiresAt = JSON.parse(localStorage.getItem('expires_at') || '{}');
    return new Date().getTime() < expiresAt;
  }

  public getToken(): Observable<string> {
    const token = localStorage.getItem('token');
    const isTokenExpired = false;
    if (!isTokenExpired) {
      return of(token);
    }
    return this.refreshToken();
  }
  refreshToken(): Observable<string> {
    const url = this.currentUrl + 'api/v1/Authorize';

    // append refresh token if you have one
    const refreshToken = localStorage.getItem('refreshToken');
    const expiredToken = localStorage.getItem('token');

    return this.http
      .get(url, {
        headers: new HttpHeaders()
          .set('refreshToken', refreshToken)
          .set('token', expiredToken),
        observe: 'response'
      })
      .pipe(
        share(), // <========== YOU HAVE TO SHARE THIS OBSERVABLE TO AVOID MULTIPLE REQUEST BEING SENT SIMULTANEOUSLY
        map(res => {
          const token = res.headers.get('token');
          const newRefreshToken = res.headers.get('refreshToken');
          // store the new tokens
          localStorage.setItem('refreshToken', newRefreshToken);
          localStorage.setItem('token', token);
          return token;
        })
      );
  }
  removeTokens() {
    localStorage.removeItem('token');
  }
}
