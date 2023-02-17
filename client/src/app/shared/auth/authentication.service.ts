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

  constructor(private httpClient: HttpClient, private router: Router) { }

  public login(username: string, password: string): Observable<any> {
    console.log(`login`)
    const url = 'api/auth/login';
    // this.authenticationClient.login(username, password).subscribe((token) => {
    //   localStorage.setItem(this.tokenKey, token);
    //   this.router.navigate(['/']);
    // });
    var context = { username: username, password: password };

    return this.httpClient.post<string>(url, context).pipe(
      tap(resp => {
        console.log(`success ${JSON.stringify(resp)}`);
        this.username = context.username;
        this.processLoginResponse(resp);
      }),
      map(resp => true),

      catchError((error: HttpErrorResponse) => {
        console.log(`error ${JSON.stringify(error)}`);
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

  };

}
