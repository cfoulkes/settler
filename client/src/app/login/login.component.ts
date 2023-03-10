import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Component, isDevMode, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { AuthenticationService } from '../shared/auth/authentication.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public theForm!: FormGroup;
  isLoading = false;
  loginFailed: boolean = false;

  constructor(private authService: AuthenticationService, private router: Router) { }

  ngOnInit() {
    this.theForm = new FormGroup({
      email: new FormControl(isDevMode() ? 'admin@settler.test' : '', [Validators.required, Validators.email]),
      password: new FormControl(isDevMode() ? 'Password1!' : '', Validators.required),
    });
  }

  public onSubmit() {
    this.isLoading = true;

    this.authService.login(
      this.theForm.get('email')!.value,
      this.theForm!.get('password')!.value
    )
      .subscribe({
        next: (res) => this.processSuccess(res),
        error: (err) => this.processError(err)
      });
  }

  processSuccess(res: boolean) {
    this.navigateToInitialPage();
  }

  processError(error: HttpErrorResponse) {
    this.loginFailed = true;
    this.isLoading = false;
  }

  navigateToInitialPage() {
    this.isLoading = true;

    this.router.navigate(['dashboard']);
  }


}
