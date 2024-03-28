import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { CommonModule } from '@angular/common';
import { User } from '../Models/User.model';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  loginObj: Login;
  userobj: User = {
    username: '',
    email: '',
    phone_number: '',
  }
  

  constructor(private http: HttpClient,private router: Router, private auth: AuthService) {
    this.loginObj = new Login();

  }
  onRegister()
  {
    this.router.navigate(['register']);
  }
  onLogin() {
    this.auth.LoginUser(this.loginObj).subscribe((response: any) => {
      if (response.isSuccess === true) {
        console.log(response);
        alert(response.statusMessage + "\nToken = " + response.token);
        this.userobj = response;
        //console.log(this.userobj);
        //localStorage.setItem('angular17token', response.token);
        localStorage.setItem('angular17token', JSON.stringify(this.userobj));
        this.router.navigate(['/dashboard']); 
      } else {
        alert("Invalid Password or Username"); 
      }
    }, error => {
      alert("An error occurred while trying to log in. Please check your Email.");
      console.error("Login Error:", error);
    });
  }

 }
export class Login {
  email: string;
  password: string;
  constructor() {
    this.email = '';
    this.password = ''; 
  }
}