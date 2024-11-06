import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AdminLayoutComponent} from './admin-layout/admin-layout.component';
import {DestinationComponent} from './destination/destination.component';
import {DashboardComponent} from './dashboard/dashboard.component';
import {ReservationComponent} from './reservation/reservation.component';
import {AdminErrorPageComponent} from './admin-error-page/admin-error-page.component';
import {CitiesComponent} from './cities/cities.component';
import {CitiesEditComponent} from './cities/cities-edit/cities-edit.component';

const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    children: [
      {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      {path: 'dashboard', component: DashboardComponent},
      {path: 'cities', component: CitiesComponent},
      {path: 'cities/new', component: CitiesEditComponent},
      {path: 'cities/edit/:id', component: CitiesEditComponent},
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
