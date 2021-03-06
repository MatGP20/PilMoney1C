import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './menus/header/header.component';
import { FooterComponent } from './menus/footer/footer.component';
import { LandingComponent } from './pages/landing/landing.component';
import { HomeComponent } from './pages/home/home.component';
import { CompModule } from './comp/comp.module'


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LandingComponent,
    HomeComponent       
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CompModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }