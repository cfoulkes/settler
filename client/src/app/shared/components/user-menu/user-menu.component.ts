import { Component } from '@angular/core';
import { AuthenticationService } from '../../auth/authentication.service';
import { UserProfile } from '../../models/user-profile';
import { RandomColourService } from '../../utils/random-colour.service';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.scss'],
})
export class UserMenuComponent {
  userProfile: UserProfile;

  userImageUrl?: string;
  backgroundColour?: string;

  constructor(
    private authenticationService: AuthenticationService,
    private randomColourService: RandomColourService
  ) {
    this.userProfile = this.authenticationService.userProfile;
    this.backgroundColour = this.randomColourService.getColourForText(
      this.userProfile?.initials
    );
  }

  get initials() {
    return this.userProfile?.initials;
  }

  loadData() {
  }
}
