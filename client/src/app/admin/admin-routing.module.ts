import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Shell } from '../shell/shell';
import { AgencyListComponent } from './agency-list/agency-list.component';
import { StaffListComponent } from './staff-list/staff-list.component';

const routes: Routes = [Shell.childRoutes([
  { path: "staff", component: StaffListComponent, pathMatch: "full" },
  { path: "agencies", component: AgencyListComponent, pathMatch: "full" },
])];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
