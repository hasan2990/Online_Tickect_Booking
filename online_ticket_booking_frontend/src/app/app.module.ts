import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { CommonModule } from "@angular/common";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { LayoutComponent } from './pages/layout/layout.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { RegisterComponent } from './pages/register/register.component';
import { UserbusinfoComponent } from './pages/userbusinfo/userbusinfo.component';
import { provideRouter } from '@angular/router';
import { routes } from './app-routing.module'
import { customInterceptor } from './pages/service/custom.interceptor';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { BookingComponent } from './pages/booking/booking.component';

@NgModule({
  declarations: [
    DashboardComponent,
    AppComponent,
    UserbusinfoComponent,
    BookingComponent,

    
  ],
  imports: [
    LayoutComponent,
    LoginComponent,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    RegisterComponent,
  ],
  providers: [
    provideClientHydration(),
    provideAnimationsAsync(),
    provideRouter(routes),provideHttpClient(withInterceptors([customInterceptor])),
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }