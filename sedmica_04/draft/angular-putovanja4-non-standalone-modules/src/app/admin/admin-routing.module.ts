import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DashboardComponent} from './dashboard/dashboard.component';
import {DestinationComponent} from './destination/destination.component';
import {OrderComponent} from './order/order.component';
import {LayoutComponent} from './layout/layout.component';
import {ErrorPageComponent} from './error-page/error-page.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      {path: 'dashboard', component: DashboardComponent},
      {path: 'destination', component: DestinationComponent},
      {path: 'order', component: OrderComponent},
      {path: '**', component: ErrorPageComponent}  // Default ruta koja vodi na public
    ]
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {
}
