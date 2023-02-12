import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { SharedModule } from '../shared/shared.module';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public theForm!: FormGroup;

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.theForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }

  public onSubmit() {
    this.authenticationService.login(
      this.theForm.get('username')!.value,
      this.theForm!.get('password')!.value
    );
  }


}
