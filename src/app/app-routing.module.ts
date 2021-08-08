import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { LoginComponent } from './comp/login/login.component';
import { RegisterComponent } from './comp/register/register.component';
import { HomeComponent } from './pages/home/home.component';


const routes: Routes = [
  {path: 'home', component: LandingComponent},
  {path: 'Login', component: LoginComponent},
  {path: 'Registro', component: RegisterComponent},
  {path: 'movimientos', component:HomeComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }