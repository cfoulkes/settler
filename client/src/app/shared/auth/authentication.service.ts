import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const jwtHelper = new JwtHelperService();
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  isLoggedIn = false;
  username?: string;
  loggedInDateTime?: Date;
  authToken?: string;
  tokenPayload: any;
  userId?: number;

  private TOKEN_KEY = 'TOKEN_KEY';

  constructor(private httpClient: HttpClient, private router: Router) {
    let token = localStorage.getItem(this.TOKEN_KEY);
    //should check if token still valid
    if (token) {
      this.processLoginResponse({ token: token });
    }
  }

  public login(username: string, password: string): Observable<any> {
    const url = 'api/auth/login';
    var context = { username: username, password: password };

    return this.httpClient.post<string>(url, context).pipe(
      tap(resp => {
        this.username = context.username;
        this.processLoginResponse(resp);
      }),
      map(resp => true),

      catchError((error: HttpErrorResponse) => {
        return throwError(() => error);
      })
    );
  }

  processLoginResponse(response: any) {
    this.isLoggedIn = true;
    this.loggedInDateTime = new Date();
    this.authToken = response.token;
    this.tokenPayload = jwtHelper.decodeToken(this.authToken!);
    this.userId = this.tokenPayload.sub;
    localStorage.setItem(this.TOKEN_KEY, response.token)

  };

  logout() {
    this.isLoggedIn = false;
    this.authToken = '';
    this.tokenPayload = null;
    this.username = '';

    localStorage.clear();

    location.href =
      location.origin + "/"
  }


}
