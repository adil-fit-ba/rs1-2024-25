import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AdminRoutingModule} from './admin-routing.module';
import {DashboardComponent} from './dashboard/dashboard.component';
import {DestinationComponent} from './destination/destination.component';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {ReservationComponent} from './reservation/reservation.component';
import {AdminErrorPageComponent} from './admin-error-page/admin-error-page.component';
import {CitiesComponent} from './cities/cities.component';
import {CitiesEditComponent} from './cities/cities-edit/cities-edit.component';
import {FormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';


@NgModule({
  declarations: [
    DashboardComponent,
    DestinationComponent,
    AdminLayoutComponent,
    ReservationComponent,
    AdminErrorPageComponent,
    CitiesComponent,
    CitiesEditComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    SharedModule // Omogućava pristup svemu što je eksportovano iz SharedModule
  ],
  providers: []
})
export class AdminModule {
}
