import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DestinationComponent } from './destination/destination.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { ReservationComponent } from './reservation/reservation.component';
import { AdminErrorPageComponent } from './admin-error-page/admin-error-page.component';


@NgModule({
  declarations: [
    DashboardComponent,
    DestinationComponent,
    AdminLayoutComponent,
    ReservationComponent,
    AdminErrorPageComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
