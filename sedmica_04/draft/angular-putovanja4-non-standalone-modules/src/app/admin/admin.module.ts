import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DestinationComponent } from './destination/destination.component';
import { OrderComponent } from './order/order.component';
import { LayoutComponent } from './layout/layout.component';
import { ErrorPageComponent } from './error-page/error-page.component';


@NgModule({
  declarations: [
    DashboardComponent,
    DestinationComponent,
    OrderComponent,
    LayoutComponent,
    ErrorPageComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
