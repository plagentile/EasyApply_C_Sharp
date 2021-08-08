import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-unknown-home',
  templateUrl: './unknown-home.component.html',
  styleUrls: ['./unknown-home.component.css']
})
export class UnknownHomeComponent implements OnInit {

  registerMode :boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event : boolean){
    this.registerMode = event;
  }
}
