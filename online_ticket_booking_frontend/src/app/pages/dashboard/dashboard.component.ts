import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../Models/User.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  angular17token: User = {
    username: '',
    email: '',
    phone_number: ''
  };

  constructor(private router: Router) {}

  ngOnInit(): void {
    const token = localStorage.getItem('angular17token');
    if (token) {
      this.angular17token = JSON.parse(token);
    }
  }
}
