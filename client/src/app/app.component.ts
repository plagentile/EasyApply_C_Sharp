import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './models/user';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Easy Apply';
  users: any; //no type safety

  constructor(private http: HttpClient, private accountService: AccountService){
  }

  ngOnInit() {
      this.getUsers();
      this.setCurrentUser();
  }

  setCurrentUser(){  
    this.accountService.setCurrentUser(JSON.parse(localStorage.getItem('user') || '{}'));
  }

  getUsers(){
    this.http.get('https://localhost:5001/api/users').subscribe(response => {
      this.users = response;
    }, error =>{
      console.log(error);
    });
  }
}
