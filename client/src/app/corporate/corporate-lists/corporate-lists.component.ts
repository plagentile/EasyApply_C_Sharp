import { Component, OnInit } from '@angular/core';
import { Corporation } from 'src/app/models/corporation';
import { CorporationsService } from 'src/app/services/corporations.service';

@Component({
  selector: 'app-corporate-lists',
  templateUrl: './corporate-lists.component.html',
  styleUrls: ['./corporate-lists.component.css']
})
export class CorporateListsComponent implements OnInit {

  corporations: Corporation[];
  
  constructor(private corporateService : CorporationsService) { }

  ngOnInit(): void {
    this.loadCorporations();
  }

  loadCorporations()
  {
    this.corporateService.getCorporations().subscribe(corporations=> 
    {
      this.corporations = corporations;
    });
  }

  getCorporationsWithNameLike(corporateName : string){
    this.corporateService.getCorporationsWithNameLike(corporateName).subscribe(likeCorporations =>
      {
        this.corporations = likeCorporations;
      });
  }
 }
