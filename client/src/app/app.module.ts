import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './register/register.component';
import { HumanResourcesComponent } from './hr/human-resources/human-resources.component';
import { MakeJobComponent } from './hr/make-job/make-job.component';
import { JobListsComponent } from './hr/job-lists/job-lists.component';
import { AboutComponent } from './info/about/about.component';
import { TosComponent } from './info/tos/tos.component';
import { UnknownHomeComponent } from './home/unknown-home/unknown-home.component';
import { CorporationHomeComponent } from './home/corporation-home/corporation-home.component';
import { ApplicantHomeComponent } from './home/applicant-home/applicant-home.component';
import { SharedModule } from './modules/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    HumanResourcesComponent,
    MakeJobComponent,
    JobListsComponent,
    AboutComponent,
    TosComponent,
    UnknownHomeComponent,
    CorporationHomeComponent,
    ApplicantHomeComponent
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
