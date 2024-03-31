import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { RegisterComponent } from './pages/register/register.component';
import { UserbusinfoComponent } from './pages/userbusinfo/userbusinfo.component';
import { LayoutComponent } from './pages/layout/layout.component';
import { BookingComponent } from './pages/booking/booking.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
  path: 'userbusinfo',
  component: UserbusinfoComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'layout',
    component: LayoutComponent
  },
  {
    path: 'booking',
    component: BookingComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
