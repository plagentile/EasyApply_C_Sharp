import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { AuthGuard } from './guards/auth.guard';
import { ApplicantHomeComponent } from './home/applicant-home/applicant-home.component';
import { CorporationHomeComponent } from './home/corporation-home/corporation-home.component';
import { UnknownHomeComponent } from './home/unknown-home/unknown-home.component';
import { HumanResourcesComponent } from './hr/human-resources/human-resources.component';
import { JobListsComponent } from './hr/job-lists/job-lists.component';
import { MakeJobComponent } from './hr/make-job/make-job.component';
import { AboutComponent } from './info/about/about.component';
import { TosComponent } from './info/tos/tos.component';

const routes: Routes = [
  {path: '', component:UnknownHomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path:'humanresources', component:HumanResourcesComponent},
      {path:'joblists', component:JobListsComponent},
      {path:'makejob', component:MakeJobComponent},
      {path:'applicanthome', component:ApplicantHomeComponent},
      {path:'corporationhome', component:CorporationHomeComponent},
    ]
  },

  {path: 'about', component:AboutComponent},
  {path: 'tos', component:TosComponent},
  {path: 'errors', component:TestErrorsComponent},
  {path: '**', component:UnknownHomeComponent, pathMatch: 'full'} //not found, wildcard
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
