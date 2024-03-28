import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login} from '../login/login.component';
import { Register } from '../register/register.component';
import { map } from 'rxjs/operators';
import { PriceInfo, SelectedBusesResponse } from '../Models/SelectedBusesResponse.model';
import { RegionResponse } from '../Models/RegionResponse.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }
  baseApiUrl = 'https://localhost:44320/api';

  LoginUser(loginObj : Login) : Observable<Login>{
      return this.http.post<Login>(this.baseApiUrl + '/login', loginObj);
  }
  RegisterUser(RegisterObj : Register) : Observable<Register>{
    return this.http.post<Register>(this.baseApiUrl + '/registration', RegisterObj);
  }

  getBusesById(source_id: number, destination_id: number): Observable<SelectedBusesResponse> {
    console.log('getBusesById', source_id, destination_id);
    return this.http.get<any>(`${this.baseApiUrl}/GetBuses/GetBusDetails?source_id=${source_id}&destination_id=${destination_id}`);
  }

  getRegions(): Observable<RegionResponse>{
    return this.http.get<any>(`${this.baseApiUrl}/Region/GetRegionDetails`);
  }
}