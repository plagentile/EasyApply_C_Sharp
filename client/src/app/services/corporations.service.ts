import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Corporation } from '../models/corporation';


@Injectable({
  providedIn: 'root'
})


export class CorporationsService {

  baseUrl : string = environment.apiUrl;

  constructor(private http: HttpClient) { 
  }

  getCorporations(){
    return this.http.get<Corporation[]>(this.baseUrl + 'corporate');
  }

  getCorporationByUsername(corporateUsername : string){
    return this.http.get<Corporation>(this.baseUrl+ 'corporate/getCorporationByUsername/' + corporateUsername); 
  }

  getCorporationsWithNameLike(corporateName : string){
    return this.http.get<Corporation[]>(this.baseUrl + 'corporate' + corporateName);
  }

}
