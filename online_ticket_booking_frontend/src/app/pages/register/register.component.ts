import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,FormsModule, HttpClientModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})

export class RegisterComponent {
RegisterObj: Register;

constructor(private http: HttpClient,private router: Router, private auth: AuthService) {
  this.RegisterObj = new Register();
}
onLog(){
    this.router.navigate(['login']);
}
  onRegistration() {
    debugger;
    this.auth.RegisterUser(this.RegisterObj).subscribe((response:any)=>{ 
      if(response.isSuccess === true){
        alert("Successfully Registered");
      }
      else{
        alert(response.statusMessage);
      }
    },
    (error: any) => {
        console.error("Registration failed:", error);
        alert("Registration failed. Please try again.");
      }
    );
  }
}

export class Register {
  username: string;
  email: string;
  password: string;
  isActive: boolean;
  phone_number: string;
  constructor() {
    this.username = '';
    this.email = '';
    this.password = ''; 
    this.isActive = true;
    this.phone_number = '';
  }
}