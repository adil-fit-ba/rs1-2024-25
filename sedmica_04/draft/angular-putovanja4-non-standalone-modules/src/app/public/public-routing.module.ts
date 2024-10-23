import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {AboutComponent} from './about/about.component';
import {LayoutComponent} from './layout/layout.component';

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {path: '', redirectTo: 'home', pathMatch: 'full'},
      {path: 'home', component: HomeComponent},
      {path: 'about', component: AboutComponent},
      {path: 'blog', component: AboutComponent},
      {path: 'contact-us', component: AboutComponent},
      {path: 'travels', component: AboutComponent},
      {path: '**', redirectTo: 'home', pathMatch: 'full'}  // Default ruta koja vodi na public
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule {
}
