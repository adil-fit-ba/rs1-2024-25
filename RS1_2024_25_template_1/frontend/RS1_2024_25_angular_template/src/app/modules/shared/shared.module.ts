import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {UnauthorizedComponent} from './unauthorized/unauthorized.component';
import {RouterLink} from '@angular/router';
import {MyDialogSimpleComponent} from './dialogs/my-dialog-simple/my-dialog-simple.component';
import {MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle} from '@angular/material/dialog';
import {MatButton, MatIconButton} from '@angular/material/button';
import {MyDialogConfirmComponent} from './dialogs/my-dialog-confirm/my-dialog-confirm.component';
import {MatIcon} from '@angular/material/icon';
import {MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    UnauthorizedComponent,
    MyDialogSimpleComponent,
    MyDialogConfirmComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
    MatDialogTitle,
    MatDialogActions,
    MatButton,
    MatDialogClose,
    MatIcon,
    MatDialogContent,
    MatIconButton,
    MatSnackBarModule
  ],
  exports: [
    UnauthorizedComponent, // Omogućavamo ponovno korištenje UnauthorizedComponent
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class SharedModule {
}
