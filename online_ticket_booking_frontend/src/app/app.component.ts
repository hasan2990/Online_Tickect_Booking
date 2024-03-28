import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'online_ticket_booking_frontend';
  constructor(public router: Router) {}

  onLogout() {
    console.log("Log Out");
    localStorage.removeItem('angular17token');
    localStorage.removeItem('userEmail');
    this.router.navigate(['/login']);
  }
}
