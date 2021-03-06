import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContributionDetailsComponent } from './pages/contribution-details/contribution-details.component';
import { ContributionMainComponent } from './pages/contribution-main/contribution-main.component';
import { CreateComponent } from './pages/create/create.component';
import { HomeComponent } from './pages/home/home.component';
import { ListComponent } from './pages/list/list.component';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'list', component: ListComponent },
  { path: 'create', component: CreateComponent },
  { path: 'contribution', component: ContributionMainComponent },
  { path: 'contribution/:id', component: ContributionDetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: '8008135', component: SignupComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
