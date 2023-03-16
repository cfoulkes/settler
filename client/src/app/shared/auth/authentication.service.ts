import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { UserProfile } from '../models/user-profile';

const jwtHelper = new JwtHelperService();
@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    isLoggedIn = false;
    isSystemAdmin = false;
    email?: string;
    loggedInDateTime?: Date;
    authToken?: string;
    tokenPayload: any;
    userId?: number;
    roles: string[] = [];

    userProfile: UserProfile = new UserProfile({ firstName: 'Colin', lastName: 'Foulkes' });


    private TOKEN_KEY = 'TOKEN_KEY';

    constructor(private httpClient: HttpClient, private router: Router) {
        let token = localStorage.getItem(this.TOKEN_KEY);
        //should check if token still valid
        if (token) {
            this.processLoginResponse({ token: token });
        }
    }

    public login(email: string, password: string): Observable<any> {
        const url = 'api/auth/login';
        var context = { email: email, password: password };

        return this.httpClient.post<string>(url, context).pipe(
            tap(resp => {
                this.email = context.email;
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
        if (this.tokenPayload.role instanceof Array) {
            this.roles = this.tokenPayload.role;
        } else {
            this.roles = [this.tokenPayload.role];
        }

        this.isSystemAdmin = this.roles.includes('SysAdmin');


    };

    logout() {
        this.isLoggedIn = false;
        this.isSystemAdmin = false;
        this.authToken = '';
        this.tokenPayload = null;
        this.email = '';
        this.roles = [];

        localStorage.clear();

        location.href =
            location.origin + "/"
    }


}
