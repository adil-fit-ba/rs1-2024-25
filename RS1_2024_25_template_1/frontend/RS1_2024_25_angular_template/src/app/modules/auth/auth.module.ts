import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AuthRoutingModule} from './auth-routing.module';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';
import {ForgetPasswordComponent} from './forget-password/forget-password.component';
import {TwoFactorComponent} from './two-factor/two-factor.component';
import {FormsModule} from '@angular/forms';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    ForgetPasswordComponent,
    TwoFactorComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule
  ]
})
export class AuthModule {
}
