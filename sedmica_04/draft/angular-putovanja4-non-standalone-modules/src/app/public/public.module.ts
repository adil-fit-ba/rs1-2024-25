import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing.module';
import {provideHttpClient} from '@angular/common/http';
import {AboutComponent} from './about/about.component';
import {HomeComponent} from './home/home.component';
import { TravelsComponent } from './travels/travels.component';
import { BlogComponent } from './blog/blog.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { LayoutComponent } from './layout/layout.component';


@NgModule({
  declarations: [
    AboutComponent,
    HomeComponent,
    TravelsComponent,
    BlogComponent,
    ContactUsComponent,
    LayoutComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule
  ],
  providers:[
    provideHttpClient()
  ]
})
export class PublicModule { }
