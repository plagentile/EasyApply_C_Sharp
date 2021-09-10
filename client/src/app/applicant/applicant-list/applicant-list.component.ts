import { Component, OnInit } from '@angular/core';
import { Applicant } from 'src/app/models/applicant';
import { ApplicantsService } from 'src/app/services/applicants.service';

@Component({
  selector: 'app-applicant-list',
  templateUrl: './applicant-list.component.html',
  styleUrls: ['./applicant-list.component.css']
})
export class ApplicantListComponent implements OnInit {

  applicants: Applicant[];

  constructor(private applicantService : ApplicantsService) { 

  }

  ngOnInit(): void {
    this.loadApplicants();
  }

  loadApplicants(){
    this.applicantService.getApplicants().subscribe(applicants =>
    {
        this.applicants = applicants;
    })
  }
}
