import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { Booking } from '../Models/BookingResponse.model';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.scss'
})
export class BookingComponent implements OnInit {

  bookinginfo: Booking[]=[];
  bus_id: any;
  seat_no: any;
  route_id: any;
  isPaid: any;
  user_id: any;
  bus_name: any;

  constructor(private http: HttpClient, private router: Router, private auth: AuthService) { 
    this.isPaid = false;
  }

  ngOnInit(): void {
    console.log('Booking ngOnInit');
    this.retrieveUserData();
    console.log('Booking SelectedBusData ngOnInit');
    this.retrieveSelectedBusData();
  }

  retrieveUserData(): void {
    const user = localStorage.getItem('angular17token');
    if (user) {
      try {
        const Vtoken = JSON.parse(user);
        this.user_id = Vtoken.user_id;
        console.log(Vtoken.user_id + '  ' + Vtoken.username + ' ' + Vtoken.phone_number);
      } catch (error) {
        console.error('Error parsing user JSON:', error);
      }
    } else {
      console.error('No user data found in localStorage');
    }
  }

  retrieveSelectedBusData(): void {
    const userselectedbus = localStorage.getItem('selectedBus');
    if (userselectedbus) {
      try {
        const VToken = JSON.parse(userselectedbus);
        console.log('VToken:', VToken);

        this.bus_id = VToken.bus_id;
        this.route_id = VToken.route_id;
        this.bus_name = VToken.bus_name;
        
        console.log(VToken.bus_id + '  ' + this.bus_name + ' ' + VToken.route_id);

      } catch (error) {
        console.error('Error parsing selected bus JSON:', error);
      }
    } else {
      console.error('No selected bus data found in localStorage');
    }
  }
  onSearchOption() {
    console.log(this.bus_id);
    console.log(this.seat_no);
    console.log(this.bus_name);
    this.auth.onBooking(this.bus_id, this.seat_no, this.user_id, this.route_id, this.isPaid)
      .subscribe(
        response => {
          console.log("OnSearchOption " + this.user_id + " " + this.bus_id + " " + this.route_id + " " + this.bus_name);
  
          if (response.isSuccess) {
            console.log(response);
            alert(response.statusMessage);
            this.bookinginfo = response.bookingList ?? [];
            console.log(this.bookinginfo);
            if (this.bookinginfo) {
              console.log(this.bookinginfo.length);
            } else {
              console.log("No information available");
            }
          } else {
            console.log("An error occurred onBooking.");
            alert("An error occurred onBooking.");
          }
        }
        // ,
        // error => {
        //   if (error.status === 500) {
        //     alert("The user has already booked 4 seats for this bus and route combination.");
        //   } else {
        //     console.error("HTTP error:", error);
        //   }
        // }
      );
  }
  
}
