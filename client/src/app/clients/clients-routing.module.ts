import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Shell } from '../shell/shell';
import { ClientDetailsComponent } from './client-details/client-details.component';
import { ClientListComponent } from './client-list/client-list.component';

const routes: Routes = [Shell.childRoutes([
  { path: "clients", component: ClientListComponent, pathMatch: "full" },
  { path: "clients/:id", component: ClientDetailsComponent, pathMatch: "full" },
])];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientsRoutingModule { }
