import { AuthenticationService } from './../shared/auth/authentication.service';
import { MenuItem } from './menu-item';
import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent {

  @ViewChild(MatSidenav)
  sidenav!: MatSidenav;

  menuItems = [
    new MenuItem('mainMenu.home', 'home', 'home', '/dashboard'),
    new MenuItem('mainMenu.clients', 'people', 'people', '/clients')
  ];

  agencyAdminMenuItems = [
    new MenuItem('mainMenu.staff', 'people', 'people', '/staff'),
  ];

  systemAdminMenuItems = [
    new MenuItem('mainMenu.agencies', 'store', 'store', '/agencies'),
  ];

  get regularMenuItems() {
    return this.menuItems;
  }

  get adminMenuItems() {
    // if (this.authenticationService.isSystemAdmin)
    return this.agencyAdminMenuItems;
  }

  /**
   *
   */
  constructor(private observer: BreakpointObserver, private authenticationService: AuthenticationService) { }

}
