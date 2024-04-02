import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Login} from '../login/login.component';
import { Register } from '../register/register.component';
import { SelectedBusesResponse } from '../Models/SelectedBusesResponse.model';
import { RegionResponse } from '../Models/RegionResponse.model';
import { BookingResponse } from '../Models/BookingResponse.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  // public $refreshToken = new Subject<boolean>();
  // public $refreshTokenReceived = new Subject<boolean>();

  constructor(private http:HttpClient) { 
    // this.$refreshToken.subscribe((res:any) => {
    //   this.getRefreshToken();
    // })
  }
  baseApiUrl = 'https://localhost:44320/api';

  // LoginUser(loginObj : Login) : Observable<Login>{
  //   return this.http.post<Login>(this.baseApiUrl + `/login`, loginObj);
  // }
  // RegisterUser(RegisterObj : Register) : Observable<Register>{
  //   return this.http.post<Register>(this.baseApiUrl + `/registration`, RegisterObj);
  // }
  LoginUser(loginObj : Login) : Observable<Login>{
      return this.http.post<Login>(this.baseApiUrl + `/AuthWithRefreshToken/login`, loginObj);
  }
  RegisterUser(RegisterObj : Register) : Observable<Register>{
    return this.http.post<Register>(this.baseApiUrl + `/AuthWithRefreshToken/api/registration`, RegisterObj);
  }

  getBusesById(source_id: number, destination_id: number): Observable<SelectedBusesResponse> {
    return this.http.get<any>(`${this.baseApiUrl}/GetBuses/GetBusDetails?source_id=${source_id}&destination_id=${destination_id}`);
  }

  getRegions(): Observable<RegionResponse>{
    console.log("GetRegions", this.baseApiUrl);
    return this.http.get<any>(`${this.baseApiUrl}/Region/GetRegionDetails`);
  }

  onBooking(bus_id: number, seat_no: string, user_id: number, route_id: number, isPaid: boolean): Observable<BookingResponse> {
    console.log('onBooking', bus_id, seat_no,user_id,route_id,isPaid);
    return this.http.get<any>(`${this.baseApiUrl}/Booking?bus_id=${bus_id}&seat_no=${seat_no}&user_id=${user_id}&route_id=${route_id}&isPaid=${isPaid}`);
  }
  onBookingRequest(seat_no: string, isPaid: boolean): Observable<BookingResponse> {
    console.log('onBookingRequest',seat_no,isPaid);
    return this.http.get<any>(`${this.baseApiUrl}/Booking?seat_no=${seat_no}&isPaid=${isPaid}`);
  }
  // getRefreshToken(){
  //   debugger;
  //   const tokenObject = JSON.parse(localStorage.getItem('angular17token') || '{}');
    
  //   const obj = {
  //   "user_id": 0,
  //   "username": "string",
  //   "email": tokenObject.email,
  //   "password": "string",
  //   "isActive": true,
  //   "phone_number": "string",
  //   "refreshToken": tokenObject.refreshToken,
  //   "accessToken": "string"
  //   }
  //   this.http.post(this.baseApiUrl + `/AuthWithRefreshToken/refresh-token`,obj).subscribe((response: any) => {
  //     localStorage.setItem('angular17token', JSON.stringify(response.data));
  //     this.$refreshTokenReceived.next(true);
  //   })
  // }
}