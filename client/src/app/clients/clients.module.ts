import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientsRoutingModule } from './clients-routing.module';
import { ClientListComponent } from './client-list/client-list.component';
import { ClientDetailsComponent } from './client-details/client-details.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    ClientListComponent,
    ClientDetailsComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    ClientsRoutingModule
  ]
})
export class ClientsModule { }
