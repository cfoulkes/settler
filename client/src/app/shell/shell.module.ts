import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { ShellComponent } from './shell.component';
import { RouterModule } from '@angular/router';
import { MenuItemComponent } from './menu-item/menu-item.component';
import { ClientsModule } from '../clients/clients.module';
import { AdminModule } from '../admin/admin.module';



@NgModule({
  declarations: [ShellComponent, MenuItemComponent],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    ClientsModule,
    AdminModule
  ]
})
export class ShellModule { }
