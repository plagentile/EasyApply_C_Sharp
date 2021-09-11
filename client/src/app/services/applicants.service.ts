import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Applicant } from '../models/applicant';


const httpOptions = {
  headers : new HttpHeaders({
    Authorization : 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token
  })
}
@Injectable({
  providedIn: 'root'
})

export class ApplicantsService {

  baseUrl : string = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getApplicants() {
    return this.http.get<Applicant[]>(this.baseUrl + 'applicant', httpOptions);
  }

  getApplicant(username : string) {
    return this.http.get<Applicant>(this.baseUrl + 'applicant' +username, httpOptions);
  }
}
