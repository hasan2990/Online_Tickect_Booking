import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
import { PriceInfo } from '../Models/SelectedBusesResponse.model';
import { Region } from '../Models/RegionResponse.model';

@Component({
  selector: 'app-userbusinfo',
  templateUrl: './userbusinfo.component.html',
  styleUrls: ['./userbusinfo.component.scss'] 
})
export class UserbusinfoComponent implements OnInit {
  businfo: PriceInfo[]=[];
  source_id: any;
  destination_id: any;
  flag: boolean=false;
  regioninfo: Region[]=[];


  constructor(private http: HttpClient, private router: Router, private auth: AuthService) { }
  
  ngOnInit(): void {
    console.log('get token');
    var user = localStorage.getItem('angular17token') ?? '';
    const Vtoken = JSON.parse(user);
    var token = Vtoken.token;
    console.log(token);
    if (token==null) {
      alert('Login First')
      this.router.navigate(['/login']);
    }
    else {
      this.flag = true;
    }
    this.onSearchRegion();
   
  }
  onSearchOption() {
    console.log(this.source_id);
    console.log(this.destination_id);
    
    if (this.source_id && this.destination_id && this.flag) {
      this.auth.getBusesById(this.source_id, this.destination_id).subscribe(response => {
        console.log("OnSearchOption");
        if (response.isSuccess) {
          alert("Buses found");
          console.log(response);
          this.businfo = response.serviceGetBuses;
          console.log(this.businfo);
          if (this.businfo) {
            console.log(this.businfo.length);
          } else {
            console.log("No bus information available");
          }
        } else {
          alert("No Buses Available");
        }
      });
    }
    else {
      alert("Give Source and Destination.");
    }
  }
  onSearchRegion(){
    if(this.flag) {
      this.auth.getRegions().subscribe(response => {
        console.log("OnSearchRegion");
        console.log(response);
        
        if(response.isSuccess) {
          //alert("Regions are available");
          console.log(response);
          this.regioninfo = response.listregion;
          console.log(this.regioninfo);
          if (this.regioninfo) {
            console.log(this.regioninfo.length);
          } else {
            console.log("No region information available");
          }
        }
      });
    }else {
      alert("Login First")
      this.router.navigate(['/login']);
    }
  }

  onOption(bus: any) {
    if (this.flag) {
      alert("Booking Option");
      console.log("Selected bus:");
      console.log(bus);
  
      localStorage.setItem('selectedBus', JSON.stringify(bus));
      this.router.navigate(['/booking']);
    } else {
      alert("Login First");
      this.router.navigate(['/login']);
    }
  }
  
}
