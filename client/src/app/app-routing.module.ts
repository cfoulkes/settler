import { ShellComponent } from './shell/shell.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';

const routes: Routes = [{
  path: '',
  component: ShellComponent,
  canActivate: [AuthGuard],
}, {
  path: 'login',
  component: LoginComponent,
},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
