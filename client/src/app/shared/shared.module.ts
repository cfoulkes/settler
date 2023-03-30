import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

export class AppModule { }
import { HttpClientModule } from '@angular/common/http';

import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTableModule } from '@angular/material/table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatDividerModule } from '@angular/material/divider';
import { MatMenuModule } from '@angular/material/menu';
import { ImageOrTextComponent } from './components/image-or-text/image-or-text.component';
import { UserMenuComponent } from './components/user-menu/user-menu.component';
import { UserMenuPopupComponent } from './components/user-menu-popup/user-menu-popup.component';
import { TranslateModule } from '@ngx-translate/core';
import { AddButtonComponent } from './components/add-button/add-button.component';

@NgModule({
  declarations: [
    ImageOrTextComponent,
    UserMenuComponent,
    UserMenuPopupComponent,
    AddButtonComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    LayoutModule,
    TranslateModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatSlideToggleModule,
    MatTableModule,
    MatDividerModule,
    MatMenuModule,
  ],
  exports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    LayoutModule,
    TranslateModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatSlideToggleModule,
    MatTableModule,
    MatDividerModule,
    MatMenuModule,

    ImageOrTextComponent,
    UserMenuComponent,
    UserMenuPopupComponent,
    AddButtonComponent,
  ],
})
export class SharedModule { }
