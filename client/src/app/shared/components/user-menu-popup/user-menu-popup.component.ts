import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../auth/authentication.service';
import { UserProfile } from '../../models/user-profile';
import { RandomColourService } from '../../utils/random-colour.service';

@Component({
  selector: 'app-user-menu-popup',
  templateUrl: './user-menu-popup.component.html',
  styleUrls: ['./user-menu-popup.component.css'],
})
export class UserMenuPopupComponent {
  @Input()
  userProfile!: UserProfile;

  backgroundColour: string;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private randomColourService: RandomColourService
  ) {
    this.backgroundColour = this.randomColourService.getColourForText(this.userProfile?.initials);
  }

  ngOnInit() {
  }

  get initials() {
    return this.userProfile.initials;
  }

  // imageOnError(event: any) {
  //   this.userProfile.imageUrl = null;
  // }


  userSettingsClicked() {
    this.router.navigate(['profile-management']);
  }

  logoutClicked() {
    this.authenticationService.logout();
  }

}
