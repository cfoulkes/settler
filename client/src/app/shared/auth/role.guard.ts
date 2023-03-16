import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';

export class RoleGuard {
  static forRoles(...roles: string[]) {

    @Injectable({
      providedIn: 'root'
    })
    class RoleCheck implements CanActivate {
      constructor(private authService: AuthenticationService) { }
      canActivate(): Observable<boolean> | Promise<boolean> | boolean {
        const userRoles = this.authService.roles;

        userRoles.forEach(userRole => {
          if (roles.includes(userRole)) {
            return true;
          }
        });
        return false;
      }
    }

    return RoleCheck;
  }

}
