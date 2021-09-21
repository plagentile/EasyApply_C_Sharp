import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Corporation } from 'src/app/models/corporation';
import { CorporationsService } from 'src/app/services/corporations.service';

@Component({
  selector: 'app-corporate-detail',
  templateUrl: './corporate-detail.component.html',
  styleUrls: ['./corporate-detail.component.css']
})
export class CorporateDetailComponent implements OnInit {

  corporation : Corporation;

  constructor(private corporateService: CorporationsService, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.getCorporation();
  }

  getCorporation() : void{
    this.corporateService.getCorporationByUsername(this.route.snapshot.paramMap.get('username')).subscribe(
      corporation =>{
       this.corporation =  corporation;
      }
    )
  }

}
