import { NgModule } from '@angular/core';
import { StaffListComponent } from './staff-list/staff-list.component';
import { SharedModule } from '../shared/shared.module';
import { AdminRoutingModule } from './admin-routing.module';
import { AgencyListComponent } from './agency-list/agency-list.component';
import { AgencyDetailComponent } from './agency-detail/agency-detail.component';

@NgModule({
  declarations: [
    StaffListComponent,
    AgencyListComponent,
    AgencyDetailComponent,
  ],
  imports: [SharedModule, AdminRoutingModule],
})
export class AdminModule { }
