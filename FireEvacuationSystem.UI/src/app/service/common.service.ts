import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  url = 'http://localhost:5000/api/';
  constructor(private httpCM:HttpClient ){}

  
  getEmployee(){
    return this.httpCM.get(this.url + 'EmployeeRoutes');
   }
}
