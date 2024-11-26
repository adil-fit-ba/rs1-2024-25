import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {DestinationComponent} from './destination/destination.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {ReservationComponent} from './reservation/reservation.component';
import {AdminErrorPageComponent} from './admin-error-page/admin-error-page.component';
import {Cities1Component} from './cities1/cities1.component';
import {Cities1EditComponent} from './cities1/cities1-edit/cities1-edit.component';
import {Cities2EditComponent} from './cities2/cities2-edit/cities2-edit.component';

const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      {path: 'dashboard', component: DashboardComponent},
      {path: 'cities', component: Cities1Component},
      {path: 'cities1/new', component: Cities1EditComponent},
      {path: 'cities2/new', component: Cities2EditComponent},
      {path: 'cities1/edit/:id', component: Cities1EditComponent},
      {path: 'cities2/edit/:id', component: Cities2EditComponent},
      {path: 'destination', component: DestinationComponent},
      {path: 'order', component: ReservationComponent},
      {path: '**', component: AdminErrorPageComponent} // Default ruta
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {
}
