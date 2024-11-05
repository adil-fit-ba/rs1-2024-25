import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)  // Lazy load  modula
  },
  {
    path: 'public',
    loadChildren: () => import('./modules/public/public.module').then(m => m.PublicModule)  // Lazy load  modula
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)  // Lazy load  modula
  },
  {path: '**', redirectTo: 'public', pathMatch: 'full'}  // Default ruta koja vodi na public
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
