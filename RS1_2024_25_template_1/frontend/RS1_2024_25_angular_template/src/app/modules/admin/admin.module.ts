import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AdminRoutingModule} from './admin-routing.module';
import {DashboardComponent} from './dashboard/dashboard.component';
import {DestinationComponent} from './destination/destination.component';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {ReservationComponent} from './reservation/reservation.component';
import {AdminErrorPageComponent} from './admin-error-page/admin-error-page.component';
import {Cities1Component} from './cities1/cities1.component';
import {Cities1EditComponent} from './cities1/cities1-edit/cities1-edit.component';
import {FormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import {Cities2EditComponent} from './cities2/cities2-edit/cities2-edit.component';
import {Cities2Component} from './cities2/cities2.component';
import {MatButton} from "@angular/material/button";


@NgModule({
  declarations: [
    DashboardComponent,
    DestinationComponent,
    AdminLayoutComponent,
    ReservationComponent,
    AdminErrorPageComponent,
    Cities1Component,
    Cities2Component,
    Cities1EditComponent,
    Cities2EditComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    SharedModule,
    MatButton,
    // Omogućava pristup svemu što je eksportovano iz SharedModule
  ],
  providers: []
})
export class AdminModule {
}
