import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { UnknownHomeComponent } from './home/unknown-home/unknown-home.component';
import { HumanResourcesComponent } from './hr/human-resources/human-resources.component';
import { AboutComponent } from './info/about/about.component';
import { TosComponent } from './info/tos/tos.component';

const routes: Routes = [
  {path: '', component:UnknownHomeComponent},
  {path:'humanresources', component:HumanResourcesComponent, canActivate: [AuthGuard]},
  {path: 'about', component:AboutComponent},
  {path: 'tos', component:TosComponent},
  {path: '**', component:UnknownHomeComponent, pathMatch: 'full'} //not found, wildcard
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
