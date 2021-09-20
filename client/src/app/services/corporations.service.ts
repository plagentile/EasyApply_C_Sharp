import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Corporation } from '../models/corporation';


const httpOptions = {
  headers : new HttpHeaders({
    Authorization : 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
  })
}

@Injectable({
  providedIn: 'root'
})


export class CorporationsService {

  baseUrl : string = environment.apiUrl;

  constructor(private http: HttpClient) { 
  }

  getCorporations(){
    return this.http.get<Corporation[]>(this.baseUrl + 'corporate', httpOptions);
  }

  getCorporationsWithNameLike(corporateName : string){
    console.log('Attempting to reach')
    return this.http.get<Corporation[]>(this.baseUrl + 'corporate/' + corporateName, httpOptions);
  }

}
