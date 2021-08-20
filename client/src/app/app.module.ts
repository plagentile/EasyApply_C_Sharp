import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
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
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

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
    ApplicantHomeComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent
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
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
